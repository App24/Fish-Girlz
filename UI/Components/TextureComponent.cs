using System;
using SFML.Graphics;
using SFML.System;

namespace Fish_Girlz.UI.Components{
    public class TextureComponent : GUIComponent {
        public Texture Texture{get;set;}
        public Vector2f Pos{get;set;}

        public TextureComponent(Texture texture):base(2){
            this.Texture=texture;
        }
    }
}