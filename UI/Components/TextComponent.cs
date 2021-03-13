using System;
using System.Collections.Generic;
using SFML.System;
using SFML.Graphics;
using Fish_Girlz.Misc;

namespace Fish_Girlz.UI.Components{
    public class TextComponent : GUIPositionalComponent
    {
        public FontInfo FontInfo{get;}

        public string Text{get;set;}
        public Color FillColor{get;set;} = Color.White;
        public Color OutlineColor{get;set;}=Color.Black;
        public float OutlineThickness{get;set;}=0;
        public Text.Styles Style{get;set;}=SFML.Graphics.Text.Styles.Regular;


        public FloatRect Bounds{get{
            SFML.Graphics.Text text=new Text(Text, FontInfo.Font, FontInfo.CharacterSize);
            FloatRect bounds=text.GetLocalBounds();
            text.Dispose();
            return bounds;
        }}

        public TextComponent(FontInfo fontInfo, Vector2f offset) : base(offset)
        {
            FontInfo=fontInfo;
            Text="";
        }
    }
}