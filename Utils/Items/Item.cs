using System;
using System.Collections.Generic;
using SFML.Graphics;
using Fish_Girlz.Utils;
using Fish_Girlz.Art;
using Fish_Girlz.Entities;

namespace Fish_Girlz.Items{
    public abstract class Item {
        public string ID{get;}
        public string Name{get;}
        public int MaxStack{get;}
        public SpriteInfo Sprite{get;}
        public IntRect CollisionBounds{get; protected set;}

        static List<Item> items=new List<Item>();

        public Item(string id, string name, SpriteInfo sprite, int maxStack=64){
            ID=id;
            Name=name;
            MaxStack=maxStack;
            Sprite=sprite;
            CollisionBounds=new IntRect(0,0,sprite.Bounds.Width, sprite.Bounds.Height);
            items.Add(this);
        }

        public static Item GetItem(string id){
            return items.Find(delegate(Item item){if(item.ID==id)return true; return false;});
        }

        public static List<Item> GetItems(){
            return items.Clone();
        }

        public abstract bool OnUse(PlayerEntity player);
    }
}