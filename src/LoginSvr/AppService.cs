﻿using LoginSvr.Conf;
using LoginSvr.Services;
using LoginSvr.Storage;
using Microsoft.Extensions.Hosting;
using System.Threading;
using System.Threading.Tasks;
using SystemModule;
using SystemModule.Logger;

namespace LoginSvr
{
    public class AppService : BackgroundService
    {
        private readonly MirLogger _logger;
        private readonly ConfigManager _configManager;
        private readonly SessionServer _masSocService;
        private readonly LoginServer _loginService;
        private readonly AccountStorage _accountStorage;

        public AppService(MirLogger logger, SessionServer masSocService, LoginServer loginService, AccountStorage accountStorage, ConfigManager configManager)
        {
            _logger = logger;
            _masSocService = masSocService;
            _loginService = loginService;
            _accountStorage = accountStorage;
            _configManager = configManager;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.Register(() => _logger.DebugLog("LoginSvr is stopping."));
            _loginService.Start(stoppingToken);
            return Task.CompletedTask;
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.DebugLog("LoginSvr is starting.");
            LsShare.Initialization();
            LoadConfig();
            _loginService.StartServer();
            _masSocService.StartServer();
            _accountStorage.Initialization();
            if (_configManager.Config.PayMode == 1)
            {
                _logger.LogInformation("当前游戏付费模式:收费模式");
            }
            else
            {
                _logger.LogInformation("当前游戏付费模式:免费模式");
            }
            return base.StartAsync(cancellationToken);
        }

        private void LoadConfig()
        {
            _configManager.LoadConfig();
            _configManager.LoadAddrTable();
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.DebugLog("LoginSvr is stopping.");
            return base.StopAsync(cancellationToken);
        }
    }
}