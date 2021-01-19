using System;
using System.Collections.Generic;
using Fish_Girlz.UI;
using Fish_Girlz.Dialog;
using Fish_Girlz.Utils;
using SFML.System;
using Fish_Girlz.Misc;
using Fish_Girlz.Systems;

namespace Fish_Girlz.States{
    public class UITestState : State
    {
        private UITextField testTextField;
        private UICheckbox checkbox;
        private DialogBox dialogBox;
        private GUIGroup group;

        public override void Init()
        {
            testTextField=new UITextField(new Vector2f(400,400), new Vector2u(300,50));
            AddGUI(testTextField);
            checkbox=new UICheckbox(new Vector2u(50,50), new Vector2f(0,0));
            AddGUI(checkbox);
            dialogBox=new DialogBox();
            List<DialogInfo> dialogInfos=new List<DialogInfo>();
            Localisation.Language language=Localisation.LocalisationLoader.GetCurrentLanguage();
            dialogInfos.Add(new DialogInfo(CharacterInfo.DOMINIQUE, "dialog.test1", language, true));
            dialogInfos.Add(new DialogInfo(CharacterInfo.ASTRA, "dialog.test2", language, true));
            dialogInfos.Add(new DialogInfo(CharacterInfo.LAURELY, "dialog.test3", language, true));
            dialogBox.SetDialogs(dialogInfos);
            group=new GUIGroup();
            group.AddGUI(new UIImage(new Vector2f(200,200), Utilities.CreateTexture(200,200, SFML.Graphics.Color.Green)));
            group.AddGUI(new UIButton(new Vector2u(160,40), new Vector2f(225,255), "Test", new UI.Components.FontInfo(AssetManager.GetFont("Arial"), 18)));
            group.AddGUIs(this);
        }

        public override void HandleInput()
        {

        }

        public override void Update()
        {
            if(InputManager.IsKeyPressed(SFML.Window.Keyboard.Key.Escape)){
                StateMachine.AddState(new MainMenuState());
            }
            if(InputManager.IsKeyPressed(SFML.Window.Keyboard.Key.Space)){
                dialogBox.Show();
            }
            if(InputManager.IsKeyPressed(SFML.Window.Keyboard.Key.E)){
                group.SetVisible(!group.Visible);
            }
        }
    }
}