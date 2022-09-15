﻿using GameSvr.Actor;
using GameSvr.Maps;
using GameSvr.Monster;
using GameSvr.Monster.Monsters;
using GameSvr.Npc;
using System.Collections;
using SystemModule;
using SystemModule.Data;
using SystemModule.Packet.ClientPackets;

namespace GameSvr.World
{
    public partial class WorldServer
    {
        /// <summary>
        /// 怪物刷新列表
        /// Key:线程ID
        /// Value:怪物列表
        /// </summary>
        public readonly Dictionary<int, IList<MonGenInfo>> MonGenList;
        public readonly Dictionary<string, int> MonGenCountInfo;
        /// <summary>
        /// 怪物对应线程
        /// </summary>
        public readonly Dictionary<string, int> MonThreadMap;
        /// <summary>
        /// 怪物列表
        /// </summary>
        internal readonly IList<TMonInfo> MonsterList;

        private MonsterThread[] MobThreads;
        private Thread[] MobThreading;
        private readonly object _locker = new object();

        private void InitializeMonster()
        {
            for (int i = 0; i < MonsterList.Count; i++)
            {
                for (int j = 0; j < M2Share.WorldEngine.MonGenList.Count; j++)
                {
                    for (int k = 0; k < M2Share.WorldEngine.MonGenList[i].Count; k++)
                    {
                        if (string.Compare(M2Share.WorldEngine.MonGenList[i][k].MonName, MonsterList[i].sName, StringComparison.OrdinalIgnoreCase) == 0)
                        {
                            if (M2Share.WorldEngine.MonThreadMap.ContainsKey(MonsterList[i].sName))
                            {
                                break;
                            }
                            M2Share.WorldEngine.MonThreadMap.Add(MonsterList[i].sName, M2Share.WorldEngine.MonGenList[i][k].ThreadId);
                        }
                    }
                }
            }
            
            for (var i = 0; i < M2Share.Config.ProcessMonsterMultiThreadLimit; i++)
            {
                for (var j = 0; j < MonGenList[i].Count; j++)
                {
                    if (MonGenList[i] != null)
                    {
                        MonGenList[i][j].Race = GetMonRace(MonGenList[i][j].MonName);
                    }
                }
            }
        }

        public void Stop()
        {
            lock (_locker)
            {
                // changing a blocking condition. (this makes the threads wake up!)
                Monitor.PulseAll(_locker);
            }

            //simply intterupt all the mob threads if they are running (will give an invisible error on them but fastest way of getting rid of them on shutdowns)
            for (var i = 0; i < MobThreading.Length; i++)
            {
                if (MobThreads[i] != null)
                {
                    MobThreads[i].EndTime = HUtil32.GetTickCount() + 9999;
                }
                if (MobThreading[i] != null &&
                    MobThreading[i].ThreadState != ThreadState.Stopped && MobThreading[i].ThreadState != ThreadState.Unstarted)
                {
                    MobThreading[i].Interrupt();
                }
            }
        }

        /// <summary>
        /// 初始化怪物运行线程
        /// </summary>
        public void InitializationMonsterThread()
        {
            _logger.Info($"Monster Run thread count:[{M2Share.Config.ProcessMonsterMultiThreadLimit}]");

            MobThreads = new MonsterThread[M2Share.Config.ProcessMonsterMultiThreadLimit];
            MobThreading = new Thread[M2Share.Config.ProcessMonsterMultiThreadLimit];

            //todo 在这里把怪物分配
            
            for (var i = 0; i < M2Share.Config.ProcessMonsterMultiThreadLimit; i++)
            {
                MobThreads[i] = new MonsterThread();
                MobThreads[i].Id = i;
            }

            for (var i = 0; i < M2Share.Config.ProcessMonsterMultiThreadLimit; i++)
            {
                var mobThread = MobThreads[i];
                MobThreading[i] = new Thread(() => ProcessMonsters(mobThread)) { IsBackground = true };
                MobThreading[i].Start();
            }
        }


