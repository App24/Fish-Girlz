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

        UISlot weaponSlot;
        UISlot helmetSlot, chestSlot;

        public UIInventory(Vector2f position, uint slotAmount) : base(position)
        {
            AddComponent(new TextureComponent(Utilities.CreateTexture(32+((slotAmount/2)*64)+((slotAmount/2)*10)+128,128+(2*64)+(2*10),Color.Green)));
            for (int y = 0; y < 2; y++)
            {
                for (int x = 0; x < slotAmount/2; x++)
                {
                    slots.Add(AddComponent(new UISlot(new Vector2f(16+(x*64)+(x*10), 112+(y*64)+(y*10)))));
                    //slots.Add(new UISlot(new Vector2f(128+(x*64)+(x*10), 128+(y*64)+(y*10)), this));
                }
            }
            weaponSlot=AddComponent(new UISlot(new Vector2f(32+((slotAmount/2)*64)+((slotAmount/2)*10),112+32)));
            helmetSlot=AddComponent(new UISlot(new Vector2f(16,16)));
            chestSlot=AddComponent(new UISlot(new Vector2f(16+64+10, 16)));
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
            weaponSlot.Update();
            helmetSlot.Update();
            chestSlot.Update();
        }

        public void UpdateWeaponSlot(Slot weaponSlot){
            this.weaponSlot.UpdateSlot(weaponSlot);
        }

        public void UpdateHelmetSlot(Slot helmetSlot){
            this.helmetSlot.UpdateSlot(helmetSlot);
        }

        public void UpdateChestSlot(Slot chestSlot){
            this.chestSlot.UpdateSlot(chestSlot);
        }

        public void UpdateSlots(Slot[] slots){
            for (int i = 0; i < slotAmount; i++)
            {
                this.slots[i].UpdateSlot(slots[i]);
            }
        }

        public List<UISlot> Slots=>slots.Clone();

        public UISlot WeaponSlot=>weaponSlot;
        public UISlot HelmetSlot=>helmetSlot;
        public UISlot ChestSlot=>chestSlot;
    }
}