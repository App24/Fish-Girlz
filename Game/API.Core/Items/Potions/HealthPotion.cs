using System;
using Fish_Girlz.Entities;
using Fish_Girlz.Items;
using Fish_Girlz.Utils;
using SFML.Graphics;

namespace Fish_Girlz.API.Core.Items{
    public class HealthPotion : PotionItem
    {
        int healAmount;

        public HealthPotion(int healAmount=10) : base("health_potion", "health_potion", AssetLoader.GetTexture(CoreAPIPlugin.Instance, "potion").SetColor(Color.Red, Color.Red))
        {
            this.healAmount=healAmount;
        }

        public override bool OnUse(PlayerEntity player)
        {
            if(player.Health>=player.MaxHealth) return false;
            player.Heal(healAmount);
            return true;
        }
    }
}