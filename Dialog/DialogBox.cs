using System;
using System.Collections.Generic;
using Fish_Girlz.UI;
using Fish_Girlz.Utils;
using Fish_Girlz.Misc;
using SFML.System;
using SFML.Graphics;

namespace Fish_Girlz.Dialog{
    public class DialogBox {
        UIDialogBox dialogBox;
        List<DialogInfo> dialogs=new List<DialogInfo>();
        int index=0;
        bool writing;

        public DialogBox(){
            dialogBox=new UIDialogBox(new Vector2f());
            StateMachine.ActiveState.AddGUI(dialogBox);
            dialogBox.Visible=false;
        }

        public void SetDialogs(List<DialogInfo> dialogs){
            this.dialogs=dialogs;
            index=0;
        }

        public void WriteText(){
            if(dialogs.Count>0){
                dialogBox.Visible=true;
                DialogInfo dialogInfo=dialogs[index++];
                dialogBox.Text=DialogUtil.FormatDialog(dialogInfo.Text, dialogInfo.CharacterInfo);
                dialogBox.CharacterName=dialogInfo.CharacterInfo.Name;
                if(dialogInfo.CharacterInfo.Portrait!=null){
                    dialogBox.CharacterTexture=dialogInfo.CharacterInfo.Portrait;
                }
                if(index>dialogs.Count-1){
                    index=0;
                }
            }
        }
    }
}