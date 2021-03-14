using SFML.Graphics;
using SFML.System;

namespace Fish_Girlz.UI.Components{
    public class TextureComponent : GUIPositionalComponent
    {
        public Texture Texture{get;set;}
        public Vector2f Size{get;set;}

        public TextureComponent(Texture texture, Vector2f offset) : base(offset)
        {
            Texture=texture;
            Size=(Vector2f)texture.Size;
        }
    }
}