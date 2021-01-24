using System;
using Fish_Girlz.Art;
using SFML.System;
using SFML.Graphics;

namespace Fish_Girlz.Entities{
    public abstract class NPCEntity : LivingEntity
    {
        public NPCEntity(string id, string name, int maxHealth, Texture texture) : this(id, name, maxHealth, texture, new Vector2i())
        {
        }
        public NPCEntity(string id, string name, int maxHealth, Texture texture, Vector2i offset) : base(id, name, maxHealth, texture, offset)
        {
        }
    }
}