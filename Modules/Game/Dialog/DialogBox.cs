using System.Collections.Generic;
using Fish_Girlz.Dialog.UI;
using SFML.System;
using Fish_Girlz.Systems;

namespace Fish_Girlz.Dialog
{
    public class DialogBox {
        UIDialogBox dialogBox;
        List<DialogInfo> dialogs=new List<DialogInfo>();
        int index=0;
        //bool writing;
        bool ignore;

        internal DialogBox(){
            dialogBox=new UIDialogBox(new Vector2f(0,475));
            StateMachine.ActiveState.AddGUI(dialogBox);
            dialogBox.SetVisible(false);
        }

        public void SetDialogs(List<DialogInfo> dialogs){
            this.dialogs=dialogs;
            index=0;
        }

        public void Show(){
            if(dialogs.Count>0){
                dialogBox.SetVisible(true);
                ignore=true;
            }
        }

        public void Update(){
            if(!dialogBox.Visible) return;
            if((InputManager.IsMouseButtonPressed(SFML.Window.Mouse.Button.Left)||InputManager.IsKeyPressed(SFML.Window.Keyboard.Key.Space))&&!ignore){
                index++;
                if(index>dialogs.Count-1){
                    Hide();
                    index=0;
                }
            }
            ignore=false;
            DialogInfo dialogInfo=dialogs[index];
            dialogBox.Text=DialogUtil.FormatDialog(dialogInfo.Text, dialogInfo.CharacterInfo);
            dialogBox.CharacterName=dialogInfo.CharacterInfo.Name;
            if(dialogInfo.CharacterInfo.Portrait!=null){
                dialogBox.CharacterTexture=dialogInfo.CharacterInfo.Portrait;
            }
        }

        public void Hide(){
            if(!dialogBox.Visible)
                return;
            dialogBox.SetVisible(false);
        }

        public bool Visible=>dialogBox.Visible;
    }
}