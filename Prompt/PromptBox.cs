using System;
using Fish_Girlz.Prompt.UI;
using Fish_Girlz.Utils;
using SFML.System;

namespace Fish_Girlz.Prompt{
    public class PromptBox {
        UIPrompt prompt;

        public PromptBox(){
            prompt=new UIPrompt(new Vector2f());
            StateMachine.ActiveState.AddGUI(prompt);
            prompt.Visible=false;
        }

        public void ShowPrompt(string key){
            prompt.Visible=true;
            prompt.SetText(key);
            prompt.Position=new Vector2f(Utilities.CenterInWindow(DisplayManager.Width, prompt.Width), 100);
        }

        public void HidePrompt(){
            prompt.Visible=false;
        }
    }
}