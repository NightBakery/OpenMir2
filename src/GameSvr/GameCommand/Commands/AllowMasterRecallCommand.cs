﻿using GameSvr.Player;
using SystemModule.Data;
using SystemModule.Enums;

namespace GameSvr.GameCommand.Commands
{
    /// <summary>
    /// 此命令用于允许或禁止师徒传送
    /// </summary>
    [Command("AllowMasterRecall", "此命令用于允许或禁止师徒传送", 0)]
    public class AllowMasterRecallCommand : GameCommand
    {
        [ExecuteCommand]
        public void Execute(PlayObject PlayObject)
        {
            PlayObject.CanMasterRecall = !PlayObject.CanMasterRecall;
            if (PlayObject.CanMasterRecall)
            {
                PlayObject.SysMsg(CommandHelp.EnableMasterRecall, MsgColor.Blue, MsgType.Hint);
            }
            else
            {
                PlayObject.SysMsg(CommandHelp.DisableMasterRecall, MsgColor.Blue, MsgType.Hint);
            }
        }
    }
}