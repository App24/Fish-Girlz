using System;
using Fish_Girlz.Systems;
using Fish_Girlz.UI;
using Fish_Girlz.Misc;

namespace Fish_Girlz.States{
    public class MainMenuState : State
    {

        UISelectTextMenu menu;

        FontInfo arial24=new FontInfo(AssetManager.GetFont("Arial"), 24);

        public override void Init()
        {
            menu=new UISelectTextMenu();
            AddGUI(menu.AddText(new UISelectableText(arial24, "Play", new SFML.System.Vector2f())));
            #if DEBUG
            AddGUI(menu.AddText(new UISelectableText(arial24, "Test", new SFML.System.Vector2f()))).OnSelect+=new EventHandler((sender, e)=>{StateMachine.AddState(new TestState());});
            AddGUI(menu.AddText(new UISelectableText(arial24, "Map Editor", new SFML.System.Vector2f()))).OnSelect+=new EventHandler((sender, e)=>{StateMachine.AddState(new MapEditorState());});
            #endif
            AddGUI(menu.AddText(new UISelectableText(arial24, "Settings", new SFML.System.Vector2f())));
            AddGUI(menu.AddText(new UISelectableText(arial24, "Credits", new SFML.System.Vector2f())));
            AddGUI(menu.AddText(new UISelectableText(arial24, "Quit", new SFML.System.Vector2f()))).OnSelect+=new EventHandler((sender, e)=>{DisplayManager.Window.Close();});
            menu.Select(0);
            menu.CenterInWindow();
        }

        public override void HandleInput()
        {
            menu.Update();
        }

        public override void Update()
        {

        }
    }
}