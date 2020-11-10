using System;
using Fish_Girlz.UI;
using Fish_Girlz.UI.Components;
using Fish_Girlz.Utils;
using SFML.System;

namespace Fish_Girlz.States{
    public class PauseState : State
    {
        private UIButton continueButton, quit, menu;

        public override void Init()
        {
            continueButton=new UIButton(new Vector2u(160, 64), new Vector2f(Utilities.CenterInWindow(DisplayManager.Width, 160), Utilities.CenterInWindow(DisplayManager.Height, 64)-70), "Continue", new Vector2f(19,13), (FontInfo)AssetManager.GetObject("Button Font"));
            menu=new UIButton(new Vector2u(160, 64), new Vector2f(Utilities.CenterInWindow(DisplayManager.Width, 160), Utilities.CenterInWindow(DisplayManager.Height, 64)), "Menu", new Vector2f(42,13), (FontInfo)AssetManager.GetObject("Button Font"));
            quit=new UIButton(new Vector2u(160, 64), new Vector2f(Utilities.CenterInWindow(DisplayManager.Width, 160), Utilities.CenterInWindow(DisplayManager.Height, 64)+70), "Quit", new Vector2f(51,13), (FontInfo)AssetManager.GetObject("Button Font"));
            guis.Add(continueButton);
            guis.Add(quit);
            guis.Add(menu);
            continueButton.OnClick+=new EventHandler((sender, e)=>{StateMachine.RemoveState();});
            quit.OnClick+=new EventHandler((sender, e)=>{DisplayManager.Window.Close();});
            menu.OnClick+=new EventHandler((sender, e)=>{
                StateMachine.RemoveState();
                StateMachine.RemoveState();
                StateMachine.AddState(new MainMenuState());
            });
        }

        public override void Update()
        {

        }
        
        public override void HandleInput()
        {
            if(InputManager.IsKeyPressed(SFML.Window.Keyboard.Key.Escape)){
                StateMachine.RemoveState();
            }
            continueButton.Update();
            quit.Update();
            menu.Update();
        }
    }
}