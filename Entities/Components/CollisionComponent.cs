using System;
using Fish_Girlz.Utils;
using SFML.Graphics;

namespace Fish_Girlz.Entities.Components{
    public class CollisionComponent : EntityComponent {

        public bool Colliding{get;set;}
        public CollisionEventHandler OnCollision;
        public bool Collidable{get; set;}

        public IntRect CollisionBounds {get; set;}

        public override void Init(){
            Collidable=true;
            CollisionBounds=new IntRect(0,0,ParentEntity.Sprite.Bounds.Width, ParentEntity.Sprite.Bounds.Height);
        }

        public override void Update(params object[] args)
        {
            
        }
    }
}