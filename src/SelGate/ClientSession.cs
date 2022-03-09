using System;
using System.Diagnostics;
using System.Net.Sockets;
using SelGate.Conf;
using SelGate.Services;
using SystemModule;
using SystemModule.Packages;

namespace SelGate
{
    /// <summary>
    /// 用户会话封包处理
    /// </summary>
    public class ClientSession
    {
        private int LastDirection = -1;
        private byte _handleLogin = 0;
        private TSessionInfo _session;
        private bool m_fOverClientCount;
        private bool m_KickFlag = false;
        public int m_nSvrListIdx = 0;
        private int m_nSvrObject = 0;
        private int m_SendCheckTick = 0;
        private TCheckStep m_Stat;
        private long m_FinishTick = 0;
        private int m_dwClientTimeOutTick = 0;
        private readonly ClientThread lastGameSvr;
        private readonly ConfigManager _configManager;

        public ClientSession(ConfigManager configManager, TSessionInfo session, ClientThread clientThread)
        {
            _session = session;
            lastGameSvr = clientThread;
            _configManager = configManager;
            m_fOverClientCount = false;
            m_Stat = TCheckStep.CheckLogin;
            m_dwClientTimeOutTick = HUtil32.GetTickCount();
        }

        public TSessionInfo Session => _session;

        private GateConfig Config => _configManager.GateConfig;

        /// <summary>
        /// 处理客户端发送过来的封包
        /// 发送创建角色，删除角色，恢复角色，创建名字等功能
        /// </summary>
        /// <param name="userData"></param>
        public void HandleUserPacket(TMessageData userData)
        {
            int dwCurrentTick = 0;
            /*if (m_KickFlag)
            {
                m_KickFlag = false;
                return;
            }*/
            if ((userData.MsgLen >= 5) && Config.m_fDefenceCCPacket)
            {
                var sMsg = HUtil32.GetString(userData.Body, 2, userData.MsgLen - 3);
                if (sMsg.IndexOf("HTTP/", StringComparison.OrdinalIgnoreCase) > -1)
                {
                    //if (LogManager.Units.LogManager.g_pLogMgr.CheckLevel(6))
                    //{
                    //    Console.WriteLine("CC Attack, Kick: " + m_pUserOBJ.pszIPAddr);
                    //}
                    //Misc.KickUser(m_pUserOBJ.nIPAddr);
                    //Succeed = false;
                    //return;
                }
            }
            if ((m_Stat == TCheckStep.CheckLogin) || (m_Stat == TCheckStep.SendCheck))
            {
                dwCurrentTick = HUtil32.GetTickCount();
                if (0 == m_SendCheckTick)
                {
                    m_SendCheckTick = dwCurrentTick;
                }
                if ((dwCurrentTick - m_SendCheckTick) > 1000 * 5)// 如果5 秒 没有回数据 就下发数据
                {
                    m_Stat = TCheckStep.SendSmu;
                }
            }
            // 如果下发成功  得多少秒有数据如果没有的话，那就是有问题
            if ((m_Stat == TCheckStep.SendFinsh))
            {
                dwCurrentTick = HUtil32.GetTickCount();
                if ((dwCurrentTick - m_FinishTick) > 1000 * 10)
                {
                    //todo 
                }
            }
            var success = false;
            var tempBuff = userData.Body[2..^1];//跳过#....! 只保留消息内容
            var nDeCodeLen = 0;
            var packBuff = Misc.DecodeBuf(tempBuff, userData.MsgLen - 3, ref nDeCodeLen);
            var CltCmd = new TCmdPack(packBuff);
            if (_handleLogin == 0)
            {
                switch (CltCmd.Cmd)
                {
                    //case Grobal2.CM_QUERYSELCHARCODE:
                    case Grobal2.CM_QUERYCHR:
                    case Grobal2.CM_NEWCHR:
                    case Grobal2.CM_DELCHR:
                    case Grobal2.CM_SELCHR:
                        //case Grobal2.CM_QUERYDELCHR:
                        //case Grobal2.CM_GETBACKDELCHR:
                        m_dwClientTimeOutTick = HUtil32.GetTickCount();
                        var sendStr = $"%A{(int)_session.Socket.Handle}/{HUtil32.GetString(userData.Body, 0, userData.MsgLen)}$";
                        lastGameSvr.SendData(sendStr);
                        break;
                    default:
                        Console.WriteLine($"错误的数据包索引:[{CltCmd.Cmd}]");
                        break;
                }
                if (!success)
                {
                    //KickUser("ip");
                }
            }
        }

