using Fish_Girlz.Entities;
using Fish_Girlz.Systems;
using Fish_Girlz.Utils;
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
            if(InputManager.IsEscPressed()){
                StateMachine.AddState(new PauseState(), false).SetBackgroundTexture(Utilities.TakeScreenshot());
            }
        }

        public override void Update()
        {
            Camera.TargetEntity(playerEntity);
        }
    }
}