using System;
using Fish_Girlz.Utils;
using SFML.System;

namespace Fish_Girlz.UI.Components{
    public class ClickComponent : GUIComponent{
        private Vector4f bounds;

        public ClickComponent(Vector4f bounds):base(0){
            this.bounds=bounds;
        }
        
        public bool OnClick(){
            if(onHover()){
                if(InputManager.IsMouseButtonPressed(SFML.Window.Mouse.Button.Left)){
                    return true;
                }
            }
            return false;
        }

        public bool onHover(){
            return InputManager.Hover(bounds);
        }
    }
}