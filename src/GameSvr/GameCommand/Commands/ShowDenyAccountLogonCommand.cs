﻿using GameSvr.Player;
using SystemModule.Enums;

namespace GameSvr.GameCommand.Commands {
    [Command("ShowDenyAccountLogon", "", 10)]
    public class ShowDenyAccountLogonCommand : GameCommand {
        [ExecuteCommand]
        public void Execute(PlayObject PlayObject) {
            if (PlayObject.Permission < 6) {
                return;
            }
            try {
                if (M2Share.DenyAccountList.Count <= 0) {
                    PlayObject.SysMsg("禁止登录帐号列表为空。", MsgColor.Green, MsgType.Hint);
                    return;
                }
                for (int i = 0; i < M2Share.DenyAccountList.Count; i++) {
                    //PlayObject.SysMsg(Settings.g_DenyAccountList[i], TMsgColor.c_Green, TMsgType.t_Hint);
                }
            }
            finally {
            }
        }
    }
}