using System;
using System.Collections.Generic;
using Fish_Girlz.States;
using SFML.System;

namespace Fish_Girlz.UI{
    public class GUIGroup {
        public List<GUI> Guis {get;private set;}=new List<GUI>();
        public bool Visible{get;private set;}=true;
        private bool added=false;

        public Vector2f Position{get{return _position;}set{
            _position=value;
            foreach (GUI gui in Guis)
            {
                gui.Offset=value;
            }
        }}

        private Vector2f _position=new Vector2f();

        public T AddGUI<T>(T gui) where T : GUI{
            gui.Offset=_position;
            Guis.Add(gui);
            return gui;
        }

        public void SetVisible(bool value){
            foreach (GUI gui in Guis)
            {
                gui.SetVisible(value);
            }
            Visible=value;
        }

        public void AddGUIs(State state){
            if(added) return;
            foreach (GUI gui in Guis)
            {
                state.AddGUI(gui);
            }
            added=true;
        }
    }
}