﻿using GameSvr.Actor;
using GameSvr.Guild;
using GameSvr.Maps;
using GameSvr.Monster.Monsters;
using GameSvr.Player;
using NLog;
using NLog.Fluent;
using SystemModule;
using SystemModule.Common;
using SystemModule.Data;

namespace GameSvr.Castle
{
    public class TUserCastle
    {
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();
        /// <summary>
        /// 守卫列表
        /// </summary>
        public readonly TObjUnit[] Archer = new TObjUnit[CastleConst.MaxCastleArcher];
        /// <summary>
        /// 攻城行会列表
        /// </summary>
        private readonly IList<GuildInfo> m_AttackGuildList;
        /// <summary>
        /// 攻城列表
        /// </summary>
        private readonly IList<TAttackerInfo> m_AttackWarList;
        /// <summary>
        /// 是否显示攻城战役结束消息
        /// </summary>
        public bool m_boShowOverMsg;
        /// <summary>
        /// 是否开始攻城
        /// </summary>
        private bool IsStartWar;
        public bool m_boUnderWar;
        public TObjUnit m_CenterWall;
        public DateTime m_ChangeDate;
        /// <summary>
        /// 城门状态
        /// </summary>
        public TDoorStatus m_DoorStatus;
        /// <summary>
        /// 是否已显示攻城结束信息
        /// </summary>
        private int m_dwSaveTick;
        public int m_dwStartCastleWarTick;
        public IList<string> m_EnvirList;
        public TObjUnit[] m_Guard = new TObjUnit[4];
        public DateTime m_IncomeToday;
        public TObjUnit m_LeftWall;
        public TObjUnit m_MainDoor;
        /// <summary>
        /// 城堡所在地图
        /// </summary>
        public Envirnoment m_MapCastle;
        /// <summary>
        /// 皇宫所在地图
        /// </summary>
        public Envirnoment m_MapPalace;
        private Envirnoment m_MapSecret;
        /// <summary>
        /// 所属行会名称
        /// </summary>
        public GuildInfo m_MasterGuild;
        /// <summary>
        /// 行会回城点X
        /// </summary>
        public int m_nHomeX;
        /// <summary>
        /// 行会回城点Y
        /// </summary>
        public int m_nHomeY;
        public int m_nPalaceDoorX;
        /// <summary>
        /// 科技等级
        /// </summary>
        public int m_nPalaceDoorY;
        private int m_nPower;
        private int m_nTechLevel;
        /// <summary>
        /// 今日收入
        /// </summary>
        public int m_nTodayIncome;
        /// <summary>
        /// 收入多少金币
        /// </summary>
        public int m_nTotalGold;
        public int m_nWarRangeX;
        public int m_nWarRangeY;
        /// <summary>
        /// 皇宫右城墙
        /// </summary>
        public TObjUnit m_RightWall;
        /// <summary>
        /// 皇宫门状态
        /// </summary>
        public string m_sConfigDir = string.Empty;
        /// <summary>
        /// 行会回城点地图
        /// </summary>
        public string m_sHomeMap = string.Empty;
        /// <summary>
        /// 城堡所在地图名
        /// </summary>
        public string m_sMapName = string.Empty;
        /// <summary>
        /// 城堡名称
        /// </summary>
        public string m_sName = string.Empty;
        public string m_sOwnGuild = string.Empty;
        /// <summary>
        /// 皇宫所在地图
        /// </summary>
        public string m_sPalaceMap = string.Empty;
        public string m_sSecretMap = string.Empty;
        public DateTime m_WarDate;
        private readonly CastleConfMgr castleConf;
        /// <summary>
        /// 沙巴克战役列表
        /// </summary>
        private const string AttackSabukWallList = "AttackSabukWall.txt";
        /// <summary>
        /// 沙巴克配置文件
        /// </summary>
        private const string SabukWFileName = "SabukW.txt";

