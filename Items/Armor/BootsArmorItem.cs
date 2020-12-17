using System;
using Fish_Girlz.Entities;
using Fish_Girlz.Localisation;
using SFML.Graphics;

namespace Fish_Girlz.Items{
    public class BootsArmorItem : ArmorItem
    {
        public BootsArmorItem(string id, string name, Texture texture, float defense) : base(id, name, texture, defense)
        {
        }

        public override bool OnUse(PlayerEntity player)
        {
            return player.Inventory.SetItem(this, Inventory.ItemSlot.Boots);
        }
    }
}