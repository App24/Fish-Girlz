using System;
using SFML.System;
using Fish_Girlz.UI.Components;
using Fish_Girlz.Misc;
using SFML.Graphics;

namespace Fish_Girlz.UI{
    public class UISelectableText : UpdatableGUI
    {
        public bool Selected{get;set;}

        public TextComponent TextComponent{get;}

        private TextComponent leftSelect, rightSelect;

        public EventHandler OnSelect;
        public FloatRect Bounds{get{return TextComponent.Bounds;}}
        public FloatRect ActualBounds{get{return new FloatRect(leftSelect.Bounds.Left, leftSelect.Bounds.Top, leftSelect.Bounds.Width+leftSelect.Bounds.Width+(leftSelect.FontInfo.CharacterSize/2)+TextComponent.Bounds.Width+leftSelect.Bounds.Width+(leftSelect.FontInfo.CharacterSize), leftSelect.Bounds.Height);}}

        public UISelectableText(FontInfo fontInfo, string text, Vector2f position) : base(position)
        {
            leftSelect=AddComponent(new TextComponent(fontInfo, new Vector2f()));
            leftSelect.Text=">";
            TextComponent=AddComponent(new TextComponent(fontInfo, new Vector2f(leftSelect.Bounds.Width+(fontInfo.CharacterSize/2), 0)));
            TextComponent.Text=text;
            rightSelect=AddComponent(new TextComponent(fontInfo, new Vector2f(TextComponent.Bounds.Width+leftSelect.Bounds.Width+(fontInfo.CharacterSize), 0)));
            rightSelect.Text="<";
            leftSelect.Visible=false;
            rightSelect.Visible=false;
        }

        public override void Update()
        {
            leftSelect.Visible=Selected;
            rightSelect.Visible=Selected;
        }
    }
}