using System;
using SFML.System;
using SFML.Graphics;
using Fish_Girlz.UI.Components;

namespace Fish_Girlz.UI{
    public class UIImage : GUI
    {
        TextureComponent textureComponent;
        public Texture Texture{get{return textureComponent.Texture;} set{textureComponent.Texture=value;}}

        public UIImage(Vector2f position, Texture texture) : base(position)
        {
            textureComponent=AddComponent(new TextureComponent(texture));
        }
        public UIImage(Vector2f position) : this(position, null)
        {

        }
    }
}