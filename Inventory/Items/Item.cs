using System;
using System.Collections.Generic;
using SFML.Graphics;
using Fish_Girlz.Utils;
using Fish_Girlz.Art;

namespace Fish_Girlz.Inventory.Items{
    public abstract class Item {
        public int ID{get;}
        public string Name{get;}
        public uint MaxStack{get;}
        public SpriteInfo Sprite{get;}
        public IntRect CollisionBounds{get; protected set;}

        static List<Item> items=new List<Item>();

        public static PotionItem HEALTH_POTION=new PotionItem("Health", Color.Red);
        public static BasicItem SWORD=new BasicItem("Sword", new SpriteInfo(Utilities.CreateTexture(64,64,Color.Red), new IntRect(0,0,64,64)),1);
        public static BasicItem BOW=new BasicItem("Bow", new SpriteInfo(Utilities.CreateTexture(64,64,Color.Cyan), new IntRect(0,0,64,64)),1);
        public static PotionItem SPEED_POTION=new PotionItem("Speed", Color.Green);
        
        public Item(string name, SpriteInfo sprite, uint maxStack=64){
            ID=items.Count;
            Name=name;
            MaxStack=maxStack;
            Sprite=sprite;
            CollisionBounds=new IntRect(0,0,sprite.Bounds.Width, sprite.Bounds.Height);
            items.Add(this);
        }

        public static Item GetItem(int id){
            return items.Find(delegate(Item item){if(item.ID==id)return true; return false;});
        }

        public static List<Item> GetItems(){
            return items.Clone();
        }
    }
}