        public TUserCastle(string sCastleDir)
        {
            m_MasterGuild = null;
            m_sHomeMap = M2Share.Config.CastleHomeMap; // '3'
            m_nHomeX = M2Share.Config.CastleHomeX; // 644
            m_nHomeY = M2Share.Config.CastleHomeY; // 290
            m_sName = M2Share.Config.CastleName; // '沙巴克'
            m_sConfigDir = sCastleDir;
            m_sPalaceMap = "0150";
            m_sSecretMap = "D701";
            m_MapCastle = null;
            m_DoorStatus = null;
            IsStartWar = false;
            m_boUnderWar = false;
            m_boShowOverMsg = false;
            m_AttackWarList = new List<TAttackerInfo>();
            m_AttackGuildList = new List<GuildInfo>();
            m_dwSaveTick = 0;
            m_nWarRangeX = M2Share.Config.CastleWarRangeX;
            m_nWarRangeY = M2Share.Config.CastleWarRangeY;
            m_EnvirList = new List<string>();
            var filePath = Path.Combine(M2Share.BasePath, M2Share.Config.CastleDir, m_sConfigDir);
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }
            castleConf = new CastleConfMgr(Path.Combine(filePath, SabukWFileName));
        }

        public int nTechLevel
        {
            get { return m_nTechLevel; }
            set { SetTechLevel(value); }
        }

        public int nPower
        {
            get { return m_nPower; }
            set { SetPower(value); }
        }

        public void Initialize()
        {
            TObjUnit ObjUnit;
            TDoorInfo Door;
            LoadConfig();
            LoadAttackSabukWall();
            if (M2Share.MapMgr.GetMapOfServerIndex(m_sMapName) == M2Share.ServerIndex)
            {
                m_MapPalace = M2Share.MapMgr.FindMap(m_sPalaceMap);
                if (m_MapPalace == null) _logger.Warn($"皇宫地图{m_sPalaceMap}没找到!!!");
                m_MapSecret = M2Share.MapMgr.FindMap(m_sSecretMap);
                if (m_MapSecret == null) _logger.Warn($"密道地图{m_sSecretMap}没找到!!!");
                m_MapCastle = M2Share.MapMgr.FindMap(m_sMapName);
                if (m_MapCastle != null)
                {
                    m_MainDoor.BaseObject = M2Share.UserEngine.RegenMonsterByName(m_sMapName, m_MainDoor.nX, m_MainDoor.nY, m_MainDoor.sName);
                    if (m_MainDoor.BaseObject != null)
                    {
                        m_MainDoor.BaseObject.MWAbil.HP = m_MainDoor.nHP;
                        m_MainDoor.BaseObject.Castle = this;
                        if (m_MainDoor.nStatus)
                        {
                            ((CastleDoor)m_MainDoor.BaseObject).Open();
                        }
                    }
                    else
                    {
                        _logger.Warn("[Error] UserCastle.Initialize MainDoor.UnitObj = nil");
                    }
                    m_LeftWall.BaseObject = M2Share.UserEngine.RegenMonsterByName(m_sMapName, m_LeftWall.nX, m_LeftWall.nY, m_LeftWall.sName);
                    if (m_LeftWall.BaseObject != null)
                    {
                        m_LeftWall.BaseObject.MWAbil.HP = m_LeftWall.nHP;
                        m_LeftWall.BaseObject.Castle = this;
                    }
                    else
                    {
                        _logger.Warn("[错误信息] 城堡初始化城门失败，检查怪物数据库里有没城门的设置: " + m_MainDoor.sName);
                    }
                    m_CenterWall.BaseObject = M2Share.UserEngine.RegenMonsterByName(m_sMapName, m_CenterWall.nX, m_CenterWall.nY, m_CenterWall.sName);
                    if (m_CenterWall.BaseObject != null)
                    {
                        m_CenterWall.BaseObject.MWAbil.HP = m_CenterWall.nHP;
                        m_CenterWall.BaseObject.Castle = this;
                    }
                    else
                    {
                        _logger.Warn("[错误信息] 城堡初始化左城墙失败，检查怪物数据库里有没左城墙的设置: " + m_LeftWall.sName);
                    }
                    m_RightWall.BaseObject = M2Share.UserEngine.RegenMonsterByName(m_sMapName, m_RightWall.nX, m_RightWall.nY, m_RightWall.sName);
                    if (m_RightWall.BaseObject != null)
                    {
                        m_RightWall.BaseObject.MWAbil.HP = m_RightWall.nHP;
                        m_RightWall.BaseObject.Castle = this;
                    }
                    else
                    {
                        _logger.Warn("[错误信息] 城堡初始化中城墙失败，检查怪物数据库里有没中城墙的设置: " + m_CenterWall.sName);
                    }
                    for (var i = 0; i < Archer.Length; i++)
                    {
                        ObjUnit = Archer[i];
                        if (ObjUnit.nHP <= 0) continue;
                        ObjUnit.BaseObject = M2Share.UserEngine.RegenMonsterByName(m_sMapName, ObjUnit.nX, ObjUnit.nY, ObjUnit.sName);
                        if (ObjUnit.BaseObject != null)
                        {
                            ObjUnit.BaseObject.MWAbil.HP = Archer[i].nHP;
                            ObjUnit.BaseObject.Castle = this;
                            ((GuardUnit)ObjUnit.BaseObject).Direction = 3;
                        }
                        else
                        {
                            _logger.Warn("[错误信息] 城堡初始化弓箭手失败，检查怪物数据库里有没弓箭手的设置: " + ObjUnit.sName);
                        }
                    }
                    for (var i = 0; i < m_Guard.Length; i++)
                    {
                        ObjUnit = m_Guard[i];
                        if (ObjUnit.nHP <= 0) continue;
                        ObjUnit.BaseObject = M2Share.UserEngine.RegenMonsterByName(m_sMapName, ObjUnit.nX, ObjUnit.nY, ObjUnit.sName);
                        if (ObjUnit.BaseObject != null)
                            ObjUnit.BaseObject.MWAbil.HP = m_Guard[i].nHP;
                        else
                            _logger.Warn("[错误信息] 城堡初始化守卫失败(检查怪物数据库里有没守卫怪物)");
                    }
                    for (var i = 0; i < m_MapCastle.DoorList.Count; i++)
                    {
                        Door = m_MapCastle.DoorList[i];
                        if (Math.Abs(Door.nX - m_nPalaceDoorX) <= 3 && Math.Abs(Door.nY - m_nPalaceDoorY) <= 3)
                        {
                            m_DoorStatus = Door.Status;
                        }
                    }
                }
                else
                {
                    _logger.Warn($"[错误信息] 城堡所在地图不存在(检查地图配置文件里是否有地图{m_sMapName}的设置)");
                }
            }
        }

