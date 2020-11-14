using System;
using System.Collections.Generic;
using Fish_Girlz.UI;
using Fish_Girlz.UI.Components;
using Fish_Girlz.Utils;
using Fish_Girlz.Art;
using SFML.System;
using SFML.Graphics;
using Fish_Girlz.Localisation;

namespace Fish_Girlz.States{
    public class MainMenuState : State
    {
        private UIButton play, quit;

        private UIText version;

        public override void Init()
        {
            play=new UIButton(new Vector2u(160, 64), new Vector2f(Utilities.CenterInWindow(DisplayManager.Width, 160), Utilities.CenterInWindow(DisplayManager.Height, 60)-40), Language.GetCurrentLanguage().GetTranslation("button.start"), new Vector2f(2,13), (FontInfo)AssetManager.GetObject("Button Font"));
            quit=new UIButton(new Vector2u(160, 64), new Vector2f(Utilities.CenterInWindow(DisplayManager.Width, 160), Utilities.CenterInWindow(DisplayManager.Height, 60)+40), Language.GetCurrentLanguage().GetTranslation("button.quit"), new Vector2f(51,13), (FontInfo)AssetManager.GetObject("Button Font"));
            guis.Add(play);
            guis.Add(quit);
            version = new UIText(new FontInfo(AssetManager.GetFont("Arial"), 24), Language.GetCurrentLanguage().GetTranslation("text.version", Program.Version), Color.White, new Vector2f(6, DisplayManager.Height-30));
            guis.Add(version);
            play.OnClick+=new EventHandler((sender, e)=>{StateMachine.AddState(new GameState());});
            quit.OnClick+=new EventHandler((sender, e)=>{DisplayManager.Window.Close();});
        }

        public override void Update()
        {
            
        }

        public override void HandleInput()
        {
            play.Update();
            quit.Update();
        }
    }
}