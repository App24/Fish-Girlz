using System;
using Fish_Girlz.Items;

namespace Fish_Girlz.Inventory{
    public class Slot {
        public int Amount{get;private set;}
        public Item Item{get;private set;}

        public Slot(Item item, int amount){
            Item=item;
            Amount=amount;
        }

        public void SetItem(Item item){
            Item=item;
            Amount=item==null?0:1;
        }

        public override string ToString(){
            return $"{Item.Name}: {Amount}";
        }

        public int IncreaseAmount(int amount=1){
            Amount+=amount;
            int remain=Math.Max(Item.MaxStack-Amount,0);
            Amount=Math.Clamp(Amount, 0, Item.MaxStack);
            return remain;
        }

        public int DecreaseAmount(int amount=1){
            Amount-=amount;
            int remain=Math.Max(Amount-Item.MaxStack,0);
            Amount=Math.Clamp(Amount, 0, Item.MaxStack);
            return remain;
        }
    }
}