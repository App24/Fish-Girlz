using System;
using System.Collections.Generic;
using SFML.Graphics;
using Fish_Girlz.Utils;
using Fish_Girlz.Art;
using Fish_Girlz.Entities;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Fish Girlz")]
[assembly: InternalsVisibleTo("Entities")]
[assembly: InternalsVisibleTo("Inventory")]
[assembly: InternalsVisibleTo("Render")]
[assembly: InternalsVisibleTo("World")]
[assembly: InternalsVisibleTo("API")]
namespace Fish_Girlz.Items{
    public abstract class Item {
        public string ID{get; private set;}
        public string Name{get; private set;}
        public int MaxStack{get;}
        public SpriteInfo Sprite{get;}
        public IntRect CollisionBounds{get; protected set;}

        static List<Item> items=new List<Item>();

        public Item(string id, string name, SpriteInfo sprite, int maxStack=64){
            ID=id;
            Name=name;
            if(!Name.StartsWith("item.")) Name=$"item.{Name}";
            MaxStack=maxStack;
            Sprite=sprite;
            CollisionBounds=new IntRect(0,0,sprite.Bounds.Width, sprite.Bounds.Height);
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