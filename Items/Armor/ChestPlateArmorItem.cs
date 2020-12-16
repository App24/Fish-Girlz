using System;
using Fish_Girlz.Entities;
using Fish_Girlz.Localisation;
using SFML.Graphics;

namespace Fish_Girlz.Items{
    public class ChestPlateArmorItem : ArmorItem
    {
        public ChestPlateArmorItem(string name, Texture texture, float defense) : base(Language.GetCurrentLanguage().GetTranslation("item.armor.chest", name), texture, defense)
        {
        }

        public override bool OnUse(PlayerEntity player)
        {
            if(!player.Inventory.SetChestplate(this)) return false;
            return true;
        }
    }
}