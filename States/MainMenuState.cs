using System;
using System.Collections.Generic;
using Fish_Girlz.UI;
using Fish_Girlz.Utils;
using Fish_Girlz.Art;
using SFML.System;
using SFML.Graphics;

namespace Fish_Girlz.States{
    public class MainMenuState : State
    {
        private UIButton play, quit;

        public override void Init()
        {
            play=new UIButton(new Vector2u(160, 64), new Vector2f(Utilities.CenterInWindow(DisplayManager.Width, 160), Utilities.CenterInWindow(DisplayManager.Height, 60)-40), "Start Game", new Vector2f(2,13));
            quit=new UIButton(new Vector2u(160, 64), new Vector2f(Utilities.CenterInWindow(DisplayManager.Width, 160), Utilities.CenterInWindow(DisplayManager.Height, 60)+40), "Quit", new Vector2f(51,13));
            guis.Add(play);
            guis.Add(quit);
        }

        public override void Update()
        {
            
        }

        public override void HandleInput()
        {
            if(play.OnClick()){
                StateMachine.AddState(new GameState());
            }
            if(quit.OnClick()){
                DisplayManager.Window.Close();
            }
        }
    }
}