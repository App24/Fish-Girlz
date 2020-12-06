using System;
using Fish_Girlz.Utils;

namespace Fish_Girlz.States{
    public class BattleState : State
    {
        public override void Init()
        {
            
        }

        public override void HandleInput()
        {

        }

        public override void Update()
        {
            StateMachine.RemoveState();
        }

        public override void Remove()
        {
            PlayerStats.ClearPlayerStats();
        }
    }
}