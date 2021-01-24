using System;
using System.Collections.Generic;
using SFML.Graphics;
using SFML.System;
using Fish_Girlz.Utils;
using Fish_Girlz.Art;
using Fish_Girlz.Entities;
using System.Runtime.CompilerServices;

namespace Fish_Girlz.Items{
    public abstract class Item {
        public string ID{get; private set;}
        public string Name{get; private set;}
        public int MaxStack{get;}
        public SpriteInfo Sprite{get;}
        public IntRect CollisionBounds{get; protected set;}

        static List<Item> items=new List<Item>();

        public Item(string id, string name, Texture texture, Vector2i offset, int maxStack=64){
            ID=id;
            Name=name;
            if(!Name.StartsWith("item.")) Name=$"item.{Name}";
            MaxStack=maxStack;
            Sprite=new SpriteInfo(texture, new IntRect(offset.X, offset.Y, Statics.UNIT_SIZE, Statics.UNIT_SIZE));
            CollisionBounds=new IntRect(0,0,Sprite.Bounds.Width, Sprite.Bounds.Height);
        }

        public Item(string id, string name, Texture texture, int maxStack=64):this(id,name,texture,new Vector2i(), maxStack){
        }

        internal static void AddItem<T>(T item, string modId="") where T: Item{
            if(!string.IsNullOrEmpty(modId)){
                item.ID=$"{modId}.{item.ID}";
                item.Name=$"{modId}.{item.Name}";
            }
            if(items.Find(delegate(Item other){if(other.ID==item.ID) return true; return false;})!=null) return;
            items.Add(item);
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