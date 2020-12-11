using System;
using System.Collections.Generic;
using Fish_Girlz.Art;
using Fish_Girlz.UI.Components;
using SFML.System;

namespace Fish_Girlz.UI{
    public abstract class GUI : IComparable<GUI> {
        public Vector2f Position{get; set;}
        public bool ToRemove {get; protected set;}
        public bool Visible{get;set;}

        public int Layer{get;set;}

        private List<GUIComponent> components=new List<GUIComponent>();

        public GUI(Vector2f position){
            Position=position;
            Visible=true;
        }

        protected T AddComponent<T>(T component) where T : GUIComponent{
            components.Add(component);
            return component;
        }

        public List<GUIComponent> GetGUIComponents(){
            return components;
        }

        public int CompareTo(GUI gui){
            if(gui==null)
                return 1;
            else
                return Layer.CompareTo(gui.Layer);
        }
    }
}