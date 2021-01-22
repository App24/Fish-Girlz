using System;
using Fish_Girlz.UI;
using Fish_Girlz.UI.Components;
using Fish_Girlz.Utils;
using SFML.System;
using Fish_Girlz.Localisation;
using SFML.Graphics;
using Fish_Girlz.Systems;

namespace Fish_Girlz.States{
    public class PauseState : State
    {
        private UIButton continueButton, quit, menu;
        private UIText pausedText;

        internal override void Init()
        {
            pausedText=new UIText(AssetManager.GetObject<FontInfo>("Title Font"), Language.GetDefault().GetTranslation("text.paused"), Color.White, new Vector2f(DisplayManager.Width/2-68, 200));
            continueButton=new UIButton(new Vector2u(160, 64), new Vector2f(Utilities.CenterInWindow(WindowSize.WIDTH, 160), Utilities.CenterInWindow(WindowSize.HEIGHT, 64)-70), Language.GetDefault().GetTranslation("button.continue"), AssetManager.GetObject<FontInfo>("Button Font"));
            menu=new UIButton(new Vector2u(160, 64), new Vector2f(Utilities.CenterInWindow(WindowSize.WIDTH, 160), Utilities.CenterInWindow(WindowSize.HEIGHT, 64)), Language.GetDefault().GetTranslation("button.menu"), AssetManager.GetObject<FontInfo>("Button Font"));
            quit=new UIButton(new Vector2u(160, 64), new Vector2f(Utilities.CenterInWindow(WindowSize.WIDTH, 160), Utilities.CenterInWindow(WindowSize.HEIGHT, 64)+70), Language.GetDefault().GetTranslation("button.quit"), AssetManager.GetObject<FontInfo>("Button Font"));
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

        internal override void Update()
        {

        }
        
        internal override void HandleInput()
        {
            if(InputManager.IsKeyPressed(SFML.Window.Keyboard.Key.Escape)){
                StateMachine.RemoveState();
            }
        }
    }
}