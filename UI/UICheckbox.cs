using System;
using Fish_Girlz.UI.Components;
using Fish_Girlz.Utils;
using SFML.System;
using SFML.Graphics;

namespace Fish_Girlz.UI{
    public class UICheckbox : UpdatableGUI
    {
        ClickComponent clickComponent;
        TextureComponent checkTextureComponent;
        public bool Checked{get;private set;}

        public UICheckbox(Vector2u size, Vector2f position, bool check=false) : base(position)
        {
            clickComponent=AddComponent(new ClickComponent(new Vector4f(position, (Vector2f)size)));
            AddComponent(new TextureComponent(Utilities.CreateTexture(size, Color.White)));
            uint x=size.X/5;
            uint y=size.Y/5;
            checkTextureComponent=AddComponent(new TextureComponent(Utilities.CreateTexture(size.X-x, size.Y-y, Color.Black)));
            checkTextureComponent.Position=new Vector2f(x/2f,y/2f);
            checkTextureComponent.Visible=check;
            Checked=check;
        }

        public override void Update()
        {
            if(clickComponent.OnClick()){
                Checked=!Checked;
            }
            checkTextureComponent.Visible=Checked;
        }
    }
}