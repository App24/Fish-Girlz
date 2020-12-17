using System;
using System.Collections.Generic;
using Fish_Girlz.Utils;
using Fish_Girlz.UI;
using Fish_Girlz.UI.Components;
using SFML.System;
using SFML.Graphics;
using Fish_Girlz.Entities;

namespace Fish_Girlz.Inventory.UI{
    public class UIInventory : UpdatableGUI
    {   
        List<UISlot> slots=new List<UISlot>();
        uint slotAmount;

        UISlot ringSlot, necklaceSlot;
        UISlot helmetSlot, chestplateSlot, leggingsSlot, bootsSlot;

        public UIInventory(Vector2f position, uint slotAmount) : base(position)
        {
            AddComponent(new TextureComponent(Utilities.CreateTexture(32+((slotAmount/2)*64)+((slotAmount/2)*10)+192,256+(2*64)+(2*10),Color.Green)));
            for (int y = 0; y < 2; y++)
            {
                for (int x = 0; x < slotAmount/2; x++)
                {
                    slots.Add(AddComponent(new UISlot(new Vector2f(16+(x*64)+(x*10), 16+(2*64)+(2*10)+(y*64)+(y*10)))));
                    //slots.Add(new UISlot(new Vector2f(128+(x*64)+(x*10), 128+(y*64)+(y*10)), this));
                }
            }
            ringSlot=AddComponent(new UISlot(new Vector2f(32+((slotAmount/2)*64)+((slotAmount/2)*10),16+(2*64)+(2*10))));
            necklaceSlot=AddComponent(new UISlot(new Vector2f(32+((slotAmount/2)*64)+((slotAmount/2)*10),16+(1*64)+(1*10))));
            
            helmetSlot=AddComponent(new UISlot(new Vector2f(32+((slotAmount/2)*64)+((slotAmount/2)*10)+74,16)));
            chestplateSlot=AddComponent(new UISlot(new Vector2f(32+((slotAmount/2)*64)+((slotAmount/2)*10)+74, 16+(1*64)+(1*10))));
            leggingsSlot=AddComponent(new UISlot(new Vector2f(32+((slotAmount/2)*64)+((slotAmount/2)*10)+74, 16+(2*64)+(2*10))));
            bootsSlot=AddComponent(new UISlot(new Vector2f(32+((slotAmount/2)*64)+((slotAmount/2)*10)+74, 16+(3*64)+(3*10))));
            this.slotAmount=slotAmount;
        }

        public override void Update()
        {
            for (int i = 0; i < slotAmount; i++)
            {
                if(slots[i]!=null){
                    slots[i].Update();
                }
            }
            ringSlot.Update();
            necklaceSlot.Update();

            helmetSlot.Update();
            chestplateSlot.Update();
            leggingsSlot.Update();
            bootsSlot.Update();
        }

        public void UpdateRingSlot(Slot ringSlot){
            this.ringSlot.UpdateSlot(ringSlot);
        }

        public void UpdateNecklaceSlot(Slot necklaceSlot){
            this.necklaceSlot.UpdateSlot(necklaceSlot);
        }

        public void UpdateHelmetSlot(Slot helmetSlot){
            this.helmetSlot.UpdateSlot(helmetSlot);
        }

        public void UpdateChestSlot(Slot chestSlot){
            this.chestplateSlot.UpdateSlot(chestSlot);
        }

        public void UpdateLeggingsSlot(Slot leggingsSlot){
            this.leggingsSlot.UpdateSlot(leggingsSlot);
        }

        public void UpdateBootsSlot(Slot bootsSlot){
            this.bootsSlot.UpdateSlot(bootsSlot);
        }

        public void UpdateSlots(Slot[] slots){
            for (int i = 0; i < slotAmount; i++)
            {
                this.slots[i].UpdateSlot(slots[i]);
            }
        }

        public List<UISlot> Slots=>slots.Clone();

        public UISlot RingSlot=>ringSlot;
        public UISlot NecklaceSlot=>necklaceSlot;

        public UISlot HelmetSlot=>helmetSlot;
        public UISlot ChestplateSlot=>chestplateSlot;
        public UISlot LeggingsSlot=>leggingsSlot;
        public UISlot BootsSlot=>bootsSlot;
    }
}