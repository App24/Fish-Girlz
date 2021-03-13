using SFML.System;

namespace Fish_Girlz.UI.Components{
    public abstract class GUIPositionalComponent : GUIComponent {
        public Vector2f Offset{get;protected set;}

        public GUIPositionalComponent(Vector2f offset){
            Offset=offset;
        }

        public Vector2f GetPosition(){
            return ParentGUI.Position+Offset;
        }
    }
}