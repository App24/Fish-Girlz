using System;
using Fish_Girlz.Art;
using Fish_Girlz.Entities;
using Fish_Girlz.Utils;
using SFML.Graphics;
using SFML.System;

namespace Fish_Girlz.Tiles{
    public abstract class TransformationTile : Tile
    {
        public TransformationTile(string id, string name, Texture texture, bool collidable = true) : this(id, name, texture, new Vector2i(), collidable)
        {
        }
        public TransformationTile(string id, string name, Texture texture, Vector2i offset, bool collidable = true) : base(id, name, texture, offset, collidable)
        {
        }

        public override CollisionBehaviour OnContiueCollision(CollisionEventArgs e)
        {
            if(e.Other.Entity is PlayerEntity){
                PlayerEntity playerEntity=(PlayerEntity)e.Other.Entity;
                if(!playerEntity.IsMermaid) playerEntity.IsMermaid=true;
                if(playerEntity.IsMermaid)
                return CollisionBehaviour.IgnoreCollision;
            }
            return CollisionBehaviour.Collision;
        }

        public override void OnExitCollision(CollisionEventArgs e)
        {
            if(e.Other.Entity is PlayerEntity){
                PlayerEntity playerEntity=(PlayerEntity)e.Other.Entity;
                if(playerEntity.IsMermaid) playerEntity.IsMermaid=false;
            }
        }
    }
}