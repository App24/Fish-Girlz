using System;
using Fish_Girlz.Inventory.Items;

namespace Fish_Girlz.Inventory{
    public class Slot {
        public uint Amount{get;set;}
        public Item Item{get;}

        public Slot(Item item, uint amount){
            Item=item;
            Amount=amount;
        }

        public override string ToString(){
            return $"{Item.Name}: {Amount}";
        }
    }
}