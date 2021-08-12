﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using SystemModule;

namespace M2Server
{
    public partial class TBaseObject
    {
        public int ObjectId;
        public string m_sMapName;
        public string m_sMapFileName;
        public string m_sCharName;
        /// <summary>
        /// 人物所在座标X
        /// </summary>
        public short m_nCurrX = 0;
        /// <summary>
        /// 人物所在座标Y
        /// </summary>
        public short m_nCurrY = 0;
        /// <summary>
        /// 人物所在方向
        /// </summary>
        public byte m_btDirection = 0;
        /// <summary>
        /// 人物的性别
        /// </summary>
        public byte m_btGender = 0;
        /// <summary>
        /// 人物的头发
        /// </summary>
        public byte m_btHair = 0;
        /// <summary>
        /// 人物的职业
        /// </summary>
        public byte m_btJob = 0;
        /// <summary>
        /// 人物金币数
        /// </summary>
        public int m_nGold = 0;
        public TAbility m_Abil = null;
        /// <summary>
        /// 状态值
        /// </summary>
        public long m_nCharStatus = 0;
        /// <summary>
        /// 回城地图
        /// </summary>
        public string m_sHomeMap;
        /// <summary>
        /// 回城座标X
        /// </summary>
        public short m_nHomeX = 0;
        /// <summary>
        /// 回城座标Y
        /// </summary>
        public short m_nHomeY = 0;
        public bool bo94 = false;
        public bool m_boOnHorse = false;
        public byte m_btHorseType = 0;
        public byte m_btDressEffType = 0;
        /// <summary>
        /// 人物的PK值
        /// </summary>
        public int m_nPkPoint = 0;
        /// <summary>
        /// 允许组队
        /// </summary>
        public bool m_boAllowGroup = false;
        /// <summary>
        /// 允许加入行会
        /// </summary>        
        public bool m_boAllowGuild = false;
        public byte btB2 = 0;
        public int m_nIncHealth = 0;
        public int m_nIncSpell = 0;
        public int m_nIncHealing = 0;
        public int m_nIncHPStoneTime = 0;
        public int m_nIncMPStoneTime = 0;
        /// <summary>
        /// 在行会占争地图中死亡次数
        /// </summary>
        public int m_nFightZoneDieCount = 0;
        public int nC4 = 0;
        public byte btC8 = 0;
        public TNakedAbility m_BonusAbil = null;
        public TNakedAbility m_CurBonusAbil = null;
        public int m_nBonusPoint = 0;
        public int m_nHungerStatus = 0;
        public bool m_boAllowGuildReCall = false;
        public double m_dBodyLuck = 0;
        public int m_nBodyLuckLevel = 0;
        public short m_wGroupRcallTime = 0;
        public bool m_boAllowGroupReCall = false;
        public byte[] m_QuestUnitOpen;
        public byte[] m_QuestUnit;
        public byte[] m_QuestFlag;
        public long m_nCharStatusEx = 0;
        /// <summary>
        /// 怪物经验值
        /// </summary>
        public int m_dwFightExp = 0;
        public TAbility m_WAbil = null;
        public TAddAbility m_AddAbil = null;
        /// <summary>
        /// 可视范围大小
        /// </summary>
        public int m_nViewRange = 0;
        public ushort[] m_wStatusTimeArr;
        public int[] m_dwStatusArrTick = new int[12];
        public ushort[] m_wStatusArrValue = null;
        public int[] m_dwStatusArrTimeOutTick = null;
        public ushort m_wAppr = 0;
        /// <summary>
        /// 角色类型
        /// </summary>
        public byte m_btRaceServer = 0;
        /// <summary>
        /// 角色外形
        /// </summary>
        public byte m_btRaceImg = 0;
        /// <summary>
        /// 人物攻击准确度
        /// </summary>
        public byte m_btHitPoint = 0;
        public ushort m_nHitPlus = 0;
        public ushort m_nHitDouble = 0;
        /// <summary>
        /// 记忆使用间隔
        /// </summary>
        public int m_dwGroupRcallTick = 0;
        /// <summary>
        /// 记忆全套
        /// </summary>
        public bool m_boRecallSuite = false;
        public bool m_boRaceImg = false;
        public ushort m_nHealthRecover = 0;
        public ushort m_nSpellRecover = 0;
        public byte m_btAntiPoison = 0;
        public ushort m_nPoisonRecover = 0;
        public ushort m_nAntiMagic = 0;
        /// <summary>
        /// 人物的幸运值
        /// </summary>
        public int m_nLuck = 0;
        public int m_nPerHealth = 0;
        public int m_nPerHealing = 0;
        public int m_nPerSpell = 0;
        public int m_dwIncHealthSpellTick = 0;
        /// <summary>
        /// 中绿毒降HP点数
        /// </summary>
        public byte m_btGreenPoisoningPoint = 0;
        /// <summary>
        /// 人物身上最多可带金币数
        /// </summary>
        public int m_nGoldMax = 0;
        /// <summary>
        /// 敏捷度
        /// </summary>
        public byte m_btSpeedPoint = 0;
        /// <summary>
        /// 权限等级
        /// </summary>
        public byte m_btPermission = 0;
        public ushort m_nHitSpeed = 0;
        public byte m_btLifeAttrib = 0;
        public byte m_btCoolEye = 0;
        public TBaseObject m_GroupOwner = null;
        /// <summary>
        /// 组成员
        /// </summary>
        public IList<TPlayObject> m_GroupMembers = null;
        /// <summary>
        /// 允许私聊
        /// </summary>
        public bool m_boHearWhisper = false;
        /// <summary>
        /// 允许群聊
        /// </summary>
        public bool m_boBanShout = false;
        /// <summary>
        /// 拒绝行会聊天
        /// </summary>
        public bool m_boBanGuildChat = false;
        /// <summary>
        /// 是不允许交易
        /// </summary>
        public bool m_boAllowDeal = false;
        /// <summary>
        /// 禁止私聊人员列表
        /// </summary>
        public IList<string> m_BlockWhisperList = null;
        public int m_dwShoutMsgTick = 0;
        /// <summary>
        /// 是否被召唤(主人)
        /// </summary>
        public TBaseObject m_Master = null;
       /// <summary>
       /// 怪物叛变时间
       /// </summary>
        public int m_dwMasterRoyaltyTick = 0;
        public int m_dwMasterTick = 0;
        /// <summary>
        /// 杀怪计数
        /// </summary>
        public int m_nKillMonCount = 0;
        /// <summary>
        /// 宝宝等级(1-7)
        /// </summary>
        public byte m_btSlaveExpLevel = 0;
        /// <summary>
        /// 召唤等级
        /// </summary>
        public byte m_btSlaveMakeLevel = 0;
        /// <summary>
        /// 下属列表
        /// </summary>        
        public IList<TBaseObject> m_SlaveList = null;
        public byte bt2A0 = 0;
        /// <summary>
        /// 宝宝攻击状态(休息/攻击)
        /// </summary>
        public bool m_boSlaveRelax = false;
        /// <summary>
        /// 下属攻击状态
        /// </summary>
        public byte m_btAttatckMode = 0;
        /// <summary>
        /// 人物名字的颜色
        /// </summary>        
        public byte m_btNameColor = 0;
        /// <summary>
        /// 亮度
        /// </summary>
        public int m_nLight = 0;
        /// <summary>
        /// 行会占争范围
        /// </summary>
        public bool m_boGuildWarArea = false;
        /// <summary>
        /// 所属城堡
        /// </summary>
        public TUserCastle m_Castle = null;
        public bool bo2B0 = false;
        public int m_dw2B4Tick = 0;
        /// <summary>
        /// 无敌模式
        /// </summary>
        public bool m_boSuperMan = false;
        public bool bo2B9 = false;
        public bool bo2BA = false;
        public bool m_boAnimal = false;
        public bool m_boNoItem = false;
        public bool m_boFixedHideMode = false;
        public bool m_boStickMode = false;
        public bool bo2BF = false;
        public bool m_boNoAttackMode = false;
        public bool m_boNoTame = false;
        public bool m_boSkeleton = false;
        public ushort m_nMeatQuality = 0;
        public int m_nBodyLeathery = 0;
        public bool m_boHolySeize = false;
        public int m_dwHolySeizeTick = 0;
        public int m_dwHolySeizeInterval = 0;
        public bool m_boCrazyMode = false;
        public int m_dwCrazyModeTick = 0;
        public int m_dwCrazyModeInterval = 0;
        public bool m_boShowHP = false;
        public int m_dwShowHPTick = 0;
        // 0x2E8  心灵启示检查时间(Dword)
        public int m_dwShowHPInterval = 0;
        // 0x2EC  心灵启示有效时长(Dword)
        public bool bo2F0 = false;
        public int m_dwDupObjTick = 0;
        public TEnvirnoment m_PEnvir = null;
        public bool m_boGhost = false;
        public int m_dwGhostTick = 0;
        public bool m_boDeath = false;
        public int m_dwDeathTick = 0;
        /// <summary>
        /// 怪物所拿的武器
        /// </summary>
        public byte m_btMonsterWeapon = 0;
        public int m_dwStruckTick = 0;
        public bool m_boWantRefMsg = false;
        public bool m_boAddtoMapSuccess = false;
        public bool m_bo316 = false;
        public bool m_boDealing = false;
        /// <summary>
        /// 交易最后操作时间
        /// </summary>
        public int m_DealLastTick = 0;
        public TBaseObject m_DealCreat = null;
        public TGuild m_MyGuild = null;
        public int m_nGuildRankNo = 0;
        public string m_sGuildRankName = string.Empty;
        public string m_sScriptLable = string.Empty;
        public byte m_btAttackSkillCount = 0;
        public byte m_btAttackSkillPointCount = 0;
        public bool m_boMission = false;
        public short m_nMissionX = 0;
        public short m_nMissionY = 0;
        public bool m_boHideMode = false;
        // 0x344  隐身戒指(Byte)
        public bool m_boStoneMode = false;
        public bool m_boCoolEye = false;
        // 0x346  //是否可以看到隐身人物
        public bool m_boUserUnLockDurg = false;
        // 0x347  //是否用了神水
        public bool m_boTransparent = false;
        // 0x348  //魔法隐身了
        public bool m_boAdminMode = false;
        // 0x349  管理模式(Byte)
        public bool m_boObMode = false;
        // 0x34A  隐身模式(Byte)
        public bool m_boTeleport = false;
        // 0x34B  传送戒指(Byte)
        public bool m_boParalysis = false;
        // 0x34C  麻痹戒指(Byte)
        public bool m_boUnParalysis = false;
        public bool m_boRevival = false;
        // 0x34D  复活戒指(Byte)
        public bool m_boUnRevival = false;
        // 防复活
        public int m_dwRevivalTick = 0;
        // 0x350  复活戒指使用间隔计数(Dword)
        public bool m_boFlameRing = false;
        // 0x354  火焰戒指(Byte)
        public bool m_boRecoveryRing = false;
        // 0x355  治愈戒指(Byte)
        public bool m_boAngryRing = false;
        // 0x356  未知戒指(Byte)
        public bool m_boMagicShield = false;
        // 0x357  护身戒指(Byte)
        public bool m_boUnMagicShield = false;
        // 防护身
        public bool m_boMuscleRing = false;
        // 0x358  活力戒指(Byte)
        public bool m_boFastTrain = false;
        // 0x359  技巧项链(Byte)
        public bool m_boProbeNecklace = false;
        // 0x35A  探测项链(Byte)
        public bool m_boGuildMove = false;
        // 行会传送
        public bool m_boSupermanItem = false;
        public bool m_bopirit = false;
        // 祈祷
        public bool m_boNoDropItem = false;
        public bool m_boNoDropUseItem = false;
        public bool m_boExpItem = false;
        public bool m_boPowerItem = false;
        public int m_rExpItem = 0;
        public int m_rPowerItem = 0;
        public int m_dwPKDieLostExp = 0;
        // PK 死亡掉经验，不够经验就掉等级
        public int m_nPKDieLostLevel = 0;
        // PK 死亡掉等级
        public bool m_boAbilSeeHealGauge = false;
        // 0x35B  //心灵启示
        public bool m_boAbilMagBubbleDefence = false;
        // 0x35C  //魔法盾
        public byte m_btMagBubbleDefenceLevel = 0;
        public int m_dwSearchTime = 0;
        public int m_dwSearchTick = 0;
        /// <summary>
        /// 上次运行时间
        /// </summary>
        public int m_dwRunTick = 0;
        public int m_nRunTime = 0;
        public int m_nHealthTick = 0;
        public int m_nSpellTick = 0;
        public TBaseObject m_TargetCret = null;
        public int m_dwTargetFocusTick = 0;
        /// <summary>
        /// 人物被对方杀害时对方指针
        /// </summary>
        public TBaseObject m_LastHiter = null;
        public int m_LastHiterTick = 0;
        public TBaseObject m_ExpHitter = null;
        public int m_ExpHitterTick = 0;
        /// <summary>
        /// 传送戒指使用间隔
        /// </summary>
        public int m_dwTeleportTick = 0;
        /// <summary>
        /// 探测项链使用间隔
        /// </summary>
        public int m_dwProbeTick = 0;
        public int m_dwMapMoveTick = 0;
        /// <summary>
        /// 人物攻击变色标志
        /// </summary>
        public bool m_boPKFlag = false;
        /// <summary>
        /// 人物攻击变色时间长度
        /// </summary>
        public int m_dwPKTick = 0;
        public int m_nMoXieSuite = 0;
        // 0x3A4  魔血一套(Dword)
        public int m_nHongMoSuite = 0;
        // 0x3A8 虹魔一套(Dword)
        public double m_db3B0 = 0;
        /// <summary>
        /// 中毒处理间隔时间
        /// </summary>
        public int m_dwPoisoningTick = 0;
        /// <summary>
        /// 减PK值时间
        /// </summary>
        public int m_dwDecPkPointTick = 0;
        public int m_DecLightItemDrugTick = 0;
        public int m_dwVerifyTick = 0;
        public int m_dwCheckRoyaltyTick = 0;
        public int m_dwDecHungerPointTick = 0;
        public int m_dwHPMPTick = 0;
        public IList<SendMessage> m_MsgList = null;
        public IList<TBaseObject> m_VisibleHumanList = null;
        public IList<TVisibleMapItem> m_VisibleItems = null;
        public IList<TEvent> m_VisibleEvents = null;
        public int m_SendRefMsgTick = 0;
        /// <summary>
        /// 是否在开行会战
        /// </summary>
        public bool m_boInFreePKArea = false;
        public int m_dwHitTick = 0;
        public int m_dwWalkTick = 0;
        public int m_dwSearchEnemyTick = 0;
        public bool m_boNameColorChanged = false;
        /// <summary>
        /// 是否在可视范围内有人物,及宝宝
        /// </summary>
        public bool m_boIsVisibleActive = false;
        /// <summary>
        /// 当前处理数量
        /// </summary>
        public short m_nProcessRunCount = 0;
        public IList<TVisibleBaseObject> m_VisibleActors = null;
        /// <summary>
        /// 人物背包(Dword)数量
        /// </summary>
        public IList<TUserItem> m_ItemList = null;
        /// <summary>
        /// 交易列表
        /// </summary>
        public IList<TUserItem> m_DealItemList = null;
        /// <summary>
        /// 交易的金币数量
        /// </summary>
        public int m_nDealGolds = 0;
        /// <summary>
        /// 确认交易标志
        /// </summary>
        public bool m_boDealOK = false;
        /// <summary>
        /// 技能表
        /// </summary>
        public IList<TUserMagic> m_MagicList = null;
        public TUserItem[] m_UseItems;
        public IList<TMonSayMsg> m_SayMsgList = null;
        public IList<TUserItem> m_StorageItemList = null;
        public int m_nWalkSpeed = 0;
        public int m_nWalkStep = 0;
        public int m_nWalkCount = 0;
        public int m_dwWalkWait = 0;
        public int m_dwWalkWaitTick = 0;
        public bool m_boWalkWaitLocked = false;
        public int m_nNextHitTime = 0;
        public TUserMagic m_MagicOneSwordSkill = null;
        public TUserMagic m_MagicPowerHitSkill = null;
        /// <summary>
        /// 刺杀剑法
        /// </summary>
        public TUserMagic m_MagicErgumSkill = null;
        /// <summary>
        /// 半月弯刀
        /// </summary>
        public TUserMagic m_MagicBanwolSkill = null;
        public TUserMagic m_MagicRedBanwolSkill = null;
        public TUserMagic m_MagicFireSwordSkill = null;
        public TUserMagic m_MagicCrsSkill = null;
        public TUserMagic m_Magic41Skill = null;
        public TUserMagic m_MagicTwnHitSkill = null;
        public TUserMagic m_Magic43Skill = null;
        public bool m_boPowerHit = false;
        public bool m_boUseThrusting = false;
        public bool m_boUseHalfMoon = false;
        public bool m_boRedUseHalfMoon = false;
        public bool m_boFireHitSkill = false;
        public bool m_boCrsHitkill = false;
        public bool m_bo41kill = false;
        public bool m_boTwinHitSkill = false;
        public bool m_bo43kill = false;
        public int m_dwLatestFireHitTick = 0;
        public int m_dwDoMotaeboTick = 0;
        public int m_dwLatestTwinHitTick = 0;
        public bool m_boDenyRefStatus = false;
        // 是否刷新在地图上信息；
        public bool m_boAddToMaped = false;
        // 是否增加地图计数
        public bool m_boDelFormMaped = false;
        // 是否从地图中删除计数
        public bool m_boAutoChangeColor = false;
        public int m_dwAutoChangeColorTick = 0;
        public int m_nAutoChangeIdx = 0;
        public bool m_boFixColor = false;
        // 固定颜色
        public int m_nFixColorIdx = 0;
        public long m_nFixStatus = 0;
        public bool m_boFastParalysis = false;
        // 快速麻痹，受攻击后麻痹立即消失
        public bool m_boSmashSet = false;
        public bool m_boHwanDevilSet = false;
        public bool m_boPuritySet = false;
        public bool m_boMundaneSet = false;
        public bool m_boNokChiSet = false;
        public bool m_boTaoBuSet = false;
        public bool m_boFiveStringSet = false;
        public bool m_boOffLineFlag = false;
        // 挂机
        public string m_sOffLineLeaveword = string.Empty;
        // 挂机字符
        public int m_dwKickOffLineTick = 0;
        public bool m_boNastyMode = false;
        public int m_nAutoAddHPMPMode = 0;
        // 气血石
        public int m_dwCheckHPMPTick = 0;
        public long dwTick3F4 = 0;
        /// <summary>
        /// 是否机器人
        /// </summary>
        public bool m_boAI;

        public TBaseObject()
        {
            ObjectId = HUtil32.Sequence();
            m_boGhost = false;
            m_dwGhostTick = 0;
            m_boDeath = false;
            m_dwDeathTick = 0;
            m_SendRefMsgTick = HUtil32.GetTickCount();
            m_btDirection = 4;
            m_btRaceServer = Grobal2.RC_ANIMAL;
            m_btRaceImg = 0;
            m_btHair = 0;
            m_btJob = M2Share.jWarr;
            m_nGold = 0;
            m_wAppr = 0;
            bo2B9 = true;
            m_nViewRange = 5;
            m_sHomeMap = "0";
            bo94 = false;
            m_btPermission = 0;
            m_nLight = 0;
            m_btNameColor = 255;
            m_nHitPlus = 0;
            m_nHitDouble = 0;
            m_dBodyLuck = 0;
            m_wGroupRcallTime = 0;
            m_dwGroupRcallTick = HUtil32.GetTickCount();
            m_boRecallSuite = false;
            m_boRaceImg = false;
            bo2BA = false;
            m_boAbilSeeHealGauge = false;
            m_boPowerHit = false;
            m_boUseThrusting = false;
            m_boUseHalfMoon = false;
            m_boRedUseHalfMoon = false;
            m_boFireHitSkill = false;
            m_boTwinHitSkill = false;
            m_btHitPoint = 5;
            m_btSpeedPoint = 15;
            m_nHitSpeed = 0;
            m_btLifeAttrib = 0;
            m_btAntiPoison = 0;
            m_nPoisonRecover = 0;
            m_nHealthRecover = 0;
            m_nSpellRecover = 0;
            m_nAntiMagic = 0;
            m_nLuck = 0;
            m_nIncSpell = 0;
            m_nIncHealth = 0;
            m_nIncHealing = 0;
            m_nIncHPStoneTime = HUtil32.GetTickCount();
            m_nIncMPStoneTime = HUtil32.GetTickCount();
            m_nPerHealth = 5;
            m_nPerHealing = 5;
            m_nPerSpell = 5;
            m_dwIncHealthSpellTick = HUtil32.GetTickCount();
            m_btGreenPoisoningPoint = 0;
            m_nFightZoneDieCount = 0;
            m_nGoldMax = M2Share.g_Config.nHumanMaxGold;
            m_nCharStatus = 0;
            m_nCharStatusEx = 0;
            m_wStatusTimeArr = new ushort[12];// FillChar(m_wStatusTimeArr, sizeof(grobal2.short), '\0');
            m_BonusAbil = new TNakedAbility();// FillChar(m_BonusAbil, sizeof(TNakedAbility), '\0');
            m_CurBonusAbil = new TNakedAbility();// FillChar(m_CurBonusAbil, sizeof(TNakedAbility), '\0');
            m_wStatusArrValue = new ushort[6];// FillChar(m_wStatusArrValue, sizeof(m_wStatusArrValue), 0);
            m_dwStatusArrTimeOutTick = new int[6];// FillChar(m_dwStatusArrTimeOutTick, sizeof(m_dwStatusArrTimeOutTick), '\0');
            m_boAllowGroup = false;
            m_boAllowGuild = false;
            btB2 = 0;
            m_btAttatckMode = 0;
            m_boInFreePKArea = false;
            m_boGuildWarArea = false;
            bo2B0 = false;
            m_boSuperMan = false;
            m_boSkeleton = false;
            bo2BF = false;
            m_boHolySeize = false;
            m_boCrazyMode = false;
            m_boShowHP = false;
            bo2F0 = false;
            m_boAnimal = false;
            m_boNoItem = false;
            m_nBodyLeathery = 50;
            m_boFixedHideMode = false;
            m_boStickMode = false;
            m_boNoAttackMode = false;
            m_boNoTame = false;
            m_boPKFlag = false;
            m_nMoXieSuite = 0;
            m_nHongMoSuite = 0;
            m_db3B0 = 0;
            m_AddAbil = new TAddAbility();//FillChar(m_AddAbil, sizeof(TAddAbility), '\0');
            m_MsgList = new List<SendMessage>();
            m_VisibleHumanList = new List<TBaseObject>();
            m_VisibleActors = new List<TVisibleBaseObject>();
            m_VisibleItems = new List<TVisibleMapItem>();
            m_VisibleEvents = new List<TEvent>();
            m_ItemList = new List<TUserItem>();
            m_DealItemList = new List<TUserItem>();
            m_boIsVisibleActive = false;
            m_nProcessRunCount = 0;
            m_nDealGolds = 0;
            m_MagicList = new List<TUserMagic>();
            m_StorageItemList = new List<TUserItem>();
            //FillChar(m_UseItems, sizeof(grobal2.TUserItem), 0);
            m_UseItems = new TUserItem[13];
            m_MagicOneSwordSkill = null;
            m_MagicPowerHitSkill = null;
            m_MagicErgumSkill = null;
            m_MagicBanwolSkill = null;
            m_MagicRedBanwolSkill = null;
            m_MagicFireSwordSkill = null;
            m_MagicCrsSkill = null;
            m_Magic41Skill = null;
            m_MagicTwnHitSkill = null;
            m_Magic43Skill = null;
            m_GroupOwner = null;
            m_Castle = null;
            m_Master = null;
            m_nKillMonCount = 0;
            m_btSlaveExpLevel = 0;
            bt2A0 = 0;
            m_GroupMembers = new List<TPlayObject>();
            m_boHearWhisper = true;
            m_boBanShout = true;
            m_boBanGuildChat = true;
            m_boAllowDeal = true;
            m_boAllowGroupReCall = false;
            m_BlockWhisperList = new List<string>();
            m_SlaveList = new  List<TBaseObject>();
            m_WAbil = new TAbility();// FillChar(m_WAbil, sizeof(TAbility), '\0');
            m_QuestUnitOpen = new byte[128];//FillChar(m_QuestUnitOpen, sizeof(grobal2.byte), '\0');
            m_QuestUnit = new byte[128];// FillChar(m_QuestUnit, sizeof(grobal2.byte), '\0');
            m_QuestFlag = new byte[128];
            m_Abil = new TAbility
            {
                Level = 1,
                AC = 0,
                MAC = 0,
                DC = HUtil32.MakeLong(1, 4),
                MC = HUtil32.MakeLong(1, 2),
                SC = HUtil32.MakeLong(1, 2),
                HP = 15,
                MP = 15,
                MaxHP = 15,
                MaxMP = 15,
                Exp = 0,
                MaxExp = 50,
                Weight = 0,
                MaxWeight = 100
            };
            m_boWantRefMsg = false;
            m_boDealing = false;
            m_DealCreat = null;
            m_MyGuild = null;
            m_nGuildRankNo = 0;
            m_sGuildRankName = "";
            m_sScriptLable = "";
            m_boMission = false;
            m_boHideMode = false;
            m_boStoneMode = false;
            m_boCoolEye = false;
            m_boUserUnLockDurg = false;
            m_boTransparent = false;
            m_boAdminMode = false;
            m_boObMode = false;
            m_dwRunTick = HUtil32.GetTickCount() + M2Share.RandomNumber.Random(1500);
            m_nRunTime = 250;
            m_dwSearchTime = M2Share.RandomNumber.Random(2000) + 2000;
            m_dwSearchTick = HUtil32.GetTickCount();
            m_dwDecPkPointTick = HUtil32.GetTickCount();
            m_DecLightItemDrugTick = HUtil32.GetTickCount();
            m_dwPoisoningTick = HUtil32.GetTickCount();
            m_dwVerifyTick = HUtil32.GetTickCount();
            m_dwCheckRoyaltyTick = HUtil32.GetTickCount();
            m_dwDecHungerPointTick = HUtil32.GetTickCount();
            m_dwHPMPTick = HUtil32.GetTickCount();
            m_dwShoutMsgTick = 0;
            m_dwTeleportTick = 0;
            m_dwProbeTick = 0;
            m_dwMapMoveTick = HUtil32.GetTickCount();
            m_dwMasterTick = 0;
            m_nWalkSpeed = 1400;
            m_nNextHitTime = 2000;
            m_nWalkCount = 0;
            m_dwWalkWaitTick = HUtil32.GetTickCount();
            m_boWalkWaitLocked = false;
            m_nHealthTick = 0;
            m_nSpellTick = 0;
            m_TargetCret = null;
            m_LastHiter = null;
            m_ExpHitter = null;
            m_SayMsgList = null;
            m_boDenyRefStatus = false;
            m_btHorseType = 0;
            m_btDressEffType = 0;
            m_dwPKDieLostExp = 0;
            m_nPKDieLostLevel = 0;
            m_boAddToMaped = true;
            m_boAutoChangeColor = false;
            m_dwAutoChangeColorTick = HUtil32.GetTickCount();
            m_nAutoChangeIdx = 0;
            m_boFixColor = false;
            m_nFixColorIdx = 0;
            m_nFixStatus = -1;
            m_boFastParalysis = false;
            m_boNastyMode = false;
            M2Share.ObjectSystem.Add(ObjectId, this);
        }

        public void ChangePKStatus(bool boWarFlag)
        {
            if (m_boInFreePKArea != boWarFlag)
            {
                m_boInFreePKArea = boWarFlag;
                m_boNameColorChanged = true;
            }
        }

