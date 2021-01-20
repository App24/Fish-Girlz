using System;
using Fish_Girlz.UI.Components;
using Fish_Girlz.Utils;
using SFML.Graphics;
using SFML.System;

namespace Fish_Girlz.UI{
    public class UIText : GUI
    {
        private TextComponent textComponent;

        public UIText(FontInfo fontInfo, string text, Color color, Vector2f position) : base(position)
        {
            textComponent=AddComponent(new TextComponent(fontInfo, text, new Vector2f(0,0), color));
        }

        public string Text{
            get{
                return textComponent.Text;
            }
            set{
                textComponent.Text=value;
            }
        }

        public Color TextColor{
            get{
                return textComponent.TextColor;
            }
            set{
                textComponent.TextColor=value;
            }
        }

        
        public Color OutlineColor {
            get{
                return textComponent.OutlineColor;
            }
            set{
                textComponent.OutlineColor=value;
            }
        }
        public float OutlineThickness {
            get{
                return textComponent.OutlineThickness;
            }
            set{
                textComponent.OutlineThickness=value;
            }
        }
    }
}