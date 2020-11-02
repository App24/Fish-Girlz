using System;
using Fish_Girlz.UI.Components;
using Fish_Girlz.Utils;
using SFML.Graphics;
using SFML.System;

namespace Fish_Girlz.UI{
    public class UIText : GUI
    {
        private TextComponent textComponent;

        public UIText(string text, Color color, Vector2f position) : base(position)
        {
            textComponent=AddComponent(new TextComponent(AssetManager.GetFont("Arial"), text, new Vector2f(0,0), color));
        }

        public string Text{
            get{
                return textComponent.Text;
            }
            set{
                textComponent.Text=value;
            }
        }
    }
}