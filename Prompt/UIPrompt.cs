using System;
using Fish_Girlz.UI;
using Fish_Girlz.Utils;
using Fish_Girlz.UI.Components;
using SFML.System;
using SFML.Graphics;

namespace Fish_Girlz.Prompt.UI{
    public class UIPrompt : GUI
    {
        TextureComponent topLeft, topRight, top, bottomLeft, bottomRight, bottom, left, right, center;
        TextComponent key;

        public float Width{get;private set;}

        public UIPrompt(Vector2f position) : base(position)
        {
            topLeft=AddComponent(new TextureComponent(AssetManager.GetTexture("DialogBoxTopLeft")));
            top=AddComponent(new TextureComponent(AssetManager.GetTexture("DialogBoxTop")));
            topRight=AddComponent(new TextureComponent(AssetManager.GetTexture("DialogBoxTopRight")));
            left=AddComponent(new TextureComponent(AssetManager.GetTexture("DialogBoxLeft")));
            bottomLeft=AddComponent(new TextureComponent(AssetManager.GetTexture("DialogBoxBottomLeft")));
            bottomRight=AddComponent(new TextureComponent(AssetManager.GetTexture("DialogBoxBottomRight")));
            bottom=AddComponent(new TextureComponent(AssetManager.GetTexture("DialogBoxBottom")));
            right=AddComponent(new TextureComponent(AssetManager.GetTexture("DialogBoxRight")));
            center=AddComponent(new TextureComponent(AssetManager.GetTexture("DialogBoxCenter")));
            ChangeScale(new Vector2f());

            key=AddComponent(new TextComponent(new FontInfo(AssetManager.GetFont("Arial"), 20), "", new Vector2f(40,35), Color.Black));
        }

        public void SetText(string text){
            key.Text=text;
            FloatRect bounds=key.Bounds;
            float width=bounds.Width;
            float missingWidth=width/432f;
            float height=bounds.Height+1;
            float missingHeight=height/110f;
            ChangeScale(new Vector2f(missingWidth, missingHeight));
        }

        void ChangeScale(Vector2f scale){
            top.Scale=new Vector2f(scale.X,1);
            bottom.Scale=new Vector2f(scale.X,1);
            left.Scale=new Vector2f(1,scale.Y);
            right.Scale=new Vector2f(1,scale.Y);
            center.Scale=scale;

            top.Position=new Vector2f(40,0);
            topRight.Position=new Vector2f(40+(432*top.Scale.X),0);
            center.Position=new Vector2f(40,40);
            left.Position=new Vector2f(0,40);
            bottomLeft.Position=new Vector2f(0,40+(110*left.Scale.Y));
            bottomRight.Position=new Vector2f(40+(432*bottom.Scale.X), 40+(110*right.Scale.Y));
            right.Position=new Vector2f(40+(432*top.Scale.X),40);
            bottom.Position=new Vector2f(40, 40+(110*left.Scale.Y));
            Width=80+(scale.X*432);
        }
    }
}