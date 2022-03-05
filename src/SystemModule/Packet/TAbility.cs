﻿using System;
using System.IO;

namespace SystemModule
{
    public class TAbility : Packets
    {
        public ushort Level;
        public int AC;
        public int MAC;
        public int DC;
        public int MC;
        public int SC;
        /// <summary>
        /// 生命值
        /// </summary>
        public ushort HP;
        /// <summary>
        /// 魔法值
        /// </summary>
        public ushort MP;
        public ushort MaxHP;
        public ushort MaxMP;
        /// <summary>
        /// 当前经验
        /// </summary>
        public int Exp;
        /// <summary>
        /// 最大经验
        /// </summary>
        public int MaxExp;
        /// <summary>
        /// 背包重
        /// </summary>
        public ushort Weight;
        /// <summary>
        /// 背包最大重量
        /// </summary>
        public ushort MaxWeight;
        /// <summary>
        /// 当前负重
        /// </summary>
        public ushort WearWeight;
        /// <summary>
        /// 最大负重
        /// </summary>
        public ushort MaxWearWeight;
        /// <summary>
        /// 腕力
        /// </summary>
        public ushort HandWeight;
        /// <summary>
        /// 最大腕力
        /// </summary>
        public ushort MaxHandWeight;

        public TAbility() { }

        public TAbility(byte[] buff)
        {
            Level = BitConverter.ToUInt16(buff, 0);
            AC = BitConverter.ToUInt16(buff, 2);
            MAC = BitConverter.ToUInt16(buff, 6);
            DC = BitConverter.ToUInt16(buff, 10);
            MC = BitConverter.ToUInt16(buff, 14);
            SC = BitConverter.ToUInt16(buff, 18);
            HP = BitConverter.ToUInt16(buff, 22);
            MP = BitConverter.ToUInt16(buff, 24);
            MaxHP = BitConverter.ToUInt16(buff, 26);
            MaxMP = BitConverter.ToUInt16(buff, 28);
            Exp = BitConverter.ToInt32(buff, 30);
            MaxExp = BitConverter.ToInt32(buff, 34);
            Weight = BitConverter.ToUInt16(buff, 38);
            MaxWeight = BitConverter.ToUInt16(buff, 40);
            WearWeight = BitConverter.ToUInt16(buff, 42);
            MaxWearWeight = BitConverter.ToUInt16(buff, 44);
            HandWeight = BitConverter.ToUInt16(buff, 46);
            MaxHandWeight = BitConverter.ToUInt16(buff, 48);
        }

        protected override void ReadPacket(BinaryReader reader)
        {
            throw new NotImplementedException();
        }

        protected override void WritePacket(BinaryWriter writer)
        {
            writer.Write(Level);
            writer.Write(AC);
            writer.Write(MAC);
            writer.Write(DC);
            writer.Write(MC);
            writer.Write(SC);
            writer.Write(HP);
            writer.Write(MP);
            writer.Write(MaxHP);
            writer.Write(MaxMP);
            writer.Write(Exp);
            writer.Write(MaxExp);
            writer.Write(Weight);
            writer.Write(MaxWeight);
            writer.Write(WearWeight);
            writer.Write(MaxWearWeight);
            writer.Write(HandWeight);
            writer.Write(MaxHandWeight);
        }
    }
}