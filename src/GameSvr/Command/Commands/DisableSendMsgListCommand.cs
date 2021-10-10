﻿using SystemModule;
using GameSvr.CommandSystem;

namespace GameSvr
{
    [GameCommand("DisableSendMsgList", "", 10)]
    public class DisableSendMsgListCommand : BaseCommond
    {
        [DefaultCommand]
        public void DisableSendMsgList(TPlayObject PlayObject)
        {
            if (M2Share.g_DisableSendMsgList.Count <= 0)
            {
                PlayObject.SysMsg("禁言列表为空!!!", TMsgColor.c_Red, TMsgType.t_Hint);
                return;
            }
            PlayObject.SysMsg("禁言列表:", TMsgColor.c_Blue, TMsgType.t_Hint);
            for (var i = 0; i < M2Share.g_DisableSendMsgList.Count; i++)
            {
                //PlayObject.SysMsg(M2Share.g_DisableSendMsgList[i], TMsgColor.c_Green, TMsgType.t_Hint);
            }
        }
    }
}