        private void LoadConfig()
        {
            castleConf.LoadConfig(this);
            m_MasterGuild = M2Share.GuildMgr.FindGuild(m_sOwnGuild);
        }

        private void SaveConfigFile()
        {
            castleConf.SaveConfig(this);
        }

        /// <summary>
        /// 读取沙巴克战役列表
        /// </summary>
        private void LoadAttackSabukWall()
        {
            var sabukwallPath = Path.Combine(M2Share.BasePath, M2Share.Config.CastleDir, m_sConfigDir);
            var guildName = string.Empty;
            if (!Directory.Exists(sabukwallPath))
                Directory.CreateDirectory(sabukwallPath);
            var sFileName = Path.Combine(sabukwallPath, AttackSabukWallList);
            if (!File.Exists(sFileName)) return;
            var loadList = new StringList();
            loadList.LoadFromFile(sFileName);
            for (var i = 0; i < m_AttackWarList.Count; i++)
            {
                m_AttackWarList[i] = null;
            }
            m_AttackWarList.Clear();
            for (var i = 0; i < loadList.Count; i++)
            {
                var sData = loadList[i];
                var s20 = HUtil32.GetValidStr3(sData, ref guildName, new[] { " ", "\t" });
                var guild = M2Share.GuildMgr.FindGuild(guildName);
                if (guild == null) continue;
                var attackerInfo = new TAttackerInfo();
                HUtil32.ArrestStringEx(s20, "\"", "\"", ref s20);
                if (DateTime.TryParse(s20, out var time))
                {
                    attackerInfo.AttackDate = time;
                }
                else
                {
                    attackerInfo.AttackDate = DateTime.Now;
                }
                attackerInfo.sGuildName = guildName;
                attackerInfo.Guild = guild;
                m_AttackWarList.Add(attackerInfo);
            }
        }

        /// <summary>
        /// 保存沙巴克战役列表
        /// </summary>
        private void SaveAttackSabukWall()
        {
            var sabukwallPath = Path.Combine(M2Share.BasePath, M2Share.Config.CastleDir, m_sConfigDir);
            if (!Directory.Exists(sabukwallPath))
                Directory.CreateDirectory(sabukwallPath);
            var sFileName = Path.Combine(sabukwallPath, AttackSabukWallList);
            using var loadLis = new StringList();
            for (var i = 0; i < m_AttackWarList.Count; i++)
            {
                var attackerInfo = m_AttackWarList[i];
                loadLis.Add(attackerInfo.sGuildName + "       \"" + attackerInfo.AttackDate + '\"');
            }
            loadLis.SaveToFile(sFileName);
        }

