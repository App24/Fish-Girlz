using System;
using Fish_Girlz.Art;
using SFML.Graphics;

namespace Fish_Girlz.Inventory.Items{
    public class BasicItem : Item
    {
        public BasicItem(string name, SpriteInfo sprite, uint maxStack=64) : base(name, sprite, maxStack)
        {
        }
    }
}