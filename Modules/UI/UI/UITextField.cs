using System;
using SFML.System;
using SFML.Graphics;
using SFML.Window;
using Fish_Girlz.UI.Components;
using Fish_Girlz.Utils;
using Fish_Girlz.Systems;

namespace Fish_Girlz.UI{
    public class UITextField : UpdatableGUI
    {
        ClickComponent clickComponent;
        TextComponent textComponent;
        TextureComponent cursorComponent;
        public bool Focused{get;set;}
        public string Text{get;private set;}
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
            return CursorPosition.Clamp(0, Size.X-10);
        }}

        public UITextField(Vector2f position, Vector2u size) : base(position)
        {
            Size=size;
            AddComponent(new TextureComponent(Utilities.CreateTexture(Size.X+5,Size.Y+5, Color.White.Divide(2))));
            AddComponent(new TextureComponent(Utilities.CreateTexture(Size.X, Size.Y, Color.White))).Position=new Vector2f(2.5f,2.5f);
            textComponent=AddComponent(new TextComponent(AssetManager.GetObject<FontInfo>("Input Font"), "", new Vector2f(), Color.Black));
            clickComponent=AddComponent(new ClickComponent());
            cursorComponent=AddComponent(new TextureComponent(Utilities.CreateTexture(3,40, Color.Black)));
            Focused=false;
            Text="";
            CursorIndex=0;
            blinkClock=new Clock();
        }

        public void Focus(){
            Focused=true;
            InputManager.SetTyping(true);
        }

        public void Unfocus(){
            Focused=false;
            InputManager.SetTyping(false);
        }

        public void SetText(string text){
            Text=text;
            textComponent.Text=Text;
            CursorIndex=Text.Length;
        }

        public override void SetVisible(bool value)
        {
            base.SetVisible(value);
            if(!value)
            Unfocus();
        }

        public override void Update()
        {
            if(clickComponent.onHover(new Vector4f(Position, new Vector2f(Size.X+5, Size.Y+5)))){
                DisplayManager.Window.SetMouseCursor(new Cursor(Cursor.CursorType.Text));
            }else{
                DisplayManager.Window.SetMouseCursor(new Cursor(Cursor.CursorType.Arrow));
            }
            if(clickComponent.OnClick(new Vector4f(Position, new Vector2f(Size.X+5, Size.Y+5)))){
                Focus();
            }else if(!clickComponent.onHover(new Vector4f(Position, new Vector2f(Size.X+5, Size.Y+5)))){
                if(InputManager.IsMouseButtonPressedNoUI(Mouse.Button.Left)){
                    Unfocus();
                }
            }
            if(Focused){
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
                            if(Text.Length>0&&CursorIndex>0){
                                Text=Text.Remove(CursorIndex-1, 1);
                                CursorIndex-=1;
                            }
                            break;
                        case "\bd":
                            if(Text.Length>=1&&(CursorIndex>=0 && CursorIndex<Text.Length))
                                Text=Text.Remove(CursorIndex, 1);
                            break;
                        case "home":
                        case "dArrow":
                            CursorIndex=0;
                            ignoreCursor=true;
                            break;
                        case "uArrow":
                        case "end":
                            CursorIndex=Text.Length;
                            ignoreCursor=true;
                            break;
                        case "lArrow":
                            CursorIndex-=1;
                            if(CursorIndex<0) CursorIndex=0;
                            ignoreCursor=true;
                            break;
                        case "rArrow":
                            CursorIndex+=1;
                            if(CursorIndex>Text.Length) CursorIndex=Text.Length;
                            ignoreCursor=true;
                            break;
                        default:
                            if(visibility==CharacterVisibility.Visible){
                                Text=Text.Insert(CursorIndex, input);
                                CursorIndex+=1;
                            }
                            break;
                    }
                    if(!ignoreCursor){
                        if(CursorIndex>Text.Length/*||(typedText.Length>textComponent.Text.Length&&CursorIndex>=textComponent.Text.Length)*/)
                            CursorIndex=Text.Length;
                    }
                    textComponent.Text=Text;
                }
                cursorComponent.Position=new Vector2f(drawCursorPosition+cursorComponent.Texture.Size.X+5, (Size.Y-40)/1.5f);
            }else{
                cursorComponent.Texture.SetColor(new Color(0,0,0,0));
            }

        }
    }
}