using System;
using Fish_Girlz.Art;
using SFML.System;

namespace Fish_Girlz.Entities{
    public abstract class NPCEntity : LivingEntity
    {
        public NPCEntity(string id, string name, SpriteInfo sprite, int maxHealth) : base(id, name, sprite, maxHealth)
        {
        }
    }
}