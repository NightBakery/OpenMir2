﻿using SystemModule;
using SystemModule.Data;
using SystemModule.Packets.ServerPackets;

namespace MarketSystem
{
    public interface IMarketService
    {
        bool IsConnected { get; }

        void Start();

        void Stop();

        void CheckConnected();

        bool RequestLoadPageUserMarket(int actorId, MarKetReqInfo marKetReqInfo);

        void SendFirstMessage();

        bool SendRequest<T>(int queryId, ServerRequestMessage message, T packet);

        bool SendUserMarketSellReady(int actorId, string chrName, int marketNpc);

        void SendUserMarket(INormNpc normNpc, IPlayerActor user, short ItemType, byte UserMode);
    }
}