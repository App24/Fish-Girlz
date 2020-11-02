using System;
using Fish_Girlz.UI;
using Fish_Girlz.Utils;
using SFML.System;

namespace Fish_Girlz.States{
    public class PauseState : State
    {
        private UIButton continueButton, quit, menu;

        public override void Init()
        {
            continueButton=new UIButton(new Vector2u(160, 64), new Vector2f(Utilities.CenterInWindow(DisplayManager.Width, 160), Utilities.CenterInWindow(DisplayManager.Height, 64)-70), "Continue", new Vector2f(19,13));
            menu=new UIButton(new Vector2u(160, 64), new Vector2f(Utilities.CenterInWindow(DisplayManager.Width, 160), Utilities.CenterInWindow(DisplayManager.Height, 64)), "Menu", new Vector2f(42,13));
            quit=new UIButton(new Vector2u(160, 64), new Vector2f(Utilities.CenterInWindow(DisplayManager.Width, 160), Utilities.CenterInWindow(DisplayManager.Height, 64)+70), "Quit", new Vector2f(51,13));
            guis.Add(continueButton);
            guis.Add(quit);
            guis.Add(menu);
        }

        public override void Update()
        {

        }
        
        public override void HandleInput()
        {
            if(continueButton.OnClick()||InputManager.IsKeyPressed(SFML.Window.Keyboard.Key.Escape)){
                StateMachine.RemoveState();
            }
            if(quit.OnClick()){
                DisplayManager.Window.Close();
            }
            if(menu.OnClick()){
                StateMachine.RemoveState();
                StateMachine.RemoveState();
                StateMachine.AddState(new MainMenuState());
            }
        }
    }
}