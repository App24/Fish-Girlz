using System;
using Fish_Girlz.Entities;
using SFML.Graphics;
using SFML.System;

namespace Fish_Girlz.Items{
    public abstract class RingItem : StatModifierItem
    {
        public RingItem(string id, string name, Texture texture, StatModifier statModifier, int amount) : this(id, name, texture, new Vector2i(), statModifier, amount)
        {
        }

        protected RingItem(string id, string name, Texture texture, Vector2i offset, StatModifier statModifier, int amount) : base(id, name, texture, offset, statModifier, amount)
        {
        }

        public override bool OnUse(PlayerEntity player)
        {
            return player.Inventory.SetItem(this, Inventory.ItemSlot.Ring);
        }
    }
}