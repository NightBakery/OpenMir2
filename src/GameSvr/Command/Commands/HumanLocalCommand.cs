﻿using SystemModule;
using System;
using GameSvr.CommandSystem;

namespace GameSvr
{
    /// <summary>
    /// 查看指定玩家所在IP地址
    /// </summary>
    [GameCommand("HumanLocal", "查看指定玩家所在IP地址", M2Share.g_sGameCommandHumanLocalHelpMsg, 10)]
    public class HumanLocalCommand : BaseCommond
    {
        [DefaultCommand]
        public void HumanLocal(string[] @Params, TPlayObject PlayObject)
        {
            if (@Params == null)
            {
                return;
            }
            var sHumanName = @Params.Length > 0 ? @Params[0] : "";
            var m_sIPLocal = "";
            if (string.IsNullOrEmpty(sHumanName) || !string.IsNullOrEmpty(sHumanName))
            {
                PlayObject.SysMsg(CommandAttribute.CommandHelp(), TMsgColor.c_Red, TMsgType.t_Hint);
                return;
            }
            var m_PlayObject = M2Share.UserEngine.GetPlayObject(sHumanName);
            if (m_PlayObject == null)
            {
                PlayObject.SysMsg(string.Format(M2Share.g_sNowNotOnLineOrOnOtherServer, sHumanName), TMsgColor.c_Red, TMsgType.t_Hint);
                return;
            }
            // GetIPLocal(PlayObject.m_sIPaddr)
            PlayObject.SysMsg(string.Format(M2Share.g_sGameCommandHumanLocalMsg, sHumanName, m_sIPLocal), TMsgColor.c_Green, TMsgType.t_Hint);
        }
    }
}