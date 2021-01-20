using System;
using Fish_Girlz.Entities;
using Fish_Girlz.Items;
using Fish_Girlz.Utils;
using SFML.Graphics;

namespace Fish_Girlz.API.Core.Items{
    public class ManaPotion : PotionItem
    {
        int manaAmount;

        public ManaPotion(int manaAmount=10) : base("mana_potion", "mana_potion", AssetLoader.GetTexture(CoreAPIPlugin.Instance, "potion").SetColor(Color.Red, Color.Blue))
        {
            this.manaAmount=manaAmount;
        }

        public override bool OnUse(PlayerEntity player)
        {
            return true;
        }
    }
}