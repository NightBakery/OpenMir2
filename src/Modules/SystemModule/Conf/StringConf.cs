﻿using SystemModule.Common;

namespace SystemModule{
    public class StringConf : ConfigFile
    {
        public StringConf(string fileName) : base(fileName)
        {
            Load();
        }

        public void LoadString()
        {
            ModuleShare.Config.ServerIPaddr = ReadWriteString("Server", "ServerIP", ModuleShare.Config.ServerIPaddr);
            ModuleShare.Config.sWebSite = ReadWriteString("Server", "WebSite", ModuleShare.Config.sWebSite);
            ModuleShare.Config.sBbsSite = ReadWriteString("Server", "BbsSite", ModuleShare.Config.sBbsSite);
            ModuleShare.Config.sClientDownload = ReadWriteString("Server", "ClientDownload", ModuleShare.Config.sClientDownload);
            ModuleShare.Config.sQQ = ReadWriteString("Server", "QQ", ModuleShare.Config.sQQ);
            ModuleShare.Config.sPhone = ReadWriteString("Server", "Phone", ModuleShare.Config.sPhone);
            ModuleShare.Config.sBankAccount0 = ReadWriteString("Server", "BankAccount0", ModuleShare.Config.sBankAccount0);
            ModuleShare.Config.sBankAccount1 = ReadWriteString("Server", "BankAccount1", ModuleShare.Config.sBankAccount1);
            ModuleShare.Config.sBankAccount2 = ReadWriteString("Server", "BankAccount2", ModuleShare.Config.sBankAccount2);
            ModuleShare.Config.sBankAccount3 = ReadWriteString("Server", "BankAccount3", ModuleShare.Config.sBankAccount3);
            ModuleShare.Config.sBankAccount4 = ReadWriteString("Server", "BankAccount4", ModuleShare.Config.sBankAccount4);
            ModuleShare.Config.sBankAccount5 = ReadWriteString("Server", "BankAccount5", ModuleShare.Config.sBankAccount5);
            ModuleShare.Config.sBankAccount6 = ReadWriteString("Server", "BankAccount6", ModuleShare.Config.sBankAccount6);
            ModuleShare.Config.sBankAccount7 = ReadWriteString("Server", "BankAccount7", ModuleShare.Config.sBankAccount7);
            ModuleShare.Config.sBankAccount8 = ReadWriteString("Server", "BankAccount8", ModuleShare.Config.sBankAccount8);
            ModuleShare.Config.sBankAccount9 = ReadWriteString("Server", "BankAccount9", ModuleShare.Config.sBankAccount9);
            ModuleShare.Config.GuildNotice = ReadWriteString("Guild", "GuildNotice", ModuleShare.Config.GuildNotice);
            ModuleShare.Config.GuildWar = ReadWriteString("Guild", "GuildWar", ModuleShare.Config.GuildWar);
            ModuleShare.Config.GuildAll = ReadWriteString("Guild", "GuildAll", ModuleShare.Config.GuildAll);
            ModuleShare.Config.GuildMember = ReadWriteString("Guild", "GuildMember", ModuleShare.Config.GuildMember);
            ModuleShare.Config.GuildMemberRank = ReadWriteString("Guild", "GuildMemberRank", ModuleShare.Config.GuildMemberRank);
            ModuleShare.Config.GuildChief = ReadWriteString("Guild", "GuildChief", ModuleShare.Config.GuildChief);
            ModuleShare.Config.LineNoticePreFix = ReadWriteString("String", "LineNoticePreFix", ModuleShare.Config.LineNoticePreFix);
            ModuleShare.Config.SysMsgPreFix = ReadWriteString("String", "SysMsgPreFix", ModuleShare.Config.SysMsgPreFix);
            ModuleShare.Config.GuildMsgPreFix = ReadWriteString("String", "GuildMsgPreFix", ModuleShare.Config.GuildMsgPreFix);
            ModuleShare.Config.GroupMsgPreFix = ReadWriteString("String", "GroupMsgPreFix", ModuleShare.Config.GroupMsgPreFix);
            ModuleShare.Config.HintMsgPreFix = ReadWriteString("String", "HintMsgPreFix", ModuleShare.Config.HintMsgPreFix);
            ModuleShare.Config.GameManagerRedMsgPreFix = ReadWriteString("String", "GMRedMsgpreFix", ModuleShare.Config.GameManagerRedMsgPreFix);
            ModuleShare.Config.MonSayMsgPreFix = ReadWriteString("String", "MonSayMsgpreFix", ModuleShare.Config.MonSayMsgPreFix);
            ModuleShare.Config.CustMsgPreFix = ReadWriteString("String", "CustMsgpreFix", ModuleShare.Config.CustMsgPreFix);
            ModuleShare.Config.CastleMsgPreFix = ReadWriteString("String", "CastleMsgpreFix", ModuleShare.Config.CastleMsgPreFix);

            Settings.ClientSoftVersionError = ReadWriteString("String", "ClientSoftVersionError", Settings.ClientSoftVersionError);
            Settings.DownLoadNewClientSoft = ReadWriteString("String", "DownLoadNewClientSoft", Settings.DownLoadNewClientSoft);
            Settings.ForceDisConnect = ReadWriteString("String", "ForceDisConnect", Settings.ForceDisConnect);
            Settings.ClientSoftVersionTooOld = ReadWriteString("String", "ClientSoftVersionTooOld", Settings.ClientSoftVersionTooOld);
            Settings.DownLoadAndUseNewClient = ReadWriteString("String", "DownLoadAndUseNewClient", Settings.DownLoadAndUseNewClient);
            Settings.OnlineUserFull = ReadWriteString("String", "OnlineUserFull", Settings.OnlineUserFull);
            Settings.YouNowIsTryPlayMode = ReadWriteString("String", "YouNowIsTryPlayMode", Settings.YouNowIsTryPlayMode);
            Settings.NowIsFreePlayMode = ReadWriteString("String", "NowIsFreePlayMode", Settings.NowIsFreePlayMode);
            Settings.AttackModeOfAll = ReadWriteString("String", "AttackModeOfAll", Settings.AttackModeOfAll);
            Settings.AttackModeOfPeaceful = ReadWriteString("String", "AttackModeOfPeaceful", Settings.AttackModeOfPeaceful);
            Settings.AttackModeOfGroup = ReadWriteString("String", "AttackModeOfGroup", Settings.AttackModeOfGroup);
            Settings.AttackModeOfGuild = ReadWriteString("String", "AttackModeOfGuild", Settings.AttackModeOfGuild);
            Settings.AttackModeOfRedWhite = ReadWriteString("String", "AttackModeOfRedWhite", Settings.AttackModeOfRedWhite);
            Settings.AttackModeOfMaster = ReadWriteString("String", "AttackModeOfMaster", Settings.AttackModeOfMaster);
            Settings.StartChangeAttackModeHelp = ReadWriteString("String", "StartChangeAttackModeHelp", Settings.StartChangeAttackModeHelp);
            Settings.StartNoticeMsg = ReadWriteString("String", "StartNoticeMsg", Settings.StartNoticeMsg);
            Settings.ThrustingOn = ReadWriteString("String", "ThrustingOn", Settings.ThrustingOn);
            Settings.ThrustingOff = ReadWriteString("String", "ThrustingOff", Settings.ThrustingOff);
            Settings.HalfMoonOn = ReadWriteString("String", "HalfMoonOn", Settings.HalfMoonOn);
            Settings.HalfMoonOff = ReadWriteString("String", "HalfMoonOff", Settings.HalfMoonOff);
            Settings.CrsHitOn = ReadWriteString("String", "CrsHitOn", Settings.CrsHitOn);
            Settings.CrsHitOff = ReadWriteString("String", "CrsHitOff", Settings.CrsHitOff);
            Settings.TwinHitOn = ReadWriteString("String", "TwinHitOn", Settings.TwinHitOn);
            Settings.TwinHitOff = ReadWriteString("String", "TwinHitOff", Settings.TwinHitOff);
            Settings.FireSpiritsSummoned = ReadWriteString("String", "FireSpiritsSummoned", Settings.FireSpiritsSummoned);
            Settings.FireSpiritsFail = ReadWriteString("String", "FireSpiritsFail", Settings.FireSpiritsFail);
            Settings.SpiritsGone = ReadWriteString("String", "SpiritsGone", Settings.SpiritsGone);
            Settings.MateDoTooweak = ReadWriteString("String", "MateDoTooweak", Settings.MateDoTooweak);
            Settings.TheWeaponBroke = ReadWriteString("String", "TheWeaponBroke", Settings.TheWeaponBroke);
            Settings.TheWeaponRefineSuccessfull = ReadWriteString("String", "TheWeaponRefineSuccessfull", Settings.TheWeaponRefineSuccessfull);
            Settings.YouPoisoned = ReadWriteString("String", "YouPoisoned", Settings.YouPoisoned);
            Settings.PetRest = ReadWriteString("String", "PetRest", Settings.PetRest);
            Settings.PetAttack = ReadWriteString("String", "PetAttack", Settings.PetAttack);
            Settings.WearNotOfWoMan = ReadWriteString("String", "WearNotOfWoMan", Settings.WearNotOfWoMan);
            Settings.WearNotOfMan = ReadWriteString("String", "WearNotOfMan", Settings.WearNotOfMan);
            Settings.HandWeightNot = ReadWriteString("String", "HandWeightNot", Settings.HandWeightNot);
            Settings.WearWeightNot = ReadWriteString("String", "WearWeightNot", Settings.WearWeightNot);
            Settings.ItemIsNotThisAccount = ReadWriteString("String", "ItemIsNotThisAccount", Settings.ItemIsNotThisAccount);
            Settings.ItemIsNotThisIPaddr = ReadWriteString("String", "ItemIsNotThisIPaddr", Settings.ItemIsNotThisIPaddr);
            Settings.ItemIsNotThisChrName = ReadWriteString("String", "ItemIsNotThisChrName", Settings.ItemIsNotThisChrName);
            Settings.LevelNot = ReadWriteString("String", "LevelNot", Settings.LevelNot);
            Settings.JobOrLevelNot = ReadWriteString("String", "JobOrLevelNot", Settings.JobOrLevelNot);
            Settings.JobOrDCNot = ReadWriteString("String", "JobOrDCNot", Settings.JobOrDCNot);
            Settings.JobOrMCNot = ReadWriteString("String", "JobOrMCNot", Settings.JobOrMCNot);
            Settings.JobOrSCNot = ReadWriteString("String", "JobOrSCNot", Settings.JobOrSCNot);
            Settings.DCNot = ReadWriteString("String", "DCNot", Settings.DCNot);
            Settings.MCNot = ReadWriteString("String", "MCNot", Settings.MCNot);
            Settings.SCNot = ReadWriteString("String", "SCNot", Settings.SCNot);
            Settings.CreditPointNot = ReadWriteString("String", "CreditPointNot", Settings.CreditPointNot);
            Settings.ReNewLevelNot = ReadWriteString("String", "ReNewLevelNot", Settings.ReNewLevelNot);
            Settings.GuildNot = ReadWriteString("String", "GuildNot", Settings.GuildNot);
            Settings.GuildMasterNot = ReadWriteString("String", "GuildMasterNot", Settings.GuildMasterNot);
            Settings.SabukHumanNot = ReadWriteString("String", "SabukHumanNot", Settings.SabukHumanNot);
            Settings.SabukMasterManNot = ReadWriteString("String", "SabukMasterManNot", Settings.SabukMasterManNot);
            Settings.MemberNot = ReadWriteString("String", "MemberNot", Settings.MemberNot);
            Settings.MemberTypeNot = ReadWriteString("String", "MemberTypeNot", Settings.MemberTypeNot);
            Settings.CanottWearIt = ReadWriteString("String", "CanottWearIt", Settings.CanottWearIt);
            Settings.CanotUseDrugOnThisMap = ReadWriteString("String", "CanotUseDrugOnThisMap", Settings.CanotUseDrugOnThisMap);
            Settings.GameMasterMode = ReadWriteString("String", "GameMasterMode", Settings.GameMasterMode);
            Settings.ReleaseGameMasterMode = ReadWriteString("String", "ReleaseGameMasterMode", Settings.ReleaseGameMasterMode);
            Settings.ObserverMode = ReadWriteString("String", "ObserverMode", Settings.ObserverMode);
            Settings.ReleaseObserverMode = ReadWriteString("String", "ReleaseObserverMode", Settings.ReleaseObserverMode);
            Settings.SupermanMode = ReadWriteString("String", "SupermanMode", Settings.SupermanMode);
            Settings.ReleaseSupermanMode = ReadWriteString("String", "ReleaseSupermanMode", Settings.ReleaseSupermanMode);
            Settings.YouFoundNothing = ReadWriteString("String", "YouFoundNothing", Settings.YouFoundNothing);
            Settings.NoPasswordLockSystemMsg = ReadWriteString("String", "NoPasswordLockSystemMsg", Settings.NoPasswordLockSystemMsg);
            Settings.AlreadySetPasswordMsg = ReadWriteString("String", "AlreadySetPassword", Settings.AlreadySetPasswordMsg);
            Settings.ReSetPasswordMsg = ReadWriteString("String", "ReSetPassword", Settings.ReSetPasswordMsg);
            Settings.PasswordOverLongMsg = ReadWriteString("String", "PasswordOverLong", Settings.PasswordOverLongMsg);
            Settings.ReSetPasswordOKMsg = ReadWriteString("String", "ReSetPasswordOK", Settings.ReSetPasswordOKMsg);
            Settings.ReSetPasswordNotMatchMsg = ReadWriteString("String", "ReSetPasswordNotMatch", Settings.ReSetPasswordNotMatchMsg);
            Settings.PleaseInputUnLockPasswordMsg = ReadWriteString("String", "PleaseInputUnLockPassword", Settings.PleaseInputUnLockPasswordMsg);
            Settings.StorageUnLockOKMsg = ReadWriteString("String", "StorageUnLockOK", Settings.StorageUnLockOKMsg);
            Settings.StorageAlreadyUnLockMsg = ReadWriteString("String", "StorageAlreadyUnLock", Settings.StorageAlreadyUnLockMsg);
            Settings.StorageNoPasswordMsg = ReadWriteString("String", "StorageNoPassword", Settings.StorageNoPasswordMsg);
            Settings.UnLockPasswordFailMsg = ReadWriteString("String", "UnLockPasswordFail", Settings.UnLockPasswordFailMsg);
            Settings.LockStorageSuccessMsg = ReadWriteString("String", "LockStorageSuccess", Settings.LockStorageSuccessMsg);
            Settings.StoragePasswordClearMsg = ReadWriteString("String", "StoragePasswordClear", Settings.StoragePasswordClearMsg);
            Settings.PleaseUnloadStoragePasswordMsg = ReadWriteString("String", "PleaseUnloadStoragePassword", Settings.PleaseUnloadStoragePasswordMsg);
            Settings.StorageAlreadyLockMsg = ReadWriteString("String", "StorageAlreadyLock", Settings.StorageAlreadyLockMsg);
            Settings.StoragePasswordLockedMsg = ReadWriteString("String", "StoragePasswordLocked", Settings.StoragePasswordLockedMsg);
            Settings.SetPasswordMsg = ReadWriteString("String", "StorageSetPassword", Settings.SetPasswordMsg);
            Settings.PleaseInputOldPasswordMsg = ReadWriteString("String", "PleaseInputOldPassword", Settings.PleaseInputOldPasswordMsg);
            Settings.OldPasswordIsClearMsg = ReadWriteString("String", "PasswordIsClearMsg", Settings.OldPasswordIsClearMsg);
            Settings.NoPasswordSetMsg = ReadWriteString("String", "NoPasswordSet", Settings.NoPasswordSetMsg);
            Settings.OldPasswordIncorrectMsg = ReadWriteString("String", "OldPasswordIncorrect", Settings.OldPasswordIncorrectMsg);
            Settings.StorageIsLockedMsg = ReadWriteString("String", "StorageIsLocked", Settings.StorageIsLockedMsg);
            Settings.PleaseTryDealLaterMsg = ReadWriteString("String", "PleaseTryDealLaterMsg", Settings.PleaseTryDealLaterMsg);
            Settings.DealItemsDenyGetBackMsg = ReadWriteString("String", "DealItemsDenyGetBackMsg", Settings.DealItemsDenyGetBackMsg);
            Settings.DisableDealItemsMsg = ReadWriteString("String", "DisableDealItemsMsg", Settings.DisableDealItemsMsg);
            Settings.CanotTryDealMsg = ReadWriteString("String", "CanotTryDealMsg", Settings.CanotTryDealMsg);
            Settings.DealActionCancelMsg = ReadWriteString("String", "DealActionCancelMsg", Settings.DealActionCancelMsg);
            Settings.PoseDisableDealMsg = ReadWriteString("String", "PoseDisableDealMsg", Settings.PoseDisableDealMsg);
            Settings.DealSuccessMsg = ReadWriteString("String", "DealSuccessMsg", Settings.DealSuccessMsg);
            Settings.DealOKTooFast = ReadWriteString("String", "DealOKTooFast", Settings.DealOKTooFast);
            Settings.YourBagSizeTooSmall = ReadWriteString("String", "YourBagSizeTooSmall", Settings.YourBagSizeTooSmall);
            Settings.DealHumanBagSizeTooSmall = ReadWriteString("String", "DealHumanBagSizeTooSmall", Settings.DealHumanBagSizeTooSmall);
            Settings.YourGoldLargeThenLimit = ReadWriteString("String", "YourGoldLargeThenLimit", Settings.YourGoldLargeThenLimit);
            Settings.DealHumanGoldLargeThenLimit = ReadWriteString("String", "DealHumanGoldLargeThenLimit", Settings.DealHumanGoldLargeThenLimit);
            Settings.YouDealOKMsg = ReadWriteString("String", "YouDealOKMsg", Settings.YouDealOKMsg);
            Settings.PoseDealOKMsg = ReadWriteString("String", "PoseDealOKMsg", Settings.PoseDealOKMsg);
            Settings.KickClientUserMsg = ReadWriteString("String", "KickClientUserMsg", Settings.KickClientUserMsg);
            Settings.ActionIsLockedMsg = ReadWriteString("String", "ActionIsLockedMsg", Settings.ActionIsLockedMsg);
            Settings.PasswordNotSetMsg = ReadWriteString("String", "PasswordNotSetMsg", Settings.PasswordNotSetMsg);
            Settings.NotPasswordProtectMode = ReadWriteString("String", "NotPasswordProtectMode", Settings.NotPasswordProtectMode);
            Settings.CanotDropGoldMsg = ReadWriteString("String", "CanotDropGoldMsg", Settings.CanotDropGoldMsg);
            Settings.CanotDropInSafeZoneMsg = ReadWriteString("String", "CanotDropInSafeZoneMsg", Settings.CanotDropInSafeZoneMsg);
            Settings.CanotDropItemMsg = ReadWriteString("String", "CanotDropItemMsg", Settings.CanotDropItemMsg);
            Settings.CanotUseItemMsg = ReadWriteString("String", "CanotUseItemMsg", Settings.CanotUseItemMsg);
            Settings.StartMarryManMsg = ReadWriteString("String", "StartMarryManMsg", Settings.StartMarryManMsg);
            Settings.StartMarryWoManMsg = ReadWriteString("String", "StartMarryWoManMsg", Settings.StartMarryWoManMsg);
            Settings.StartMarryManAskQuestionMsg = ReadWriteString("String", "StartMarryManAskQuestionMsg", Settings.StartMarryManAskQuestionMsg);
            Settings.StartMarryWoManAskQuestionMsg = ReadWriteString("String", "StartMarryWoManAskQuestionMsg", Settings.StartMarryWoManAskQuestionMsg);
            Settings.MarryManAnswerQuestionMsg = ReadWriteString("String", "MarryManAnswerQuestionMsg", Settings.MarryManAnswerQuestionMsg);
            Settings.MarryManAskQuestionMsg = ReadWriteString("String", "MarryManAskQuestionMsg", Settings.MarryManAskQuestionMsg);
            Settings.MarryWoManAnswerQuestionMsg = ReadWriteString("String", "MarryWoManAnswerQuestionMsg", Settings.MarryWoManAnswerQuestionMsg);
            Settings.MarryWoManGetMarryMsg = ReadWriteString("String", "MarryWoManGetMarryMsg", Settings.MarryWoManGetMarryMsg);
            Settings.MarryWoManDenyMsg = ReadWriteString("String", "MarryWoManDenyMsg", Settings.MarryWoManDenyMsg);
            Settings.MarryWoManCancelMsg = ReadWriteString("String", "MarryWoManCancelMsg", Settings.MarryWoManCancelMsg);
            Settings.fUnMarryManLoginMsg = ReadWriteString("String", "ForceUnMarryManLoginMsg", Settings.fUnMarryManLoginMsg);
            Settings.fUnMarryWoManLoginMsg = ReadWriteString("String", "ForceUnMarryWoManLoginMsg", Settings.fUnMarryWoManLoginMsg);
            Settings.ManLoginDearOnlineSelfMsg = ReadWriteString("String", "ManLoginDearOnlineSelfMsg", Settings.ManLoginDearOnlineSelfMsg);
            Settings.ManLoginDearOnlineDearMsg = ReadWriteString("String", "ManLoginDearOnlineDearMsg", Settings.ManLoginDearOnlineDearMsg);
            Settings.WoManLoginDearOnlineSelfMsg = ReadWriteString("String", "WoManLoginDearOnlineSelfMsg", Settings.WoManLoginDearOnlineSelfMsg);
            Settings.WoManLoginDearOnlineDearMsg = ReadWriteString("String", "WoManLoginDearOnlineDearMsg", Settings.WoManLoginDearOnlineDearMsg);
            Settings.ManLoginDearNotOnlineMsg = ReadWriteString("String", "ManLoginDearNotOnlineMsg", Settings.ManLoginDearNotOnlineMsg);
            Settings.WoManLoginDearNotOnlineMsg = ReadWriteString("String", "WoManLoginDearNotOnlineMsg", Settings.WoManLoginDearNotOnlineMsg);
            Settings.ManLongOutDearOnlineMsg = ReadWriteString("String", "ManLongOutDearOnlineMsg", Settings.ManLongOutDearOnlineMsg);
            Settings.WoManLongOutDearOnlineMsg = ReadWriteString("String", "WoManLongOutDearOnlineMsg", Settings.WoManLongOutDearOnlineMsg);
            Settings.YouAreNotMarryedMsg = ReadWriteString("String", "YouAreNotMarryedMsg", Settings.YouAreNotMarryedMsg);
            Settings.YourWifeNotOnlineMsg = ReadWriteString("String", "YourWifeNotOnlineMsg", Settings.YourWifeNotOnlineMsg);
            Settings.YourHusbandNotOnlineMsg = ReadWriteString("String", "YourHusbandNotOnlineMsg", Settings.YourHusbandNotOnlineMsg);
            Settings.YourWifeNowLocateMsg = ReadWriteString("String", "YourWifeNowLocateMsg", Settings.YourWifeNowLocateMsg);
            Settings.YourHusbandSearchLocateMsg = ReadWriteString("String", "YourHusbandSearchLocateMsg", Settings.YourHusbandSearchLocateMsg);
            Settings.YourHusbandNowLocateMsg = ReadWriteString("String", "YourHusbandNowLocateMsg", Settings.YourHusbandNowLocateMsg);
            Settings.YourWifeSearchLocateMsg = ReadWriteString("String", "YourWifeSearchLocateMsg", Settings.YourWifeSearchLocateMsg);
            Settings.fUnMasterLoginMsg = ReadWriteString("String", "FUnMasterLoginMsg", Settings.fUnMasterLoginMsg);
            Settings.fUnMasterListLoginMsg = ReadWriteString("String", "UnMasterListLoginMsg", Settings.fUnMasterListLoginMsg);
            Settings.MasterListOnlineSelfMsg = ReadWriteString("String", "MasterListOnlineSelfMsg", Settings.MasterListOnlineSelfMsg);
            Settings.MasterListOnlineMasterMsg = ReadWriteString("String", "MasterListOnlineMasterMsg", Settings.MasterListOnlineMasterMsg);
            Settings.MasterOnlineSelfMsg = ReadWriteString("String", "MasterOnlineSelfMsg", Settings.MasterOnlineSelfMsg);
            Settings.MasterOnlineMasterListMsg = ReadWriteString("String", "MasterOnlineMasterListMsg", Settings.MasterOnlineMasterListMsg);
            Settings.MasterLongOutMasterListOnlineMsg = ReadWriteString("String", "MasterLongOutMasterListOnlineMsg", Settings.MasterLongOutMasterListOnlineMsg);
            Settings.MasterListLongOutMasterOnlineMsg = ReadWriteString("String", "MasterListLongOutMasterOnlineMsg", Settings.MasterListLongOutMasterOnlineMsg);
            Settings.MasterListNotOnlineMsg = ReadWriteString("String", "MasterListNotOnlineMsg", Settings.MasterListNotOnlineMsg);
            Settings.MasterNotOnlineMsg = ReadWriteString("String", "MasterNotOnlineMsg", Settings.MasterNotOnlineMsg);
            Settings.YouAreNotMasterMsg = ReadWriteString("String", "YouAreNotMasterMsg", Settings.YouAreNotMasterMsg);
            Settings.YourMasterNotOnlineMsg = ReadWriteString("String", "YourMasterNotOnlineMsg", Settings.YourMasterNotOnlineMsg);
            Settings.YourMasterListNotOnlineMsg = ReadWriteString("String", "YourMasterListNotOnlineMsg", Settings.YourMasterListNotOnlineMsg);
            Settings.YourMasterNowLocateMsg = ReadWriteString("String", "YourMasterNowLocateMsg", Settings.YourMasterNowLocateMsg);
            Settings.YourMasterListSearchLocateMsg = ReadWriteString("String", "YourMasterListSearchLocateMsg", Settings.YourMasterListSearchLocateMsg);
            Settings.YourMasterListNowLocateMsg = ReadWriteString("String", "YourMasterListNowLocateMsg", Settings.YourMasterListNowLocateMsg);
            Settings.YourMasterSearchLocateMsg = ReadWriteString("String", "YourMasterSearchLocateMsg", Settings.YourMasterSearchLocateMsg);
            Settings.YourMasterListUnMasterOKMsg = ReadWriteString("String", "YourMasterListUnMasterOKMsg", Settings.YourMasterListUnMasterOKMsg);
            Settings.YouAreUnMasterOKMsg = ReadWriteString("String", "YouAreUnMasterOKMsg", Settings.YouAreUnMasterOKMsg);
            Settings.UnMasterLoginMsg = ReadWriteString("String", "UnMasterLoginMsg", Settings.UnMasterLoginMsg);
            Settings.NPCSayUnMasterOKMsg = ReadWriteString("String", "NPCSayUnMasterOKMsg", Settings.NPCSayUnMasterOKMsg);
            Settings.NPCSayForceUnMasterMsg = ReadWriteString("String", "NPCSayForceUnMasterMsg", Settings.NPCSayForceUnMasterMsg);
            Settings.MyInfo = ReadWriteString("String", "MyInfo", Settings.MyInfo);
            Settings.OpenedDealMsg = ReadWriteString("String", "OpenedDealMsg", Settings.OpenedDealMsg);
            Settings.SendCustMsgCanNotUseNowMsg = ReadWriteString("String", "SendCustMsgCanNotUseNowMsg", Settings.SendCustMsgCanNotUseNowMsg);
            Settings.SubkMasterMsgCanNotUseNowMsg = ReadWriteString("String", "SubkMasterMsgCanNotUseNowMsg", Settings.SubkMasterMsgCanNotUseNowMsg);
            Settings.SendOnlineCountMsg = ReadWriteString("String", "SendOnlineCountMsg", Settings.SendOnlineCountMsg);
            Settings.WeaponRepairSuccess = ReadWriteString("String", "WeaponRepairSuccess", Settings.WeaponRepairSuccess);
            Settings.DefenceUpTime = ReadWriteString("String", "DefenceUpTime", Settings.DefenceUpTime);
            Settings.MagDefenceUpTime = ReadWriteString("String", "MagDefenceUpTime", Settings.MagDefenceUpTime);
            Settings.WinLottery1Msg = ReadWriteString("String", "WinLottery1Msg", Settings.WinLottery1Msg);
            Settings.WinLottery2Msg = ReadWriteString("String", "WinLottery2Msg", Settings.WinLottery2Msg);
            Settings.WinLottery3Msg = ReadWriteString("String", "WinLottery3Msg", Settings.WinLottery3Msg);
            Settings.WinLottery4Msg = ReadWriteString("String", "WinLottery4Msg", Settings.WinLottery4Msg);
            Settings.WinLottery5Msg = ReadWriteString("String", "WinLottery5Msg", Settings.WinLottery5Msg);
            Settings.WinLottery6Msg = ReadWriteString("String", "WinLottery6Msg", Settings.WinLottery6Msg);
            Settings.NotWinLotteryMsg = ReadWriteString("String", "NotWinLotteryMsg", Settings.NotWinLotteryMsg);
            Settings.WeaptonMakeLuck = ReadWriteString("String", "WeaptonMakeLuck", Settings.WeaptonMakeLuck);
            Settings.WeaptonNotMakeLuck = ReadWriteString("String", "WeaptonNotMakeLuck", Settings.WeaptonNotMakeLuck);
            Settings.TheWeaponIsCursed = ReadWriteString("String", "TheWeaponIsCursed", Settings.TheWeaponIsCursed);
            Settings.CanotTakeOffItem = ReadWriteString("String", "CanotTakeOffItem", Settings.CanotTakeOffItem);
            Settings.JoinGroup = ReadWriteString("String", "JoinGroupMsg", Settings.JoinGroup);
            Settings.TryModeCanotUseStorage = ReadWriteString("String", "TryModeCanotUseStorage", Settings.TryModeCanotUseStorage);
            Settings.CanotGetItems = ReadWriteString("String", "CanotGetItemsMsg", Settings.CanotGetItems);
            Settings.YourIPaddrDenyLogon = ReadWriteString("String", "YourIPaddrDenyLogon", Settings.YourIPaddrDenyLogon);
            Settings.YourAccountDenyLogon = ReadWriteString("String", "YourAccountDenyLogon", Settings.YourAccountDenyLogon);
            Settings.YourChrNameDenyLogon = ReadWriteString("String", "YourChrNameDenyLogon", Settings.YourChrNameDenyLogon);
            Settings.CanotPickUpItem = ReadWriteString("String", "CanotPickUpItem", Settings.CanotPickUpItem);
            Settings.QUERYBAGITEMS = ReadWriteString("String", "sQUERYBAGITEMS", Settings.QUERYBAGITEMS);
            Settings.CanotSendmsg = ReadWriteString("String", "CanotSendmsg", Settings.CanotSendmsg);
            Settings.UserDenyWhisperMsg = ReadWriteString("String", "UserDenyWhisperMsg", Settings.UserDenyWhisperMsg);
            Settings.UserNotOnLine = ReadWriteString("String", "UserNotOnLine", Settings.UserNotOnLine);
            Settings.RevivalRecoverMsg = ReadWriteString("String", "RevivalRecoverMsg", Settings.RevivalRecoverMsg);
            Settings.ClientVersionTooOld = ReadWriteString("String", "ClientVersionTooOld", Settings.ClientVersionTooOld);
            Settings.CastleGuildName = ReadWriteString("String", "CastleGuildName", Settings.CastleGuildName);
            Settings.NoCastleGuildName = ReadWriteString("String", "NoCastleGuildName", Settings.NoCastleGuildName);
            Settings.WarrReNewName = ReadWriteString("String", "WarrReNewName", Settings.WarrReNewName);
            Settings.WizardReNewName = ReadWriteString("String", "WizardReNewName", Settings.WizardReNewName);
            Settings.TaosReNewName = ReadWriteString("String", "TaosReNewName", Settings.TaosReNewName);
            Settings.RankLevelName = ReadWriteString("String", "RankLevelName", Settings.RankLevelName);
            Settings.ManDearName = ReadWriteString("String", "ManDearName", Settings.ManDearName);
            Settings.WoManDearName = ReadWriteString("String", "WoManDearName", Settings.WoManDearName);
            Settings.MasterName = ReadWriteString("String", "MasterName", Settings.MasterName);
            Settings.NoMasterName = ReadWriteString("String", "NoMasterName", Settings.NoMasterName);
            Settings.HumanShowName = ReadWriteString("String", "HumanShowName", Settings.HumanShowName);
            Settings.ChangePermissionMsg = ReadWriteString("String", "ChangePermissionMsg", Settings.ChangePermissionMsg);
            Settings.ChangeKillMonExpRateMsg = ReadWriteString("String", "ChangeKillMonExpRateMsg", Settings.ChangeKillMonExpRateMsg);
            Settings.ChangePowerRateMsg = ReadWriteString("String", "ChangePowerRateMsg", Settings.ChangePowerRateMsg);
            Settings.ChangeMemberLevelMsg = ReadWriteString("String", "ChangeMemberLevelMsg", Settings.ChangeMemberLevelMsg);
            Settings.ChangeMemberTypeMsg = ReadWriteString("String", "ChangeMemberTypeMsg", Settings.ChangeMemberTypeMsg);
            Settings.ScriptChangeHumanHPMsg = ReadWriteString("String", "ScriptChangeHumanHPMsg", Settings.ScriptChangeHumanHPMsg);
            Settings.ScriptChangeHumanMPMsg = ReadWriteString("String", "ScriptChangeHumanMPMsg", Settings.ScriptChangeHumanMPMsg);
            Settings.DisableSayMsg = ReadWriteString("String", "YouCanotDisableSayMsg", Settings.DisableSayMsg);
            Settings.OnlineCountMsg = ReadWriteString("String", "OnlineCountMsg", Settings.OnlineCountMsg);
            Settings.TotalOnlineCountMsg = ReadWriteString("String", "TotalOnlineCountMsg", Settings.TotalOnlineCountMsg);
            Settings.YouNeedLevelMsg = ReadWriteString("String", "YouNeedLevelSendMsg", Settings.YouNeedLevelMsg);
            Settings.ThisMapDisableSendCyCyMsg = ReadWriteString("String", "ThisMapDisableSendCyCyMsg", Settings.ThisMapDisableSendCyCyMsg);
            Settings.YouCanSendCyCyLaterMsg = ReadWriteString("String", "YouCanSendCyCyLaterMsg", Settings.YouCanSendCyCyLaterMsg);
            Settings.YouIsDisableSendMsg = ReadWriteString("String", "YouIsDisableSendMsg", Settings.YouIsDisableSendMsg);
            Settings.YouMurderedMsg = ReadWriteString("String", "YouMurderedMsg", Settings.YouMurderedMsg);
            Settings.YouKilledByMsg = ReadWriteString("String", "YouKilledByMsg", Settings.YouKilledByMsg);
            Settings.YouprotectedByLawOfDefense = ReadWriteString("String", "YouprotectedByLawOfDefense", Settings.YouprotectedByLawOfDefense);

            /*CommandHelp.EnableDearRecall = ReadWriteString("String", "EnableDearRecall", CommandHelp.EnableDearRecall);
            CommandHelp.DisableDearRecall = ReadWriteString("String", "DisableDearRecall", CommandHelp.DisableDearRecall);
            CommandHelp.EnableMasterRecall = ReadWriteString("String", "EnableMasterRecall", CommandHelp.EnableMasterRecall);
            CommandHelp.DisableMasterRecall = ReadWriteString("String", "DisableMasterRecall", CommandHelp.DisableMasterRecall);
            CommandHelp.NowCurrDateTime = ReadWriteString("String", "NowCurrDateTime", CommandHelp.NowCurrDateTime);
            CommandHelp.EnableHearWhisper = ReadWriteString("String", "EnableHearWhisper", CommandHelp.EnableHearWhisper);
            CommandHelp.DisableHearWhisper = ReadWriteString("String", "DisableHearWhisper", CommandHelp.DisableHearWhisper);
            CommandHelp.EnableShoutMsg = ReadWriteString("String", "EnableShoutMsg", CommandHelp.EnableShoutMsg);
            CommandHelp.DisableShoutMsg = ReadWriteString("String", "DisableShoutMsg", CommandHelp.DisableShoutMsg);
            CommandHelp.EnableDealMsg = ReadWriteString("String", "EnableDealMsg", CommandHelp.EnableDealMsg);
            CommandHelp.DisableDealMsg = ReadWriteString("String", "DisableDealMsg", CommandHelp.DisableDealMsg);
            CommandHelp.EnableGuildChat = ReadWriteString("String", "EnableGuildChat", CommandHelp.EnableGuildChat);
            CommandHelp.DisableGuildChat = ReadWriteString("String", "DisableGuildChat", CommandHelp.DisableGuildChat);
            CommandHelp.EnableJoinGuild = ReadWriteString("String", "EnableJoinGuild", CommandHelp.EnableJoinGuild);
            CommandHelp.DisableJoinGuild = ReadWriteString("String", "DisableJoinGuild", CommandHelp.DisableJoinGuild);
            CommandHelp.EnableAuthAllyGuild = ReadWriteString("String", "EnableAuthAllyGuild", CommandHelp.EnableAuthAllyGuild);
            CommandHelp.DisableAuthAllyGuild = ReadWriteString("String", "DisableAuthAllyGuild", CommandHelp.DisableAuthAllyGuild);
            CommandHelp.EnableGroupRecall = ReadWriteString("String", "EnableGroupRecall", CommandHelp.EnableGroupRecall);
            CommandHelp.DisableGroupRecall = ReadWriteString("String", "DisableGroupRecall", CommandHelp.DisableGroupRecall);
            CommandHelp.EnableGuildRecall = ReadWriteString("String", "EnableGuildRecall", CommandHelp.EnableGuildRecall);
            CommandHelp.DisableGuildRecall = ReadWriteString("String", "DisableGuildRecall", CommandHelp.DisableGuildRecall);
            CommandHelp.PleaseInputPassword = ReadWriteString("String", "PleaseInputPassword", CommandHelp.PleaseInputPassword);
            CommandHelp.TheMapDisableMove = ReadWriteString("String", "TheMapDisableMove", CommandHelp.TheMapDisableMove);
            CommandHelp.TheMapNotFound = ReadWriteString("String", "TheMapNotFound", CommandHelp.TheMapNotFound);*/
        }
    }
}