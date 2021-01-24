using System;
using Fish_Girlz.Utils;
using SFML.Graphics;

namespace Fish_Girlz.Entities.Components{
    public class CollisionComponent : EntityComponent {

        internal bool Colliding{get;set;}
        public CollisionEnterEventHandler OnEnterCollision;
        public CollisionExitEventHandler OnExitCollision;
        public CollisionContinueEventHandler OnContinueCollision;
        public bool Collidable{get; set;}

        public IntRect CollisionBounds {get; set;}

        public CollisionComponent(IntRect collisionBounds){
            CollisionBounds=collisionBounds;
        }

        public override void Init(){
            Collidable=true;
            // CollisionBounds=new IntRect(0,0,ParentEntity.Sprite.Bounds.Width, ParentEntity.Sprite.Bounds.Height);
        }
    }
}