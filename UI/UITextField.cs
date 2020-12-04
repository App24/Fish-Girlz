using System;
using SFML.System;
using SFML.Graphics;
using SFML.Window;
using Fish_Girlz.UI.Components;
using Fish_Girlz.Utils;

namespace Fish_Girlz.UI{
    public class UITextField : UpdatableGUI
    {
        ClickComponent clickComponent;
        TextComponent textComponent;
        TextureComponent cursorComponent;
        bool focused;
        string typedText;
        public int CursorIndex{get; private set;}
        public Vector2u Size {get;}
        Clock blinkClock;
        bool displayCursor;

        public float CursorPosition{get{
            Text text=new Text(textComponent.Text, textComponent.FontInfo.Font, textComponent.FontInfo.Size);
            Vector2f currentPos=text.FindCharacterPos((uint)Math.Max(CursorIndex-1,0));
            float width=currentPos.X;
            if(CursorIndex>0){
                Text charText=new Text(textComponent.Text[CursorIndex-1].ToString(), textComponent.FontInfo.Font);
                width=currentPos.X+charText.GetLocalBounds().Width;
            }
            return width;
        }}

        float drawCursorPosition{get{
            return CursorPosition;
        }}

        public UITextField(Vector2f position) : base(position)
        {
            Size=new Vector2u(300,50);
            AddComponent(new TextureComponent(Utilities.CreateTexture(Size.X+5,Size.Y+5, Color.White.Divide(2))));
            AddComponent(new TextureComponent(Utilities.CreateTexture(Size.X, Size.Y, Color.White))).Pos=new Vector2f(2.5f,2.5f);
            textComponent=AddComponent(new TextComponent((FontInfo)AssetManager.GetObject("Input Font"), "", new Vector2f(), Color.Black));
            clickComponent=AddComponent(new ClickComponent(new Vector4f(position, new Vector2f(Size.X+5, Size.Y+5))));
            cursorComponent=AddComponent(new TextureComponent(Utilities.CreateTexture(3,40, Color.Black)));
            focused=false;
            typedText="";
            CursorIndex=0;
            blinkClock=new Clock();
        }

        public override void Update()
        {
            if(clickComponent.onHover()){
                DisplayManager.Window.SetMouseCursor(new Cursor(Cursor.CursorType.Text));
            }else{
                DisplayManager.Window.SetMouseCursor(new Cursor(Cursor.CursorType.Arrow));
            }
            if(clickComponent.OnClick()){
                focused=true;
            }else if(!clickComponent.onHover()){
                if(InputManager.IsMouseButtonPressed(Mouse.Button.Left))
                focused=false;
            }
            if(focused){
                if(blinkClock.ElapsedTime.AsMilliseconds()>=500){
                    if(displayCursor){
                        cursorComponent.Texture.SetColor(new Color(0,0,0,0));
                    }else{
                        cursorComponent.Texture.SetColor(Color.Black);
                    }
                    displayCursor=!displayCursor;
                    blinkClock.Restart();
                }
                
                (string input, CharacterVisibility visibility)=InputManager.CheckForInput();
                if(!string.IsNullOrEmpty(input)){
                    bool ignoreCursor=false;
                    switch(input){
                        case "\b":
                            if(typedText.Length>0&&CursorIndex>0)
                                typedText=typedText.Remove(CursorIndex-1, 1);
                            break;
                        case "\bd":
                            if(typedText.Length>1&&(CursorIndex>=0 && CursorIndex<typedText.Length))
                                typedText=typedText.Remove(CursorIndex, 1);
                            break;
                        case "home":
                        case "dArrow":
                            CursorIndex=0;
                            ignoreCursor=true;
                            break;
                        case "uArrow":
                        case "end":
                            CursorIndex=typedText.Length;
                            ignoreCursor=true;
                            break;
                        case "lArrow":
                            CursorIndex-=1;
                            if(CursorIndex<0) CursorIndex=0;
                            ignoreCursor=true;
                            break;
                        case "rArrow":
                            CursorIndex+=1;
                            if(CursorIndex>typedText.Length) CursorIndex=typedText.Length;
                            ignoreCursor=true;
                            break;
                        default:
                            if(visibility==CharacterVisibility.Visible)
                                typedText+=input;
                            break;
                    }
                    if(!ignoreCursor)
                        CursorIndex=typedText.Length;
                    textComponent.Text=typedText;
                }
                cursorComponent.Pos=new Vector2f(drawCursorPosition+cursorComponent.Texture.Size.X+5, (Size.Y-40)/1.5f);
            }else{
                cursorComponent.Texture.SetColor(new Color(0,0,0,0));
            }

        }
    }
}