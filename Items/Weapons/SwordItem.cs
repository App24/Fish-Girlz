using System;
using Fish_Girlz.Art;
using Fish_Girlz.Entities;
using SFML.Graphics;
using Fish_Girlz.Localisation;

namespace Fish_Girlz.Items{
    public class SwordItem : WeaponItem
    {

        public SwordItem(string name, Texture texture, int damage) : base(Language.GetCurrentLanguage().GetTranslation("item.sword", name), texture, damage)
        {
        }
    }
}