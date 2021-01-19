using System;
using System.Collections.Generic;
using Fish_Girlz.UI;
using Fish_Girlz.Dialog;
using Fish_Girlz.Utils;
using SFML.System;
using Fish_Girlz.Misc;

namespace Fish_Girlz.States{
    public class UITestState : State
    {
        private UITextField testTextField;
        private UICheckbox checkbox;
        private DialogBox dialogBox;

        public override void Init()
        {
            testTextField=new UITextField(new Vector2f(400,400));
            AddGUI(testTextField);
            checkbox=new UICheckbox(new Vector2u(50,50), new Vector2f(0,0));
            AddGUI(checkbox);
            dialogBox=new DialogBox();
            List<DialogInfo> dialogInfos=new List<DialogInfo>();
            dialogInfos.Add(new DialogInfo(CharacterInfo.DOMINIQUE, "dialog.test1", true));
            dialogInfos.Add(new DialogInfo(CharacterInfo.ASTRA, "dialog.test2", true));
            dialogInfos.Add(new DialogInfo(CharacterInfo.LAURELY, "dialog.test3", true));
            dialogBox.SetDialogs(dialogInfos);
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
        }
    }
}