        public bool GetDropPosition(int nOrgX, int nOrgY, int nRange, ref int nDX, ref int nDY)
        {
            var result = false;
            var nItemCount = 0;
            var n24 = 999;
            var n28 = 0;
            var n2C = 0;
            for (var i = 1; i <= nRange; i++)
            {
                for (var ii = -i; ii <= i; ii++)
                {
                    for (var iii = -i; iii <= i; iii++)
                    {
                        nDX = nOrgX + iii;
                        nDY = nOrgY + ii;
                        if (m_PEnvir.GetItemEx(nDX, nDY, ref nItemCount) == null)
                        {
                            if (m_PEnvir.bo2C)
                            {
                                result = true;
                                break;
                            }
                        }
                        else
                        {
                            if (m_PEnvir.bo2C && n24 > nItemCount)
                            {
                                n24 = nItemCount;
                                n28 = nDX;
                                n2C = nDY;
                            }
                        }
                    }
                    if (result)
                    {
                        break;
                    }
                }
                if (result)
                {
                    break;
                }
            }
            if (!result)
            {
                if (n24 < 8)
                {
                    nDX = n28;
                    nDY = n2C;
                }
                else
                {
                    nDX = nOrgX;
                    nDY = nOrgY;
                }
            }
            return result;
        }

        public bool DropItemDown(TUserItem UserItem, int nScatterRange, bool boDieDrop, TBaseObject ItemOfCreat, TBaseObject DropCreat)
        {
            bool result = false;
            int dx = 0;
            int dy = 0;
            int idura;
            TMapItem MapItem;
            TMapItem pr;
            string logcap;
            MirItem StdItem = M2Share.UserEngine.GetStdItem(UserItem.wIndex);
            if (StdItem != null)
            {
                if (StdItem.StdMode == 40)
                {
                    idura = UserItem.Dura;
                    idura = idura - 2000;
                    if (idura < 0)
                    {
                        idura = 0;
                    }
                    UserItem.Dura = (ushort)idura;
                }
                MapItem = new TMapItem
                {
                    UserItem = UserItem,
                    Name = ItmUnit.GetItemName(UserItem),// 取自定义物品名称
                    Looks = StdItem.Looks
                };
                if (StdItem.StdMode == 45)
                {
                    MapItem.Looks = (ushort)M2Share.GetRandomLook(MapItem.Looks, StdItem.Shape);
                }
                MapItem.AniCount = StdItem.AniCount;
                MapItem.Reserved = 0;
                MapItem.Count = 1;
                MapItem.OfBaseObject = ItemOfCreat;
                MapItem.dwCanPickUpTick = HUtil32.GetTickCount();
                MapItem.DropBaseObject = DropCreat;
                GetDropPosition(m_nCurrX, m_nCurrY, nScatterRange, ref dx, ref dy);
                pr = (TMapItem)m_PEnvir.AddToMap(dx, dy, Grobal2.OS_ITEMOBJECT, MapItem);
                if (pr == MapItem)
                {
                    SendRefMsg(Grobal2.RM_ITEMSHOW, MapItem.Looks, MapItem.Id, dx, dy, MapItem.Name);
                    if (boDieDrop)
                    {
                        logcap = "15";
                    }
                    else
                    {
                        logcap = "7";
                    }
                    if (!M2Share.IsCheapStuff(StdItem.StdMode))
                    {
                        if (StdItem.NeedIdentify == 1)
                        {
                            M2Share.AddGameDataLog(logcap + "\t" + m_sMapName + "\t" + m_nCurrX.ToString() + "\t" + m_nCurrY.ToString() + "\t" + m_sCharName + "\t" + StdItem.Name + "\t" + UserItem.MakeIndex.ToString() + "\t" + HUtil32.BoolToIntStr(m_btRaceServer == Grobal2.RC_PLAYOBJECT) + "\t" + '0');
                        }
                    }
                    result = true;
                }
                else
                {
                    MapItem = null;
                }
            }
            return result;
        }

        public void GoldChanged()
        {
            if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
            {
                SendUpdateMsg(this, Grobal2.RM_GOLDCHANGED, 0, 0, 0, 0, "");
            }
        }

        public void GameGoldChanged()
        {
            if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
            {
                SendUpdateMsg(this, Grobal2.RM_GAMEGOLDCHANGED, 0, 0, 0, 0, "");
            }
        }

        public void RecalcLevelAbilitys()
        {
            int n;
            double nLevel = m_Abil.Level;
            switch (m_btJob)
            {
                case M2Share.jTaos:
                    m_Abil.MaxHP = (ushort)HUtil32._MIN(short.MaxValue, 14 + HUtil32.Round((nLevel / M2Share.g_Config.nLevelValueOfTaosHP + M2Share.g_Config.nLevelValueOfTaosHPRate) * nLevel));
                    m_Abil.MaxMP = (ushort)HUtil32._MIN(short.MaxValue, 13 + HUtil32.Round(nLevel / M2Share.g_Config.nLevelValueOfTaosMP * 2.2 * nLevel));
                    m_Abil.MaxWeight = (ushort)(50 + HUtil32.Round(nLevel / 4 * nLevel));
                    m_Abil.MaxWearWeight = (ushort)(15 + HUtil32.Round(nLevel / 50 * nLevel));
                    m_Abil.MaxHandWeight = (ushort)(12 + HUtil32.Round(nLevel / 42 * nLevel));
                    n = (int)(nLevel / 7);
                    m_Abil.DC = HUtil32.MakeLong(HUtil32._MAX(n - 1, 0), HUtil32._MAX(1, n));
                    m_Abil.MC = 0;
                    m_Abil.SC = HUtil32.MakeLong(HUtil32._MAX(n - 1, 0), HUtil32._MAX(1, n));
                    m_Abil.AC = 0;
                    n = HUtil32.Round(nLevel / 6);
                    m_Abil.MAC = HUtil32.MakeLong(n / 2, n + 1);
                    break;
                case M2Share.jWizard:
                    m_Abil.MaxHP = (ushort)HUtil32._MIN(short.MaxValue, 14 + HUtil32.Round((nLevel / M2Share.g_Config.nLevelValueOfWizardHP + M2Share.g_Config.nLevelValueOfWizardHPRate) * nLevel));
                    m_Abil.MaxMP = (ushort)HUtil32._MIN(short.MaxValue, 13 + HUtil32.Round((nLevel / 5 + 2) * 2.2 * nLevel));
                    m_Abil.MaxWeight = (ushort)(50 + HUtil32.Round(nLevel / 5 * nLevel));
                    m_Abil.MaxWearWeight = (ushort)HUtil32._MIN(short.MaxValue, 15 + HUtil32.Round(nLevel / 100 * nLevel));
                    m_Abil.MaxHandWeight = (ushort)(12 + HUtil32.Round(nLevel / 90 * nLevel));
                    n = (int)(nLevel / 7);
                    m_Abil.DC = HUtil32.MakeLong(HUtil32._MAX(n - 1, 0), HUtil32._MAX(1, n));
                    m_Abil.MC = HUtil32.MakeLong(HUtil32._MAX(n - 1, 0), HUtil32._MAX(1, n));
                    m_Abil.SC = 0;
                    m_Abil.AC = 0;
                    m_Abil.MAC = 0;
                    break;
                case M2Share.jWarr:
                    m_Abil.MaxHP = (ushort)HUtil32._MIN(short.MaxValue, 14 + HUtil32.Round((nLevel / M2Share.g_Config.nLevelValueOfWarrHP + M2Share.g_Config.nLevelValueOfWarrHPRate + nLevel / 20) * nLevel));
                    m_Abil.MaxMP = (ushort)HUtil32._MIN(short.MaxValue, 11 + HUtil32.Round(nLevel * 3.5));
                    m_Abil.MaxWeight = (ushort)(50 + HUtil32.Round(nLevel / 3 * nLevel));
                    m_Abil.MaxWearWeight = (ushort)(15 + HUtil32.Round(nLevel / 20 * nLevel));
                    m_Abil.MaxHandWeight = (ushort)(12 + HUtil32.Round(nLevel / 13 * nLevel));
                    m_Abil.DC = HUtil32.MakeLong(HUtil32._MAX((int)(nLevel / 5) - 1, 1), HUtil32._MAX(1, (int)(nLevel / 5)));
                    m_Abil.SC = 0;
                    m_Abil.MC = 0;
                    m_Abil.AC = HUtil32.MakeLong(0, nLevel / 7);
                    m_Abil.MAC = 0;
                    break;
            }
            if (m_Abil.HP > m_Abil.MaxHP)
            {
                m_Abil.HP = m_Abil.MaxHP;
            }
            if (m_Abil.MP > m_Abil.MaxMP)
            {
                m_Abil.MP = m_Abil.MaxMP;
            }
        }

        public void HasLevelUp(int nLevel)
        {
            m_Abil.MaxExp = GetLevelExp(m_Abil.Level);
            RecalcLevelAbilitys();
            RecalcAbilitys();
            SendMsg(this, Grobal2.RM_LEVELUP, 0, m_Abil.Exp, 0, 0, "");
#if FOR_ABIL_POINT
            // 4/16老 何磐 利侩
            if (prevlevel + 1 == Abil.Level)
            {
                BonusPoint = BonusPoint + GetBonusPoint(Job, Abil.Level);
                SendMsg(this, grobal2.RM_ADJUST_BONUS, 0, 0, 0, 0, "");
            }
            else
            {
                if (prevlevel != Abil.Level)
                {
                    // 焊呈胶 器牢飘甫 贸澜何磐 促矫 拌魂茄促.
                    BonusPoint = GetLevelBonusSum(Job, Abil.Level);
                    FillChar(BonusAbil, sizeof(TNakedAbility), '\0');
                    FillChar(CurBonusAbil, sizeof(TNakedAbility), '\0');
                    RecalcLevelAbilitys();
                    SendMsg(this, grobal2.RM_ADJUST_BONUS, 0, 0, 0, 0, "");
                }
            }
#endif
            if (M2Share.g_FunctionNPC != null)
            {
                M2Share.g_FunctionNPC.GotoLable(this as TPlayObject, "@LevelUp", false);
            }
        }

        public bool WalkTo(byte btDir, bool boFlag)
        {
            short nOX = 0;
            short nOY = 0;
            short nNX = 0;
            short nNY = 0;
            short n20 = 0;
            short n24 = 0;
            bool bo29;
            const string sExceptionMsg = "[Exception] TBaseObject::WalkTo";
            bool result = false;
            if (m_boHolySeize)
            {
                return result;
            }
            try
            {
                nOX = m_nCurrX;
                nOY = m_nCurrY;
                m_btDirection = btDir;
                nNX = 0;
                nNY = 0;
                switch (btDir)
                {
                    case Grobal2.DR_UP:
                        nNX = m_nCurrX;
                        nNY = (short)(m_nCurrY - 1);
                        break;
                    case Grobal2.DR_UPRIGHT:
                        nNX = (short)(m_nCurrX + 1);
                        nNY = (short)(m_nCurrY - 1);
                        break;
                    case Grobal2.DR_RIGHT:
                        nNX = (short)(m_nCurrX + 1);
                        nNY = m_nCurrY;
                        break;
                    case Grobal2.DR_DOWNRIGHT:
                        nNX = (short)(m_nCurrX + 1);
                        nNY = (short)(m_nCurrY + 1);
                        break;
                    case Grobal2.DR_DOWN:
                        nNX = m_nCurrX;
                        nNY = (short)(m_nCurrY + 1);
                        break;
                    case Grobal2.DR_DOWNLEFT:
                        nNX = (short)(m_nCurrX - 1);
                        nNY = (short)(m_nCurrY + 1);
                        break;
                    case Grobal2.DR_LEFT:
                        nNX = (short)(m_nCurrX - 1);
                        nNY = m_nCurrY;
                        break;
                    case Grobal2.DR_UPLEFT:
                        nNX = (short)(m_nCurrX - 1);
                        nNY = (short)(m_nCurrY - 1);
                        break;
                }
                if (nNX >= 0 && m_PEnvir.wWidth - 1 >= nNX && nNY >= 0 && m_PEnvir.wHeight - 1 >= nNY)
                {
                    bo29 = true;
                    if (bo2BA && !m_PEnvir.CanSafeWalk(nNX, nNY))
                    {
                        bo29 = false;
                    }
                    if (m_Master != null)
                    {
                        m_Master.m_PEnvir.GetNextPosition(m_Master.m_nCurrX, m_Master.m_nCurrY, m_Master.m_btDirection, 1, ref n20, ref n24);
                        if (nNX == n20 && nNY == n24)
                        {
                            bo29 = false;
                        }
                    }
                    if (bo29)
                    {
                        if (m_PEnvir.MoveToMovingObject(m_nCurrX, m_nCurrY, this, nNX, nNY, boFlag) > 0)
                        {
                            m_nCurrX = nNX;
                            m_nCurrY = nNY;
                        }
                    }
                }
                if (m_nCurrX != nOX || m_nCurrY != nOY)
                {
                    if (Walk(Grobal2.RM_WALK))
                    {
                        if (m_boTransparent && m_boHideMode)
                        {
                            m_wStatusTimeArr[Grobal2.STATE_TRANSPARENT] = 1;
                        }
                        result = true;
                    }
                    else
                    {
                        m_PEnvir.DeleteFromMap(m_nCurrX, m_nCurrY, Grobal2.OS_MOVINGOBJECT, this);
                        m_nCurrX = nOX;
                        m_nCurrY = nOY;
                        m_PEnvir.AddToMap(m_nCurrX, m_nCurrY, Grobal2.OS_MOVINGOBJECT, this);
                    }
                }
            }
            catch
            {
                M2Share.ErrorMessage(sExceptionMsg);
            }
            return result;
        }

        public bool IsGroupMember(TBaseObject target)
        {
            bool result = false;
            if (m_GroupOwner == null)
            {
                return result;
            }
            for (int i = 0; i < m_GroupOwner.m_GroupMembers.Count; i++)
            {
                if (m_GroupOwner.m_GroupMembers[i] == target)
                {
                    result = true;
                    break;
                }
            }
            return result;
        }

        public int PKLevel()
        {
            return m_nPkPoint / 100;
        }

        public void HealthSpellChanged()
        {
            if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
            {
                SendUpdateMsg(this, Grobal2.RM_HEALTHSPELLCHANGED, 0, 0, 0, 0, "");
            }
            if (m_boShowHP)
            {
                SendRefMsg(Grobal2.RM_HEALTHSPELLCHANGED, 0, 0, 0, 0, "");
            }
        }

        public int CalcGetExp(int nLevel, int nExp)
        {
            int result;
            if (M2Share.g_Config.boHighLevelKillMonFixExp || (m_Abil.Level < (nLevel + 10)))
            {
                result = nExp;
            }
            else
            {
                result = nExp - HUtil32.Round(nExp / 15 * (m_Abil.Level - (nLevel + 10)));
            }
            if (result <= 0)
            {
                result = 1;
            }
            return result;
        }

        public void RefNameColor()
        {
            SendRefMsg(Grobal2.RM_CHANGENAMECOLOR, 0, 0, 0, 0, "");
        }

        public int GainSlaveExp_GetUpKillCount()
        {
            int tCount;
            if (m_btSlaveExpLevel < Grobal2.SLAVEMAXLEVEL - 2)
            {
                tCount = M2Share.g_Config.MonUpLvNeedKillCount[m_btSlaveExpLevel];
            }
            else
            {
                tCount = 0;
            }
            return (m_Abil.Level * M2Share.g_Config.nMonUpLvRate) - m_Abil.Level + M2Share.g_Config.nMonUpLvNeedKillBase + tCount;
        }

        public void GainSlaveExp(int nLevel)
        {
            m_nKillMonCount += nLevel;
            if (GainSlaveExp_GetUpKillCount() < m_nKillMonCount)
            {
                m_nKillMonCount -= GainSlaveExp_GetUpKillCount();
                if (m_btSlaveExpLevel < (m_btSlaveMakeLevel * 2 + 1))
                {
                    m_btSlaveExpLevel++;
                    RecalcAbilitys();
                    RefNameColor();
                }
            }
        }

        public bool DropGoldDown(int nGold, bool boFalg, TBaseObject GoldOfCreat, TBaseObject DropGoldCreat)
        {
            bool result = false;
            int nX = 0;
            int nY = 0;
            string s20;
            int DropWide = HUtil32._MIN(M2Share.g_Config.nDropItemRage, 7);
            TMapItem MapItem = new TMapItem
            {
                Name = Grobal2.sSTRING_GOLDNAME,
                Count = nGold,
                Looks = M2Share.GetGoldShape(nGold),
                OfBaseObject = GoldOfCreat,
                dwCanPickUpTick = HUtil32.GetTickCount(),
                DropBaseObject = DropGoldCreat
            };
            GetDropPosition(m_nCurrX, m_nCurrY, 3, ref nX, ref nY);
            TMapItem MapItemA = (TMapItem) m_PEnvir.AddToMap(nX, nY, Grobal2.OS_ITEMOBJECT, MapItem);
            if (MapItemA != null)
            {
                if (MapItemA != MapItem)
                {
                    MapItem = null;
                    MapItem = MapItemA;
                }

                SendRefMsg(Grobal2.RM_ITEMSHOW, MapItem.Looks, MapItem.Id, nX, nY, MapItem.Name);
                if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                {
                    if (boFalg)
                    {
                        s20 = "15";
                    }
                    else
                    {
                        s20 = "7";
                    }
                    if (M2Share.g_boGameLogGold)
                    {
                        M2Share.AddGameDataLog(s20 + "\t" + m_sMapName + "\t" + m_nCurrX.ToString() + "\t" +
                                               m_nCurrY.ToString() + "\t" + m_sCharName + "\t" +
                                               Grobal2.sSTRING_GOLDNAME + "\t" + nGold.ToString() + "\t" +
                                               HUtil32.BoolToIntStr(m_btRaceServer == Grobal2.RC_PLAYOBJECT) + "\t" +
                                               '0');
                    }
                }
                result = true;
            }
            else
            {
                MapItem = null;
            }
            return result;
        }

        public int GetGuildRelation(TBaseObject cert1, TBaseObject cert2)
        {
            int result = 0;
            m_boGuildWarArea = false;
            if ((cert1.m_MyGuild == null) || (cert2.m_MyGuild == null))
            {
                return result;
            }
            if (cert1.InSafeArea() || cert2.InSafeArea())
            {
                return result;
            }
            if (cert1.m_MyGuild.GuildWarList.Count <= 0)
            {
                return result;
            }
            m_boGuildWarArea = true;
            if (cert1.m_MyGuild.IsWarGuild(cert2.m_MyGuild) && cert2.m_MyGuild.IsWarGuild(cert1.m_MyGuild))
            {
                result = 2;
            }
            if (cert1.m_MyGuild == cert2.m_MyGuild)
            {
                result = 1;
            }
            if (cert1.m_MyGuild.IsAllyGuild(cert2.m_MyGuild) && cert2.m_MyGuild.IsAllyGuild(cert1.m_MyGuild))
            {
                result = 3;
            }
            return result;
        }

        public void IncPkPoint(int nPoint)
        {
            int nOldPKLevel;
            nOldPKLevel = PKLevel();
            m_nPkPoint += nPoint;
            if (PKLevel() != nOldPKLevel)
            {
                if (PKLevel() <= 2)
                {
                    RefNameColor();
                }
            }
        }

        public void AddBodyLuck(double dLuck)
        {
            if ((dLuck > 0) && (m_dBodyLuck < 5 * M2Share.BODYLUCKUNIT))
            {
                m_dBodyLuck = m_dBodyLuck + dLuck;
            }
            if ((dLuck < 0) && (m_dBodyLuck > -(5 * M2Share.BODYLUCKUNIT)))
            {
                m_dBodyLuck = m_dBodyLuck + dLuck;
            }
            int n = Convert.ToInt32(m_dBodyLuck / M2Share.BODYLUCKUNIT);
            if (n > 5)
            {
                n = 5;
            }
            if (n < -10)
            {
                n = -10;
            }
            m_nBodyLuckLevel = n;
        }

        public void MakeWeaponUnlock()
        {
            if (m_UseItems[Grobal2.U_WEAPON] == null)
            {
                return;
            }
            if (m_UseItems[Grobal2.U_WEAPON].wIndex <= 0)
            {
                return;
            }
            if (m_UseItems[Grobal2.U_WEAPON].btValue[3] > 0)
            {
                m_UseItems[Grobal2.U_WEAPON].btValue[3] -= 1;
                SysMsg(M2Share.g_sTheWeaponIsCursed, TMsgColor.c_Red, TMsgType.t_Hint);
            }
            else
            {
                if (m_UseItems[Grobal2.U_WEAPON].btValue[4] < 10)
                {
                    m_UseItems[Grobal2.U_WEAPON].btValue[4]++;
                    SysMsg(M2Share.g_sTheWeaponIsCursed, TMsgColor.c_Red, TMsgType.t_Hint);
                }
            }
            if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
            {
                RecalcAbilitys();
                SendMsg(this, Grobal2.RM_ABILITY, 0, 0, 0, 0, "");
                SendMsg(this, Grobal2.RM_SUBABILITY, 0, 0, 0, 0, "");
            }
        }

        public ushort GetAttackPower(int nBasePower, int nPower)
        {
            int result;
            TPlayObject PlayObject;
            if (nPower < 0)
            {
                nPower = 0;
            }
            if (m_nLuck > 0)
            {
                if (M2Share.RandomNumber.Random(10 - HUtil32._MIN(9, m_nLuck)) == 0)
                {
                    result = nBasePower + nPower;
                }
                else
                {
                    result = nBasePower + M2Share.RandomNumber.Random(nPower + 1);
                }
            }
            else
            {
                result = nBasePower + M2Share.RandomNumber.Random(nPower + 1);
                if (m_nLuck < 0)
                {
                    if (M2Share.RandomNumber.Random(10 - HUtil32._MAX(0, -m_nLuck)) == 0)
                    {
                        result = nBasePower;
                    }
                }
            }
            if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
            {
                PlayObject = this as TPlayObject;
                // Result:=Result * PlayObject.m_nPowerMult + ROUND(Result * (PlayObject.m_nPowerMultPoint / 100));
                result = HUtil32.Round(result * (PlayObject.m_nPowerRate / 100));
                if (PlayObject.m_boPowerItem)
                {
                    result = HUtil32.Round(m_rPowerItem * result);
                }
            }
            if (m_boAutoChangeColor)
            {
                result = result * m_nAutoChangeIdx + 1;
            }
            if (m_boFixColor)
            {
                result = result * m_nFixColorIdx + 1;
            }
            return (ushort)result;
        }

        /// <summary>
        /// 减少生命值
        /// </summary>
        /// <param name="nDamage"></param>
        public void DamageHealth(int nDamage)
        {
            int nSpdam;
            if (((m_LastHiter == null) || !m_LastHiter.m_boUnMagicShield) && m_boMagicShield && (nDamage > 0) && (m_WAbil.MP > 0))
            {
                nSpdam = HUtil32.Round(nDamage * 1.5);
                if (m_WAbil.MP >= nSpdam)
                {
                    m_WAbil.MP = (ushort)(m_WAbil.MP - nSpdam);
                    nSpdam = 0;
                }
                else
                {
                    nSpdam = nSpdam - m_WAbil.MP;
                    m_WAbil.MP = 0;
                }
                nDamage = HUtil32.Round(nSpdam / 1.5);
                HealthSpellChanged();
            }
            if (nDamage > 0)
            {
                if ((m_WAbil.HP - nDamage) > 0)
                {
                    m_WAbil.HP = (ushort)(m_WAbil.HP - nDamage);
                }
                else
                {
                    m_WAbil.HP = 0;
                }
            }
            else
            {
                if ((m_WAbil.HP - nDamage) < m_WAbil.MaxHP)
                {
                    m_WAbil.HP = (ushort)(m_WAbil.HP - nDamage);
                }
                else
                {
                    m_WAbil.HP = m_WAbil.MaxHP;
                }
            }
        }

        public byte GetBackDir(int nDir)
        {
            byte result = 0;
            switch (nDir)
            {
                case Grobal2.DR_UP:
                    result = Grobal2.DR_DOWN;
                    break;
                case Grobal2.DR_DOWN:
                    result = Grobal2.DR_UP;
                    break;
                case Grobal2.DR_LEFT:
                    result = Grobal2.DR_RIGHT;
                    break;
                case Grobal2.DR_RIGHT:
                    result = Grobal2.DR_LEFT;
                    break;
                case Grobal2.DR_UPLEFT:
                    result = Grobal2.DR_DOWNRIGHT;
                    break;
                case Grobal2.DR_UPRIGHT:
                    result = Grobal2.DR_DOWNLEFT;
                    break;
                case Grobal2.DR_DOWNLEFT:
                    result = Grobal2.DR_UPRIGHT;
                    break;
                case Grobal2.DR_DOWNRIGHT:
                    result = Grobal2.DR_UPLEFT;
                    break;
            }
            return result;
        }

