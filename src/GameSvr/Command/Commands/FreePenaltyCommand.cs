﻿using GameSvr.Player;
using SystemModule.Data;

namespace GameSvr.Command.Commands
{
    /// <summary>
    /// 清除指定玩家PK值
    /// </summary>
    [GameCommand("FreePenalty", "清除指定玩家PK值", "人物名称", 10)]
    public class FreePenaltyCommand : BaseCommond
    {
        [DefaultCommand]
        public void FreePenalty(string[] @Params, PlayObject PlayObject)
        {
            if (@Params == null)
            {
                return;
            }
            var sHumanName = @Params.Length > 0 ? @Params[0] : "";
            if (!string.IsNullOrEmpty(sHumanName) && sHumanName[0] == '?')
            {
                PlayObject.SysMsg(GameCommand.ShowHelp, MsgColor.Red, MsgType.Hint);
                return;
            }
            var m_PlayObject = M2Share.UserEngine.GetPlayObject(sHumanName);
            if (m_PlayObject == null)
            {
                PlayObject.SysMsg(string.Format(GameCommandConst.NowNotOnLineOrOnOtherServer, sHumanName), MsgColor.Red, MsgType.Hint);
                return;
            }
            m_PlayObject.PkPoint = 0;
            m_PlayObject.RefNameColor();
            m_PlayObject.SysMsg(GameCommandConst.GameCommandFreePKHumanMsg, MsgColor.Green, MsgType.Hint);
            PlayObject.SysMsg(string.Format(GameCommandConst.GameCommandFreePKMsg, sHumanName), MsgColor.Green, MsgType.Hint);
        }
    }
}