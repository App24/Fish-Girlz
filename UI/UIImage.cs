using SFML.System;
using SFML.Graphics;
using Fish_Girlz.UI.Components;

namespace Fish_Girlz.UI{
    public class UIImage : GUI
    {
        public TextureComponent TextureComponent{get;}

        public UIImage(Texture texture, Vector2f position) : base(position)
        {
            TextureComponent=AddComponent(new TextureComponent(texture, new Vector2f()));
        }
    }
}