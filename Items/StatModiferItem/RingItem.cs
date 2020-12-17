using System;
using Fish_Girlz.Entities;
using SFML.Graphics;

namespace Fish_Girlz.Items{
    public class RingItem : StatModifierItem
    {
        public RingItem(string id, string name, Texture texture, StatModifier statModifier, int amount) : base(id, name, texture, statModifier, amount)
        {
        }

        public override bool OnUse(PlayerEntity player)
        {
            return player.Inventory.SetItem(this, Inventory.ItemSlot.Ring);
        }
    }
}