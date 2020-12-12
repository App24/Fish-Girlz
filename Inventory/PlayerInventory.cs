using System;
using System.Collections.Generic;
using Fish_Girlz.Inventory.Items;
using Fish_Girlz.Utils;
using Fish_Girlz.Inventory.UI;
using SFML.System;

namespace Fish_Girlz.Inventory{
    public class PlayerInventory {
        List<Slot> slots=new List<Slot>();
        int inventorySize;

        UIInventory uIInventory;

        public PlayerInventory(int inventorySize=4){
            this.inventorySize=inventorySize;
            uIInventory=new UIInventory(new Vector2f());
            uIInventory.Visible=false;
            StateMachine.ActiveState.AddGUI(uIInventory);
        }

        public bool AddItem(Item item, uint amount=1){
            if(slots.Count>=inventorySize)
                return false;
            Slot slot=slots.FindLast(delegate(Slot _slot){if(_slot.Item==item)return true; return false;});
            if(slot==null){
                slot=new Slot(item, amount);
            }else{
                if(!slot.IncreaseAmount(amount)) return false;
            }
            slots.AddOrReplace(slot);
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