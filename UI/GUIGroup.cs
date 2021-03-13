using System.Collections.Generic;
using SFML.System;

namespace Fish_Girlz.UI{
    public class GUIGroup {
        List<GUI> guis=new List<GUI>();
        Vector2f position;

        public GUIGroup(Vector2f pos){
            position=pos;
        }

        public T AddGUI<T>(T gui) where T : GUI{
            gui.Position+=position;
            guis.Add(gui);
            return gui;
        }

        public void SetVisible(bool value){
            foreach (var gui in guis)
            {
                gui.Visible=value;
            }
        }
    }
}