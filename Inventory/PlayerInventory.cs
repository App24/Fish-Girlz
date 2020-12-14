using System;
using System.Collections.Generic;
using Fish_Girlz.Inventory.Items;
using Fish_Girlz.Utils;
using Fish_Girlz.Inventory.UI;
using SFML.System;

namespace Fish_Girlz.Inventory{
    public class PlayerInventory {
        Slot[] slots;
        uint inventorySize;

        UIInventory uIInventory;

        public PlayerInventory(uint inventorySize=20){
            this.inventorySize=inventorySize;
            uIInventory=new UIInventory(new Vector2f(Utilities.CenterInWindow(DisplayManager.Width, 32+((inventorySize/2)*64)+((inventorySize/2)*10)), 200), inventorySize);
            uIInventory.Visible=false;
            StateMachine.ActiveState.AddGUI(uIInventory);
            slots=new Slot[inventorySize];
            for (int i = 0; i < inventorySize; i++)
            {
                slots[i]=new Slot(null,0);
            }
        }

        public bool AddItem(Item item, uint amount=1){
            if(IsInventoryFull())
                return false;
            (Slot slot, int index)=GetSlot(item);
            if(slot.Item==null){
                slot=new Slot(item, amount);
            }else{
                if(!slot.IncreaseAmount(amount)) return false;
            }
            slots[index]=slot;
            uIInventory.UpdateSlots(slots);
            return true;
        }

        (Slot, int) GetSlot(Item item){
            Slot slot=null;
            int index=-1;
            for (int i = 0; i < inventorySize; i++)
            {
                if(slots[i].Item==item){
                    slot=slots[i];
                    index=i;
                    break;
                }
                if(slots[i].Item==null){
                    slot=slots[i];
                    index=i;
                    break;
                }
            }
            return (slot, index);
        }

        public bool IsInventoryFull(){ 
            for (int i = 0; i < inventorySize; i++)
            {
                if(slots[i].Item==null){
                    return false;
                }
            }
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