        public void Run()
        {
            const string sWarStartMsg = "[{0} 攻城战已经开始]";
            const string sWarStopTimeMsg = "[{0} 攻城战离结束还有{1}分钟]";
            const string sExceptionMsg = "[Exception] TUserCastle::Run";
            try
            {
                if (M2Share.ServerIndex != M2Share.MapMgr.GetMapOfServerIndex(m_sMapName)) return;
                var Year = DateTime.Now.Year;
                var Month = DateTime.Now.Month;
                var Day = DateTime.Now.Day;
                var wYear = m_IncomeToday.Year;
                var wMonth = m_IncomeToday.Month;
                var wDay = m_IncomeToday.Day;
                if (Year != wYear || Month != wMonth || Day != wDay)
                {
                    m_nTodayIncome = 0;
                    m_IncomeToday = DateTime.Now;
                    IsStartWar = false;
                }
                if (!IsStartWar && !m_boUnderWar)
                {
                    var hour = DateTime.Now.Hour;
                    if (hour == M2Share.Config.StartCastlewarTime) // 20
                    {
                        IsStartWar = true;
                        m_AttackGuildList.Clear();
                        for (var i = m_AttackWarList.Count - 1; i >= 0; i--)
                        {
                            var attackerInfo = m_AttackWarList[i];
                            wYear = attackerInfo.AttackDate.Year;
                            wMonth = attackerInfo.AttackDate.Month;
                            wDay = attackerInfo.AttackDate.Day;
                            if (Year == wYear && Month == wMonth && Day == wDay)
                            {
                                m_boUnderWar = true;
                                m_boShowOverMsg = false;
                                m_WarDate = DateTime.Now;
                                m_dwStartCastleWarTick = HUtil32.GetTickCount();
                                m_AttackGuildList.Add(attackerInfo.Guild);
                                attackerInfo = null;
                                m_AttackWarList.RemoveAt(i);
                            }
                        }
                        if (m_boUnderWar)
                        {
                            m_AttackGuildList.Add(m_MasterGuild);
                            StartWallconquestWar();
                            SaveAttackSabukWall();
                            M2Share.UserEngine.SendServerGroupMsg(Grobal2.SS_212, M2Share.ServerIndex, "");
                            var s20 = string.Format(sWarStartMsg, m_sName);
                            M2Share.UserEngine.SendBroadCastMsgExt(s20, MsgType.System);
                            M2Share.UserEngine.SendServerGroupMsg(Grobal2.SS_204, M2Share.ServerIndex, s20);
                            _logger.Info(s20);
                            MainDoorControl(true);
                        }
                    }
                }
                for (var i = 0; i < m_Guard.Length; i++)
                {
                    if (m_Guard[i].BaseObject != null && m_Guard[i].BaseObject.Ghost)
                    {
                        m_Guard[i].BaseObject = null;
                    }
                }
                for (var i = 0; i < Archer.Length; i++)
                {
                    if (Archer[i].BaseObject != null && Archer[i].BaseObject.Ghost)
                    {
                        Archer[i].BaseObject = null;
                    }
                }
                if (m_boUnderWar)
                {
                    if (m_LeftWall.BaseObject != null) m_LeftWall.BaseObject.StoneMode = false;
                    if (m_CenterWall.BaseObject != null) m_CenterWall.BaseObject.StoneMode = false;
                    if (m_RightWall.BaseObject != null) m_RightWall.BaseObject.StoneMode = false;
                    if (!m_boShowOverMsg)
                    {
                        if ((HUtil32.GetTickCount() - m_dwStartCastleWarTick) > (M2Share.Config.CastleWarTime - M2Share.Config.ShowCastleWarEndMsgTime)) // 3 * 60 * 60 * 1000 - 10 * 60 * 1000
                        {
                            m_boShowOverMsg = true;
                            var s20 = string.Format(sWarStopTimeMsg, m_sName, M2Share.Config.ShowCastleWarEndMsgTime / (60 * 1000));
                            M2Share.UserEngine.SendBroadCastMsgExt(s20, MsgType.System);
                            M2Share.UserEngine.SendServerGroupMsg(Grobal2.SS_204, M2Share.ServerIndex, s20);
                            _logger.Warn(s20);
                        }
                    }
                    if ((HUtil32.GetTickCount() - m_dwStartCastleWarTick) > M2Share.Config.CastleWarTime)
                    {
                        StopWallconquestWar();
                    }
                }
                else
                {
                    if (m_LeftWall.BaseObject != null) m_LeftWall.BaseObject.StoneMode = true;
                    if (m_CenterWall.BaseObject != null) m_CenterWall.BaseObject.StoneMode = true;
                    if (m_RightWall.BaseObject != null) m_RightWall.BaseObject.StoneMode = true;
                }
            }
            catch
            {
                _logger.Error(sExceptionMsg);
            }
        }