        /// <summary>
        /// 取怪物刷新时间
        /// </summary>
        /// <returns></returns>
        public int GetMonstersZenTime(int dwTime)
        {
            int result;
            if (dwTime < 30 * 60 * 1000)
            {
                var d10 = (PlayObjectCount - M2Share.Config.UserFull) / HUtil32._MAX(1, M2Share.Config.ZenFastStep);
                if (d10 > 0)
                {
                    if (d10 > 6) d10 = 6;
                    result = (int)(dwTime - Math.Round(dwTime / 10 * (double)d10));
                }
                else
                {
                    result = dwTime;
                }
            }
            else
            {
                result = dwTime;
            }
            return result;
        }

        /// <summary>
        /// 刷新怪物
        /// </summary>
        private void ProcessMonsters(MonsterThread monsterThread)
        {
            if (monsterThread == null)
            {
                return;
            }
            IList<MonGenInfo> mongenList = null;
            if (!MonGenList.TryGetValue(monsterThread.Id, out mongenList))
            {
                return;
            }

            _logger.Info($"Monster thread:{monsterThread.Id} monsters:{mongenList.Count} work.");

            while (true)
            {
                MonGenInfo monGen = null;
                if ((HUtil32.GetTickCount() - RegenMonstersTick) > M2Share.Config.RegenMonstersTime)
                {
                    RegenMonstersTick = HUtil32.GetTickCount();
                    if (monsterThread.CurrMonGenIdx < mongenList.Count)
                    {
                        monGen = mongenList[monsterThread.CurrMonGenIdx];
                    }
                    else if (mongenList.Count > 0)
                    {
                        monGen = mongenList[0];
                    }
                    if (monsterThread.CurrMonGenIdx < mongenList.Count - 1)
                    {
                        monsterThread.CurrMonGenIdx++;
                    }
                    else
                    {
                        monsterThread.CurrMonGenIdx = 0;
                    }
                    if (monGen != null && !string.IsNullOrEmpty(monGen.MonName) && !M2Share.Config.VentureServer)
                    {
                        var nTemp = HUtil32.GetTickCount() - monGen.StartTick;
                        if (monGen.StartTick == 0 || nTemp > GetMonstersZenTime(monGen.ZenTime))
                        {
                            var nGenCount = monGen.ActiveCount; //取已刷出来的怪数量
                            var boRegened = true;
                            var nGenModCount = monGen.Count / M2Share.Config.MonGenRate * 10;
                            var map = M2Share.MapMgr.FindMap(monGen.MapName);
                            bool canCreate;
                            if (map == null || map.Flag.boNOHUMNOMON && map.HumCount <= 0)
                                canCreate = false;
                            else
                                canCreate = true;
                            if (nGenModCount > nGenCount && canCreate)// 增加 控制刷怪数量比例
                            {
                                boRegened = RegenMonsters(monGen, nGenModCount - nGenCount);
                            }
                            if (boRegened)
                            {
                                monGen.StartTick = HUtil32.GetTickCount();
                            }
                        }
                    }
                }

                ProcessMonstersLoop(monsterThread, mongenList);

                Thread.Sleep(20);
            }
        }

