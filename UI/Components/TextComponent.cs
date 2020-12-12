using System;
using SFML.Graphics;
using SFML.System;

namespace Fish_Girlz.UI.Components{
    public class TextComponent : GUIComponent {
        public FontInfo FontInfo {get; private set;}
        public string Text {get; set;}
        public Color TextColor {get; set;}
        public Color OutlineColor {get;set;}
        public float OutlineThickness {get; set;}

        public Vector2f Position{get; set;}

        public FloatRect Bounds{get{
            SFML.Graphics.Text text=new Text(Text, FontInfo.Font, FontInfo.Size);
            FloatRect bounds=text.GetLocalBounds();
            text.Dispose();
            return bounds;
        }}

        public TextComponent(FontInfo fontInfo, string text, Vector2f position, Color color){
            this.FontInfo=fontInfo;
            this.Text=text;
            Position=position;
            TextColor=color;
            OutlineColor=new Color();
            OutlineThickness=0;
        }

        public TextComponent(FontInfo fontInfo, string text, Color color):this(fontInfo, text, new Vector2f(), color){
        }
    }

    public struct FontInfo{
        public Font Font;
        public uint Size;
        
        public FontInfo(Font font, uint size){
            Font=font;
            Size=size;
        }
    }
}