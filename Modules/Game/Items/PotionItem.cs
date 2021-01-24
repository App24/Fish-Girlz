using System;
using System.Collections.Generic;
using Fish_Girlz.Art;
using Fish_Girlz.Entities;
using Fish_Girlz.Utils;
using SFML.Graphics;

namespace Fish_Girlz.Items{
    public abstract class PotionItem : Item
    {

        public PotionItem(string id, string name, Texture potionTexture, int maxStack=64) : base(id, name, potionTexture, maxStack)
        {
            CollisionBounds=new IntRect(11,8,52,64);
        }
    }
}