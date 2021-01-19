using System;
using Fish_Girlz.Art;
using Fish_Girlz.Entities;
using SFML.Graphics;

namespace Fish_Girlz.Items{
    [Obsolete]
    public abstract class WeaponItem : EquipableItem
    {
        public int Damage{get;}

        public WeaponItem(string id, string name, Texture texture, int damage) : base(id, name, texture)
        {
            Damage=damage;
        }

        public override bool OnUse(PlayerEntity player)
        {
            return false;
        }
    }
}