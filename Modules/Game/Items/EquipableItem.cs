using System;
using Fish_Girlz.Art;
// using Fish_Girlz.Entities;
using SFML.Graphics;

namespace Fish_Girlz.Items{
    public abstract class EquipableItem : Item
    {
        public EquipableItem(string id, string name, Texture texture) : base(id, name, new SpriteInfo(texture, new IntRect(0,0,64,64)), 1)
        {
        }

        // public override bool OnUse(PlayerEntity player)
        // {
        //     /*if(!player.Inventory.SetEquipable(this)) return false;
        //     return true;*/
        //     return false;
        // }
    }
}