        /// <summary>
        /// 怪物处理
        /// 刷新、行动、攻击等动作
        /// </summary>
        private void ProcessMonstersLoop(MonsterThread thread, IList<MonGenInfo> monGenList)
        {
            var dwRunTick = HUtil32.GetTickCount();
            try
            {
                var boProcessLimit = false;
                var dwCurrentTick = HUtil32.GetTickCount();
                var dwMonProcTick = HUtil32.GetTickCount();
                thread.MonsterProcessCount = 0;
                var i = 0;
                for (i = thread.MonGenListPosition; i < monGenList.Count; i++)
                {
                    var monGen = monGenList[i];
                    var processPosition = thread.MonGenCertListPosition < monGen.CertList.Count ? thread.MonGenCertListPosition : 0;
                    thread.MonGenCertListPosition = 0;
                    while (true)
                    {
                        if (processPosition >= monGen.CertList.Count)
                        {
                            break;
                        }
                        var monster = (AnimalObject)monGen.CertList[processPosition];
                        if (monster != null)
                        {
                            if (!monster.Ghost)
                            {
                                if ((dwCurrentTick - monster.RunTick) > monster.RunTime)
                                {
                                    monster.RunTick = dwRunTick;
                                    if (monster.Death && monster.CanReAlive && monster.Invisible && (monster.MonGen != null))
                                    {
                                        if ((HUtil32.GetTickCount() - monster.ReAliveTick) > GetMonstersZenTime(monster.MonGen.ZenTime))
                                        {
                                            if (monster.ReAliveEx(monster.MonGen))
                                            {
                                                monster.ReAliveTick = HUtil32.GetTickCount();
                                            }
                                        }
                                    }
                                    if (!monster.IsVisibleActive && (monster.ProcessRunCount < M2Share.Config.ProcessMonsterInterval))
                                    {
                                        monster.ProcessRunCount++;
                                    }
                                    else
                                    {
                                        if ((dwCurrentTick - monster.SearchTick) > monster.SearchTime)
                                        {
                                            monster.SearchTick = HUtil32.GetTickCount();
                                            if (!monster.Death)
                                            {
                                                monster.SearchViewRange();
                                            }
                                            else
                                            {
                                                monster.SearchViewRangeDeath();
                                            }
                                        }
                                        monster.ProcessRunCount = 0;
                                        monster.Run();
                                    }
                                }
                                thread.MonsterProcessPostion++;
                            }
                            else
                            {
                                if ((HUtil32.GetTickCount() - monster.GhostTick) > 5 * 60 * 1000)
                                {
                                    monGen.CertList.RemoveAt(processPosition);
                                    monGen.CertCount--;
                                    monster = null;
                                    continue;
                                }
                            }
                        }
                        processPosition++;
                        if ((HUtil32.GetTickCount() - dwMonProcTick) > M2Share.g_dwMonLimit)
                        {
                            boProcessLimit = true;
                            thread.MonGenCertListPosition = processPosition;
                            break;
                        }
                    }
                    if (boProcessLimit) break;
                }
                if (MonGenList.Count <= i)
                {
                    thread.MonGenListPosition = 0;
                    _monsterCount = thread.MonsterProcessPostion;
                    thread.MonsterProcessPostion = 0;
                }
                thread.MonGenListPosition = !boProcessLimit ? 0 : i;
            }
            catch (Exception e)
            {
                _logger.Error(e.StackTrace);
            }
        }

        /// <summary>
        /// 获取刷怪数量
        /// </summary>
        /// <param name="monGen"></param>
        /// <returns></returns>
        private int GetGenMonCount(MonGenInfo monGen)
        {
            var nCount = 0;
            for (var i = 0; i < monGen.CertList.Count; i++)
            {
                BaseObject baseObject = monGen.CertList[i];
                if (!baseObject.Death && !baseObject.Ghost)
                {
                    nCount++;
                }
            }
            return nCount;
        }

        public BaseObject RegenMonsterByName(string sMap, short nX, short nY, string sMonName)
        {
            var nRace = GetMonRace(sMonName);
            var baseObject = CreateMonster(sMap, nX, nY, nRace, sMonName);
            if (baseObject != null)
            {
                var threadId = GetMonsterThreadId(sMonName);
                if (threadId >= 0)
                {
                    var n18 = MonGenList[threadId].Count - 1;
                    if (n18 < 0) n18 = 0;
                    if (MonGenList[threadId].Count > n18)
                    {
                        var monGen = MonGenList[threadId][n18];
                        monGen.CertList.Add(baseObject);
                        monGen.CertCount++;
                    }
                    baseObject.Envir.AddObject(baseObject);
                    baseObject.AddToMaped = true;
                }
                else
                {
                    return null;
                }
            }
            return baseObject;
        }

