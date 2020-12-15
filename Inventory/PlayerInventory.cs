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

        UIInventory uIInventory;

        PlayerEntity player;

        public PlayerInventory(PlayerEntity player, uint inventorySize=20){
            this.inventorySize=inventorySize;
            uIInventory=new UIInventory(new Vector2f(Utilities.CenterInWindow(DisplayManager.Width, 32+((inventorySize/2)*64)+((inventorySize/2)*10)), 200), inventorySize);
            uIInventory.Visible=false;
            StateMachine.ActiveState.AddGUI(uIInventory);
            slots=new Slot[inventorySize];
            this.player=player;
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

        public void Update(){
            if(!uIInventory.Visible)return;
            for (int i = 0; i < inventorySize; i++)
            {
                Slot slot=slots[i];
                long x=i%(inventorySize/2);
                float y=MathF.Floor(i/(inventorySize/2));
                if(slot!=null){
                    if(InputManager.Hover(new Vector4f(uIInventory.Position+new Vector2f(16+(x*64)+(x*10), 16+(y*64)+(y*10)), new Vector2f(64,64)))){
                        if(InputManager.IsMouseButtonPressed(SFML.Window.Mouse.Button.Left)){
                            if(slot.Item.OnUse(player)){
                                RemoveItem(slot.Item);
                            }
                        }
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