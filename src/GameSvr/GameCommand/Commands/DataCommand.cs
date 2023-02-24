﻿using GameSvr.Player;
using SystemModule.Enums;

namespace GameSvr.GameCommand.Commands {
    /// <summary>
    /// 查看时间日期
    /// </summary>
    [Command("Date", "查看时间日期", "", 0)]
    public class DataCommand : GameCommand {
        [ExecuteCommand]
        public void Execute(PlayObject PlayObject) {
            PlayObject.SysMsg(CommandHelp.NowCurrDateTime + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), MsgColor.Blue, MsgType.Hint);
        }
    }
}