using System;
using Fish_Girlz.Art;
using Fish_Girlz.Entities;
using SFML.Graphics;

namespace Fish_Girlz.Items{
    public abstract class ArmorItem : Item
    {
        public float Defense{get;}

        public ArmorItem(string name, Texture texture, float defense) : base(name, new SpriteInfo(texture, new IntRect(0,0,64,64)), 1)
        {
            Defense=defense;
        }
    }
}