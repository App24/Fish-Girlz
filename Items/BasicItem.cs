using System;
using Fish_Girlz.Art;
using Fish_Girlz.Entities;
using SFML.Graphics;

namespace Fish_Girlz.Items{
    public class BasicItem : Item
    {
        public BasicItem(string name, SpriteInfo sprite, int maxStack=64) : base(name, sprite, maxStack)
        {
        }

        public override bool OnUse(PlayerEntity player)
        {
            return true;
        }
    }
}