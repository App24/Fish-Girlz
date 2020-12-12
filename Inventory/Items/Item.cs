using System;

namespace Fish_Girlz.Inventory.Items{
    public abstract class Item {
        public int ID{get;}
        public string Name{get;}

        public static BasicItem ITEM_TEST=new BasicItem(1, "Test");
        
        public Item(int id, string name){
            ID=id;
            Name=name;
        }
    }
}