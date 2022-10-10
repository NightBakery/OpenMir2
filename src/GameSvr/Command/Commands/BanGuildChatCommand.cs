﻿using GameSvr.Player;
using SystemModule.Data;

namespace GameSvr.Command.Commands
{
    [Command("Banguildchat", "", "", 0)]
    public class BanGuildChatCommand : Commond
    {
        [ExecuteCommand]
        public void Banguildchat(PlayObject playObject)
        {
            playObject.BanGuildChat = !playObject.BanGuildChat;
            if (playObject.BanGuildChat)
            {
                playObject.SysMsg(CommandHelp.EnableGuildChat, MsgColor.Green, MsgType.Hint);
            }
            else
            {
                playObject.SysMsg(CommandHelp.DisableGuildChat, MsgColor.Green, MsgType.Hint);
            }
            return;
        }
    }
}