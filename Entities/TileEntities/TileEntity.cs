using System;
using System.Collections.Generic;
using Fish_Girlz.Art;
using SFML.System;

namespace Fish_Girlz.Entities.Tiles{
    public abstract class TileEntity : Entity
    {
        public int ID {get;}

        public TileEntity(Vector2f position, SpriteInfo sprite, bool collidable, int id) : base(position, sprite)
        {
            Collidable=collidable;
            ID=id;
        }
    }
}