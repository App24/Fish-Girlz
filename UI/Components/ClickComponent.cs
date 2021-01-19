using System;
using Fish_Girlz.Utils;
using SFML.System;

namespace Fish_Girlz.UI.Components{
    public class ClickComponent : GUIComponent{
        
        public bool OnClick(Vector4f bounds){
            if(onHover(bounds)){
                if(InputManager.IsMouseButtonPressed(SFML.Window.Mouse.Button.Left)){
                    InputManager.ClickedUI(SFML.Window.Mouse.Button.Left);
                    return true;
                }
            }
            return false;
        }

        public bool onHover(Vector4f bounds){
            return InputManager.Hover(bounds);
        }
    }
}