        public void Save()
        {
            SaveConfigFile();
            SaveAttackSabukWall();
        }

        public bool InCastleWarArea(Envirnoment envir, int nX, int nY)
        {
            if (envir == null)
            {
                return false;
            }
            if (envir == m_MapCastle && Math.Abs(m_nHomeX - nX) < m_nWarRangeX &&
                Math.Abs(m_nHomeY - nY) < m_nWarRangeY) return true;
            if (envir == m_MapPalace || envir == m_MapSecret) return true;
            for (var i = 0; i < m_EnvirList.Count; i++) // 增加取得城堡所有地图列表
                if (m_EnvirList[i] == envir.MapName)
                    return true;
            return false;
        }

        public bool IsMember(BaseObject cert)
        {
            return IsMasterGuild(cert.MyGuild);
        }

        // 检查是否为攻城方行会的联盟行会
        public bool IsAttackAllyGuild(GuildInfo Guild)
        {
            GuildInfo AttackGuild;
            var result = false;
            for (var i = 0; i < m_AttackGuildList.Count; i++)
            {
                AttackGuild = m_AttackGuildList[i];
                if (AttackGuild != m_MasterGuild && AttackGuild.IsAllyGuild(Guild))
                {
                    result = true;
                    break;
                }
            }
            return result;
        }

        // 检查是否为攻城方行会
        public bool IsAttackGuild(GuildInfo Guild)
        {
            GuildInfo AttackGuild;
            var result = false;
            for (var i = 0; i < m_AttackGuildList.Count; i++)
            {
                AttackGuild = m_AttackGuildList[i];
                if (AttackGuild != m_MasterGuild && AttackGuild == Guild)
                {
                    result = true;
                    break;
                }
            }
            return result;
        }

        public bool CanGetCastle(GuildInfo guild)
        {
            if ((HUtil32.GetTickCount() - m_dwStartCastleWarTick) <= M2Share.Config.GetCastleTime)
            {
                return false;
            }
            var playPbjectList = new List<BaseObject>();
            M2Share.UserEngine.GetMapRageHuman(m_MapPalace, 0, 0, 1000, playPbjectList);
            var result = true;
            for (var i = 0; i < playPbjectList.Count; i++)
            {
                var playObject = (PlayObject)playPbjectList[i];
                if (!playObject.Death && playObject.MyGuild != guild)
                {
                    result = false;
                    break;
                }
            }
            playPbjectList = null;
            return result;
        }

        public void GetCastle(GuildInfo Guild)
        {
            const string sGetCastleMsg = "[{0} 已被 {1} 占领]";
            m_sOwnGuild = Guild.sGuildName;
            m_ChangeDate = DateTime.Now;
            SaveConfigFile();
            if (m_MasterGuild != null)
            {
                m_MasterGuild.RefMemberName();//刷新旧的行会信息
            }
            Guild.RefMemberName();//刷新新的行会信息
            var s10 = string.Format(sGetCastleMsg, m_sName, m_sOwnGuild);
            M2Share.UserEngine.SendBroadCastMsgExt(s10, MsgType.System);
            M2Share.UserEngine.SendServerGroupMsg(Grobal2.SS_204, M2Share.ServerIndex, s10);
            _logger.Info(s10);
        }

        public void StartWallconquestWar()
        {
            PlayObject PlayObject;
            var ListC = new List<BaseObject>();
            M2Share.UserEngine.GetMapRageHuman(m_MapPalace, m_nHomeX, m_nHomeY, 100, ListC);
            for (var i = 0; i < ListC.Count; i++)
            {
                PlayObject = (PlayObject)ListC[i];
                PlayObject.RefShowName();
            }
        }

