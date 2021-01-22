using Fish_Girlz.Entities;
using Fish_Girlz.Systems;
using Fish_Girlz.States;

namespace Fish_Girlz.Battle
{
    internal static class BattleSystem {
        internal static void TriggerBattle(BattleData battleData){
            StateMachine.AddState(new BattleState(), false).battleData=battleData;
        }
    }

    internal struct BattleData{
        internal PlayerEntity Player {get;}
        internal EnemyEntity Enemy0 {get;}
        internal EnemyEntity Enemy1 {get;}
        internal EnemyEntity Enemy2 {get;}

        internal BattleData(PlayerEntity player, EnemyEntity enemy0, EnemyEntity enemy1, EnemyEntity enemy2){
            this.Player=player;
            this.Enemy0=enemy0;
            this.Enemy1=enemy1;
            this.Enemy2=enemy2;
        }
    }
}