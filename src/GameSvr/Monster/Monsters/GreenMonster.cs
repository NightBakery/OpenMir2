﻿using SystemModule;

namespace GameSvr.Monster.Monsters
{
    public class GreenMonster : MonsterObject
    {
        public GreenMonster() : base()
        {
            SearchTime = M2Share.RandomNumber.Random(1500) + 1500;
        }

        public override void Run()
        {
            if (CanWalk())
            {
                if (TargetCret != null)
                {
                    TargetX = TargetCret.CurrX;
                    TargetY = TargetCret.CurrY;
                    if (Math.Abs(TargetX - CurrX) == 1 && Math.Abs(TargetY - CurrY) == 1)
                    {
                        if (M2Share.RandomNumber.Random(TargetCret.AntiPoison + 7) <= 6 && TargetCret.StatusTimeArr[Grobal2.POISON_DECHEALTH] == 0)
                        {
                            TargetCret.MakePosion(Grobal2.POISON_DECHEALTH, 30, 1);
                        }
                    }
                }
                if ((HUtil32.GetTickCount() - SearchEnemyTick) > 8000 || (HUtil32.GetTickCount() - SearchEnemyTick) > 1000 && TargetCret == null)
                {
                    SearchEnemyTick = HUtil32.GetTickCount();
                    SearchTarget();
                }
            }
            base.Run();
        }
    }
}