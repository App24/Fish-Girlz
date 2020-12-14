using System;
using SFML.Graphics;
using Fish_Girlz.Utils;

namespace Fish_Girlz.Inventory.Items{
    public abstract class Item {
        public int ID{get;}
        public string Name{get;}
        public uint MaxStack{get;}
        public Texture ItemTexture{get;}

        private static int currentID;

        public static BasicItem POTION=new BasicItem("Potion", Utilities.CreateTexture(64,64,Color.Blue));
        public static BasicItem SWORD=new BasicItem("Sword", Utilities.CreateTexture(64,64,Color.Red),1);
        public static BasicItem BOW=new BasicItem("Bow", Utilities.CreateTexture(64,64,Color.Cyan),1);
        
        public Item(string name, Texture itemTexture, uint maxStack=64){
            ID=currentID;
            currentID++;
            Name=name;
            MaxStack=maxStack;
            ItemTexture=itemTexture;
        }
    }
}