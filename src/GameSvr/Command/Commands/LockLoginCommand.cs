﻿using SystemModule;
using GameSvr.CommandSystem;

namespace GameSvr
{
    /// <summary>
    /// 锁定登录
    /// </summary>
    [GameCommand("LockLogin", "锁定登录", 0)]
    public class LockLoginCommand : BaseCommond
    {
        [DefaultCommand]
        public void LockLogin(TPlayObject PlayObject)
        {
            if (!M2Share.g_Config.boLockHumanLogin)
            {
                PlayObject.SysMsg("本服务器还没有启用登录锁功能!!!", TMsgColor.c_Red, TMsgType.t_Hint);
                return;
            }
            if (PlayObject.m_boLockLogon && !PlayObject.m_boLockLogoned)
            {
                PlayObject.SysMsg("您还没有打开登录锁或还没有设置锁密码!!!", TMsgColor.c_Red, TMsgType.t_Hint);
                return;
            }
            PlayObject.m_boLockLogon = !PlayObject.m_boLockLogon;
            if (PlayObject.m_boLockLogon)
            {
                PlayObject.SysMsg("已开启登录锁", TMsgColor.c_Green, TMsgType.t_Hint);
            }
            else
            {
                PlayObject.SysMsg("已关闭登录锁", TMsgColor.c_Green, TMsgType.t_Hint);
            }
        }
    }
}