using System;

namespace Fish_Girlz.Inventory.Items{
    public abstract class Item {
        public int ID{get;}
        public string Name{get;}
        public uint MaxStack{get;}

        private static int currentID;

        public static BasicItem POTION=new BasicItem("Potion");
        public static BasicItem SWORD=new BasicItem("Sword",1);
        public static BasicItem BOW=new BasicItem("Bow",1);
        public static BasicItem SPEAR=new BasicItem("Spear",1);
        public static BasicItem FOOD=new BasicItem("FOOD");
        
        public Item(string name, uint maxStack=64){
            ID=currentID;
            currentID++;
            Name=name;
            MaxStack=maxStack;
        }
    }
}