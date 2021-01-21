using System;
using System.Collections.Generic;
using Fish_Girlz.Art;
using SFML.System;
using Fish_Girlz.Entities.Components;
using Fish_Girlz.Tiles;
using Fish_Girlz.States;

// namespace Fish_Girlz.Entities.Tiles{
//     public class TileEntity : EntityEntity
//     {
//         protected CollisionComponent collisionComponent;

//         public Tile Tile{get;}

//         public TileEntity(Vector2f position, Tile tile) : base(position, new Entity(tile.ID, tile.Name, tile.Sprite))
//         {
//             collisionComponent=AddComponent(new CollisionComponent());
//             collisionComponent.Collidable=tile.Collidable;
//             Tile=tile;
//         }

//         internal override void Move()
//         {

//         }

//         internal override void Update(State currentState)
//         {
            
//         }
//     }
// }

namespace Fish_Girlz.Entities.Tiles{
    public class TileEntity : Entity
    {
        protected CollisionComponent collisionComponent;

        public Tile Tile{get;}

        public override bool ShowOnMapEditor => false;

        public TileEntity(Tile tile) : base(tile.ID.ToString(), tile.Name, tile.Sprite)
        {
            Tile=tile;
        }

        internal override void Update(State currentState)
        {
            
        }

        internal override void Move()
        {
            
        }
    }
}