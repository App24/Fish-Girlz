using System;
using System.Collections.Generic;
using Fish_Girlz.UI;
using Fish_Girlz.UI.Components;
using Fish_Girlz.Utils;
using Fish_Girlz.Art;
using SFML.System;
using SFML.Graphics;
using SFML.Window;
using Fish_Girlz.Localisation;

namespace Fish_Girlz.States{
    public class MainMenuState : State
    {
        private UIButton play, quit;


        private UIText version;

        #if (DEV || DEBUG)
            private UIButton uiTestButton;
            private UIButton testButton;
        #endif

        public override void Init()
        {
            play=new UIButton(new Vector2u(160, 64), new Vector2f(Utilities.CenterInWindow(WindowSize.WIDTH, 160), Utilities.CenterInWindow(WindowSize.HEIGHT, 60)-40), Language.GetCurrentLanguage().GetTranslation("button.start"), AssetManager.GetObject<FontInfo>("Button Font"));
            quit=new UIButton(new Vector2u(160, 64), new Vector2f(Utilities.CenterInWindow(WindowSize.WIDTH, 160), Utilities.CenterInWindow(WindowSize.HEIGHT, 60)+40), Language.GetCurrentLanguage().GetTranslation("button.quit"), AssetManager.GetObject<FontInfo>("Button Font"));
            AddGUI(play);
            AddGUI(quit);
            version = new UIText(new FontInfo(AssetManager.GetFont("Arial"), 24), Language.GetCurrentLanguage().GetTranslation("text.version", Program.Version), Color.White, new Vector2f(6, DisplayManager.Height-30));
            AddGUI(version);
            //play.OnClick+=new EventHandler((sender, e)=>{StateMachine.AddState(new GameState());});
            quit.OnClick+=new EventHandler((sender, e)=>{DisplayManager.Window.Close();});

            #if(DEV||DEBUG)
                uiTestButton=new UIButton(new Vector2u(160,64), new Vector2f(Utilities.CenterInWindow(WindowSize.WIDTH, 160), 0), "UI Test", AssetManager.GetObject<FontInfo>("Button Font"));
                uiTestButton.OnClick+=new EventHandler((sender, e)=>{StateMachine.AddState(new UITestState());});
                AddGUI(uiTestButton);
                testButton=new UIButton(new Vector2u(160,64), new Vector2f(Utilities.CenterInWindow(WindowSize.WIDTH, 160), 70), "Test Scene", AssetManager.GetObject<FontInfo>("Button Font"));
                testButton.OnClick+=new EventHandler((sender, e)=>{StateMachine.AddState(new TestState());});
                AddGUI(testButton);
            #endif
        }

        public override void Update()
        {
            
        }

        public override void HandleInput()
        {
            #if DEBUG
            if(InputManager.IsKeyHeld(Keyboard.Key.LAlt)&&InputManager.IsKeyHeld(Keyboard.Key.LControl)){
                StateMachine.AddState(new MapCreatorState());
            }
            #endif
        }
    }
}