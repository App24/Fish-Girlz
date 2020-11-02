using System;

namespace Fish_Girlz.UI.Components{
    public abstract class GUIComponent : IComparable<GUIComponent> {
        private int layer;
        
        public GUIComponent(int layer){
            this.layer=layer;
        }

        public int CompareTo(GUIComponent guiComponent){
            if(guiComponent==null)
                return 1;
            else
                return layer.CompareTo(guiComponent.layer);
        }
    }
}