using System;
using System.Collections.Generic;
using Fish_Girlz.Items;
using Fish_Girlz.Utils;
using Fish_Girlz.Inventory.UI;
using SFML.System;
using Fish_Girlz.Entities;
using Fish_Girlz.Systems;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Entities")]
namespace Fish_Girlz.Inventory{
    public class PlayerInventory {
        Slot[] slots;
        uint inventorySize;

        Slot ringSlot, necklaceSlot;
        Slot helmetSlot, chestplateSlot, leggingsSlot, bootsSlot;

        UIInventory uIInventory;

        PlayerEntity player;

        public PlayerInventory(PlayerEntity player, uint inventorySize=20){
            this.inventorySize=inventorySize;
            uIInventory=new UIInventory(new Vector2f(Utilities.CenterInWindow(WindowSize.WIDTH, 32+((inventorySize/2)*64)+((inventorySize/2)*10)+192), 200), inventorySize);
            uIInventory.SetVisible(false);
            slots=new Slot[inventorySize];
            this.player=player;

            ringSlot=new Slot(null,0, typeof(RingItem));
            necklaceSlot=new Slot(null, 0, typeof(NecklaceItem));
            
            helmetSlot=new Slot(null,0, typeof(HelmetArmorItem));
            chestplateSlot=new Slot(null,0, typeof(ChestPlateArmorItem));
            leggingsSlot=new Slot(null, 0, typeof(LeggingsArmorItem));
            bootsSlot=new Slot(null, 0, typeof(BootsArmorItem));
        }

        internal void Init(){
            StateMachine.ActiveState.AddGUI(uIInventory);
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
            if(ClickSlot(uIInventory.RingSlot)){
                if(ringSlot.Item!=null){
                    if(AddItem(ringSlot.Item)<=0){
                        SetItem(null, ItemSlot.Ring);
                    }
                }
            }
            if(ClickSlot(uIInventory.NecklaceSlot)){
                if(necklaceSlot.Item!=null){
                    if(AddItem(necklaceSlot.Item)<=0){
                        SetItem(null, ItemSlot.Necklace);
                    }
                }
            }

            if(ClickSlot(uIInventory.HelmetSlot)){
                if(helmetSlot.Item!=null){
                    if(AddItem(helmetSlot.Item)<=0){
                        SetItem(null, ItemSlot.Helmet);
                    }
                }
            }
            if(ClickSlot(uIInventory.ChestplateSlot)){
                if(chestplateSlot.Item!=null){
                    if(AddItem(chestplateSlot.Item)<=0){
                        SetItem(null, ItemSlot.Chestplate);
                    }
                }
            }
            if(ClickSlot(uIInventory.LeggingsSlot)){
                if(leggingsSlot.Item!=null){
                    if(AddItem(leggingsSlot.Item)<=0){
                        SetItem(null, ItemSlot.Leggings);
                    }
                }
            }
            if(ClickSlot(uIInventory.BootsSlot)){
                if(bootsSlot.Item!=null){
                    if(AddItem(bootsSlot.Item)<=0){
                        SetItem(null, ItemSlot.Boots);
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

        public bool SetItem(Item item, ItemSlot itemSlot){
            switch (itemSlot)
            {
                case ItemSlot.Ring:
                    if(!ringSlot.SetItem(item)) return false;
                    uIInventory.UpdateRingSlot(ringSlot);
                    return true;
                case ItemSlot.Necklace:
                    if(!necklaceSlot.SetItem(item)) return false;
                    uIInventory.UpdateNecklaceSlot(necklaceSlot);
                    return true;
                case ItemSlot.Helmet:
                    if(!helmetSlot.SetItem(item)) return false;
                    uIInventory.UpdateHelmetSlot(helmetSlot);
                    return true;
                case ItemSlot.Chestplate:
                    if(!chestplateSlot.SetItem(item)) return false;
                    uIInventory.UpdateChestSlot(chestplateSlot);
                    return true;
                case ItemSlot.Leggings:
                    if(!leggingsSlot.SetItem(item)) return false;
                    uIInventory.UpdateLeggingsSlot(leggingsSlot);
                    return true;
                case ItemSlot.Boots:
                    if(!bootsSlot.SetItem(item)) return false;
                    uIInventory.UpdateBootsSlot(bootsSlot);
                    return true;
            }
            return false;
        }

        public override string ToString(){
            return slots.ToStringExtended();
        }

        public void ToggleInventory(){
            uIInventory.SetVisible(!uIInventory.Visible);
        }

        public void ShowInventory(){
            uIInventory.SetVisible(true);
        }

        public void HideInventory(){
            uIInventory.SetVisible(false);
        }
    }

    public enum ItemSlot{
        Ring, Necklace, Helmet, Chestplate, Leggings, Boots
    }
}