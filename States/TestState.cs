using Fish_Girlz.Entities;
using Fish_Girlz.Systems;
using SFML.System;

namespace Fish_Girlz.States{
    public class TestState : State
    {
        PlayerEntity playerEntity;

        public override void Init()
        {
            playerEntity=AddEntity(new PlayerEntity(new Vector2f()));
        }

        public override void HandleInput()
        {

        }

        public override void Update()
        {
            
        }
    }
}