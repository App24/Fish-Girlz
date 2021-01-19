using System;
using Fish_Girlz.Art;
using SFML.System;

namespace Fish_Girlz.Entities{
    public abstract class StaticEntity : Entity
    {
        public StaticEntity(Vector2f position, SpriteInfo sprite) : base(position, sprite)
        {
            
        }
    }
}