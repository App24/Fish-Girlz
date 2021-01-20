using System;
using Fish_Girlz.Items;
using Fish_Girlz.Utils;

namespace Fish_Girlz.Inventory{
    public class Slot {
        public int Amount{get;private set;}
        public Item Item{get;private set;}
        public Type AllowedItemType{get;}

        public Slot(Item item, int amount):this(item, amount, typeof(Item)){
        }

        public Slot(Item item, int amount, Type allowedItemType){
            Item=item;
            Amount=amount;
            AllowedItemType=allowedItemType;
        }

        public bool SetItem(Item item){
            if(item==null||(item.GetType().IsSubclassOf(AllowedItemType))){
                Item=item;
                Amount=item==null?0:1;
                return true;
            }
            return false;
        }

        public override string ToString(){
            return $"{Item.Name}: {Amount}";
        }

        public int IncreaseAmount(int amount=1){
            Amount+=amount;
            int remain=Math.Max(Item.MaxStack-Amount,0);
            Amount=Amount.Clamp(0, Item.MaxStack);
            return remain;
        }

        public int DecreaseAmount(int amount=1){
            Amount-=amount;
            int remain=Math.Max(Amount-Item.MaxStack,0);
            Amount=Amount.Clamp(0, Item.MaxStack);
            return remain;
        }
    }
}