using System;
using Fish_Girlz.UI;
using Fish_Girlz.UI.Components;
using Fish_Girlz.Utils;
using SFML.System;
using Fish_Girlz.Localisation;
using SFML.Graphics;

namespace Fish_Girlz.States{
    public class PauseState : State
    {
        private UIButton continueButton, quit, menu;
        private UIText pausedText;

        public override void Init()
        {
            pausedText=new UIText((FontInfo)AssetManager.GetObject("Title Font"), Language.GetCurrentLanguage().GetTranslation("text.paused"), Color.White, new Vector2f(DisplayManager.Width/2-68, 200));
            continueButton=new UIButton(new Vector2u(160, 64), new Vector2f(Utilities.CenterInWindow(DisplayManager.Width, 160), Utilities.CenterInWindow(DisplayManager.Height, 64)-70), Language.GetCurrentLanguage().GetTranslation("button.continue"), (FontInfo)AssetManager.GetObject("Button Font"));
            menu=new UIButton(new Vector2u(160, 64), new Vector2f(Utilities.CenterInWindow(DisplayManager.Width, 160), Utilities.CenterInWindow(DisplayManager.Height, 64)), Language.GetCurrentLanguage().GetTranslation("button.menu"), (FontInfo)AssetManager.GetObject("Button Font"));
            quit=new UIButton(new Vector2u(160, 64), new Vector2f(Utilities.CenterInWindow(DisplayManager.Width, 160), Utilities.CenterInWindow(DisplayManager.Height, 64)+70), Language.GetCurrentLanguage().GetTranslation("button.quit"), (FontInfo)AssetManager.GetObject("Button Font"));
            AddGUI(pausedText);
            AddGUI(continueButton);
            AddGUI(quit);
            AddGUI(menu);
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
        }
    }
}