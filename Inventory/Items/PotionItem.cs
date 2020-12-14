using System;
using Fish_Girlz.Art;
using Fish_Girlz.Utils;
using SFML.Graphics;

namespace Fish_Girlz.Inventory.Items{
    public class PotionItem : Item
    {
        public PotionItem(string name, Color potionColor) : base($"{name} Potion", new SpriteInfo(AssetManager.GetTexture("potion").SetColor(Color.Red, potionColor), new IntRect(0,0,64,64)))
        {
            CollisionBounds=new IntRect(11,8,52,64);
        }
    }
}