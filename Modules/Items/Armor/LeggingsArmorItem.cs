using System;
using Fish_Girlz.Entities;
using SFML.Graphics;

namespace Fish_Girlz.Items{
    public abstract class LeggingsArmorItem : ArmorItem
    {
        public LeggingsArmorItem(string id, string name, Texture texture, float defense) : base(id, name, texture, defense)
        {
        }

        public override bool OnUse(PlayerEntity player)
        {
            return player.Inventory.SetItem(this, Inventory.ItemSlot.Leggings);
        }
    }
}