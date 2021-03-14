using System;
using Fish_Girlz.Misc;
using Fish_Girlz.Systems;
using Fish_Girlz.UI;
using Fish_Girlz.Utils;
using SFML.Graphics;
using SFML.System;

namespace Fish_Girlz.States{
    public class PauseState : State {

        UISelectTextMenu menu;

        Texture backgroundTexture;

        View view;

        public override void Init()
        {
            view=new View(DisplayManager.View);
            FontInfo font=new FontInfo(AssetManager.GetFont("Arial"), 40);
            Camera.ResetView();
            menu=new UISelectTextMenu(new Vector2f(), 10);
            AddGUI(menu.AddText(new UISelectableText(font, "Continue", new Vector2f()))).OnSelect+=new EventHandler((sender, e)=>{StateMachine.RemoveState();});
            AddGUI(menu.AddText(new UISelectableText(font, "Main Menu", new Vector2f()))).OnSelect+=new EventHandler((sender, e)=>{StateMachine.RemoveState();StateMachine.RemoveState();StateMachine.AddState(new MainMenuState());});
            AddGUI(menu.AddText(new UISelectableText(font, "Quit", new Vector2f()))).OnSelect+=new EventHandler((sender, e)=>{DisplayManager.Window.Close();});
            AddSprite(new Sprite(backgroundTexture));
            AddSprite(new Sprite(Utilities.CreateTexture(DisplayManager.Width, DisplayManager.Height, new Color(127,127,127,127))));
            menu.Select(0);
            menu.CenterInWindow();
        }

        public void SetBackgroundTexture(Texture backgroundTexture){
            this.backgroundTexture=backgroundTexture;
        }

        public override void HandleInput()
        {
            if(InputManager.IsEscPressed()){
                StateMachine.RemoveState();
            }
            menu.Update();
        }

        public override void Update()
        {
            
        }

        public override void Remove()
        {
            DisplayManager.Window.SetView(view);
        }
    }
}