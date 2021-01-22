using System;
using SFML.System;
using SFML.Graphics;
using Fish_Girlz.UI.Components;
using Fish_Girlz.Utils;

namespace Fish_Girlz.UI{
    public class UIProgressBar : GUI {
        float percentage;
        TextureComponent bar;
        Vector2u size;

        public UIProgressBar(Vector2u size, Vector2f position, Color backgroundColor, Color barColor):base(position){
            AddComponent(new TextureComponent(Utilities.CreateTexture(size.X,size.Y,backgroundColor)));
            bar=AddComponent(new TextureComponent(Utilities.CreateTexture(size.X,size.Y,barColor)));
            this.size=size;
            SetPercentage(1);
        }

        public void SetPercentage(float newPercentage){
            percentage=newPercentage;
            percentage=percentage.Clamp(0,1);
            bar.Texture=Utilities.CreateTexture((uint)(size.X*percentage), size.Y, Color.White);
        }

        public float GetPercentage(){
            return percentage;
        }
    }
}