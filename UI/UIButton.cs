using System;
using SFML.Graphics;
using SFML.System;
using Fish_Girlz.Art;
using Fish_Girlz.Audio;
using Fish_Girlz.Utils;
using Fish_Girlz.UI.Components;

namespace Fish_Girlz.UI{
    public class UIButton : GUI {
        private ClickComponent clickComponent;
        private ImageComponent imageComponent;
        private ButtonInformation buttonInformation;
        private Sound clickSound;

        struct ButtonInformation
        {
            public Texture normalTexture, hoverTexture;

            public ButtonInformation(Texture normalTexture, Texture hoverTexture){
                this.normalTexture=normalTexture;
                this.hoverTexture=hoverTexture;
            }
        }

        public UIButton(Vector2u size, Vector2f position, string text, Vector2f textPosition):base(position){
            Texture texture=Utilities.CreateTexture(size.X,size.Y, new Color(255,255,255));
            Texture hoverTexture=Utilities.CreateTexture(size.X,size.Y, new Color(255/2,255/2,255/2));
            buttonInformation=new ButtonInformation(texture, hoverTexture);
            clickComponent=AddComponent(new ClickComponent(new Vector4f(position, (Vector2f)texture.Size)));
            imageComponent=AddComponent(new ImageComponent(texture));
            AddComponent(new TextComponent(AssetManager.GetFont("Arial"), text, textPosition, Color.Black));
            clickSound=new Sound(AssetManager.GetSoundBuffer("Button Click"));
        }

        public bool OnClick(){
            if(clickComponent.onHover()){
                imageComponent.Texture=buttonInformation.hoverTexture;
            }else{
                imageComponent.Texture=buttonInformation.normalTexture;
            }
            if(clickComponent.OnClick()){
                clickSound.Play();
                return true;
            }
            return false;
        }
    }
}