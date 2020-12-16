using System;
using Fish_Girlz.Entities;
using Fish_Girlz.Localisation;
using SFML.Graphics;

namespace Fish_Girlz.Items{
    public class BootsArmorItem : ArmorItem
    {
        public BootsArmorItem(string name, Texture texture, float defense) : base(Language.GetCurrentLanguage().GetTranslation("item.armor.boots", name), texture, defense)
        {
        }

        public override bool OnUse(PlayerEntity player)
        {
            if(!player.Inventory.SetBoots(this)) return false;
            return true;
        }
    }
}