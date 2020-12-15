using System;
using Fish_Girlz.Art;
using Fish_Girlz.Entities;
using Fish_Girlz.Utils;
using Fish_Girlz.Localisation;
using SFML.Graphics;

namespace Fish_Girlz.Items{
    public class PotionItem : Item
    {
        PotionType PotionType{get;set;}

        public PotionItem(string name, Color potionColor, PotionType potionType) : base(Language.GetCurrentLanguage().GetTranslation("item.potion", name), new SpriteInfo(AssetManager.GetTexture("potion").SetColor(Color.Red, potionColor), new IntRect(0,0,64,64)))
        {
            CollisionBounds=new IntRect(11,8,52,64);
            PotionType=potionType;
        }

        public override bool OnUse(PlayerEntity player)
        {
            switch (PotionType)
            {
                case PotionType.Heal:
                    if(player.Health>=player.MaxHealth) return false;
                    player.Heal(5);
                    break;
                case PotionType.Speed:
                    Console.WriteLine("Speed Potion");
                    break;
            }
            return true;
        }
    }

    public enum PotionType{
        Heal, Speed
    }
}