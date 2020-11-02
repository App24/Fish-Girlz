using System;
using SFML.Graphics;
using SFML.System;

namespace Fish_Girlz.UI.Components{
    public class TextComponent : GUIComponent {
        public Font Font {get; private set;}
        public string Text {get; set;}
        public Color TextColor {get;private set;}

        public Vector2f Position{get; set;}

        public TextComponent(Font font, string text, Vector2f position, Color color):base(3){
            this.Font=font;
            this.Text=text;
            Position=position;
            TextColor=color;
        }
    }
}