using System;
using Fish_Girlz.UI;
using Fish_Girlz.Utils;
using SFML.System;

namespace Fish_Girlz.States{
    public class UITestState : State
    {
        private UITextField test;

        public override void Init()
        {
            test=new UITextField(new Vector2f(400,400));
            guis.Add(test);
        }

        public override void HandleInput()
        {

        }

        public override void Update()
        {
            if(InputManager.IsKeyPressed(SFML.Window.Keyboard.Key.Escape)){
                StateMachine.AddState(new MainMenuState());
            }
        }
    }
}