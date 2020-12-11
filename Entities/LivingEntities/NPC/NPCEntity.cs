using System;
using Fish_Girlz.Art;
using SFML.System;

namespace Fish_Girlz.Entities{
    public abstract class NPCEntity : LivingEntity
    {
        public NPCEntity(Vector2f position, SpriteInfo sprite, int maxHealth) : base(position, sprite, maxHealth)
        {
        }
    }
}