using System;
using System.Collections.Generic;
using Fish_Girlz.Art;
using SFML.System;
using Fish_Girlz.Entities.Components;

namespace Fish_Girlz.Entities.Tiles{
    public abstract class TileEntity : Entity
    {
        public int ID {get;}
        protected CollisionComponent collisionComponent;

        public TileEntity(Vector2f position, SpriteInfo sprite, bool collidable, int id) : base(position, sprite)
        {
            collisionComponent=AddComponent(new CollisionComponent());
            collisionComponent.Collidable=collidable;
            ID=id;
        }
    }
}