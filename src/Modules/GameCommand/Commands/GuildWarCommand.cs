﻿using SystemModule;

namespace CommandSystem.Commands
{
    [Command("GuildWar", "", 10)]
    public class GuildWarCommand : GameCommand
    {
        [ExecuteCommand]
        public void Execute(IPlayerActor PlayerActor)
        {
            if (PlayerActor.Permission < 6)
            {
                return;
            }
        }
    }
}