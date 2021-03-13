using Fish_Girlz.UI.Components;
using Fish_Girlz.Misc;
using SFML.System;

namespace Fish_Girlz.UI{
    public class UIText : GUI
    {
        public TextComponent TextComponent{get;}

        public UIText(FontInfo fontInfo, string text, Vector2f position) : base(position)
        {
            TextComponent=AddComponent(new TextComponent(fontInfo, new Vector2f()));
            TextComponent.Text=text;
        }
    }
}