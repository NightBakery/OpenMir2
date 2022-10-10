﻿using GameSvr.Player;

namespace GameSvr.Command.Commands
{
    /// <summary>
    /// 此命令允许或禁止公会联盟
    /// </summary>
    [Command("Auth", "", 0)]
    public class AuthCommand : Commond
    {
        [ExecuteCommand]
        public void Auth(PlayObject PlayObject)
        {
            if (PlayObject.IsGuildMaster())
            {
                PlayObject.ClientGuildAlly();
            }
        }
    }
}