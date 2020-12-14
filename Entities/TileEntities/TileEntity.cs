using System;
using System.Collections.Generic;
using Fish_Girlz.Art;
using SFML.System;
using Fish_Girlz.Entities.Components;
using Fish_Girlz.Tiles;
using Fish_Girlz.States;

namespace Fish_Girlz.Entities.Tiles{
    public class TileEntity : Entity
    {
        protected CollisionComponent collisionComponent;

        public Tile Tile{get;}

        public TileEntity(Vector2f position, Tile tile) : base(position, tile.Sprite)
        {
            collisionComponent=AddComponent(new CollisionComponent());
            collisionComponent.Collidable=tile.Collidable;
            Tile=tile;
        }

        public override void Move()
        {

        }

        public override void Update(State currentState)
        {
            
        }
    }
}