        /// <summary>
        /// 停止沙巴克攻城战役
        /// </summary>
        public void StopWallconquestWar()
        {
            const string sWallWarStop = "[{0} 攻城战已经结束]";
            m_boUnderWar = false;
            m_AttackGuildList.Clear();
            IList<PlayObject> ListC = new List<PlayObject>();
            M2Share.UserEngine.GetMapOfRangeHumanCount(m_MapCastle, m_nHomeX, m_nHomeY, 100);
            for (var i = 0; i < ListC.Count; i++)
            {
                var PlayObject = ListC[i];
                PlayObject.ChangePkStatus(false);
                if (PlayObject.MyGuild != m_MasterGuild)
                {
                    PlayObject.MapRandomMove(PlayObject.HomeMap, 0);
                }
            }
            var s14 = string.Format(sWallWarStop, m_sName);
            M2Share.UserEngine.SendBroadCastMsgExt(s14, MsgType.System);
            M2Share.UserEngine.SendServerGroupMsg(Grobal2.SS_204, M2Share.ServerIndex, s14);
            _logger.Info(s14);
        }

        public int InPalaceGuildCount()
        {
            return m_AttackGuildList.Count;
        }

        public bool IsDefenseAllyGuild(GuildInfo guild)
        {
            if (!m_boUnderWar) return false; // 如果未开始攻城，则无效
            return m_MasterGuild != null && m_MasterGuild.IsAllyGuild(guild);
        }

        // 检查是否为守城方行会
        public bool IsDefenseGuild(GuildInfo guild)
        {
            if (!m_boUnderWar) return false;// 如果未开始攻城，则无效
            return guild == m_MasterGuild;
        }

        public bool IsMasterGuild(GuildInfo guild)
        {
            return m_MasterGuild != null && m_MasterGuild == guild;
        }

        public short GetHomeX()
        {
            return (short)(m_nHomeX - 4 + M2Share.RandomNumber.Random(9));
        }

        public short GetHomeY()
        {
            return (short)(m_nHomeY - 4 + M2Share.RandomNumber.Random(9));
        }

        public string GetMapName()
        {
            return m_sMapName;
        }

        public bool CheckInPalace(int nX, int nY, BaseObject cert)
        {
            TObjUnit ObjUnit;
            var result = IsMasterGuild(cert.MyGuild);
            if (result) return result;
            ObjUnit = m_LeftWall;
            if (ObjUnit.BaseObject != null && ObjUnit.BaseObject.Death && ObjUnit.BaseObject.CurrX == nX &&
                ObjUnit.BaseObject.CurrY == nY) result = true;
            ObjUnit = m_CenterWall;
            if (ObjUnit.BaseObject != null && ObjUnit.BaseObject.Death && ObjUnit.BaseObject.CurrX == nX &&
                ObjUnit.BaseObject.CurrY == nY) result = true;
            ObjUnit = m_RightWall;
            if (ObjUnit.BaseObject != null && ObjUnit.BaseObject.Death && ObjUnit.BaseObject.CurrX == nX &&
                ObjUnit.BaseObject.CurrY == nY) result = true;
            return result;
        }

        public string GetWarDate()
        {
            const string sMsg = "{0}年{1}月{2}日";
            var result = string.Empty;
            if (m_AttackWarList.Count <= 0) return result;
            var AttackerInfo = m_AttackWarList[0];
            var Year = AttackerInfo.AttackDate.Year;
            var Month = AttackerInfo.AttackDate.Month;
            var Day = AttackerInfo.AttackDate.Day;
            return string.Format(sMsg, Year, Month, Day);
        }

        public string GetAttackWarList()
        {
            TAttackerInfo AttackerInfo;
            var result = string.Empty;
            short wYear = 0;
            short wMonth = 0;
            short wDay = 0;
            var n10 = 0;
            for (var i = 0; i < m_AttackWarList.Count; i++)
            {
                AttackerInfo = m_AttackWarList[i];
                var Year = AttackerInfo.AttackDate.Year;
                var Month = AttackerInfo.AttackDate.Month;
                var Day = AttackerInfo.AttackDate.Day;
                if (Year != wYear || Month != wMonth || Day != wDay)
                {
                    wYear = (short)Year;
                    wMonth = (short)Month;
                    wDay = (short)Day;
                    if (result != "") result = result + '\\';
                    result = result + wYear + '年' + wMonth + '月' + wDay + "日\\";
                    n10 = 0;
                }
                if (n10 > 40)
                {
                    result = result + '\\';
                    n10 = 0;
                }
                var s20 = '\"' + AttackerInfo.sGuildName + '\"';
                n10 += s20.Length;
                result = result + s20;
            }
            return result;
        }