        public int CharPushed(byte nDir, int nPushCount)
        {
            short nx = 0;
            short ny = 0;
            int result = 0;
            byte olddir = m_btDirection;
            int oldx = m_nCurrX;
            int oldy = m_nCurrY;
            m_btDirection = nDir;
            byte nBackDir = GetBackDir(nDir);
            for (var i = 0; i < nPushCount; i++)
            {
                GetFrontPosition(ref nx, ref ny);
                if (m_PEnvir.CanWalk(nx, ny, false))
                {
                    if (m_PEnvir.MoveToMovingObject(m_nCurrX, m_nCurrY, this, nx, ny, false) > 0)
                    {
                        m_nCurrX = nx;
                        m_nCurrY = ny;
                        // SendRefMsg(RM_PUSH, GetBackDir(ndir), m_nCurrX, m_nCurrY, 0, '');
                        SendRefMsg(Grobal2.RM_PUSH, nBackDir, m_nCurrX, m_nCurrY, 0, "");
                        result++;
                        if (m_btRaceServer >= Grobal2.RC_ANIMAL)
                        {
                            m_dwWalkTick = m_dwWalkTick + 800;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    break;
                }
            }
            m_btDirection = nBackDir;
            if (result == 0)
            {
                m_btDirection = olddir;
            }
            return result;
        }

        public int MagPassThroughMagic(short sx, short sy, short tx, short ty, int ndir, int magpwr, bool undeadattack)
        {
            TBaseObject BaseObject;
            int tcount = 0;
            for (int i = 0; i <= 12; i++)
            {
                BaseObject = m_PEnvir.GetMovingObject(sx, sy, true) as TBaseObject;
                if (BaseObject != null)
                {
                    if (IsProperTarget(BaseObject))
                    {
                        if (M2Share.RandomNumber.Random(10) >= BaseObject.m_nAntiMagic)
                        {
                            if (undeadattack)
                            {
                                magpwr = HUtil32.Round(magpwr * 1.5);
                            }
                            BaseObject.SendDelayMsg(this, Grobal2.RM_MAGSTRUCK, 0, magpwr, 0, 0, "", 600);
                            tcount++;
                        }
                    }
                }
                if (!((Math.Abs(sx - tx) <= 0) && (Math.Abs(sy - ty) <= 0)))
                {
                    ndir = M2Share.GetNextDirection(sx, sy, tx, ty);
                    if (!m_PEnvir.GetNextPosition(sx, sy, ndir, 1, ref sx, ref sy))
                    {
                        break;
                    }
                }
                else
                {
                    break;
                }
            }
            int result = tcount;
            return result;
        }

        public void BreakOpenHealth()
        {
            if (m_boShowHP)
            {
                m_boShowHP = false;
                m_nCharStatusEx = m_nCharStatusEx ^ Grobal2.STATE_OPENHEATH;
                m_nCharStatus = GetCharStatus();
                SendRefMsg(Grobal2.RM_CLOSEHEALTH, 0, 0, 0, 0, "");
            }
        }

        public void MakeOpenHealth()
        {
            m_boShowHP = true;
            m_nCharStatusEx = m_nCharStatusEx | Grobal2.STATE_OPENHEATH;
            m_nCharStatus = GetCharStatus();
            SendRefMsg(Grobal2.RM_OPENHEALTH, 0, m_WAbil.HP, m_WAbil.MaxHP, 0, "");
        }

        public void IncHealthSpell(int nHP, int nMP)
        {
            if ((nHP < 0) || (nMP < 0))
            {
                return;
            }
            if ((m_WAbil.HP + nHP) >= m_WAbil.MaxHP)
            {
                m_WAbil.HP = m_WAbil.MaxHP;
            }
            else
            {
                m_WAbil.HP += (ushort)nHP;
            }
            if ((m_WAbil.MP + nMP) >= m_WAbil.MaxMP)
            {
                m_WAbil.MP = m_WAbil.MaxMP;
            }
            else
            {
                m_WAbil.MP += (ushort)nMP;
            }
            HealthSpellChanged();
        }

        public void ItemDamageRevivalRing()
        {
            MirItem pSItem;
            ushort nDura;
            ushort tDura;
            TPlayObject PlayObject;
            for (int i = m_UseItems.GetLowerBound(0); i <= m_UseItems.GetUpperBound(0); i++)
            {
                if (m_UseItems[i] != null && m_UseItems[i].wIndex > 0)
                {
                    pSItem = M2Share.UserEngine.GetStdItem(m_UseItems[i].wIndex);
                    if (pSItem != null)
                    {
                        if (new ArrayList(new int[] { 114, 160, 161, 162 }).Contains(pSItem.Shape) || (((i == Grobal2.U_WEAPON) || (i == Grobal2.U_RIGHTHAND)) && new ArrayList(new int[] { 114, 160, 161, 162 }).Contains(pSItem.AniCount)))
                        {
                            nDura = m_UseItems[i].Dura;
                            tDura = (ushort)HUtil32.Round(nDura / 1000.0);// 1.03
                            nDura -= 1000;
                            if (nDura <= 0)
                            {
                                nDura = 0;
                                m_UseItems[i].Dura = nDura;
                                if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                                {
                                    PlayObject = this as TPlayObject;
                                    PlayObject.SendDelItems(m_UseItems[i]);
                                }
                                m_UseItems[i].wIndex = 0;
                                RecalcAbilitys();
                            }
                            else
                            {
                                m_UseItems[i].Dura = nDura;
                            }
                            if (tDura != HUtil32.Round(nDura / 1000.0)) // 1.03
                            {
                                SendMsg(this, Grobal2.RM_DURACHANGE, i, nDura, m_UseItems[i].DuraMax, 0, "");
                            }
                        }
                    }
                }
            }
        }

        public bool GetFrontPosition(ref short nX, ref short nY)
        {
            bool result;
            TEnvirnoment Envir = m_PEnvir;
            nX = m_nCurrX;
            nY = m_nCurrY;
            switch (m_btDirection)
            {
                case Grobal2.DR_UP:
                    if (nY > 0)
                    {
                        nY -= 1;
                    }
                    break;
                case Grobal2.DR_UPRIGHT:
                    if ((nX < (Envir.wWidth - 1)) && (nY > 0))
                    {
                        nX++;
                        nY -= 1;
                    }
                    break;
                case Grobal2.DR_RIGHT:
                    if (nX < (Envir.wWidth - 1))
                    {
                        nX++;
                    }
                    break;
                case Grobal2.DR_DOWNRIGHT:
                    if ((nX < (Envir.wWidth - 1)) && (nY < (Envir.wHeight - 1)))
                    {
                        nX++;
                        nY++;
                    }
                    break;
                case Grobal2.DR_DOWN:
                    if (nY < (Envir.wHeight - 1))
                    {
                        nY++;
                    }
                    break;
                case Grobal2.DR_DOWNLEFT:
                    if ((nX > 0) && (nY < (Envir.wHeight - 1)))
                    {
                        nX -= 1;
                        nY++;
                    }
                    break;
                case Grobal2.DR_LEFT:
                    if (nX > 0)
                    {
                        nX -= 1;
                    }
                    break;
                case Grobal2.DR_UPLEFT:
                    if ((nX > 0) && (nY > 0))
                    {
                        nX -= 1;
                        nY -= 1;
                    }
                    break;
            }
            result = true;
            return result;
        }

        public bool SpaceMove_GetRandXY(TEnvirnoment Envir, ref short nX, ref short nY)
        {
            int n14;
            short n18;
            int n1C;
            bool result = false;
            if (Envir.wWidth < 80)
            {
                n18 = 3;
            }
            else
            {
                n18 = 10;
            }
            if (Envir.wHeight < 150)
            {
                if (Envir.wHeight < 50)
                {
                    n1C = 2;
                }
                else
                {
                    n1C = 15;
                }
            }
            else
            {
                n1C = 50;
            }
            n14 = 0;
            while (true)
            {
                if (Envir.CanWalk(nX, nY, true))
                {
                    result = true;
                    break;
                }
                if (nX < (Envir.wWidth - n1C - 1))
                {
                    nX += n18;
                }
                else
                {
                    nX = (short)M2Share.RandomNumber.Random(Envir.wWidth);
                    if (nY < (Envir.wHeight - n1C - 1))
                    {
                        nY += n18;
                    }
                    else
                    {
                        nY = (short)M2Share.RandomNumber.Random(Envir.wHeight);
                    }
                }
                n14++;
                if (n14 >= 201)
                {
                    break;
                }
            }
            return result;
        }

        public void SpaceMove(string sMap, short nX, short nY, int nInt)
        {
            int nOldX;
            int nOldY;
            bool bo21;
            TPlayObject PlayObject;
            TEnvirnoment Envir = M2Share.g_MapManager.FindMap(sMap);
            if (Envir != null)
            {
                if (M2Share.nServerIndex == Envir.nServerIndex)
                {
                    TEnvirnoment OldEnvir = m_PEnvir;
                    nOldX = m_nCurrX;
                    nOldY = m_nCurrY;
                    bo21 = false;
                    m_PEnvir.DeleteFromMap(m_nCurrX, m_nCurrY, Grobal2.OS_MOVINGOBJECT, this);
                    m_VisibleHumanList.Clear();
                    for (int i = 0; i < m_VisibleItems.Count; i++)
                    {
                        m_VisibleItems[i] = null;
                    }
                    m_VisibleItems.Clear();
                    for (int i = 0; i < m_VisibleActors.Count; i++)
                    {
                        m_VisibleActors[i] = null;
                    }
                    m_VisibleActors.Clear();
                    m_VisibleEvents.Clear();// 01/21 移动时清除列表
                    m_PEnvir = Envir;
                    m_sMapName = Envir.sMapName;
                    m_sMapFileName = Envir.m_sMapFileName;
                    m_nCurrX = nX;
                    m_nCurrY = nY;
                    if (SpaceMove_GetRandXY(m_PEnvir, ref m_nCurrX, ref m_nCurrY))
                    {
                        m_PEnvir.AddToMap(m_nCurrX, m_nCurrY, Grobal2.OS_MOVINGOBJECT, this);
                        SendMsg(this, Grobal2.RM_CLEAROBJECTS, 0, 0, 0, 0, "");
                        SendMsg(this, Grobal2.RM_CHANGEMAP, 0, 0, 0, 0, m_sMapFileName);
                        if (nInt == 1)
                        {
                            SendRefMsg(Grobal2.RM_SPACEMOVE_SHOW2, m_btDirection, m_nCurrX, m_nCurrY, 0, "");
                        }
                        else
                        {
                            SendRefMsg(Grobal2.RM_SPACEMOVE_SHOW, m_btDirection, m_nCurrX, m_nCurrY, 0, "");
                        }
                        m_dwMapMoveTick = HUtil32.GetTickCount();
                        m_bo316 = true;
                        bo21 = true;
                    }
                    if (!bo21)
                    {
                        m_PEnvir = OldEnvir;
                        m_nCurrX = (short)nOldX;
                        m_nCurrY = (short)nOldY;
                        m_PEnvir.AddToMap(m_nCurrX, m_nCurrY, Grobal2.OS_MOVINGOBJECT, this);
                    }
                }
                else
                {
                    if (SpaceMove_GetRandXY(Envir, ref nX, ref nY))
                    {
                        if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                        {
                            DisappearA();
                            m_bo316 = true;
                            PlayObject = this as TPlayObject;
                            PlayObject.m_sSwitchMapName = Envir.sMapName;
                            PlayObject.m_nSwitchMapX = nX;
                            PlayObject.m_nSwitchMapY = nY;
                            PlayObject.m_boSwitchData = true;
                            PlayObject.m_nServerIndex = Envir.nServerIndex;
                            PlayObject.m_boEmergencyClose = true;
                            PlayObject.m_boReconnection = true;
                        }
                        else
                        {
                            KickException();
                        }
                    }
                }
            }
        }

        public void RefShowName()
        {
            SendRefMsg(Grobal2.RM_USERNAME, 0, 0, 0, 0, GetShowName());
        }

        public TBaseObject MakeSlave(string sMonName, int nMakeLevel, int nExpLevel, int nMaxMob, int dwRoyaltySec)
        {
            short nX = 0;
            short nY = 0;
            TBaseObject MonObj;
            TBaseObject result = null;
            if (m_SlaveList.Count < nMaxMob)
            {
                GetFrontPosition(ref nX, ref nY);
                MonObj = M2Share.UserEngine.RegenMonsterByName(m_PEnvir.sMapName, nX, nY, sMonName);
                if (MonObj != null)
                {
                    MonObj.m_Master = this;
                    MonObj.m_dwMasterRoyaltyTick = HUtil32.GetTickCount() + dwRoyaltySec * 1000;
                    MonObj.m_btSlaveMakeLevel = (byte)nMakeLevel;
                    MonObj.m_btSlaveExpLevel = (byte)nExpLevel;
                    MonObj.RecalcAbilitys();
                    if (MonObj.m_WAbil.HP < MonObj.m_WAbil.MaxHP)
                    {
                        MonObj.m_WAbil.HP = (ushort)(MonObj.m_WAbil.HP + (MonObj.m_WAbil.MaxHP - MonObj.m_WAbil.HP) / 2);
                    }
                    MonObj.RefNameColor();
                    m_SlaveList.Add(MonObj);
                    result = MonObj;
                }
            }
            return result;
        }

        public void MapRandomMove(string sMapName, int nInt)
        {
            int nEgdey;
            TEnvirnoment Envir = M2Share.g_MapManager.FindMap(sMapName);
            if (Envir != null)
            {
                if (Envir.wHeight < 150)
                {
                    if (Envir.wHeight < 30)
                    {
                        nEgdey = 2;
                    }
                    else
                    {
                        nEgdey = 20;
                    }
                }
                else
                {
                    nEgdey = 50;
                }
                short nX = (short)(M2Share.RandomNumber.Random(Envir.wWidth - nEgdey - 1) + nEgdey);
                short nY = (short)(M2Share.RandomNumber.Random(Envir.wHeight - nEgdey - 1) + nEgdey);
                SpaceMove(sMapName, nX, nY, nInt);
            }
        }

        public bool AddItemToBag(TUserItem UserItem)
        {
            bool result = false;
            if (m_ItemList.Count < Grobal2.MAXBAGITEM)
            {
                m_ItemList.Add(UserItem);
                WeightChanged();
                result = true;
            }
            return result;
        }

        public void sub_4C713C(TUserMagic Magic)
        {
            if (Magic.MagicInfo.wMagicID == 28)
            {
                if (Magic.btLevel >= 2)
                {
                    m_boAbilSeeHealGauge = true;
                }
            }
        }

        public int GetQuestFalgStatus(int nFlag)
        {
            int result = 0;
            nFlag -= 1;
            if (nFlag < 0)
            {
                return result;
            }
            int n10 = nFlag / 8;
            int n14 = nFlag % 8;
            if ((n10 - m_QuestFlag.Length) < 0)
            {
                if (((128 >> n14) & m_QuestFlag[n10]) != 0)
                {
                    result = 1;
                }
                else
                {
                    result = 0;
                }
            }
            return result;
        }

        public void SetQuestFlagStatus(int nFlag, int nValue)
        {
            nFlag -= 1;
            if (nFlag < 0)
            {
                return;
            }
            int n10 = nFlag / 8;
            int n14 = nFlag % 8;
            if ((n10 - m_QuestFlag.Length) < 0)
            {
                byte bt15 = m_QuestFlag[n10];
                if (nValue == 0)
                {
                    m_QuestFlag[n10] = (byte)((~(128 >> n14)) & bt15);
                }
                else
                {
                    m_QuestFlag[n10] = (byte)((128 >> n14) | bt15);
                }
            }
        }

        public int GetQuestUnitOpenStatus(int nFlag)
        {
            int result;
            int n10;
            int n14;
            result = 0;
            nFlag -= 1;
            if (nFlag < 0)
            {
                return result;
            }
            n10 = nFlag / 8;
            n14 = nFlag % 8;
            if ((n10 - m_QuestUnitOpen.Length) < 0)
            {
                if (((128 >> n14) & m_QuestUnitOpen[n10]) != 0)
                {
                    result = 1;
                }
                else
                {
                    result = 0;
                }
            }
            return result;
        }

        public void SetQuestUnitOpenStatus(int nFlag, int nValue)
        {
            int n10;
            int n14;
            byte bt15;
            nFlag -= 1;
            if (nFlag < 0)
            {
                return;
            }
            n10 = nFlag / 8;
            n14 = nFlag % 8;
            if ((n10 - m_QuestUnitOpen.Length) < 0)
            {
                bt15 = m_QuestUnitOpen[n10];
                if (nValue == 0)
                {
                    m_QuestUnitOpen[n10] = (byte)((~(128 >> n14)) & bt15);
                }
                else
                {
                    m_QuestUnitOpen[n10] = (byte)((128 >> n14) | bt15);
                }
            }
        }

        public int GetQuestUnitStatus(int nFlag)
        {
            int result = 0;
            nFlag -= 1;
            if (nFlag < 0)
            {
                return result;
            }
            int n10 = nFlag / 8;
            int n14 = nFlag % 8;
            if ((n10 - m_QuestUnit.Length) < 0)
            {
                if (((128 >> n14) & m_QuestUnit[n10]) != 0)
                {
                    result = 1;
                }
                else
                {
                    result = 0;
                }
            }
            return result;
        }

        public void SetQuestUnitStatus(int nFlag, int nValue)
        {
            int n10;
            int n14;
            byte bt15;
            nFlag -= 1;
            if (nFlag < 0)
            {
                return;
            }
            n10 = nFlag / 8;
            n14 = nFlag % 8;
            if ((n10 - m_QuestUnit.Length) < 0)
            {
                bt15 = m_QuestUnit[n10];
                if (nValue == 0)
                {
                    m_QuestUnit[n10] = (byte)((~(128 >> n14)) & bt15);
                }
                else
                {
                    m_QuestUnit[n10] = (byte)((128 >> n14) | bt15);
                }
            }
        }

        public bool KillFunc()
        {
            const string sExceptionMsg = "[Exception] TBaseObject::KillFunc";
            bool result = false;
            try
            {
                if ((M2Share.g_FunctionNPC != null) && (m_PEnvir != null) && m_PEnvir.Flag.boKILLFUNC)
                {
                    if (m_btRaceServer != Grobal2.RC_PLAYOBJECT)
                    {
                        if (m_ExpHitter != null)
                        {
                            if (m_ExpHitter.m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                            {
                                M2Share.g_FunctionNPC.GotoLable(m_ExpHitter as TPlayObject, "@KillPlayMon" + m_PEnvir.Flag.nKILLFUNCNO.ToString(), false);
                            }
                            if (m_ExpHitter.m_Master != null)
                            {
                                M2Share.g_FunctionNPC.GotoLable(m_ExpHitter.m_Master as TPlayObject, "@KillPlayMon" + m_PEnvir.Flag.nKILLFUNCNO.ToString(), false);
                            }
                        }
                        else
                        {
                            if (m_LastHiter != null)
                            {
                                if (m_LastHiter.m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                                {
                                    M2Share.g_FunctionNPC.GotoLable(m_LastHiter as TPlayObject, "@KillPlayMon" + m_PEnvir.Flag.nKILLFUNCNO.ToString(), false);
                                }
                                if (m_LastHiter.m_Master != null)
                                {
                                    M2Share.g_FunctionNPC.GotoLable(m_LastHiter.m_Master as TPlayObject, "@KillPlayMon" + m_PEnvir.Flag.nKILLFUNCNO.ToString(), false);
                                }
                            }
                        }
                    }
                    else
                    {
                        if ((m_LastHiter != null) && (m_LastHiter.m_btRaceServer == Grobal2.RC_PLAYOBJECT))
                        {
                            M2Share.g_FunctionNPC.GotoLable(m_LastHiter as TPlayObject, "@KillPlay" + m_PEnvir.Flag.nKILLFUNCNO.ToString(), false);
                        }
                    }
                    result = true;
                }
            }
            catch (Exception e)
            {
                M2Share.ErrorMessage(sExceptionMsg);
                M2Share.ErrorMessage(e.Message);
            }
            return result;
        }

        private void UseLamp()
        {
            int nOldDura;
            int nDura;
            TPlayObject PlayObject;
            MirItem Stditem;
            const string sExceptionMsg = "[Exception] TBaseObject::UseLamp";
            try
            {
                if (m_UseItems[Grobal2.U_RIGHTHAND] != null && m_UseItems[Grobal2.U_RIGHTHAND].wIndex > 0)
                {
                    Stditem = M2Share.UserEngine.GetStdItem(m_UseItems[Grobal2.U_RIGHTHAND].wIndex);
                    if ((Stditem == null) || (Stditem.Source != 0))
                    {
                        return;
                    }
                    nOldDura = HUtil32.Round(m_UseItems[Grobal2.U_RIGHTHAND].Dura / 1000);
                    if (M2Share.g_Config.boDecLampDura)
                    {
                        nDura = m_UseItems[Grobal2.U_RIGHTHAND].Dura - 1;
                    }
                    else
                    {
                        nDura = m_UseItems[Grobal2.U_RIGHTHAND].Dura;
                    }
                    if (nDura <= 0)
                    {
                        m_UseItems[Grobal2.U_RIGHTHAND].Dura = 0;
                        if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                        {
                            PlayObject = this as TPlayObject;
                            PlayObject.SendDelItems(m_UseItems[Grobal2.U_RIGHTHAND]);
                        }
                        m_UseItems[Grobal2.U_RIGHTHAND].wIndex = 0;
                        m_nLight = 0;
                        SendRefMsg(Grobal2.RM_CHANGELIGHT, 0, 0, 0, 0, "");
                        SendMsg(this, Grobal2.RM_LAMPCHANGEDURA, 0, m_UseItems[Grobal2.U_RIGHTHAND].Dura, 0, 0, "");
                        RecalcAbilitys();
                        // FeatureChanged(); 01/21 取消 蜡烛是本人才可以看到的，不需要发送广播信息
                    }
                    else
                    {
                        m_UseItems[Grobal2.U_RIGHTHAND].Dura = (ushort)nDura;
                    }
                    if (nOldDura != HUtil32.Round(nDura / 1000))
                    {
                        SendMsg(this, Grobal2.RM_LAMPCHANGEDURA, 0, m_UseItems[Grobal2.U_RIGHTHAND].Dura, 0, 0, "");
                    }
                }
            }
            catch
            {
                M2Share.ErrorMessage(sExceptionMsg);
            }
        }

        public TBaseObject GetPoseCreate()
        {
            short nX = 0;
            short nY = 0;
            TBaseObject result = null;
            if (GetFrontPosition(ref nX, ref nY))
            {
                result = (TBaseObject)m_PEnvir.GetMovingObject(nX, nY, true);
            }
            return result;
        }

        public bool GetAttackDir(TBaseObject BaseObject, ref byte btDir)
        {
            bool result = false;
            if ((m_nCurrX - 1 <= BaseObject.m_nCurrX) && (m_nCurrX + 1 >= BaseObject.m_nCurrX) && (m_nCurrY - 1 <= BaseObject.m_nCurrY) && (m_nCurrY + 1 >= BaseObject.m_nCurrY) && ((m_nCurrX != BaseObject.m_nCurrX) || (m_nCurrY != BaseObject.m_nCurrY)))
            {
                result = true;
                if (((m_nCurrX - 1) == BaseObject.m_nCurrX) && (m_nCurrY == BaseObject.m_nCurrY))
                {
                    btDir = Grobal2.DR_LEFT;
                    return result;
                }
                if (((m_nCurrX + 1) == BaseObject.m_nCurrX) && (m_nCurrY == BaseObject.m_nCurrY))
                {
                    btDir = Grobal2.DR_RIGHT;
                    return result;
                }
                if ((m_nCurrX == BaseObject.m_nCurrX) && ((m_nCurrY - 1) == BaseObject.m_nCurrY))
                {
                    btDir = Grobal2.DR_UP;
                    return result;
                }
                if ((m_nCurrX == BaseObject.m_nCurrX) && ((m_nCurrY + 1) == BaseObject.m_nCurrY))
                {
                    btDir = Grobal2.DR_DOWN;
                    return result;
                }
                if (((m_nCurrX - 1) == BaseObject.m_nCurrX) && ((m_nCurrY - 1) == BaseObject.m_nCurrY))
                {
                    btDir = Grobal2.DR_UPLEFT;
                    return result;
                }
                if (((m_nCurrX + 1) == BaseObject.m_nCurrX) && ((m_nCurrY - 1) == BaseObject.m_nCurrY))
                {
                    btDir = Grobal2.DR_UPRIGHT;
                    return result;
                }
                if (((m_nCurrX - 1) == BaseObject.m_nCurrX) && ((m_nCurrY + 1) == BaseObject.m_nCurrY))
                {
                    btDir = Grobal2.DR_DOWNLEFT;
                    return result;
                }
                if (((m_nCurrX + 1) == BaseObject.m_nCurrX) && ((m_nCurrY + 1) == BaseObject.m_nCurrY))
                {
                    btDir = Grobal2.DR_DOWNRIGHT;
                    return result;
                }
                btDir = 0;
            }
            return result;
        }

        public bool GetAttackDir(TBaseObject BaseObject, int nRange, ref byte btDir)
        {
            short nX = 0;
            short nY = 0;
            btDir = M2Share.GetNextDirection(m_nCurrX, m_nCurrY, BaseObject.m_nCurrX, BaseObject.m_nCurrY);
            if (m_PEnvir.GetNextPosition(m_nCurrX, m_nCurrY, btDir, nRange, ref nX, ref nY))
            {
                return BaseObject == (TBaseObject)m_PEnvir.GetMovingObject(nX, nY, true);
            }
            return false;
        }

        public bool TargetInSpitRange(TBaseObject BaseObject, ref byte btDir)
        {
            bool result = false;
            if ((Math.Abs(BaseObject.m_nCurrX - m_nCurrX) <= 2) && (Math.Abs(BaseObject.m_nCurrY - m_nCurrY) <= 2))
            {
                int nX = BaseObject.m_nCurrX - m_nCurrX;
                int nY = BaseObject.m_nCurrY - m_nCurrY;
                if ((Math.Abs(nX) <= 1) && (Math.Abs(nY) <= 1))
                {
                    GetAttackDir(BaseObject, ref btDir);
                    result = true;
                    return result;
                }
                nX += 2;
                nY += 2;
                if ((nX >= 0) && (nX <= 4) && (nY >= 0) && (nY <= 4))
                {
                    btDir = M2Share.GetNextDirection(m_nCurrX, m_nCurrY, BaseObject.m_nCurrX, BaseObject.m_nCurrY);
                    if (M2Share.g_Config.SpitMap[btDir, nY, nX] == 1)
                    {
                        result = true;
                    }
                }
            }
            return result;
        }

        protected ushort RecalcBagWeight()
        {
            ushort result = 0;
            TUserItem UserItem;
            MirItem StdItem;
            for (int i = 0; i < m_ItemList.Count; i++)
            {
                UserItem = m_ItemList[i];
                StdItem = M2Share.UserEngine.GetStdItem(UserItem.wIndex);
                if (StdItem != null)
                {
                    result += StdItem.Weight;
                }
            }
            return result;
        }

        private void RecalcHitSpeed()
        {
            TUserMagic UserMagic;
            TNakedAbility BonusTick = null;
            switch (m_btJob)
            {
                case M2Share.jWarr:
                    BonusTick = M2Share.g_Config.BonusAbilofWarr;
                    break;
                case M2Share.jWizard:
                    BonusTick = M2Share.g_Config.BonusAbilofWizard;
                    break;
                case M2Share.jTaos:
                    BonusTick = M2Share.g_Config.BonusAbilofTaos;
                    break;
            }
            m_btHitPoint = (byte)(M2Share.DEFHIT + m_BonusAbil.Hit / BonusTick.Hit);
            switch (m_btJob)
            {
                case M2Share.jTaos:
                    m_btSpeedPoint = (byte)(M2Share.DEFSPEED + m_BonusAbil.Speed / BonusTick.Speed + 3);
                    break;
                default:
                    m_btSpeedPoint = (byte)(M2Share.DEFSPEED + m_BonusAbil.Speed / BonusTick.Speed);
                    break;
            }
            m_nHitPlus = 0;
            m_nHitDouble = 0;
            m_MagicOneSwordSkill = null;
            m_MagicPowerHitSkill = null;
            m_MagicErgumSkill = null;
            m_MagicBanwolSkill = null;
            m_MagicRedBanwolSkill = null;
            m_MagicFireSwordSkill = null;
            m_MagicCrsSkill = null;
            m_Magic41Skill = null;
            m_MagicTwnHitSkill = null;
            m_Magic43Skill = null;
            for (int i = 0; i < m_MagicList.Count; i++)
            {
                UserMagic = m_MagicList[i];
                switch (UserMagic.wMagIdx)
                {
                    case Grobal2.SKILL_ONESWORD:// 内功心法
                        m_MagicOneSwordSkill = UserMagic;
                        if (UserMagic.btLevel > 0)
                        {
                            m_btHitPoint = (byte)(m_btHitPoint + HUtil32.Round(9 / 3 * UserMagic.btLevel));
                        }
                        break;
                    case Grobal2.SKILL_YEDO:// 攻杀剑法
                        m_MagicPowerHitSkill = UserMagic;
                        if (UserMagic.btLevel > 0)
                        {
                            m_btHitPoint = (byte)(m_btHitPoint + HUtil32.Round(3 / 3 * UserMagic.btLevel));
                        }
                        m_nHitPlus = (byte)(M2Share.DEFHIT + UserMagic.btLevel);
                        m_btAttackSkillCount = (byte)(7 - UserMagic.btLevel);
                        m_btAttackSkillPointCount = (byte)M2Share.RandomNumber.Random(m_btAttackSkillCount);
                        break;
                    case Grobal2.SKILL_ERGUM:// 刺杀剑法
                        m_MagicErgumSkill = UserMagic;
                        break;
                    case Grobal2.SKILL_BANWOL:// 半月弯刀
                        m_MagicBanwolSkill = UserMagic;
                        break;
                    case Grobal2.SKILL_REDBANWOL:
                        m_MagicRedBanwolSkill = UserMagic;
                        break;
                    case Grobal2.SKILL_FIRESWORD:// 烈火剑法
                        m_MagicFireSwordSkill = UserMagic;
                        m_nHitDouble = (byte)(4 + UserMagic.btLevel * 4);
                        break;
                    case Grobal2.SKILL_ILKWANG:// 基本剑法
                        m_MagicOneSwordSkill = UserMagic;
                        if (UserMagic.btLevel > 0)
                        {
                            m_btHitPoint = (byte)(m_btHitPoint + HUtil32.Round(8 / 3 * UserMagic.btLevel));
                        }
                        break;
                    case Grobal2.SKILL_CROSSMOON:
                        m_MagicCrsSkill = UserMagic;
                        break;
                    case 41:
                        m_Magic41Skill = UserMagic;
                        break;
                    case Grobal2.SKILL_TWINBLADE:
                        m_MagicTwnHitSkill = UserMagic;
                        break;
                    case 43:
                        m_Magic43Skill = UserMagic;
                        break;
                }
            }
        }

        public void AddItemSkill(int nIndex)
        {
            TMagic Magic = null;
            TUserMagic UserMagic;
            switch (nIndex)
            {
                case 1:
                    Magic = M2Share.UserEngine.FindMagic(M2Share.g_Config.sFireBallSkill);
                    break;
                case 2:
                    Magic = M2Share.UserEngine.FindMagic(M2Share.g_Config.sHealSkill);
                    break;
            }
            if (Magic != null)
            {
                if (!IsTrainingSkill(Magic.wMagicID))
                {
                    UserMagic = new TUserMagic
                    {
                        MagicInfo = Magic,
                        wMagIdx = Magic.wMagicID,
                        btKey = 0,
                        btLevel = 1,
                        nTranPoint = 0
                    };
                    m_MagicList.Add(UserMagic);
                    if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                    {
                        (this as TPlayObject).SendAddMagic(UserMagic);
                    }
                }
            }
        }

        private bool AddToMap()
        {
            bool result;
            object Point = m_PEnvir.AddToMap(m_nCurrX, m_nCurrY, Grobal2.OS_MOVINGOBJECT, this);
            if (Point != null)
            {
                result = true;
            }
            else
            {
                result = false;
            }
            if (!m_boFixedHideMode)
            {
                SendRefMsg(Grobal2.RM_TURN, m_btDirection, m_nCurrX, m_nCurrY, 0, "");
            }
            return result;
        }

        /// <summary>
        /// 计算施法魔法值
        /// </summary>
        /// <param name="UserMagic"></param>
        /// <returns></returns>
        public short GetMagicSpell(TUserMagic UserMagic)
        {
            return (short)HUtil32.Round(UserMagic.MagicInfo.wSpell / (UserMagic.MagicInfo.btTrainLv + 1) * (UserMagic.btLevel + 1));
        }

        /// <summary>
        /// 武器升级设置
        /// </summary>
        /// <param name="UserItem"></param>
        public void AttackDir_CheckWeaponUpgradeStatus(TUserItem UserItem)
        {
            if ((UserItem.btValue[0] + UserItem.btValue[1] + UserItem.btValue[2]) < M2Share.g_Config.nUpgradeWeaponMaxPoint)
            {
                if (UserItem.btValue[10] == 1)
                {
                    UserItem.wIndex = 0;
                }
                if (HUtil32.RangeInDefined(UserItem.btValue[10], 10, 13))
                {
                    UserItem.btValue[0] = (byte)(UserItem.btValue[0] + UserItem.btValue[10] - 9);
                }
                if (HUtil32.RangeInDefined(UserItem.btValue[10], 20, 23))
                {
                    UserItem.btValue[1] = (byte)(UserItem.btValue[1] + UserItem.btValue[10] - 19);
                }
                if (HUtil32.RangeInDefined(UserItem.btValue[10], 30, 33))
                {
                    UserItem.btValue[2] = (byte)(UserItem.btValue[2] + UserItem.btValue[10] - 29);
                }
            }
            else
            {
                UserItem.wIndex = 0;
            }
            UserItem.btValue[10] = 0;
        }

        public void AttackDir_CheckWeaponUpgrade()
        {
            TUserItem UseItems;
            TPlayObject PlayObject;
            MirItem StdItem;
            if (m_UseItems[Grobal2.U_WEAPON].btValue[10] > 0)
            {
                UseItems = m_UseItems[Grobal2.U_WEAPON];
                AttackDir_CheckWeaponUpgradeStatus(m_UseItems[Grobal2.U_WEAPON]);
                if (m_UseItems[Grobal2.U_WEAPON].wIndex == 0)
                {
                    SysMsg(M2Share.g_sTheWeaponBroke, TMsgColor.c_Red, TMsgType.t_Hint);
                    PlayObject = this as TPlayObject;
                    PlayObject.SendDelItems(UseItems);
                    // PlayObject.StatusChanged;
                    SendRefMsg(Grobal2.RM_BREAKWEAPON, 0, 0, 0, 0, "");
                    StdItem = M2Share.UserEngine.GetStdItem(UseItems.wIndex);
                    if (StdItem.NeedIdentify == 1)
                    {
                        // UserEngine.GetStdItemName(UseItems.wIndex) + #9 +
                        M2Share.AddGameDataLog("21" + "\t" + m_sMapName + "\t" + m_nCurrX.ToString() + "\t" + m_nCurrY.ToString() + "\t" + m_sCharName + "\t" + StdItem.Name + "\t" + UseItems.MakeIndex.ToString() + "\t" + '1' + "\t" + '0');
                    }
                    FeatureChanged();
                }
                else
                {
                    SysMsg(M2Share.sTheWeaponRefineSuccessfull, TMsgColor.c_Red, TMsgType.t_Hint);
                    PlayObject = this as TPlayObject;
                    PlayObject.SendUpdateItem(m_UseItems[Grobal2.U_WEAPON]);
                    StdItem = M2Share.UserEngine.GetStdItem(UseItems.wIndex);
                    if (StdItem.NeedIdentify == 1)
                    {
                        // UserEngine.GetStdItemName(UseItems.wIndex) + #9 +
                        M2Share.AddGameDataLog("20" + "\t" + m_sMapName + "\t" + m_nCurrX.ToString() + "\t" + m_nCurrY.ToString() + "\t" + m_sCharName + "\t" + StdItem.Name + "\t" + UseItems.MakeIndex.ToString() + "\t" + '1' + "\t" + '0');
                    }
                    RecalcAbilitys();
                    SendMsg(this, Grobal2.RM_ABILITY, 0, 0, 0, 0, "");
                    SendMsg(this, Grobal2.RM_SUBABILITY, 0, 0, 0, 0, "");
                }
            }
        }

        public virtual void AttackDir(TBaseObject TargeTBaseObject, short wHitMode, byte nDir)
        {
            TBaseObject AttackTarget;
            bool boPowerHit;
            bool boFireHit;
            bool boCrsHit;
            bool bo41;
            bool boTwinHit;
            bool bo43;
            short wIdent;
            const string sExceptionMsg = "[Exception] TBaseObject::AttackDir";
            try
            {
                if ((wHitMode == 5) && (m_MagicBanwolSkill != null)) // 半月
                {
                    if (m_WAbil.MP > 0)
                    {
                        DamageSpell((ushort)(m_MagicBanwolSkill.MagicInfo.btDefSpell + GetMagicSpell(m_MagicBanwolSkill)));
                        HealthSpellChanged();
                    }
                    else
                    {
                        wHitMode = Grobal2.RM_HIT;
                    }
                }
                if ((wHitMode == 12) && (m_MagicRedBanwolSkill != null))
                {
                    if (m_WAbil.MP > 0)
                    {
                        DamageSpell((ushort)(m_MagicRedBanwolSkill.MagicInfo.btDefSpell + GetMagicSpell(m_MagicRedBanwolSkill)));
                        HealthSpellChanged();
                    }
                    else
                    {
                        wHitMode = Grobal2.RM_HIT;
                    }
                }
                if ((wHitMode == 8) && (m_MagicCrsSkill != null))
                {
                    if (m_WAbil.MP > 0)
                    {
                        DamageSpell((ushort)(m_MagicCrsSkill.MagicInfo.btDefSpell + GetMagicSpell(m_MagicCrsSkill)));
                        HealthSpellChanged();
                    }
                    else
                    {
                        wHitMode = Grobal2.RM_HIT;
                    }
                }

                m_btDirection = nDir;
                if (TargeTBaseObject == null)
                {
                    AttackTarget = GetPoseCreate();
                }
                else
                {
                    AttackTarget = TargeTBaseObject;
                }
                if ((AttackTarget != null) && (m_UseItems[Grobal2.U_WEAPON] != null) && (m_UseItems[Grobal2.U_WEAPON].wIndex > 0))
                {
                    AttackDir_CheckWeaponUpgrade();
                }

                boPowerHit = m_boPowerHit;
                boFireHit = m_boFireHitSkill;
                boCrsHit = m_boCrsHitkill;
                bo41 = m_bo41kill;
                boTwinHit = m_boTwinHitSkill;
                bo43 = m_bo43kill;
                if (_Attack(ref wHitMode, AttackTarget))
                {
                    SetTargetCreat(AttackTarget);
                }
                wIdent = Grobal2.RM_HIT;
                if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                {
                    switch (wHitMode)
                    {
                        case 0:
                            wIdent = Grobal2.RM_HIT;
                            break;
                        case 1:
                            wIdent = Grobal2.RM_HEAVYHIT;
                            break;
                        case 2:
                            wIdent = Grobal2.RM_BIGHIT;
                            break;
                        case 3:
                            if (boPowerHit)
                            {
                                wIdent = Grobal2.RM_SPELL2;
                            }
                            break;
                        case 4:
                            if (m_MagicErgumSkill != null)
                            {
                                wIdent = Grobal2.RM_LONGHIT;
                            }
                            break;
                        case 5:
                            if (m_MagicBanwolSkill != null)
                            {
                                wIdent = Grobal2.RM_WIDEHIT;
                            }
                            break;
                        case 7:
                            if (boFireHit)
                            {
                                wIdent = Grobal2.RM_FIREHIT;
                            }
                            break;
                        case 8:
                            if (m_MagicCrsSkill != null)
                            {
                                wIdent = Grobal2.RM_CRSHIT;
                            }
                            break;
                        case 9:
                            if (boTwinHit)
                            {
                                wIdent = Grobal2.RM_TWINHIT;
                            }
                            break;
                        case 12:
                            if (m_MagicRedBanwolSkill != null)
                            {
                                wIdent = Grobal2.RM_WIDEHIT;
                            }
                            break;
                    }
                }
                SendAttackMsg(wIdent, m_btDirection, m_nCurrX, m_nCurrY);
            }
            catch (Exception e)
            {
                M2Share.ErrorMessage(sExceptionMsg);
                M2Share.ErrorMessage(e.Message);
            }
        }

        private void CheckPKStatus()
        {
            if (m_boPKFlag && ((HUtil32.GetTickCount() - m_dwPKTick) > M2Share.g_Config.dwPKFlagTime))// 60 * 1000
            {
                m_boPKFlag = false;
                RefNameColor();
            }
        }

        /// <summary>
        /// 减少魔法值
        /// </summary>
        /// <param name="nSpellPoint"></param>
        public void DamageSpell(ushort nSpellPoint)
        {
            if (nSpellPoint > 0)
            {
                if ((m_WAbil.MP - nSpellPoint) > 0)
                {
                    m_WAbil.MP -= nSpellPoint;
                }
                else
                {
                    m_WAbil.MP = 0;
                }
            }
            else
            {
                if ((m_WAbil.MP - nSpellPoint) < m_WAbil.MaxMP)
                {
                    m_WAbil.MP -= nSpellPoint;
                }
                else
                {
                    m_WAbil.MP = m_WAbil.MaxMP;
                }
            }
        }

        private void DecPKPoint(int nPoint)
        {
            int nC = PKLevel();
            m_nPkPoint -= nPoint;
            if (m_nPkPoint < 0)
            {
                m_nPkPoint = 0;
            }
            if ((PKLevel() != nC) && (nC > 0) && (nC <= 2))
            {
                RefNameColor();
            }
        }

        public void DelItemSkill_DeleteSkill(string sSkillName)
        {
            TUserMagic UserMagic;
            TPlayObject PlayObject;
            for (int i = 0; i < m_MagicList.Count; i++)
            {
                UserMagic = m_MagicList[i];
                if (UserMagic.MagicInfo.sMagicName == sSkillName)
                {
                    PlayObject = this as TPlayObject;
                    PlayObject.SendDelMagic(UserMagic);
                    UserMagic = null;
                    m_MagicList.RemoveAt(i);
                    break;
                }
            }
        }

        public void DelItemSkill(int nIndex)
        {
            if (m_btRaceServer != Grobal2.RC_PLAYOBJECT)
            {
                return;
            }
            switch (nIndex)
            {
                case 1:
                    if (m_btJob != M2Share.jWizard)
                    {
                        DelItemSkill_DeleteSkill(M2Share.g_Config.sFireBallSkill);
                    }
                    break;
                case 2:
                    if (m_btJob != M2Share.jTaos)
                    {
                        DelItemSkill_DeleteSkill(M2Share.g_Config.sHealSkill);
                    }
                    break;
            }
        }

        public void DelMember(TBaseObject BaseObject)
        {
            TPlayObject PlayObject;
            if (m_GroupOwner != BaseObject)
            {
                for (int i = 0; i < m_GroupMembers.Count; i++)
                {
                    if (m_GroupMembers[i] == BaseObject)
                    {
                        BaseObject.LeaveGroup();
                        m_GroupMembers.RemoveAt(i);
                        break;
                    }
                }
            }
            else
            {
                for (int i = m_GroupMembers.Count - 1; i >= 0; i--)
                {
                    m_GroupMembers[i].LeaveGroup();
                    m_GroupMembers.RemoveAt(i);
                }
            }
            PlayObject = this as TPlayObject;
            if (!PlayObject.CancelGroup())
            {
                PlayObject.SendDefMessage(Grobal2.SM_GROUPCANCEL, 0, 0, 0, 0, "");
            }
            else
            {
                PlayObject.SendGroupMembers();
            }
        }

        public void DoDamageWeapon(int nWeaponDamage)
        {
            int nDura;
            int nDuraPoint;
            TPlayObject PlayObject;
            MirItem StdItem;
            if (m_UseItems[Grobal2.U_WEAPON] != null && m_UseItems[Grobal2.U_WEAPON].wIndex <= 0)
            {
                return;
            }
            nDura = m_UseItems[Grobal2.U_WEAPON].Dura;
            nDuraPoint = HUtil32.Round(nDura / 1.03);
            nDura -= nWeaponDamage;
            if (nDura <= 0)
            {
                nDura = 0;
                m_UseItems[Grobal2.U_WEAPON].Dura = (ushort)nDura;
                if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                {
                    PlayObject = this as TPlayObject;
                    PlayObject.SendDelItems(m_UseItems[Grobal2.U_WEAPON]);
                    StdItem = M2Share.UserEngine.GetStdItem(m_UseItems[Grobal2.U_WEAPON].wIndex);
                    if (StdItem.NeedIdentify == 1)
                    {
                        // UserEngine.GetStdItemName(m_UseItems[U_WEAPON].wIndex) + #9 +
                        M2Share.AddGameDataLog('3' + "\t" + m_sMapName + "\t" + m_nCurrX.ToString() + "\t" + m_nCurrY.ToString() + "\t" + m_sCharName + "\t" + StdItem.Name + "\t" + m_UseItems[Grobal2.U_WEAPON].MakeIndex.ToString() + "\t" + HUtil32.BoolToIntStr(m_btRaceServer == Grobal2.RC_PLAYOBJECT) + "\t" + '0');
                    }
                }
                m_UseItems[Grobal2.U_WEAPON].wIndex = 0;
                SendMsg(this, Grobal2.RM_DURACHANGE, Grobal2.U_WEAPON, nDura, m_UseItems[Grobal2.U_WEAPON].DuraMax, 0, "");
            }
            else
            {
                m_UseItems[Grobal2.U_WEAPON].Dura = (ushort)nDura;
            }
            if ((nDura / 1.03) != nDuraPoint)
            {
                SendMsg(this, Grobal2.RM_DURACHANGE, Grobal2.U_WEAPON, m_UseItems[Grobal2.U_WEAPON].Dura, m_UseItems[Grobal2.U_WEAPON].DuraMax, 0, "");
            }
        }

        public byte GetCharColor(TBaseObject BaseObject)
        {
            int n10;
            TUserCastle Castle;
            byte result = BaseObject.GetNamecolor();
            if (BaseObject.m_btRaceServer == Grobal2.RC_PLAYOBJECT)
            {
                if (BaseObject.PKLevel() < 2)
                {
                    if (BaseObject.m_boPKFlag)
                    {
                        result = M2Share.g_Config.btPKFlagNameColor;
                    }
                    n10 = GetGuildRelation(this, BaseObject);
                    switch (n10)
                    {
                        case 1:
                        case 3:
                            result = M2Share.g_Config.btAllyAndGuildNameColor;
                            break;
                        case 2:
                            result = M2Share.g_Config.btWarGuildNameColor;
                            break;
                    }
                    if (BaseObject.m_PEnvir.Flag.boFight3Zone)
                    {
                        if (m_MyGuild == BaseObject.m_MyGuild)
                        {
                            result = M2Share.g_Config.btAllyAndGuildNameColor;
                        }
                        else
                        {
                            result = M2Share.g_Config.btWarGuildNameColor;
                        }
                    }
                }
                Castle = M2Share.CastleManager.InCastleWarArea(BaseObject);
                if ((Castle != null) && Castle.m_boUnderWar && m_boInFreePKArea && BaseObject.m_boInFreePKArea)
                {
                    result = M2Share.g_Config.btInFreePKAreaNameColor;
                    m_boGuildWarArea = true;
                    if (m_MyGuild == null)
                    {
                        return result;
                    }
                    if (Castle.IsMasterGuild(m_MyGuild))
                    {
                        if ((m_MyGuild == BaseObject.m_MyGuild) || m_MyGuild.IsAllyGuild(BaseObject.m_MyGuild))
                        {
                            result = M2Share.g_Config.btAllyAndGuildNameColor;
                        }
                        else
                        {
                            if (Castle.IsAttackGuild(BaseObject.m_MyGuild))
                            {
                                result = M2Share.g_Config.btWarGuildNameColor;
                            }
                        }
                    }
                    else
                    {
                        if (Castle.IsAttackGuild(m_MyGuild))
                        {
                            if ((m_MyGuild == BaseObject.m_MyGuild) || m_MyGuild.IsAllyGuild(BaseObject.m_MyGuild))
                            {
                                result = M2Share.g_Config.btAllyAndGuildNameColor;
                            }
                            else
                            {
                                if (Castle.IsMember(BaseObject))
                                {
                                    result = M2Share.g_Config.btWarGuildNameColor;
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                if (BaseObject.m_btSlaveExpLevel < Grobal2.SLAVEMAXLEVEL)
                {
                    result = M2Share.g_Config.SlaveColor[BaseObject.m_btSlaveExpLevel];
                }
                if (BaseObject.m_boCrazyMode)
                {
                    result = 0xF9;
                }
                if (BaseObject.m_boHolySeize)
                {
                    result = 0x7D;
                }
            }
            return result;
        }

        public int GetLevelExp(int nLevel)
        {
            int result;
            if (nLevel <= Grobal2.MAXLEVEL)
            {
                result = M2Share.g_Config.dwNeedExps[nLevel];
            }
            else
            {
                result = M2Share.g_Config.dwNeedExps[M2Share.g_Config.dwNeedExps.GetUpperBound(0)];
            }
            return result;
        }

        private byte GetNamecolor()
        {
            byte result = m_btNameColor;
            if (PKLevel() == 1)
            {
                result = M2Share.g_Config.btPKLevel1NameColor;
            }
            if (PKLevel() >= 2)
            {
                result = M2Share.g_Config.btPKLevel2NameColor;
            }
            return result;
        }

        public void HearMsg(string sMsg)
        {
            if (!string.IsNullOrEmpty(sMsg))
            {
                SendMsg(null, Grobal2.RM_HEAR, 0, M2Share.g_Config.btHearMsgFColor, M2Share.g_Config.btHearMsgBColor, 0, sMsg);
            }
        }

        public bool InSafeArea()
        {
            bool result = false;
            int n14;
            int n18;
            if (m_PEnvir == null)
            {
                return result;
            }
            result = m_PEnvir.Flag.boSAFE;
            if (result)
            {
                return result;
            }
            for (int i = 0; i < M2Share.StartPointList.Count; i++)
            {
                if (M2Share.StartPointList[i].m_sMapName == m_PEnvir.sMapName)
                {
                    if (M2Share.StartPointList[i] != null)
                    {
                        n14 = M2Share.StartPointList[i].m_nCurrX;
                        n18 = M2Share.StartPointList[i].m_nCurrY;
                        if ((Math.Abs(m_nCurrX - n14) <= 60) && (Math.Abs(m_nCurrY - n18) <= 60))
                        {
                            result = true;
                        }
                    }
                }
            }
            return result;
        }

        public void MonsterRecalcAbilitys()
        {
            m_WAbil.DC = HUtil32.MakeLong(HUtil32.LoWord(m_WAbil.DC), HUtil32.HiWord(m_Abil.DC));
            int n8 = 0;
            if ((m_btRaceServer == M2Share.MONSTER_WHITESKELETON) || (m_btRaceServer == M2Share.MONSTER_ELFMONSTER) || (m_btRaceServer == M2Share.MONSTER_ELFWARRIOR))
            {
                m_WAbil.DC = HUtil32.MakeLong(HUtil32.LoWord(m_WAbil.DC), HUtil32.Round((m_btSlaveExpLevel * 0.1 + 0.3) * 3.0 * m_btSlaveExpLevel + HUtil32.HiWord(m_WAbil.DC)));
                n8 = n8 + HUtil32.Round((m_btSlaveExpLevel * 0.1 + 0.3) * m_Abil.MaxHP) * m_btSlaveExpLevel;
                n8 = n8 + m_Abil.MaxHP;
                if (m_btSlaveExpLevel > 0)
                {
                    m_WAbil.MaxHP = (ushort)n8;
                }
                else
                {
                    m_WAbil.MaxHP = m_Abil.MaxHP;
                }
            }
            else
            {
                n8 = m_Abil.MaxHP;
                m_WAbil.DC = HUtil32.MakeLong(HUtil32.LoWord(m_WAbil.DC), HUtil32.Round(m_btSlaveExpLevel * 2 + HUtil32.HiWord(m_WAbil.DC)));
                n8 = n8 + HUtil32.Round(m_Abil.MaxHP * 0.15) * m_btSlaveExpLevel;
                m_WAbil.MaxHP = (ushort)HUtil32._MIN(HUtil32.Round(m_Abil.MaxHP + m_btSlaveExpLevel * 60), n8);
                // m_WAbil.MAC:=0; 01/20 取消此行，防止怪物升级后魔防变0
            }
            // m_btHitPoint:=15; 01/20 取消此行，防止怪物升级后准确率变15
        }

        public void SendFirstMsg(TBaseObject BaseObject, short wIdent, short wParam, int lParam1, int lParam2, int lParam3, string sMsg)
        {
            SendMessage SendMessage;
            try
            {
                HUtil32.EnterCriticalSection(M2Share.ProcessMsgCriticalSection);
                if (!m_boGhost)
                {
                    SendMessage = new SendMessage
                    {
                        wIdent = wIdent,
                        wParam = wParam,
                        nParam1 = lParam1,
                        nParam2 = lParam2,
                        nParam3 = lParam3,
                        dwDeliveryTime = 0,
                        BaseObject = BaseObject
                    };
                    if (!string.IsNullOrEmpty(sMsg))
                    {
                        SendMessage.Buff = sMsg;
                    }
                    else
                    {
                        SendMessage.Buff = null;
                    }
                    m_MsgList.Insert(0, SendMessage);
                }
            }
            finally
            {
                HUtil32.LeaveCriticalSection(M2Share.ProcessMsgCriticalSection);
            }
        }

        public void SendMsg(TBaseObject BaseObject, int wIdent, int wParam, int nParam1, int nParam2, int nParam3, string sMsg)
        {
            SendMessage SendMessage;
            try
            {
                HUtil32.EnterCriticalSection(M2Share.ProcessMsgCriticalSection);
                if (!m_boGhost)
                {
                    SendMessage = new SendMessage
                    {
                        wIdent = wIdent,
                        wParam = wParam,
                        nParam1 = nParam1,
                        nParam2 = nParam2,
                        nParam3 = nParam3,
                        dwDeliveryTime = 0,
                        BaseObject = BaseObject,
                        boLateDelivery = false
                    };
                    if (!string.IsNullOrEmpty(sMsg))
                    {
                        SendMessage.Buff = sMsg;
                    }
                    m_MsgList.Add(SendMessage);
                }
            }
            finally
            {
                HUtil32.LeaveCriticalSection(M2Share.ProcessMsgCriticalSection);
            }
        }

        public void SendDelayMsg(TBaseObject BaseObject, int wIdent, int wParam, int lParam1, int lParam2, int lParam3, string sMsg, int dwDelay)
        {
            SendMessage SendMessage;
            try
            {
                HUtil32.EnterCriticalSection(M2Share.ProcessMsgCriticalSection);
                if (!m_boGhost)
                {
                    SendMessage = new SendMessage
                    {
                        wIdent = wIdent,
                        wParam = wParam,
                        nParam1 = lParam1,
                        nParam2 = lParam2,
                        nParam3 = lParam3,
                        dwDeliveryTime = HUtil32.GetTickCount() + dwDelay,
                        BaseObject = BaseObject,
                        boLateDelivery = true
                    };
                    if (!string.IsNullOrEmpty(sMsg))
                    {
                        SendMessage.Buff = sMsg;
                    }
                    else
                    {
                        SendMessage.Buff = null;
                    }
                    m_MsgList.Add(SendMessage);
                }
            }
            finally
            {
                HUtil32.LeaveCriticalSection(M2Share.ProcessMsgCriticalSection);
            }
        }

        public void SendDelayMsg(int BaseObject, short wIdent, int wParam, int lParam1, int lParam2, int lParam3, string sMsg, int dwDelay)
        {
            SendMessage SendMessage;
            try
            {
                HUtil32.EnterCriticalSection(M2Share.ProcessMsgCriticalSection);
                if (!m_boGhost)
                {
                    SendMessage = new SendMessage
                    {
                        wIdent = wIdent,
                        wParam = wParam,
                        nParam1 = lParam1,
                        nParam2 = lParam2,
                        nParam3 = lParam3,
                        dwDeliveryTime = HUtil32.GetTickCount() + dwDelay,
                        boLateDelivery = true
                    };
                    if (BaseObject == Grobal2.RM_STRUCK)
                    {
                        SendMessage.ObjectId = Grobal2.RM_STRUCK;
                    }
                    else
                    {
                        SendMessage.BaseObject = M2Share.ObjectSystem.Get(BaseObject);
                    }
                    if (!string.IsNullOrEmpty(sMsg))
                    {
                        SendMessage.Buff = sMsg;
                    }
                    else
                    {
                        SendMessage.Buff = null;
                    }
                    m_MsgList.Add(SendMessage);
                }
            }
            finally
            {
                HUtil32.LeaveCriticalSection(M2Share.ProcessMsgCriticalSection);
            }
        }

        private void SendUpdateDelayMsg(TBaseObject BaseObject, short wIdent, short wParam, int lParam1, int lParam2, int lParam3, string sMsg, int dwDelay)
        {
            SendMessage SendMessage;
            int i;
            HUtil32.EnterCriticalSection(M2Share.ProcessMsgCriticalSection);
            try
            {
                i = 0;
                while (true)
                {
                    if (m_MsgList.Count <= i)
                    {
                        break;
                    }
                    SendMessage = m_MsgList[i];
                    if ((SendMessage.wIdent == wIdent) && (SendMessage.nParam1 == lParam1))
                    {
                        m_MsgList.RemoveAt(i);
                        if (SendMessage.Buff != null)
                        {
                            //FreeMem(SendMessage.Buff);
                        }
                        Dispose(SendMessage);
                        continue;
                    }
                    i++;
                }
            }
            finally
            {
                HUtil32.LeaveCriticalSection(M2Share.ProcessMsgCriticalSection);
            }
            SendDelayMsg(BaseObject, wIdent, wParam, lParam1, lParam2, lParam3, sMsg, dwDelay);
        }

        public void SendUpdateMsg(TBaseObject BaseObject, int wIdent, int wParam, int lParam1, int lParam2, int lParam3, string sMsg)
        {
            SendMessage SendMessage;
            int i;
            try
            {
                HUtil32.EnterCriticalSection(M2Share.ProcessMsgCriticalSection);
                i = 0;
                while (true)
                {
                    if (m_MsgList.Count <= i)
                    {
                        break;
                    }
                    SendMessage = m_MsgList[i];
                    if (SendMessage.wIdent == wIdent)
                    {
                        m_MsgList.RemoveAt(i);
                        if (SendMessage.Buff != null)
                        {
                            //FreeMem(SendMessage.Buff);
                        }
                        Dispose(SendMessage);
                        continue;
                    }
                    i++;
                }
            }
            finally
            {

                HUtil32.LeaveCriticalSection(M2Share.ProcessMsgCriticalSection);
            }
            SendMsg(BaseObject, wIdent, wParam, lParam1, lParam2, lParam3, sMsg);
        }

        public void SendActionMsg(TBaseObject BaseObject, int wIdent, int wParam, int lParam1, int lParam2, int lParam3, string sMsg)
        {
            SendMessage SendMessage;
            int i;
            HUtil32.EnterCriticalSection(M2Share.ProcessMsgCriticalSection);
            try
            {
                i = 0;
                while (true)
                {
                    if (m_MsgList.Count <= i)
                    {
                        break;
                    }
                    SendMessage = m_MsgList[i];
                    if ((SendMessage.wIdent == Grobal2.CM_TURN) || (SendMessage.wIdent == Grobal2.CM_WALK) || (SendMessage.wIdent == Grobal2.CM_SITDOWN) || (SendMessage.wIdent == Grobal2.CM_HORSERUN) || (SendMessage.wIdent == Grobal2.CM_RUN) || (SendMessage.wIdent == Grobal2.CM_HIT) || (SendMessage.wIdent == Grobal2.CM_HEAVYHIT) || (SendMessage.wIdent == Grobal2.CM_BIGHIT) || (SendMessage.wIdent == Grobal2.CM_POWERHIT) || (SendMessage.wIdent == Grobal2.CM_LONGHIT) || (SendMessage.wIdent == Grobal2.CM_WIDEHIT) || (SendMessage.wIdent == Grobal2.CM_FIREHIT))
                    {
                        m_MsgList.RemoveAt(i);
                        if (SendMessage.Buff != null)
                        {
                            //FreeMem(SendMessage.Buff);
                        }
                        Dispose(SendMessage);
                        continue;
                    }
                    i++;
                }
            }
            finally
            {
                HUtil32.LeaveCriticalSection(M2Share.ProcessMsgCriticalSection);
            }
            SendMsg(BaseObject, wIdent, wParam, lParam1, lParam2, lParam3, sMsg);
        }

        public virtual bool GetMessage(ref TProcessMessage Msg)
        {
            bool result = false;
            int I;
            SendMessage SendMessage;
            HUtil32.EnterCriticalSection(M2Share.ProcessMsgCriticalSection);
            try
            {
                I = 0;
                while (m_MsgList.Count > I)
                {
                    if (m_MsgList.Count <= I)
                    {
                        break;
                    }
                    SendMessage = m_MsgList[I];
                    //if ((SendMessage.dwDeliveryTime != 0) && (HUtil32.GetTickCount() < SendMessage.dwDeliveryTime))
                    //{
                    //    I++;
                    //    continue;
                    //}
                    m_MsgList.RemoveAt(I);
                    Msg = new TProcessMessage
                    {
                        wIdent = 0
                    };
                    Msg.wIdent = SendMessage.wIdent;
                    Msg.wParam = SendMessage.wParam;
                    Msg.nParam1 = SendMessage.nParam1;
                    Msg.nParam2 = SendMessage.nParam2;
                    Msg.nParam3 = SendMessage.nParam3;
                    if (SendMessage.BaseObject != null)
                    {
                        Msg.BaseObject = SendMessage.BaseObject.ObjectId;
                    }
                    else if (SendMessage.ObjectId > 0)
                    {
                        Msg.BaseObject = SendMessage.ObjectId;
                    }
                    Msg.dwDeliveryTime = SendMessage.dwDeliveryTime;
                    Msg.boLateDelivery = SendMessage.boLateDelivery;
                    if (!string.IsNullOrEmpty(SendMessage.Buff))
                    {
                        Msg.sMsg = SendMessage.Buff;
                    }
                    else
                    {
                        Msg.sMsg = string.Empty;
                    }
                    SendMessage = null;
                    result = true;
                    break;
                }
            }
            finally
            {
                HUtil32.LeaveCriticalSection(M2Share.ProcessMsgCriticalSection);
            }
            return result;
        }

        public bool GetMapBaseObjects(TEnvirnoment tEnvir, int nX, int nY, int nRage, IList<TBaseObject> rList)
        {
            TMapCellinfo MapCellInfo = null;
            TOSObject OSObject;
            TBaseObject BaseObject;
            const string sExceptionMsg = "[Exception] TBaseObject::GetMapBaseObjects";
            if (rList == null)
            {
                return false;
            }
            try
            {
                int nStartX = nX - nRage;
                int nEndX = nX + nRage;
                int nStartY = nY - nRage;
                int nEndY = nY + nRage;
                for (var x = nStartX; x <= nEndX; x++)
                {
                    for (var y = nStartY; y <= nEndY; y++)
                    {
                        if (tEnvir.GetMapCellInfo(x, y, ref MapCellInfo) && (MapCellInfo.ObjList != null))
                        {
                            for (var j = 0; j < MapCellInfo.ObjList.Count; j++)
                            {
                                OSObject = MapCellInfo.ObjList[j];
                                if ((OSObject != null) && (OSObject.btType == Grobal2.OS_MOVINGOBJECT))
                                {
                                    BaseObject = OSObject.CellObj as TBaseObject;
                                    if ((BaseObject != null) && (!BaseObject.m_boDeath) && (!BaseObject.m_boGhost))
                                    {
                                        rList.Add(BaseObject);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
                M2Share.ErrorMessage(sExceptionMsg);
            }
            return true;
        }

        public void SendRefMsg(int wIdent, int wParam, int nParam1, int nParam2, int nParam3, string sMsg)
        {
            int II;
            int nC;
            int nCX;
            int nCY;
            int nLX;
            int nLY;
            int nHX;
            int nHY;
            TMapCellinfo MapCellInfo = null;
            TOSObject OSObject;
            TBaseObject BaseObject;
            const string sExceptionMsg = "[Exception] TBaseObject::SendRefMsg Name = {0}";
            if (m_PEnvir == null)
            {
                M2Share.ErrorMessage(m_sCharName + " SendRefMsg nil PEnvir ");
                return;
            }
            // 01/21 增加，原来直接不发信息，如果隐身模式则只发送信息给自己
            if (m_boObMode || m_boFixedHideMode)
            {
                SendMsg(this, wIdent, wParam, nParam1, nParam2, nParam3, sMsg);
                return;
            }
            HUtil32.EnterCriticalSection(M2Share.ProcessMsgCriticalSection);
            try
            {
                if (((HUtil32.GetTickCount() - m_SendRefMsgTick) >= 500) || (m_VisibleHumanList.Count == 0))
                {
                    m_SendRefMsgTick = HUtil32.GetTickCount();
                    m_VisibleHumanList.Clear();
                    nLX = m_nCurrX - M2Share.g_Config.nSendRefMsgRange; // 12
                    nHX = m_nCurrX + M2Share.g_Config.nSendRefMsgRange; // 12
                    nLY = m_nCurrY - M2Share.g_Config.nSendRefMsgRange; // 12
                    nHY = m_nCurrY + M2Share.g_Config.nSendRefMsgRange; // 12
                    for (nCX = nLX; nCX <= nHX; nCX++)
                    {
                        for (nCY = nLY; nCY <= nHY; nCY++)
                        {
                            if (m_PEnvir.GetMapCellInfo(nCX, nCY, ref MapCellInfo))
                            {
                                if (MapCellInfo.ObjList != null)
                                {
                                    for (II = MapCellInfo.ObjList.Count - 1; II >= 0; II--)
                                    {
                                        OSObject = MapCellInfo.ObjList[II];
                                        if (OSObject != null)
                                        {
                                            if (OSObject.btType == Grobal2.OS_MOVINGOBJECT)
                                            {
                                                if ((HUtil32.GetTickCount() - OSObject.dwAddTime) >= 60 * 1000)
                                                {
                                                    OSObject = null;
                                                    MapCellInfo.ObjList.RemoveAt(II);
                                                    if (MapCellInfo.ObjList.Count <= 0)
                                                    {
                                                        //MapCellInfo.ObjList.Free;
                                                        MapCellInfo.ObjList = null;
                                                        break;
                                                    }
                                                }
                                                else
                                                {
                                                    try
                                                    {
                                                        BaseObject = OSObject.CellObj as TBaseObject;
                                                        if ((BaseObject != null) && !BaseObject.m_boGhost)
                                                        {
                                                            if (BaseObject.m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                                                            {
                                                                BaseObject.SendMsg(this, wIdent, wParam, nParam1, nParam2, nParam3, sMsg);
                                                                m_VisibleHumanList.Add(BaseObject);
                                                            }
                                                            else if (BaseObject.m_boWantRefMsg)
                                                            {
                                                                if ((wIdent == Grobal2.RM_STRUCK) || (wIdent == Grobal2.RM_HEAR) || (wIdent == Grobal2.RM_DEATH))
                                                                {
                                                                    BaseObject.SendMsg(this, wIdent, wParam, nParam1, nParam2, nParam3, sMsg);
                                                                    m_VisibleHumanList.Add(BaseObject);
                                                                }
                                                            }
                                                        }
                                                    }
                                                    catch (Exception e)
                                                    {
                                                        MapCellInfo.ObjList.RemoveAt(II);
                                                        if (MapCellInfo.ObjList.Count <= 0)
                                                        {
                                                            //MapCellInfo.ObjList.Free;
                                                            MapCellInfo.ObjList = null;
                                                        }
                                                        M2Share.ErrorMessage(format(sExceptionMsg, m_sCharName));
                                                        M2Share.ErrorMessage(e.Message);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    return;
                }
                for (nC = 0; nC < m_VisibleHumanList.Count; nC++)
                {
                    BaseObject = m_VisibleHumanList[nC];
                    if (BaseObject.m_boGhost)
                    {
                        continue;
                    }
                    if ((BaseObject.m_PEnvir == m_PEnvir) && (Math.Abs(BaseObject.m_nCurrX - m_nCurrX) < 11) && (Math.Abs(BaseObject.m_nCurrY - m_nCurrY) < 11))
                    {
                        if (BaseObject.m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                        {
                            BaseObject.SendMsg(this, wIdent, wParam, nParam1, nParam2, nParam3, sMsg);
                        }
                        else if (BaseObject.m_boWantRefMsg)
                        {
                            if ((wIdent == Grobal2.RM_STRUCK) || (wIdent == Grobal2.RM_HEAR) || (wIdent == Grobal2.RM_DEATH))
                            {
                                BaseObject.SendMsg(this, wIdent, wParam, nParam1, nParam2, nParam3, sMsg);
                            }
                        }
                    }
                }
            }
            finally
            {
                HUtil32.LeaveCriticalSection(M2Share.ProcessMsgCriticalSection);
            }
        }

        public virtual void UpdateVisibleGay(TBaseObject BaseObject)
        {
            bool boIsVisible = false;
            TVisibleBaseObject VisibleBaseObject;
            if ((BaseObject.m_btRaceServer == Grobal2.RC_PLAYOBJECT) || (BaseObject.m_Master != null))
            {
                m_boIsVisibleActive = true;
            }
            // 如果是人物或宝宝则置TRUE
            for (int i = 0; i < m_VisibleActors.Count; i++)
            {
                VisibleBaseObject = m_VisibleActors[i];
                if (VisibleBaseObject.BaseObject == BaseObject)
                {
                    VisibleBaseObject.nVisibleFlag = 1;
                    boIsVisible = true;
                    break;
                }
            }
            if (boIsVisible)
            {
                return;
            }
            VisibleBaseObject = new TVisibleBaseObject
            {
                nVisibleFlag = 2,
                BaseObject = BaseObject
            };
            m_VisibleActors.Add(VisibleBaseObject);
        }

        public void UpdateVisibleItem(int wX, int wY, TMapItem MapItem)
        {
            TVisibleMapItem VisibleMapItem;
            bool boIsVisible = false;
            for (int i = 0; i < m_VisibleItems.Count; i++)
            {
                VisibleMapItem = m_VisibleItems[i];
                if (VisibleMapItem.MapItem == MapItem)
                {
                    VisibleMapItem.nVisibleFlag = 1;
                    boIsVisible = true;
                    break;
                }
            }
            if (boIsVisible)
            {
                return;
            }
            VisibleMapItem = new TVisibleMapItem
            {
                nVisibleFlag = 2,
                nX = wX,
                nY = wY,
                MapItem = MapItem,
                sName = MapItem.Name,
                wLooks = MapItem.Looks
            };
            m_VisibleItems.Add(VisibleMapItem);
        }

        public void UpdateVisibleEvent(int wX, int wY, TEvent MapEvent)
        {
            bool boIsVisible = false;
            TEvent __Event;
            for (int i = 0; i < m_VisibleEvents.Count; i++)
            {
                __Event = m_VisibleEvents[i];
                if (__Event == MapEvent)
                {
                    __Event.nVisibleFlag = 1;
                    boIsVisible = true;
                    break;
                }
            }
            if (boIsVisible)
            {
                return;
            }
            MapEvent.nVisibleFlag = 2;
            MapEvent.m_nX = wX;
            MapEvent.m_nY = wY;
            m_VisibleEvents.Add(MapEvent);
        }

        public bool IsVisibleHuman()
        {
            bool result = false;
            TVisibleBaseObject VisibleBaseObject;
            for (int i = 0; i < m_VisibleActors.Count; i++)
            {
                VisibleBaseObject = m_VisibleActors[i];
                if ((VisibleBaseObject.BaseObject.m_btRaceServer == Grobal2.RC_PLAYOBJECT) || (VisibleBaseObject.BaseObject.m_Master != null))
                {
                    result = true;
                    break;
                }
            }
            return result;
        }

        public virtual void SearchViewRange()
        {
            TMapCellinfo MapCellInfo = null;
            TOSObject OSObject;
            TBaseObject BaseObject;
            TVisibleBaseObject VisibleBaseObject;
            const string sExceptionMsg1 = "[Exception] TBaseObject::SearchViewRange";
            const string sExceptionMsg2 = "[Exception] TBaseObject::SearchViewRange 1-%d %s %s %d %d %d";
            if (m_PEnvir == null)
            {
                M2Share.ErrorMessage("SearchViewRange nil PEnvir");
                return;
            }
            var n24 = 0;
            m_boIsVisibleActive = false;// 先置为FALSE
            try
            {
                for (var i = 0; i < m_VisibleActors.Count; i++)
                {
                    m_VisibleActors[i].nVisibleFlag = 0;
                }
            }
            catch
            {
                M2Share.ErrorMessage(sExceptionMsg1);
                KickException();
            }
            var nStartX = m_nCurrX - m_nViewRange;
            var nEndX = m_nCurrX + m_nViewRange;
            var nStartY = m_nCurrY - m_nViewRange;
            var nEndY = m_nCurrY + m_nViewRange;
            try
            {
                for (var n18 = nStartX; n18 <= nEndX; n18++)
                {
                    for (var n1C = nStartY; n1C <= nEndY; n1C++)
                    {
                        if (m_PEnvir.GetMapCellInfo(n18, n1C, ref MapCellInfo) && (MapCellInfo.ObjList != null))
                        {
                            n24 = 1;
                            var nIdx = 0;
                            while (true)
                            {
                                if (MapCellInfo.ObjList.Count <= nIdx)
                                {
                                    break;
                                }
                                OSObject = MapCellInfo.ObjList[nIdx];
                                if (OSObject != null)
                                {
                                    if (OSObject.btType == Grobal2.OS_MOVINGOBJECT)
                                    {
                                        if ((HUtil32.GetTickCount() - OSObject.dwAddTime) >= 60 * 1000)
                                        {
                                            OSObject = null;
                                            MapCellInfo.ObjList.RemoveAt(nIdx);
                                            if (MapCellInfo.ObjList.Count > 0)
                                            {
                                                continue;
                                            }
                                            MapCellInfo.ObjList = null;
                                            break;
                                        }

                                        BaseObject = OSObject.CellObj as TBaseObject;
                                        if (BaseObject != null)
                                        {
                                            if (!BaseObject.m_boGhost && !BaseObject.m_boFixedHideMode && !BaseObject.m_boObMode)
                                            {
                                                if ((m_btRaceServer < Grobal2.RC_ANIMAL) || (m_Master != null) || m_boCrazyMode || m_boNastyMode || m_boWantRefMsg || ((BaseObject.m_Master != null) && (Math.Abs(BaseObject.m_nCurrX - m_nCurrX) <= 3) && (Math.Abs(BaseObject.m_nCurrY - m_nCurrY) <= 3)) || (BaseObject.m_btRaceServer == Grobal2.RC_PLAYOBJECT))
                                                {
                                                    UpdateVisibleGay(BaseObject);
                                                }
                                            }
                                        }
                                    }
                                }
                                nIdx++;
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                M2Share.ErrorMessage(format(sExceptionMsg2, new object[] { n24, m_sCharName, m_sMapName, m_nCurrX, m_nCurrY }));
                M2Share.ErrorMessage(e.Message);
                KickException();
            }

            n24 = 2;
            try
            {
                var n18 = 0;
                while (true)
                {
                    if (m_VisibleActors.Count <= n18)
                    {
                        break;
                    }

                    VisibleBaseObject = m_VisibleActors[n18];
                    if (VisibleBaseObject.nVisibleFlag == 0)
                    {
                        m_VisibleActors.RemoveAt(n18);
                        Dispose(VisibleBaseObject);
                        continue;
                    }

                    n18++;
                }
            }
            catch
            {
                M2Share.ErrorMessage(format(sExceptionMsg2, new object[] { n24, m_sCharName, m_sMapName, m_nCurrX, m_nCurrY }));
                KickException();
            }
        }

        public int GetFeatureToLong()
        {
            return GetFeature(null);
        }

        public ushort GetFeatureEx()
        {
            ushort result;
            if (m_boOnHorse)
            {
                result = HUtil32.MakeWord(m_btHorseType, m_btDressEffType);
            }
            else
            {
                result = HUtil32.MakeWord(0, m_btDressEffType);
            }
            return result;
        }

        public int GetFeature(TBaseObject BaseObject)
        {
            int result;
            byte nDress;
            byte nWeapon;
            byte nHair;
            byte nRaceImg;
            byte nAppr;
            MirItem StdItem;
            bool bo25;
            if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
            {
                nDress = 0;
                if (m_UseItems[Grobal2.U_DRESS] != null && m_UseItems[Grobal2.U_DRESS].wIndex > 0)// 衣服
                {
                    StdItem = M2Share.UserEngine.GetStdItem(m_UseItems[Grobal2.U_DRESS].wIndex);
                    if (StdItem != null)
                    {
                        nDress = (byte)(StdItem.Shape * 2);
                    }
                }
                nDress += m_btGender;
                nWeapon = 0;
                if (m_UseItems[Grobal2.U_WEAPON] != null && m_UseItems[Grobal2.U_WEAPON].wIndex > 0)// 武器
                {
                    StdItem = M2Share.UserEngine.GetStdItem(m_UseItems[Grobal2.U_WEAPON].wIndex);
                    if (StdItem != null)
                    {
                        nWeapon = (byte)(StdItem.Shape * 2);
                    }
                }
                nWeapon += m_btGender;
                nHair = (byte)(m_btHair * 2 + m_btGender);
                result = Grobal2.MakeHumanFeature(0, nDress, nWeapon, nHair);
                return result;
            }
            bo25 = false;
            if ((BaseObject != null) && BaseObject.m_boRaceImg)
            {
                bo25 = true;
            }
            if (bo25)
            {
                nRaceImg = m_btRaceImg;
                nAppr = (byte)m_wAppr;
                switch (nAppr)
                {
                    case 0:
                        nRaceImg = 12;
                        nAppr = 5;
                        break;
                    case 1:
                        nRaceImg = 11;
                        nAppr = 9;
                        break;
                    case 160:
                        nRaceImg = 10;
                        nAppr = 0;
                        break;
                    case 161:
                        nRaceImg = 10;
                        nAppr = 1;
                        break;
                    case 162:
                        nRaceImg = 11;
                        nAppr = 6;
                        break;
                    case 163:
                        nRaceImg = 11;
                        nAppr = 3;
                        break;
                }
                result = Grobal2.MakeMonsterFeature(nRaceImg, m_btMonsterWeapon, nAppr);
                return result;
            }
            result = Grobal2.MakeMonsterFeature(m_btRaceImg, m_btMonsterWeapon, m_wAppr);
            return result;
        }

        /// <summary>
        /// 转换有问题
        /// </summary>
        /// <returns></returns>
        public long GetCharStatus()
        {
            long result = 0;
            long nStatus = 0;
            for (int i = m_wStatusTimeArr.GetLowerBound(0); i <= m_wStatusTimeArr.GetUpperBound(0); i++)
            {
                if (m_wStatusTimeArr[i] > 0)
                {
                    nStatus = (0x80000000 >> i) | nStatus;
                }
            }
            result = (m_nCharStatusEx & 0xFFFFF) | nStatus;
            return result;
        }

        public void AbilCopyToWAbil()
        {
            m_WAbil = m_Abil;
        }

        public virtual void Initialize()
        {
            TUserMagic UserMagic;
            AbilCopyToWAbil();
            for (int i = 0; i < m_MagicList.Count; i++)
            {
                UserMagic = m_MagicList[i];
                if (UserMagic.btLevel >= 4)
                {
                    UserMagic.btLevel = 0;
                }
            }
            m_boAddtoMapSuccess = true;
            if (m_PEnvir.CanWalk(m_nCurrX, m_nCurrY, true) && AddToMap())
            {
                m_boAddtoMapSuccess = false;
            }
            m_nCharStatus = GetCharStatus();
            AddBodyLuck(0);
            LoadSayMsg();
            if (M2Share.g_Config.boMonSayMsg)
            {
                MonsterSayMsg(null, TMonStatus.s_MonGen);
            }
        }

        /// <summary>
        /// 取怪物说话信息列表
        /// </summary>
        public void LoadSayMsg()
        {
            for (var i = 0; i < M2Share.g_MonSayMsgList.Count; i++)
            {
                if (M2Share.g_MonSayMsgList.TryGetValue(m_sCharName, out m_SayMsgList))
                {
                    break;
                }
            }
        }

        public virtual void Disappear()
        {

        }

        public void FeatureChanged()
        {
            SendRefMsg(Grobal2.RM_FEATURECHANGED, GetFeatureEx(), GetFeatureToLong(), 0, 0, "");
        }

        public void StatusChanged()
        {
            SendRefMsg(Grobal2.RM_CHARSTATUSCHANGED, m_nHitSpeed, (int)m_nCharStatus, 0, 0, "");
        }

        protected void DisappearA()
        {
            m_PEnvir.DeleteFromMap(m_nCurrX, m_nCurrY, Grobal2.OS_MOVINGOBJECT, this);
            SendRefMsg(Grobal2.RM_DISAPPEAR, 0, 0, 0, 0, "");
        }

        protected void KickException()
        {
            TPlayObject PlayObject;
            if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
            {
                m_sMapName = M2Share.g_Config.sHomeMap;
                m_nCurrX = M2Share.g_Config.nHomeX;
                m_nCurrY = M2Share.g_Config.nHomeY;
                PlayObject = this as TPlayObject;
                PlayObject.m_boEmergencyClose = true;
            }
            else
            {
                m_boDeath = true;
                m_dwDeathTick = HUtil32.GetTickCount();
                MakeGhost();
            }
        }

        public bool Walk(int nIdent)
        {
            TMapCellinfo MapCellInfo = null;
            TOSObject OSObject;
            TGateObj GateObj;
            bool bo1D;
            TEvent __Event;
            TPlayObject PlayObject;
            const string sExceptionMsg = "[Exception] TBaseObject::Walk  CheckCode:%d %s %s %d:%d";
            bool result = true;
            int nCheckCode = -1;
            if (m_PEnvir == null)
            {
                M2Share.ErrorMessage("Walk nil PEnvir");
                return result;
            }
            try
            {
                nCheckCode = 1;
                bo1D = m_PEnvir.GetMapCellInfo(m_nCurrX, m_nCurrY, ref MapCellInfo);
                GateObj = null;
                __Event = null;
                nCheckCode = 2;
                if (bo1D && (MapCellInfo.ObjList != null))
                {
                    for (int i = 0; i < MapCellInfo.ObjList.Count; i++)
                    {
                        OSObject = MapCellInfo.ObjList[i];
                        if (OSObject.btType == Grobal2.OS_GATEOBJECT)
                        {
                            GateObj = (TGateObj)OSObject.CellObj;
                        }
                        if (OSObject.btType == Grobal2.OS_EVENTOBJECT)
                        {
                            if (((TEvent)OSObject.CellObj).m_OwnBaseObject != null)
                            {
                                __Event = (TEvent)OSObject.CellObj;
                            }
                        }
                        if (OSObject.btType == Grobal2.OS_MAPEVENT)
                        {
                        }
                        if (OSObject.btType == Grobal2.OS_DOOR)
                        {
                        }
                        if (OSObject.btType == Grobal2.OS_ROON)
                        {
                        }
                    }
                }
                nCheckCode = 3;
                if (__Event != null)
                {
                    if (__Event.m_OwnBaseObject.IsProperTarget(this))
                    {
                        SendMsg(__Event.m_OwnBaseObject, Grobal2.RM_MAGSTRUCK_MINE, 0, __Event.m_nDamage, 0, 0, "");
                    }
                }
                nCheckCode = 4;
                if (result && (GateObj != null))
                {
                    if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                    {
                        if (m_PEnvir.ArroundDoorOpened(m_nCurrX, m_nCurrY))
                        {
                            if ((!GateObj.DEnvir.Flag.boNEEDHOLE) || (M2Share.EventManager.GetEvent(m_PEnvir, m_nCurrX, m_nCurrY, Grobal2.ET_DIGOUTZOMBI) != null))
                            {
                                if (M2Share.nServerIndex == GateObj.DEnvir.nServerIndex)
                                {
                                    if (!EnterAnotherMap(GateObj.DEnvir, GateObj.nDMapX, GateObj.nDMapY))
                                    {
                                        result = false;
                                    }
                                }
                                else
                                {
                                    DisappearA();
                                    m_bo316 = true;
                                    PlayObject = this as TPlayObject;
                                    PlayObject.m_sSwitchMapName = GateObj.DEnvir.sMapName;
                                    PlayObject.m_nSwitchMapX = GateObj.nDMapX;
                                    PlayObject.m_nSwitchMapY = GateObj.nDMapY;
                                    PlayObject.m_boSwitchData = true;
                                    PlayObject.m_nServerIndex = GateObj.DEnvir.nServerIndex;
                                    PlayObject.m_boEmergencyClose = true;
                                    PlayObject.m_boReconnection = true;
                                }
                            }
                        }
                    }
                    else
                    {
                        result = false;
                    }
                }
                else
                {
                    nCheckCode = 5;
                    if (result)
                    {
                        nCheckCode = 6;
                        SendRefMsg(nIdent, m_btDirection, m_nCurrX, m_nCurrY, 0, "");
                    }
                }
            }
            catch (Exception e)
            {
                M2Share.ErrorMessage(format(sExceptionMsg, new object[] { nCheckCode, m_sCharName, m_sMapName, m_nCurrX, m_nCurrY }));
                M2Share.ErrorMessage(e.Message);
            }
            return result;
        }

        /// <summary>
        /// 切换地图
        /// </summary>
        /// <param name="Envir"></param>
        /// <param name="nDMapX"></param>
        /// <param name="nDMapY"></param>
        /// <returns></returns>
        public bool EnterAnotherMap(TEnvirnoment Envir, int nDMapX, int nDMapY)
        {
            bool result = false;
            TMapCellinfo MapCellInfo = null;
            TEnvirnoment OldEnvir;
            int nOldX;
            int nOldY;
            TUserCastle Castle;
            const string sExceptionMsg1 = "[Exception] TBaseObject::EnterAnotherMap -> MsgTargetList Clear";
            const string sExceptionMsg2 = "[Exception] TBaseObject::EnterAnotherMap -> VisbleItems Dispose";
            const string sExceptionMsg3 = "[Exception] TBaseObject::EnterAnotherMap -> VisbleItems Clear";
            const string sExceptionMsg4 = "[Exception] TBaseObject::EnterAnotherMap -> VisbleEvents Clear";
            const string sExceptionMsg5 = "[Exception] TBaseObject::EnterAnotherMap -> VisbleActors Dispose";
            const string sExceptionMsg6 = "[Exception] TBaseObject::EnterAnotherMap -> VisbleActors Clear";
            const string sExceptionMsg7 = "[Exception] TBaseObject::EnterAnotherMap";
            try
            {
                if (m_Abil.Level < Envir.nRequestLevel)
                {
                    return result;
                }
                if (Envir.QuestNPC != null)
                {
                    ((TMerchant)Envir.QuestNPC).Click(this as TPlayObject);
                }
                if (Envir.Flag.nNEEDSETONFlag >= 0)
                {
                    if (GetQuestFalgStatus(Envir.Flag.nNEEDSETONFlag) != Envir.Flag.nNeedONOFF)
                    {
                        return result;
                    }
                }
                if (!Envir.GetMapCellInfo(nDMapX, nDMapY, ref MapCellInfo))
                {
                    return result;
                }
                Castle = M2Share.CastleManager.IsCastlePalaceEnvir(Envir);
                if ((Castle != null) && (m_btRaceServer == Grobal2.RC_PLAYOBJECT))
                {
                    if (!Castle.CheckInPalace(m_nCurrX, m_nCurrY, this))
                    {
                        return result;
                    }
                }
                if (Envir.Flag.boNOHORSE)
                {
                    m_boOnHorse = false;
                }
                OldEnvir = m_PEnvir;
                nOldX = m_nCurrX;
                nOldY = m_nCurrY;
                DisappearA();
                try
                {
                    m_VisibleHumanList.Clear();
                }
                catch
                {
                    M2Share.ErrorMessage(sExceptionMsg1);
                }
                try
                {
                    for (var i = 0; i < m_VisibleItems.Count; i++)
                    {
                        m_VisibleItems[i] = null;
                    }
                }
                catch
                {
                    M2Share.ErrorMessage(sExceptionMsg2);
                }
                try
                {
                    m_VisibleItems.Clear();
                }
                catch
                {
                    M2Share.ErrorMessage(sExceptionMsg3);
                }
                try
                {
                    m_VisibleEvents.Clear();
                }
                catch
                {
                    M2Share.ErrorMessage(sExceptionMsg4);
                }
                try
                {
                    for (var i = 0; i < m_VisibleActors.Count; i++)
                    {
                        m_VisibleActors[i] = null;
                    }
                }
                catch
                {
                    M2Share.ErrorMessage(sExceptionMsg5);
                }
                try
                {
                    m_VisibleActors.Clear();
                }
                catch
                {
                    M2Share.ErrorMessage(sExceptionMsg6);
                }
                SendMsg(this, Grobal2.RM_CLEAROBJECTS, 0, 0, 0, 0, "");
                m_PEnvir = Envir;
                m_sMapName = Envir.sMapName;
                m_sMapFileName = Envir.m_sMapFileName;
                m_nCurrX = (short)nDMapX;
                m_nCurrY = (short)nDMapY;
                SendMsg(this, Grobal2.RM_CHANGEMAP, 0, 0, 0, 0, Envir.m_sMapFileName);
                if (AddToMap())
                {

                    m_dwMapMoveTick = HUtil32.GetTickCount();
                    m_bo316 = true;
                    result = true;
                }
                else
                {
                    m_PEnvir = OldEnvir;
                    m_nCurrX = (short)nOldX;
                    m_nCurrY = (short)nOldY;
                    m_PEnvir.AddToMap(m_nCurrX, m_nCurrY, Grobal2.OS_MOVINGOBJECT, this);
                }
                if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                {
                    // 复位泡点，及金币，时间
                    (this as TPlayObject).m_dwIncGamePointTick = HUtil32.GetTickCount();
                    (this as TPlayObject).m_dwIncGameGoldTick = HUtil32.GetTickCount();
                    (this as TPlayObject).m_dwAutoGetExpTick = HUtil32.GetTickCount();
                }
                if (m_PEnvir.Flag.boFight3Zone && (m_PEnvir.Flag.boFight3Zone != OldEnvir.Flag.boFight3Zone))
                {
                    RefShowName();
                }
            }
            catch
            {
                M2Share.ErrorMessage(sExceptionMsg7);
            }
            return result;
        }

        public void TurnTo(byte nDir)
        {
            m_btDirection = nDir;
            SendRefMsg(Grobal2.RM_TURN, nDir, m_nCurrX, m_nCurrY, 0, "");
        }

        public void SysMsg(string sMsg, TMsgColor MsgColor, TMsgType MsgType)
        {
            if (M2Share.g_Config.boShowPreFixMsg)
            {
                switch (MsgType)
                {
                    case TMsgType.t_Mon:
                        sMsg = M2Share.g_Config.sMonSayMsgpreFix + sMsg;
                        break;
                    case TMsgType.t_Hint:
                        sMsg = M2Share.g_Config.sHintMsgPreFix + sMsg;
                        break;
                    case TMsgType.t_GM:
                        sMsg = M2Share.g_Config.sGMRedMsgpreFix + sMsg;
                        break;
                    case TMsgType.t_System:
                        sMsg = M2Share.g_Config.sSysMsgPreFix + sMsg;
                        break;
                    case TMsgType.t_Notice:
                        sMsg = M2Share.g_Config.sLineNoticePreFix + sMsg;
                        break;
                    case TMsgType.t_Cust:
                        sMsg = M2Share.g_Config.sCustMsgpreFix + sMsg;
                        break;
                    case TMsgType.t_Castle:
                        sMsg = M2Share.g_Config.sCastleMsgpreFix + sMsg;
                        break;
                }
            }
            switch (MsgColor)
            {
                case TMsgColor.c_Green:
                    SendMsg(this, Grobal2.RM_SYSMESSAGE, 0, M2Share.g_Config.btGreenMsgFColor, M2Share.g_Config.btGreenMsgBColor, 0, sMsg);
                    break;
                case TMsgColor.c_Blue:
                    SendMsg(this, Grobal2.RM_SYSMESSAGE, 0, M2Share.g_Config.btBlueMsgFColor, M2Share.g_Config.btBlueMsgBColor, 0, sMsg);
                    break;
                default:
                    if (MsgType == TMsgType.t_Cust)
                    {
                        SendMsg(this, Grobal2.RM_SYSMESSAGE, 0, M2Share.g_Config.btCustMsgFColor, M2Share.g_Config.btCustMsgBColor, 0, sMsg);
                    }
                    else
                    {
                        SendMsg(this, Grobal2.RM_SYSMESSAGE, 0, M2Share.g_Config.btRedMsgFColor, M2Share.g_Config.btRedMsgBColor, 0, sMsg);
                    }
                    break;
            }
        }

        /// <summary>
        /// 怪物说话
        /// </summary>
        /// <param name="AttackBaseObject"></param>
        /// <param name="MonStatus"></param>
        public void MonsterSayMsg(TBaseObject AttackBaseObject, TMonStatus MonStatus)
        {
            string sAttackName = string.Empty;
            if (m_SayMsgList == null)
            {
                return;
            }
            if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
            {
                return;
            }
            if (AttackBaseObject != null)
            {
                if ((AttackBaseObject.m_btRaceServer != Grobal2.RC_PLAYOBJECT) && (AttackBaseObject.m_Master == null))
                {
                    return;
                }
                if (AttackBaseObject.m_Master != null)
                {
                    sAttackName = AttackBaseObject.m_Master.m_sCharName;
                }
                else
                {
                    sAttackName = AttackBaseObject.m_sCharName;
                }
            }
            TMonSayMsg MonSayMsg = null;
            string sMsg = string.Empty;
            for (var i = 0; i < m_SayMsgList.Count; i++)
            {
                MonSayMsg = m_SayMsgList[i];
                sMsg = MonSayMsg.sSayMsg.Replace("%s", M2Share.FilterShowName(m_sCharName));
                sMsg = sMsg.Replace("%d", sAttackName);
                if ((MonSayMsg.State == MonStatus) && (M2Share.RandomNumber.Random(MonSayMsg.nRate) == 0))
                {
                    if (MonStatus == TMonStatus.s_MonGen)
                    {
                        M2Share.UserEngine.SendBroadCastMsg(sMsg, TMsgType.t_Mon);
                        break;
                    }
                    if (MonSayMsg.Color == TMsgColor.c_White)
                    {
                        ProcessSayMsg(sMsg);
                    }
                    else
                    {
                        AttackBaseObject.SysMsg(sMsg, MonSayMsg.Color, TMsgType.t_Mon);
                    }
                    break;
                }
            }
        }

        public void SendGroupText(string sMsg)
        {
            TPlayObject PlayObject;
            sMsg = M2Share.g_Config.sGroupMsgPreFix + sMsg;
            if (m_GroupOwner != null)
            {
                for (int i = 0; i < m_GroupOwner.m_GroupMembers.Count; i++)
                {
                    PlayObject = m_GroupOwner.m_GroupMembers[i];
                    PlayObject.SendMsg(this, Grobal2.RM_GROUPMESSAGE, 0, M2Share.g_Config.btGroupMsgFColor, M2Share.g_Config.btGroupMsgBColor, 0, sMsg);
                }
            }
        }

        public void ApplyMeatQuality()
        {
            MirItem StdItem;
            TUserItem UserItem;
            for (int i = 0; i < m_ItemList.Count; i++)
            {
                UserItem = m_ItemList[i];
                StdItem = M2Share.UserEngine.GetStdItem(UserItem.wIndex);
                if (StdItem != null)
                {
                    if (StdItem.StdMode == 40)
                    {
                        UserItem.Dura = m_nMeatQuality;
                    }
                }
            }
        }

        public bool TakeBagItems(TBaseObject BaseObject)
        {
            bool result = false;
            TUserItem UserItem;
            TPlayObject PlayObject;
            while (true)
            {
                if (BaseObject.m_ItemList.Count <= 0)
                {
                    break;
                }
                UserItem = BaseObject.m_ItemList[0];
                if (!AddItemToBag(UserItem))
                {
                    break;
                }
                if (this is TPlayObject)
                {
                    PlayObject = this as TPlayObject;
                    PlayObject.SendAddItem(UserItem);
                    result = true;
                }
                BaseObject.m_ItemList.RemoveAt(0);
            }
            return result;
        }

        public void ScatterGolds(TBaseObject GoldOfCreat)
        {
            int I;
            int nGold;
            if (m_nGold > 0)
            {
                I = 0;
                while (true)
                {
                    if (m_nGold > M2Share.g_Config.nMonOneDropGoldCount)
                    {
                        nGold = M2Share.g_Config.nMonOneDropGoldCount;
                        m_nGold = m_nGold - M2Share.g_Config.nMonOneDropGoldCount;
                    }
                    else
                    {
                        nGold = m_nGold;
                        m_nGold = 0;
                    }
                    if (nGold > 0)
                    {
                        if (!DropGoldDown(nGold, true, GoldOfCreat, this))
                        {
                            m_nGold = m_nGold + nGold;
                            break;
                        }
                    }
                    else
                    {
                        break;
                    }
                    I++;
                    if (I >= 17)
                    {
                        break;
                    }
                }
                GoldChanged();
            }
        }

        public void SetLastHiter(TBaseObject BaseObject)
        {
            m_LastHiter = BaseObject;
            m_LastHiterTick = HUtil32.GetTickCount();
            if (m_ExpHitter == null)
            {
                m_ExpHitter = BaseObject;
                m_ExpHitterTick = HUtil32.GetTickCount();
            }
            else
            {
                if (m_ExpHitter == BaseObject)
                {
                    m_ExpHitterTick = HUtil32.GetTickCount();
                }
            }
        }

        public void SetPKFlag(TBaseObject BaseObject)
        {
            if ((PKLevel() < 2) && (BaseObject.PKLevel() < 2) && (!m_PEnvir.Flag.boFightZone) && (!m_PEnvir.Flag.boFight3Zone) && !m_boPKFlag)
            {
                BaseObject.m_dwPKTick = HUtil32.GetTickCount();
                if (!BaseObject.m_boPKFlag)
                {
                    BaseObject.m_boPKFlag = true;
                    BaseObject.RefNameColor();
                }
            }
        }

        public bool IsGoodKilling(TBaseObject cert)
        {
            bool result = false;
            if (cert.m_boPKFlag)
            {
                result = true;
            }
            return result;
        }

        public bool IsAttackTarget_sub_4C88E4()
        {
            return true;
        }

        public virtual bool IsAttackTarget(TBaseObject BaseObject)
        {
            bool result = false;
            int I;
            if ((BaseObject == null) || (BaseObject == this))
            {
                return result;
            }
            if (m_btRaceServer >= Grobal2.RC_ANIMAL)
            {
                if (m_Master != null)
                {
                    if ((m_Master.m_LastHiter == BaseObject) || (m_Master.m_ExpHitter == BaseObject) || (m_Master.m_TargetCret == BaseObject))
                    {
                        result = true;
                    }
                    if (BaseObject.m_TargetCret != null)
                    {
                        if ((BaseObject.m_TargetCret == m_Master) || (BaseObject.m_TargetCret.m_Master == m_Master) && (BaseObject.m_btRaceServer != Grobal2.RC_PLAYOBJECT))
                        {
                            result = true;
                        }
                    }
                    if ((BaseObject.m_TargetCret == this) && (BaseObject.m_btRaceServer >= Grobal2.RC_ANIMAL))
                    {
                        result = true;
                    }
                    if (BaseObject.m_Master != null)
                    {
                        if ((BaseObject.m_Master == m_Master.m_LastHiter) || (BaseObject.m_Master == m_Master.m_TargetCret))
                        {
                            result = true;
                        }
                    }
                    if (BaseObject.m_Master == m_Master)
                    {
                        result = false;
                    }
                    if (BaseObject.m_boHolySeize)
                    {
                        result = false;
                    }
                    if (m_Master.m_boSlaveRelax)
                    {
                        result = false;
                    }
                    if (BaseObject.m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                    {
                        if (BaseObject.InSafeZone())
                        {
                            result = false;
                        }
                    }
                    BreakCrazyMode();
                }
                else
                {
                    if (BaseObject.m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                    {
                        result = true;
                    }
                    // 15
                    // 50
                    if ((m_btRaceServer > Grobal2.RC_PEACENPC) && (m_btRaceServer < Grobal2.RC_ANIMAL))
                    {
                        result = true;
                    }
                    if (BaseObject.m_Master != null)
                    {
                        result = true;
                    }
                }
                if (m_boCrazyMode && ((BaseObject.m_btRaceServer == Grobal2.RC_PLAYOBJECT) || (BaseObject.m_btRaceServer > Grobal2.RC_PEACENPC)))
                {
                    result = true;
                }
                if (m_boNastyMode && ((BaseObject.m_btRaceServer < Grobal2.RC_NPC) || (BaseObject.m_btRaceServer > Grobal2.RC_PEACENPC)))
                {
                    result = true;
                }
            }
            else
            {
                if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                {
                    switch (m_btAttatckMode)
                    {
                        case M2Share.HAM_ALL:
                            if ((BaseObject.m_btRaceServer < Grobal2.RC_NPC) || (BaseObject.m_btRaceServer > Grobal2.RC_PEACENPC))
                            {
                                result = true;
                            }
                            if (M2Share.g_Config.boNonPKServer)
                            {
                                result = IsAttackTarget_sub_4C88E4();
                            }
                            break;
                        case M2Share.HAM_PEACE:
                            // 1
                            if (BaseObject.m_btRaceServer >= Grobal2.RC_ANIMAL)
                            {
                                result = true;
                            }
                            break;
                        case M2Share.HAM_DEAR:
                            if (BaseObject != (this as TPlayObject).m_DearHuman)
                            {
                                result = true;
                            }
                            break;
                        case M2Share.HAM_MASTER:
                            if (BaseObject.m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                            {
                                result = true;
                                if ((this as TPlayObject).m_boMaster)
                                {
                                    for (I = 0; I < (this as TPlayObject).m_MasterList.Count; I++)
                                    {
                                        if ((this as TPlayObject).m_MasterList[I] == BaseObject)
                                        {
                                            result = false;
                                            break;
                                        }
                                    }
                                }
                                if ((BaseObject as TPlayObject).m_boMaster)
                                {
                                    for (I = 0; I < (BaseObject as TPlayObject).m_MasterList.Count; I++)
                                    {
                                        if ((BaseObject as TPlayObject).m_MasterList[I] == this)
                                        {
                                            result = false;
                                            break;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                result = true;
                            }
                            break;
                        case M2Share.HAM_GROUP:
                            // 2
                            if ((BaseObject.m_btRaceServer < Grobal2.RC_NPC) || (BaseObject.m_btRaceServer > Grobal2.RC_PEACENPC))
                            {
                                result = true;
                            }
                            if (BaseObject.m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                            {
                                if (IsGroupMember(BaseObject))
                                {
                                    result = false;
                                }
                            }
                            if (M2Share.g_Config.boNonPKServer)
                            {
                                result = IsAttackTarget_sub_4C88E4();
                            }
                            break;
                        case M2Share.HAM_GUILD:
                            // 3
                            if ((BaseObject.m_btRaceServer < Grobal2.RC_NPC) || (BaseObject.m_btRaceServer > Grobal2.RC_PEACENPC))
                            {
                                result = true;
                            }
                            if (BaseObject.m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                            {
                                if (m_MyGuild != null)
                                {
                                    if (m_MyGuild.IsMember(BaseObject.m_sCharName))
                                    {
                                        result = false;
                                    }
                                    if (m_boGuildWarArea && (BaseObject.m_MyGuild != null))
                                    {
                                        if (m_MyGuild.IsAllyGuild(BaseObject.m_MyGuild))
                                        {
                                            result = false;
                                        }
                                    }
                                }
                            }
                            if (M2Share.g_Config.boNonPKServer)
                            {
                                result = IsAttackTarget_sub_4C88E4();
                            }
                            break;
                        case M2Share.HAM_PKATTACK:
                            // 4
                            if ((BaseObject.m_btRaceServer < Grobal2.RC_NPC) || (BaseObject.m_btRaceServer > Grobal2.RC_PEACENPC))
                            {
                                result = true;
                            }
                            if (BaseObject.m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                            {
                                if (PKLevel() >= 2)
                                {
                                    if (BaseObject.PKLevel() < 2)
                                    {
                                        result = true;
                                    }
                                    else
                                    {
                                        result = false;
                                    }
                                }
                                else
                                {
                                    if (BaseObject.PKLevel() >= 2)
                                    {
                                        result = true;
                                    }
                                    else
                                    {
                                        result = false;
                                    }
                                }
                            }
                            if (M2Share.g_Config.boNonPKServer)
                            {
                                result = IsAttackTarget_sub_4C88E4();
                            }
                            break;
                    }
                }
                else
                {
                    result = true;
                }
            }
            if (BaseObject.m_boAdminMode || BaseObject.m_boStoneMode)
            {
                result = false;
            }
            return result;
        }

        public virtual bool IsProperTarget(TBaseObject BaseObject)
        {
            bool result = IsAttackTarget(BaseObject);
            if (result)
            {
                if ((m_btRaceServer == Grobal2.RC_PLAYOBJECT) && (BaseObject.m_btRaceServer == Grobal2.RC_PLAYOBJECT))
                {
                    result = IsProtectTarget(BaseObject);
                }
            }
            if ((BaseObject != null) && (m_btRaceServer == Grobal2.RC_PLAYOBJECT) && (BaseObject.m_Master != null) && (BaseObject.m_btRaceServer != Grobal2.RC_PLAYOBJECT))
            {
                if (BaseObject.m_Master == this)
                {
                    if (m_btAttatckMode != M2Share.HAM_ALL)
                    {
                        result = false;
                    }
                }
                else
                {
                    result = IsAttackTarget(BaseObject.m_Master);
                    if (InSafeZone() || BaseObject.InSafeZone())
                    {
                        result = false;
                    }
                }
            }
            return result;
        }

        protected void WeightChanged()
        {
            m_WAbil.Weight = RecalcBagWeight();
            SendUpdateMsg(this, Grobal2.RM_WEIGHTCHANGED, 0, 0, 0, 0, "");
        }

        public bool InSafeZone()
        {
            bool result;
            int nSafeX;
            int nSafeY;
            if (m_PEnvir == null)// 修正机器人刷火墙的错误
            {
                result = true;
                return result;
            }
            result = m_PEnvir.Flag.boSAFE;
            if (result)
            {
                return result;
            }
            if ((m_PEnvir.sMapName != M2Share.g_Config.sRedHomeMap) || (Math.Abs(m_nCurrX - M2Share.g_Config.nRedHomeX) > M2Share.g_Config.nSafeZoneSize) || (Math.Abs(m_nCurrY - M2Share.g_Config.nRedHomeY) > M2Share.g_Config.nSafeZoneSize))
            {
                result = false;
            }
            else
            {
                result = true;
            }
            if (result)
            {
                return result;
            }
            for (int i = 0; i < M2Share.StartPointList.Count; i++)
            {
                if (M2Share.StartPointList[i].m_sMapName == m_PEnvir.sMapName)
                {
                    if (M2Share.StartPointList[i] != null)
                    {
                        nSafeX = M2Share.StartPointList[i].m_nCurrX;
                        nSafeY = M2Share.StartPointList[i].m_nCurrY;
                        if ((Math.Abs(m_nCurrX - nSafeX) <= M2Share.g_Config.nSafeZoneSize) && (Math.Abs(m_nCurrY - nSafeY) <= M2Share.g_Config.nSafeZoneSize))
                        {
                            result = true;
                        }
                    }
                }
            }
            return result;
        }

        public bool InSafeZone(TEnvirnoment Envir, int nX, int nY)
        {
            int nSafeX;
            int nSafeY;
            if (m_PEnvir == null)  // 修正机器人刷火墙的错误
            {
                return true;
            }
            bool result = m_PEnvir.Flag.boSAFE;
            if (result)
            {
                return true;
            }
            if ((Envir.sMapName != M2Share.g_Config.sRedHomeMap) || (Math.Abs(nX - M2Share.g_Config.nRedHomeX) > M2Share.g_Config.nSafeZoneSize) || (Math.Abs(nY - M2Share.g_Config.nRedHomeY) > M2Share.g_Config.nSafeZoneSize))
            {
                result = false;
            }
            else
            {
                return true;
            }
            for (int i = 0; i < M2Share.StartPointList.Count; i++)
            {
                if (M2Share.StartPointList[i].m_sMapName == Envir.sMapName)
                {
                    if (M2Share.StartPointList[i] != null)
                    {
                        nSafeX = M2Share.StartPointList[i].m_nCurrX;
                        nSafeY = M2Share.StartPointList[i].m_nCurrY;
                        if ((Math.Abs(nX - nSafeX) <= M2Share.g_Config.nSafeZoneSize) && (Math.Abs(nY - nSafeY) <= M2Share.g_Config.nSafeZoneSize))
                        {
                            result = true;
                        }
                    }
                }
            }
            return result;
        }

        public void OpenHolySeizeMode(int dwInterval)
        {
            m_boHolySeize = true;
            m_dwHolySeizeTick = HUtil32.GetTickCount();
            m_dwHolySeizeInterval = dwInterval;
            RefNameColor();
        }

        public void BreakHolySeizeMode()
        {
            m_boHolySeize = false;
            RefNameColor();
        }

        public void OpenCrazyMode(int nTime)
        {
            m_boCrazyMode = true;
            m_dwCrazyModeTick = HUtil32.GetTickCount();
            m_dwCrazyModeInterval = nTime * 1000;
            RefNameColor();
        }

        public void BreakCrazyMode()
        {
            if (m_boCrazyMode)
            {
                m_boCrazyMode = false;
                RefNameColor();
            }
        }

        private void LeaveGroup()
        {
            const string sExitGropMsg = "{0} 已经退出了本组.";
            SendGroupText(format(sExitGropMsg, m_sCharName));
            m_GroupOwner = null;
            SendMsg(this, Grobal2.RM_GROUPCANCEL, 0, 0, 0, 0, "");
        }

        protected TUserMagic GetMagicInfo(int nMagicID)
        {
            TUserMagic result = null;
            TUserMagic UserMagic;
            for (int i = 0; i < m_MagicList.Count; i++)
            {
                UserMagic = m_MagicList[i];
                if (UserMagic.MagicInfo.wMagicID == nMagicID)
                {
                    result = UserMagic;
                    break;
                }
            }
            return result;
        }

        public void TrainSkill(TUserMagic UserMagic, int nTranPoint)
        {
            if (m_boFastTrain)
            {
                nTranPoint = nTranPoint * 3;
            }
            UserMagic.nTranPoint += nTranPoint;
        }

        public bool CheckMagicLevelup(TUserMagic UserMagic)
        {
            bool result = false;
            int n10;
            if ((UserMagic.btLevel < 4) && (UserMagic.MagicInfo.btTrainLv >= UserMagic.btLevel))
            {
                n10 = UserMagic.btLevel;
            }
            else
            {
                n10 = 0;
            }
            if ((UserMagic.MagicInfo.btTrainLv > UserMagic.btLevel) && (UserMagic.MagicInfo.MaxTrain[n10] <= UserMagic.nTranPoint))
            {
                if (UserMagic.MagicInfo.btTrainLv > UserMagic.btLevel)
                {
                    UserMagic.nTranPoint -= UserMagic.MagicInfo.MaxTrain[n10];
                    UserMagic.btLevel++;
                    SendUpdateDelayMsg(this, Grobal2.RM_MAGIC_LVEXP, 0, UserMagic.MagicInfo.wMagicID, UserMagic.btLevel, UserMagic.nTranPoint, "", 800);
                    sub_4C713C(UserMagic);
                }
                else
                {
                    UserMagic.nTranPoint = UserMagic.MagicInfo.MaxTrain[n10];
                }
                result = true;
            }
            return result;
        }

        /// <summary>
        /// 召唤属下
        /// </summary>
        /// <param name="sSlaveName"></param>
        public void RecallSlave(string sSlaveName)
        {
            short nX = 0;
            short nY = 0;
            int nFlag = -1;
            GetFrontPosition(ref nX, ref nY);
            if (sSlaveName == M2Share.g_Config.sDragon)
            {
                nFlag = 1;
            }
            for (int i = m_SlaveList.Count - 1; i >= 0; i--)
            {
                if (nFlag == 1)
                {
                    if ((m_SlaveList[i].m_sCharName == M2Share.g_Config.sDragon) || (m_SlaveList[i].m_sCharName == M2Share.g_Config.sDragon1))
                    {
                        m_SlaveList[i].SpaceMove(m_PEnvir.sMapName, nX, nY, 1);
                        break;
                    }
                }
                else if (m_SlaveList[i].m_sCharName == sSlaveName)
                {
                    m_SlaveList[i].SpaceMove(m_PEnvir.sMapName, nX, nY, 1);
                    break;
                }
            }
        }

        // 攻击角色
        public bool _Attack_DirectAttack(TBaseObject BaseObject, int nSecPwr)
        {
            bool result = false;
            if ((m_btRaceServer == Grobal2.RC_PLAYOBJECT) || (BaseObject.m_btRaceServer == Grobal2.RC_PLAYOBJECT) || !(InSafeZone() && BaseObject.InSafeZone()))
            {
                if (IsProperTarget(BaseObject))
                {
                    if (M2Share.RandomNumber.Random(BaseObject.m_btSpeedPoint) < m_btHitPoint)
                    {
                        BaseObject.StruckDamage(nSecPwr);
                        BaseObject.SendDelayMsg(Grobal2.RM_STRUCK, Grobal2.RM_10101, (short)nSecPwr, BaseObject.m_WAbil.HP, BaseObject.m_WAbil.MaxHP, ObjectId, "", 500);
                        if (BaseObject.m_btRaceServer != Grobal2.RC_PLAYOBJECT)
                        {
                            BaseObject.SendMsg(BaseObject, Grobal2.RM_STRUCK, (short)nSecPwr, BaseObject.m_WAbil.HP, BaseObject.m_WAbil.MaxHP, ObjectId, "");
                        }
                        result = true;
                    }
                }
            }
            return result;
        }

        // 刺杀前面一个位置的攻击
        public bool _Attack_SwordLongAttack(int nSecPwr)
        {
            bool result = false;
            short nX = 0;
            short nY = 0;
            nSecPwr = HUtil32.Round(nSecPwr * M2Share.g_Config.nSwordLongPowerRate / 100);
            if (m_PEnvir.GetNextPosition(m_nCurrX, m_nCurrY, m_btDirection, 2, ref nX, ref nY))
            {
                TBaseObject BaseObject = (TBaseObject)m_PEnvir.GetMovingObject(nX, nY, true);
                if (BaseObject != null)
                {
                    if ((nSecPwr > 0) && IsProperTarget(BaseObject))
                    {
                        result = _Attack_DirectAttack(BaseObject, nSecPwr);
                        SetTargetCreat(BaseObject);
                    }
                    result = true;
                }
            }
            return result;
        }

        // 半月攻击
        public bool _Attack_SwordWideAttack(int nSecPwr)
        {
            bool result = false;
            int nC= 0;
            int n10= 0;
            short nX = 0;
            short nY = 0;
            TBaseObject BaseObject;
            while (true)
            {
                n10 = (m_btDirection + M2Share.g_Config.WideAttack[nC]) % 8;
                if (m_PEnvir.GetNextPosition(m_nCurrX, m_nCurrY, n10, 1, ref nX, ref nY))
                {
                    BaseObject = (TBaseObject)m_PEnvir.GetMovingObject(nX, nY, true);
                    if ((nSecPwr > 0) && (BaseObject != null) && IsProperTarget(BaseObject))
                    {
                        result = _Attack_DirectAttack(BaseObject, nSecPwr);
                        SetTargetCreat(BaseObject);
                    }
                }
                nC++;
                if (nC >= 3)
                {
                    break;
                }
            }
            return result;
        }

        public bool _Attack_CrsWideAttack(int nSecPwr)
        {
            bool result = false;
            int nC = 0;
            int n10 = 0;
            short nX = 0;
            short nY = 0;
            TBaseObject BaseObject;
            while (true)
            {
                n10 = (m_btDirection + M2Share.g_Config.CrsAttack[nC]) % 8;
                if (m_PEnvir.GetNextPosition(m_nCurrX, m_nCurrY, n10, 1, ref nX, ref nY))
                {
                    BaseObject = (TBaseObject)m_PEnvir.GetMovingObject(nX, nY, true);
                    if ((nSecPwr > 0) && (BaseObject != null) && IsProperTarget(BaseObject))
                    {
                        result = _Attack_DirectAttack(BaseObject, nSecPwr);
                        SetTargetCreat(BaseObject);
                    }
                }
                nC++;
                if (nC >= 7)
                {
                    break;
                }
            }
            return result;
        }

        public void _Attack_sub_4C1E5C_sub_4C1DC0(ref TBaseObject BaseObject, byte btDir, ref short nX, ref short nY, int nSecPwr)
        {
            if (m_PEnvir.GetNextPosition(m_nCurrX, m_nCurrY, btDir, 1, ref nX, ref nY))
            {
                BaseObject = (TBaseObject)m_PEnvir.GetMovingObject(nX, nY, true);
                if ((nSecPwr > 0) && (BaseObject != null))
                {
                    _Attack_DirectAttack(BaseObject, nSecPwr);
                }
            }
        }

        public void _Attack_sub_4C1E5C(int nSecPwr)
        {
            byte btDir = 0;
            short nX = 0;
            short nY = 0;
            TBaseObject BaseObject = null;
            btDir = m_btDirection;
            m_PEnvir.GetNextPosition(m_nCurrX, m_nCurrY, btDir, 1, ref nX, ref nY);
            _Attack_sub_4C1E5C_sub_4C1DC0(ref BaseObject, btDir, ref nX, ref nY, nSecPwr);
            btDir = M2Share.sub_4B2F80(m_btDirection, 2);
            _Attack_sub_4C1E5C_sub_4C1DC0(ref BaseObject, btDir, ref nX, ref nY, nSecPwr);
            btDir = M2Share.sub_4B2F80(m_btDirection, 6);
            _Attack_sub_4C1E5C_sub_4C1DC0(ref BaseObject, btDir, ref nX, ref nY, nSecPwr);
        }

        public bool _Attack(ref short wHitMode, TBaseObject AttackTarget)
        {
            int n20;
            bool result = false;
            try
            {
                bool bo21 = false;
                int nWeaponDamage = 0;
                int nPower = 0;
                int nSecPwr = 0;
                if (AttackTarget != null)
                {
                    nPower = GetAttackPower(HUtil32.LoWord(m_WAbil.DC), HUtil32.HiWord(m_WAbil.DC) - HUtil32.LoWord(m_WAbil.DC));
                    if ((wHitMode == 3) && m_boPowerHit)
                    {
                        m_boPowerHit = false;
                        nPower += m_nHitPlus;
                        bo21 = true;
                    }
                    if ((wHitMode == 7) && m_boFireHitSkill) // 烈火剑法
                    {
                        m_boFireHitSkill = false;
                        m_dwLatestFireHitTick = HUtil32.GetTickCount();// Jacky 禁止双烈火
                        nPower = nPower + HUtil32.Round(nPower / 100 * (m_nHitDouble * 10));
                        bo21 = true;
                    }
                    if ((wHitMode == 9) && m_boTwinHitSkill) // 烈火剑法
                    {
                        m_boTwinHitSkill = false;
                        m_dwLatestTwinHitTick = HUtil32.GetTickCount();// Jacky 禁止双烈火
                        nPower = nPower + HUtil32.Round(nPower / 100 * (m_nHitDouble * 10));
                        bo21 = true;
                    }
                }
                else
                {
                    nPower = GetAttackPower(HUtil32.LoWord(m_WAbil.DC), HUtil32.HiWord(m_WAbil.DC) - HUtil32.LoWord(m_WAbil.DC));
                    if ((wHitMode == 3) && m_boPowerHit)
                    {
                        m_boPowerHit = false;
                        nPower += m_nHitPlus;
                        bo21 = true;
                    }
                    // Jacky 防止砍空刀刀烈火
                    if ((wHitMode == 7) && m_boFireHitSkill)
                    {
                        m_boFireHitSkill = false;
                        m_dwLatestFireHitTick = HUtil32.GetTickCount();// Jacky 禁止双烈火
                    }
                    if ((wHitMode == 9) && m_boTwinHitSkill)
                    {
                        m_boTwinHitSkill = false;
                        m_dwLatestTwinHitTick = HUtil32.GetTickCount();// Jacky 禁止双烈火
                    }
                }
                if (wHitMode == 4)
                {
                    // 刺杀
                    nSecPwr = 0;
                    if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                    {
                        if (m_MagicErgumSkill != null)
                        {
                            nSecPwr = HUtil32.Round(nPower / (m_MagicErgumSkill.MagicInfo.btTrainLv + 2) * (m_MagicErgumSkill.btLevel + 2));
                        }
                    }
                    if (nSecPwr > 0)
                    {
                        if (!_Attack_SwordLongAttack(nSecPwr) && M2Share.g_Config.boLimitSwordLong)
                        {
                            wHitMode = 0;
                        }
                    }
                }
                if (wHitMode == 5)
                {
                    nSecPwr = 0;
                    if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                    {
                        if (m_MagicBanwolSkill != null)
                        {
                            nSecPwr = HUtil32.Round(nPower / (m_MagicBanwolSkill.MagicInfo.btTrainLv + 10) * (m_MagicBanwolSkill.btLevel + 2));
                        }
                    }
                    if (nSecPwr > 0)
                    {
                        _Attack_SwordWideAttack(nSecPwr);
                    }
                }
                if (wHitMode == 12)
                {
                    nSecPwr = 0;
                    if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                    {
                        if (m_MagicRedBanwolSkill != null)
                        {
                            nSecPwr = HUtil32.Round(nPower / (m_MagicRedBanwolSkill.MagicInfo.btTrainLv + 10) * (m_MagicRedBanwolSkill.btLevel + 2));
                        }
                    }
                    if (nSecPwr > 0)
                    {
                        _Attack_SwordWideAttack(nSecPwr);
                    }
                }

                if (wHitMode == 6)
                {
                    nSecPwr = 0;
                    if (nSecPwr > 0)
                    {
                        _Attack_sub_4C1E5C(nSecPwr);
                    }
                }
                if (wHitMode == 8)
                {
                    nSecPwr = 0;
                    if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                    {
                        if (m_MagicCrsSkill != null)
                        {
                            nSecPwr = HUtil32.Round(nPower / (m_MagicCrsSkill.MagicInfo.btTrainLv + 10) * (m_MagicCrsSkill.btLevel + 2));
                        }
                    }
                    if (nSecPwr > 0)
                    {
                        _Attack_CrsWideAttack(nSecPwr);
                    }
                }
                if (AttackTarget == null)
                {
                    return result;
                }
                if (IsProperTarget(AttackTarget))
                {
                    if (AttackTarget.m_btHitPoint > 0)
                    {
                        if (m_btHitPoint < M2Share.RandomNumber.Random(AttackTarget.m_btSpeedPoint))
                        {
                            nPower = 0;
                        }
                    }
                }
                else
                {
                    nPower = 0;
                }
                if (nPower > 0)
                {
                    nPower = AttackTarget.GetHitStruckDamage(this, nPower);
                    nWeaponDamage = M2Share.RandomNumber.Random(5) + 2 - m_AddAbil.btWeaponStrong;
                }
                if (nPower > 0)
                {
                    AttackTarget.StruckDamage(nPower);
                    AttackTarget.SendDelayMsg(Grobal2.RM_STRUCK, Grobal2.RM_10101, nPower, AttackTarget.m_WAbil.HP, AttackTarget.m_WAbil.MaxHP, ObjectId, "", 200);
                    if (!AttackTarget.m_boUnParalysis && m_boParalysis && (M2Share.RandomNumber.Random(AttackTarget.m_btAntiPoison + M2Share.g_Config.nAttackPosionRate) == 0))
                    {
                        AttackTarget.MakePosion(Grobal2.POISON_STONE, M2Share.g_Config.nAttackPosionTime, 0);
                    }
                    // 虹魔，吸血
                    if (m_nHongMoSuite > 0)
                    {
                        m_db3B0 = nPower / 100 * m_nHongMoSuite;
                        if (m_db3B0 >= 2.0)
                        {
                            n20 = Convert.ToInt32(m_db3B0);
                            m_db3B0 = n20;
                            DamageHealth(-n20);
                        }
                    }
                    if ((m_MagicOneSwordSkill != null) && (m_btRaceServer == Grobal2.RC_PLAYOBJECT) && (m_MagicOneSwordSkill.btLevel < 3) && (m_MagicOneSwordSkill.MagicInfo.TrainLevel[m_MagicOneSwordSkill.btLevel] <= m_Abil.Level))
                    {
                        (this as TPlayObject).TrainSkill(m_MagicOneSwordSkill, M2Share.RandomNumber.Random(3) + 1);
                        if (!(this as TPlayObject).CheckMagicLevelup(m_MagicOneSwordSkill))
                        {
                            SendDelayMsg(this, Grobal2.RM_MAGIC_LVEXP, 0, m_MagicOneSwordSkill.MagicInfo.wMagicID, m_MagicOneSwordSkill.btLevel, m_MagicOneSwordSkill.nTranPoint, "", 3000);
                        }
                    }
                    if (bo21 && (m_MagicPowerHitSkill != null) && (m_btRaceServer == Grobal2.RC_PLAYOBJECT) && (m_MagicPowerHitSkill.btLevel < 3) && (m_MagicPowerHitSkill.MagicInfo.TrainLevel[m_MagicPowerHitSkill.btLevel] <= m_Abil.Level))
                    {
                        (this as TPlayObject).TrainSkill(m_MagicPowerHitSkill, M2Share.RandomNumber.Random(3) + 1);
                        if (!(this as TPlayObject).CheckMagicLevelup(m_MagicPowerHitSkill))
                        {
                            SendDelayMsg(this, Grobal2.RM_MAGIC_LVEXP, 0, m_MagicPowerHitSkill.MagicInfo.wMagicID, m_MagicPowerHitSkill.btLevel, m_MagicPowerHitSkill.nTranPoint, "", 3000);
                        }
                    }
                    if ((wHitMode == 4) && (m_MagicErgumSkill != null) && (m_btRaceServer == Grobal2.RC_PLAYOBJECT) && (m_MagicErgumSkill.btLevel < 3) && (m_MagicErgumSkill.MagicInfo.TrainLevel[m_MagicErgumSkill.btLevel] <= m_Abil.Level))
                    {
                        (this as TPlayObject).TrainSkill(m_MagicErgumSkill, 1);
                        if (!(this as TPlayObject).CheckMagicLevelup(m_MagicErgumSkill))
                        {
                            SendDelayMsg(this, Grobal2.RM_MAGIC_LVEXP, 0, m_MagicErgumSkill.MagicInfo.wMagicID, m_MagicErgumSkill.btLevel, m_MagicErgumSkill.nTranPoint, "", 3000);
                        }
                    }
                    if ((wHitMode == 5) && (m_MagicBanwolSkill != null) && (m_btRaceServer == Grobal2.RC_PLAYOBJECT) && (m_MagicBanwolSkill.btLevel < 3) && (m_MagicBanwolSkill.MagicInfo.TrainLevel[m_MagicBanwolSkill.btLevel] <= m_Abil.Level))
                    {
                        (this as TPlayObject).TrainSkill(m_MagicBanwolSkill, 1);
                        if (!(this as TPlayObject).CheckMagicLevelup(m_MagicBanwolSkill))
                        {
                            SendDelayMsg(this, Grobal2.RM_MAGIC_LVEXP, 0, m_MagicBanwolSkill.MagicInfo.wMagicID, m_MagicBanwolSkill.btLevel, m_MagicBanwolSkill.nTranPoint, "", 3000);
                        }
                    }
                    if ((wHitMode == 12) && (m_MagicRedBanwolSkill != null) && (m_btRaceServer == Grobal2.RC_PLAYOBJECT) && (m_MagicRedBanwolSkill.btLevel < 3) && (m_MagicRedBanwolSkill.MagicInfo.TrainLevel[m_MagicRedBanwolSkill.btLevel] <= m_Abil.Level))
                    {
                        (this as TPlayObject).TrainSkill(m_MagicRedBanwolSkill, 1);
                        if (!(this as TPlayObject).CheckMagicLevelup(m_MagicRedBanwolSkill))
                        {
                            SendDelayMsg(this, Grobal2.RM_MAGIC_LVEXP, 0, m_MagicRedBanwolSkill.MagicInfo.wMagicID, m_MagicRedBanwolSkill.btLevel, m_MagicRedBanwolSkill.nTranPoint, "", 3000);
                        }
                    }
                    if ((wHitMode == 7) && (m_MagicFireSwordSkill != null) && (m_btRaceServer == Grobal2.RC_PLAYOBJECT) && (m_MagicFireSwordSkill.btLevel < 3) && (m_MagicFireSwordSkill.MagicInfo.TrainLevel[m_MagicFireSwordSkill.btLevel] <= m_Abil.Level))
                    {
                        (this as TPlayObject).TrainSkill(m_MagicFireSwordSkill, 1);
                        if (!(this as TPlayObject).CheckMagicLevelup(m_MagicFireSwordSkill))
                        {
                            SendDelayMsg(this, Grobal2.RM_MAGIC_LVEXP, 0, m_MagicFireSwordSkill.MagicInfo.wMagicID, m_MagicFireSwordSkill.btLevel, m_MagicFireSwordSkill.nTranPoint, "", 3000);
                        }
                    }
                    if ((wHitMode == 8) && (m_MagicCrsSkill != null) && (m_btRaceServer == Grobal2.RC_PLAYOBJECT) && (m_MagicCrsSkill.btLevel < 3) && (m_MagicCrsSkill.MagicInfo.TrainLevel[m_MagicCrsSkill.btLevel] <= m_Abil.Level))
                    {
                        (this as TPlayObject).TrainSkill(m_MagicCrsSkill, 1);
                        if (!(this as TPlayObject).CheckMagicLevelup(m_MagicCrsSkill))
                        {
                            SendDelayMsg(this, Grobal2.RM_MAGIC_LVEXP, 0, m_MagicCrsSkill.MagicInfo.wMagicID, m_MagicCrsSkill.btLevel, m_MagicCrsSkill.nTranPoint, "", 3000);
                        }
                    }
                    if ((wHitMode == 9) && (m_MagicTwnHitSkill != null) && (m_btRaceServer == Grobal2.RC_PLAYOBJECT) && (m_MagicTwnHitSkill.btLevel < 3) && (m_MagicTwnHitSkill.MagicInfo.TrainLevel[m_MagicTwnHitSkill.btLevel] <= m_Abil.Level))
                    {
                        (this as TPlayObject).TrainSkill(m_MagicTwnHitSkill, 1);
                        if (!(this as TPlayObject).CheckMagicLevelup(m_MagicTwnHitSkill))
                        {
                            SendDelayMsg(this, Grobal2.RM_MAGIC_LVEXP, 0, m_MagicTwnHitSkill.MagicInfo.wMagicID, m_MagicTwnHitSkill.btLevel, m_MagicTwnHitSkill.nTranPoint, "", 3000);
                        }
                    }
                    result = true;
                    if (M2Share.g_Config.boMonDelHptoExp)
                    {
                        if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                        {
                            if ((this as TPlayObject).m_WAbil.Level <= M2Share.g_Config.MonHptoExpLevel)
                            {
                                if (!M2Share.GetNoHptoexpMonList(AttackTarget.m_sCharName))
                                {
                                    (this as TPlayObject).GainExp(nPower * M2Share.g_Config.MonHptoExpmax);
                                }
                            }
                        }
                        if (m_btRaceServer == Grobal2.RC_PLAYCLONE)
                        {
                            if (m_Master != null)
                            {
                                if ((m_Master as TPlayObject).m_WAbil.Level <= M2Share.g_Config.MonHptoExpLevel)
                                {
                                    if (!M2Share.GetNoHptoexpMonList(AttackTarget.m_sCharName))
                                    {
                                        (m_Master as TPlayObject).GainExp(nPower * M2Share.g_Config.MonHptoExpmax);
                                    }
                                }
                            }
                        }
                    }
                }

                if ((nWeaponDamage > 0) && (m_UseItems[Grobal2.U_WEAPON] != null) && (m_UseItems[Grobal2.U_WEAPON].wIndex > 0))
                {
                    DoDamageWeapon(nWeaponDamage);
                }
                if (AttackTarget.m_btRaceServer != Grobal2.RC_PLAYOBJECT)
                {
                    AttackTarget.SendMsg(AttackTarget, Grobal2.RM_STRUCK, (short)nPower, AttackTarget.m_WAbil.HP, AttackTarget.m_WAbil.MaxHP, ObjectId, "");
                }
            }
            catch (Exception e)
            {
                M2Share.ErrorMessage(e.Message);
            }
            return result;
        }

        protected void SendAttackMsg(short wIdent, byte btDir, int nX, int nY)
        {
            SendRefMsg(wIdent, btDir, nX, nY, 0, "");
        }

        public ushort GetHitStruckDamage(TBaseObject Target, int nDamage)
        {
            int result;
            int nArmor;
            var nRnd = HUtil32.HiWord(m_WAbil.AC) - HUtil32.LoWord(m_WAbil.AC) + 1;
            if (nRnd > 0)
            {
                nArmor = HUtil32.LoWord(m_WAbil.AC) + M2Share.RandomNumber.Random(nRnd);
            }
            else
            {
                nArmor = HUtil32.LoWord(m_WAbil.AC);
            }
            nDamage = HUtil32._MAX(0, nDamage - nArmor);
            if (nDamage > 0)
            {
                if ((m_btLifeAttrib == Grobal2.LA_UNDEAD) && (Target != null))
                {
                    nDamage += Target.m_AddAbil.btUndead;
                }
                if (m_boAbilMagBubbleDefence)
                {
                    nDamage = HUtil32.Round(nDamage / 1.0e2 * (m_btMagBubbleDefenceLevel + 2) * 8.0);
                    DamageBubbleDefence(nDamage);
                }
            }
            result = nDamage;
            return (ushort)result;
        }

        public int GetMagStruckDamage(TBaseObject BaseObject, int nDamage)
        {
            int n14 = HUtil32.LoWord(m_WAbil.MAC) + M2Share.RandomNumber.Random(HUtil32.HiWord(m_WAbil.MAC) - HUtil32.LoWord(m_WAbil.MAC) + 1);
            nDamage = HUtil32._MAX(0, nDamage - n14);
            if ((m_btLifeAttrib == Grobal2.LA_UNDEAD) && (BaseObject != null))
            {
                nDamage += m_AddAbil.btUndead;
            }
            if ((nDamage > 0) && m_boAbilMagBubbleDefence)
            {
                nDamage = HUtil32.Round(nDamage / 1.0e2 * (m_btMagBubbleDefenceLevel + 2) * 8.0);
                DamageBubbleDefence(nDamage);
            }
            return nDamage;
        }

        public void StruckDamage(int nDamage)
        {
            int nDam;
            int nDura;
            int nOldDura;
            TPlayObject PlayObject;
            MirItem StdItem;
            bool bo19;
            if (nDamage <= 0)
            {
                return;
            }
            // 人攻击怪物
            if ((m_btRaceServer >= 50) && (m_LastHiter != null) && (m_LastHiter.m_btRaceServer == Grobal2.RC_PLAYOBJECT))
            {
                switch (m_LastHiter.m_btJob)
                {
                    case 0:
                        nDamage = nDamage * M2Share.g_Config.nWarrMon / 10;
                        break;
                    case 1:
                        nDamage = nDamage * M2Share.g_Config.nWizardMon / 10;
                        break;
                    case 2:
                        nDamage = nDamage * M2Share.g_Config.nTaosMon / 10;
                        break;
                }
            }
            // 怪物攻击人
            if ((m_btRaceServer == Grobal2.RC_PLAYOBJECT) && (m_LastHiter != null) && (m_LastHiter.m_Master != null))
            {
                nDamage = nDamage * M2Share.g_Config.nMonHum / 10;
            }
            nDam = M2Share.RandomNumber.Random(10) + 5;  // 1 0x62
            if (m_wStatusTimeArr[Grobal2.POISON_DAMAGEARMOR] > 0)
            {
                nDam = HUtil32.Round(nDam * (M2Share.g_Config.nPosionDamagarmor / 10));// 1.2
                nDamage = HUtil32.Round(nDamage * (M2Share.g_Config.nPosionDamagarmor / 10));// 1.2
            }
            bo19 = false;
            if (m_UseItems[Grobal2.U_DRESS] != null && m_UseItems[Grobal2.U_DRESS].wIndex > 0)
            {
                nDura = m_UseItems[Grobal2.U_DRESS].Dura;
                nOldDura = HUtil32.Round(nDura / 1000);
                nDura -= nDam;
                if (nDura <= 0)
                {
                    if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                    {
                        PlayObject = this as TPlayObject;
                        PlayObject.SendDelItems(m_UseItems[Grobal2.U_DRESS]);
                        StdItem = M2Share.UserEngine.GetStdItem(m_UseItems[Grobal2.U_DRESS].wIndex);
                        if (StdItem.NeedIdentify == 1)
                        {
                            // UserEngine.GetStdItemName(m_UseItems[U_DRESS].wIndex) + #9 +
                            M2Share.AddGameDataLog('3' + "\t" + m_sMapName + "\t" + m_nCurrX.ToString() + "\t" + m_nCurrY.ToString() + "\t" + m_sCharName + "\t" + StdItem.Name + "\t" + m_UseItems[Grobal2.U_DRESS].MakeIndex.ToString() + "\t" 
                                + HUtil32.BoolToIntStr(m_btRaceServer == Grobal2.RC_PLAYOBJECT) + "\t" + '0');
                        }
                        m_UseItems[Grobal2.U_DRESS].wIndex = 0;
                        FeatureChanged();
                    }
                    m_UseItems[Grobal2.U_DRESS].wIndex = 0;
                    m_UseItems[Grobal2.U_DRESS].Dura = 0;
                    bo19 = true;
                }
                else
                {
                    m_UseItems[Grobal2.U_DRESS].Dura = (ushort)nDura;
                }
                if (nOldDura != HUtil32.Round(nDura / 1000))
                {
                    SendMsg(this, Grobal2.RM_DURACHANGE, Grobal2.U_DRESS, nDura, m_UseItems[Grobal2.U_DRESS].DuraMax, 0, "");
                }
            }
            for (var i = m_UseItems.GetLowerBound(0); i <= m_UseItems.GetUpperBound(0); i++)
            {
                if ((m_UseItems[i] != null) && (m_UseItems[i].wIndex > 0) && (M2Share.RandomNumber.Random(8) == 0))
                {
                    nDura = m_UseItems[i].Dura;
                    nOldDura = HUtil32.Round(nDura / 1000);
                    nDura -= nDam;
                    if (nDura <= 0)
                    {
                        if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                        {
                            PlayObject = this as TPlayObject;
                            PlayObject.SendDelItems(m_UseItems[i]);
                            StdItem = M2Share.UserEngine.GetStdItem(m_UseItems[i].wIndex);
                            if (StdItem.NeedIdentify == 1)
                            {
                                M2Share.AddGameDataLog('3' + "\t" + m_sMapName + "\t" + m_nCurrX.ToString() + "\t" + m_nCurrY.ToString() + "\t" + m_sCharName + "\t" + StdItem.Name + "\t" + m_UseItems[i].MakeIndex.ToString() + "\t" 
                                    + HUtil32.BoolToIntStr(m_btRaceServer == Grobal2.RC_PLAYOBJECT) + "\t" + '0');
                            }
                            m_UseItems[i].wIndex = 0;
                            FeatureChanged();
                        }
                        m_UseItems[i].wIndex = 0;
                        m_UseItems[i].Dura = 0;
                        bo19 = true;
                    }
                    else
                    {
                        m_UseItems[i].Dura = (ushort)nDura;
                    }
                    if (nOldDura != HUtil32.Round(nDura / 1000))
                    {
                        SendMsg(this, Grobal2.RM_DURACHANGE, i, nDura, m_UseItems[i].DuraMax, 0, "");
                    }
                }
            }
            if (bo19)
            {
                RecalcAbilitys();
            }
            DamageHealth(nDamage);
        }

        public virtual string GeTBaseObjectInfo()
        {
            string result = m_sCharName + ' ' + "地图:" + m_sMapName + '(' + m_PEnvir.sMapDesc + ") " + "座标:" + m_nCurrX.ToString() + '/' + m_nCurrY.ToString() + ' ' + "等级:" + m_Abil.Level.ToString() + ' ' + "经验:" + m_Abil.Exp.ToString() + ' ' 
                + "生命值: " + m_WAbil.HP.ToString() + '-' + m_WAbil.MaxHP.ToString() + ' ' + "魔法值: " + m_WAbil.MP.ToString() + '-' + m_WAbil.MaxMP.ToString() + ' ' + "攻击力: " + HUtil32.LoWord(m_WAbil.DC).ToString() + '-' + HUtil32.HiWord(m_WAbil.DC).ToString() + ' ' 
                + "魔法力: " + HUtil32.LoWord(m_WAbil.MC).ToString() + '-' + HUtil32.HiWord(m_WAbil.MC).ToString() + ' ' + "道术: " + HUtil32.LoWord(m_WAbil.SC).ToString() + '-' + HUtil32.HiWord(m_WAbil.SC).ToString() + ' ' 
                + "防御力: " + HUtil32.LoWord(m_WAbil.AC).ToString() + '-' + HUtil32.HiWord(m_WAbil.AC).ToString() + ' ' + "魔防力: " + HUtil32.LoWord(m_WAbil.MAC).ToString() + '-' + HUtil32.HiWord(m_WAbil.MAC).ToString() + ' ' + "准确:" + m_btHitPoint.ToString() + ' '
                + "敏捷:" + m_btSpeedPoint.ToString();
            return result;
        }

        public bool GetBackPosition(ref short nX, ref short nY)
        {
            bool result;
            TEnvirnoment Envir;
            Envir = m_PEnvir;
            nX = m_nCurrX;
            nY = m_nCurrY;
            switch (m_btDirection)
            {
                case Grobal2.DR_UP:
                    if (nY < (Envir.wHeight - 1))
                    {
                        nY++;
                    }
                    break;
                case Grobal2.DR_DOWN:
                    if (nY > 0)
                    {
                        nY -= 1;
                    }
                    break;
                case Grobal2.DR_LEFT:
                    if (nX < (Envir.wWidth - 1))
                    {
                        nX++;
                    }
                    break;
                case Grobal2.DR_RIGHT:
                    if (nX > 0)
                    {
                        nX -= 1;
                    }
                    break;
                case Grobal2.DR_UPLEFT:
                    if ((nX < (Envir.wWidth - 1)) && (nY < (Envir.wHeight - 1)))
                    {
                        nX++;
                        nY++;
                    }
                    break;
                case Grobal2.DR_UPRIGHT:
                    if ((nX < (Envir.wWidth - 1)) && (nY > 0))
                    {
                        nX -= 1;
                        nY++;
                    }
                    break;
                case Grobal2.DR_DOWNLEFT:
                    if ((nX > 0) && (nY < (Envir.wHeight - 1)))
                    {
                        nX++;
                        nY -= 1;
                    }
                    break;
                case Grobal2.DR_DOWNRIGHT:
                    if ((nX > 0) && (nY > 0))
                    {
                        nX -= 1;
                        nY -= 1;
                    }
                    break;
            }
            result = true;
            return result;
        }

        public bool MakePosion(int nType, int nTime, int nPoint)
        {
            bool result = false;
            if (nType < Grobal2.MAX_STATUS_ATTRIBUTE)
            {
                var nOldCharStatus = m_nCharStatus;
                if (m_wStatusTimeArr[nType] > 0)
                {
                    if (m_wStatusTimeArr[nType] < nTime)
                    {
                        m_wStatusTimeArr[nType] = (ushort)nTime;
                    }
                }
                else
                {
                    m_wStatusTimeArr[nType] = (ushort)nTime;
                }
                m_dwStatusArrTick[nType] = HUtil32.GetTickCount();
                m_nCharStatus = GetCharStatus();
                m_btGreenPoisoningPoint = (byte)nPoint;
                if (nOldCharStatus != m_nCharStatus)
                {
                    StatusChanged();
                }
                if (m_btRaceServer == Grobal2.RC_PLAYOBJECT)
                {
                    SysMsg(format(M2Share.sYouPoisoned, nTime, nPoint), TMsgColor.c_Red, TMsgType.t_Hint);
                }
                result = true;
            }
            return result;
        }

        public bool sub_4DD704()
        {
            bool result = false;
            SendMessage SendMessage;
            HUtil32.EnterCriticalSection(M2Share.ProcessMsgCriticalSection);
            try
            {
                for (var i = 0; i < m_MsgList.Count; i++)
                {
                    SendMessage = m_MsgList[i];
                    if (SendMessage.wIdent == Grobal2.RM_10401)
                    {
                        result = true;
                        break;
                    }
                }
            }
            finally
            {
                HUtil32.LeaveCriticalSection(M2Share.ProcessMsgCriticalSection);
            }
            return result;
        }

        protected bool sub_4C5370(short nX, short nY, int nRange, ref short nDX, ref short nDY)
        {
            bool result = false;
            if (m_PEnvir.GetMovingObject(nX, nY, true) == null)
            {
                result = true;
                nDX = nX;
                nDY = nY;
            }
            if (!result)
            {
                for (int i = 0; i <= nRange; i++)
                {
                    for (int j = -i; j <= i; j++)
                    {
                        for (int k = -i; k <= i; k++)
                        {
                            nDX = (short)(nX + k);
                            nDY = (short)(nY + j);
                            if (m_PEnvir.GetMovingObject(nDX, nDY, true) == null)
                            {
                                result = true;
                                break;
                            }
                        }
                        if (result)
                        {
                            break;
                        }
                    }
                    if (result)
                    {
                        break;
                    }
                }
            }
            if (!result)
            {
                nDX = nX;
                nDY = nY;
            }
            return result;
        }

        public bool IsTrainingSkill(int nIndex)
        {
            bool result = false;
            TUserMagic UserMagic;
            for (int i = 0; i < m_MagicList.Count; i++)
            {
                UserMagic = m_MagicList[i];
                if ((UserMagic != null) && (UserMagic.wMagIdx == nIndex))
                {
                    result = true;
                    break;
                }
            }
            return result;
        }

        private void DamageBubbleDefence(int nInt)
        {
            if (m_wStatusTimeArr[Grobal2.STATE_BUBBLEDEFENCEUP] > 0)
            {
                if (m_wStatusTimeArr[Grobal2.STATE_BUBBLEDEFENCEUP] > 3)
                {
                    m_wStatusTimeArr[Grobal2.STATE_BUBBLEDEFENCEUP] -= 3;
                }
                else
                {
                    m_wStatusTimeArr[Grobal2.STATE_BUBBLEDEFENCEUP] = 1;
                }
            }
        }

        public bool IsGuildMaster()
        {
            bool result = false;
            if ((m_MyGuild != null) && (m_nGuildRankNo == 1))
            {
                result = true;
            }
            return result;
        }

        public bool MagCanHitTarget(short nX, short nY, TBaseObject TargeTBaseObject)
        {
            bool result = false;
            int n18;
            if (TargeTBaseObject == null)
            {
                return result;
            }
            int n20 = Math.Abs(nX - TargeTBaseObject.m_nCurrX) + Math.Abs(nY - TargeTBaseObject.m_nCurrY);
            int n14 = 0;
            while (n14 < 13)
            {
                n18 = M2Share.GetNextDirection(nX, nY, TargeTBaseObject.m_nCurrX, TargeTBaseObject.m_nCurrY);
                if (m_PEnvir.GetNextPosition(nX, nY, n18, 1, ref nX, ref nY) && m_PEnvir.IsValidCell(nX, nY))
                {
                    if ((nX == TargeTBaseObject.m_nCurrX) && (nY == TargeTBaseObject.m_nCurrY))
                    {
                        result = true;
                        break;
                    }
                    else
                    {
                        int n1C = Math.Abs(nX - TargeTBaseObject.m_nCurrX) + Math.Abs(nY - TargeTBaseObject.m_nCurrY);
                        if (n1C > n20)
                        {
                            result = true;
                            break;
                        }
                        n1C = n20;
                    }
                }
                else
                {
                    break;
                }
                n14++;
            }
            return result;
        }

        private bool IsProperFriend_IsFriend(TBaseObject cret)
        {
            bool result = false;
            if (cret.m_btRaceServer == Grobal2.RC_PLAYOBJECT)
            {
                switch (m_btAttatckMode)
                {
                    case M2Share.HAM_ALL:
                        result = true;
                        break;
                    case M2Share.HAM_PEACE:
                        result = true;
                        break;
                    case M2Share.HAM_DEAR:
                        if ((this == cret) || (cret == (this as TPlayObject).m_DearHuman))
                        {
                            result = true;
                        }
                        break;
                    case M2Share.HAM_MASTER:
                        if (this == cret)
                        {
                            result = true;
                        }
                        else if ((this as TPlayObject).m_boMaster)
                        {
                            for (int i = 0; i < (this as TPlayObject).m_MasterList.Count; i++)
                            {
                                if ((this as TPlayObject).m_MasterList[i] == cret)
                                {
                                    result = true;
                                    break;
                                }
                            }
                        }
                        else if ((cret as TPlayObject).m_boMaster)
                        {
                            for (int i = 0; i < (cret as TPlayObject).m_MasterList.Count; i++)
                            {
                                if ((cret as TPlayObject).m_MasterList[i] == this)
                                {
                                    result = true;
                                    break;
                                }
                            }
                        }
                        break;
                    case M2Share.HAM_GROUP:
                        if (cret == this)
                        {
                            result = true;
                        }
                        if (IsGroupMember(cret))
                        {
                            result = true;
                        }
                        break;
                    case M2Share.HAM_GUILD:
                        if (cret == this)
                        {
                            result = true;
                        }
                        if (m_MyGuild != null)
                        {
                            if (m_MyGuild.IsMember(cret.m_sCharName))
                            {
                                result = true;
                            }
                            if (m_boGuildWarArea && (cret.m_MyGuild != null))
                            {
                                if (m_MyGuild.IsAllyGuild(cret.m_MyGuild))
                                {
                                    result = true;
                                }
                            }
                        }
                        break;
                    case M2Share.HAM_PKATTACK:
                        if (cret == this)
                        {
                            result = true;
                        }
                        if (PKLevel() >= 2)
                        {
                            if (cret.PKLevel() < 2)
                            {
                                result = true;
                            }
                        }
                        else
                        {
                            if (cret.PKLevel() >= 2)
                            {
                                result = true;
                            }
                        }
                        break;
                }
            }
            return result;
        }

        public int MagMakeDefenceArea(int nX, int nY, int nRange, ushort nSec, byte btState)
        {
            TMapCellinfo MapCellInfo = null;
            TOSObject OSObject;
            TBaseObject BaseObject;
            int result = 0;
            int nStartX = nX - nRange;
            int nEndX = nX + nRange;
            int nStartY = nY - nRange;
            int nEndY = nY + nRange;
            for (int i = nStartX; i <= nEndX; i++)
            {
                for (int j = nStartY; j <= nEndY; j++)
                {
                    if (m_PEnvir.GetMapCellInfo(i, j, ref MapCellInfo) && (MapCellInfo.ObjList != null))
                    {
                        for (int k = 0; k < MapCellInfo.ObjList.Count; k++)
                        {
                            OSObject = MapCellInfo.ObjList[k];
                            if ((OSObject != null) && (OSObject.btType == Grobal2.OS_MOVINGOBJECT))
                            {
                                BaseObject = OSObject.CellObj as TBaseObject;
                                if ((BaseObject != null) && (!BaseObject.m_boGhost))
                                {
                                    if (IsProperFriend(BaseObject))
                                    {
                                        if (btState == 0)
                                        {
                                            BaseObject.DefenceUp(nSec);
                                        }
                                        else
                                        {
                                            BaseObject.MagDefenceUp(nSec);
                                        }
                                        result++;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return result;
        }

        private bool DefenceUp(int nSec)
        {
            bool result = false;
            if (m_wStatusTimeArr[Grobal2.STATE_DEFENCEUP] > 0)
            {
                if (m_wStatusTimeArr[Grobal2.STATE_DEFENCEUP] < nSec)
                {
                    m_wStatusTimeArr[Grobal2.STATE_DEFENCEUP] = (ushort)nSec;
                    result = true;
                }
            }
            else
            {
                m_wStatusTimeArr[Grobal2.STATE_DEFENCEUP] = (ushort)nSec;
                result = true;
            }
            m_dwStatusArrTick[Grobal2.STATE_DEFENCEUP] = HUtil32.GetTickCount();
            SysMsg(format(M2Share.g_sDefenceUpTime, nSec), TMsgColor.c_Green, TMsgType.t_Hint);
            RecalcAbilitys();
            SendMsg(this, Grobal2.RM_ABILITY, 0, 0, 0, 0, "");
            return result;
        }

        public bool AttPowerUp(int nPower, int nTime)
        {
            m_wStatusArrValue[0] = (ushort)nPower;
            m_dwStatusArrTimeOutTick[0] = HUtil32.GetTickCount() + nTime * 1000;
            int nMin = nTime / 60;
            int nSec = nTime % 60;
            SysMsg(format(M2Share.g_sAttPowerUpTime, new object[] { nMin, nSec }), TMsgColor.c_Green, TMsgType.t_Hint);
            RecalcAbilitys();
            SendMsg(this, Grobal2.RM_ABILITY, 0, 0, 0, 0, "");
            return true;
        }

        private bool MagDefenceUp(ushort nSec)
        {
            bool result = false;
            if (m_wStatusTimeArr[Grobal2.STATE_MAGDEFENCEUP] > 0)
            {
                if (m_wStatusTimeArr[Grobal2.STATE_MAGDEFENCEUP] < nSec)
                {
                    m_wStatusTimeArr[Grobal2.STATE_MAGDEFENCEUP] = nSec;
                    result = true;
                }
            }
            else
            {
                m_wStatusTimeArr[Grobal2.STATE_MAGDEFENCEUP] = nSec;
                result = true;
            }
            m_dwStatusArrTick[Grobal2.STATE_MAGDEFENCEUP] = HUtil32.GetTickCount();
            SysMsg(format(M2Share.g_sMagDefenceUpTime, nSec), TMsgColor.c_Green, TMsgType.t_Hint);
            RecalcAbilitys();
            SendMsg(this, Grobal2.RM_ABILITY, 0, 0, 0, 0, "");
            return result;
        }

        /// <summary>
        /// 魔法盾
        /// </summary>
        /// <returns></returns>
        public bool MagBubbleDefenceUp(byte nLevel, ushort nSec)
        {
            long nOldStatus;
            if (m_wStatusTimeArr[Grobal2.STATE_BUBBLEDEFENCEUP] != 0)
            {
                return false;
            }
            nOldStatus = m_nCharStatus;
            m_wStatusTimeArr[Grobal2.STATE_BUBBLEDEFENCEUP] = nSec;
            m_dwStatusArrTick[Grobal2.STATE_BUBBLEDEFENCEUP] = HUtil32.GetTickCount();
            m_nCharStatus = GetCharStatus();
            if (nOldStatus != m_nCharStatus)
            {
                StatusChanged();
            }
            m_boAbilMagBubbleDefence = true;
            m_btMagBubbleDefenceLevel = nLevel;
            return true;
        }

        public TUserItem sub_4C4CD4(string sItemName, ref int nCount)
        {
            TUserItem result = null;
            string sName;
            nCount = 0;
            for (int i = m_UseItems.GetLowerBound(0); i <= m_UseItems.GetUpperBound(0); i++)
            {
                if (m_UseItems[i] == null)
                {
                    continue;
                }
                sName = M2Share.UserEngine.GetStdItemName(m_UseItems[i].wIndex);
                if (string.Compare(sName, sItemName, StringComparison.OrdinalIgnoreCase) == 0)
                {
                    result = m_UseItems[i];
                    nCount++;
                }
            }
            return result;
        }

        public TUserItem CheckItems(string sItemName)
        {
            TUserItem result = null;
            TUserItem UserItem;
            for (int i = 0; i < m_ItemList.Count; i++)
            {
                UserItem = m_ItemList[i];
                if (UserItem == null)
                {
                    continue;
                }
                if (string.Compare(M2Share.UserEngine.GetStdItemName(UserItem.wIndex), sItemName, StringComparison.OrdinalIgnoreCase) == 0)
                {
                    result = UserItem;
                    break;
                }
            }
            return result;
        }

        public int sub_4C3538()
        {
            int result= 0;
            int nC= -1;
            int n10;
            while (nC != 2)
            {
                n10 = -1;
                while (n10 != 2)
                {
                    if (!m_PEnvir.CanWalk(m_nCurrX + nC, m_nCurrY + n10, false))
                    {
                        if ((nC != 0) || (n10 != 0))
                        {
                            result++;
                        }
                    }
                    n10++;
                }
                nC++;
            }
            return result;
        }

        protected void DelBagItem(int nIndex)
        {
            if ((nIndex < 0) || (nIndex >= m_ItemList.Count))
            {
                return;
            }
            Dispose(m_ItemList[nIndex]);
            m_ItemList.RemoveAt(nIndex);
        }

        public bool DelBagItem(int nItemIndex, string sItemName)
        {
            TUserItem UserItem;
            bool result = false;
            for (int i = 0; i < m_ItemList.Count; i++)
            {
                UserItem = m_ItemList[i];
                if ((UserItem.MakeIndex == nItemIndex) && string.Compare(M2Share.UserEngine.GetStdItemName(UserItem.wIndex), sItemName, StringComparison.OrdinalIgnoreCase) == 0)
                {
                    Dispose(UserItem);
                    m_ItemList.RemoveAt(i);
                    result = true;
                    break;
                }
            }
            if (result)
            {
                WeightChanged();
            }
            return result;
        }

        public bool CanMove(short nX, short nY, bool boFlag)
        {
            if (Math.Abs(m_nCurrX - nX) <= 1 && Math.Abs(m_nCurrX - nY) <= 1)
            {
                return m_PEnvir.CanWalkEx(nX, nY, boFlag);
            }
            return CanRun(nX, nY, boFlag);
        }

        public bool CanMove(short nCurrX, short nCurrY, short nX, short nY, bool boFlag)
        {
            if ((Math.Abs(nCurrX - nX) <= 1) && (Math.Abs(nCurrY - nY) <= 1))
            {
                return m_PEnvir.CanWalkEx(nX, nY, boFlag);
            }
            else{
                return CanRun(nCurrX, nCurrY, nX, nY, boFlag);
            }
        }

        public bool CanRun(short nCurrX, short nCurrY, short nX, short nY, bool boFlag)
        {
            var result = false;
            var btDir = M2Share.GetNextDirection(nCurrX, nCurrY, nX, nY);
            switch (btDir)
            {
                case Grobal2.DR_UP:
                    if (nCurrY > 1) {
                        if ((m_PEnvir.CanWalkEx(nCurrX, nCurrY - 1, M2Share.g_Config.boDiableHumanRun || ((m_btPermission > 9) && M2Share.g_Config.boGMRunAll)) || (M2Share.g_Config.boSafeAreaLimited && InSafeZone()))
                                && (m_PEnvir.CanWalkEx(nCurrX, nCurrY - 2, M2Share.g_Config.boDiableHumanRun ||((m_btPermission > 9) && M2Share.g_Config.boGMRunAll)) || (M2Share.g_Config.boSafeAreaLimited && InSafeZone())))
                        {
                            result = true;
                            return result;
                        }
                    }
                    break;
                case Grobal2.DR_UPRIGHT:
                    if (nCurrX < m_PEnvir.wWidth - 2 && nCurrY > 1)
                    {
                        if ((m_PEnvir.CanWalkEx(nCurrX + 1, nCurrY - 1, M2Share.g_Config.boDiableHumanRun || ((m_btPermission > 9) && M2Share.g_Config.boGMRunAll)) || (M2Share.g_Config.boSafeAreaLimited && InSafeZone())) &&
                            (m_PEnvir.CanWalkEx(nCurrX + 2, nCurrY - 2, M2Share.g_Config.boDiableHumanRun || ((m_btPermission > 9) && M2Share.g_Config.boGMRunAll)) || (M2Share.g_Config.boSafeAreaLimited && InSafeZone())))
                        {
                            result = true;
                            return result;
                        }
                    }
                    break;
                case Grobal2.DR_RIGHT:
                    if (nCurrX < m_PEnvir.wWidth - 2)
                    {
                        if (m_PEnvir.CanWalkEx(nCurrX + 1, nCurrY, M2Share.g_Config.boDiableHumanRun || ((m_btPermission > 9) && M2Share.g_Config.boGMRunAll)) || (M2Share.g_Config.boSafeAreaLimited && InSafeZone()) &&
                         (m_PEnvir.CanWalkEx(nCurrX + 2, nCurrY, M2Share.g_Config.boDiableHumanRun || ((m_btPermission > 9) && M2Share.g_Config.boGMRunAll)) || (M2Share.g_Config.boSafeAreaLimited && InSafeZone())))
                        {
                            result = true;
                            return result;
                        }
                    }
                    break;
                case Grobal2.DR_DOWNRIGHT:
                    if ((nCurrX < m_PEnvir.wWidth - 2) && (nCurrY < m_PEnvir.wHeight - 2) && (m_PEnvir.CanWalkEx(nCurrX + 1, nCurrY + 1, M2Share.g_Config.boDiableHumanRun || ((m_btPermission > 9) && M2Share.g_Config.boGMRunAll)) ||
                        M2Share.g_Config.boSafeAreaLimited && InSafeZone()) && (m_PEnvir.CanWalkEx(nCurrX + 2, nCurrY + 2, M2Share.g_Config.boDiableHumanRun || ((m_btPermission > 9) && M2Share.g_Config.boGMRunAll)) || (M2Share.g_Config.boSafeAreaLimited && InSafeZone())))
                    {
                        result = true;
                        return result;
                    }
                    break;
                case Grobal2.DR_DOWN:
                    if ((nCurrY < m_PEnvir.wHeight - 2) &&
                        (m_PEnvir.CanWalkEx(nCurrX, nCurrY + 1, M2Share.g_Config.boDiableHumanRun || ((m_btPermission > 9) && M2Share.g_Config.boGMRunAll)) || (M2Share.g_Config.boSafeAreaLimited && InSafeZone()) &&
                        (m_PEnvir.CanWalkEx(nCurrX, nCurrY + 2, M2Share.g_Config.boDiableHumanRun || ((m_btPermission > 9) && M2Share.g_Config.boGMRunAll)) || (M2Share.g_Config.boSafeAreaLimited && InSafeZone()))))
                    {
                        result = true;
                        return result;
                    }
                    break;
                case Grobal2.DR_DOWNLEFT:
                    if ((nCurrX > 1) && (nCurrY < m_PEnvir.wHeight - 2) && (m_PEnvir.CanWalkEx(nCurrX - 1, nCurrY + 1, M2Share.g_Config.boDiableHumanRun || ((m_btPermission > 9) && M2Share.g_Config.boGMRunAll)) || (M2Share.g_Config.boSafeAreaLimited && InSafeZone())) &&
                    (m_PEnvir.CanWalkEx(nCurrX - 2, nCurrY + 2, M2Share.g_Config.boDiableHumanRun || ((m_btPermission > 9) && M2Share.g_Config.boGMRunAll)) ||(M2Share.g_Config.boSafeAreaLimited && InSafeZone())))
                    {
                        result = true;
                        return result;
                    }
                    break;
                case Grobal2.DR_LEFT:
                    if ((nCurrX > 1) && (m_PEnvir.CanWalkEx(nCurrX - 1, nCurrY, M2Share.g_Config.boDiableHumanRun || ((m_btPermission > 9) && M2Share.g_Config.boGMRunAll)) || (M2Share.g_Config.boSafeAreaLimited && InSafeZone())) &&
                    (m_PEnvir.CanWalkEx(nCurrX - 2, nCurrY, M2Share.g_Config.boDiableHumanRun ||((m_btPermission > 9) && M2Share.g_Config.boGMRunAll)) || (M2Share.g_Config.boSafeAreaLimited && InSafeZone())))
                    {
                        result = true;
                        return result;
                    }
                    break;
                case Grobal2.DR_UPLEFT:
                    if ((nCurrX > 1) && (nCurrY > 1) && (m_PEnvir.CanWalkEx(nCurrX - 1, nCurrY - 1, M2Share.g_Config.boDiableHumanRun || ((m_btPermission > 9) && M2Share.g_Config.boGMRunAll))
                    || (M2Share.g_Config.boSafeAreaLimited && InSafeZone())) && (m_PEnvir.CanWalkEx(nCurrX - 2, nCurrY - 2, M2Share.g_Config.boDiableHumanRun || ((m_btPermission > 9) && M2Share.g_Config.boGMRunAll)) ||
                    (M2Share.g_Config.boSafeAreaLimited && InSafeZone())))
                    {
                        result = true;
                        return result;
                    }
                    break;
            }
            return false;
        }

        private bool CanRun(short nX, short nY, bool boFlag)
        {
            var result = false;
            var btDir = M2Share.GetNextDirection(m_nCurrX, m_nCurrY, nX, nY);
            switch (btDir)
            {
                case Grobal2.DR_UP:
                    if (m_nCurrY > 1) {
                        if ((m_PEnvir.CanWalkEx(m_nCurrX, m_nCurrY - 1, M2Share.g_Config.boDiableHumanRun || ((m_btPermission > 9) && M2Share.g_Config.boGMRunAll)) || (M2Share.g_Config.boSafeAreaLimited && InSafeZone()))
                                && (m_PEnvir.CanWalkEx(m_nCurrX, m_nCurrY - 2, M2Share.g_Config.boDiableHumanRun ||((m_btPermission > 9) && M2Share.g_Config.boGMRunAll)) || (M2Share.g_Config.boSafeAreaLimited && InSafeZone())))
                        {
                            result = true;
                            return result;
                        }
                    }
                    break;
                case Grobal2.DR_UPRIGHT:
                    if (m_nCurrX < m_PEnvir.wWidth - 2 && m_nCurrY > 1)
                    {
                        if ((m_PEnvir.CanWalkEx(m_nCurrX + 1, m_nCurrY - 1, M2Share.g_Config.boDiableHumanRun || ((m_btPermission > 9) && M2Share.g_Config.boGMRunAll)) || (M2Share.g_Config.boSafeAreaLimited && InSafeZone())) &&
                            (m_PEnvir.CanWalkEx(m_nCurrX + 2, m_nCurrY - 2, M2Share.g_Config.boDiableHumanRun || ((m_btPermission > 9) && M2Share.g_Config.boGMRunAll)) || (M2Share.g_Config.boSafeAreaLimited && InSafeZone())))
                        {
                            result = true;
                            return result;
                        }
                    }
                    break;
                case Grobal2.DR_RIGHT:
                    if (m_nCurrX < m_PEnvir.wWidth - 2)
                    {
                        if (m_PEnvir.CanWalkEx(m_nCurrX + 1, m_nCurrY, M2Share.g_Config.boDiableHumanRun || ((m_btPermission > 9) && M2Share.g_Config.boGMRunAll)) || (M2Share.g_Config.boSafeAreaLimited && InSafeZone()) &&
                         (m_PEnvir.CanWalkEx(m_nCurrX + 2, m_nCurrY, M2Share.g_Config.boDiableHumanRun || ((m_btPermission > 9) && M2Share.g_Config.boGMRunAll)) || (M2Share.g_Config.boSafeAreaLimited && InSafeZone())))
                        {
                            result = true;
                            return result;
                        }
                    }
                    break;
                case Grobal2.DR_DOWNRIGHT:
                    if ((m_nCurrX < m_PEnvir.wWidth - 2) && (m_nCurrY < m_PEnvir.wHeight - 2) && (m_PEnvir.CanWalkEx(m_nCurrX + 1, m_nCurrY + 1, M2Share.g_Config.boDiableHumanRun || ((m_btPermission > 9) && M2Share.g_Config.boGMRunAll)) ||
                        M2Share.g_Config.boSafeAreaLimited && InSafeZone()) && (m_PEnvir.CanWalkEx(m_nCurrX + 2, m_nCurrY + 2, M2Share.g_Config.boDiableHumanRun || ((m_btPermission > 9) && M2Share.g_Config.boGMRunAll)) || (M2Share.g_Config.boSafeAreaLimited && InSafeZone())))
                    {
                        result = true;
                        return result;
                    }
                    break;
                case Grobal2.DR_DOWN:
                    if ((m_nCurrY < m_PEnvir.wHeight - 2) &&
                        (m_PEnvir.CanWalkEx(m_nCurrX, m_nCurrY + 1, M2Share.g_Config.boDiableHumanRun || ((m_btPermission > 9) && M2Share.g_Config.boGMRunAll)) || (M2Share.g_Config.boSafeAreaLimited && InSafeZone()) &&
                        (m_PEnvir.CanWalkEx(m_nCurrX, m_nCurrY + 2, M2Share.g_Config.boDiableHumanRun || ((m_btPermission > 9) && M2Share.g_Config.boGMRunAll)) || (M2Share.g_Config.boSafeAreaLimited && InSafeZone()))))
                    {
                        result = true;
                        return result;
                    }
                    break;
                case Grobal2.DR_DOWNLEFT:
                    if ((m_nCurrX > 1) && (m_nCurrY < m_PEnvir.wHeight - 2) && (m_PEnvir.CanWalkEx(m_nCurrX - 1, m_nCurrY + 1, M2Share.g_Config.boDiableHumanRun || ((m_btPermission > 9) && M2Share.g_Config.boGMRunAll)) || (M2Share.g_Config.boSafeAreaLimited && InSafeZone())) &&
                    (m_PEnvir.CanWalkEx(m_nCurrX - 2, m_nCurrY + 2, M2Share.g_Config.boDiableHumanRun || ((m_btPermission > 9) && M2Share.g_Config.boGMRunAll)) ||(M2Share.g_Config.boSafeAreaLimited && InSafeZone())))
                    {
                        result = true;
                        return result;
                    }
                    break;
                case Grobal2.DR_LEFT:
                    if ((m_nCurrX > 1) && (m_PEnvir.CanWalkEx(m_nCurrX - 1, m_nCurrY, M2Share.g_Config.boDiableHumanRun || ((m_btPermission > 9) && M2Share.g_Config.boGMRunAll)) || (M2Share.g_Config.boSafeAreaLimited && InSafeZone())) &&
                    (m_PEnvir.CanWalkEx(m_nCurrX - 2, m_nCurrY, M2Share.g_Config.boDiableHumanRun ||((m_btPermission > 9) && M2Share.g_Config.boGMRunAll)) || (M2Share.g_Config.boSafeAreaLimited && InSafeZone())))
                    {
                        result = true;
                        return result;
                    }
                    break;
                case Grobal2.DR_UPLEFT:
                    if ((m_nCurrX > 1) && (m_nCurrY > 1) && (m_PEnvir.CanWalkEx(m_nCurrX - 1, m_nCurrY - 1, M2Share.g_Config.boDiableHumanRun || ((m_btPermission > 9) && M2Share.g_Config.boGMRunAll))
                    || (M2Share.g_Config.boSafeAreaLimited && InSafeZone())) && (m_PEnvir.CanWalkEx(m_nCurrX - 2, m_nCurrY - 2, M2Share.g_Config.boDiableHumanRun || ((m_btPermission > 9) && M2Share.g_Config.boGMRunAll)) ||
                    (M2Share.g_Config.boSafeAreaLimited && InSafeZone())))
                    {
                        result = true;
                        return result;
                    }
                    break;
            }
            return false;
        }

        public TBaseObject GetMaster()
        {
            TBaseObject MasterObject = null;
            if (m_btRaceServer != Grobal2.RC_PLAYOBJECT)
            {
                MasterObject = m_Master;
                if (MasterObject != null)
                {
                    while (true)
                    {
                        if (MasterObject.m_Master != null)
                        {
                            MasterObject = MasterObject.m_Master;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                return MasterObject;
            }
            return null;
        }

        internal void Dispose(object obj)
        {
            obj = null;
        }

        internal string format(string str, params object[] par)
        {
            return string.Format(str, par);
        }
    }
}

