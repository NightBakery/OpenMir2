﻿namespace GameSrv.Monster.Monsters {
    public class DefendMonster : MonsterObject {
        public DefendMonster()
            : base() {
            SearchTime = GameShare.RandomNumber.Random(1500) + 1500;
        }

        public override void Run() {
            base.Run();
        }
    }
}