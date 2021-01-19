using System;
using Fish_Girlz.Art;
using SFML.Graphics;

namespace Fish_Girlz.Items{
    [Obsolete]
    public class SwordItem : WeaponItem
    {

        public SwordItem(string id, string name, Texture texture, int damage) : base(id, name, texture, damage)
        {
        }
    }
}