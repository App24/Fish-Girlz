using System;
using System.Collections.Generic;
using Fish_Girlz.Art;
using Fish_Girlz.Entities;
using Fish_Girlz.Utils;
using SFML.Graphics;

namespace Fish_Girlz.Items{
    public abstract class PotionItem : Item
    {
        // PotionType PotionType{get;set;}
        // Dictionary<string, object> values=new Dictionary<string, object>();

        public PotionItem(string id, string name, Texture potionTexture/*, PotionType potionType, Dictionary<string, object> values*/) : base(id, name, new SpriteInfo(potionTexture, new IntRect(0,0,64,64)))
        {
            CollisionBounds=new IntRect(11,8,52,64);
            // PotionType=potionType;
            // this.values=values;
        }

        // T GetValue<T>(string name){
        //     object value;
        //     if(values.TryGetValue(name, out value)){
        //         return (T)value;
        //     }
        //     return default(T);
        // }

        // public override bool OnUse(PlayerEntity player)
        // {
        //     switch (PotionType)
        //     {
        //         case PotionType.Heal:
        //             if(player.Health>=player.MaxHealth) return false;
        //             int healAmount=GetValue<int>("healamount");
        //             player.Heal(healAmount);
        //             break;
        //         case PotionType.None:
        //         default:
        //             break;
        //     }
        //     return true;
        // }
    }

    // public enum PotionType{
    //     None, Heal
    // }
}