        /// <summary>
        /// 计算怪物掉落物品
        /// 即创建怪物对象的时候已经算好要掉落的物品和属性
        /// </summary>
        /// <returns></returns>
        private void MonGetRandomItems(BaseObject mon)
        {
            IList<TMonItem> itemList = null;
            var itemName = string.Empty;
            for (var i = 0; i < MonsterList.Count; i++)
            {
                var monster = MonsterList[i];
                if (string.Compare(monster.sName, mon.CharName, StringComparison.OrdinalIgnoreCase) == 0)
                {
                    itemList = monster.ItemList;
                    break;
                }
            }
            if (itemList != null)
            {
                for (var i = 0; i < itemList.Count; i++)
                {
                    var monItem = itemList[i];
                    if (M2Share.RandomNumber.Random(monItem.MaxPoint) <= monItem.SelPoint)
                    {
                        if (string.Compare(monItem.ItemName, Grobal2.sSTRING_GOLDNAME, StringComparison.OrdinalIgnoreCase) == 0)
                        {
                            mon.Gold = mon.Gold + monItem.Count / 2 + M2Share.RandomNumber.Random(monItem.Count);
                        }
                        else
                        {
                            if (string.IsNullOrEmpty(itemName)) itemName = monItem.ItemName;
                            UserItem userItem = null;
                            if (CopyToUserItemFromName(itemName, ref userItem))
                            {
                                userItem.Dura = (ushort)HUtil32.Round(userItem.DuraMax / 100 * (20 + M2Share.RandomNumber.Random(80)));
                                var stdItem = GetStdItem(userItem.wIndex);
                                if (stdItem == null) continue;
                                if (M2Share.RandomNumber.Random(M2Share.Config.MonRandomAddValue) == 0) //极品掉落几率
                                {
                                    stdItem.RandomUpgradeItem(userItem);
                                }
                                if (new ArrayList(new byte[] { 15, 19, 20, 21, 22, 23, 24, 26 }).Contains(stdItem.StdMode))
                                {
                                    if (stdItem.Shape == 130 || stdItem.Shape == 131 || stdItem.Shape == 132)
                                    {
                                        stdItem.RandomUpgradeUnknownItem(userItem);
                                    }
                                }
                                mon.ItemList.Add(userItem);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 创建对象
        /// </summary>
        /// <returns></returns>
        private BaseObject CreateMonster(string sMapName, short nX, short nY, int nMonRace, string sMonName)
        {
            BaseObject result = null;
            BaseObject cert = null;
            int n1C;
            int n20;
            int n24;
            object p28;
            var map = M2Share.MapMgr.FindMap(sMapName);
            if (map == null) return null;
            switch (nMonRace)
            {
                case MonsterConst.Supreguard:
                    cert = new SuperGuard();
                    break;
                case MonsterConst.Petsupreguard:
                    cert = new PetSuperGuard();
                    break;
                case MonsterConst.ArcherPolice:
                    cert = new ArcherPolice();
                    break;
                case MonsterConst.AnimalChicken:
                    cert = new MonsterObject
                    {
                        Animal = true,
                        MeatQuality = (ushort)(M2Share.RandomNumber.Random(3500) + 3000),
                        BodyLeathery = 50
                    };
                    break;
                case MonsterConst.AnimalDeer:
                    if (M2Share.RandomNumber.Random(30) == 0)
                        cert = new ChickenDeer
                        {
                            Animal = true,
                            MeatQuality = (ushort)(M2Share.RandomNumber.Random(20000) + 10000),
                            BodyLeathery = 150
                        };
                    else
                        cert = new MonsterObject()
                        {
                            Animal = true,
                            MeatQuality = (ushort)(M2Share.RandomNumber.Random(8000) + 8000),
                            BodyLeathery = 150
                        };
                    break;
                case MonsterConst.AnimalWolf:
                    cert = new AtMonster
                    {
                        Animal = true,
                        MeatQuality = (ushort)(M2Share.RandomNumber.Random(8000) + 8000),
                        BodyLeathery = 150
                    };
                    break;
                case MonsterConst.Trainer:
                    cert = new Trainer();
                    break;
                case MonsterConst.MonsterOma:
                    cert = new MonsterObject();
                    break;
                case MonsterConst.MonsterOmaknight:
                    cert = new AtMonster();
                    break;
                case MonsterConst.MonsterSpitspider:
                    cert = new SpitSpider();
                    break;
                case 83:
                    cert = new SlowAtMonster();
                    break;
                case 84:
                    cert = new Scorpion();
                    break;
                case MonsterConst.MonsterStick:
                    cert = new StickMonster();
                    break;
                case 86:
                    cert = new AtMonster();
                    break;
                case MonsterConst.MonsterDualaxe:
                    cert = new DualAxeMonster();
                    break;
                case 88:
                    cert = new AtMonster();
                    break;
                case 89:
                    cert = new AtMonster();
                    break;
                case 90:
                    cert = new GasAttackMonster();
                    break;
                case 91:
                    cert = new MagCowMonster();
                    break;
                case 92:
                    cert = new CowKingMonster();
                    break;
                case MonsterConst.MonsterThonedark:
                    cert = new ThornDarkMonster();
                    break;
                case MonsterConst.MonsterLightzombi:
                    cert = new LightingZombi();
                    break;
                case MonsterConst.MonsterDigoutzombi:
                    cert = new DigOutZombi();
                    if (M2Share.RandomNumber.Random(2) == 0) cert.Bo2Ba = true;
                    break;
                case MonsterConst.MonsterZilkinzombi:
                    cert = new ZilKinZombi();
                    if (M2Share.RandomNumber.Random(4) == 0) cert.Bo2Ba = true;
                    break;
                case 97:
                    cert = new CowMonster();
                    if (M2Share.RandomNumber.Random(2) == 0) cert.Bo2Ba = true;
                    break;
                case MonsterConst.MonsterWhiteskeleton:
                    cert = new WhiteSkeleton();
                    break;
                case MonsterConst.MonsterSculture:
                    cert = new ScultureMonster
                    {
                        Bo2Ba = true
                    };
                    break;
                case MonsterConst.MonsterScultureking:
                    cert = new ScultureKingMonster();
                    break;
                case MonsterConst.MonsterBeequeen:
                    cert = new BeeQueen();
                    break;
                case 104:
                    cert = new ArcherMonster();
                    break;
                case 105:
                    cert = new GasMothMonster();
                    break;
                case 106: // 楔蛾
                    cert = new GasDungMonster();
                    break;
                case 107:
                    cert = new CentipedeKingMonster();
                    break;
                case 110:
                    cert = new CastleDoor();
                    break;
                case 111:
                    cert = new WallStructure();
                    break;
                case MonsterConst.MonsterArcherguard:
                    cert = new ArcherGuard();
                    break;
                case MonsterConst.MonsterElfmonster:
                    cert = new ElfMonster();
                    break;
                case MonsterConst.MonsterElfwarrior:
                    cert = new ElfWarriorMonster();
                    break;
                case 115:
                    cert = new BigHeartMonster();
                    break;
                case 116:
                    cert = new SpiderHouseMonster();
                    break;
                case 117:
                    cert = new ExplosionSpider();
                    break;
                case 118:
                    cert = new HighRiskSpider();
                    break;
                case 119:
                    cert = new BigPoisionSpider();
                    break;
                case 120:
                    cert = new SoccerBall();
                    break;
                case 130:
                    cert = new DoubleCriticalMonster();
                    break;
                case 131:
                    cert = new RonObject();
                    break;
                case 132:
                    cert = new SandMobObject();
                    break;
                case 133:
                    cert = new MagicMonObject();
                    break;
                case 134:
                    cert = new BoneKingMonster();
                    break;
                case 200:
                    cert = new ElectronicScolpionMon();
                    break;
                case 201:
                    cert = new CloneMonster();
                    break;
                case 203:
                    cert = new TeleMonster();
                    break;
                case 206:
                    cert = new Khazard();
                    break;
                case 208:
                    cert = new GreenMonster();
                    break;
                case 209:
                    cert = new RedMonster();
                    break;
                case 210:
                    cert = new FrostTiger();
                    break;
                case 214:
                    cert = new FireMonster();
                    break;
                case 215:
                    cert = new FireballMonster();
                    break;
            }

            if (cert != null)
            {
                MonInitialize(cert, sMonName);
                cert.Envir = map;
                cert.MapName = sMapName;
                cert.CurrX = nX;
                cert.CurrY = nY;
                cert.Direction = M2Share.RandomNumber.RandomByte(8);
                cert.CharName = sMonName;
                cert.WAbil = cert.Abil;
                cert.OnEnvirnomentChanged();
                if (M2Share.RandomNumber.Random(100) < cert.CoolEyeCode) cert.CoolEye = true;
                MonGetRandomItems(cert);
                cert.Initialize();
                if (cert.AddtoMapSuccess)
                {
                    p28 = null;
                    if (cert.Envir.Width < 50)
                        n20 = 2;
                    else
                        n20 = 3;
                    if (cert.Envir.Height < 250)
                    {
                        if (cert.Envir.Height < 30)
                            n24 = 2;
                        else
                            n24 = 20;
                    }
                    else
                    {
                        n24 = 50;
                    }

                    n1C = 0;
                    while (true)
                    {
                        if (!cert.Envir.CanWalk(cert.CurrX, cert.CurrY, false))
                        {
                            if (cert.Envir.Width - n24 - 1 > cert.CurrX)
                            {
                                cert.CurrX += (short)n20;
                            }
                            else
                            {
                                cert.CurrX = (short)(M2Share.RandomNumber.Random(cert.Envir.Width / 2) + n24);
                                if (cert.Envir.Height - n24 - 1 > cert.CurrY)
                                    cert.CurrY += (short)n20;
                                else
                                    cert.CurrY = (short)(M2Share.RandomNumber.Random(cert.Envir.Height / 2) + n24);
                            }
                        }
                        else
                        {
                            p28 = cert.Envir.AddToMap(cert.CurrX, cert.CurrY, CellType.MovingObject, cert);
                            break;
                        }

                        n1C++;
                        if (n1C >= 31) break;
                    }

                    if (p28 == null)
                        //Cert.Free;
                        cert = null;
                }
            }

            result = cert;
            return result;
        }

        /// <summary>
        /// 创建怪物对象
        /// 在指定时间内创建完对象，则返加TRUE，如果超过指定时间则返回FALSE
        /// </summary>
        /// <returns></returns>
        private bool RegenMonsters(MonGenInfo monGen, int nCount)
        {
            BaseObject cert;
            const string sExceptionMsg = "[Exception] TUserEngine::RegenMonsters";
            var result = true;
            var dwStartTick = HUtil32.GetTickCount();
            try
            {
                if (monGen.Race > 0)
                {
                    short nX;
                    short nY;
                    if (M2Share.RandomNumber.Random(100) < monGen.MissionGenRate)
                    {
                        nX = (short)(monGen.X - monGen.Range + M2Share.RandomNumber.Random(monGen.Range * 2 + 1));
                        nY = (short)(monGen.Y - monGen.Range + M2Share.RandomNumber.Random(monGen.Range * 2 + 1));
                        for (var i = 0; i < nCount; i++)
                        {
                            cert = CreateMonster(monGen.MapName, (short)(nX - 10 + M2Share.RandomNumber.Random(20)), (short)(nY - 10 + M2Share.RandomNumber.Random(20)), monGen.Race, monGen.MonName);
                            if (cert != null)
                            {
                                cert.CanReAlive = true;
                                cert.ReAliveTick = HUtil32.GetTickCount();
                                cert.MonGen = monGen;
                                monGen.ActiveCount++;
                                monGen.CertList.Add(cert);
                            }
                            if ((HUtil32.GetTickCount() - dwStartTick) > M2Share.g_dwZenLimit)
                            {
                                result = false;
                                break;
                            }
                        }
                    }
                    else
                    {
                        for (var i = 0; i < nCount; i++)
                        {
                            nX = (short)(monGen.X - monGen.Range + M2Share.RandomNumber.Random(monGen.Range * 2 + 1));
                            nY = (short)(monGen.Y - monGen.Range + M2Share.RandomNumber.Random(monGen.Range * 2 + 1));
                            cert = CreateMonster(monGen.MapName, nX, nY, monGen.Race, monGen.MonName);
                            if (cert != null)
                            {
                                cert.CanReAlive = true;
                                cert.ReAliveTick = HUtil32.GetTickCount();
                                cert.MonGen = monGen;
                                monGen.ActiveCount++;
                                monGen.CertList.Add(cert);
                            }
                            if (HUtil32.GetTickCount() - dwStartTick > M2Share.g_dwZenLimit)
                            {
                                result = false;
                                break;
                            }
                        }
                    }
                }
            }
            catch
            {
                _logger.Error(sExceptionMsg);
            }
            return result;
        }

        private void MonInitialize(BaseObject baseObject, string sMonName)
        {
            for (var i = 0; i < MonsterList.Count; i++)
            {
                TMonInfo monster = MonsterList[i];
                if (string.Compare(monster.sName, sMonName, StringComparison.OrdinalIgnoreCase) == 0)
                {
                    baseObject.Race = monster.btRace;
                    baseObject.RaceImg = monster.btRaceImg;
                    baseObject.Appr = monster.wAppr;
                    baseObject.Abil.Level = (byte)monster.wLevel;
                    baseObject.LifeAttrib = monster.btLifeAttrib;
                    baseObject.CoolEyeCode = (byte)monster.wCoolEye;
                    baseObject.FightExp = monster.dwExp;
                    baseObject.Abil.HP = monster.wHP;
                    baseObject.Abil.MaxHP = monster.wHP;
                    baseObject.MonsterWeapon = HUtil32.LoByte(monster.wMP);
                    baseObject.Abil.MP = 0;
                    baseObject.Abil.MaxMP = monster.wMP;
                    baseObject.Abil.AC = HUtil32.MakeLong(monster.wAC, monster.wAC);
                    baseObject.Abil.MAC = HUtil32.MakeLong(monster.wMAC, monster.wMAC);
                    baseObject.Abil.DC = HUtil32.MakeLong(monster.wDC, monster.wMaxDC);
                    baseObject.Abil.MC = HUtil32.MakeLong(monster.wMC, monster.wMC);
                    baseObject.Abil.SC = HUtil32.MakeLong(monster.wSC, monster.wSC);
                    baseObject.SpeedPoint = (byte)monster.wSpeed;
                    baseObject.HitPoint = (byte)monster.wHitPoint;
                    baseObject.WalkSpeed = monster.wWalkSpeed;
                    baseObject.WalkStep = monster.wWalkStep;
                    baseObject.WalkWait = monster.wWalkWait;
                    baseObject.NextHitTime = monster.wAttackSpeed;
                    baseObject.NastyMode = monster.boAggro;
                    baseObject.NoTame = monster.boTame;
                    break;
                }
            }
        }

    }
}