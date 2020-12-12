using System;
using Fish_Girlz.Utils;
using Fish_Girlz.UI;
using Fish_Girlz.UI.Components;
using SFML.System;
using SFML.Graphics;

namespace Fish_Girlz.Inventory.UI{
    public class UIInventory : UpdatableGUI
    {
        public UIInventory(Vector2f position) : base(position)
        {
            AddComponent(new TextureComponent(Utilities.CreateTexture(512,512,Color.Green)));
            for (int x = 0; x < 2; x++)
            {
                for (int y = 0; y < 2; y++)
                {
                    AddComponent(new TextureComponent(Utilities.CreateTexture(64,64, Color.White))).Position=new Vector2f(128+(x*64)+(x*10), 128+(y*64)+(y*10));
                }
            }
        }

        public override void Update()
        {

        }
    }
}