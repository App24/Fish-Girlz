using System;
using Fish_Girlz.UI;
using Fish_Girlz.Utils;
using SFML.System;
using SFML.Graphics;

namespace Fish_Girlz.UI.Presets{
    public class DialogBox {
        UIDialogBox dialogBox;

        public DialogBox(){
            dialogBox=new UIDialogBox(new Vector2f());
            StateMachine.ActiveState.AddGUI(dialogBox);
            dialogBox.Visible=false;
        }

        public void ShowDialogBox(Texture characterTexture){
            if(characterTexture!=null){
                dialogBox.CharacterTexture=characterTexture;
            }else{
                dialogBox.CharacterTexture=Utilities.CreateTexture(10,10,Color.White);
            }
            if(!dialogBox.Visible){
                dialogBox.Visible=true;
            }
        }
    }
}