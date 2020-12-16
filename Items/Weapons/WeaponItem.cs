using System;
using Fish_Girlz.Art;
using Fish_Girlz.Entities;
using SFML.Graphics;

namespace Fish_Girlz.Items{
    public abstract class WeaponItem : Item
    {
        public int Damage{get;}

        public WeaponItem(string id, string name, Texture texture, int damage) : base(id, name, new SpriteInfo(texture, new IntRect(0,0,64,64)), 1)
        {
            Damage=damage;
        }

        public override bool OnUse(PlayerEntity player)
        {
            if(!player.Inventory.SetWeapon(this)) return false;
            return true;
        }
    }
}