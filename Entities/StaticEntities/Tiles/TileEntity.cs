using System;
using Fish_Girlz.Art;
using SFML.System;

namespace Fish_Girlz.Entities{
    public class TileEntity : StaticEntity
    {
        public bool Collidable{get; protected set;}

        public TileEntity(Vector2f position, SpriteInfo sprite, bool collidable) : base(position, sprite)
        {
            Collidable=collidable;
        }
    }
}