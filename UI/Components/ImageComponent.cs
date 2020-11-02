using System;
using SFML.Graphics;

namespace Fish_Girlz.UI.Components{
    public class ImageComponent : GUIComponent {
        public Texture Texture{get;set;}

        public ImageComponent(Texture texture):base(2){
            this.Texture=texture;
        }
    }
}