        /// <summary>
        /// 处理消息
        /// </summary>
        public void HandleDelayMsg(ref bool success)
        {
            if (!m_KickFlag)
            {
                if (_handleLogin < 3)
                {
                    if (HUtil32.GetTickCount() - m_dwClientTimeOutTick > Config.m_nClientTimeOutTime)
                    {
                        m_dwClientTimeOutTick = HUtil32.GetTickCount();
                        SendDefMessage(Grobal2.SM_OUTOFCONNECTION, m_nSvrObject, 0, 0, 0, "");
                        m_KickFlag = true;
                        //BlockUser(this);
                        success = true;
                        Debug.WriteLine($"Client Connect Time Out: {Session.ClientIP}");
                    }
                }
            }
            else
            {
                if (HUtil32.GetTickCount() - m_dwClientTimeOutTick > Config.m_nClientTimeOutTime)
                {
                    m_dwClientTimeOutTick = HUtil32.GetTickCount();
                    _session.Socket.Close();
                    success = true;
                }
            }
        }

        /// <summary>
        /// 处理服务端发送过来的消息并发送到游戏客户端
        /// </summary>
        public void ProcessSvrData(TMessageData sendData)
        {
            if (_session.Socket != null && _session.Socket.Connected)
            {
                _session.Socket.Send(sendData.Body);
            }
        }

        private void SendDefMessage(ushort wIdent, int nRecog, ushort nParam, ushort nTag, ushort nSeries, string sMsg)
        {
            int iLen = 0;
            TCmdPack Cmd;
            byte[] TempBuf = new byte[1048 - 1 + 1];
            byte[] SendBuf = new byte[1048 - 1 + 1];
            if ((lastGameSvr == null) || !lastGameSvr.IsConnected)
            {
                return;
            }
            Cmd = new TCmdPack();
            Cmd.Recog = nRecog;
            Cmd.Ident = wIdent;
            Cmd.Param = nParam;
            Cmd.Tag = nTag;
            Cmd.Series = nSeries;
            SendBuf[0] = (byte)'#';
            //Move(Cmd, TempBuf[1], TCmdPack.PackSize);
            Array.Copy(Cmd.GetPacket(), 0, TempBuf, 0, TCmdPack.PackSize);
            if (!string.IsNullOrEmpty(sMsg))
            {
                //Move(sMsg[1], TempBuf[TCmdPack.PackSize + 1], sMsg.Length);
                var sBuff = HUtil32.GetBytes(sMsg);
                Array.Copy(sBuff, 0, TempBuf, 13, sBuff.Length);
                iLen = Misc.EncodeBuf(TempBuf, TCmdPack.PackSize + sMsg.Length, SendBuf);
            }
            else
            {
                iLen = Misc.EncodeBuf(TempBuf, TCmdPack.PackSize, SendBuf);
            }
            SendBuf[iLen + 1] = (byte)'!';
            _session.Socket.Send(SendBuf, iLen + 2, SocketFlags.None);
        }

        /// <summary>
        /// 通知DBSvr有客户端链接
        /// </summary>
        public void UserEnter()
        {
            _handleLogin = 0;
            var sendStr = $"%K{(int)_session.Socket.Handle}/{_session.ClientIP}/{_session.ClientIP}$";
            lastGameSvr.SendData(sendStr);
        }

        /// <summary>
        /// 通知DBSvr客户端断开链接
        /// </summary>
        public void UserLeave()
        {
            _handleLogin = 0;
            var szSenfBuf = $"%L{(int)_session.Socket.Handle}$";
            lastGameSvr.SendData(szSenfBuf);
            m_KickFlag = false;
        }
    }

    public enum TCheckStep
    {
        CheckLogin,
        SendCheck,
        SendSmu,
        SendFinsh,
        CheckTick
    }
}