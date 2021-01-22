using SFML.System;
using SFML.Graphics;
using Fish_Girlz.Utils;
using Fish_Girlz.UI;
using Fish_Girlz.UI.Components;
using Fish_Girlz.Systems;

namespace Fish_Girlz.Dialog.UI{
    internal class UIDialogBox : GUI
    {
        TextureComponent topLeft, topRight, top, bottomLeft, bottomRight, bottom, left, right, center;
        TextureComponent characterTextureComponent;
        TextComponent characterNameTextComponent;
        TextComponent textTextComponent;

        public Texture CharacterTexture{
            get{
                return characterTextureComponent.Texture;
            }
            set{
                characterTextureComponent.Texture=value;
            }
        }

        public string CharacterName{
            get{
                return characterNameTextComponent.Text;
            }
            set{
                characterNameTextComponent.Text=value;
            }
        }

        public string Text{
            get{
                return textTextComponent.Text;
            }
            set{
                textTextComponent.Text=value;
            }
        }

        public UIDialogBox(Vector2f position) : base(position)
        {
            //AddComponent(new TextureComponent(Utilities.CreateTexture(40,432, true, new ColorData(0, 7/40f, new Color(0,0,0,0)), new ColorData(0.2f, 0.2f, new Color(0,0,0,228)), new ColorData(9/40f, 15/40f, Color.Black), new ColorData(16/40f, 16/40f, new Color(180,75,92,255)), new ColorData(17/40f, 23/40f, new Color(250,102,128,255)), new ColorData(24/40f, 24/40f, new Color(250,146,161,255)), new ColorData(25/40f, 32/40f, new Color(250,255,255,255)), new ColorData(33/40f,1,new Color(250,146,164,255)))));
            topLeft=AddComponent(new TextureComponent(AssetManager.GetTexture("DialogBoxTopLeft")));
            top=AddComponent(new TextureComponent(AssetManager.GetTexture("DialogBoxTop")));
            topRight=AddComponent(new TextureComponent(AssetManager.GetTexture("DialogBoxTopRight")));
            left=AddComponent(new TextureComponent(AssetManager.GetTexture("DialogBoxLeft")));
            bottomLeft=AddComponent(new TextureComponent(AssetManager.GetTexture("DialogBoxBottomLeft")));
            bottomRight=AddComponent(new TextureComponent(AssetManager.GetTexture("DialogBoxBottomRight")));
            bottom=AddComponent(new TextureComponent(AssetManager.GetTexture("DialogBoxBottom")));
            right=AddComponent(new TextureComponent(AssetManager.GetTexture("DialogBoxRight")));
            center=AddComponent(new TextureComponent(AssetManager.GetTexture("DialogBoxCenter")));
            top.Scale=new Vector2f(2.777777777777778f,1);
            bottom.Scale=new Vector2f(2.777777777777778f,1);
            left.Scale=new Vector2f(1,1.5f);
            right.Scale=new Vector2f(1,1.5f);
            center.Scale=new Vector2f(2.777777777777778f,1.5f);

            top.Position=new Vector2f(40,0);
            topRight.Position=new Vector2f(40+(432*top.Scale.X),0);
            center.Position=new Vector2f(40,40);
            left.Position=new Vector2f(0,40);
            bottomLeft.Position=new Vector2f(0,40+(110*left.Scale.Y));
            bottomRight.Position=new Vector2f(40+(432*bottom.Scale.X), 40+(110*right.Scale.Y));
            right.Position=new Vector2f(40+(432*top.Scale.X),40);
            bottom.Position=new Vector2f(40, 40+(110*left.Scale.Y));

            characterTextureComponent=AddComponent(new TextureComponent(Utilities.CreateTexture(10,10,Color.White)));
            characterTextureComponent.Position=new Vector2f(40,40);
            characterTextureComponent.MaxSize=new Vector2u(170,170);
            characterNameTextComponent=AddComponent(new TextComponent(new FontInfo(AssetManager.GetFont("Arial"), 25), "", new Vector2f(), Color.Black));
            characterNameTextComponent.Position=new Vector2f(40+170,40);

            textTextComponent=AddComponent(new TextComponent(new FontInfo(AssetManager.GetFont("Arial"), 20), "", new Vector2f(), Color.Black));
            textTextComponent.Position=new Vector2f(40+170,40+30);
        }
    }
}