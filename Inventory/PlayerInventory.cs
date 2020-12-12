using System;
using System.Collections.Generic;
using Fish_Girlz.Inventory.Items;
using Fish_Girlz.Utils;

namespace Fish_Girlz.Inventory{
    public class PlayerInventory {
        List<Slot> slots=new List<Slot>();
        int inventorySize;

        public PlayerInventory(int inventorySize=4){
            this.inventorySize=inventorySize;
        }

        public bool AddItem(Item item, uint amount=1){
            if(slots.Count>=inventorySize)
                return false;
            Slot slot=slots.Find(delegate(Slot _slot){if(_slot.Item==item)return true; return false;});
            if(slot==null){
                slot=new Slot(item, amount);
            }else{
                slot.Amount+=amount;
            }
            slots.AddOrReplace(slot);
            return true;
        }

        public override string ToString(){
            return slots.ToStringExtended();
        }
    }
}