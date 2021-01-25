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
        internal LivingEntity Enemy0 {get;}
        internal LivingEntity Enemy1 {get;}
        internal LivingEntity Enemy2 {get;}

        internal BattleData(PlayerEntity player, LivingEntity enemy0, LivingEntity enemy1, LivingEntity enemy2){
            this.Player=player;
            this.Enemy0=enemy0;
            this.Enemy1=enemy1;
            this.Enemy2=enemy2;
        }
    }
}