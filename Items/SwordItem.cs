using System;
using Fish_Girlz.Art;
using Fish_Girlz.Entities;
using SFML.Graphics;
using Fish_Girlz.Localisation;

namespace Fish_Girlz.Items{
    public class SwordItem : Item
    {
        private int damage;

        public SwordItem(string name, Texture texture, int damage) : base(Language.GetCurrentLanguage().GetTranslation("item.sword", name), new SpriteInfo(texture, new IntRect(0,0,64,64)), 1)
        {
            this.damage=damage;
        }

        public override bool OnUse(PlayerEntity player)
        {
            return true;
        }
    }
}