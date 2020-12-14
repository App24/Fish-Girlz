using System;
using System.Collections.Generic;
using Fish_Girlz.Utils;
using Fish_Girlz.UI;
using Fish_Girlz.UI.Components;
using SFML.System;
using SFML.Graphics;

namespace Fish_Girlz.Inventory.UI{
    public class UIInventory : UpdatableGUI
    {   
        List<UISlot> slots=new List<UISlot>();
        uint slotAmount;

        public UIInventory(Vector2f position, uint slotAmount) : base(position)
        {
            AddComponent(new TextureComponent(Utilities.CreateTexture(512,512,Color.Green)));
            for (int y = 0; y < slotAmount/2; y++)
            {
                for (int x = 0; x < slotAmount/2; x++)
                {
                    slots.Add(AddComponent(new UISlot(new Vector2f(128+(x*64)+(x*10), 128+(y*64)+(y*10)))));
                    //slots.Add(new UISlot(new Vector2f(128+(x*64)+(x*10), 128+(y*64)+(y*10)), this));
                }
            }
            this.slotAmount=slotAmount;
        }

        public override void Update()
        {
            foreach (UISlot slot in slots)
            {
                slot.Update();
            }
        }

        public void UpdateSlots(Slot[] slots){
            for (int i = 0; i < slotAmount; i++)
            {
                this.slots[i].UpdateSlot(slots[i]);
            }
        }
    }
}