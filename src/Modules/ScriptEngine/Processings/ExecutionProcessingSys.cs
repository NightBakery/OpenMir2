﻿using SystemModule;
using SystemModule.Common;
using SystemModule.Data;
using SystemModule.Enums;
using SystemModule.Packets.ClientPackets;

namespace ScriptModule
{
    /// <summary>
    /// 脚本命令执行处理模块
    /// </summary>
    public class ExecutionProcessingSys : ProcessingBase
    {
        /// <summary>
        /// 全局变量消息处理列表
        /// </summary>
        private static Dictionary<int, HandleExecutionMessage> ProcessExecutionMessage;
        private delegate void HandleExecutionMessage(INormNpc normNpc, IPlayerActor playerActor, QuestActionInfo questActionInfo, ref bool Success);

        private readonly IConfiguration configuration;

        public ExecutionProcessingSys(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void Initialize()
        {
            ProcessExecutionMessage = new Dictionary<int, HandleExecutionMessage>();
            ProcessExecutionMessage[(int)ExecutionCode.Set] = ActionOfSet;
            ProcessExecutionMessage[(int)ExecutionCode.ReSet] = ActionOfReSet;
            ProcessExecutionMessage[(int)ExecutionCode.SetOpen] = ActionOfSetOpen;
            ProcessExecutionMessage[(int)ExecutionCode.SetUnit] = ActionOfSetUnit;
            ProcessExecutionMessage[(int)ExecutionCode.ResetUnit] = ActionOfResetUnit;
            ProcessExecutionMessage[(int)ExecutionCode.Give] = ActionOfGiveItem;
            ProcessExecutionMessage[(int)ExecutionCode.ThrowItem] = ActionOfThrowitem;
            ProcessExecutionMessage[(int)ExecutionCode.RandomMove] = ActionOfRandomMove;
            ProcessExecutionMessage[(int)ExecutionCode.ReCallMob] = ActionOfRecallmob;
            ProcessExecutionMessage[(int)ExecutionCode.Hairstyle] = ActionOfChangeHairStyle;
            ProcessExecutionMessage[(int)ExecutionCode.ReCallgroupMembers] = ActionOfRecallGroupMembers;
            ProcessExecutionMessage[(int)ExecutionCode.ClearNameList] = ActionOfClearList;
            ProcessExecutionMessage[(int)ExecutionCode.Mapting] = ActionOfMapTing;
            ProcessExecutionMessage[(int)ExecutionCode.ChangeLevel] = ActionOfChangeLevel;
            ProcessExecutionMessage[(int)ExecutionCode.Marry] = ActionOfMarry;
            ProcessExecutionMessage[(int)ExecutionCode.Master] = ActionOfMaster;
            ProcessExecutionMessage[(int)ExecutionCode.UnMaster] = ActionOfUnMaster;
            ProcessExecutionMessage[(int)ExecutionCode.UnMarry] = ActionOfUnMarry;
            ProcessExecutionMessage[(int)ExecutionCode.GetMarry] = ActionOfGetMarry;
            ProcessExecutionMessage[(int)ExecutionCode.GetMaster] = ActionOfGetMaster;
            ProcessExecutionMessage[(int)ExecutionCode.ClearSkill] = ActionOfClearSkill;
            ProcessExecutionMessage[(int)ExecutionCode.DelnoJobSkill] = ActionOfDelNoJobSkill;
            ProcessExecutionMessage[(int)ExecutionCode.DelSkill] = ActionOfDelSkill;
            ProcessExecutionMessage[(int)ExecutionCode.AddSkill] = ActionOfAddSkill;
            ProcessExecutionMessage[(int)ExecutionCode.SkillLevel] = ActionOfSkillLevel;
            ProcessExecutionMessage[(int)ExecutionCode.ChangePkPoint] = ActionOfChangePkPoint;
            ProcessExecutionMessage[(int)ExecutionCode.ChangeExp] = ActionOfChangeExp;
            ProcessExecutionMessage[(int)ExecutionCode.ChangeJob] = ActionOfChangeJob;
            ProcessExecutionMessage[(int)ExecutionCode.Mission] = ActionOfMission;
            ProcessExecutionMessage[(int)ExecutionCode.MobPlace] = ActionOfMobPlace;
            ProcessExecutionMessage[(int)ExecutionCode.SetMemberType] = ActionOfSetMemberType;
            ProcessExecutionMessage[(int)ExecutionCode.SetMemberLevel] = ActionOfSetMemberLevel;
            ProcessExecutionMessage[(int)ExecutionCode.GameGold] = ActionOfGameGold;
            ProcessExecutionMessage[(int)ExecutionCode.GamePoint] = ActionOfGamePoint;
            ProcessExecutionMessage[(int)ExecutionCode.OffLine] = ActionOfOffLine;
            ProcessExecutionMessage[(int)ExecutionCode.AutoAddGameGold] = ActionOfAutoAddGameGold;
            ProcessExecutionMessage[(int)ExecutionCode.AutoSubGameGold] = ActionOfAutoSubGameGold;
            ProcessExecutionMessage[(int)ExecutionCode.ChangeNameColor] = ActionOfChangeNameColor;
            ProcessExecutionMessage[(int)ExecutionCode.ClearPassword] = ActionOfClearPassword;
            ProcessExecutionMessage[(int)ExecutionCode.Renewlevel] = ActionOfReNewLevel;
            ProcessExecutionMessage[(int)ExecutionCode.KillSlave] = ActionOfKillSlave;
            ProcessExecutionMessage[(int)ExecutionCode.ChangeGender] = ActionOfChangeGender;
            ProcessExecutionMessage[(int)ExecutionCode.KillMonExpRate] = ActionOfKillMonExpRate;
            ProcessExecutionMessage[(int)ExecutionCode.PowerRate] = ActionOfPowerRate;
            ProcessExecutionMessage[(int)ExecutionCode.ChangePerMission] = ActionOfChangePerMission;
            ProcessExecutionMessage[(int)ExecutionCode.BonusPoint] = ActionOfBonusPoint;
            ProcessExecutionMessage[(int)ExecutionCode.Restrenewlevel] = ActionOfRestReNewLevel;
            ProcessExecutionMessage[(int)ExecutionCode.DelMarry] = ActionOfDelMarry;
            ProcessExecutionMessage[(int)ExecutionCode.DelMaster] = ActionOfDelMaster;
            ProcessExecutionMessage[(int)ExecutionCode.CreditPoint] = ActionOfChangeCreditPoint;
            ProcessExecutionMessage[(int)ExecutionCode.ClearNeedItems] = ActionOfClearNeedItems;
            ProcessExecutionMessage[(int)ExecutionCode.ClearMakeItems] = ActionOfClearMakeItems;
            ProcessExecutionMessage[(int)ExecutionCode.SetSendMsgFlag] = ActionOfSetSendMsgFlag;
            ProcessExecutionMessage[(int)ExecutionCode.UpgradeItems] = ActionOfUpgradeItems;
            ProcessExecutionMessage[(int)ExecutionCode.UpgradeItemSex] = ActionOfUpgradeItemsEx;
            ProcessExecutionMessage[(int)ExecutionCode.MonGenex] = ActionOfMonGenEx;
            ProcessExecutionMessage[(int)ExecutionCode.ClearMapMon] = ActionOfClearMapMon;
            ProcessExecutionMessage[(int)ExecutionCode.SetMapMode] = ActionOfSetMapMode;
            ProcessExecutionMessage[(int)ExecutionCode.PvpZone] = ActionOfPkZone;
            ProcessExecutionMessage[(int)ExecutionCode.RestBonusPoint] = ActionOfRestBonusPoint;
            ProcessExecutionMessage[(int)ExecutionCode.TakeCastleGold] = ActionOfTakeCastleGold;
            ProcessExecutionMessage[(int)ExecutionCode.HumanHp] = ActionOfHumanHp;
            ProcessExecutionMessage[(int)ExecutionCode.HumanMp] = ActionOfHumanMp;
            ProcessExecutionMessage[(int)ExecutionCode.BuildPoint] = ActionOfGuildBuildPoint;
            ProcessExecutionMessage[(int)ExecutionCode.AuraePoint] = ActionOfGuildAuraePoint;
            ProcessExecutionMessage[(int)ExecutionCode.StabilityPoint] = ActionOfGuildstabilityPoint;
            ProcessExecutionMessage[(int)ExecutionCode.FlourishPoint] = ActionOfGuildFlourishPoint;
            ProcessExecutionMessage[(int)ExecutionCode.OpenMagicbox] = ActionOfOpenMagicBox;
            ProcessExecutionMessage[(int)ExecutionCode.SetRankLevelName] = ActionOfSetRankLevelName;
            ProcessExecutionMessage[(int)ExecutionCode.GmExecute] = ActionOfGmExecute;
            ProcessExecutionMessage[(int)ExecutionCode.GuildChiefItemCount] = ActionOfGuildChiefItemCount;
            ProcessExecutionMessage[(int)ExecutionCode.AddNameDateList] = ActionOfAddNameDateList;
            ProcessExecutionMessage[(int)ExecutionCode.DelNameDateList] = ActionOfDelNameDateList;
            ProcessExecutionMessage[(int)ExecutionCode.MobFireburn] = ActionOfMobFireBurn;
            ProcessExecutionMessage[(int)ExecutionCode.MessageBox] = ActionOfMessageBox;
            ProcessExecutionMessage[(int)ExecutionCode.SetscriptFlag] = ActionOfSetScriptFlag;
            ProcessExecutionMessage[(int)ExecutionCode.SetautogetExp] = ActionOfAutoGetExp;
            ProcessExecutionMessage[(int)ExecutionCode.Var] = ActionOfVar;
            ProcessExecutionMessage[(int)ExecutionCode.LoadVar] = ActionOfLoadVar;
            ProcessExecutionMessage[(int)ExecutionCode.SaveVar] = ActionOfSaveVar;
            ProcessExecutionMessage[(int)ExecutionCode.CalcVar] = ActionOfCalcVar;
            ProcessExecutionMessage[(int)ExecutionCode.GuildReCall] = ActionOfGuildRecall;
            ProcessExecutionMessage[(int)ExecutionCode.GroupAddList] = ActionOfGroupAddList;
            ProcessExecutionMessage[(int)ExecutionCode.ClearList] = ActionOfClearList;
            ProcessExecutionMessage[(int)ExecutionCode.GroupReCall] = ActionOfGroupRecall;
            ProcessExecutionMessage[(int)ExecutionCode.GroupMoveMap] = ActionOfGroupMoveMap;
            ProcessExecutionMessage[(int)ExecutionCode.RepairAll] = ActionOfRepairAllItem;
            ProcessExecutionMessage[(int)ExecutionCode.ChangeMode] = ActionOfChangeMode;
            ProcessExecutionMessage[(int)ExecutionCode.Kill] = ActionOfKill;
            ProcessExecutionMessage[(int)ExecutionCode.Kick] = ActionOfKick;
            ProcessExecutionMessage[(int)ExecutionCode.DelayGoto] = ActionOfDelayCall;
            ProcessExecutionMessage[(int)ExecutionCode.OpenYbDeal] = ActionOfOpenSaleDeal;
            ProcessExecutionMessage[(int)ExecutionCode.QueryYbSell] = ActionOfQuerySaleSell;
            ProcessExecutionMessage[(int)ExecutionCode.QueryYbDeal] = ActionOfQueryTrustDeal;
            ProcessExecutionMessage[(int)ExecutionCode.LineMsg] = ActionOfLineMsg;
            ProcessExecutionMessage[(int)ExecutionCode.SendMsg] = ActionOfLineMsg;
            ProcessExecutionMessage[(int)ExecutionCode.QueryBagItems] = ActionOfQueryBagItems;
            ProcessExecutionMessage[(int)ExecutionCode.QueryValue] = ActionOfQueryValue;
            ProcessExecutionMessage[(int)ExecutionCode.KillSlaveName] = ActionOfKillSlaveName;
            ProcessExecutionMessage[(int)ExecutionCode.QueryItemDlg] = ActionOfQueryItemDlg;
            ProcessExecutionMessage[(int)ExecutionCode.UpgradeDlgItem] = ActionOfUpgradeDlgItem;
            ProcessExecutionMessage[(int)ExecutionCode.ExchangeMap] = ActionOfExchangeMap;
            ProcessExecutionMessage[(int)ExecutionCode.ReCallMap] = ActionOfReCallMap;
            ProcessExecutionMessage[(int)ExecutionCode.Close] = ActionOfClose;
            ProcessExecutionMessage[(int)ExecutionCode.MapMove] = ActionOfMapMove;
            ProcessExecutionMessage[(int)ExecutionCode.Map] = ActionOfMap;
            ProcessExecutionMessage[(int)ExecutionCode.MonClear] = ActionOfMonClear;
            ProcessExecutionMessage[(int)ExecutionCode.MonGen] = ActionOfMonGen;
            ProcessExecutionMessage[(int)ExecutionCode.TimereCall] = ActionOfTimereCall;
            ProcessExecutionMessage[(int)ExecutionCode.BreakTimereCall] = ActionOfBreakTimereCall;
            ProcessExecutionMessage[(int)ExecutionCode.PkPoint] = ActionOfPkPoint;
            ProcessExecutionMessage[(int)ExecutionCode.AddNameList] = ActionOfAddNameList;
            ProcessExecutionMessage[(int)ExecutionCode.DelNameList] = ActionOfDelNameList;
            ProcessExecutionMessage[(int)ExecutionCode.AddUserDate] = ActionOfAddUseDateList;
            ProcessExecutionMessage[(int)ExecutionCode.DelUserDate] = ActionOfDelUseDateList;
            ProcessExecutionMessage[(int)ExecutionCode.AddGuildList] = ActionOfAddGuildList;
            ProcessExecutionMessage[(int)ExecutionCode.DelGuildList] = ActionOfDelGuildList;
            ProcessExecutionMessage[(int)ExecutionCode.AddAccountList] = ActionOfAddAccountList;
            ProcessExecutionMessage[(int)ExecutionCode.DelAccountList] = ActionOfDelAccountList;
            ProcessExecutionMessage[(int)ExecutionCode.AddIpList] = ActionOfAddIpList;
            ProcessExecutionMessage[(int)ExecutionCode.DelIpList] = ActionOfDelIpList;
            ProcessExecutionMessage[(int)ExecutionCode.ClearDelayGoto] = ActionOfClearDelayGoto;
            ProcessExecutionMessage[(int)ExecutionCode.SetRandomNo] = ActionOfSetRandomNo;
            ProcessExecutionMessage[(int)ExecutionCode.PlayDice] = ActionOfPlayDice;
            ProcessExecutionMessage[(int)ExecutionCode.Exeaction] = ActionOfExeaction;
            ProcessExecutionMessage[(int)ExecutionCode.Dec] = ActionOfDecInteger;
            ProcessExecutionMessage[(int)ExecutionCode.Mov] = ActionOfMovData;
            ProcessExecutionMessage[(int)ExecutionCode.Inc] = ActionOfIncInteger;
            ProcessExecutionMessage[(int)ExecutionCode.Sum] = ActionOfSumData;
            ProcessExecutionMessage[(int)ExecutionCode.Div] = ActionOfDivData;
            ProcessExecutionMessage[(int)ExecutionCode.Mul] = ActionOfMulData;
            ProcessExecutionMessage[(int)ExecutionCode.Percent] = ActionOfPercentData;
            ProcessExecutionMessage[(int)ExecutionCode.Movr] = ActionOfMovrData;
        }

        public bool IsRegister(int cmdCode)
        {
            return ProcessExecutionMessage.ContainsKey(cmdCode);
        }

        public void Execute(INormNpc normNpc, IPlayerActor playerActor, QuestActionInfo questConditionInfo, ref bool success)
        {
            if (ProcessExecutionMessage.ContainsKey(questConditionInfo.nCmdCode))
            {
                ProcessExecutionMessage[questConditionInfo.nCmdCode](normNpc, playerActor,questConditionInfo, ref success);
            }
        }

        /// <summary>
        /// 取随机值赋给变量
        /// 拓展可以随机参数2到参数3之间的数
        /// </summary>
        /// <param name="IPlayerActor"></param>
        /// <param name="QuestActionInfo"></param>
        private void ActionOfMovrData(INormNpc normNpc, IPlayerActor playerActor, QuestActionInfo questActionInfo, ref bool Success)
        {
            string s34 = string.Empty;
            int n14;
            if (HUtil32.CompareLStr(questActionInfo.sParam1, "<$STR(", 6))
            {
                HUtil32.ArrestStringEx(questActionInfo.sParam1, "(", ")", ref s34);
                n14 = ModuleShare.GetValNameNo(s34);
            }
            else
            {
                n14 = ModuleShare.GetValNameNo(questActionInfo.sParam1);
            }
            if (n14 >= 0)
            {
                if (HUtil32.RangeInDefined(n14, 0, 99))
                {
                    if (questActionInfo.nParam3 > questActionInfo.nParam2)
                    {
                        playerActor.MNVal[n14] = questActionInfo.nParam2 + ModuleShare.RandomNumber.Random(questActionInfo.nParam3 - questActionInfo.nParam2);
                    }
                    else
                    {
                        playerActor.MNVal[n14] = ModuleShare.RandomNumber.Random(questActionInfo.nParam2);
                    }
                }
                else if (HUtil32.RangeInDefined(n14, 100, 119))
                {
                    if (questActionInfo.nParam3 > questActionInfo.nParam2)
                    {
                        configuration.Config.GlobalVal[n14 - 100] = questActionInfo.nParam2 + ModuleShare.RandomNumber.Random(questActionInfo.nParam3 - questActionInfo.nParam2);
                    }
                    else
                    {
                        configuration.Config.GlobalVal[n14 - 100] = ModuleShare.RandomNumber.Random(questActionInfo.nParam2);
                    }
                }
                else if (HUtil32.RangeInDefined(n14, 200, 299))
                {
                    if (questActionInfo.nParam3 > questActionInfo.nParam2)
                    {
                        playerActor.MDyVal[n14 - 200] = questActionInfo.nParam2 + ModuleShare.RandomNumber.Random(questActionInfo.nParam3 - questActionInfo.nParam2);
                    }
                    else
                    {
                        playerActor.MDyVal[n14 - 200] = ModuleShare.RandomNumber.Random(questActionInfo.nParam2);
                    }
                }
                else if (HUtil32.RangeInDefined(n14, 300, 399))
                {
                    if (questActionInfo.nParam3 > questActionInfo.nParam2)
                    {
                        playerActor.MNMval[n14 - 300] = questActionInfo.nParam2 + ModuleShare.RandomNumber.Random(questActionInfo.nParam3 - questActionInfo.nParam2);
                    }
                    else
                    {
                        playerActor.MNMval[n14 - 300] = ModuleShare.RandomNumber.Random(questActionInfo.nParam2);
                    }
                }
                else if (HUtil32.RangeInDefined(n14, 400, 499))
                {
                    if (questActionInfo.nParam3 > questActionInfo.nParam2)
                    {
                        configuration.Config.GlobaDyMval[n14 - 400] = questActionInfo.nParam2 + ModuleShare.RandomNumber.Random(questActionInfo.nParam3 - questActionInfo.nParam2);
                    }
                    else
                    {
                        configuration.Config.GlobaDyMval[n14 - 400] = ModuleShare.RandomNumber.Random(questActionInfo.nParam2);
                    }
                }
                else if (HUtil32.RangeInDefined(n14, 500, 599))
                {
                    if (questActionInfo.nParam3 > questActionInfo.nParam2)
                    {
                        playerActor.MNInteger[n14 - 500] = questActionInfo.nParam2 + ModuleShare.RandomNumber.Random(questActionInfo.nParam3 - questActionInfo.nParam2);
                    }
                    else
                    {
                        playerActor.MNInteger[n14 - 500] = ModuleShare.RandomNumber.Random(questActionInfo.nParam2);
                    }
                }
                else if (HUtil32.RangeInDefined(n14, 800, 1199))
                {
                    if (questActionInfo.nParam3 > questActionInfo.nParam2)
                    {
                        configuration.Config.GlobalVal[n14 - 700] = questActionInfo.nParam2 + ModuleShare.RandomNumber.Random(questActionInfo.nParam3 - questActionInfo.nParam2);
                    }
                    else
                    {
                        configuration.Config.GlobalVal[n14 - 700] = ModuleShare.RandomNumber.Random(questActionInfo.nParam2);
                    }
                }
                else
                {
                    ScriptActionError(playerActor,"", questActionInfo, ExecutionCode.Movr);
                }
            }
            else
            {
                ScriptActionError(playerActor,"", questActionInfo, ExecutionCode.Movr);
            }
        }

        private void ActionOfMovData(INormNpc normNpc, IPlayerActor playerActor, QuestActionInfo questActionInfo, ref bool Success)
        {
            string sParam1 = string.Empty;
            string sParam2 = string.Empty;
            string sParam3 = string.Empty;
            string sValue = string.Empty;
            int nValue = 0;
            int nDataType = 0;
            const string sVarFound = "变量{0}不存在，变量类型:{1}";
            if (HUtil32.CompareLStr(questActionInfo.sParam1, "<$STR(", 6))
            {
                HUtil32.ArrestStringEx(questActionInfo.sParam1, "(", ")", ref sParam1);
            }
            else
            {
                sParam1 = questActionInfo.sParam1;
            }
            if (HUtil32.CompareLStr(questActionInfo.sParam2, "<$STR(", 6))
            {
                HUtil32.ArrestStringEx(questActionInfo.sParam2, "(", ")", ref sParam2);
            }
            else
            {
                sParam2 = questActionInfo.sParam2;
            }
            if (HUtil32.CompareLStr(questActionInfo.sParam3, "<$STR(", 6))
            {
                HUtil32.ArrestStringEx(questActionInfo.sParam3, "(", ")", ref sParam3);
            }
            else
            {
                sParam3 = questActionInfo.sParam3;
            }
            if (string.IsNullOrEmpty(sParam1))
            {
                ScriptActionError(playerActor,"", questActionInfo, ExecutionCode.Mov);
                return;
            }
            switch (GetMovDataType(questActionInfo))
            {
                case 0:
                    if (GetMovDataHumanInfoValue(normNpc, playerActor,sParam3, ref sValue, ref nValue, ref nDataType))
                    {
                        if (!SetMovDataDynamicVarValue(playerActor,sParam1, sParam2, sValue, nValue, nDataType))
                        {
                            ScriptActionError(playerActor,string.Format(sVarFound, sParam1, sParam2), questActionInfo, ExecutionCode.Mov);
                        }
                    }
                    else
                    {
                        ScriptActionError(playerActor,"", questActionInfo, ExecutionCode.Mov);
                    }
                    break;
                case 1:
                    if (GetMovDataValNameValue(playerActor,sParam3, ref sValue, ref nValue, ref nDataType))
                    {
                        if (!SetMovDataDynamicVarValue(playerActor,sParam1, sParam2, sValue, nValue, nDataType))
                        {
                            ScriptActionError(playerActor,string.Format(sVarFound, sParam1, sParam2), questActionInfo, ExecutionCode.Mov);
                        }
                    }
                    else
                    {
                        ScriptActionError(playerActor,"", questActionInfo, ExecutionCode.Mov);
                    }
                    break;
                case 2:
                    if (!SetMovDataDynamicVarValue(playerActor,sParam1, sParam2, questActionInfo.sParam3, questActionInfo.nParam3, 1))
                    {
                        ScriptActionError(playerActor,string.Format(sVarFound, sParam1, sParam2), questActionInfo, ExecutionCode.Mov);
                    }
                    break;
                case 3:
                    if (!SetMovDataDynamicVarValue(playerActor,sParam1, sParam2, questActionInfo.sParam3, questActionInfo.nParam3, 0))
                    {
                        ScriptActionError(playerActor,string.Format(sVarFound, sParam1, sParam2), questActionInfo, ExecutionCode.Mov);
                    }
                    break;
                case 4:
                    if (GetMovDataHumanInfoValue(normNpc, playerActor,sParam2, ref sValue, ref nValue, ref nDataType))
                    {
                        if (!SetMovDataValNameValue(playerActor,sParam1, sValue, nValue, nDataType))
                        {
                            ScriptActionError(playerActor,"", questActionInfo, ExecutionCode.Mov);
                        }
                    }
                    else
                    {
                        ScriptActionError(playerActor,"", questActionInfo, ExecutionCode.Mov);
                    }
                    break;
                case 5:
                    if (GetMovDataValNameValue(playerActor,sParam2, ref sValue, ref nValue, ref nDataType))
                    {
                        if (!SetMovDataValNameValue(playerActor,sParam1, sValue, nValue, nDataType))
                        {
                            ScriptActionError(playerActor,"", questActionInfo, ExecutionCode.Mov);
                        }
                    }
                    else
                    {
                        ScriptActionError(playerActor,"", questActionInfo, ExecutionCode.Mov);
                    }
                    break;
                case 6:
                    if (GetMovDataDynamicVarValue(playerActor,sParam2, sParam3, ref sValue, ref nValue, ref nDataType))
                    {
                        if (!SetMovDataValNameValue(playerActor,sParam1, sValue, nValue, nDataType))
                        {
                            ScriptActionError(playerActor,"", questActionInfo, ExecutionCode.Mov);
                        }
                    }
                    else
                    {
                        ScriptActionError(playerActor,string.Format(sVarFound, sParam2, sParam3), questActionInfo, ExecutionCode.Mov);
                    }
                    break;
                case 7:
                    if (GetMovDataValNameValue(playerActor,sParam1, ref sValue, ref nValue, ref nDataType))
                    {
                        if ((!string.IsNullOrEmpty(sParam2)) && (sParam2[0] == '<') && (sParam2[1] == '$'))//  支持:MOV A14 <$USERALLNAME>\天下第一战士 的传值
                        {
                            GetMovDataHumanInfoValue(normNpc, playerActor,sParam2, ref sValue, ref nValue, ref nDataType);// 取人物信息
                            sValue = sValue + sParam2.Substring(sParam2.IndexOf("\\", StringComparison.CurrentCultureIgnoreCase) - 1, sParam2.Length - sParam2.IndexOf("\\", StringComparison.CurrentCultureIgnoreCase) + 1);
                            if (!SetMovDataValNameValue(playerActor,sParam1, sValue, nValue, nDataType))
                            {
                                ScriptActionError(playerActor,"", questActionInfo, ExecutionCode.Mov);
                                return;
                            }
                        }
                        else
                        {
                            if (!SetMovDataValNameValue(playerActor,sParam1, questActionInfo.sParam2, questActionInfo.nParam2, nDataType))
                            {
                                ScriptActionError(playerActor,"", questActionInfo, ExecutionCode.Mov);
                                return;
                            }
                        }
                    }
                    else
                    {
                        ScriptActionError(playerActor,"", questActionInfo, ExecutionCode.Mov);
                    }
                    break;
                default:
                    ScriptActionError(playerActor,"", questActionInfo, ExecutionCode.Mov);
                    break;
            }
        }

        private void ActionOfIncInteger(INormNpc normNpc, IPlayerActor playerActor, QuestActionInfo questActionInfo, ref bool Success)
        {
            int n14;
            int n3C = 0;
            string s01 = string.Empty;
            DynamicVar DynamicVar;
            Dictionary<string, DynamicVar> DynamicVarList;
            string sName = string.Empty;
            bool boVarFound;
            string sParam1 = string.Empty;
            string sParam2 = string.Empty;
            string sParam3 = string.Empty;
            const string sVarFound = "变量{0}不存在，变量类型:{1}";
            const string sVarTypeError = "变量类型错误，错误类型:{0} 当前支持类型(HUMAN、GUILD、GLOBAL)";
            int n10 = 0;
            if (HUtil32.CompareLStr(questActionInfo.sParam1, "<$STR(", 6))
            {
                HUtil32.ArrestStringEx(questActionInfo.sParam1, "(", ")", ref sParam1);
            }
            else
            {
                sParam1 = questActionInfo.sParam1;
            }
            if (HUtil32.CompareLStr(questActionInfo.sParam2, "<$STR(", 6))
            {
                HUtil32.ArrestStringEx(questActionInfo.sParam2, "(", ")", ref sParam2);
            }
            else
            {
                sParam2 = questActionInfo.sParam2;
            }
            if (HUtil32.CompareLStr(questActionInfo.sParam3, "<$STR(", 6))
            {
                HUtil32.ArrestStringEx(questActionInfo.sParam3, "(", ")", ref sParam3);
            }
            else
            {
                sParam3 = questActionInfo.sParam3;
            }
            if ((string.IsNullOrEmpty(sParam1)) || (string.IsNullOrEmpty(sParam2)))
            {
                ScriptActionError(playerActor,"", questActionInfo, ExecutionCode.Inc);
                return;
            }
            if (!string.IsNullOrEmpty(sParam3))
            {
                if ((!HUtil32.IsVarNumber(sParam1)) && HUtil32.IsVarNumber(sParam2))
                {
                    boVarFound = false;
                    DynamicVarList = GetDynamicVarMap(playerActor,sParam2, ref sName);
                    if (DynamicVarList == null)
                    {
                        ScriptActionError(playerActor,string.Format(sVarTypeError, sParam2), questActionInfo, ExecutionCode.Inc);
                        return;
                    }
                    if (DynamicVarList.TryGetValue(sParam3, out DynamicVar))
                    {
                        switch (DynamicVar.VarType)
                        {
                            case VarType.Integer:
                                n3C = DynamicVar.nInternet;
                                break;
                            case VarType.String:
                                s01 = DynamicVar.sString;
                                break;
                        }
                        boVarFound = true;
                    }
                    if (!boVarFound)
                    {
                        ScriptActionError(playerActor,string.Format(sVarFound, sParam3, sParam2), questActionInfo, ExecutionCode.Inc);
                        return;
                    }
                    n14 = ModuleShare.GetValNameNo(sParam1);
                    if (n14 >= 0)
                    {
                        if (HUtil32.RangeInDefined(n14, 0, 99))
                        {
                            if (n3C > 1)
                            {
                                playerActor.MNVal[n14] += n3C;
                            }
                            else
                            {
                                playerActor.MNVal[n14]++;
                            }
                        }
                        else if (HUtil32.RangeInDefined(n14, 100, 199))
                        {
                            if (n3C > 1)
                            {
                                configuration.Config.GlobalVal[n14 - 100] += n3C;
                            }
                            else
                            {
                                configuration.Config.GlobalVal[n14 - 100]++;
                            }
                        }
                        else if (HUtil32.RangeInDefined(n14, 200, 299))
                        {
                            if (n3C > 1)
                            {
                                playerActor.MDyVal[n14 - 200] += n3C;
                            }
                            else
                            {
                                playerActor.MDyVal[n14 - 200]++;
                            }
                        }
                        else if (HUtil32.RangeInDefined(n14, 300, 399))
                        {
                            if (n3C > 1)
                            {
                                playerActor.MNMval[n14 - 300] += n3C;
                            }
                            else
                            {
                                playerActor.MNMval[n14 - 300]++;
                            }
                        }
                        else if (HUtil32.RangeInDefined(n14, 400, 499))
                        {
                            if (n3C > 1)
                            {
                                configuration.Config.GlobaDyMval[n14 - 400] += n3C;
                            }
                            else
                            {
                                configuration.Config.GlobaDyMval[n14 - 400]++;
                            }
                        }
                        else if (HUtil32.RangeInDefined(n14, 500, 599))
                        {
                            if (n3C > 1)
                            {
                                playerActor.MNInteger[n14 - 500] += n3C;
                            }
                            else
                            {
                                playerActor.MNInteger[n14 - 500]++;
                            }
                        }
                        else if (HUtil32.RangeInDefined(n14, 600, 699))
                        {
                            playerActor.MSString[n14 - 600] = playerActor.MSString[n14 - 600] + s01;
                        }
                        else if (HUtil32.RangeInDefined(n14, 700, 799))
                        {
                            configuration.Config.GlobalAVal[n14 - 700] = configuration.Config.GlobalAVal[n14 - 700] + s01;
                        }
                        else if (HUtil32.RangeInDefined(n14, 800, 1199)) // G变量
                        {
                            if (n3C > 1)
                            {
                                configuration.Config.GlobalVal[n14 - 700] += n3C;
                            }
                            else
                            {
                                configuration.Config.GlobalVal[n14 - 700]++;
                            }
                        }
                        else if (HUtil32.RangeInDefined(n14, 1200, 1599)) // A变量
                        {
                            configuration.Config.GlobalAVal[n14 - 1100] = configuration.Config.GlobalAVal[n14 - 1100] + s01;
                        }
                        else
                        {
                            ScriptActionError(playerActor,"", questActionInfo, ExecutionCode.Inc);
                        }
                    }
                    else
                    {
                        ScriptActionError(playerActor,"", questActionInfo, ExecutionCode.Inc);
                        return;
                    }
                    return;
                }
                if (HUtil32.IsVarNumber(sParam1) && (!HUtil32.IsVarNumber(sParam2)))
                {
                    if ((!string.IsNullOrEmpty(sParam3)) && (!HUtil32.IsStringNumber(sParam3)))
                    {
                        n14 = ModuleShare.GetValNameNo(sParam3);
                        if (n14 >= 0)
                        {
                            if (HUtil32.RangeInDefined(n14, 0, 99))
                            {
                                n3C = playerActor.MNVal[n14];
                            }
                            else if (HUtil32.RangeInDefined(n14, 100, 199))
                            {
                                n3C = configuration.Config.GlobalVal[n14 - 100];
                            }
                            else if (HUtil32.RangeInDefined(n14, 200, 299))
                            {
                                n3C = playerActor.MDyVal[n14 - 200];
                            }
                            else if (HUtil32.RangeInDefined(n14, 300, 399))
                            {
                                n3C = playerActor.MNMval[n14 - 300];
                            }
                            else if (HUtil32.RangeInDefined(n14, 400, 499))
                            {
                                n3C = configuration.Config.GlobaDyMval[n14 - 400];
                            }
                            else if (HUtil32.RangeInDefined(n14, 500, 599))
                            {
                                n3C = playerActor.MNInteger[n14 - 500];
                            }
                            else if (HUtil32.RangeInDefined(n14, 600, 699))
                            {
                                s01 = playerActor.MSString[n14 - 600];
                            }
                            else if (HUtil32.RangeInDefined(n14, 700, 799))
                            {
                                s01 = configuration.Config.GlobalAVal[n14 - 700];
                            }
                            else if (HUtil32.RangeInDefined(n14, 800, 1199)) // G变量
                            {
                                n3C = configuration.Config.GlobalVal[n14 - 700];
                            }
                            else if (HUtil32.RangeInDefined(n14, 1200, 1599)) // A变量
                            {
                                s01 = configuration.Config.GlobalAVal[n14 - 1100];
                            }
                            else
                            {
                                ScriptActionError(playerActor,"", questActionInfo, ExecutionCode.Inc);
                            }
                        }
                        else
                        {
                            s01 = sParam3;
                        }
                    }
                    else
                    {
                        n3C = questActionInfo.nParam3;
                    }
                    boVarFound = false;
                    DynamicVarList = GetDynamicVarMap(playerActor,sParam1, ref sName);
                    if (DynamicVarList == null)
                    {
                        ScriptActionError(playerActor,string.Format(sVarTypeError, sParam1), questActionInfo, ExecutionCode.Inc);
                        return;
                    }
                    if (DynamicVarList.TryGetValue(sParam2, out DynamicVar))
                    {
                        switch (DynamicVar.VarType)
                        {
                            case VarType.Integer:
                                if (n3C > 1)
                                {
                                    DynamicVar.nInternet += n3C;
                                }
                                else
                                {
                                    DynamicVar.nInternet++;
                                }
                                break;
                            case VarType.String:
                                DynamicVar.sString = DynamicVar.sString + s01;
                                break;
                        }
                        boVarFound = true;
                    }
                    if (!boVarFound)
                    {
                        ScriptActionError(playerActor,string.Format(sVarFound, sParam2, sParam1), questActionInfo, ExecutionCode.Inc);
                        return;
                    }
                    return;
                }
                if (n10 == 0)
                {
                    ScriptActionError(playerActor,"", questActionInfo, ExecutionCode.Inc);
                }
            }
            else
            {
                if (((!string.IsNullOrEmpty(sParam2))) && (!HUtil32.IsStringNumber(sParam2)))
                {
                    // 获取第2个变量值
                    n14 = ModuleShare.GetValNameNo(sParam2);
                    if (n14 >= 0)
                    {
                        if (HUtil32.RangeInDefined(n14, 0, 99))
                        {
                            n3C = playerActor.MNVal[n14];
                        }
                        else if (HUtil32.RangeInDefined(n14, 100, 199))
                        {
                            n3C = configuration.Config.GlobalVal[n14 - 100];
                        }
                        else if (HUtil32.RangeInDefined(n14, 200, 299))
                        {
                            n3C = playerActor.MDyVal[n14 - 200];
                        }
                        else if (HUtil32.RangeInDefined(n14, 300, 399))
                        {
                            n3C = playerActor.MNMval[n14 - 300];
                        }
                        else if (HUtil32.RangeInDefined(n14, 400, 499))
                        {
                            n3C = configuration.Config.GlobaDyMval[n14 - 400];
                        }
                        else if (HUtil32.RangeInDefined(n14, 500, 599))
                        {
                            n3C = playerActor.MNInteger[n14 - 500];
                        }
                        else if (HUtil32.RangeInDefined(n14, 600, 699))
                        {
                            s01 = playerActor.MSString[n14 - 600];
                        }
                        else if (HUtil32.RangeInDefined(n14, 700, 799))
                        {
                            s01 = configuration.Config.GlobalAVal[n14 - 700];
                        }
                        else if (HUtil32.RangeInDefined(n14, 800, 1199)) // G变量
                        {
                            n3C = configuration.Config.GlobalVal[n14 - 700];
                        }
                        else if (HUtil32.RangeInDefined(n14, 1200, 1599)) // A变量
                        {
                            s01 = configuration.Config.GlobalAVal[n14 - 1100];
                        }
                        else
                        {
                            ScriptActionError(playerActor,"", questActionInfo, ExecutionCode.Inc);
                        }
                    }
                    else
                    {
                        n3C = HUtil32.StrToInt(GetLineVariableText(playerActor,sParam2), 0);// 个人变量
                        s01 = sParam2;
                    }
                }
                else
                {
                    n3C = questActionInfo.nParam2;
                }
                n14 = ModuleShare.GetValNameNo(sParam1);
                if (n14 >= 0)
                {
                    if (HUtil32.RangeInDefined(n14, 0, 99))
                    {
                        if (n3C > 1)
                        {
                            playerActor.MNVal[n14] += n3C;
                        }
                        else
                        {
                            playerActor.MNVal[n14]++;
                        }
                    }
                    else if (HUtil32.RangeInDefined(n14, 100, 199))
                    {
                        if (n3C > 1)
                        {
                            configuration.Config.GlobalVal[n14 - 100] += n3C;
                        }
                        else
                        {
                            configuration.Config.GlobalVal[n14 - 100]++;
                        }
                    }
                    else if (HUtil32.RangeInDefined(n14, 200, 299))
                    {
                        if (n3C > 1)
                        {
                            playerActor.MDyVal[n14 - 200] += n3C;
                        }
                        else
                        {
                            playerActor.MDyVal[n14 - 200]++;
                        }
                    }
                    else if (HUtil32.RangeInDefined(n14, 300, 399))
                    {
                        if (n3C > 1)
                        {
                            playerActor.MNMval[n14 - 300] += n3C;
                        }
                        else
                        {
                            playerActor.MNMval[n14 - 300]++;
                        }
                    }
                    else if (HUtil32.RangeInDefined(n14, 400, 499))
                    {
                        if (n3C > 1)
                        {
                            configuration.Config.GlobaDyMval[n14 - 400] += n3C;
                        }
                        else
                        {
                            configuration.Config.GlobaDyMval[n14 - 400]++;
                        }
                    }
                    else if (HUtil32.RangeInDefined(n14, 500, 599))
                    {
                        if (n3C > 1)
                        {
                            playerActor.MNInteger[n14 - 500] += n3C;
                        }
                        else
                        {
                            playerActor.MNInteger[n14 - 500]++;
                        }
                    }
                    else if (HUtil32.RangeInDefined(n14, 600, 699))
                    {
                        playerActor.MSString[n14 - 600] = playerActor.MSString[n14 - 600] + s01;
                    }
                    else if (HUtil32.RangeInDefined(n14, 700, 799))
                    {
                        configuration.Config.GlobalAVal[n14 - 700] = configuration.Config.GlobalAVal[n14 - 700] + s01;
                    }
                    else if (HUtil32.RangeInDefined(n14, 800, 1199)) // G变量
                    {
                        if (n3C > 1)
                        {
                            configuration.Config.GlobalVal[n14 - 700] += n3C;
                        }
                        else
                        {
                            configuration.Config.GlobalVal[n14 - 700]++;
                        }
                    }
                    else if (HUtil32.RangeInDefined(n14, 1200, 1599)) // A变量
                    {
                        configuration.Config.GlobalAVal[n14 - 1100] = configuration.Config.GlobalAVal[n14 - 1100] + s01;
                    }
                    else
                    {
                        ScriptActionError(playerActor,"", questActionInfo, ExecutionCode.Inc);
                    }
                }
                else
                {
                    ScriptActionError(playerActor,"", questActionInfo, ExecutionCode.Inc);
                    return;
                }
            }
        }

        /// <summary>
        /// 变量运算 除法  格式: DIV N1 N2 N3 即N1=N2/N3
        /// </summary>
        /// <param name="IPlayerActor"></param>
        /// <param name="QuestActionInfo"></param>
        private void ActionOfDivData(INormNpc normNpc, IPlayerActor playerActor, QuestActionInfo questActionInfo, ref bool Success)
        {
            string s34 = string.Empty;
            int n18 = 0;
            int n14 = HUtil32.StrToInt(GetLineVariableText(playerActor,questActionInfo.sParam2), -1);
            if (n14 < 0)
            {
                n14 = ModuleShare.GetValNameNo(questActionInfo.sParam2);
                if (n14 >= 0)
                {
                    if (HUtil32.RangeInDefined(n14, 0, 99))
                    {
                        n18 = playerActor.MNVal[n14];
                    }
                    else if (HUtil32.RangeInDefined(n14, 100, 199))
                    {
                        n18 = configuration.Config.GlobalVal[n14 - 100];
                    }
                    else if (HUtil32.RangeInDefined(n14, 200, 299))
                    {
                        n18 = playerActor.MDyVal[n14 - 200];
                    }
                    else if (HUtil32.RangeInDefined(n14, 300, 399))
                    {
                        n18 = playerActor.MNMval[n14 - 300];
                    }
                    else if (HUtil32.RangeInDefined(n14, 400, 499))
                    {
                        n18 = configuration.Config.GlobaDyMval[n14 - 400];
                    }
                    else if (HUtil32.RangeInDefined(n14, 500, 599))
                    {
                        n18 = playerActor.MNInteger[n14 - 500];
                    }
                    else if (HUtil32.RangeInDefined(n14, 800, 1199))//G变量
                    {
                        n18 = configuration.Config.GlobalVal[n14 - 700];
                    }
                    else
                    {
                        ScriptActionError(playerActor,"", questActionInfo, ExecutionCode.Div);
                    }
                }
                else
                {
                    ScriptActionError(playerActor,"", questActionInfo, ExecutionCode.Div);
                }
            }
            else
            {
                n18 = n14;
            }
            int n1C = 0;
            n14 = HUtil32.StrToInt(GetLineVariableText(playerActor,questActionInfo.sParam3), -1);
            if (n14 < 0)
            {
                n14 = ModuleShare.GetValNameNo(questActionInfo.sParam3);
                if (n14 >= 0)
                {
                    if (HUtil32.RangeInDefined(n14, 0, 99))
                    {
                        n1C = playerActor.MNVal[n14];
                    }
                    else if (HUtil32.RangeInDefined(n14, 100, 199))
                    {
                        n1C = configuration.Config.GlobalVal[n14 - 100];
                    }
                    else if (HUtil32.RangeInDefined(n14, 200, 299))
                    {
                        n1C = playerActor.MDyVal[n14 - 200];
                    }
                    else if (HUtil32.RangeInDefined(n14, 300, 399))
                    {
                        n1C = playerActor.MNMval[n14 - 300];
                    }
                    else if (HUtil32.RangeInDefined(n14, 400, 499))
                    {
                        n1C = configuration.Config.GlobaDyMval[n14 - 400];
                    }
                    else if (HUtil32.RangeInDefined(n14, 500, 599))
                    {
                        n1C = playerActor.MNInteger[n14 - 500];
                    }
                    else if (HUtil32.RangeInDefined(n14, 800, 1199))//G变量
                    {
                        n1C = configuration.Config.GlobalVal[n14 - 700];
                    }
                    else
                    {
                        ScriptActionError(playerActor,"", questActionInfo, ExecutionCode.Div);
                    }
                }
                else
                {
                    // ScriptActionError(IPlayerActor,'',questActionInfo,sSC_DIV);
                }
            }
            else
            {
                n1C = n14;
            }
            if (HUtil32.CompareLStr(questActionInfo.sParam1, "<$STR(", 6))//支持字符串变量
            {
                HUtil32.ArrestStringEx(questActionInfo.sParam1, "(", ")", ref s34);
                n14 = ModuleShare.GetValNameNo(s34);
            }
            else
            {
                n14 = ModuleShare.GetValNameNo(questActionInfo.sParam1);
            }
            if (n14 >= 0)
            {
                if (HUtil32.RangeInDefined(n14, 0, 99))
                {
                    playerActor.MNVal[n14] = n18 / n1C;
                }
                else if (HUtil32.RangeInDefined(n14, 100, 199))
                {
                    configuration.Config.GlobalVal[n14 - 100] = n18 / n1C;
                }
                else if (HUtil32.RangeInDefined(n14, 200, 299))
                {
                    playerActor.MDyVal[n14 - 200] = n18 / n1C;
                }
                else if (HUtil32.RangeInDefined(n14, 300, 399))
                {
                    playerActor.MNMval[n14 - 300] = n18 / n1C;
                }
                else if (HUtil32.RangeInDefined(n14, 400, 499))
                {
                    configuration.Config.GlobaDyMval[n14 - 400] = n18 / n1C;
                }
                else if (HUtil32.RangeInDefined(n14, 500, 599))
                {
                    playerActor.MNInteger[n14 - 500] = n18 / n1C;
                }
                else if (HUtil32.RangeInDefined(n14, 800, 1199))//G变量
                {
                    configuration.Config.GlobalVal[n14 - 700] = n18 / n1C;
                }
            }
        }

        /// <summary>
        /// 变量运算 乘法  格式: MUL N1 N2 N3 即N1=N2*N3
        /// </summary>
        /// <param name="IPlayerActor"></param>
        /// <param name="QuestActionInfo"></param>
        private void ActionOfMulData(INormNpc normNpc, IPlayerActor playerActor, QuestActionInfo questActionInfo, ref bool Success)
        {
            string s34 = string.Empty;
            int n18 = 0;
            int n14 = HUtil32.StrToInt(GetLineVariableText(playerActor,questActionInfo.sParam2), -1);
            if (n14 < 0)
            {
                n14 = ModuleShare.GetValNameNo(questActionInfo.sParam2);
                if (n14 >= 0)
                {
                    if (HUtil32.RangeInDefined(n14, 0, 99))
                    {
                        n18 = playerActor.MNVal[n14];
                    }
                    else if (HUtil32.RangeInDefined(n14, 100, 199))
                    {
                        n18 = configuration.Config.GlobalVal[n14 - 100];
                    }
                    else if (HUtil32.RangeInDefined(n14, 200, 299))
                    {
                        n18 = playerActor.MDyVal[n14 - 200];
                    }
                    else if (HUtil32.RangeInDefined(n14, 300, 399))
                    {
                        n18 = playerActor.MNMval[n14 - 300];
                    }
                    else if (HUtil32.RangeInDefined(n14, 400, 499))
                    {
                        n18 = configuration.Config.GlobaDyMval[n14 - 400];
                    }
                    else if (HUtil32.RangeInDefined(n14, 500, 599))
                    {
                        n18 = playerActor.MNInteger[n14 - 500];
                    }
                    else if (HUtil32.RangeInDefined(n14, 600, 699))
                    {
                        n18 = HUtil32.StrToInt(playerActor.MSString[n14 - 600], 1);
                    }
                    else if (HUtil32.RangeInDefined(n14, 700, 799))
                    {
                        n18 = HUtil32.StrToInt(configuration.Config.GlobalAVal[n14 - 700], 1);
                    }
                    else if (HUtil32.RangeInDefined(n14, 800, 1199))//A变量
                    {
                        n18 = configuration.Config.GlobalVal[n14 - 700];
                    }
                    else if (HUtil32.RangeInDefined(n14, 1200, 1599))//G变量
                    {
                        n18 = HUtil32.StrToInt(configuration.Config.GlobalAVal[n14 - 1100], 1);
                    }
                    else
                    {
                        ScriptActionError(playerActor,"", questActionInfo, ExecutionCode.Mul);
                    }
                }
                else
                {
                    ScriptActionError(playerActor,"", questActionInfo, ExecutionCode.Mul);
                }
            }
            else
            {
                n18 = n14;
            }
            int n1C = 0;
            n14 = HUtil32.StrToInt(GetLineVariableText(playerActor,questActionInfo.sParam3), -1);
            if (n14 < 0)
            {
                n14 = ModuleShare.GetValNameNo(questActionInfo.sParam3);
                if (n14 >= 0)
                {
                    if (HUtil32.RangeInDefined(n14, 0, 99))
                    {
                        n1C = playerActor.MNVal[n14];
                    }
                    else if (HUtil32.RangeInDefined(n14, 100, 199))
                    {
                        n1C = configuration.Config.GlobalVal[n14 - 100];
                    }
                    else if (HUtil32.RangeInDefined(n14, 200, 299))
                    {
                        n1C = playerActor.MDyVal[n14 - 200];
                    }
                    else if (HUtil32.RangeInDefined(n14, 300, 399))
                    {
                        n1C = playerActor.MNMval[n14 - 300];
                    }
                    else if (HUtil32.RangeInDefined(n14, 400, 499))
                    {
                        n1C = configuration.Config.GlobaDyMval[n14 - 400];
                    }
                    else if (HUtil32.RangeInDefined(n14, 500, 599))
                    {
                        n1C = playerActor.MNInteger[n14 - 500];
                    }
                    else if (HUtil32.RangeInDefined(n14, 600, 699))
                    {
                        n1C = HUtil32.StrToInt(playerActor.MSString[n14 - 600], 1);
                    }
                    else if (HUtil32.RangeInDefined(n14, 700, 799))
                    {
                        n1C = HUtil32.StrToInt(configuration.Config.GlobalAVal[n14 - 700], 1);
                    }
                    else if (HUtil32.RangeInDefined(n14, 800, 1199)) //G变量
                    {
                        n1C = configuration.Config.GlobalVal[n14 - 700];
                    }
                    else if (HUtil32.RangeInDefined(n14, 1200, 1599))//A变量
                    {
                        n1C = HUtil32.StrToInt(configuration.Config.GlobalAVal[n14 - 1100], 1);
                    }
                    else
                    {
                        ScriptActionError(playerActor,"", questActionInfo, ExecutionCode.Mul);
                    }
                }
                else
                {
                    // ScriptActionError(IPlayerActor,'',questActionInfo,sSC_MUL;
                }
            }
            else
            {
                n1C = n14;
            }
            if (HUtil32.CompareLStr(questActionInfo.sParam1, "<$STR(", 6))// 支持字符串变量
            {
                HUtil32.ArrestStringEx(questActionInfo.sParam1, "(", ")", ref s34);
                n14 = ModuleShare.GetValNameNo(s34);
            }
            else
            {
                n14 = ModuleShare.GetValNameNo(questActionInfo.sParam1);// 取第一个变量,并传值给n18
            }
            if (n14 >= 0)
            {
                if (HUtil32.RangeInDefined(n14, 0, 99))
                {
                    playerActor.MNVal[n14] = n18 * n1C;
                }
                else if (HUtil32.RangeInDefined(n14, 100, 199))
                {
                    configuration.Config.GlobalVal[n14 - 100] = n18 * n1C;
                }
                else if (HUtil32.RangeInDefined(n14, 200, 299))
                {
                    playerActor.MDyVal[n14 - 200] = n18 * n1C;
                }
                else if (HUtil32.RangeInDefined(n14, 300, 399))
                {
                    playerActor.MNMval[n14 - 300] = n18 * n1C;
                }
                else if (HUtil32.RangeInDefined(n14, 400, 499))
                {
                    configuration.Config.GlobaDyMval[n14 - 400] = n18 * n1C;
                }
                else if (HUtil32.RangeInDefined(n14, 500, 599))
                {
                    playerActor.MNInteger[n14 - 500] = n18 * n1C;
                }
                else if (HUtil32.RangeInDefined(n14, 600, 699))
                {
                    playerActor.MSString[n14 - 600] = (n18 * n1C).ToString();
                }
                else if (HUtil32.RangeInDefined(n14, 700, 799))
                {
                    configuration.Config.GlobalAVal[n14 - 700] = (n18 * n1C).ToString();
                }
                else if (HUtil32.RangeInDefined(n14, 800, 1199)) //G变量
                {
                    configuration.Config.GlobalVal[n14 - 700] = n18 * n1C;
                }
                else if (HUtil32.RangeInDefined(n14, 1200, 1599))//A变量(100-499)
                {
                    configuration.Config.GlobalAVal[n14 - 1100] = (n18 * n1C).ToString();
                }
            }
        }

        /// <summary>
        /// 变量运算 百分比  格式: PERCENT N1 N2 N3 即N1=(N2/N3)*100
        /// </summary>
        /// <param name="IPlayerActor"></param>
        /// <param name="QuestActionInfo"></param>
        private void ActionOfPercentData(INormNpc normNpc, IPlayerActor playerActor, QuestActionInfo questActionInfo, ref bool Success)
        {
            string s34 = string.Empty;
            int n18 = 0;
            int n14 = HUtil32.StrToInt(GetLineVariableText(playerActor,questActionInfo.sParam2), -1);
            if (n14 < 0)
            {
                n14 = ModuleShare.GetValNameNo(questActionInfo.sParam2); // 取第一个变量,并传值给n18
                if (n14 >= 0)
                {
                    if (HUtil32.RangeInDefined(n14, 0, 99))
                    {
                        n18 = playerActor.MNVal[n14];
                    }
                    else if (HUtil32.RangeInDefined(n14, 100, 199))
                    {
                        n18 = configuration.Config.GlobalVal[n14 - 100];
                    }
                    else if (HUtil32.RangeInDefined(n14, 200, 299))
                    {
                        n18 = playerActor.MDyVal[n14 - 200];
                    }
                    else if (HUtil32.RangeInDefined(n14, 300, 399))
                    {
                        n18 = playerActor.MNMval[n14 - 300];
                    }
                    else if (HUtil32.RangeInDefined(n14, 400, 499))
                    {
                        n18 = configuration.Config.GlobaDyMval[n14 - 400];
                    }
                    else if (HUtil32.RangeInDefined(n14, 500, 599))
                    {
                        n18 = playerActor.MNInteger[n14 - 500];
                    }
                    else if (HUtil32.RangeInDefined(n14, 800, 1199))//G变量
                    {
                        n18 = configuration.Config.GlobalVal[n14 - 700];
                    }
                    else
                    {
                        ScriptActionError(playerActor,"", questActionInfo, ExecutionCode.Percent);
                    }
                }
                else
                {
                    ScriptActionError(playerActor,"", questActionInfo, ExecutionCode.Percent);
                }
            }
            else
            {
                n18 = n14;
            }
            int n1C = 0;
            n14 = HUtil32.StrToInt(GetLineVariableText(playerActor,questActionInfo.sParam3), -1);
            if (n14 < 0)
            {
                n14 = ModuleShare.GetValNameNo(questActionInfo.sParam3); // 取第一个变量,并传值给n1C
                if (n14 >= 0)
                {
                    if (HUtil32.RangeInDefined(n14, 0, 99))
                    {
                        n1C = playerActor.MNVal[n14];
                    }
                    else if (HUtil32.RangeInDefined(n14, 100, 199))
                    {
                        n1C = configuration.Config.GlobalVal[n14 - 100];
                    }
                    else if (HUtil32.RangeInDefined(n14, 200, 299))
                    {
                        n1C = playerActor.MDyVal[n14 - 200];
                    }
                    else if (HUtil32.RangeInDefined(n14, 300, 399))
                    {
                        n1C = playerActor.MNMval[n14 - 300];
                    }
                    else if (HUtil32.RangeInDefined(n14, 400, 499))
                    {
                        n1C = configuration.Config.GlobaDyMval[n14 - 400];
                    }
                    else if (HUtil32.RangeInDefined(n14, 500, 599))
                    {
                        n1C = playerActor.MNInteger[n14 - 500];
                    }
                    else if (HUtil32.RangeInDefined(n14, 800, 1199))//G变量
                    {
                        n1C = configuration.Config.GlobalVal[n14 - 700];
                    }
                    else
                    {
                        ScriptActionError(playerActor,"", questActionInfo, ExecutionCode.Percent);
                    }
                }
                else
                {
                    // ScriptActionError(IPlayerActor,'',questActionInfo,sSC_PERCENT);
                }
            }
            else
            {
                n1C = n14;
            }
            if (HUtil32.CompareLStr(questActionInfo.sParam1, "<$STR(", 6))// 支持字符串变量
            {
                HUtil32.ArrestStringEx(questActionInfo.sParam1, "(", ")", ref s34);
                n14 = ModuleShare.GetValNameNo(s34);
            }
            else
            {
                n14 = ModuleShare.GetValNameNo(questActionInfo.sParam1);
            }
            if (n14 >= 0)
            {
                if (HUtil32.RangeInDefined(n14, 0, 99))
                {
                    playerActor.MNVal[n14] = n18 * n1C;
                }
                else if (HUtil32.RangeInDefined(n14, 100, 199))
                {
                    configuration.Config.GlobalVal[n14 - 100] = n18 / n1C * 100;
                }
                else if (HUtil32.RangeInDefined(n14, 200, 299))
                {
                    playerActor.MDyVal[n14 - 200] = n18 / n1C * 100;
                }
                else if (HUtil32.RangeInDefined(n14, 300, 399))
                {
                    playerActor.MNMval[n14 - 300] = n18 / n1C * 100;
                }
                else if (HUtil32.RangeInDefined(n14, 400, 499))
                {
                    configuration.Config.GlobaDyMval[n14 - 400] = n18 / n1C * 100;
                }
                else if (HUtil32.RangeInDefined(n14, 500, 599))
                {
                    playerActor.MNInteger[n14 - 500] = n18 / n1C * 100;
                }
                else if (HUtil32.RangeInDefined(n14, 600, 699))
                {
                    playerActor.MSString[n14 - 600] = $"{n18 / n1C * 100}%";
                }
                else if (HUtil32.RangeInDefined(n14, 700, 799))
                {
                    configuration.Config.GlobalAVal[n14 - 700] = $"{n18 / n1C * 100}%";
                }
                else if (HUtil32.RangeInDefined(n14, 800, 1199))//G变量
                {
                    configuration.Config.GlobalVal[n14 - 700] = n18 / n1C * 100;
                }
                else if (HUtil32.RangeInDefined(n14, 1200, 1599))//A变量
                {
                    configuration.Config.GlobalAVal[n14 - 1100] = $"{n18 / n1C * 100}%";
                }
            }
        }

        private void ActionOfSumData(INormNpc normNpc, IPlayerActor playerActor, QuestActionInfo questActionInfo, ref bool Success)
        {
            int n18 = 0;
            string s34 = string.Empty;
            string s44 = string.Empty;
            string s48 = string.Empty;
            int n14;
            if (HUtil32.CompareLStr(questActionInfo.sParam1, "<$STR(", 6)) //  SUM 支持字符串变量
            {
                HUtil32.ArrestStringEx(questActionInfo.sParam1, "(", ")", ref s34);
                n14 = ModuleShare.GetValNameNo(s34);
            }
            else
            {
                n14 = ModuleShare.GetValNameNo(questActionInfo.sParam1);
            }
            if (n14 >= 0)
            {
                if (HUtil32.RangeInDefined(n14, 0, 99))
                {
                    n18 = playerActor.MNVal[n14];
                }
                else if (HUtil32.RangeInDefined(n14, 100, 199))
                {
                    n18 = configuration.Config.GlobalVal[n14 - 100];
                }
                else if (HUtil32.RangeInDefined(n14, 200, 299))
                {
                    n18 = playerActor.MDyVal[n14 - 200];
                }
                else if (HUtil32.RangeInDefined(n14, 300, 399))
                {
                    n18 = playerActor.MNMval[n14 - 300];
                }
                else if (HUtil32.RangeInDefined(n14, 400, 499))
                {
                    n18 = configuration.Config.GlobaDyMval[n14 - 400];
                }
                else if (HUtil32.RangeInDefined(n14, 500, 599))
                {
                    n18 = playerActor.MNInteger[n14 - 500];
                }
                else if (HUtil32.RangeInDefined(n14, 600, 699))
                {
                    s44 = playerActor.MSString[n14 - 600];
                }
                else if (HUtil32.RangeInDefined(n14, 700, 799))
                {
                    s44 = configuration.Config.GlobalAVal[n14 - 700];
                }
                else if (HUtil32.RangeInDefined(n14, 800, 1199))
                {
                    n18 = configuration.Config.GlobalVal[n14 - 700];//G变量
                }
                else if (HUtil32.RangeInDefined(n14, 1200, 1599))
                {
                    s44 = configuration.Config.GlobalAVal[n14 - 1100];//A变量
                }
                else
                {
                    ScriptActionError(playerActor,"", questActionInfo, ExecutionCode.Sum);
                }
            }
            else
            {
                ScriptActionError(playerActor,"", questActionInfo, ExecutionCode.Sum);
            }
            int n1C = 0;
            if (HUtil32.CompareLStr(questActionInfo.sParam2, "<$STR(", 6)) //SUM 支持字符串变量
            {
                HUtil32.ArrestStringEx(questActionInfo.sParam2, "(", ")", ref s34);
                n14 = ModuleShare.GetValNameNo(s34);
            }
            else
            {
                n14 = ModuleShare.GetValNameNo(questActionInfo.sParam2);
            }
            if (n14 >= 0)
            {
                if (HUtil32.RangeInDefined(n14, 0, 99))
                {
                    n1C = playerActor.MNVal[n14];
                }
                else if (HUtil32.RangeInDefined(n14, 100, 199))
                {
                    n1C = configuration.Config.GlobalVal[n14 - 100];
                }
                else if (HUtil32.RangeInDefined(n14, 200, 299))
                {
                    n1C = playerActor.MDyVal[n14 - 200];
                }
                else if (HUtil32.RangeInDefined(n14, 300, 399))
                {
                    n1C = playerActor.MNMval[n14 - 300];
                }
                else if (HUtil32.RangeInDefined(n14, 400, 499))
                {
                    n1C = configuration.Config.GlobaDyMval[n14 - 400];
                }
                else if (HUtil32.RangeInDefined(n14, 500, 599))
                {
                    n1C = playerActor.MNInteger[n14 - 500];
                }
                else if (HUtil32.RangeInDefined(n14, 600, 699))
                {
                    s48 = playerActor.MSString[n14 - 600];
                }
                else if (HUtil32.RangeInDefined(n14, 700, 799))
                {
                    s48 = configuration.Config.GlobalAVal[n14 - 700];
                }
                else if (HUtil32.RangeInDefined(n14, 800, 1199))
                {
                    n1C = configuration.Config.GlobalVal[n14 - 700];//G变量
                }
                else if (HUtil32.RangeInDefined(n14, 1200, 1599))
                {
                    s48 = configuration.Config.GlobalAVal[n14 - 1100];//A变量
                }
                else
                {
                    ScriptActionError(playerActor,"", questActionInfo, ExecutionCode.Sum);
                }
            }
            if (HUtil32.CompareLStr(questActionInfo.sParam1, "<$STR(", 6)) // SUM 支持字符串变量
            {
                HUtil32.ArrestStringEx(questActionInfo.sParam1, "(", ")", ref s34);
                n14 = ModuleShare.GetValNameNo(s34);
            }
            else
            {
                n14 = ModuleShare.GetValNameNo(questActionInfo.sParam1);
            }
            if (n14 >= 0)
            {
                if (HUtil32.RangeInDefined(n14, 0, 99))
                {
                    playerActor.MNVal[n14] = n18 + n1C;
                }
                else if (HUtil32.RangeInDefined(n14, 100, 199))
                {
                    configuration.Config.GlobalVal[n14 - 100] = n18 + n1C;
                }
                else if (HUtil32.RangeInDefined(n14, 200, 299))
                {
                    playerActor.MDyVal[n14 - 200] = n18 + n1C;
                }
                else if (HUtil32.RangeInDefined(n14, 300, 399))
                {
                    playerActor.MNMval[n14 - 300] = n18 + n1C;
                }
                else if (HUtil32.RangeInDefined(n14, 400, 499))
                {
                    configuration.Config.GlobaDyMval[n14 - 400] = n18 + n1C;
                }
                else if (HUtil32.RangeInDefined(n14, 500, 599))
                {
                    playerActor.MNInteger[n14 - 500] = n18 + n1C;
                }
                else if (HUtil32.RangeInDefined(n14, 600, 699))
                {
                    playerActor.MSString[n14 - 600] = s44 + s48;
                }
                else if (HUtil32.RangeInDefined(n14, 700, 799))
                {
                    configuration.Config.GlobalAVal[n14 - 700] = s44 + s48;
                }
                else if (HUtil32.RangeInDefined(n14, 800, 1199))
                {
                    configuration.Config.GlobalVal[n14 - 700] = n18 + n1C;//G变量
                }
                else if (HUtil32.RangeInDefined(n14, 1200, 1599))
                {
                    configuration.Config.GlobalAVal[n14 - 1100] = s44 + s48;//A变量
                }
            }
        }

        private void ActionOfDecInteger(INormNpc normNpc, IPlayerActor playerActor, QuestActionInfo questActionInfo, ref bool Success)
        {
            int n14;
            int n3C = 0;
            DynamicVar DynamicVar;
            Dictionary<string, DynamicVar> DynamicVarList;
            string sName = string.Empty;
            string s01 = string.Empty;
            string sParam1 = string.Empty;
            string sParam2 = string.Empty;
            string sParam3 = string.Empty;
            const string sVarFound = "变量{0}不存在，变量类型:{1}";
            const string sVarTypeError = "变量类型错误，错误类型:{0} 当前支持类型(HUMAN、GUILD、GLOBAL)";
            int n10 = 0;
            if (HUtil32.CompareLStr(questActionInfo.sParam1, "<$STR(", 6))
            {
                HUtil32.ArrestStringEx(questActionInfo.sParam1, "(", ")", ref sParam1);
            }
            else
            {
                sParam1 = questActionInfo.sParam1;
            }
            if (HUtil32.CompareLStr(questActionInfo.sParam2, "<$STR(", 6))
            {
                HUtil32.ArrestStringEx(questActionInfo.sParam2, "(", ")", ref sParam2);
            }
            else
            {
                sParam2 = questActionInfo.sParam2;
            }
            if (HUtil32.CompareLStr(questActionInfo.sParam3, "<$STR(", 6))
            {
                HUtil32.ArrestStringEx(questActionInfo.sParam3, "(", ")", ref sParam3);
            }
            else
            {
                sParam3 = questActionInfo.sParam3;
            }
            if ((string.IsNullOrEmpty(sParam1)) || (string.IsNullOrEmpty(sParam2)))
            {
                ScriptActionError(playerActor,"", questActionInfo, ExecutionCode.Dec);
                return;
            }
            string s02;
            string s03;
            if (!string.IsNullOrEmpty(sParam3))
            {
                bool boVarFound;
                if ((!HUtil32.IsVarNumber(sParam1)) && HUtil32.IsVarNumber(sParam2))
                {
                    boVarFound = false;
                    DynamicVarList = GetDynamicVarMap(playerActor,sParam2, ref sName);
                    if (DynamicVarList == null)
                    {
                        ScriptActionError(playerActor,string.Format(sVarTypeError, sParam2), questActionInfo, ExecutionCode.Dec);
                        return;
                    }
                    if (DynamicVarList.TryGetValue(sParam3, out DynamicVar))
                    {
                        switch (DynamicVar.VarType)
                        {
                            case VarType.Integer:
                                n3C = DynamicVar.nInternet;
                                break;
                            case VarType.String:
                                s01 = DynamicVar.sString;
                                break;
                        }
                        boVarFound = true;
                    }
                    if (!boVarFound)
                    {
                        ScriptActionError(playerActor,string.Format(sVarFound, sParam3, sParam2), questActionInfo, ExecutionCode.Dec);
                        return;
                    }
                    n14 = ModuleShare.GetValNameNo(sParam1);
                    if (n14 >= 0)
                    {
                        if (HUtil32.RangeInDefined(n14, 0, 99))
                        {
                            if (n3C > 1)
                            {
                                playerActor.MNVal[n14] -= n3C;
                            }
                            else
                            {
                                playerActor.MNVal[n14] -= 1;
                            }
                        }
                        else if (HUtil32.RangeInDefined(n14, 100, 199))
                        {
                            if (n3C > 1)
                            {
                                configuration.Config.GlobalVal[n14 - 100] -= n3C;
                            }
                            else
                            {
                                configuration.Config.GlobalVal[n14 - 100] -= 1;
                            }
                        }
                        else if (HUtil32.RangeInDefined(n14, 200, 299))
                        {
                            if (n3C > 1)
                            {
                                playerActor.MDyVal[n14 - 200] -= n3C;
                            }
                            else
                            {
                                playerActor.MDyVal[n14 - 200] -= 1;
                            }
                        }
                        else if (HUtil32.RangeInDefined(n14, 300, 399))
                        {
                            if (n3C > 1)
                            {
                                playerActor.MNMval[n14 - 300] -= n3C;
                            }
                            else
                            {
                                playerActor.MNMval[n14 - 300] -= 1;
                            }
                        }
                        else if (HUtil32.RangeInDefined(n14, 400, 499))
                        {
                            if (n3C > 1)
                            {
                                configuration.Config.GlobaDyMval[n14 - 400] -= n3C;
                            }
                            else
                            {
                                configuration.Config.GlobaDyMval[n14 - 400] -= 1;
                            }
                        }
                        else if (HUtil32.RangeInDefined(n14, 500, 599))
                        {
                            if (n3C > 1)
                            {
                                playerActor.MNInteger[n14 - 500] -= n3C;
                            }
                            else
                            {
                                playerActor.MNInteger[n14 - 500] -= 1;
                            }
                        }
                        else if (HUtil32.RangeInDefined(n14, 600, 699))
                        {
                            n10 = playerActor.MSString[n14 - 600].AsSpan().IndexOf(s01, StringComparison.CurrentCultureIgnoreCase);
                            s02 = playerActor.MSString[n14 - 600][1..n10];
                            s03 = playerActor.MSString[n14 - 600].Substring(s01.Length + n10, playerActor.MSString[n14 - 600].Length);
                            playerActor.MSString[n14 - 600] = s02 + s03;
                        }
                        else if (HUtil32.RangeInDefined(n14, 700, 799))
                        {
                            n10 = configuration.Config.GlobalAVal[n14 - 700].AsSpan().IndexOf(s01, StringComparison.CurrentCultureIgnoreCase);
                            s02 = configuration.Config.GlobalAVal[n14 - 700][1..n10];
                            s03 = configuration.Config.GlobalAVal[n14 - 700].Substring(s01.Length + n10, configuration.Config.GlobalAVal[n14 - 700].Length);
                            configuration.Config.GlobalAVal[n14 - 700] = s02 + s03;
                        }
                        else if (HUtil32.RangeInDefined(n14, 800, 1199)) // G变量
                        {
                            if (n3C > 1)
                            {
                                configuration.Config.GlobalVal[n14 - 700] -= n3C;
                            }
                            else
                            {
                                configuration.Config.GlobalVal[n14 - 700] -= 1;
                            }
                        }
                        else if (HUtil32.RangeInDefined(n14, 1200, 1599)) // A变量
                        {
                            n10 = configuration.Config.GlobalAVal[n14 - 1100].AsSpan().IndexOf(s01, StringComparison.CurrentCultureIgnoreCase);
                            s02 = configuration.Config.GlobalAVal[n14 - 1100][1..n10];
                            s03 = configuration.Config.GlobalAVal[n14 - 1100].Substring(s01.Length + n10, configuration.Config.GlobalAVal[n14 - 1100].Length);
                            configuration.Config.GlobalAVal[n14 - 1100] = s02 + s03;
                        }
                        else
                        {
                            ScriptActionError(playerActor,"", questActionInfo, ExecutionCode.Dec);
                        }
                    }
                    else
                    {
                        ScriptActionError(playerActor,"", questActionInfo, ExecutionCode.Dec);
                        return;
                    }
                    return;
                }
                if (HUtil32.IsVarNumber(sParam1) && (!HUtil32.IsVarNumber(sParam2)))
                {
                    if ((!string.IsNullOrEmpty(sParam3)) && (!HUtil32.IsStringNumber(sParam3)))
                    {
                        n14 = ModuleShare.GetValNameNo(sParam3);
                        if (n14 >= 0)
                        {
                            if (HUtil32.RangeInDefined(n14, 0, 99))
                            {
                                n3C = playerActor.MNVal[n14];
                            }
                            else if (HUtil32.RangeInDefined(n14, 100, 199))
                            {
                                n3C = configuration.Config.GlobalVal[n14 - 100];
                            }
                            else if (HUtil32.RangeInDefined(n14, 200, 299))
                            {
                                n3C = playerActor.MDyVal[n14 - 200];
                            }
                            else if (HUtil32.RangeInDefined(n14, 300, 399))
                            {
                                n3C = playerActor.MNMval[n14 - 300];
                            }
                            else if (HUtil32.RangeInDefined(n14, 400, 499))
                            {
                                n3C = configuration.Config.GlobaDyMval[n14 - 400];
                            }
                            else if (HUtil32.RangeInDefined(n14, 500, 599))
                            {
                                n3C = playerActor.MNInteger[n14 - 500];
                            }
                            else if (HUtil32.RangeInDefined(n14, 600, 699))
                            {
                                s01 = playerActor.MSString[n14 - 600];
                            }
                            else if (HUtil32.RangeInDefined(n14, 700, 799))
                            {
                                s01 = configuration.Config.GlobalAVal[n14 - 700];
                            }
                            else if (HUtil32.RangeInDefined(n14, 800, 1199)) // G变量
                            {
                                n3C = configuration.Config.GlobalVal[n14 - 700];
                            }
                            else if (HUtil32.RangeInDefined(n14, 1200, 1599)) // A变量
                            {
                                s01 = configuration.Config.GlobalAVal[n14 - 1100];
                            }
                            else
                            {
                                ScriptActionError(playerActor,"", questActionInfo, ExecutionCode.Dec);
                            }
                        }
                        else
                        {
                            s01 = sParam3;
                        }
                    }
                    else
                    {
                        n3C = questActionInfo.nParam3;
                    }
                    boVarFound = false;
                    DynamicVarList = GetDynamicVarMap(playerActor,sParam1, ref sName);
                    if (DynamicVarList == null)
                    {
                        ScriptActionError(playerActor,string.Format(sVarTypeError, sParam1), questActionInfo, ExecutionCode.Dec);
                        return;
                    }
                    if (DynamicVarList.TryGetValue(sParam2, out DynamicVar))
                    {
                        switch (DynamicVar.VarType)
                        {
                            case VarType.Integer:
                                if (n3C > 1)
                                {
                                    DynamicVar.nInternet -= n3C;
                                }
                                else
                                {
                                    DynamicVar.nInternet -= 1;
                                }
                                break;
                            case VarType.String:
                                n10 = DynamicVar.sString.AsSpan().IndexOf(s01, StringComparison.CurrentCultureIgnoreCase);
                                s02 = DynamicVar.sString[..(n10 - 1)];
                                s03 = DynamicVar.sString.Substring(s01.Length + n10 - 1, DynamicVar.sString.Length);
                                DynamicVar.sString = s02 + s03;
                                break;
                        }
                        boVarFound = true;
                    }
                    if (!boVarFound)
                    {
                        ScriptActionError(playerActor,string.Format(sVarFound, sParam2, sParam1), questActionInfo, ExecutionCode.Dec);
                        return;
                    }
                    return;
                }
                if (n10 == 0)
                {
                    ScriptActionError(playerActor,"", questActionInfo, ExecutionCode.Dec);
                }
            }
            else
            {
                if ((!string.IsNullOrEmpty(sParam2)) && (!HUtil32.IsStringNumber(sParam2)))
                {
                    // 获取第2个变量值
                    n14 = ModuleShare.GetValNameNo(sParam2);
                    if (n14 >= 0)
                    {
                        if (HUtil32.RangeInDefined(n14, 0, 99))
                        {
                            n3C = playerActor.MNVal[n14];
                        }
                        else if (HUtil32.RangeInDefined(n14, 100, 199))
                        {
                            n3C = configuration.Config.GlobalVal[n14 - 100];
                        }
                        else if (HUtil32.RangeInDefined(n14, 200, 299))
                        {
                            n3C = playerActor.MDyVal[n14 - 200];
                        }
                        else if (HUtil32.RangeInDefined(n14, 300, 399))
                        {
                            n3C = playerActor.MNMval[n14 - 300];
                        }
                        else if (HUtil32.RangeInDefined(n14, 400, 499))
                        {
                            n3C = configuration.Config.GlobaDyMval[n14 - 400];
                        }
                        else if (HUtil32.RangeInDefined(n14, 500, 599))
                        {
                            n3C = playerActor.MNInteger[n14 - 500];
                        }
                        else if (HUtil32.RangeInDefined(n14, 600, 699))
                        {
                            s01 = playerActor.MSString[n14 - 600];
                        }
                        else if (HUtil32.RangeInDefined(n14, 700, 799))
                        {
                            s01 = configuration.Config.GlobalAVal[n14 - 700];
                        }
                        else if (HUtil32.RangeInDefined(n14, 800, 1199)) // G变量
                        {
                            n3C = configuration.Config.GlobalVal[n14 - 700];
                        }
                        else if (HUtil32.RangeInDefined(n14, 1200, 1599)) // A变量
                        {
                            s01 = configuration.Config.GlobalAVal[n14 - 1100];
                        }
                        else
                        {
                            ScriptActionError(playerActor,"", questActionInfo, ExecutionCode.Dec);
                        }
                    }
                    else
                    {
                        n3C = HUtil32.StrToInt(GetLineVariableText(playerActor,sParam2), 0);// 个人变量
                        s01 = sParam2;
                    }
                }
                else
                {
                    n3C = questActionInfo.nParam2;
                }
                n14 = ModuleShare.GetValNameNo(sParam1);
                if (n14 >= 0)
                {
                    if (HUtil32.RangeInDefined(n14, 0, 99))
                    {
                        if (n3C > 1)
                        {
                            playerActor.MNVal[n14] -= n3C;
                        }
                        else
                        {
                            playerActor.MNVal[n14] -= 1;
                        }
                    }
                    else if (HUtil32.RangeInDefined(n14, 100, 199))
                    {
                        if (n3C > 1)
                        {
                            configuration.Config.GlobalVal[n14 - 100] -= n3C;
                        }
                        else
                        {
                            configuration.Config.GlobalVal[n14 - 100] -= 1;
                        }
                    }
                    else if (HUtil32.RangeInDefined(n14, 200, 299))
                    {
                        if (n3C > 1)
                        {
                            playerActor.MDyVal[n14 - 200] -= n3C;
                        }
                        else
                        {
                            playerActor.MDyVal[n14 - 200] -= 1;
                        }
                    }
                    else if (HUtil32.RangeInDefined(n14, 300, 399))
                    {
                        if (n3C > 1)
                        {
                            playerActor.MNMval[n14 - 300] -= n3C;
                        }
                        else
                        {
                            playerActor.MNMval[n14 - 300] -= 1;
                        }
                    }
                    else if (HUtil32.RangeInDefined(n14, 400, 499))
                    {
                        if (n3C > 1)
                        {
                            configuration.Config.GlobaDyMval[n14 - 400] -= n3C;
                        }
                        else
                        {
                            configuration.Config.GlobaDyMval[n14 - 400] -= 1;
                        }
                    }
                    else if (HUtil32.RangeInDefined(n14, 500, 599))
                    {
                        if (n3C > 1)
                        {
                            playerActor.MNInteger[n14 - 500] -= n3C;
                        }
                        else
                        {
                            playerActor.MNInteger[n14 - 500] -= 1;
                        }
                    }
                    else if (HUtil32.RangeInDefined(n14, 600, 699))
                    {
                        n10 = playerActor.MSString[n14 - 600].AsSpan().IndexOf(s01, StringComparison.OrdinalIgnoreCase);
                        s02 = playerActor.MSString[n14 - 600][1..n10];
                        s03 = playerActor.MSString[n14 - 600].Substring(s01.Length + n10, playerActor.MSString[n14 - 600].Length);
                        playerActor.MSString[n14 - 600] = s02 + s03;
                    }
                    else if (HUtil32.RangeInDefined(n14, 700, 799))
                    {
                        n10 = configuration.Config.GlobalAVal[n14 - 700].AsSpan().IndexOf(s01, StringComparison.OrdinalIgnoreCase);
                        s02 = configuration.Config.GlobalAVal[n14 - 700][1..n10];
                        s03 = configuration.Config.GlobalAVal[n14 - 700].Substring(s01.Length + n10, configuration.Config.GlobalAVal[n14 - 700].Length);
                        configuration.Config.GlobalAVal[n14 - 700] = s02 + s03;
                    }
                    else if (HUtil32.RangeInDefined(n14, 800, 1199)) // G变量
                    {
                        if (n3C > 1)
                        {
                            configuration.Config.GlobalVal[n14 - 700] -= n3C;
                        }
                        else
                        {
                            configuration.Config.GlobalVal[n14 - 700] -= 1;
                        }
                    }
                    else if (HUtil32.RangeInDefined(n14, 1200, 1599)) // A变量
                    {
                        n10 = configuration.Config.GlobalAVal[n14 - 1100].AsSpan().IndexOf(s01, StringComparison.OrdinalIgnoreCase);
                        s02 = configuration.Config.GlobalAVal[n14 - 1100][1..n10];
                        s03 = configuration.Config.GlobalAVal[n14 - 1100].Substring(s01.Length + n10, configuration.Config.GlobalAVal[n14 - 1100].Length);
                        configuration.Config.GlobalAVal[n14 - 1100] = s02 + s03;
                    }
                    else
                    {
                        ScriptActionError(playerActor,"", questActionInfo, ExecutionCode.Dec);
                    }
                }
                else
                {
                    ScriptActionError(playerActor,"", questActionInfo, ExecutionCode.Dec);
                    return;
                }
            }
        }

        private void ActionOfExeaction(INormNpc normNpc, IPlayerActor playerActor, QuestActionInfo questActionInfo, ref bool Success)
        {
            var n40 = questActionInfo.nParam1;
           // normNpc.ExeAction(playerActor,questActionInfo.sParam1, questActionInfo.sParam2, questActionInfo.sParam3, questActionInfo.nParam1, questActionInfo.nParam2, questActionInfo.nParam3);
        }

        private void ActionOfPlayDice(INormNpc normNpc, IPlayerActor playerActor, QuestActionInfo questActionInfo, ref bool Success)
        {
            playerActor.PlayDiceLabel = questActionInfo.sParam2;
            playerActor.SendMsg(normNpc, Messages.RM_PLAYDICE, (short)questActionInfo.nParam1, HUtil32.MakeLong(HUtil32.MakeWord((ushort)playerActor.MDyVal[0], (ushort)playerActor.MDyVal[1]), HUtil32.MakeWord((ushort)playerActor.MDyVal[2], (ushort)playerActor.MDyVal[3])), HUtil32.MakeLong(HUtil32.MakeWord((ushort)playerActor.MDyVal[4], (ushort)playerActor.MDyVal[5]), HUtil32.MakeWord((ushort)playerActor.MDyVal[6], (ushort)playerActor.MDyVal[7])), HUtil32.MakeLong(HUtil32.MakeWord((ushort)playerActor.MDyVal[8], (ushort)playerActor.MDyVal[9]), 0), questActionInfo.sParam2);
        }

        private void ActionOfSet(INormNpc normNpc, IPlayerActor playerActor, QuestActionInfo questActionInfo, ref bool Success)
        {
            var n28 = HUtil32.StrToInt(questActionInfo.sParam1, 0);
            var n2C = HUtil32.StrToInt(questActionInfo.sParam2, 0);
            playerActor.SetQuestFlagStatus(n28, n2C);
        }

        private void ActionOfReSet(INormNpc normNpc, IPlayerActor playerActor, QuestActionInfo questActionInfo, ref bool Success)
        {
            for (int k = 0; k < questActionInfo.nParam2; k++)
            {
                playerActor.SetQuestFlagStatus(questActionInfo.nParam1 + k, 0);
            }
        }

        private void ActionOfSetOpen(INormNpc normNpc, IPlayerActor playerActor, QuestActionInfo questActionInfo, ref bool Success)
        {
            var n28 = HUtil32.StrToInt(questActionInfo.sParam1, 0);
            var n2C = HUtil32.StrToInt(questActionInfo.sParam2, 0);
            playerActor.SetQuestUnitOpenStatus(n28, n2C);
        }

        private void ActionOfSetUnit(INormNpc normNpc, IPlayerActor playerActor, QuestActionInfo questActionInfo, ref bool Success)
        {
            var n28 = HUtil32.StrToInt(questActionInfo.sParam1, 0);
            var n2C = HUtil32.StrToInt(questActionInfo.sParam2, 0);
            playerActor.SetQuestUnitStatus(n28, n2C);
        }

        private void ActionOfResetUnit(INormNpc normNpc, IPlayerActor playerActor, QuestActionInfo questActionInfo, ref bool Success)
        {
            for (int k = 0; k < questActionInfo.nParam2; k++)
            {
                playerActor.SetQuestUnitStatus(questActionInfo.nParam1 + k, 0);
            }
        }

        private void ActionOfPkPoint(INormNpc normNpc, IPlayerActor playerActor, QuestActionInfo questActionInfo, ref bool Success)
        {
            if (questActionInfo.nParam1 == 0)
            {
                playerActor.PkPoint = 0;
            }
            else
            {
                if (questActionInfo.nParam1 < 0)
                {
                    if ((playerActor.PkPoint + questActionInfo.nParam1) >= 0)
                    {
                        playerActor.PkPoint += questActionInfo.nParam1;
                    }
                    else
                    {
                        playerActor.PkPoint = 0;
                    }
                }
                else
                {
                    if ((playerActor.PkPoint + questActionInfo.nParam1) > 10000)
                    {
                        playerActor.PkPoint = 10000;
                    }
                    else
                    {
                        playerActor.PkPoint += questActionInfo.nParam1;
                    }
                }
            }
            playerActor.RefNameColor();
        }

        private void ActionOfBreakTimereCall(INormNpc normNpc, IPlayerActor playerActor, QuestActionInfo questActionInfo, ref bool Success)
        {
            playerActor.IsTimeRecall = false;
        }

        private void ActionOfSetRandomNo(INormNpc normNpc, IPlayerActor playerActor, QuestActionInfo questActionInfo, ref bool Success)
        {
            while (true)
            {
                var n2C = ModuleShare.RandomNumber.Random(999999);
                if ((n2C >= 1000) && (n2C.ToString() != playerActor.RandomNo))
                {
                    playerActor.RandomNo = n2C.ToString();
                    break;
                }
            }
        }

        private void ActionOfClearDelayGoto(INormNpc normNpc, IPlayerActor playerActor, QuestActionInfo questActionInfo, ref bool Success)
        {
            playerActor.IsTimeGoto = false;
            playerActor.TimeGotoLable = "";
            playerActor.TimeGotoNpc = null;
        }

        private void ActionOfTimereCall(INormNpc normNpc, IPlayerActor playerActor, QuestActionInfo questActionInfo, ref bool Success)
        {
            playerActor.IsTimeRecall = true;
            playerActor.TimeRecallMoveMap = playerActor.MapName;
            playerActor.TimeRecallMoveX = playerActor.CurrX;
            playerActor.TimeRecallMoveY = playerActor.CurrY;
            playerActor.TimeRecallTick = HUtil32.GetTickCount() + (questActionInfo.nParam1 * 60 * 1000);
        }

        private void ActionOfMonGen(INormNpc normNpc, IPlayerActor playerActor, QuestActionInfo questActionInfo, ref bool Success)
        {
            var n3C = questActionInfo.nParam1;
            var n38 = questActionInfo.nParam1;
            var sMap = questActionInfo.sParam1;
            for (int k = 0; k < questActionInfo.nParam2; k++)
            {
                var n20X = ModuleShare.RandomNumber.Random(questActionInfo.nParam3 * 2 + 1) + (n38 - questActionInfo.nParam3);
                var n24Y = ModuleShare.RandomNumber.Random(questActionInfo.nParam3 * 2 + 1) + (n3C - questActionInfo.nParam3);
                ModuleShare.WorldEngine.RegenMonsterByName(sMap, (short)n20X, (short)n24Y, questActionInfo.sParam1);
            }
        }

        private void ActionOfMonClear(INormNpc normNpc, IPlayerActor playerActor, QuestActionInfo questActionInfo, ref bool Success)
        {
            var list58 = new List<IActor>();
            ModuleShare.WorldEngine.GetMapMonster(ModuleShare.MapMgr.FindMap(questActionInfo.sParam1), list58);
            for (int k = 0; k < list58.Count; k++)
            {
                list58[k].NoItem = true;
                list58[k].WAbil.HP = 0;
                list58[k].MakeGhost();
            }
            list58.Clear();
        }

        private void ActionOfMap(INormNpc normNpc, IPlayerActor playerActor, QuestActionInfo questActionInfo, ref bool Success)
        {
            playerActor.SendRefMsg(Messages.RM_SPACEMOVE_FIRE, 0, 0, 0, 0, "");
            playerActor.MapRandomMove(questActionInfo.sParam1, 0);
        }

        private void ActionOfMapMove(INormNpc normNpc, IPlayerActor playerActor, QuestActionInfo questActionInfo, ref bool Success)
        {
            playerActor.SendRefMsg(Messages.RM_SPACEMOVE_FIRE, 0, 0, 0, 0, "");
            playerActor.SpaceMove(questActionInfo.sParam1, (short)questActionInfo.nParam2, (short)questActionInfo.nParam3, 0);
        }

        private void ActionOfClose(INormNpc normNpc, IPlayerActor playerActor, QuestActionInfo questActionInfo, ref bool Success)
        {
            playerActor.SendMsg(normNpc, Messages.RM_MERCHANTDLGCLOSE, 0, normNpc.ActorId, 0, 0);
        }

        private void ActionOfReCallMap(INormNpc normNpc, IPlayerActor playerActor, QuestActionInfo questActionInfo, ref bool Success)
        {
            var recallEnvir = ModuleShare.MapMgr.FindMap(questActionInfo.sParam1);
            if (recallEnvir != null)
            {
                IList<IActor> recallList = new List<IActor>();
                ModuleShare.WorldEngine.GetMapRageHuman(recallEnvir, 0, 0, 1000, ref recallList);
                for (int k = 0; k < recallList.Count; k++)
                {
                    var user = (IPlayerActor)recallList[k];
                    user.MapRandomMove(recallEnvir.MapName, 0);
                    if (k > 20)
                    {
                        break;
                    }
                }
            }
            else
            {
                ScriptActionError(playerActor,"", questActionInfo, ExecutionCode.ReCallMap);
            }
        }

        private void ActionOfExchangeMap(INormNpc normNpc, IPlayerActor playerActor, QuestActionInfo questActionInfo, ref bool Success)
        {
            var envir = ModuleShare.MapMgr.FindMap(questActionInfo.sParam1);
            if (envir != null)
            {
                //IList<BaseObject> exchangeList = new List<BaseObject>();
                //M2Share.WorldEngine.GetMapRageHuman(envir, 0, 0, 1000, ref exchangeList);
                //if (exchangeList.Count > 0)
                //{
                //    var user = exchangeList[0];
                //    user.MapRandomMove(normNpc.MapName, 0);
                //}
                playerActor.MapRandomMove(questActionInfo.sParam1, 0);
            }
            else
            {
                ScriptActionError(playerActor,"", questActionInfo, ExecutionCode.ExchangeMap);
            }
        }

        private void ActionOfUpgradeDlgItem(INormNpc normNpc, IPlayerActor playerActor, QuestActionInfo questActionInfo, ref bool Success)
        {

        }

        private void ActionOfQueryItemDlg(INormNpc normNpc, IPlayerActor playerActor, QuestActionInfo questActionInfo, ref bool Success)
        {
            playerActor.TakeDlgItem = questActionInfo.nParam3 != 0;
            playerActor.GotoNpcLabel = questActionInfo.sParam2;
            string sHint = questActionInfo.sParam1;
            if (string.IsNullOrEmpty(sHint)) sHint = "请输入:";
            playerActor.SendDefMessage(Messages.SM_QUERYITEMDLG, normNpc.ActorId, 0, 0, 0, sHint);
        }

        private void ActionOfKillSlaveName(INormNpc normNpc, IPlayerActor playerActor, QuestActionInfo questActionInfo, ref bool Success)
        {
            string sSlaveName = questActionInfo.sParam1;
            if (string.IsNullOrEmpty(sSlaveName))
            {
                ScriptActionError(playerActor,"", questActionInfo, ExecutionCode.KillSlaveName);
                return;
            }
            if (sSlaveName.Equals("*") || string.Compare(sSlaveName, "ALL", StringComparison.OrdinalIgnoreCase) == 0)
            {
                for (int i = 0; i < playerActor.SlaveList.Count; i++)
                {
                    playerActor.SlaveList[i].WAbil.HP = 0;
                }
                return;
            }
            for (int i = 0; i < playerActor.SlaveList.Count; i++)
            {
                IActor baseObject = playerActor.SlaveList[i];
                if (!baseObject.Death && (string.Compare(sSlaveName, baseObject.ChrName, StringComparison.OrdinalIgnoreCase) == 0))
                {
                    baseObject.WAbil.HP = 0;
                }
            }
        }

        private void ActionOfQueryValue(INormNpc normNpc, IPlayerActor playerActor, QuestActionInfo questActionInfo, ref bool Success)
        {
            int btStrLabel = questActionInfo.nParam1;
            if (btStrLabel < 100)
            {
                btStrLabel = 0;
            }
            playerActor.ValLabel = (byte)btStrLabel;
            byte btType = (byte)questActionInfo.nParam2;
            if (btType > 3)
            {
                btType = 0;
            }
            playerActor.ValType = btType;
            int btLen = HUtil32._MAX(1, questActionInfo.nParam3);
            playerActor.GotoNpcLabel = questActionInfo.sParam4;
            string sHint = questActionInfo.sParam5;
            playerActor.ValNpcType = 0;
            if (string.Compare(questActionInfo.sParam6, "QF", StringComparison.OrdinalIgnoreCase) == 0)
            {
                playerActor.ValNpcType = 1;
            }
            else if (string.Compare(questActionInfo.sParam6, "QM", StringComparison.OrdinalIgnoreCase) == 0)
            {
                playerActor.ValNpcType = 2;
            }
            if (string.IsNullOrEmpty(sHint))
            {
                sHint = "请输入：";
            }
            playerActor.SendDefMessage(Messages.SM_QUERYVALUE, 0, HUtil32.MakeWord(btType, (ushort)btLen), 0, 0, sHint);
        }

        private void ActionOfQueryBagItems(INormNpc normNpc, IPlayerActor playerActor, QuestActionInfo questActionInfo, ref bool Success)
        {
            Success = true;
            if ((HUtil32.GetTickCount() - playerActor.QueryBagItemsTick) > configuration.Config.QueryBagItemsTick)
            {
                playerActor.QueryBagItemsTick = HUtil32.GetTickCount();
                playerActor.ClientQueryBagItems();
            }
            else
            {
                playerActor.SysMsg(Settings.QUERYBAGITEMS, MsgColor.Red, MsgType.Hint);
            }
        }

        private void ActionOfSetSendMsgFlag(INormNpc normNpc, IPlayerActor playerActor, QuestActionInfo questActionInfo, ref bool Success)
        {
            Success = true;
            playerActor.BoSendMsgFlag = true;
        }

        /// <summary>
        /// 开通元宝交易
        /// </summary>
        private void ActionOfOpenSaleDeal(INormNpc normNpc, IPlayerActor playerActor, QuestActionInfo questActionInfo, ref bool Success)
        {
            var nGameGold = 0;
            try
            {
                if (playerActor.SaleDeal)
                {
                    playerActor.SendMsg(normNpc, Messages.RM_MERCHANTSAY, 0, 0, 0, 0, playerActor.ChrName + "/您已开通寄售服务,不需要再开通!!!\\ \\<返回/@main>");
                    return;// 如已开通元宝服务则退出
                }
                if (!GetValValue(playerActor,questActionInfo.sParam1, ref nGameGold))
                {
                    nGameGold = HUtil32.StrToInt(GetLineVariableText(playerActor,questActionInfo.sParam1), 0);
                }
                if (playerActor.GameGold >= nGameGold)// 玩家的元宝数大于或等于开通所需的元宝数
                {
                    playerActor.GameGold -= nGameGold;
                    playerActor.SaleDeal = true;
                    playerActor.SendMsg(normNpc, Messages.RM_MERCHANTSAY, 0, 0, 0, 0, playerActor.ChrName + "/开通寄售服务成功!!!\\ \\<返回/@main>");
                }
                else
                {
                    playerActor.SendMsg(normNpc, Messages.RM_MERCHANTSAY, 0, 0, 0, 0, playerActor.ChrName + "/您身上没有" + configuration.Config.GameGoldName + ",或" + configuration.Config.GameGoldName + "数不够!!!\\ \\<返回/@main>");
                }
            }
            catch
            {
                ModuleShare.Logger.Error("{异常} TNormNpc.ActionOfOPENYBDEAL");
            }
        }

        /// <summary>
        /// 查询正在出售的物品
        /// </summary>
        private void ActionOfQuerySaleSell(INormNpc normNpc, IPlayerActor playerActor, QuestActionInfo questActionInfo, ref bool Success)
        {
            try
            {
                var bo12 = false;
                if (playerActor.SaleDeal) // 已开通元宝服务
                {
                    if (playerActor.SellOffInTime(0))
                    {
                        if (ModuleShare.SellOffItemList.Count > 0)
                        {
                            var sClientDealOffInfo = new ClientDealOffInfo();
                            sClientDealOffInfo.UseItems = new ClientItem[9];
                            for (var i = 0; i < ModuleShare.SellOffItemList.Count; i++)
                            {
                                var dealOffInfo = ModuleShare.SellOffItemList[i];
                                if (string.Compare(dealOffInfo.sDealChrName, playerActor.ChrName, StringComparison.OrdinalIgnoreCase) == 0 && (dealOffInfo.Flag == 0 || dealOffInfo.Flag == 3))
                                {
                                    for (var j = 0; j < 9; j++)
                                    {
                                        if (dealOffInfo.UseItems[j] == null)
                                        {
                                            continue;
                                        }
                                        var stdItem = ModuleShare.ItemSystem.GetStdItem(dealOffInfo.UseItems[j].Index);
                                        if (stdItem == null)
                                        {
                                            // 是金刚石
                                            if (!bo12 && dealOffInfo.UseItems[j].MakeIndex > 0 && dealOffInfo.UseItems[j].Index == ushort.MaxValue && dealOffInfo.UseItems[j].Dura == ushort.MaxValue && dealOffInfo.UseItems[j].DuraMax == ushort.MaxValue)
                                            {
                                                var wvar1 = sClientDealOffInfo.UseItems[j];// '金刚石'
                                                //_wvar1.S.Name = Settings.Config.sGameDiaMond + '(' + (DealOffInfo.UseItems[K].MakeIndex).ToString() + ')';
                                                //_wvar1.S.Price = DealOffInfo.UseItems[K].MakeIndex;// 金刚石数量
                                                wvar1.Dura = ushort.MaxValue;// 客户端金刚石特征
                                                wvar1.Item.DuraMax = ushort.MaxValue;// 客户端金刚石特征
                                                wvar1.Item.Looks = ushort.MaxValue;// 不显示图片
                                                bo12 = true;
                                            }
                                            else
                                            {
                                                sClientDealOffInfo.UseItems[j].Item.Name = "";
                                            }
                                            continue;
                                        }
                                        //M2Share.ItemUnit.GetItemAddValue(DealOffInfo.UseItems[K], ref StdItem80);
                                        //Move(StdItem80, sClientDealOffInfo.UseItems[K].S, sizeof(TStdItem));
                                        sClientDealOffInfo.UseItems[j] = new ClientItem();
                                       // M2Share.ItemSystem.GetUpgradeStdItem(stdItem, dealOffInfo.UseItems[j], ref sClientDealOffInfo.UseItems[j]);
                                        //sClientDealOffInfo.UseItems[j].S = StdItem80;
                                        // 取自定义物品名称
                                        //var sUserItemName = string.Empty;
                                        //if (dealOffInfo.UseItems[j].Desc[13] == 1)
                                        //{
                                        //    sUserItemName = M2Share.CustomItemMgr.GetCustomItemName(dealOffInfo.UseItems[j].MakeIndex, dealOffInfo.UseItems[j].Index);
                                        //    if (!string.IsNullOrEmpty(sUserItemName))
                                        //    {
                                        //        sClientDealOffInfo.UseItems[j].Item.Name = sUserItemName;
                                        //    }
                                        //}
                                        sClientDealOffInfo.UseItems[j].MakeIndex = dealOffInfo.UseItems[j].MakeIndex;
                                        sClientDealOffInfo.UseItems[j].Dura = dealOffInfo.UseItems[j].Dura;
                                        sClientDealOffInfo.UseItems[j].DuraMax = dealOffInfo.UseItems[j].DuraMax;
                                        switch (stdItem.StdMode)
                                        {
                                            case 15:
                                            case 19:
                                            case 26:
                                                if (dealOffInfo.UseItems[j].Desc[8] != 0)
                                                {
                                                    sClientDealOffInfo.UseItems[j].Item.Shape = 130;
                                                }
                                                break;
                                        }
                                    }
                                    sClientDealOffInfo.DealChrName = dealOffInfo.sDealChrName;
                                    sClientDealOffInfo.BuyChrName = dealOffInfo.sBuyChrName;
                                    sClientDealOffInfo.SellDateTime = HUtil32.DateTimeToDouble(dealOffInfo.dSellDateTime);
                                    sClientDealOffInfo.SellGold = dealOffInfo.nSellGold;
                                    sClientDealOffInfo.N = dealOffInfo.Flag;
                                    var sSendStr = EDCode.EncodeBuffer(sClientDealOffInfo);
                                    playerActor.SendMsg(normNpc, Messages.RM_QUERYYBSELL, 0, 0, 0, 0, sSendStr);
                                    break;
                                }
                            }
                        }
                    }
                    else
                    {
                        normNpc.GotoLable(playerActor,"@AskYBSellFail", false);
                    }
                }
                else
                {
                    playerActor.SendMsg(playerActor,Messages.RM_MENU_OK, 0, playerActor.ActorId, 0, 0, "您未开通寄售服务,请先开通!!!");
                }
            }
            catch
            {
                ModuleShare.Logger.Error("{异常} TNormNpc.ActionOfQUERYYBSELL");
            }
        }

        /// <summary>
        /// 查询可以的购买物品
        /// </summary>
        private void ActionOfQueryTrustDeal(INormNpc normNpc, IPlayerActor playerActor, QuestActionInfo questActionInfo, ref bool Success)
        {
            try
            {
                var bo12 = false;
                if (playerActor.SaleDeal)  // 已开通元宝服务
                {
                    if (playerActor.SellOffInTime(1))
                    {
                        if (ModuleShare.SellOffItemList.Count > 0)
                        {
                            var sClientDealOffInfo = new ClientDealOffInfo();
                            sClientDealOffInfo.UseItems = new ClientItem[9];
                            for (var i = 0; i < ModuleShare.SellOffItemList.Count; i++)
                            {
                                var dealOffInfo = ModuleShare.SellOffItemList[i];
                                if (string.Compare(dealOffInfo.sBuyChrName, playerActor.ChrName, StringComparison.OrdinalIgnoreCase) == 0 && dealOffInfo.Flag == 0)
                                {
                                    for (var k = 0; k < 9; k++)
                                    {
                                        if (dealOffInfo.UseItems[k] == null)
                                        {
                                            continue;
                                        }
                                        var stdItem = ModuleShare.ItemSystem.GetStdItem(dealOffInfo.UseItems[k].Index);
                                        if (stdItem == null)
                                        {
                                            // 是金刚石
                                            if (!bo12 && dealOffInfo.UseItems[k].MakeIndex > 0 && dealOffInfo.UseItems[k].Index == short.MaxValue && dealOffInfo.UseItems[k].Dura == short.MaxValue && dealOffInfo.UseItems[k].DuraMax == short.MaxValue)
                                            {
                                                var wvar1 = sClientDealOffInfo.UseItems[k];// '金刚石'
                                                //_wvar1.S.Name = Settings.Config.sGameDiaMond + '(' + (DealOffInfo.UseItems[K].MakeIndex).ToString() + ')';
                                                //_wvar1.S.Price = DealOffInfo.UseItems[K].MakeIndex;
                                                //// 金刚石数量
                                                //_wvar1.Dura = UInt16.MaxValue;// 客户端金刚石特征
                                                //_wvar1.S.DuraMax = Int16.MaxValue;// 客户端金刚石特征
                                                //_wvar1.S.Looks = UInt16.MaxValue;// 不显示图片
                                                bo12 = true;
                                            }
                                            else
                                            {
                                                sClientDealOffInfo.UseItems[k].Item.Name = "";
                                            }
                                            continue;
                                        }

                                        //M2Share.ItemUnit.GetItemAddValue(DealOffInfo.UseItems[K], ref StdItem80);
                                        //Move(StdItem80, sClientDealOffInfo.UseItems[K].S);// 取自定义物品名称
                                        //sClientDealOffInfo.UseItems[K].S = StdItem80;
                                        sClientDealOffInfo.UseItems[k] = new ClientItem();
                                        //StdItem80.GetStandardItem(ref sClientDealOffInfo.UseItems[k].Item);
                                        var sUserItemName = string.Empty;
                                        if (dealOffInfo.UseItems[k].Desc[13] == 1)
                                        {
                                           // sUserItemName = M2Share.CustomItemMgr.GetCustomItemName(dealOffInfo.UseItems[k].MakeIndex, dealOffInfo.UseItems[k].Index);
                                        }
                                        if (!string.IsNullOrEmpty(sUserItemName))
                                        {
                                            sClientDealOffInfo.UseItems[k].Item.Name = sUserItemName;
                                        }
                                        sClientDealOffInfo.UseItems[k].MakeIndex = dealOffInfo.UseItems[k].MakeIndex;
                                        sClientDealOffInfo.UseItems[k].Dura = dealOffInfo.UseItems[k].Dura;
                                        sClientDealOffInfo.UseItems[k].DuraMax = dealOffInfo.UseItems[k].DuraMax;
                                        switch (stdItem.StdMode)
                                        {
                                            // Modify the A .. B: 15, 19 .. 24, 26
                                            case 15:
                                            case 19:
                                            case 26:
                                                if (dealOffInfo.UseItems[k].Desc[8] != 0)
                                                {
                                                    sClientDealOffInfo.UseItems[k].Item.Shape = 130;
                                                }
                                                break;
                                        }
                                    }
                                    sClientDealOffInfo.DealChrName = dealOffInfo.sDealChrName;
                                    sClientDealOffInfo.BuyChrName = dealOffInfo.sBuyChrName;
                                    sClientDealOffInfo.SellDateTime = HUtil32.DateTimeToDouble(dealOffInfo.dSellDateTime);
                                    sClientDealOffInfo.SellGold = dealOffInfo.nSellGold;
                                    sClientDealOffInfo.N = dealOffInfo.Flag;
                                    var sSendStr = EDCode.EncodeBuffer(sClientDealOffInfo);
                                    playerActor.SendMsg(normNpc, Messages.RM_QUERYYBDEAL, 0, 0, 0, 0, sSendStr);
                                    break;
                                }
                            }
                        }
                    }
                    else
                    {
                        normNpc.GotoLable(playerActor,"@AskYBDealFail", false);
                    }
                }
                else
                {
                    playerActor.SendMsg(playerActor,Messages.RM_MENU_OK, 0, playerActor.ActorId, 0, 0, "您未开通元宝寄售服务,请先开通!!!");
                }
            }
            catch
            {
                ModuleShare.Logger.Error("{异常} TNormNpc.ActionOfQueryTrustDeal");
            }
        }

        private void ActionOfAddNameDateList(INormNpc normNpc, IPlayerActor playerActor, QuestActionInfo questActionInfo, ref bool Success)
        {
            var sHumName = string.Empty;
            var sDate = string.Empty;
            var sListFileName = ModuleShare.GetEnvirFilePath(normNpc.m_sPath, questActionInfo.sParam1);
            using var loadList = new StringList();
            if (File.Exists(sListFileName))
            {
                loadList.LoadFromFile(sListFileName);
            }
            var boFound = false;
            for (var i = 0; i < loadList.Count; i++)
            {
                var sLineText = loadList[i].Trim();
                sLineText = HUtil32.GetValidStr3(sLineText, ref sHumName, new[] { ' ', '\t' });
                sLineText = HUtil32.GetValidStr3(sLineText, ref sDate, new[] { ' ', '\t' });
                if (string.Compare(sHumName, playerActor.ChrName, StringComparison.OrdinalIgnoreCase) == 0)
                {
                    loadList[i] = playerActor.ChrName + "\t" + DateTime.Today;
                    boFound = true;
                    break;
                }
            }
            if (!boFound)
            {
                loadList.Add(playerActor.ChrName + "\t" + DateTime.Today);
            }
            try
            {
                loadList.SaveToFile(sListFileName);
            }
            catch
            {
                ModuleShare.Logger.Error("saving fail.... => " + sListFileName);
            }
        }

        private void ActionOfDelNameDateList(INormNpc normNpc, IPlayerActor playerActor, QuestActionInfo questActionInfo, ref bool Success)
        {
            var sHumName = string.Empty;
            var sDate = string.Empty;
            var sListFileName = ModuleShare.GetEnvirFilePath(normNpc.m_sPath, questActionInfo.sParam1);
            using var loadList = new StringList();
            if (File.Exists(sListFileName))
            {
                loadList.LoadFromFile(sListFileName);
            }
            var boFound = false;
            for (var i = 0; i < loadList.Count; i++)
            {
                var sLineText = loadList[i].Trim();
                sLineText = HUtil32.GetValidStr3(sLineText, ref sHumName, new[] { ' ', '\t' });
                sLineText = HUtil32.GetValidStr3(sLineText, ref sDate, new[] { ' ', '\t' });
                if (string.Compare(sHumName, playerActor.ChrName, StringComparison.OrdinalIgnoreCase) == 0)
                {
                    loadList.RemoveAt(i);
                    boFound = true;
                    break;
                }
            }
            if (boFound)
            {
                loadList.SaveToFile(sListFileName);
            }
        }

        private void ActionOfAddSkill(INormNpc normNpc, IPlayerActor playerActor, QuestActionInfo questActionInfo, ref bool Success)
        {
            var nLevel = HUtil32._MIN(3, HUtil32.StrToInt(questActionInfo.sParam2, 0));
            var magic = ModuleShare.WorldEngine.FindMagic(questActionInfo.sParam1);
            if (magic != null)
            {
                if (!playerActor.IsTrainingSkill(magic.MagicId))
                {
                    var userMagic = new UserMagic();
                    userMagic.Magic = magic;
                    userMagic.MagIdx = magic.MagicId;
                    userMagic.Key = (char)0;
                    userMagic.Level = (byte)nLevel;
                    userMagic.TranPoint = 0;
                    playerActor.MagicList.Add(userMagic);
                    playerActor.SendAddMagic(userMagic);
                    playerActor.RecalcAbilitys();
                    if (configuration.Config.ShowScriptActionMsg)
                    {
                        playerActor.SysMsg(magic.MagicName + "练习成功。", MsgColor.Green, MsgType.Hint);
                    }
                }
            }
            else
            {
                ScriptActionError(playerActor,"", questActionInfo, ExecutionCode.AddSkill);
            }
        }

        private void ActionOfAutoAddGameGold(INormNpc normNpc, IPlayerActor playerActor, QuestActionInfo questActionInfo, ref bool Success)
        {
            int nPoint = 0;
            int nTime = 0;
            if (string.Compare(questActionInfo.sParam1, "START", StringComparison.OrdinalIgnoreCase) == 0)
            {
                if (nPoint > 0 && nTime > 0)
                {
                    playerActor.IncGameGold = nPoint;
                    playerActor.IncGameGoldTime = nTime * 1000;
                    playerActor.IncGameGoldTick = HUtil32.GetTickCount();
                    playerActor.BoIncGameGold = true;
                    return;
                }
            }
            if (string.Compare(questActionInfo.sParam1, "STOP", StringComparison.OrdinalIgnoreCase) == 0)
            {
                playerActor.BoIncGameGold = false;
                return;
            }
            ScriptActionError(playerActor,"", questActionInfo, ExecutionCode.AutoAddGameGold);
        }

        // SETAUTOGETEXP 时间 点数 是否安全区 地图号
        private void ActionOfAutoGetExp(INormNpc normNpc, IPlayerActor playerActor, QuestActionInfo questActionInfo, ref bool Success)
        {
            IEnvirnoment envir = null;
            var nTime = HUtil32.StrToInt(questActionInfo.sParam1, -1);
            var nPoint = HUtil32.StrToInt(questActionInfo.sParam2, -1);
            var boIsSafeZone = questActionInfo.sParam3[1] == '1';
            var sMap = questActionInfo.sParam4;
            if (string.IsNullOrEmpty(sMap))
            {
                envir = ModuleShare.MapMgr.FindMap(sMap);
            }
            if (nTime <= 0 || nPoint <= 0 || string.IsNullOrEmpty(sMap) && envir == null)
            {
                ScriptActionError(playerActor,"", questActionInfo, ExecutionCode.SetautogetExp);
                return;
            }
            playerActor.AutoGetExpInSafeZone = boIsSafeZone;
            playerActor.AutoGetExpEnvir = envir;
            playerActor.AutoGetExpTime = nTime * 1000;
            playerActor.AutoGetExpPoint = nPoint;
        }

        /// <summary>
        /// 增加挂机
        /// </summary>
        private void ActionOfOffLine(INormNpc normNpc, IPlayerActor playerActor, QuestActionInfo questActionInfo, ref bool Success)
        {
            const string sOffLineStartMsg = "系统已经为你开启了脱机泡点功能，你现在可以下线了……";
            playerActor.ClientMsg = Messages.MakeMessage(Messages.SM_SYSMESSAGE, playerActor.ActorId, HUtil32.MakeWord(configuration.Config.CustMsgFColor, configuration.Config.CustMsgBColor), 0, 1);
           // playerActor.SendSocket(playerActor.ClientMsg, EDCode.EncodeString(sOffLineStartMsg));
            var nTime = HUtil32.StrToInt(questActionInfo.sParam1, 5);
            var nPoint = HUtil32.StrToInt(questActionInfo.sParam2, 500);
            var nKickOffLine = HUtil32.StrToInt(questActionInfo.sParam3, 1440 * 15);
            playerActor.AutoGetExpInSafeZone = true;
            playerActor.AutoGetExpEnvir = playerActor.Envir;
            playerActor.AutoGetExpTime = nTime * 1000;
            playerActor.AutoGetExpPoint = nPoint;
            playerActor.OffLineFlag = true;
            playerActor.KickOffLineTick = HUtil32.GetTickCount() + nKickOffLine * 60 * 1000;
         //   IdSrvClient.Instance.SendHumanLogOutMsgA(playerActor.UserAccount, playerActor.SessionId);
            playerActor.SendDefMessage(Messages.SM_OUTOFCONNECTION, 0, 0, 0, 0);
        }

        private void ActionOfAutoSubGameGold(INormNpc normNpc, IPlayerActor playerActor, QuestActionInfo questActionInfo, ref bool Success)
        {
            int nPoint = 0;
            int nTime = 0;
            if (string.Compare(questActionInfo.sParam1, "START", StringComparison.OrdinalIgnoreCase) == 0)
            {
                if (nPoint > 0 && nTime > 0)
                {
                    playerActor.DecGameGold = nPoint;
                    playerActor.DecGameGoldTime = nTime * 1000;
                    playerActor.DecGameGoldTick = 0;
                    playerActor.BoDecGameGold = true;
                    return;
                }
            }
            if (string.Compare(questActionInfo.sParam1, "STOP", StringComparison.OrdinalIgnoreCase) == 0)
            {
                playerActor.BoDecGameGold = false;
                return;
            }
            ScriptActionError(playerActor,"", questActionInfo, ExecutionCode.AutoSubGameGold);
        }

        private void ActionOfChangeCreditPoint(INormNpc normNpc, IPlayerActor playerActor, QuestActionInfo questActionInfo, ref bool Success)
        {
            var nCreditPoint = (byte)HUtil32.StrToInt(questActionInfo.sParam2, -1);
            if (nCreditPoint < 0)
            {
                ScriptActionError(playerActor,"", questActionInfo, ExecutionCode.CreditPoint);
                return;
            }
            var cMethod = questActionInfo.sParam1[0];
            switch (cMethod)
            {
                case '=':
                    if (nCreditPoint >= 0)
                    {
                        if (nCreditPoint > byte.MaxValue)
                        {
                            playerActor.CreditPoint = byte.MaxValue;
                        }
                        else
                        {
                            playerActor.CreditPoint = nCreditPoint;
                        }
                    }
                    break;
                case '-':
                    if (playerActor.CreditPoint > nCreditPoint)
                    {
                        playerActor.CreditPoint -= nCreditPoint;
                    }
                    else
                    {
                        playerActor.CreditPoint = 0;
                    }
                    break;
                case '+':
                    if (playerActor.CreditPoint + nCreditPoint > byte.MaxValue)
                    {
                        playerActor.CreditPoint = byte.MaxValue;
                    }
                    else
                    {
                        playerActor.CreditPoint += nCreditPoint;
                    }
                    break;
                default:
                    ScriptActionError(playerActor,"", questActionInfo, ExecutionCode.CreditPoint);
                    return;
            }
        }

        private void ActionOfChangeExp(INormNpc normNpc, IPlayerActor playerActor, QuestActionInfo questActionInfo, ref bool Success)
        {
            int dwInt;
            var nExp = HUtil32.StrToInt(questActionInfo.sParam2, -1);
            if (nExp < 0)
            {
                ScriptActionError(playerActor,"", questActionInfo, ExecutionCode.ChangeExp);
                return;
            }
            var cMethod = questActionInfo.sParam1[0];
            switch (cMethod)
            {
                case '=':
                    if (nExp > 0)
                    {
                        playerActor.Abil.Exp = nExp;
                    }
                    break;
                case '-':
                    if (playerActor.Abil.Exp > nExp)
                    {
                        playerActor.Abil.Exp -= nExp;
                    }
                    else
                    {
                        playerActor.Abil.Exp = 0;
                    }
                    break;
                case '+':
                    if (playerActor.Abil.Exp >= nExp)
                    {
                        if (playerActor.Abil.Exp - nExp > int.MaxValue - playerActor.Abil.Exp)
                        {
                            dwInt = int.MaxValue - playerActor.Abil.Exp;
                        }
                        else
                        {
                            dwInt = nExp;
                        }
                    }
                    else
                    {
                        if (nExp - playerActor.Abil.Exp > int.MaxValue - nExp)
                        {
                            dwInt = int.MaxValue - nExp;
                        }
                        else
                        {
                            dwInt = nExp;
                        }
                    }
                    playerActor.Abil.Exp += dwInt;
                    // playerActor.GetExp(dwInt);
                    playerActor.SendMsg(playerActor,Messages.RM_WINEXP, 0, dwInt, 0, 0);
                    break;
            }
        }

        private void ActionOfChangeHairStyle(INormNpc normNpc, IPlayerActor playerActor, QuestActionInfo questActionInfo, ref bool Success)
        {
            var nHair = HUtil32.StrToInt(questActionInfo.sParam1, -1);
            if ((!string.IsNullOrEmpty(questActionInfo.sParam1)) && nHair >= 0)
            {
                playerActor.Hair = (byte)nHair;
                playerActor.FeatureChanged();
            }
            else
            {
                ScriptActionError(playerActor,"", questActionInfo, ExecutionCode.Hairstyle);
            }
        }

        private void ActionOfChangeJob(INormNpc normNpc, IPlayerActor playerActor, QuestActionInfo questActionInfo, ref bool Success)
        {
            var nJob = PlayJob.None;
            if (HUtil32.CompareLStr(questActionInfo.sParam1, ScriptFlagCode.sWarrior))
            {
                nJob = PlayJob.Warrior;
            }
            if (HUtil32.CompareLStr(questActionInfo.sParam1, ScriptFlagCode.sWizard))
            {
                nJob = PlayJob.Wizard;
            }
            if (HUtil32.CompareLStr(questActionInfo.sParam1, ScriptFlagCode.sTaos))
            {
                nJob = PlayJob.Taoist;
            }
            if (nJob == PlayJob.None)
            {
                ScriptActionError(playerActor,"", questActionInfo, ExecutionCode.ChangeJob);
                return;
            }
            if (playerActor.Job != nJob)
            {
                playerActor.Job = nJob;
                playerActor.HasLevelUp(0);
            }
        }

        private void ActionOfChangeLevel(INormNpc normNpc, IPlayerActor playerActor, QuestActionInfo questActionInfo, ref bool Success)
        {
            int nLv;
            var boChgOk = false;
            ushort nOldLevel = playerActor.Abil.Level;
            var nLevel = HUtil32.StrToInt(questActionInfo.sParam2, -1);
            if (nLevel < 0)
            {
                ScriptActionError(playerActor,"", questActionInfo, ExecutionCode.ChangeLevel);
                return;
            }
            var cMethod = questActionInfo.sParam1[0];
            switch (cMethod)
            {
                case '=':
                    if (nLevel > 0 && nLevel <= Grobal2.MaxLevel)
                    {
                        playerActor.Abil.Level = (byte)nLevel;
                        boChgOk = true;
                    }
                    break;
                case '-':
                    nLv = HUtil32._MAX(0, playerActor.Abil.Level - nLevel);
                    nLv = HUtil32._MIN(Grobal2.MaxLevel, nLv);
                    playerActor.Abil.Level = (byte)nLv;
                    boChgOk = true;
                    break;
                case '+':
                    nLv = HUtil32._MAX(0, playerActor.Abil.Level + nLevel);
                    nLv = HUtil32._MIN(Grobal2.MaxLevel, nLv);
                    playerActor.Abil.Level = (byte)nLv;
                    boChgOk = true;
                    break;
            }
            if (boChgOk)
            {
                playerActor.HasLevelUp(nOldLevel);
            }
        }

        private void ActionOfChangePkPoint(INormNpc normNpc, IPlayerActor playerActor, QuestActionInfo questActionInfo, ref bool Success)
        {
            int nPoint;
            var nOldPkLevel = playerActor.PvpLevel();
            var nPkPoint = HUtil32.StrToInt(questActionInfo.sParam2, -1);
            if (nPkPoint < 0)
            {
                ScriptActionError(playerActor,"", questActionInfo, ExecutionCode.ChangePkPoint);
                return;
            }
            var cMethod = questActionInfo.sParam1[0];
            switch (cMethod)
            {
                case '=':
                    if (nPkPoint >= 0)
                    {
                        playerActor.PkPoint = nPkPoint;
                    }
                    break;
                case '-':
                    nPoint = HUtil32._MAX(0, playerActor.PkPoint - nPkPoint);
                    playerActor.PkPoint = nPoint;
                    break;
                case '+':
                    nPoint = HUtil32._MAX(0, playerActor.PkPoint + nPkPoint);
                    playerActor.PkPoint = nPoint;
                    break;
            }
            if (nOldPkLevel != playerActor.PvpLevel())
            {
                playerActor.RefNameColor();
            }
        }

        private void ActionOfClearMapMon(INormNpc normNpc, IPlayerActor playerActor, QuestActionInfo questActionInfo, ref bool Success)
        {
            IList<IActor> monList = new List<IActor>();
            var monsterCount = ModuleShare.WorldEngine.GetMapMonster(ModuleShare.MapMgr.FindMap(questActionInfo.sParam1), monList);
            for (var i = 0; i < monsterCount; i++)
            {
                var mon = monList[i];
                if (mon.Master != null)
                {
                    continue;
                }
                if (ModuleShare.GetNoClearMonList(mon.ChrName))
                {
                    continue;
                }
                mon.NoItem = true;
                mon.WAbil.HP = 0;
                mon.MakeGhost();
            }
        }

        private void ActionOfClearList(INormNpc normNpc, IPlayerActor playerActor, QuestActionInfo questActionInfo, ref bool Success)
        {
            var sListFileName = ModuleShare.GetEnvirFilePath(questActionInfo.sParam1);
            File.WriteAllBytes(sListFileName, Array.Empty<byte>());
        }

        private void ActionOfClearSkill(INormNpc normNpc, IPlayerActor playerActor, QuestActionInfo questActionInfo, ref bool Success)
        {
            for (var i = playerActor.MagicList.Count - 1; i >= 0; i--)
            {
                var userMagic = playerActor.MagicList[i];
                playerActor.SendDelMagic(userMagic);
                playerActor.MagicList.RemoveAt(i);
                Dispose(userMagic);
            }
            playerActor.RecalcAbilitys();
        }

        private void ActionOfDelNoJobSkill(INormNpc normNpc, IPlayerActor playerActor, QuestActionInfo questActionInfo, ref bool Success)
        {
            for (var i = playerActor.MagicList.Count - 1; i >= 0; i--)
            {
                var userMagic = playerActor.MagicList[i];
                if (userMagic.Magic.Job != (byte)playerActor.Job)
                {
                    playerActor.SendDelMagic(userMagic);
                    playerActor.MagicList.RemoveAt(i);
                    Dispose(userMagic);
                }
            }
        }

        private void ActionOfDelSkill(INormNpc normNpc, IPlayerActor playerActor, QuestActionInfo questActionInfo, ref bool Success)
        {
            var magic = ModuleShare.WorldEngine.FindMagic(questActionInfo.sParam1);
            if (magic == null)
            {
                ScriptActionError(playerActor,"", questActionInfo, ExecutionCode.DelSkill);
                return;
            }
            for (var i = 0; i < playerActor.MagicList.Count; i++)
            {
                var userMagic = playerActor.MagicList[i];
                if (string.CompareOrdinal(userMagic.Magic.MagicName, magic.MagicName) == 0)
                {
                    playerActor.MagicList.RemoveAt(i);
                    playerActor.SendDelMagic(userMagic);
                    Dispose(userMagic);
                    playerActor.RecalcAbilitys();
                    break;
                }
            }
        }

        private void ActionOfGameGold(INormNpc normNpc, IPlayerActor playerActor, QuestActionInfo questActionInfo, ref bool Success)
        {
            var nOldGameGold = playerActor.GameGold;
            var nGameGold = HUtil32.StrToInt(questActionInfo.sParam2, -1);
            if (nGameGold < 0)
            {
                ScriptActionError(playerActor,"", questActionInfo, ExecutionCode.GameGold);
                return;
            }
            var cMethod = questActionInfo.sParam1[0];
            switch (cMethod)
            {
                case '=':
                    if (nGameGold >= 0)
                    {
                        playerActor.GameGold = nGameGold;
                    }
                    break;
                case '-':
                    nGameGold = HUtil32._MAX(0, playerActor.GameGold - nGameGold);
                    playerActor.GameGold = nGameGold;
                    break;
                case '+':
                    nGameGold = HUtil32._MAX(0, playerActor.GameGold + nGameGold);
                    playerActor.GameGold = nGameGold;
                    break;
            }
            if (ModuleShare.GameLogGameGold)
            {
                // M2Share.EventSource.AddEventLog(Grobal2.LogGameGold, string.Format(CommandHelp.GameLogMsg1, playerActor.MapName, playerActor.CurrX, playerActor.CurrY, playerActor.ChrName, configuration.Config.GameGoldName, nGameGold, cMethod, normNpc.ChrName));
            }
            if (nOldGameGold != playerActor.GameGold)
            {
                playerActor.GameGoldChanged();
            }
        }

        private void ActionOfGamePoint(INormNpc normNpc, IPlayerActor playerActor, QuestActionInfo questActionInfo, ref bool Success)
        {
            var nOldGamePoint = playerActor.GamePoint;
            var nGamePoint = HUtil32.StrToInt(questActionInfo.sParam2, -1);
            if (nGamePoint < 0)
            {
                ScriptActionError(playerActor,"", questActionInfo, ExecutionCode.GamePoint);
                return;
            }
            var cMethod = questActionInfo.sParam1[0];
            switch (cMethod)
            {
                case '=':
                    if (nGamePoint >= 0)
                    {
                        playerActor.GamePoint = nGamePoint;
                    }
                    break;
                case '-':
                    nGamePoint = HUtil32._MAX(0, playerActor.GamePoint - nGamePoint);
                    playerActor.GamePoint = nGamePoint;
                    break;
                case '+':
                    nGamePoint = HUtil32._MAX(0, playerActor.GamePoint + nGamePoint);
                    playerActor.GamePoint = nGamePoint;
                    break;
            }
            if (ModuleShare.GameLogGamePoint)
            {
              //  M2Share.EventSource.AddEventLog(Grobal2.LogGamePoint, string.Format(CommandHelp.GameLogMsg1, playerActor.MapName, playerActor.CurrX, playerActor.CurrY, playerActor.ChrName, configuration.Config.GamePointName, nGamePoint, cMethod, normNpc.ChrName));
            }
            if (nOldGamePoint != playerActor.GamePoint)
            {
                playerActor.GameGoldChanged();
            }
        }

        private void ActionOfGetMarry(INormNpc normNpc, IPlayerActor playerActor, QuestActionInfo questActionInfo, ref bool Success)
        {
            var poseHuman = (IPlayerActor)playerActor.GetPoseCreate();
            if (poseHuman != null && poseHuman.Race == ActorRace.Play && (poseHuman).Gender != playerActor.Gender)
            {
                playerActor.DearName = poseHuman.ChrName;
                playerActor.RefShowName();
                poseHuman.RefShowName();
            }
            else
            {
                normNpc.GotoLable(playerActor,"@MarryError", false);
            }
        }

        private void ActionOfGetMaster(INormNpc normNpc, IPlayerActor playerActor, QuestActionInfo questActionInfo, ref bool Success)
        {
            var poseHuman = (IPlayerActor)playerActor.GetPoseCreate();
            if (poseHuman != null && poseHuman.Race == ActorRace.Play && (poseHuman).Gender != playerActor.Gender)
            {
                playerActor.MasterName = poseHuman.ChrName;
                playerActor.RefShowName();
                poseHuman.RefShowName();
            }
            else
            {
                normNpc.GotoLable(playerActor,"@MasterError", false);
            }
        }

        private void ActionOfLineMsg(INormNpc normNpc, IPlayerActor playerActor, QuestActionInfo questActionInfo, ref bool Success)
        {
            var sMsg = GetLineVariableText(playerActor,questActionInfo.sParam2);
            sMsg = sMsg.Replace("%s", playerActor.ChrName);
            sMsg = sMsg.Replace("%d", normNpc.ChrName);
            switch (questActionInfo.nParam1)
            {
                case 0:
                    ModuleShare.WorldEngine.SendBroadCastMsg(sMsg, MsgType.System);
                    break;
                case 1:
                    ModuleShare.WorldEngine.SendBroadCastMsg("(*) " + sMsg, MsgType.System);
                    break;
                case 2:
                    ModuleShare.WorldEngine.SendBroadCastMsg('[' + normNpc.ChrName + ']' + sMsg, MsgType.System);
                    break;
                case 3:
                    ModuleShare.WorldEngine.SendBroadCastMsg('[' + playerActor.ChrName + ']' + sMsg, MsgType.System);
                    break;
                case 4:
                    normNpc.SendSayMsg(sMsg);
                    break;
                case 5:
                    playerActor.SysMsg(sMsg, MsgColor.Red, MsgType.Say);
                    break;
                case 6:
                    playerActor.SysMsg(sMsg, MsgColor.Green, MsgType.Say);
                    break;
                case 7:
                    playerActor.SysMsg(sMsg, MsgColor.Blue, MsgType.Say);
                    break;
                case 8:
                    playerActor.SendGroupText(sMsg);
                    break;
                case 9:
                    if (playerActor.MyGuild != null)
                    {
                        playerActor.MyGuild.SendGuildMsg(sMsg);
                        //WorldServer.SendServerGroupMsg(Messages.SS_208, M2Share.ServerIndex, playerActor.MyGuild.GuildName + "/" + playerActor.ChrName + "/" + sMsg);
                    }
                    break;
                default:
                    ScriptActionError(playerActor,"", questActionInfo, ExecutionCode.SendMsg);
                    break;
            }
        }

        private void ActionOfMapTing(INormNpc normNpc, IPlayerActor playerActor, QuestActionInfo questActionInfo, ref bool Success)
        {

        }

        private void ActionOfMarry(INormNpc normNpc, IPlayerActor playerActor, QuestActionInfo questActionInfo, ref bool Success)
        {
            string sSayMsg;
            if (!string.IsNullOrEmpty(playerActor.DearName))
            {
                return;
            }
            var poseHuman = (IPlayerActor)playerActor.GetPoseCreate();
            if (poseHuman == null)
            {
                normNpc.GotoLable(playerActor,"@MarryCheckDir", false);
                return;
            }
            if (string.IsNullOrEmpty(questActionInfo.sParam1))
            {
                if (poseHuman.Race != ActorRace.Play)
                {
                    normNpc.GotoLable(playerActor,"@HumanTypeErr", false);
                    return;
                }
                if (poseHuman.GetPoseCreate() == playerActor)
                {
                    if (playerActor.Gender != poseHuman.Gender)
                    {
                        normNpc.GotoLable(playerActor,"@StartMarry", false);
                        normNpc.GotoLable(poseHuman, "@StartMarry", false);
                        if (playerActor.Gender == PlayGender.Man && poseHuman.Gender == PlayGender.WoMan)
                        {
                            sSayMsg = string.Format(Settings.StartMarryManMsg, normNpc.ChrName, playerActor.ChrName, poseHuman.ChrName);
                            ModuleShare.WorldEngine.SendBroadCastMsg(sSayMsg, MsgType.Say);
                            sSayMsg = string.Format(Settings.StartMarryManAskQuestionMsg, normNpc.ChrName, playerActor.ChrName, poseHuman.ChrName);
                            ModuleShare.WorldEngine.SendBroadCastMsg(sSayMsg, MsgType.Say);
                        }
                        else if (playerActor.Gender == PlayGender.WoMan && poseHuman.Gender == PlayGender.Man)
                        {
                            sSayMsg = string.Format(Settings.StartMarryWoManMsg, normNpc.ChrName, playerActor.ChrName, poseHuman.ChrName);
                            ModuleShare.WorldEngine.SendBroadCastMsg(sSayMsg, MsgType.Say);
                            sSayMsg = string.Format(Settings.StartMarryWoManAskQuestionMsg, normNpc.ChrName, playerActor.ChrName, poseHuman.ChrName);
                            ModuleShare.WorldEngine.SendBroadCastMsg(sSayMsg, MsgType.Say);
                        }
                        playerActor.IsStartMarry = true;
                        poseHuman.IsStartMarry = true;
                    }
                    else
                    {
                        normNpc.GotoLable(poseHuman, "@MarrySexErr", false);
                        normNpc.GotoLable(playerActor,"@MarrySexErr", false);
                    }
                }
                else
                {
                    normNpc.GotoLable(playerActor,"@MarryDirErr", false);
                    normNpc.GotoLable(poseHuman, "@MarryCheckDir", false);
                }
                return;
            }
            // sREQUESTMARRY
            if (string.Compare(questActionInfo.sParam1, "REQUESTMARRY", StringComparison.OrdinalIgnoreCase) == 0)
            {
                if (playerActor.IsStartMarry && poseHuman.IsStartMarry)
                {
                    if (playerActor.Gender == PlayGender.Man && poseHuman.Gender == PlayGender.WoMan)
                    {
                        sSayMsg = Settings.MarryManAnswerQuestionMsg.Replace("%n", normNpc.ChrName);
                        sSayMsg = sSayMsg.Replace("%s", playerActor.ChrName);
                        sSayMsg = sSayMsg.Replace("%d", poseHuman.ChrName);
                        ModuleShare.WorldEngine.SendBroadCastMsg(sSayMsg, MsgType.Say);
                        sSayMsg = Settings.MarryManAskQuestionMsg.Replace("%n", normNpc.ChrName);
                        sSayMsg = sSayMsg.Replace("%s", playerActor.ChrName);
                        sSayMsg = sSayMsg.Replace("%d", poseHuman.ChrName);
                        ModuleShare.WorldEngine.SendBroadCastMsg(sSayMsg, MsgType.Say);
                        normNpc.GotoLable(playerActor,"@WateMarry", false);
                        normNpc.GotoLable(poseHuman, "@RevMarry", false);
                    }
                }
                return;
            }
            // sRESPONSEMARRY
            if (string.Compare(questActionInfo.sParam1, "RESPONSEMARRY", StringComparison.OrdinalIgnoreCase) == 0)
            {
                if (playerActor.Gender == PlayGender.WoMan && poseHuman.Gender == PlayGender.Man)
                {
                    if (string.Compare(questActionInfo.sParam2, "OK", StringComparison.OrdinalIgnoreCase) == 0)
                    {
                        if (playerActor.IsStartMarry && poseHuman.IsStartMarry)
                        {
                            sSayMsg = string.Format(Settings.MarryWoManAnswerQuestionMsg, normNpc.ChrName, playerActor.ChrName, poseHuman.ChrName);
                            ModuleShare.WorldEngine.SendBroadCastMsg(sSayMsg, MsgType.Say);
                            sSayMsg = string.Format(Settings.MarryWoManGetMarryMsg, normNpc.ChrName, playerActor.ChrName, poseHuman.ChrName);
                            ModuleShare.WorldEngine.SendBroadCastMsg(sSayMsg, MsgType.Say);
                            normNpc.GotoLable(playerActor,"@EndMarry", false);
                            normNpc.GotoLable(poseHuman, "@EndMarry", false);
                            playerActor.IsStartMarry = false;
                            poseHuman.IsStartMarry = false;
                            playerActor.DearName = poseHuman.ChrName;
                            playerActor.DearHuman = poseHuman;
                            poseHuman.DearName = playerActor.ChrName;
                            poseHuman.DearHuman = playerActor;
                            playerActor.RefShowName();
                            poseHuman.RefShowName();
                        }
                    }
                    else
                    {
                        if (playerActor.IsStartMarry && poseHuman.IsStartMarry)
                        {
                            normNpc.GotoLable(playerActor,"@EndMarryFail", false);
                            normNpc.GotoLable(poseHuman, "@EndMarryFail", false);
                            playerActor.IsStartMarry = false;
                            poseHuman.IsStartMarry = false;
                            sSayMsg = string.Format(Settings.MarryWoManDenyMsg, normNpc.ChrName, playerActor.ChrName, poseHuman.ChrName);
                            ModuleShare.WorldEngine.SendBroadCastMsg(sSayMsg, MsgType.Say);
                            sSayMsg = string.Format(Settings.MarryWoManCancelMsg, normNpc.ChrName, playerActor.ChrName, poseHuman.ChrName);
                            ModuleShare.WorldEngine.SendBroadCastMsg(sSayMsg, MsgType.Say);
                        }
                    }
                }
            }
        }

        private void ActionOfMaster(INormNpc normNpc, IPlayerActor playerActor, QuestActionInfo questActionInfo, ref bool Success)
        {
            if (!string.IsNullOrEmpty(playerActor.MasterName))
            {
                return;
            }
            var poseHuman = (IPlayerActor)playerActor.GetPoseCreate();
            if (poseHuman == null)
            {
                normNpc.GotoLable(playerActor,"@MasterCheckDir", false);
                return;
            }
            if ((string.IsNullOrEmpty(questActionInfo.sParam1)))
            {
                if (poseHuman.Race != ActorRace.Play)
                {
                    normNpc.GotoLable(playerActor,"@HumanTypeErr", false);
                    return;
                }
                if (poseHuman.GetPoseCreate() == playerActor)
                {
                    normNpc.GotoLable(playerActor,"@StartGetMaster", false);
                    normNpc.GotoLable(poseHuman, "@StartMaster", false);
                    playerActor.IsStartMaster = true;
                    poseHuman.IsStartMaster = true;
                }
                else
                {
                    normNpc.GotoLable(playerActor,"@MasterDirErr", false);
                    normNpc.GotoLable(poseHuman, "@MasterCheckDir", false);
                }
                return;
            }
            if (string.Compare(questActionInfo.sParam1, "REQUESTMASTER", StringComparison.OrdinalIgnoreCase) == 0)
            {
                if (playerActor.IsStartMaster && poseHuman.IsStartMaster)
                {
                    playerActor.PoseBaseObject = poseHuman.ActorId;
                    poseHuman.PoseBaseObject = playerActor.ActorId;
                    normNpc.GotoLable(playerActor,"@WateMaster", false);
                    normNpc.GotoLable(poseHuman, "@RevMaster", false);
                }
                return;
            }
            if (string.Compare(questActionInfo.sParam1, "RESPONSEMASTER", StringComparison.OrdinalIgnoreCase) == 0)
            {
                if (string.Compare(questActionInfo.sParam2, "OK", StringComparison.OrdinalIgnoreCase) == 0)
                {
                    if (playerActor.PoseBaseObject == poseHuman.ActorId && poseHuman.PoseBaseObject == playerActor.ActorId)
                    {
                        if (playerActor.IsStartMaster && poseHuman.IsStartMaster)
                        {
                            normNpc.GotoLable(playerActor,"@EndMaster", false);
                            normNpc.GotoLable(poseHuman, "@EndMaster", false);
                            playerActor.IsStartMaster = false;
                            poseHuman.IsStartMaster = false;
                            if (string.IsNullOrEmpty(playerActor.MasterName))
                            {
                                playerActor.MasterName = poseHuman.ChrName;
                                playerActor.IsMaster = true;
                            }
                            playerActor.MasterList.Add(poseHuman);
                            poseHuman.MasterName = playerActor.ChrName;
                            poseHuman.IsMaster = false;
                            playerActor.RefShowName();
                            poseHuman.RefShowName();
                        }
                    }
                }
                else
                {
                    if (playerActor.IsStartMaster && poseHuman.IsStartMaster)
                    {
                        normNpc.GotoLable(playerActor,"@EndMasterFail", false);
                        normNpc.GotoLable(poseHuman, "@EndMasterFail", false);
                        playerActor.IsStartMaster = false;
                        poseHuman.IsStartMaster = false;
                    }
                }
            }
        }

        private void ActionOfMessageBox(INormNpc normNpc, IPlayerActor playerActor, QuestActionInfo questActionInfo, ref bool Success)
        {
            playerActor.SendMsg(normNpc, Messages.RM_MENU_OK, 0, playerActor.ActorId, 0, 0, GetLineVariableText(playerActor,questActionInfo.sParam1));
        }

        private void ActionOfMission(INormNpc normNpc, IPlayerActor playerActor, QuestActionInfo questActionInfo, ref bool Success)
        {
            if (!string.IsNullOrEmpty(questActionInfo.sParam1) && questActionInfo.nParam2 > 0 && questActionInfo.nParam3 > 0)
            {
                ModuleShare.MissionMap = questActionInfo.sParam1;
                ModuleShare.MissionX = (short)questActionInfo.nParam2;
                ModuleShare.MissionY = (short)questActionInfo.nParam3;
            }
            else
            {
                ScriptActionError(playerActor,"", questActionInfo, ExecutionCode.Mission);
            }
        }

        // MOBFIREBURN MAP X Y TYPE TIME POINT
        private void ActionOfMobFireBurn(INormNpc normNpc, IPlayerActor playerActor, QuestActionInfo questActionInfo, ref bool Success)
        {
            var sMap = questActionInfo.sParam1;
            var nX = HUtil32.StrToInt16(questActionInfo.sParam2, -1);
            var nY = HUtil32.StrToInt16(questActionInfo.sParam3, -1);
            var nType = (byte)HUtil32.StrToInt(questActionInfo.sParam4, -1);
            var nTime = HUtil32.StrToInt(questActionInfo.sParam5, -1);
            var nPoint = HUtil32.StrToInt(questActionInfo.sParam6, -1);
            if (string.IsNullOrEmpty(sMap) || nX < 0 || nY < 0 || nType < 0 || nTime < 0 || nPoint < 0)
            {
                ScriptActionError(playerActor,"", questActionInfo, ExecutionCode.MobFireburn);
                return;
            }
            //var envir = M2Share.MapMgr.FindMap(sMap);
            //if (envir != null)
            //{
            //    var oldEnvir = playerActor.Envir;
            //    playerActor.Envir = envir;
            //    var fireBurnEvent = new FireBurnEvent(playerActor,nX, nY, nType, nTime * 1000, nPoint);
            //    M2Share.EventMgr.AddEvent(fireBurnEvent);
            //    playerActor.Envir = oldEnvir;
            //    return;
            //}
            //ScriptActionError(playerActor,"", questActionInfo, ExecutionCode.MobFireburn);
        }

        private void ActionOfMobPlace(INormNpc normNpc, IPlayerActor playerActor, QuestActionInfo questActionInfo, ref bool Success)
        {
            int nX = 0;
            int nY = 0;
            int nCount = 0;
            int nRange = 0;
            for (var i = 0; i < nCount; i++)
            {
                var nRandX = (short)(ModuleShare.RandomNumber.Random(nRange * 2 + 1) + (nX - nRange));
                var nRandY = (short)(ModuleShare.RandomNumber.Random(nRange * 2 + 1) + (nY - nRange));
                var mon = ModuleShare.WorldEngine.RegenMonsterByName(ModuleShare.MissionMap, nRandX, nRandY, questActionInfo.sParam1);
                if (mon != null)
                {
                    mon.Mission = true;
                    mon.MissionX = ModuleShare.MissionX;
                    mon.MissionY = ModuleShare.MissionY;
                }
                else
                {
                    ScriptActionError(playerActor,"", questActionInfo, ExecutionCode.MobPlace);
                    break;
                }
            }
        }

        private void ActionOfRecallGroupMembers(INormNpc normNpc, IPlayerActor playerActor, QuestActionInfo questActionInfo, ref bool Success)
        {
        }

        private void ActionOfSetRankLevelName(INormNpc normNpc, IPlayerActor playerActor, QuestActionInfo questActionInfo, ref bool Success)
        {
            var sRankLevelName = questActionInfo.sParam1;
            if (string.IsNullOrEmpty(sRankLevelName))
            {
                ScriptActionError(playerActor,"", questActionInfo, ExecutionCode.SkillLevel);
                return;
            }
            playerActor.RankLevelName = sRankLevelName;
            playerActor.RefShowName();
        }

        private void ActionOfSetScriptFlag(INormNpc normNpc, IPlayerActor playerActor, QuestActionInfo questActionInfo, ref bool Success)
        {
            var nWhere = HUtil32.StrToInt(questActionInfo.sParam1, -1);
            var boFlag = HUtil32.StrToInt(questActionInfo.sParam2, -1) == 1;
            switch (nWhere)
            {
                case 0:
                    playerActor.BoSendMsgFlag = boFlag;
                    break;
                case 1:
                    playerActor.BoChangeItemNameFlag = boFlag;
                    break;
                default:
                    ScriptActionError(playerActor,"", questActionInfo, ExecutionCode.SetscriptFlag);
                    break;
            }
        }

        private void ActionOfSkillLevel(INormNpc normNpc, IPlayerActor playerActor, QuestActionInfo questActionInfo, ref bool Success)
        {
            var nLevel = HUtil32.StrToInt(questActionInfo.sParam3, 0);
            if (nLevel < 0)
            {
                ScriptActionError(playerActor,"", questActionInfo, ExecutionCode.SkillLevel);
                return;
            }
            var cMethod = questActionInfo.sParam2[0];
            var magic = ModuleShare.WorldEngine.FindMagic(questActionInfo.sParam1);
            if (magic != null)
            {
                for (var i = 0; i < playerActor.MagicList.Count; i++)
                {
                    var userMagic = playerActor.MagicList[i];
                    if (userMagic.Magic == magic)
                    {
                        switch (cMethod)
                        {
                            case '=':
                                if (nLevel >= 0)
                                {
                                    nLevel = HUtil32._MAX(3, nLevel);
                                    userMagic.Level = (byte)nLevel;
                                }
                                break;
                            case '-':
                                if (userMagic.Level >= nLevel)
                                {
                                    userMagic.Level -= (byte)nLevel;
                                }
                                else
                                {
                                    userMagic.Level = 0;
                                }
                                break;
                            case '+':
                                if (userMagic.Level + nLevel <= 3)
                                {
                                    userMagic.Level += (byte)nLevel;
                                }
                                else
                                {
                                    userMagic.Level = 3;
                                }
                                break;
                        }
                        playerActor.SendSelfDelayMsg(Messages.RM_MAGIC_LVEXP, 0, userMagic.Magic.MagicId, userMagic.Level, userMagic.TranPoint, "", 100);
                        break;
                    }
                }
            }
        }

        private void ActionOfTakeCastleGold(INormNpc normNpc, IPlayerActor playerActor, QuestActionInfo questActionInfo, ref bool Success)
        {
            var nGold = HUtil32.StrToInt(questActionInfo.sParam1, -1);
            if (nGold < 0 || normNpc.Castle == null)
            {
                ScriptActionError(playerActor,"", questActionInfo, ExecutionCode.TakeCastleGold);
                return;
            }
            if (nGold <= normNpc.Castle.TotalGold)
            {
                normNpc.Castle.TotalGold -= nGold;
            }
            else
            {
                normNpc.Castle.TotalGold = 0;
            }
        }

        private void ActionOfUnMarry(INormNpc normNpc, IPlayerActor playerActor, QuestActionInfo questActionInfo, ref bool Success)
        {
            if (string.IsNullOrEmpty(playerActor.DearName))
            {
                normNpc.GotoLable(playerActor,"@ExeMarryFail", false);
                return;
            }
            var poseHuman = (IPlayerActor)playerActor.GetPoseCreate();
            if (poseHuman == null)
            {
                normNpc.GotoLable(playerActor,"@UnMarryCheckDir", false);
            }
            if (poseHuman != null)
            {
                if (string.IsNullOrEmpty(questActionInfo.sParam1))
                {
                    if (poseHuman.Race != ActorRace.Play)
                    {
                        normNpc.GotoLable(playerActor,"@UnMarryTypeErr", false);
                        return;
                    }
                    if (poseHuman.GetPoseCreate() == playerActor)
                    {
                        if (playerActor.DearName == poseHuman.ChrName)
                        {
                            normNpc.GotoLable(playerActor,"@StartUnMarry", false);
                            normNpc.GotoLable(poseHuman, "@StartUnMarry", false);
                            return;
                        }
                    }
                }
            }
            // sREQUESTUNMARRY
            if (string.Compare(questActionInfo.sParam1, "REQUESTUNMARRY", StringComparison.OrdinalIgnoreCase) == 0)
            {
                if (string.IsNullOrEmpty(questActionInfo.sParam2))
                {
                    if (poseHuman != null)
                    {
                        playerActor.IsStartUnMarry = true;
                        if (playerActor.IsStartUnMarry && poseHuman.IsStartUnMarry)
                        {
                            // sUnMarryMsg8
                            // sMarryMsg0
                            // sUnMarryMsg9
                            ModuleShare.WorldEngine.SendBroadCastMsg('[' + normNpc.ChrName + "]: " + "我宣布" + poseHuman.ChrName + ' ' + '与' + playerActor.ChrName + ' ' + ' ' + "正式脱离夫妻关系。", MsgType.Say);
                            playerActor.DearName = "";
                            poseHuman.DearName = "";
                            playerActor.MarryCount++;
                            poseHuman.MarryCount++;
                            playerActor.IsStartUnMarry = false;
                            poseHuman.IsStartUnMarry = false;
                            playerActor.RefShowName();
                            poseHuman.RefShowName();
                            normNpc.GotoLable(playerActor,"@UnMarryEnd", false);
                            normNpc.GotoLable(poseHuman, "@UnMarryEnd", false);
                        }
                        else
                        {
                            normNpc.GotoLable(playerActor,"@WateUnMarry", false);
                            // GotoLable(PoseHuman,'@RevUnMarry',False);
                        }
                    }
                }
                else
                {
                    // 强行离婚
                    if (string.Compare(questActionInfo.sParam2, "FORCE", StringComparison.OrdinalIgnoreCase) == 0)
                    {
                        ModuleShare.WorldEngine.SendBroadCastMsg('[' + normNpc.ChrName + "]: " + "我宣布" + playerActor.ChrName + ' ' + '与' + playerActor.DearName + ' ' + ' ' + "已经正式脱离夫妻关系!!!", MsgType.Say);
                        poseHuman = ModuleShare.WorldEngine.GetPlayObject(playerActor.DearName);
                        if (poseHuman != null)
                        {
                            poseHuman.DearName = string.Empty;
                            poseHuman.MarryCount++;
                            poseHuman.RefShowName();
                        }
                        else
                        {
                            //sUnMarryFileName = Settings.Config.sEnvirDir + "UnMarry.txt";
                            //LoadList = new StringList();
                            //if (File.Exists(sUnMarryFileName))
                            //{
                            //    LoadList.LoadFromFile(sUnMarryFileName);
                            //}
                            //LoadList.Add(playerActor.m_sDearName);
                            //LoadList.SaveToFile(sUnMarryFileName);
                            //LoadList.Free;
                        }
                        playerActor.DearName = string.Empty;
                        playerActor.MarryCount++;
                        normNpc.GotoLable(playerActor,"@UnMarryEnd", false);
                        playerActor.RefShowName();
                    }
                }
            }
        }

        /// <summary>
        /// 保存变量值
        /// SAVEVAR 变量类型 变量名 文件名
        /// </summary>
        /// <param name="IPlayerActor"></param>
        /// <param name="questActionInfo"></param>
        private void ActionOfSaveVar(INormNpc normNpc, IPlayerActor playerActor, QuestActionInfo questActionInfo, ref bool Success)
        {
            var sName = string.Empty;
            DynamicVar dynamicVar = null;
            const string sVarFound = "变量{0}不存在，变量类型:{1}";
            const string sVarTypeError = "变量类型错误，错误类型:{0} 当前支持类型(HUMAN、GUILD、GLOBAL)";
            var sType = questActionInfo.sParam1;
            var sVarName = questActionInfo.sParam2;
            var sFileName = GetLineVariableText(playerActor,questActionInfo.sParam3);
            if (sFileName[0] == '\\')
            {
                sFileName = sFileName[1..];
            }
            if (sFileName[1] == '\\')
            {
                sFileName = sFileName[2..];
            }
            if (sFileName[2] == '\\')
            {
                sFileName = sFileName[3..];
            }
            sFileName = ModuleShare.GetEnvirFilePath(sFileName);
            if (string.IsNullOrEmpty(sType) || string.IsNullOrEmpty(sVarName) || !File.Exists(sFileName))
            {
                ScriptActionError(playerActor,"", questActionInfo, ExecutionCode.SaveVar);
                return;
            }
            var boFoundVar = false;
            var dynamicVarList = GetDynamicVarMap(playerActor,sType, ref sName);
            if (dynamicVarList == null)
            {
                Dispose(dynamicVar);
                ScriptActionError(playerActor,string.Format(sVarTypeError, sType), questActionInfo, ExecutionCode.Var);
                return;
            }
            if (dynamicVarList.TryGetValue(sVarName, out dynamicVar))
            {
                var iniFile = new ConfFile(sFileName);
                iniFile.Load();
                if (dynamicVar.VarType == VarType.Integer)
                {
                    dynamicVarList[sVarName].nInternet = dynamicVar.nInternet;
                    iniFile.WriteInteger(sName, dynamicVar.sName, dynamicVar.nInternet);
                }
                else
                {
                    dynamicVarList[sVarName].sString = dynamicVar.sString;
                    iniFile.WriteString(sName, dynamicVar.sName, dynamicVar.sString);
                }
                boFoundVar = true;
            }
            if (!boFoundVar)
            {
                ScriptActionError(playerActor,string.Format(sVarFound, sVarName, sType), questActionInfo, ExecutionCode.SaveVar);
            }
        }

        private void ActionOfDelayCall(INormNpc normNpc, IPlayerActor playerActor, QuestActionInfo questActionInfo, ref bool Success)
        {
            playerActor.DelayCall = HUtil32._MAX(1, questActionInfo.nParam1);
            playerActor.DelayCallLabel = questActionInfo.sParam2;
            playerActor.DelayCallTick = HUtil32.GetTickCount();
            playerActor.IsDelayCall = true;
            playerActor.DelayCallNpc = normNpc.ActorId;

            playerActor.IsTimeGoto = true;
            int mDelayGoto = HUtil32.StrToInt(GetLineVariableText(playerActor,questActionInfo.sParam1), 0);//变量操作
            if (mDelayGoto == 0)
            {
                int delayCount = 0;
                GetValValue(playerActor,questActionInfo.sParam1, ref delayCount);
                mDelayGoto = delayCount;
            }
            if (mDelayGoto > 0)
            {
                playerActor.TimeGotoTick = HUtil32.GetTickCount() + mDelayGoto;
            }
            else
            {
                playerActor.TimeGotoTick = HUtil32.GetTickCount() + questActionInfo.nParam1;//毫秒
            }
            playerActor.TimeGotoLable = questActionInfo.sParam2;
            playerActor.TimeGotoNpc = normNpc;
        }

        /// <summary>
        /// 对变量进行运算(+、-、*、/)
        /// </summary>
        /// <param name="IPlayerActor"></param>
        /// <param name="questActionInfo"></param>
        private void ActionOfCalcVar(INormNpc normNpc, IPlayerActor playerActor, QuestActionInfo questActionInfo, ref bool Success)
        {
            var sName = string.Empty;
            DynamicVar dynamicVar = null;
            var sVarValue2 = string.Empty;
            const string sVarFound = "变量{0}不存在，变量类型:{1}";
            const string sVarTypeError = "变量类型错误，错误类型:{0} 当前支持类型(HUMAN、GUILD、GLOBAL)";
            var sType = questActionInfo.sParam1;//类型
            var sVarName = questActionInfo.sParam2;//自定义变量
            var sMethod = questActionInfo.sParam3;//操作符 +-*/=
            var sVarValue = questActionInfo.sParam4;//变量
            var nVarValue = HUtil32.StrToInt(questActionInfo.sParam4, 0);
            if (string.IsNullOrEmpty(sType) || string.IsNullOrEmpty(sVarName) || string.IsNullOrEmpty(sMethod))
            {
                ScriptActionError(playerActor,"", questActionInfo, ExecutionCode.CalcVar);
                return;
            }
            var boFoundVar = false;
            if (!string.IsNullOrEmpty(sVarValue) && !HUtil32.IsStringNumber(sVarValue))
            {
                if (HUtil32.CompareLStr(sVarValue, "<$HUMAN(", 8))
                {
                    HUtil32.ArrestStringEx(sVarValue, "(", ")", ref sVarValue2);
                    sVarValue = sVarValue2;
                    if (playerActor.DynamicVarMap.Count > 0)
                    {
                        if (playerActor.DynamicVarMap.TryGetValue(sVarValue, out dynamicVar))
                        {
                            switch (dynamicVar.VarType)
                            {
                                case VarType.Integer:
                                    nVarValue = dynamicVar.nInternet;
                                    break;
                                case VarType.String:
                                    sVarValue = dynamicVar.sString;
                                    break;
                            }
                            boFoundVar = true;
                        }
                    }
                    if (!boFoundVar)
                    {
                        ScriptActionError(playerActor,string.Format(sVarFound, sVarValue, sType), questActionInfo, ExecutionCode.CalcVar);
                        return;
                    }
                }
                else
                {
                    nVarValue = HUtil32.StrToInt(GetLineVariableText(playerActor,sVarValue), 0);
                    sVarValue = GetLineVariableText(playerActor,sVarValue);
                }
            }
            else
            {
                nVarValue = HUtil32.StrToInt(questActionInfo.sParam4, 0);
            }
            var cMethod = sMethod[0];
            var dynamicVarList = GetDynamicVarMap(playerActor,sType, ref sName);
            if (dynamicVarList == null)
            {
                Dispose(dynamicVar);
                ScriptActionError(playerActor,string.Format(sVarTypeError, sType), questActionInfo, ExecutionCode.CalcVar);
                return;
            }

            if (playerActor.DynamicVarMap.TryGetValue(sVarName, out dynamicVar))
            {
                switch (dynamicVar.VarType)
                {
                    case VarType.Integer:
                        switch (cMethod)
                        {
                            case '=':
                                dynamicVar.nInternet = nVarValue;
                                break;
                            case '+':
                                dynamicVar.nInternet = dynamicVar.nInternet + nVarValue;
                                break;
                            case '-':
                                dynamicVar.nInternet = dynamicVar.nInternet - nVarValue;
                                break;
                            case '*':
                                dynamicVar.nInternet = dynamicVar.nInternet * nVarValue;
                                break;
                            case '/':
                                dynamicVar.nInternet = dynamicVar.nInternet / nVarValue;
                                break;
                        }
                        break;
                    case VarType.String:
                        switch (cMethod)
                        {
                            case '=':
                                dynamicVar.sString = sVarValue;
                                break;
                            case '+':
                                dynamicVar.sString = dynamicVar.sString + sVarValue;
                                break;
                            case '-':
                                break;
                        }
                        break;
                }
                boFoundVar = true;
            }
            if (!boFoundVar)
            {
                ScriptActionError(playerActor,string.Format(sVarFound, sVarName, sType), questActionInfo, ExecutionCode.CalcVar);
            }
        }

        private void ActionOfGuildRecall(INormNpc normNpc, IPlayerActor playerActor, QuestActionInfo questActionInfo, ref bool Success)
        {
            if (playerActor.MyGuild != null)
            {
                // playerActor.GuildRecall('GuildRecall','');
            }
        }

        private void ActionOfGroupAddList(INormNpc normNpc, IPlayerActor playerActor, QuestActionInfo questActionInfo, ref bool Success)
        {
            var ffile = questActionInfo.sParam1;
            if (playerActor.GroupOwner != 0)
            {
                for (var i = 0; i < playerActor.GroupMembers.Count; i++)
                {
                    var memberActor = playerActor.GroupMembers[i];
                    // AddListEx(playerActor.m_sChrName,ffile);
                }
            }
        }

        private void ActionOfGroupRecall(INormNpc normNpc, IPlayerActor playerActor, QuestActionInfo questActionInfo, ref bool Success)
        {
            if (playerActor.GroupOwner != 0)
            {
                // playerActor.GroupRecall('GroupRecall');
            }
        }

        /// <summary>
        /// 特修身上所有装备
        /// </summary>
        /// <param name="IPlayerActor"></param>
        /// <param name="questActionInfo"></param>
        private void ActionOfRepairAllItem(INormNpc normNpc, IPlayerActor playerActor, QuestActionInfo questActionInfo, ref bool Success)
        {
            var boIsHasItem = false;
            for (var i = 0; i < playerActor.UseItems.Length; i++)
            {
                if (playerActor.UseItems[i].Index <= 0)
                {
                    continue;
                }
                var sUserItemName = ModuleShare.ItemSystem.GetStdItemName(playerActor.UseItems[i].Index);
                if (!(i != ItemLocation.Charm))
                {
                    playerActor.SysMsg(sUserItemName + " 禁止修理...", MsgColor.Red, MsgType.Hint);
                    continue;
                }
                playerActor.UseItems[i].Dura = playerActor.UseItems[i].DuraMax;
                playerActor.SendMsg(normNpc, Messages.RM_DURACHANGE, (short)i, playerActor.UseItems[i].Dura, playerActor.UseItems[i].DuraMax, 0);
                boIsHasItem = true;
            }
            if (boIsHasItem)
            {
                playerActor.SysMsg("您身上的的装备修复成功了...", MsgColor.Blue, MsgType.Hint);
            }
        }

        private void ActionOfGroupMoveMap(INormNpc normNpc, IPlayerActor playerActor, QuestActionInfo questActionInfo, ref bool Success)
        {
            var boFlag = false;
            if (playerActor.GroupOwner != 0)
            {
                var envir = ModuleShare.MapMgr.FindMap(questActionInfo.sParam1);
                if (envir != null)
                {
                    if (envir.CanWalk(questActionInfo.nParam2, questActionInfo.nParam3, true))
                    {
                        for (var i = 0; i < playerActor.GroupMembers.Count; i++)
                        {
                            var IPlayerActorEx = playerActor.GroupMembers[i];
                            IPlayerActorEx.SpaceMove(questActionInfo.sParam1, (short)questActionInfo.nParam2, (short)questActionInfo.nParam3, 0);
                        }
                        boFlag = true;
                    }
                }
            }
            if (!boFlag)
            {
                ScriptActionError(playerActor,"", questActionInfo, ExecutionCode.GroupMoveMap);
            }
        }

        private void ActionOfUpgradeItems(INormNpc normNpc, IPlayerActor playerActor, QuestActionInfo questActionInfo, ref bool Success)
        {
            int nAddPoint;
            var nWhere = HUtil32.StrToInt(questActionInfo.sParam1, -1);
            var nRate = HUtil32.StrToInt(questActionInfo.sParam2, -1);
            var nPoint = HUtil32.StrToInt(questActionInfo.sParam3, -1);
            if (nWhere < 0 || nWhere > playerActor.UseItems.Length || nRate < 0 || nPoint < 0 || nPoint > 255)
            {
                ScriptActionError(playerActor,"", questActionInfo, ExecutionCode.UpgradeItems);
                return;
            }
            var userItem = playerActor.UseItems[nWhere];
            var stdItem = ModuleShare.ItemSystem.GetStdItem(userItem.Index);
            if (userItem.Index <= 0 || stdItem == null)
            {
                playerActor.SysMsg("你身上没有戴指定物品!!!", MsgColor.Red, MsgType.Hint);
                return;
            }
            nRate = ModuleShare.RandomNumber.Random(nRate);
            nPoint = ModuleShare.RandomNumber.Random(nPoint);
            var nValType = ModuleShare.RandomNumber.Random(14);
            if (nRate != 0)
            {
                playerActor.SysMsg("装备升级失败!!!", MsgColor.Red, MsgType.Hint);
                return;
            }
            if (nValType == 14)
            {
                nAddPoint = nPoint * 1000;
                if (userItem.DuraMax + nAddPoint > ushort.MaxValue)
                {
                    nAddPoint = ushort.MaxValue - userItem.DuraMax;
                }
                userItem.DuraMax = (ushort)(userItem.DuraMax + nAddPoint);
            }
            else
            {
                nAddPoint = nPoint;
                if (userItem.Desc[nValType] + nAddPoint > byte.MaxValue)
                {
                    nAddPoint = byte.MaxValue - userItem.Desc[nValType];
                }
                userItem.Desc[nValType] = (byte)(userItem.Desc[nValType] + nAddPoint);
            }
            playerActor.SendUpdateItem(userItem);
            playerActor.SysMsg("装备升级成功", MsgColor.Green, MsgType.Hint);
            playerActor.SysMsg(stdItem.Name + ": " + userItem.Dura + '/' + userItem.DuraMax + '/' + userItem.Desc[0] + '/' + userItem.Desc[1] + '/' + userItem.Desc[2] + '/' + userItem.Desc[3] + '/' + userItem.Desc[4] + '/' + userItem.Desc[5] + '/' + userItem.Desc[6] + '/' + userItem.Desc[7] + '/' + userItem.Desc[8] + '/' + userItem.Desc[9] + '/' + userItem.Desc[ItemAttr.WeaponUpgrade] + '/' + userItem.Desc[11] + '/' + userItem.Desc[12] + '/' + userItem.Desc[13], MsgColor.Blue, MsgType.Hint);
        }

        private void ActionOfUpgradeItemsEx(INormNpc normNpc, IPlayerActor playerActor, QuestActionInfo questActionInfo, ref bool Success)
        {
            int nAddPoint;
            var nWhere = HUtil32.StrToInt(questActionInfo.sParam1, -1);
            var nValType = HUtil32.StrToInt(questActionInfo.sParam2, -1);
            var nRate = HUtil32.StrToInt(questActionInfo.sParam3, -1);
            var nPoint = HUtil32.StrToInt(questActionInfo.sParam4, -1);
            var nUpgradeItemStatus = HUtil32.StrToInt(questActionInfo.sParam5, -1);
            if (nValType < 0 || nValType > 14 || nWhere < 0 || nWhere > playerActor.UseItems.Length || nRate < 0 || nPoint < 0 || nPoint > 255)
            {
                ScriptActionError(playerActor,"", questActionInfo, ExecutionCode.UpgradeItemSex);
                return;
            }
            var userItem = playerActor.UseItems[nWhere];
            var stdItem = ModuleShare.ItemSystem.GetStdItem(userItem.Index);
            if (userItem.Index <= 0 || stdItem == null)
            {
                playerActor.SysMsg("你身上没有戴指定物品!!!", MsgColor.Red, MsgType.Hint);
                return;
            }
            var nRatePoint = ModuleShare.RandomNumber.Random(nRate * 10);
            nPoint = HUtil32._MAX(1, ModuleShare.RandomNumber.Random(nPoint));
            if (!(nRatePoint >= 0 && nRatePoint <= 10))
            {
                switch (nUpgradeItemStatus)
                {
                    case 0:
                        playerActor.SysMsg("装备升级未成功!!!", MsgColor.Red, MsgType.Hint);
                        break;
                    case 1:
                        playerActor.SendDelItems(userItem);
                        userItem.Index = 0;
                        playerActor.SysMsg("装备破碎!!!", MsgColor.Red, MsgType.Hint);
                        break;
                    case 2:
                        playerActor.SysMsg("装备升级失败，装备属性恢复默认!!!", MsgColor.Red, MsgType.Hint);
                        if (nValType != 14)
                        {
                            userItem.Desc[nValType] = 0;
                        }
                        break;
                }
                return;
            }
            if (nValType == 14)
            {
                nAddPoint = nPoint * 1000;
                if (userItem.DuraMax + nAddPoint > ushort.MaxValue)
                {
                    nAddPoint = ushort.MaxValue - userItem.DuraMax;
                }
                userItem.DuraMax = (ushort)(userItem.DuraMax + nAddPoint);
            }
            else
            {
                nAddPoint = nPoint;
                if (userItem.Desc[nValType] + nAddPoint > byte.MaxValue)
                {
                    nAddPoint = byte.MaxValue - userItem.Desc[nValType];
                }
                userItem.Desc[nValType] = (byte)(userItem.Desc[nValType] + nAddPoint);
            }
            playerActor.SendUpdateItem(userItem);
            playerActor.SysMsg("装备升级成功", MsgColor.Green, MsgType.Hint);
            playerActor.SysMsg(stdItem.Name + ": " + userItem.Dura + '/' + userItem.DuraMax + '-' + userItem.Desc[0] + '/' + userItem.Desc[1] + '/' + userItem.Desc[2] + '/' + userItem.Desc[3] + '/' + userItem.Desc[4] + '/' + userItem.Desc[5] + '/' + userItem.Desc[6] + '/' + userItem.Desc[7] + '/' + userItem.Desc[8] + '/' + userItem.Desc[9] + '/' + userItem.Desc[ItemAttr.WeaponUpgrade] + '/' + userItem.Desc[11] + '/' + userItem.Desc[12] + '/' + userItem.Desc[13], MsgColor.Blue, MsgType.Hint);
        }

        /// <summary>
        /// 声明变量
        /// VAR 数据类型(Integer String) 类型(HUMAN GUILD GLOBAL) 变量值
        /// </summary>
        /// <param name="IPlayerActor"></param>
        /// <param name="questActionInfo"></param>
        private void ActionOfVar(INormNpc normNpc, IPlayerActor playerActor, QuestActionInfo questActionInfo, ref bool Success)
        {
            var sName = string.Empty;
            const string sVarFound = "变量{0}已存在，变量类型:{1}";
            const string sVarTypeError = "变量类型错误，错误类型:{0} 当前支持类型(HUMAN、GUILD、GLOBAL)";
            var sType = questActionInfo.sParam2;
            var sVarName = questActionInfo.sParam3;
            var sVarValue = questActionInfo.sParam4;
            var nVarValue = HUtil32.StrToInt(questActionInfo.sParam4, 0);
            var varType = VarType.None;
            if (string.Compare(questActionInfo.sParam1, "Integer", StringComparison.OrdinalIgnoreCase) == 0)
            {
                varType = VarType.Integer;
            }
            if (string.Compare(questActionInfo.sParam1, "String", StringComparison.OrdinalIgnoreCase) == 0)
            {
                varType = VarType.String;
            }
            if (string.IsNullOrEmpty(sType) || string.IsNullOrEmpty(sVarName) || varType == VarType.None)
            {
                ScriptActionError(playerActor,"", questActionInfo, ExecutionCode.Var);
                return;
            }
            if (string.Compare(questActionInfo.sParam1, "Integer", StringComparison.OrdinalIgnoreCase) == 0)
            {
                varType = VarType.Integer;
            }
            if (string.Compare(questActionInfo.sParam1, "String", StringComparison.OrdinalIgnoreCase) == 0)
            {
                varType = VarType.String;
            }
            if (string.IsNullOrEmpty(sType) || string.IsNullOrEmpty(sVarName) || varType == VarType.None)
            {
                ScriptActionError(playerActor,"", questActionInfo, ExecutionCode.Var);
                return;
            }
            var dynamicVar = new DynamicVar();
            dynamicVar.sName = sVarName;
            dynamicVar.VarType = varType;
            dynamicVar.nInternet = nVarValue;
            dynamicVar.sString = sVarValue;
            var boFoundVar = false;
            var dynamicVarList = GetDynamicVarMap(playerActor,sType, ref sName);
            if (dynamicVarList == null)
            {
                Dispose(dynamicVar);
                ScriptActionError(playerActor,string.Format(sVarTypeError, sType), questActionInfo, ExecutionCode.Var);
                return;
            }
            if (dynamicVarList.ContainsKey(sVarName))
            {
                boFoundVar = true;
            }
            if (!boFoundVar)
            {
                dynamicVarList.Add(sVarName, dynamicVar);
            }
            else
            {
                ScriptActionError(playerActor,string.Format(sVarFound, sVarName, sType), questActionInfo, ExecutionCode.Var);
            }
        }

        /// <summary>
        /// 读取变量值
        /// LOADVAR 变量类型 变量名 文件名
        /// </summary>
        /// <param name="IPlayerActor"></param>
        /// <param name="questActionInfo"></param>
        private void ActionOfLoadVar(INormNpc normNpc, IPlayerActor playerActor, QuestActionInfo questActionInfo, ref bool Success)
        {
            var sName = string.Empty;
            const string sVarFound = "变量{0}不存在，变量类型:{1}";
            const string sVarTypeError = "变量类型错误，错误类型:{0} 当前支持类型(HUMAN、GUILD、GLOBAL)";
            var sType = questActionInfo.sParam1;
            var sVarName = questActionInfo.sParam2;
            var sFileName = GetLineVariableText(playerActor,questActionInfo.sParam3);
            if (sFileName[0] == '\\')
            {
                sFileName = sFileName[1..];
            }
            if (sFileName[1] == '\\')
            {
                sFileName = sFileName[2..];
            }
            if (sFileName[2] == '\\')
            {
                sFileName = sFileName[3..];
            }
            sFileName = ModuleShare.GetEnvirFilePath(sFileName);
            if (string.IsNullOrEmpty(sType) || string.IsNullOrEmpty(sVarName) || !File.Exists(sFileName))
            {
                ScriptActionError(playerActor,"", questActionInfo, ExecutionCode.LoadVar);
                return;
            }
            var boFoundVar = false;
            var dynamicVarList = GetDynamicVarMap(playerActor,sType, ref sName);
            if (dynamicVarList == null)
            {
                ScriptActionError(playerActor,string.Format(sVarTypeError, sType), questActionInfo, ExecutionCode.Var);
                return;
            }
            if (dynamicVarList.TryGetValue(sVarName, out _))
            {
                //IniFile = new ConfFile(sFileName);
                //IniFile.Load();
                /*switch (DynamicVar.VarType)
                {
                    case VarType.Integer:
                        DynamicVar.nInternet = IniFile.ReadWriteInteger(sName, DynamicVar.sName, 0);
                        break;
                    case VarType.String:
                        DynamicVar.sString = IniFile.ReadWriteString(sName, DynamicVar.sName, "");
                        break;
                }*/
                boFoundVar = true;
            }
            else
            {
                var iniFile = new ConfFile(sFileName);
                iniFile.Load();
                var str = iniFile.ReadString(sName, sVarName, "");
                if (!string.IsNullOrEmpty(str))
                {
                    if (!dynamicVarList.ContainsKey(sVarName))
                    {
                        dynamicVarList.Add(sVarName, new DynamicVar()
                        {
                            sName = sVarName,
                            sString = str,
                            VarType = VarType.String
                        });
                    }
                    boFoundVar = true;
                }
            }
            if (!boFoundVar)
            {
                ScriptActionError(playerActor,string.Format(sVarFound, sVarName, sType), questActionInfo, ExecutionCode.LoadVar);
            }
        }

        private void ActionOfClearNeedItems(INormNpc normNpc, IPlayerActor playerActor, QuestActionInfo questActionInfo, ref bool Success)
        {
            var nNeed = HUtil32.StrToInt(questActionInfo.sParam1, -1);
            if (nNeed < 0)
            {
                ScriptActionError(playerActor,"", questActionInfo, ExecutionCode.ClearNeedItems);
                return;
            }
            StdItem stdItem;
            UserItem userItem;
            for (var i = playerActor.ItemList.Count - 1; i >= 0; i--)
            {
                userItem = playerActor.ItemList[i];
                stdItem = ModuleShare.ItemSystem.GetStdItem(userItem.Index);
                if (stdItem != null && stdItem.Need == nNeed)
                {
                    playerActor.SendDelItems(userItem);
                    Dispose(userItem);
                    playerActor.ItemList.RemoveAt(i);
                }
            }
            for (var i = playerActor.StorageItemList.Count - 1; i >= 0; i--)
            {
                userItem = playerActor.StorageItemList[i];
                stdItem = ModuleShare.ItemSystem.GetStdItem(userItem.Index);
                if (stdItem != null && stdItem.Need == nNeed)
                {
                    Dispose(userItem);
                    playerActor.StorageItemList.RemoveAt(i);
                }
            }
        }

        private void ActionOfClearMakeItems(INormNpc normNpc, IPlayerActor playerActor, QuestActionInfo questActionInfo, ref bool Success)
        {
            UserItem userItem;
            var sItemName = questActionInfo.sParam1;
            var nMakeIndex = questActionInfo.nParam2;
            var boMatchName = questActionInfo.sParam3 == "1";
            if (string.IsNullOrEmpty(sItemName) || nMakeIndex <= 0)
            {
                ScriptActionError(playerActor,"", questActionInfo, ExecutionCode.ClearMakeItems);
                return;
            }
            StdItem stdItem;
            for (var i = playerActor.ItemList.Count - 1; i >= 0; i--)
            {
                userItem = playerActor.ItemList[i];
                if (userItem.MakeIndex != nMakeIndex)
                {
                    continue;
                }
                stdItem = ModuleShare.ItemSystem.GetStdItem(userItem.Index);
                if (!boMatchName || stdItem != null && string.Compare(stdItem.Name, sItemName, StringComparison.OrdinalIgnoreCase) == 0)
                {
                    playerActor.SendDelItems(userItem);
                    Dispose(userItem);
                    playerActor.ItemList.RemoveAt(i);
                }
            }
            for (var i = playerActor.StorageItemList.Count - 1; i >= 0; i--)
            {
                userItem = playerActor.ItemList[i];
                if (userItem.MakeIndex != nMakeIndex)
                {
                    continue;
                }
                stdItem = ModuleShare.ItemSystem.GetStdItem(userItem.Index);
                if (!boMatchName || stdItem != null && string.Compare(stdItem.Name, sItemName, StringComparison.OrdinalIgnoreCase) == 0)
                {
                    Dispose(userItem);
                    playerActor.StorageItemList.RemoveAt(i);
                }
            }
            for (var i = 0; i < playerActor.UseItems.Length; i++)
            {
                userItem = playerActor.UseItems[i];
                if (userItem.MakeIndex != nMakeIndex)
                {
                    continue;
                }
                stdItem = ModuleShare.ItemSystem.GetStdItem(userItem.Index);
                if (!boMatchName || stdItem != null && string.Compare(stdItem.Name, sItemName, StringComparison.OrdinalIgnoreCase) == 0)
                {
                    userItem.Index = 0;
                }
            }
        }

        private void ActionOfUnMaster(INormNpc normNpc, IPlayerActor playerActor, QuestActionInfo questActionInfo, ref bool Success)
        {
            if (string.IsNullOrEmpty(playerActor.MasterName))
            {
                normNpc.GotoLable(playerActor,"@ExeMasterFail", false);
                return;
            }
            var poseHuman = (IPlayerActor)playerActor.GetPoseCreate();
            if (poseHuman == null)
            {
                normNpc.GotoLable(playerActor,"@UnMasterCheckDir", false);
            }
            if (poseHuman != null)
            {
                if ((string.IsNullOrEmpty(questActionInfo.sParam1)))
                {
                    if (poseHuman.Race != ActorRace.Play)
                    {
                        normNpc.GotoLable(playerActor,"@UnMasterTypeErr", false);
                        return;
                    }
                    if (poseHuman.GetPoseCreate() == playerActor)
                    {
                        if (playerActor.MasterName == poseHuman.ChrName)
                        {
                            if (playerActor.IsMaster)
                            {
                                normNpc.GotoLable(playerActor,"@UnIsMaster", false);
                                return;
                            }
                            if (playerActor.MasterName != poseHuman.ChrName)
                            {
                                normNpc.GotoLable(playerActor,"@UnMasterError", false);
                                return;
                            }
                            normNpc.GotoLable(playerActor,"@StartUnMaster", false);
                            normNpc.GotoLable(poseHuman, "@WateUnMaster", false);
                            return;
                        }
                    }
                }
            }
            // sREQUESTUNMARRY
            if (string.Compare(questActionInfo.sParam1, "REQUESTUNMASTER", StringComparison.OrdinalIgnoreCase) == 0)
            {
                string sMsg;
                if (string.IsNullOrEmpty(questActionInfo.sParam2))
                {
                    if (poseHuman != null)
                    {
                        playerActor.IsStartUnMaster = true;
                        if (playerActor.IsStartUnMaster && poseHuman.IsStartUnMaster)
                        {
                            sMsg = string.Format(Settings.NPCSayUnMasterOKMsg, normNpc.ChrName, playerActor.ChrName, poseHuman.ChrName);
                            ModuleShare.WorldEngine.SendBroadCastMsg(sMsg, MsgType.Say);
                            playerActor.MasterName = "";
                            poseHuman.MasterName = "";
                            playerActor.IsStartUnMaster = false;
                            poseHuman.IsStartUnMaster = false;
                            playerActor.RefShowName();
                            poseHuman.RefShowName();
                            normNpc.GotoLable(playerActor,"@UnMasterEnd", false);
                            normNpc.GotoLable(poseHuman, "@UnMasterEnd", false);
                        }
                        else
                        {
                            normNpc.GotoLable(playerActor,"@WateUnMaster", false);
                            normNpc.GotoLable(poseHuman, "@RevUnMaster", false);
                        }
                    }
                    return;
                }
                // 强行出师
                if (string.Compare(questActionInfo.sParam2, "FORCE", StringComparison.OrdinalIgnoreCase) == 0)
                {
                    sMsg = string.Format(Settings.NPCSayForceUnMasterMsg, normNpc.ChrName, playerActor.ChrName, playerActor.MasterName);
                    ModuleShare.WorldEngine.SendBroadCastMsg(sMsg, MsgType.Say);
                    //poseHuman = M2Share.WorldEngine.GetIPlayerActor(playerActor.MasterName);
                    //if (poseHuman != null)
                    //{
                    //    poseHuman.MasterName = "";
                    //    poseHuman.RefShowName();
                    //}
                    //else
                    //{
                    //    M2Share.UnForceMasterList.Add(playerActor.MasterName);
                    //    M2Share.SaveUnForceMasterList();
                    //}
                    playerActor.MasterName = "";
                    normNpc.GotoLable(playerActor,"@UnMasterEnd", false);
                    playerActor.RefShowName();
                }
            }
        }

        private void ActionOfSetMapMode(INormNpc normNpc, IPlayerActor playerActor, QuestActionInfo questActionInfo, ref bool Success)
        {
            var sMapName = questActionInfo.sParam1;
            var sMapMode = questActionInfo.sParam2;
            var sParam1 = questActionInfo.sParam3;
            var sParam2 = questActionInfo.sParam4;
            var envir = ModuleShare.MapMgr.FindMap(sMapName);
            if (envir == null || string.IsNullOrEmpty(sMapMode))
            {
                ScriptActionError(playerActor,"", questActionInfo, ExecutionCode.SetMapMode);
                return;
            }
            if (string.Compare(sMapMode, "SAFE", StringComparison.OrdinalIgnoreCase) == 0)
            {
                if (!string.IsNullOrEmpty(sParam1))
                {
                    envir.Flag.SafeArea = true;
                }
                else
                {
                    envir.Flag.SafeArea = false;
                }
            }
            else if (string.Compare(sMapMode, "DARK", StringComparison.OrdinalIgnoreCase) == 0)
            {
                if (!string.IsNullOrEmpty(sParam1))
                {
                    envir.Flag.boDarkness = true;
                }
                else
                {
                    envir.Flag.boDarkness = false;
                }
            }
            else if (string.Compare(sMapMode, "FIGHT", StringComparison.OrdinalIgnoreCase) == 0)
            {
                if (!string.IsNullOrEmpty(sParam1))
                {
                    envir.Flag.FightZone = true;
                }
                else
                {
                    envir.Flag.FightZone = false;
                }
            }
            else if (string.Compare(sMapMode, "FIGHT3", StringComparison.OrdinalIgnoreCase) == 0)
            {
                if (!string.IsNullOrEmpty(sParam1))
                {
                    envir.Flag.Fight3Zone = true;
                }
                else
                {
                    envir.Flag.Fight3Zone = false;
                }
            }
            else if (string.Compare(sMapMode, "DAY", StringComparison.OrdinalIgnoreCase) == 0)
            {
                if (!string.IsNullOrEmpty(sParam1))
                {
                    envir.Flag.DayLight = true;
                }
                else
                {
                    envir.Flag.DayLight = false;
                }
            }
            else if (string.Compare(sMapMode, "QUIZ", StringComparison.OrdinalIgnoreCase) == 0)
            {
                if (!string.IsNullOrEmpty(sParam1))
                {
                    envir.Flag.boQUIZ = true;
                }
                else
                {
                    envir.Flag.boQUIZ = false;
                }
            }
            else if (string.Compare(sMapMode, "NORECONNECT", StringComparison.OrdinalIgnoreCase) == 0)
            {
                if (!string.IsNullOrEmpty(sParam1))
                {
                    envir.Flag.boNORECONNECT = true;
                    envir.Flag.sNoReConnectMap = sParam1;
                }
                else
                {
                    envir.Flag.boNORECONNECT = false;
                }
            }
            else if (string.Compare(sMapMode, "MUSIC", StringComparison.OrdinalIgnoreCase) == 0)
            {
                if (!string.IsNullOrEmpty(sParam1))
                {
                    envir.Flag.Music = true;
                    envir.Flag.MusicId = HUtil32.StrToInt(sParam1, -1);
                }
                else
                {
                    envir.Flag.Music = false;
                }
            }
            else if (string.Compare(sMapMode, "EXPRATE", StringComparison.OrdinalIgnoreCase) == 0)
            {
                if (!string.IsNullOrEmpty(sParam1))
                {
                    envir.Flag.boEXPRATE = true;
                    envir.Flag.ExpRate = HUtil32.StrToInt(sParam1, -1);
                }
                else
                {
                    envir.Flag.boEXPRATE = false;
                }
            }
            else if (string.Compare(sMapMode, "PKWINLEVEL", StringComparison.OrdinalIgnoreCase) == 0)
            {
                if (!string.IsNullOrEmpty(sParam1))
                {
                    envir.Flag.boPKWINLEVEL = true;
                    envir.Flag.nPKWINLEVEL = HUtil32.StrToInt(sParam1, -1);
                }
                else
                {
                    envir.Flag.boPKWINLEVEL = false;
                }
            }
            else if (string.Compare(sMapMode, "PKWINEXP", StringComparison.OrdinalIgnoreCase) == 0)
            {
                if (!string.IsNullOrEmpty(sParam1))
                {
                    envir.Flag.boPKWINEXP = true;
                    envir.Flag.nPKWINEXP = HUtil32.StrToInt(sParam1, -1);
                }
                else
                {
                    envir.Flag.boPKWINEXP = false;
                }
            }
            else if (string.Compare(sMapMode, "PKLOSTLEVEL", StringComparison.OrdinalIgnoreCase) == 0)
            {
                if (!string.IsNullOrEmpty(sParam1))
                {
                    envir.Flag.boPKLOSTLEVEL = true;
                    envir.Flag.nPKLOSTLEVEL = HUtil32.StrToInt(sParam1, -1);
                }
                else
                {
                    envir.Flag.boPKLOSTLEVEL = false;
                }
            }
            else if (string.Compare(sMapMode, "PKLOSTEXP", StringComparison.OrdinalIgnoreCase) == 0)
            {
                if (!string.IsNullOrEmpty(sParam1))
                {
                    envir.Flag.boPKLOSTEXP = true;
                    envir.Flag.nPKLOSTEXP = HUtil32.StrToInt(sParam1, -1);
                }
                else
                {
                    envir.Flag.boPKLOSTEXP = false;
                }
            }
            else if (string.Compare(sMapMode, "DECHP", StringComparison.OrdinalIgnoreCase) == 0)
            {
                if ((!string.IsNullOrEmpty(sParam1)) && (!string.IsNullOrEmpty(sParam2)))
                {
                    envir.Flag.boDECHP = true;
                    envir.Flag.nDECHPTIME = HUtil32.StrToInt(sParam1, -1);
                    envir.Flag.nDECHPPOINT = HUtil32.StrToInt(sParam2, -1);
                }
                else
                {
                    envir.Flag.boDECHP = false;
                }
            }
            else if (string.Compare(sMapMode, "DECGAMEGOLD", StringComparison.OrdinalIgnoreCase) == 0)
            {
                if ((!string.IsNullOrEmpty(sParam1)) && (!string.IsNullOrEmpty(sParam2)))
                {
                    envir.Flag.boDECGAMEGOLD = true;
                    envir.Flag.nDECGAMEGOLDTIME = HUtil32.StrToInt(sParam1, -1);
                    envir.Flag.nDECGAMEGOLD = HUtil32.StrToInt(sParam2, -1);
                }
                else
                {
                    envir.Flag.boDECGAMEGOLD = false;
                }
            }
            else if (string.Compare(sMapMode, "RUNHUMAN", StringComparison.OrdinalIgnoreCase) == 0)
            {
                if (!string.IsNullOrEmpty(sParam1))
                {
                    envir.Flag.RunHuman = true;
                }
                else
                {
                    envir.Flag.RunHuman = false;
                }
            }
            else if (string.Compare(sMapMode, "RUNMON", StringComparison.OrdinalIgnoreCase) == 0)
            {
                if (!string.IsNullOrEmpty(sParam1))
                {
                    envir.Flag.RunMon = true;
                }
                else
                {
                    envir.Flag.RunMon = false;
                }
            }
            else if (string.Compare(sMapMode, "NEEDHOLE", StringComparison.OrdinalIgnoreCase) == 0)
            {
                if (!string.IsNullOrEmpty(sParam1))
                {
                    envir.Flag.boNEEDHOLE = true;
                }
                else
                {
                    envir.Flag.boNEEDHOLE = false;
                }
            }
            else if (string.Compare(sMapMode, "NORECALL", StringComparison.OrdinalIgnoreCase) == 0)
            {
                if (!string.IsNullOrEmpty(sParam1))
                {
                    envir.Flag.NoReCall = true;
                }
                else
                {
                    envir.Flag.NoReCall = false;
                }
            }
            else if (string.Compare(sMapMode, "NOGUILDRECALL", StringComparison.OrdinalIgnoreCase) == 0)
            {
                if (!string.IsNullOrEmpty(sParam1))
                {
                    envir.Flag.NoGuildReCall = true;
                }
                else
                {
                    envir.Flag.NoGuildReCall = false;
                }
            }
            else if (string.Compare(sMapMode, "NODEARRECALL", StringComparison.OrdinalIgnoreCase) == 0)
            {
                if (!string.IsNullOrEmpty(sParam1))
                {
                    envir.Flag.boNODEARRECALL = true;
                }
                else
                {
                    envir.Flag.boNODEARRECALL = false;
                }
            }
            else if (string.Compare(sMapMode, "NOMASTERRECALL", StringComparison.OrdinalIgnoreCase) == 0)
            {
                if (!string.IsNullOrEmpty(sParam1))
                {
                    envir.Flag.MasterReCall = true;
                }
                else
                {
                    envir.Flag.MasterReCall = false;
                }
            }
            else if (string.Compare(sMapMode, "NORANDOMMOVE", StringComparison.OrdinalIgnoreCase) == 0)
            {
                if (!string.IsNullOrEmpty(sParam1))
                {
                    envir.Flag.boNORANDOMMOVE = true;
                }
                else
                {
                    envir.Flag.boNORANDOMMOVE = false;
                }
            }
            else if (string.Compare(sMapMode, "NODRUG", StringComparison.OrdinalIgnoreCase) == 0)
            {
                if (!string.IsNullOrEmpty(sParam1))
                {
                    envir.Flag.boNODRUG = true;
                }
                else
                {
                    envir.Flag.boNODRUG = false;
                }
            }
            else if (string.Compare(sMapMode, "MINE", StringComparison.OrdinalIgnoreCase) == 0)
            {
                if (!string.IsNullOrEmpty(sParam1))
                {
                    envir.Flag.Mine = true;
                }
                else
                {
                    envir.Flag.Mine = false;
                }
            }
            else if (string.Compare(sMapMode, "MINE2", StringComparison.OrdinalIgnoreCase) == 0)
            {
                if (!string.IsNullOrEmpty(sParam1))
                {
                    envir.Flag.boMINE2 = true;
                }
                else
                {
                    envir.Flag.boMINE2 = false;
                }
            }
            else if (string.Compare(sMapMode, "NOTHROWITEM", StringComparison.OrdinalIgnoreCase) == 0)
            {
                if (!string.IsNullOrEmpty(sParam1))
                {
                    envir.Flag.NoThrowItem = true;
                }
                else
                {
                    envir.Flag.NoThrowItem = false;
                }
            }
            else if (string.Compare(sMapMode, "NODROPITEM", StringComparison.OrdinalIgnoreCase) == 0)
            {
                if (!string.IsNullOrEmpty(sParam1))
                {
                    envir.Flag.NoDropItem = true;
                }
                else
                {
                    envir.Flag.NoDropItem = false;
                }
            }
            else if (string.Compare(sMapMode, "NOPOSITIONMOVE", StringComparison.OrdinalIgnoreCase) == 0)
            {
                if (!string.IsNullOrEmpty(sParam1))
                {
                    envir.Flag.boNOPOSITIONMOVE = true;
                }
                else
                {
                    envir.Flag.boNOPOSITIONMOVE = false;
                }
            }
            else if (string.Compare(sMapMode, "NOHORSE", StringComparison.OrdinalIgnoreCase) == 0)
            {
                if (!string.IsNullOrEmpty(sParam1))
                {
                    envir.Flag.NoHorse = true;
                }
                else
                {
                    envir.Flag.NoHorse = false;
                }
            }
            else if (string.Compare(sMapMode, "NOCHAT", StringComparison.OrdinalIgnoreCase) == 0)
            {
                if (!string.IsNullOrEmpty(sParam1))
                {
                    envir.Flag.boNOCHAT = true;
                }
                else
                {
                    envir.Flag.boNOCHAT = false;
                }
            }
        }

        private void ActionOfSetMemberLevel(INormNpc normNpc, IPlayerActor playerActor, QuestActionInfo questActionInfo, ref bool Success)
        {
            var nLevel = (byte)HUtil32.StrToInt(questActionInfo.sParam2, -1);
            if (nLevel < 0)
            {
                ScriptActionError(playerActor,"", questActionInfo, ExecutionCode.SetMemberLevel);
                return;
            }
            var cMethod = questActionInfo.sParam1[0];
            switch (cMethod)
            {
                case '=':
                    playerActor.MemberLevel = nLevel;
                    break;
                case '-':
                    playerActor.MemberLevel -= nLevel;
                    if (playerActor.MemberLevel <= 0)
                    {
                        playerActor.MemberLevel = 0;
                    }
                    break;
                case '+':
                    playerActor.MemberLevel += nLevel;
                    if (playerActor.MemberLevel >= byte.MaxValue)
                    {
                        playerActor.MemberLevel = 255;
                    }
                    break;
            }
            if (configuration.Config.ShowScriptActionMsg)
            {
                playerActor.SysMsg(string.Format(Settings.ChangeMemberLevelMsg, playerActor.MemberLevel), MsgColor.Green, MsgType.Hint);
            }
        }

        private void ActionOfSetMemberType(INormNpc normNpc, IPlayerActor playerActor, QuestActionInfo questActionInfo, ref bool Success)
        {
            var nType = HUtil32.StrToInt(questActionInfo.sParam2, -1);
            if (nType < 0)
            {
                ScriptActionError(playerActor,"", questActionInfo, ExecutionCode.SetMemberType);
                return;
            }
            var cMethod = questActionInfo.sParam1[0];
            switch (cMethod)
            {
                case '=':
                    playerActor.MemberType = nType;
                    break;
                case '-':
                    playerActor.MemberType -= nType;
                    if (playerActor.MemberType < 0)
                    {
                        playerActor.MemberType = 0;
                    }
                    break;
                case '+':
                    playerActor.MemberType += nType;
                    if (playerActor.MemberType > 65535)
                    {
                        playerActor.MemberType = 65535;
                    }
                    break;
            }
            if (configuration.Config.ShowScriptActionMsg)
            {
                playerActor.SysMsg(string.Format(Settings.ChangeMemberTypeMsg, playerActor.MemberType), MsgColor.Green, MsgType.Hint);
            }
        }

        private void ActionOfGiveItem(INormNpc normNpc, IPlayerActor playerActor, QuestActionInfo questActionInfo, ref bool Success)
        {
            var sItemName = questActionInfo.sParam1;
            var nItemCount = questActionInfo.nParam2;
            if (string.IsNullOrEmpty(sItemName) || nItemCount <= 0)
            {
                ScriptActionError(playerActor,"", questActionInfo, ExecutionCode.Give);
                return;
            }
            if (string.Compare(sItemName, Grobal2.StringGoldName, StringComparison.OrdinalIgnoreCase) == 0)
            {
                playerActor.IncGold(nItemCount);
                playerActor.GoldChanged();
                if (ModuleShare.GameLogGold)
                {
                   // M2Share.EventSource.AddEventLog(9, playerActor.MapName + "\t" + playerActor.CurrX + "\t" + playerActor.CurrY + "\t" + playerActor.ChrName + "\t" + Grobal2.StringGoldName + "\t" + nItemCount + "\t" + '1' + "\t" + normNpc.ChrName);
                }
                return;
            }
            if (ModuleShare.ItemSystem.GetStdItemIdx(sItemName) > 0)
            {
                if (!(nItemCount >= 1 && nItemCount <= 50))
                {
                    nItemCount = 1;
                }
                for (var i = 0; i < nItemCount; i++)
                {
                    StdItem stdItem;
                    // nItemCount 为0时出死循环
                    UserItem userItem;
                    if (playerActor.IsEnoughBag)
                    {
                        userItem = new UserItem();
                        if (ModuleShare.ItemSystem.CopyToUserItemFromName(sItemName, ref userItem))
                        {
                            playerActor.ItemList.Add(userItem);
                            playerActor.SendAddItem(userItem);
                            stdItem = ModuleShare.ItemSystem.GetStdItem(userItem.Index);
                            if (stdItem.NeedIdentify == 1)
                            {
                               // M2Share.EventSource.AddEventLog(9, playerActor.MapName + "\t" + playerActor.CurrX + "\t" + playerActor.CurrY + "\t" + playerActor.ChrName + "\t" + sItemName + "\t" + userItem.MakeIndex + "\t" + '1' + "\t" + normNpc.ChrName);
                            }
                        }
                        else
                        {
                            Dispose(userItem);
                        }
                    }
                    else
                    {
                        userItem = new UserItem();
                        if (ModuleShare.ItemSystem.CopyToUserItemFromName(sItemName, ref userItem))
                        {
                            stdItem = ModuleShare.ItemSystem.GetStdItem(userItem.Index);
                            if (stdItem.NeedIdentify == 1)
                            {
                               // M2Share.EventSource.AddEventLog(9, playerActor.MapName + "\t" + playerActor.CurrX + "\t" + playerActor.CurrY + "\t" + playerActor.ChrName + "\t" + sItemName + "\t" + userItem.MakeIndex + "\t" + '1' + "\t" + normNpc.ChrName);
                            }
                            playerActor.DropItemDown(userItem, 3, false, playerActor.ActorId, 0);
                        }
                        Dispose(userItem);
                    }
                }
            }
        }

        private void ActionOfGmExecute(INormNpc normNpc, IPlayerActor playerActor, QuestActionInfo questActionInfo, ref bool Success)
        {
            var sParam1 = questActionInfo.sParam1;
            var sParam2 = questActionInfo.sParam2;
            var sParam3 = questActionInfo.sParam3;
            var sParam4 = questActionInfo.sParam4;
            var sParam5 = questActionInfo.sParam5;
            var sParam6 = questActionInfo.sParam6;
            if (string.Compare(sParam2, "Self", StringComparison.OrdinalIgnoreCase) == 0)
            {
                sParam2 = playerActor.ChrName;
            }
            var sData = string.Format("@{0} {1} {2} {3} {4} {5}", sParam1, sParam2, sParam3, sParam4, sParam5, sParam6);
            var btOldPermission = playerActor.Permission;
            try
            {
                playerActor.Permission = 10;
                playerActor.ProcessUserLineMsg(sData);
            }
            finally
            {
                playerActor.Permission = btOldPermission;
            }
        }

        private void ActionOfGuildAuraePoint(INormNpc normNpc, IPlayerActor playerActor, QuestActionInfo questActionInfo, ref bool Success)
        {
            var nAuraePoint = HUtil32.StrToInt(questActionInfo.sParam2, -1);
            if (nAuraePoint < 0)
            {
                ScriptActionError(playerActor,"", questActionInfo, ExecutionCode.AuraePoint);
                return;
            }
            if (playerActor.MyGuild == null)
            {
                playerActor.SysMsg(Settings.ScriptGuildAuraePointNoGuild, MsgColor.Red, MsgType.Hint);
                return;
            }
            var guild = playerActor.MyGuild;
            var cMethod = questActionInfo.sParam1[0];
            switch (cMethod)
            {
                case '=':
                    guild.Aurae = nAuraePoint;
                    break;
                case '-':
                    if (guild.Aurae >= nAuraePoint)
                    {
                        guild.Aurae = guild.Aurae - nAuraePoint;
                    }
                    else
                    {
                        guild.Aurae = 0;
                    }
                    break;
                case '+':
                    if (int.MaxValue - guild.Aurae >= nAuraePoint)
                    {
                        guild.Aurae = guild.Aurae + nAuraePoint;
                    }
                    else
                    {
                        guild.Aurae = int.MaxValue;
                    }
                    break;
            }
            if (configuration.Config.ShowScriptActionMsg)
            {
                playerActor.SysMsg(string.Format(Settings.ScriptGuildAuraePointMsg, new[] { guild.Aurae }), MsgColor.Green, MsgType.Hint);
            }
        }

        private void ActionOfGuildBuildPoint(INormNpc normNpc, IPlayerActor playerActor, QuestActionInfo questActionInfo, ref bool Success)
        {
            var nBuildPoint = HUtil32.StrToInt(questActionInfo.sParam2, -1);
            if (nBuildPoint < 0)
            {
                ScriptActionError(playerActor,"", questActionInfo, ExecutionCode.BuildPoint);
                return;
            }
            if (playerActor.MyGuild == null)
            {
                playerActor.SysMsg(Settings.ScriptGuildBuildPointNoGuild, MsgColor.Red, MsgType.Hint);
                return;
            }
            var guild = playerActor.MyGuild;
            var cMethod = questActionInfo.sParam1[0];
            switch (cMethod)
            {
                case '=':
                    guild.BuildPoint = nBuildPoint;
                    break;
                case '-':
                    if (guild.BuildPoint >= nBuildPoint)
                    {
                        guild.BuildPoint = guild.BuildPoint - nBuildPoint;
                    }
                    else
                    {
                        guild.BuildPoint = 0;
                    }
                    break;
                case '+':
                    if (int.MaxValue - guild.BuildPoint >= nBuildPoint)
                    {
                        guild.BuildPoint = guild.BuildPoint + nBuildPoint;
                    }
                    else
                    {
                        guild.BuildPoint = int.MaxValue;
                    }
                    break;
            }
            if (configuration.Config.ShowScriptActionMsg)
            {
                playerActor.SysMsg(string.Format(Settings.ScriptGuildBuildPointMsg, guild.BuildPoint), MsgColor.Green, MsgType.Hint);
            }
        }

        private void ActionOfGuildChiefItemCount(INormNpc normNpc, IPlayerActor playerActor, QuestActionInfo questActionInfo, ref bool Success)
        {
            var nItemCount = HUtil32.StrToInt(questActionInfo.sParam2, -1);
            if (nItemCount < 0)
            {
                ScriptActionError(playerActor,"", questActionInfo, ExecutionCode.GuildChiefItemCount);
                return;
            }
            if (playerActor.MyGuild == null)
            {
                playerActor.SysMsg(Settings.ScriptGuildFlourishPointNoGuild, MsgColor.Red, MsgType.Hint);
                return;
            }
            var guild = playerActor.MyGuild;
            var cMethod = questActionInfo.sParam1[0];
            switch (cMethod)
            {
                case '=':
                    guild.ChiefItemCount = nItemCount;
                    break;
                case '-':
                    if (guild.ChiefItemCount >= nItemCount)
                    {
                        guild.ChiefItemCount = guild.ChiefItemCount - nItemCount;
                    }
                    else
                    {
                        guild.ChiefItemCount = 0;
                    }
                    break;
                case '+':
                    if (int.MaxValue - guild.ChiefItemCount >= nItemCount)
                    {
                        guild.ChiefItemCount = guild.ChiefItemCount + nItemCount;
                    }
                    else
                    {
                        guild.ChiefItemCount = int.MaxValue;
                    }
                    break;
            }
            if (configuration.Config.ShowScriptActionMsg)
            {
                playerActor.SysMsg(string.Format(Settings.ScriptChiefItemCountMsg, guild.ChiefItemCount), MsgColor.Green, MsgType.Hint);
            }
        }

        private void ActionOfGuildFlourishPoint(INormNpc normNpc, IPlayerActor playerActor, QuestActionInfo questActionInfo, ref bool Success)
        {
            var nFlourishPoint = HUtil32.StrToInt(questActionInfo.sParam2, -1);
            if (nFlourishPoint < 0)
            {
                ScriptActionError(playerActor,"", questActionInfo, ExecutionCode.FlourishPoint);
                return;
            }
            if (playerActor.MyGuild == null)
            {
                playerActor.SysMsg(Settings.ScriptGuildFlourishPointNoGuild, MsgColor.Red, MsgType.Hint);
                return;
            }
            var guild = playerActor.MyGuild;
            var cMethod = questActionInfo.sParam1[0];
            switch (cMethod)
            {
                case '=':
                    guild.Flourishing = nFlourishPoint;
                    break;
                case '-':
                    if (guild.Flourishing >= nFlourishPoint)
                    {
                        guild.Flourishing = guild.Flourishing - nFlourishPoint;
                    }
                    else
                    {
                        guild.Flourishing = 0;
                    }
                    break;
                case '+':
                    if (int.MaxValue - guild.Flourishing >= nFlourishPoint)
                    {
                        guild.Flourishing = guild.Flourishing + nFlourishPoint;
                    }
                    else
                    {
                        guild.Flourishing = int.MaxValue;
                    }
                    break;
            }
            if (configuration.Config.ShowScriptActionMsg)
            {
                playerActor.SysMsg(string.Format(Settings.ScriptGuildFlourishPointMsg, guild.Flourishing), MsgColor.Green, MsgType.Hint);
            }
        }

        private void ActionOfGuildstabilityPoint(INormNpc normNpc, IPlayerActor playerActor, QuestActionInfo questActionInfo, ref bool Success)
        {
            var nStabilityPoint = HUtil32.StrToInt(questActionInfo.sParam2, -1);
            if (nStabilityPoint < 0)
            {
                ScriptActionError(playerActor,"", questActionInfo, ExecutionCode.StabilityPoint);
                return;
            }
            if (playerActor.MyGuild == null)
            {
                playerActor.SysMsg(Settings.ScriptGuildStabilityPointNoGuild, MsgColor.Red, MsgType.Hint);
                return;
            }
            var guild = playerActor.MyGuild;
            var cMethod = questActionInfo.sParam1[0];
            switch (cMethod)
            {
                case '=':
                    guild.Stability = nStabilityPoint;
                    break;
                case '-':
                    if (guild.Stability >= nStabilityPoint)
                    {
                        guild.Stability = guild.Stability - nStabilityPoint;
                    }
                    else
                    {
                        guild.Stability = 0;
                    }
                    break;
                case '+':
                    if (int.MaxValue - guild.Stability >= nStabilityPoint)
                    {
                        guild.Stability = guild.Stability + nStabilityPoint;
                    }
                    else
                    {
                        guild.Stability = int.MaxValue;
                    }
                    break;
            }
            if (configuration.Config.ShowScriptActionMsg)
            {
                playerActor.SysMsg(string.Format(Settings.ScriptGuildStabilityPointMsg, guild.Stability), MsgColor.Green, MsgType.Hint);
            }
        }

        private void ActionOfHumanHp(INormNpc normNpc, IPlayerActor playerActor, QuestActionInfo questActionInfo, ref bool Success)
        {
            var nHp = HUtil32.StrToInt(questActionInfo.sParam2, -1);
            if (nHp < 0)
            {
                ScriptActionError(playerActor,"", questActionInfo, ExecutionCode.HumanHp);
                return;
            }
            var cMethod = questActionInfo.sParam1[0];
            switch (cMethod)
            {
                case '=':
                    playerActor.WAbil.HP = (ushort)nHp;
                    break;
                case '-':
                    if (playerActor.WAbil.HP >= nHp)
                    {
                        playerActor.WAbil.HP -= (ushort)nHp;
                    }
                    else
                    {
                        playerActor.WAbil.HP = 0;
                    }
                    break;
                case '+':
                    playerActor.WAbil.HP += (ushort)nHp;
                    if (playerActor.WAbil.HP > playerActor.WAbil.MaxHP)
                    {
                        playerActor.WAbil.HP = playerActor.WAbil.MaxHP;
                    }
                    break;
            }
            if (configuration.Config.ShowScriptActionMsg)
            {
                playerActor.SysMsg(string.Format(Settings.ScriptChangeHumanHPMsg, playerActor.WAbil.MaxHP), MsgColor.Green, MsgType.Hint);
            }
        }

        private void ActionOfHumanMp(INormNpc normNpc, IPlayerActor playerActor, QuestActionInfo questActionInfo, ref bool Success)
        {
            var nMp = HUtil32.StrToInt(questActionInfo.sParam2, -1);
            if (nMp < 0)
            {
                ScriptActionError(playerActor,"", questActionInfo, ExecutionCode.HumanMp);
                return;
            }
            var cMethod = questActionInfo.sParam1[0];
            switch (cMethod)
            {
                case '=':
                    playerActor.WAbil.MP = (ushort)nMp;
                    break;
                case '-':
                    if (playerActor.WAbil.MP >= nMp)
                    {
                        playerActor.WAbil.MP -= (ushort)nMp;
                    }
                    else
                    {
                        playerActor.WAbil.MP = 0;
                    }
                    break;
                case '+':
                    playerActor.WAbil.MP += (ushort)nMp;
                    if (playerActor.WAbil.MP > playerActor.WAbil.MaxMP)
                    {
                        playerActor.WAbil.MP = playerActor.WAbil.MaxMP;
                    }
                    break;
            }
            if (configuration.Config.ShowScriptActionMsg)
            {
                playerActor.SysMsg(string.Format(Settings.ScriptChangeHumanMPMsg, new[] { playerActor.WAbil.MaxMP }), MsgColor.Green, MsgType.Hint);
            }
        }

        private void ActionOfKick(INormNpc normNpc, IPlayerActor playerActor, QuestActionInfo questActionInfo, ref bool Success)
        {
            playerActor.BoKickFlag = true;
            playerActor.BoReconnection = true;
            playerActor.BoSoftClose = true;
        }

        private void ActionOfKill(INormNpc normNpc, IPlayerActor playerActor, QuestActionInfo questActionInfo, ref bool Success)
        {
            var nMode = HUtil32.StrToInt(questActionInfo.sParam1, -1);
            if (nMode >= 0 && nMode <= 3)
            {
                switch (nMode)
                {
                    case 1:
                        playerActor.NoItem = true;
                        playerActor.Die();
                        break;
                    case 2:
                        playerActor.SetLastHiter(normNpc);
                        playerActor.Die();
                        break;
                    case 3:
                        playerActor.NoItem = true;
                        playerActor.SetLastHiter(normNpc);
                        playerActor.Die();
                        break;
                    default:
                        playerActor.Die();
                        break;
                }
            }
            else
            {
                ScriptActionError(playerActor,"", questActionInfo, ExecutionCode.Kill);
            }
        }

        private void ActionOfBonusPoint(INormNpc normNpc, IPlayerActor playerActor, QuestActionInfo questActionInfo, ref bool Success)
        {
            var nBonusPoint = HUtil32.StrToInt(questActionInfo.sParam2, -1);
            if (nBonusPoint < 0 || nBonusPoint > 10000)
            {
                ScriptActionError(playerActor,"", questActionInfo, ExecutionCode.BonusPoint);
                return;
            }
            var cMethod = questActionInfo.sParam1[0];
            switch (cMethod)
            {
                case '=':
                    playerActor.HasLevelUp(0);
                    playerActor.BonusPoint = nBonusPoint;
                    playerActor.SendMsg(Messages.RM_ADJUST_BONUS, 0, 0, 0, 0);
                    break;
                case '-':
                    break;
                case '+':
                    playerActor.BonusPoint += nBonusPoint;
                    playerActor.SendMsg(Messages.RM_ADJUST_BONUS, 0, 0, 0, 0);
                    break;
            }
        }

        private void ActionOfDelMarry(INormNpc normNpc, IPlayerActor playerActor, QuestActionInfo questActionInfo, ref bool Success)
        {
            playerActor.DearName = "";
            playerActor.RefShowName();
        }

        private void ActionOfDelMaster(INormNpc normNpc, IPlayerActor playerActor, QuestActionInfo questActionInfo, ref bool Success)
        {
            playerActor.MasterName = "";
            playerActor.RefShowName();
        }

        private void ActionOfRestBonusPoint(INormNpc normNpc, IPlayerActor playerActor, QuestActionInfo questActionInfo, ref bool Success)
        {
            var nTotleUsePoint = playerActor.BonusAbil.DC + playerActor.BonusAbil.MC + playerActor.BonusAbil.SC + playerActor.BonusAbil.AC + playerActor.BonusAbil.MAC + playerActor.BonusAbil.HP + playerActor.BonusAbil.MP + playerActor.BonusAbil.Hit + playerActor.BonusAbil.Speed + playerActor.BonusAbil.Reserved;
            playerActor.BonusPoint += nTotleUsePoint;
            playerActor.SendMsg(Messages.RM_ADJUST_BONUS, 0, 0, 0, 0);
            playerActor.HasLevelUp(0);
            playerActor.SysMsg("分配点数已复位!!!", MsgColor.Red, MsgType.Hint);
        }

        private void ActionOfRestReNewLevel(INormNpc normNpc, IPlayerActor playerActor, QuestActionInfo questActionInfo, ref bool Success)
        {
            playerActor.ReLevel = 0;
            playerActor.HasLevelUp(0);
        }

        private void ActionOfChangeNameColor(INormNpc normNpc, IPlayerActor playerActor, QuestActionInfo questActionInfo, ref bool Success)
        {
            var nColor = questActionInfo.nParam1;
            if (nColor < 0 || nColor > 255)
            {
                ScriptActionError(playerActor,"", questActionInfo, ExecutionCode.ChangeNameColor);
                return;
            }
            playerActor.NameColor = (byte)nColor;
            playerActor.RefNameColor();
        }

        private void ActionOfClearPassword(INormNpc normNpc, IPlayerActor playerActor, QuestActionInfo questActionInfo, ref bool Success)
        {
            playerActor.StoragePwd = "";
            playerActor.IsPasswordLocked = false;
        }

        // RECALLMOB 怪物名称 等级 叛变时间 变色(0,1) 固定颜色(1 - 7)
        // 变色为0 时固定颜色才起作用
        private void ActionOfRecallmob(INormNpc normNpc, IPlayerActor playerActor, QuestActionInfo questActionInfo, ref bool Success)
        {
            IActor mon;
            if (questActionInfo.nParam3 <= 1)
            {
                mon = playerActor.MakeSlave(questActionInfo.sParam1, 3, HUtil32.StrToInt(questActionInfo.sParam2, 0), 100, 10 * 24 * 60 * 60);
            }
            else
            {
                mon = playerActor.MakeSlave(questActionInfo.sParam1, 3, HUtil32.StrToInt(questActionInfo.sParam2, 0), 100, questActionInfo.nParam3 * 60);
            }
            if (mon != null)
            {
                if (!string.IsNullOrEmpty(questActionInfo.sParam4) && questActionInfo.sParam4[1] == '1')
                {
                    mon.AutoChangeColor = true;
                }
                else if (questActionInfo.nParam5 > 0)
                {
                    mon.FixColor = true;
                    mon.FixColorIdx = (byte)(questActionInfo.nParam5 - 1);
                }
            }
        }

        private void ActionOfReNewLevel(INormNpc normNpc, IPlayerActor playerActor, QuestActionInfo questActionInfo, ref bool Success)
        {
            var nReLevel = (byte)HUtil32.StrToInt(questActionInfo.sParam1, -1);
            var nLevel = (byte)HUtil32.StrToInt(questActionInfo.sParam2, -1);
            var nBounsuPoint = HUtil32.StrToInt(questActionInfo.sParam3, -1);
            if (nReLevel < 0 || nLevel < 0 || nBounsuPoint < 0)
            {
                ScriptActionError(playerActor,"", questActionInfo, ExecutionCode.Renewlevel);
                return;
            }
            if (playerActor.ReLevel + nReLevel <= 255)
            {
                playerActor.ReLevel += nReLevel;
                if (nLevel > 0)
                {
                    playerActor.Abil.Level = nLevel;
                }
                if (configuration.Config.ReNewLevelClearExp)
                {
                    playerActor.Abil.Exp = 0;
                }
                playerActor.BonusPoint += nBounsuPoint;
                playerActor.SendMsg(Messages.RM_ADJUST_BONUS, 0, 0, 0, 0);
                playerActor.HasLevelUp(0);
                playerActor.RefShowName();
            }
        }

        private void ActionOfChangeGender(INormNpc normNpc, IPlayerActor playerActor, QuestActionInfo questActionInfo, ref bool Success)
        {
            var nGender = HUtil32.StrToInt(questActionInfo.sParam1, -1);
            if (nGender > 1)
            {
                ScriptActionError(playerActor,"", questActionInfo, ExecutionCode.ChangeGender);
                return;
            }
            playerActor.Gender = Enum.Parse<PlayGender>(nGender.ToString());
            playerActor.FeatureChanged();
        }

        private void ActionOfKillSlave(INormNpc normNpc, IPlayerActor playerActor, QuestActionInfo questActionInfo, ref bool Success)
        {
            for (var i = 0; i < playerActor.SlaveList.Count; i++)
            {
                var slave = playerActor.SlaveList[i];
                slave.WAbil.HP = 0;
            }
        }

        private void ActionOfKillMonExpRate(INormNpc normNpc, IPlayerActor playerActor, QuestActionInfo questActionInfo, ref bool Success)
        {
            var nRate = HUtil32.StrToInt(questActionInfo.sParam1, -1);
            var nTime = HUtil32.StrToInt(questActionInfo.sParam2, -1);
            if (nRate < 0 || nTime < 0)
            {
                ScriptActionError(playerActor,"", questActionInfo, ExecutionCode.KillMonExpRate);
                return;
            }
            playerActor.KillMonExpRate = nRate;
            playerActor.KillMonExpRateTime = nTime;
            if (configuration.Config.ShowScriptActionMsg)
            {
                playerActor.SysMsg(string.Format(Settings.ChangeKillMonExpRateMsg, playerActor.KillMonExpRate / 100, playerActor.KillMonExpRateTime), MsgColor.Green, MsgType.Hint);
            }
        }

        private void ActionOfMonGenEx(INormNpc normNpc, IPlayerActor playerActor, QuestActionInfo questActionInfo, ref bool Success)
        {
            var sMapName = questActionInfo.sParam1;
            var nMapX = HUtil32.StrToInt(questActionInfo.sParam2, -1);
            var nMapY = HUtil32.StrToInt(questActionInfo.sParam3, -1);
            var sMonName = questActionInfo.sParam4;
            var nRange = questActionInfo.nParam5;
            var nCount = questActionInfo.nParam6;
            if (string.IsNullOrEmpty(sMapName) || nMapX <= 0 || nMapY <= 0 || string.IsNullOrEmpty(sMapName) || nRange <= 0 || nCount <= 0)
            {
                ScriptActionError(playerActor,"", questActionInfo, ExecutionCode.MonGenex);
                return;
            }
            for (var i = 0; i < nCount; i++)
            {
                var nRandX = (short)(ModuleShare.RandomNumber.Random(nRange * 2 + 1) + (nMapX - nRange));
                var nRandY = (short)(ModuleShare.RandomNumber.Random(nRange * 2 + 1) + (nMapY - nRange));
                if (ModuleShare.WorldEngine.RegenMonsterByName(sMapName, nRandX, nRandY, sMonName) == null)
                {
                    break;
                }
            }
        }

        private void ActionOfOpenMagicBox(INormNpc normNpc, IPlayerActor playerActor, QuestActionInfo questActionInfo, ref bool Success)
        {
            short nX = 0;
            short nY = 0;
            var sMonName = questActionInfo.sParam1;
            if (string.IsNullOrEmpty(sMonName))
            {
                ScriptActionError(playerActor,"", questActionInfo, ExecutionCode.OpenMagicbox);
                return;
            }
            playerActor.GetFrontPosition(ref nX, ref nY);
            var monster = ModuleShare.WorldEngine.RegenMonsterByName(playerActor.Envir.MapName, nX, nY, sMonName);
            if (monster == null)
            {
                return;
            }
            monster.Die();
        }

        private void ActionOfPkZone(INormNpc normNpc, IPlayerActor playerActor, QuestActionInfo questActionInfo, ref bool Success)
        {
            //FireBurnEvent fireBurnEvent;
            //var nRange = HUtil32.StrToInt(questActionInfo.sParam1, -1);
            //var nType = HUtil32.StrToInt(questActionInfo.sParam2, -1);
            //var nTime = HUtil32.StrToInt(questActionInfo.sParam3, -1);
            //var nPoint = HUtil32.StrToInt(questActionInfo.sParam4, -1);
            //if (nRange < 0 || nType < 0 || nTime < 0 || nPoint < 0)
            //{
            //    ScriptActionError(playerActor,"", questActionInfo, ExecutionCode.PvpZone);
            //    return;
            //}
            //var nMinX = normNpc.CurrX - nRange;
            //var nMaxX = normNpc.CurrX + nRange;
            //var nMinY = normNpc.CurrY - nRange;
            //var nMaxY = normNpc.CurrY + nRange;
            //for (var nX = nMinX; nX <= nMaxX; nX++)
            //{
            //    for (var nY = nMinY; nY <= nMaxY; nY++)
            //    {
            //        if (nX < nMaxX && nY == nMinY || nY < nMaxY && nX == nMinX || nX == nMaxX ||
            //            nY == nMaxY)
            //        {
            //            fireBurnEvent = new FireBurnEvent(playerActor,(short)nX, (short)nY, (byte)nType, nTime * 1000, nPoint);
            //            M2Share.EventMgr.AddEvent(fireBurnEvent);
            //        }
            //    }
            //}
        }

        private void ActionOfPowerRate(INormNpc normNpc, IPlayerActor playerActor, QuestActionInfo questActionInfo, ref bool Success)
        {
            var nRate = HUtil32.StrToInt(questActionInfo.sParam1, -1);
            var nTime = HUtil32.StrToInt(questActionInfo.sParam2, -1);
            if (nRate < 0 || nTime < 0)
            {
                ScriptActionError(playerActor,"", questActionInfo, ExecutionCode.PowerRate);
                return;
            }
            playerActor.PowerRate = nRate;
            playerActor.PowerRateTime = nTime;
            if (configuration.Config.ShowScriptActionMsg)
            {
                playerActor.SysMsg(string.Format(Settings.ChangePowerRateMsg, playerActor.PowerRate / 100, playerActor.PowerRateTime), MsgColor.Green, MsgType.Hint);
            }
        }

        private void ActionOfChangeMode(INormNpc normNpc, IPlayerActor playerActor, QuestActionInfo questActionInfo, ref bool Success)
        {
            //switch (questActionInfo.nParam1)
            //{
            //    case 1:
            //        CommandMgr.Execute(playerActor,"ChangeAdminMode");
            //        break;
            //    case 2:
            //        CommandMgr.Execute(playerActor,"ChangeSuperManMode");
            //        break;
            //    case 3:
            //        CommandMgr.Execute(playerActor,"ChangeObMode");
            //        break;
            //    default:
            //        ScriptActionError(playerActor,"", questActionInfo, ExecutionCodeDef.CHANGEMODE);
            //        break;
            //}
            var nMode = questActionInfo.nParam1;
            var boOpen = HUtil32.StrToInt(questActionInfo.sParam2, -1) == 1;
            if (nMode >= 1 && nMode <= 3)
            {
                switch (nMode)
                {
                    case 1:
                        playerActor.AdminMode = boOpen;
                        if (playerActor.AdminMode)
                        {
                            playerActor.SysMsg(Settings.GameMasterMode, MsgColor.Green, MsgType.Hint);
                        }
                        else
                        {
                            playerActor.SysMsg(Settings.ReleaseGameMasterMode, MsgColor.Green, MsgType.Hint);
                        }
                        break;
                    case 2:
                        playerActor.SuperMan = boOpen;
                        if (playerActor.SuperMan)
                        {
                            playerActor.SysMsg(Settings.SupermanMode, MsgColor.Green, MsgType.Hint);
                        }
                        else
                        {
                            playerActor.SysMsg(Settings.ReleaseSupermanMode, MsgColor.Green, MsgType.Hint);
                        }
                        break;
                    case 3:
                        playerActor.ObMode = boOpen;
                        if (playerActor.ObMode)
                        {
                            playerActor.SysMsg(Settings.ObserverMode, MsgColor.Green, MsgType.Hint);
                        }
                        else
                        {
                            playerActor.SysMsg(Settings.ReleaseObserverMode, MsgColor.Green, MsgType.Hint);
                        }
                        break;
                }
            }
            else
            {
                ScriptActionError(playerActor,"", questActionInfo, ExecutionCode.ChangeMode);
            }
        }

        private void ActionOfChangePerMission(INormNpc normNpc, IPlayerActor playerActor, QuestActionInfo questActionInfo, ref bool Success)
        {
            var nPermission = (byte)HUtil32.StrToInt(questActionInfo.sParam1, -1);
            if (nPermission <= 10)
            {
                playerActor.Permission = nPermission;
            }
            else
            {
                ScriptActionError(playerActor,"", questActionInfo, ExecutionCode.ChangePerMission);
                return;
            }
            if (configuration.Config.ShowScriptActionMsg)
            {
                playerActor.SysMsg(string.Format(Settings.ChangePermissionMsg, playerActor.Permission), MsgColor.Green, MsgType.Hint);
            }
        }

        private void ActionOfThrowitem(INormNpc normNpc, IPlayerActor playerActor, QuestActionInfo questActionInfo, ref bool Success)
        {
            var sMap = string.Empty;
            var sItemName = string.Empty;
            var nX = 0;
            var nY = 0;
            var nRange = 0;
            var nCount = 0;
            var dX = 0;
            var dY = 0;
            UserItem userItem = null;
            try
            {
                if (!GetValValue(playerActor,questActionInfo.sParam1, ref sMap))
                {
                    sMap = GetLineVariableText(playerActor,questActionInfo.sParam1);
                }
                if (!GetValValue(playerActor,questActionInfo.sParam2, ref nX))
                {
                    nX = HUtil32.StrToInt(GetLineVariableText(playerActor,questActionInfo.sParam2), -1);
                }
                if (!GetValValue(playerActor,questActionInfo.sParam3, ref nY))
                {
                    nY = HUtil32.StrToInt(GetLineVariableText(playerActor,questActionInfo.sParam3), -1);
                }
                if (!GetValValue(playerActor,questActionInfo.sParam4, ref nRange))
                {
                    nRange = HUtil32.StrToInt(GetLineVariableText(playerActor,questActionInfo.sParam4), -1);
                }
                if (!GetValValue(playerActor,questActionInfo.sParam5, ref sItemName))
                {
                    sItemName = GetLineVariableText(playerActor,questActionInfo.sParam5);
                }
                if (!GetValValue(playerActor,questActionInfo.sParam6, ref nCount))
                {
                    nCount = HUtil32.StrToInt(GetLineVariableText(playerActor,questActionInfo.sParam6), -1);
                }
                if (string.IsNullOrEmpty(sMap) || nX < 0 || nY < 0 || nRange < 0 || string.IsNullOrEmpty(sItemName) || nCount <= 0)
                {
                    ScriptActionError(playerActor,"", questActionInfo, ExecutionCode.ThrowItem);
                    return;
                }
                var envir = ModuleShare.MapMgr.FindMap(sMap);
                if (envir == null)
                {
                    return;
                }
                if (nCount <= 0)
                {
                    nCount = 1;
                }
                MapItem mapItem;
                if (string.Compare(sItemName, Grobal2.StringGoldName, StringComparison.OrdinalIgnoreCase) == 0)// 金币
                {
                    if (GetActionOfThrowitemDropPosition(envir, nX, nY, nRange, ref dX, ref dY))
                    {
                        mapItem = new MapItem();
                        mapItem.Name = Grobal2.StringGoldName;
                        mapItem.Count = nCount;
                        mapItem.Looks = ModuleShare.GetGoldShape(nCount);
                        mapItem.OfBaseObject = playerActor.ActorId;
                        mapItem.CanPickUpTick = HUtil32.GetTickCount();
                        mapItem.DropBaseObject = playerActor.ActorId;
                        if (envir.AddItemToMap(dX, dY, mapItem))
                        {
                            normNpc.SendRefMsg(Messages.RM_ITEMSHOW, mapItem.Looks, mapItem.ItemId, dX, dY, mapItem.Name + "@0");
                        }
                        else
                        {
                            Dispose(mapItem);
                        }
                        return;
                    }
                }
                for (var i = 0; i < nCount; i++)
                {
                    if (GetActionOfThrowitemDropPosition(envir, nX, nY, nRange, ref dX, ref dY)) // 修正出现在一个坐标上
                    {
                        if (ModuleShare.ItemSystem.CopyToUserItemFromName(sItemName, ref userItem))
                        {
                            var stdItem = ModuleShare.ItemSystem.GetStdItem(userItem.Index);
                            if (stdItem != null)
                            {
                                if (stdItem.StdMode == 40)
                                {
                                    var idura = userItem.Dura - 2000;
                                    if (idura < 0)
                                    {
                                        idura = 0;
                                    }
                                    userItem.Dura = (ushort)idura;
                                }
                                mapItem = new MapItem();
                                mapItem.UserItem = new UserItem(userItem);
                                mapItem.Name = stdItem.Name;
                                //var nameCorlr = "@" + CustomItem.GetItemAddValuePointColor(userItem); // 取自定义物品名称
                                //if (userItem.Desc[13] == 1)
                                //{
                                //    var sUserItemName = M2Share.CustomItemMgr.GetCustomItemName(userItem.MakeIndex, userItem.Index);
                                //    if (!string.IsNullOrEmpty(sUserItemName))
                                //    {
                                //        mapItem.Name = sUserItemName;
                                //    }
                                //}
                                mapItem.Looks = stdItem.Looks;
                                if (stdItem.StdMode == 45)
                                {
                                    mapItem.Looks = (ushort)ModuleShare.GetRandomLook(mapItem.Looks, stdItem.Shape);
                                }
                                mapItem.AniCount = stdItem.AniCount;
                                mapItem.Reserved = 0;
                                mapItem.Count = nCount;
                                mapItem.OfBaseObject = playerActor.ActorId;
                                mapItem.CanPickUpTick = HUtil32.GetTickCount();
                                mapItem.DropBaseObject = playerActor.ActorId;
                                // GetDropPosition(nX, nY, nRange, dx, dy);//取掉物的位置
                                if (envir.AddItemToMap(dX, dY, mapItem))
                                {
                                   // normNpc.SendRefMsg(Messages.RM_ITEMSHOW, mapItem.Looks, mapItem.ItemId, dX, dY, mapItem.Name + nameCorlr);
                                }
                                else
                                {
                                    Dispose(mapItem);
                                    break;
                                }
                            }
                        }
                        else
                        {
                            Dispose(userItem);
                        }
                    }
                }
            }
            catch
            {
                ModuleShare.Logger.Error("{异常} TNormNpc.ActionOfTHROWITEM");
            }
        }

        private static bool GetActionOfThrowitemDropPosition(IEnvirnoment envir, int nOrgX, int nOrgY, int nRange, ref int nDx, ref int nDy)
        {
            var nItemCount = 0;
            var n24 = 999;
            var result = false;
            var n28 = 0;
            var n2C = 0;
            for (var i = 0; i < nRange; i++)
            {
                for (var j = -i; j <= i; j++)
                {
                    for (var k = -i; k <= i; k++)
                    {
                        nDx = nOrgX + k;
                        nDy = nOrgY + j;
                        if (envir.GetItemEx(nDx, nDy, ref nItemCount) == 0)
                        {
                            if (envir.ChFlag)
                            {
                                result = true;
                                break;
                            }
                        }
                        else
                        {
                            if (envir.ChFlag && n24 > nItemCount)
                            {
                                n24 = nItemCount;
                                n28 = nDx;
                                n2C = nDy;
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
                    nDx = n28;
                    nDy = n2C;
                }
                else
                {
                    nDx = nOrgX;
                    nDy = nOrgY;
                }
            }
            return result;
        }

        private void ActionOfRandomMove(INormNpc normNpc, IPlayerActor playerActor, QuestActionInfo questActionInfo, ref bool Success)
        {
            Success = true;
        }

        private static void ActionOfAddUseDateList(INormNpc normNpc, IPlayerActor playerActor, QuestActionInfo questConditionInfo, ref bool success)
        {
            string sHumName = playerActor.ChrName;
            string sListFileName = normNpc.m_sPath + questConditionInfo.sParam1;
            string s10 = string.Empty;
            string sText;
            bool bo15;
            sListFileName = ModuleShare.GetEnvirFilePath(sListFileName);
            using StringList loadList = new StringList();
            if (File.Exists(sListFileName))
            {
                loadList.LoadFromFile(sListFileName);
            }
            bo15 = false;
            for (int i = 0; i < loadList.Count; i++)
            {
                sText = loadList[i].Trim();
                sText = HUtil32.GetValidStrCap(sText, ref s10, new[] { ' ', '\t' });
                if (string.Compare(sHumName, s10, StringComparison.OrdinalIgnoreCase) == 0)
                {
                    bo15 = true;
                    break;
                }
            }
            if (!bo15)
            {
                s10 = $"{sHumName}    {DateTime.Today}";
                loadList.Add(s10);
                try
                {
                    loadList.SaveToFile(sListFileName);
                }
                catch
                {
                    ModuleShare.Logger.Error("saving fail.... => " + sListFileName);
                }
            }
        }

        private void ActionOfAddNameList(INormNpc normNpc, IPlayerActor playerActor, QuestActionInfo questConditionInfo, ref bool success)
        {
            string sListFileName = normNpc.m_sPath + questConditionInfo.sParam1;
            ActionOfAddList(playerActor.ChrName, sListFileName);
        }

        private void ActionOfDelUseDateList(INormNpc normNpc, IPlayerActor playerActor, QuestActionInfo questConditionInfo, ref bool success)
        {
            string sListFileName = normNpc.m_sPath + questConditionInfo.sParam1;
            ActionOfDelList(playerActor.ChrName, sListFileName);
        }

        private void ActionOfDelNameList(INormNpc normNpc, IPlayerActor playerActor, QuestActionInfo questConditionInfo, ref bool success)
        {
            string sListFileName = normNpc.m_sPath + questConditionInfo.sParam1;
            ActionOfDelList(playerActor.ChrName, sListFileName);
        }

        private void ActionOfDelAccountList(INormNpc normNpc, IPlayerActor playerActor, QuestActionInfo questConditionInfo, ref bool success)
        {
            string playName = playerActor.UserAccount;
            string sListFileName = normNpc.m_sPath + questConditionInfo.sParam1;
            ActionOfDelList(playerActor.UserAccount, sListFileName);
        }

        private void ActionOfAddAccountList(INormNpc normNpc, IPlayerActor playerActor, QuestActionInfo questActionInfo, ref bool Success)
        {
            ActionOfAddList(playerActor.UserAccount, normNpc.m_sPath + questActionInfo.sParam1);
        }

        private void ActionOfAddIpList(INormNpc normNpc, IPlayerActor playerActor, QuestActionInfo questActionInfo, ref bool Success)
        {
            ActionOfAddList(playerActor.LoginIpAddr, normNpc.m_sPath + questActionInfo.sParam1);
        }

        private void ActionOfDelIpList(INormNpc normNpc, IPlayerActor playerActor, QuestActionInfo questActionInfo, ref bool Success)
        {
            ActionOfAddList(playerActor.LoginIpAddr, normNpc.m_sPath + questActionInfo.sParam1);
        }

        private void ActionOfAddGuildList(INormNpc normNpc, IPlayerActor playerActor, QuestActionInfo questActionInfo, ref bool Success)
        {
            if (playerActor.MyGuild != null)
            {
                ActionOfAddList(playerActor.MyGuild.GuildName, normNpc.m_sPath + questActionInfo.sParam1);
            }
        }

        private void ActionOfDelGuildList(INormNpc normNpc, IPlayerActor playerActor, QuestActionInfo questActionInfo, ref bool Success)
        {
            if (playerActor.MyGuild != null)
            {
                ActionOfDelList(playerActor.MyGuild.GuildName, normNpc.m_sPath + questActionInfo.sParam1);
            }
        }

        private void ActionOfAddList(string val, string fileName)
        {
            var sListFileName = ModuleShare.GetEnvirFilePath(fileName);
            using StringList loadList = new StringList();
            if (File.Exists(sListFileName))
            {
                loadList.LoadFromFile(sListFileName);
            }
            bool bo15 = false;
            for (int i = 0; i < loadList.Count; i++)
            {
                string s10 = loadList[i].Trim();
                if (string.Compare(val, s10, StringComparison.OrdinalIgnoreCase) == 0)
                {
                    loadList.RemoveAt(i);
                    bo15 = true;
                    break;
                }
            }
            if (bo15)
            {
                loadList.SaveToFile(sListFileName);
            }
        }

        private void ActionOfDelList(string val, string fileName)
        {
            var sListFileName = ModuleShare.GetEnvirFilePath(fileName);
            using StringList loadList = new StringList();
            if (File.Exists(sListFileName))
            {
                loadList.LoadFromFile(sListFileName);
            }
            bool bo15 = false;
            for (int i = 0; i < loadList.Count; i++)
            {
                string s10 = loadList[i].Trim();
                if (string.Compare(val, s10, StringComparison.OrdinalIgnoreCase) == 0)
                {
                    loadList.RemoveAt(i);
                    bo15 = true;
                    break;
                }
            }
            if (bo15)
            {
                loadList.SaveToFile(sListFileName);
            }
        }

        private void ScriptActionError(IPlayerActor playerActor, string sErrMsg, QuestActionInfo questActionInfo, ExecutionCode sCmd)
        {
            //const string sOutMessage = "[脚本错误] {0} 脚本命令:{1} NPC名称:{2} 地图:{3}({4}:{5}) 参数1:{6} 参数2:{7} 参数3:{8} 参数4:{9} 参数5:{10} 参数6:{11}";
            //string sMsg = Format(sOutMessage, sErrMsg, sCmd, ChrName, MapName, CurrX, CurrY, questActionInfo.sParam1, questActionInfo.sParam2, questActionInfo.sParam3, questActionInfo.sParam4, questActionInfo.sParam5, questActionInfo.sParam6);
            //M2Share.Logger.Error(sMsg);
        }

        public void Dispose(object obj)
        {
            obj = null;
        }
    }
}