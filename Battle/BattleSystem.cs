using System;
using Fish_Girlz.Entities;

namespace Fish_Girlz.Battle{
    public static class BattleSystem {
        public static void TriggerBattle(BattleData battleData){
            
        }
    }

    public struct BattleData{
        public PlayerEntity Player {get;}
        public EnemyEntity Enemy0 {get;}
        public EnemyEntity Enemy1 {get;}
        public EnemyEntity Enemy2 {get;}

        public BattleData(PlayerEntity player, EnemyEntity enemy0, EnemyEntity enemy1, EnemyEntity enemy2){
            this.Player=player;
            this.Enemy0=enemy0;
            this.Enemy1=enemy1;
            this.Enemy2=enemy2;
        }
    }
}