using System;
using Fish_Girlz.Art;
using SFML.Graphics;
using SFML.System;

namespace Fish_Girlz.Items{
    public abstract class ArmorItem : Item
    {
        public float Defense{get;}

        public ArmorItem(string id, string name, Texture texture, float defense) : this(id, name, texture, new Vector2i(), defense)
        {
            Defense=defense;
        }

        protected ArmorItem(string id, string name, Texture texture, Vector2i offset, float defense) : base(id, name, texture, offset, 1)
        {
        }
    }
}