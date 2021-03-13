using SFML.System;
using System.Collections.Generic;
using Fish_Girlz.UI.Components;
using Fish_Girlz.Utils;

namespace Fish_Girlz.UI{
    public abstract class GUI {
        public Vector2f Position{get;set;}

        public bool ToRemove{get;set;}

        public bool Visible{get;set;}=true;

        List<GUIComponent> components=new List<GUIComponent>();

        public GUI(Vector2f position){
            Position=position;
        }

        protected T AddComponent<T>(T component) where T : GUIComponent{
            component.ParentGUI=this;
            components.Add(component);
            return component;
        }

        public List<GUIComponent> GetGUIComponents(){
            return components.Clone();
        }
    }
}