        /// <summary>
        /// 增加每日收入
        /// </summary>
        /// <param name="nGold"></param>
        public void IncRateGold(int nGold)
        {
            var nInGold = HUtil32.Round(nGold * (M2Share.Config.CastleTaxRate / 100));
            if (m_nTodayIncome + nInGold <= M2Share.Config.CastleOneDayGold)
            {
                m_nTodayIncome += nInGold;
            }
            else
            {
                if (m_nTodayIncome >= M2Share.Config.CastleOneDayGold)
                {
                    nInGold = 0;
                }
                else
                {
                    nInGold = M2Share.Config.CastleOneDayGold - m_nTodayIncome;
                    m_nTodayIncome = M2Share.Config.CastleOneDayGold;
                }
            }
            if (nInGold > 0)
            {
                if (m_nTotalGold + nInGold < M2Share.Config.CastleGoldMax)
                    m_nTotalGold += nInGold;
                else
                    m_nTotalGold = M2Share.Config.CastleGoldMax;
            }
            if ((HUtil32.GetTickCount() - m_dwSaveTick) > 10 * 60 * 1000)
            {
                m_dwSaveTick = HUtil32.GetTickCount();
                if (M2Share.g_boGameLogGold)
                    M2Share.AddGameDataLog("23" + "\t" + '0' + "\t" + '0' + "\t" + '0' + "\t" + "autosave" + "\t" +
                                           Grobal2.sSTRING_GOLDNAME + "\t" + m_nTotalGold + "\t" + '1' + "\t" + '0');
            }
        }

        /// <summary>
        /// 提取每日收入
        /// </summary>
        /// <param name="PlayObject"></param>
        /// <param name="nGold"></param>
        /// <returns></returns>
        public int WithDrawalGolds(PlayObject PlayObject, int nGold)
        {
            var result = -1;
            if (nGold <= 0)
            {
                result = -4;
                return result;
            }
            if (m_MasterGuild == PlayObject.MyGuild && PlayObject.GuildRankNo == 1)
            {
                if (nGold <= m_nTotalGold)
                {
                    if (PlayObject.Gold + nGold <= M2Share.Config.HumanMaxGold)
                    {
                        m_nTotalGold -= nGold;
                        PlayObject.IncGold(nGold);
                        if (M2Share.g_boGameLogGold)
                            M2Share.AddGameDataLog("22" + "\t" + PlayObject.MapName + "\t" + PlayObject.CurrX +
                                                   "\t" + PlayObject.CurrY + "\t" + PlayObject.CharName + "\t" +
                                                   Grobal2.sSTRING_GOLDNAME + "\t" + nGold + "\t" + '1' + "\t" + '0');
                        PlayObject.GoldChanged();
                        result = 1;
                    }
                    else
                    {
                        result = -3;
                    }
                }
                else
                {
                    result = -2;
                }
            }
            return result;
        }

        public int ReceiptGolds(PlayObject PlayObject, int nGold)
        {
            var result = -1;
            if (nGold <= 0)
            {
                result = -4;
                return result;
            }
            if (m_MasterGuild == PlayObject.MyGuild && PlayObject.GuildRankNo == 1 && nGold > 0)
            {
                if (nGold <= PlayObject.Gold)
                {
                    if (m_nTotalGold + nGold <= M2Share.Config.CastleGoldMax)
                    {
                        PlayObject.Gold -= nGold;
                        m_nTotalGold += nGold;
                        if (M2Share.g_boGameLogGold)
                            M2Share.AddGameDataLog("23" + "\t" + PlayObject.MapName + "\t" + PlayObject.CurrX +
                                                   "\t" + PlayObject.CurrY + "\t" + PlayObject.CharName + "\t" +
                                                   Grobal2.sSTRING_GOLDNAME + "\t" + nGold + "\t" + '1' + "\t" + '0');
                        PlayObject.GoldChanged();
                        result = 1;
                    }
                    else
                    {
                        result = -3;
                    }
                }
                else
                {
                    result = -2;
                }
            }
            return result;
        }

