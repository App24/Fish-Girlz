using System;
using Fish_Girlz.Entities;
using SFML.Graphics;
using SFML.System;

namespace Fish_Girlz.Items{
    public abstract class LeggingsArmorItem : ArmorItem
    {
        public LeggingsArmorItem(string id, string name, Texture texture, float defense) : this(id, name, texture, new Vector2i(), defense)
        {
        }

        protected LeggingsArmorItem(string id, string name, Texture texture, Vector2i offset, float defense) : base(id, name, texture, offset, defense)
        {
        }

        public override bool OnUse(PlayerEntity player)
        {
            return player.Inventory.SetItem(this, Inventory.ItemSlot.Leggings);
        }
    }
}