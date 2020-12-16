using System;
using System.Collections.Generic;
using Fish_Girlz.Items;
using Fish_Girlz.Utils;
using Fish_Girlz.Inventory.UI;
using SFML.System;
using Fish_Girlz.Entities;

namespace Fish_Girlz.Inventory{
    public class PlayerInventory {
        Slot[] slots;
        uint inventorySize;

        Slot weaponSlot;
        Slot helmetSlot, chestSlot, leggingsSlot, bootsSlot;

        UIInventory uIInventory;

        PlayerEntity player;

        public PlayerInventory(PlayerEntity player, uint inventorySize=20){
            this.inventorySize=inventorySize;
            uIInventory=new UIInventory(new Vector2f(Utilities.CenterInWindow(DisplayManager.Width, 32+((inventorySize/2)*64)+((inventorySize/2)*10)), 200), inventorySize);
            uIInventory.Visible=false;
            StateMachine.ActiveState.AddGUI(uIInventory);
            slots=new Slot[inventorySize];
            this.player=player;
            weaponSlot=new Slot(null,0);
            helmetSlot=new Slot(null,0);
            chestSlot=new Slot(null,0);
            leggingsSlot=new Slot(null, 0);
            bootsSlot=new Slot(null, 0);
        }

        public int AddItem(Item item, int amount=1){
            if(IsInventoryFull())
                return 1;
            (Slot slot, int index)=GetSlot(item);
            if(slot==null){
                slot=new Slot(item, amount);
            }else{
                return slot.IncreaseAmount(amount);
            }
            slots[index]=slot;
            uIInventory.UpdateSlots(slots);
            return 0;
        }

        public int RemoveItem(Item item, int amount=1){
            if(IsInventoryEmpty())
                return 1;
            (Slot slot, int index)=GetSlot(item);
            if(slot==null) return 1;
            if(slot.DecreaseAmount()<=0) slot=null;
            slots[index]=slot;
            uIInventory.UpdateSlots(slots);
            return 0;
        }

        (Slot, int) GetSlot(Item item){
            Slot slot=null;
            int index=-1;
            for (int i = 0; i < inventorySize; i++)
            {
                if(slots[i]!=null&&slots[i].Item==item){
                    slot=slots[i];
                    index=i;
                    break;
                }
                if(slots[i]==null&&index<0){
                    slot=slots[i];
                    index=i;
                }
            }
            return (slot, index);
        }

        bool ClickSlot(UISlot slot){
            if(InputManager.Hover(new Vector4f(slot.Position+slot.ParentGUI.Position, new Vector2f(64,64)))){
                if(InputManager.IsMouseButtonPressed(SFML.Window.Mouse.Button.Left)){
                    return true;
                }
            }
            return false;
        }

        public void Update(){
            if(!uIInventory.Visible)return;
            for (int i = 0; i < inventorySize; i++)
            {
                Slot slot=slots[i];
                UISlot uISlot=uIInventory.Slots[i];
                if(slot!=null){
                    if(ClickSlot(uISlot)){
                        if(slot.Item.OnUse(player)){
                            RemoveItem(slot.Item);
                        }
                    }
                }
            }
            if(ClickSlot(uIInventory.WeaponSlot)){
                if(weaponSlot.Item!=null){
                    if(AddItem(weaponSlot.Item)<=0){
                        weaponSlot.SetItem(null);
                        uIInventory.UpdateWeaponSlot(weaponSlot);
                    }
                }
            }
            if(ClickSlot(uIInventory.HelmetSlot)){
                if(helmetSlot.Item!=null){
                    if(AddItem(helmetSlot.Item)<=0){
                        helmetSlot.SetItem(null);
                        uIInventory.UpdateHelmetSlot(helmetSlot);
                    }
                }
            }
            if(ClickSlot(uIInventory.ChestSlot)){
                if(chestSlot.Item!=null){
                    if(AddItem(chestSlot.Item)<=0){
                        chestSlot.SetItem(null);
                        uIInventory.UpdateChestSlot(chestSlot);
                    }
                }
            }
            if(ClickSlot(uIInventory.LeggingsSlot)){
                if(leggingsSlot.Item!=null){
                    if(AddItem(leggingsSlot.Item)<=0){
                        leggingsSlot.SetItem(null);
                        uIInventory.UpdateLeggingsSlot(leggingsSlot);
                    }
                }
            }
            if(ClickSlot(uIInventory.BootsSlot)){
                if(bootsSlot.Item!=null){
                    if(AddItem(bootsSlot.Item)<=0){
                        bootsSlot.SetItem(null);
                        uIInventory.UpdateBootsSlot(bootsSlot);
                    }
                }
            }
        }

        public bool IsInventoryFull(){ 
            for (int i = 0; i < inventorySize; i++)
            {
                if(slots[i]==null){
                    return false;
                }
            }
            return true;
        }

        public bool IsInventoryEmpty(){
            for (int i = 0; i < inventorySize; i++)
            {
                if(slots[i]!=null){
                    return false;
                }
            }
            return true;
        }

        public bool SetWeapon(WeaponItem weaponItem){
            if(weaponSlot.Item!=null) return false;
            weaponSlot.SetItem(weaponItem);
            uIInventory.UpdateWeaponSlot(weaponSlot);
            return true;
        }

        public bool SetHelmet(HelmetArmorItem helmetArmorItem){
            if(helmetSlot.Item!=null) return false;
            helmetSlot.SetItem(helmetArmorItem);
            uIInventory.UpdateHelmetSlot(helmetSlot);
            return true;
        }

        public bool SetChestplate(ChestPlateArmorItem chestPlateArmorItem){
            if(chestSlot.Item!=null) return false;
            chestSlot.SetItem(chestPlateArmorItem);
            uIInventory.UpdateChestSlot(chestSlot);
            return true;
        }

        public bool SetLeggings(LeggingsArmorItem leggingsArmorItem){
            if(leggingsSlot.Item!=null) return false;
            leggingsSlot.SetItem(leggingsArmorItem);
            uIInventory.UpdateLeggingsSlot(leggingsSlot);
            return true;
        }

        public bool SetBoots(BootsArmorItem bootsArmorItem){
            if(bootsSlot.Item!=null) return false;
            bootsSlot.SetItem(bootsArmorItem);
            uIInventory.UpdateBootsSlot(bootsSlot);
            return true;
        }

        public override string ToString(){
            return slots.ToStringExtended();
        }

        public void ToggleInventory(){
            uIInventory.Visible=!uIInventory.Visible;
        }

        public void ShowInventory(){
            uIInventory.Visible=true;
        }

        public void HideInventory(){
            uIInventory.Visible=false;
        }
    }
}