        /// <summary>
        /// 城门控制
        /// </summary>
        /// <param name="boClose"></param>
        public void MainDoorControl(bool boClose)
        {
            if (m_MainDoor.BaseObject != null && !m_MainDoor.BaseObject.Ghost)
            {
                if (boClose)
                {
                    if (((CastleDoor)m_MainDoor.BaseObject).m_boOpened)
                    {
                        ((CastleDoor)m_MainDoor.BaseObject).Close();
                    }
                }
                else
                {
                    if (!((CastleDoor)m_MainDoor.BaseObject).m_boOpened)
                    {
                        ((CastleDoor)m_MainDoor.BaseObject).Open();
                    }
                }
            }
        }

        /// <summary>
        /// 修复城门
        /// </summary>
        /// <returns></returns>
        public bool RepairDoor()
        {
            var result = false;
            var CastleDoor = m_MainDoor;
            if (CastleDoor.BaseObject == null || m_boUnderWar || CastleDoor.BaseObject.MWAbil.HP >= CastleDoor.BaseObject.MWAbil.MaxHP)
            {
                return result;
            }
            if (!CastleDoor.BaseObject.Death)
            {
                if ((HUtil32.GetTickCount() - CastleDoor.BaseObject.StruckTick) > 60 * 1000)
                {
                    CastleDoor.BaseObject.MWAbil.HP = CastleDoor.BaseObject.MWAbil.MaxHP;
                    ((CastleDoor)CastleDoor.BaseObject).RefStatus();
                    result = true;
                }
            }
            else
            {
                if ((HUtil32.GetTickCount() - CastleDoor.BaseObject.StruckTick) > 60 * 1000)
                {
                    CastleDoor.BaseObject.MWAbil.HP = CastleDoor.BaseObject.MWAbil.MaxHP;
                    CastleDoor.BaseObject.Death = false;
                    ((CastleDoor)CastleDoor.BaseObject).m_boOpened = false;
                    ((CastleDoor)CastleDoor.BaseObject).RefStatus();
                    result = true;
                }
            }
            return result;
        }

        /// <summary>
        /// 修复城墙
        /// </summary>
        /// <param name="nWallIndex"></param>
        /// <returns></returns>
        public bool RepairWall(int nWallIndex)
        {
            var result = false;
            BaseObject Wall = null;
            switch (nWallIndex)
            {
                case 1:
                    Wall = m_LeftWall.BaseObject;
                    break;
                case 2:
                    Wall = m_CenterWall.BaseObject;
                    break;
                case 3:
                    Wall = m_RightWall.BaseObject;
                    break;
            }
            if (Wall == null || m_boUnderWar || Wall.MWAbil.HP >= Wall.MWAbil.MaxHP)
            {
                return result;
            }
            if (!Wall.Death)
            {
                if ((HUtil32.GetTickCount() - Wall.StruckTick) > 60 * 1000)
                {
                    Wall.MWAbil.HP = Wall.MWAbil.MaxHP;
                    ((WallStructure)Wall).RefStatus();
                    result = true;
                }
            }
            else
            {
                if ((HUtil32.GetTickCount() - Wall.StruckTick) > 60 * 1000)
                {
                    Wall.MWAbil.HP = Wall.MWAbil.MaxHP;
                    Wall.Death = false;
                    ((WallStructure)Wall).RefStatus();
                    result = true;
                }
            }
            return result;
        }

        public bool AddAttackerInfo(GuildInfo Guild)
        {
            var result = false;
            if (InAttackerList(Guild)) return result;
            var AttackerInfo = new TAttackerInfo();
            AttackerInfo.AttackDate = M2Share.AddDateTimeOfDay(DateTime.Now, M2Share.Config.StartCastleWarDays);
            AttackerInfo.sGuildName = Guild.sGuildName;
            AttackerInfo.Guild = Guild;
            m_AttackWarList.Add(AttackerInfo);
            SaveAttackSabukWall();
            M2Share.UserEngine.SendServerGroupMsg(Grobal2.SS_212, M2Share.ServerIndex, "");
            result = true;
            return result;
        }

        private bool InAttackerList(GuildInfo Guild)
        {
            var result = false;
            for (var i = 0; i < m_AttackWarList.Count; i++)
            {
                if (m_AttackWarList[i].Guild == Guild)
                {
                    result = true;
                    break;
                }
            }
            return result;
        }

        private void SetPower(int nPower)
        {
            m_nPower = nPower;
        }

        private void SetTechLevel(int nLevel)
        {
            m_nTechLevel = nLevel;
        }
    }
}