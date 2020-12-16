using System;
using Fish_Girlz.Entities;
using Fish_Girlz.Localisation;
using SFML.Graphics;

namespace Fish_Girlz.Items{
    public class HelmetArmorItem : ArmorItem
    {
        public HelmetArmorItem(string id, string name, Texture texture, float defense) : base(id, name, texture, defense)
        {
        }

        public override bool OnUse(PlayerEntity player)
        {
            if(!player.Inventory.SetHelmet(this)) return false;
            return true;
        }
    }
}