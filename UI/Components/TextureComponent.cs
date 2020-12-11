using System;
using SFML.Graphics;
using SFML.System;

namespace Fish_Girlz.UI.Components{
    public class TextureComponent : GUIComponent {
        public Texture Texture{get;set;}
        public Vector2f Position{get;set;}
        public Vector2f Scale{get;set;}
        public Vector2u MaxSize{get;set;}
        public float Rotation{get;set;}

        public TextureComponent(Texture texture){
            this.Texture=texture;
            Scale=new Vector2f(1,1);
            MaxSize=new Vector2u();
        }
    }
}