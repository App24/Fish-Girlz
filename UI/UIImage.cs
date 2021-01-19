using System;
using SFML.System;
using SFML.Graphics;
using Fish_Girlz.UI.Components;

namespace Fish_Girlz.UI{
    public class UIImage : UpdatableGUI
    {
        TextureComponent textureComponent;
        ClickComponent clickComponent;
        public Texture Texture{get{return textureComponent.Texture;} set{textureComponent.Texture=value;}}

        public UIImage(Vector2f position, Texture texture) : base(position)
        {
            textureComponent=AddComponent(new TextureComponent(texture));
            clickComponent=AddComponent(new ClickComponent());
        }
        public UIImage(Vector2f position) : this(position, null)
        {

        }

        public override void Update()
        {
            if(textureComponent.Texture!=null){
                clickComponent.OnClick(new Vector4f(Position, (Vector2f)Texture.Size));
            }
        }
    }
}