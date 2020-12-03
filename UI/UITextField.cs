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
        bool focused;
        string typedText;
        int cursorIndex=0;
        public Vector2u Size {get;}

        public UITextField(Vector2f position) : base(position)
        {
            Size=new Vector2u(300,50);
            AddComponent(new TextureComponent(Utilities.CreateTexture(Size.X+5,Size.Y+5, Color.White.Divide(2))));
            AddComponent(new TextureComponent(Utilities.CreateTexture(Size.X, Size.Y, Color.White))).Pos=new Vector2f(2.5f,2.5f);
            textComponent=AddComponent(new TextComponent((FontInfo)AssetManager.GetObject("Input Font"), "", new Vector2f(), Color.Black));
            clickComponent=AddComponent(new ClickComponent(new Vector4f(position, new Vector2f(Size.X+5, Size.Y+5))));
            focused=false;
            typedText="";
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
            }else if(InputManager.IsMouseButtonPressed(Mouse.Button.Left)&&!clickComponent.onHover()){
                focused=false;
            }
            if(focused){
                (string input, CharacterVisibility visibility)=InputManager.CheckForInput();
                bool ignoreCursor=false;
                switch(input){
                    case "\b":
                        if(typedText.Length>0&&cursorIndex>0)
                            typedText=typedText.Remove(cursorIndex-1, 1);
                        break;
                    case "\bd":
                        if(typedText.Length>1&&(cursorIndex>=0 && cursorIndex<typedText.Length))
                            typedText=typedText.Remove(cursorIndex, 1);
                        break;
                    case "dArrow":
                        cursorIndex=0;
                        ignoreCursor=true;
                        break;
                    case "end":
                        cursorIndex=typedText.Length;
                        ignoreCursor=true;
                        break;
                    case "lArrow":
                        cursorIndex-=1;
                        if(cursorIndex<0) cursorIndex=0;
                        ignoreCursor=true;
                        break;
                    default:
                        if(visibility==CharacterVisibility.Visible)
                            typedText+=input;
                        break;
                }
                if(!ignoreCursor)
                    cursorIndex=typedText.Length;
                textComponent.Text=typedText;
            }
        }
    }
}