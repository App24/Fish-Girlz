using System;
using Fish_Girlz.Art;
using Fish_Girlz.Entities;
using SFML.Graphics;
using Fish_Girlz.Localisation;

namespace Fish_Girlz.Items{
    [Obsolete]
    public class BowItem : WeaponItem
    {
        public BowItem(string id, string name, Texture texture, int damage) : base(id, name, texture, damage)
        {
        }
    }
}