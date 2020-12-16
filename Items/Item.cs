using System;
using System.Collections.Generic;
using SFML.Graphics;
using Fish_Girlz.Utils;
using Fish_Girlz.Art;
using Fish_Girlz.Entities;

namespace Fish_Girlz.Items{
    public abstract class Item {
        public int ID{get;}
        public string Name{get;}
        public int MaxStack{get;}
        public SpriteInfo Sprite{get;}
        public IntRect CollisionBounds{get; protected set;}

        static List<Item> items=new List<Item>();

        #region Item Inits
        public static PotionItem HEALTH_POTION=new PotionItem("Health", Color.Red, PotionType.Heal);
        public static SwordItem WOODEN_SWORD=new SwordItem("Wooden", Utilities.CreateTexture(64,64,Color.Red), 1);
        public static BowItem NORMAL_BOW=new BowItem("Normal", Utilities.CreateTexture(64,64,Color.Cyan), 1);
        public static PotionItem SPEED_POTION=new PotionItem("Speed", Color.Green, PotionType.Speed);
        public static HelmetArmorItem NORMAL_HEMET=new HelmetArmorItem("Normal", Utilities.CreateTexture(64,64,Color.Magenta), 5);
        public static ChestPlateArmorItem NORMAL_CHESTPLATE=new ChestPlateArmorItem("Normal", Utilities.CreateTexture(64,64,Color.Yellow), 10);
        public static LeggingsArmorItem NORMAL_LEGGINGS=new LeggingsArmorItem("Normal", Utilities.CreateTexture(64,64,Color.Blue), 5);
        public static BootsArmorItem NORMAL_BOOTS=new BootsArmorItem("Normal", Utilities.CreateTexture(64,64,Color.Green), 3);
        #endregion

        public Item(string name, SpriteInfo sprite, int maxStack=64){
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

        public abstract bool OnUse(PlayerEntity player);
    }
}