﻿using LoginGate.Services;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;
using SystemModule;

namespace LoginGate
{
    public class TimedService : BackgroundService
    {
        private int _processDelayTick = 0;
        private readonly MirLogger _logger;
        private readonly SessionManager _sessionManager;
        private readonly ClientManager _clientManager;

        public TimedService(MirLogger logger, ClientManager clientManager, SessionManager sessionManager)
        {
            _logger = logger;
            _clientManager = clientManager;
            _sessionManager = sessionManager;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _processDelayTick = HUtil32.GetTickCount();
            while (!stoppingToken.IsCancellationRequested)
            {
                ProcessDelayMsg();
                await Task.Delay(TimeSpan.FromSeconds(5), stoppingToken);
            }
        }
        
        private void ProcessDelayMsg()
        {
            if (HUtil32.GetTickCount() - _processDelayTick > 1000)
            {
                _processDelayTick = HUtil32.GetTickCount();
                var clientList = _clientManager.ServerGateList();
                for (var i = 0; i < clientList.Count; i++)
                {
                    if (clientList[i] == null)
                    {
                        continue;
                    }
                    _clientManager.ProcessClientThreadState(clientList[i]);
                    if (clientList[i].SessionArray == null)
                    {
                        continue;
                    }
                    for (var j = 0; j < clientList[i].SessionArray.Length; j++)
                    {
                        var session = clientList[i].SessionArray[j];
                        if (session == null)
                        {
                            continue;
                        }
                        if (session.Socket == null)
                        {
                            continue;
                        }
                        var userSession = _sessionManager.GetSession(session.ConnectionId);
                        if (userSession == null)
                        {
                            continue;
                        }
                        var success = false;
                        userSession.HandleDelayMsg(ref success);
                        if (success)
                        {
                            _sessionManager.CloseSession(session.ConnectionId);
                            clientList[i].SessionArray[j].Socket = null;
                            clientList[i].SessionArray[j] = null;
                        }
                    }
                }
            }
        }
    }
}