using System;
using SFML.Graphics;

namespace Fish_Girlz.Inventory.Items{
    public class BasicItem : Item
    {
        public BasicItem(string name, Texture itemTexture, uint maxStack=64) : base(name, itemTexture, maxStack)
        {
        }
    }
}