using System;
using SFML.Graphics;
using SFML.System;
using Fish_Girlz.Art;
using Fish_Girlz.Audio;
using Fish_Girlz.Utils;
using Fish_Girlz.UI.Components;
using Fish_Girlz.Systems;

namespace Fish_Girlz.UI{
    public class UIButton : UpdatableGUI {
        private ClickComponent clickComponent;
        private TextureComponent textureComponent;
        private ButtonInformation buttonInformation;
        private Sound clickSound;

        TextComponent textComponent;

        public EventHandler OnClick;

        struct ButtonInformation
        {
            public Texture normalTexture, hoverTexture;

            public ButtonInformation(Texture normalTexture, Texture hoverTexture){
                this.normalTexture=normalTexture;
                this.hoverTexture=hoverTexture;
            }
        }

        public UIButton(Vector2u size, Vector2f position, string text, FontInfo fontInfo, Color normalColor, Color hoverColor):base(position){
            Texture texture=Utilities.CreateTexture(size.X,size.Y, normalColor);
            Texture hoverTexture=Utilities.CreateTexture(size.X,size.Y, hoverColor);
            buttonInformation=new ButtonInformation(texture, hoverTexture);
            clickComponent=AddComponent(new ClickComponent());
            textureComponent=AddComponent(new TextureComponent(texture));
            textComponent=AddComponent(new TextComponent(fontInfo, text, Color.Black));
            textComponent.Position=new Vector2f((size.X-textComponent.Bounds.Width)/2f,fontInfo.Size/2f-2);
            clickSound=new Sound(AssetManager.GetSoundBuffer("Button Click"));
        }

        public UIButton(Vector2u size, Vector2f position, string text, FontInfo fontInfo) : this(size, position, text, fontInfo, new Color(255,255,255), new Color(255/2,255/2,255/2)){

        }

        public override void Update(){
            if(clickComponent.onHover(new Vector4f(Position, (Vector2f)textureComponent.Texture.Size))){
                textureComponent.Texture=buttonInformation.hoverTexture;
            }else{
                textureComponent.Texture=buttonInformation.normalTexture;
            }
            if(clickComponent.OnClick(new Vector4f(Position, (Vector2f)textureComponent.Texture.Size))){
                clickSound.Play();
                OnClick?.Invoke(this, new EventArgs());
            }
        }
    }
}