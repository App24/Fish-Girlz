using System;
using System.Collections.Generic;
using Fish_Girlz.Art;
using Fish_Girlz.Utils;
using Fish_Girlz.States;
using Fish_Girlz.Effects;
using SFML.System;
using SFML.Graphics;

namespace Fish_Girlz.Entities{
    public abstract class Entity : IComparable<Entity> {
        public SpriteInfo Sprite {get; protected set;}

        public Vector2f Position{get; private set;}
        public Vector2f Speed {get; protected set;}

        public bool Colliding{get;protected set;}

        public CollisionEventHandler OnCollision;

        public bool ToRemove{get;protected set;}

        public float Rotation{get;protected set;}
        public bool Collidable{get; protected set;}

        public IntRect CollisionBounds {get; protected set;}

        public Entity(Vector2f position, SpriteInfo sprite){
            this.Sprite=sprite;
            Position=position;
            Collidable=true;
            CollisionBounds=new IntRect(0,0,sprite.Bounds.Width, sprite.Bounds.Height);
        }

        public int CompareTo(Entity other)
        {
            if(other==null)
                return 1;
            return Sprite.Layer.CompareTo(other.Sprite.Layer);
        }

        public LayeredSprite ToLayeredSprite(){
            LayeredSprite sprite=new LayeredSprite(Sprite.Texture);
            sprite.TextureRect=Sprite.Bounds;
            sprite.Position=Position;
            return sprite;
        }

        public List<T> GetNearbyEntities<T>(List<T> entities, params Type[] toIgnore) where T: Entity{
            List<T> newEntities=new List<T>();
            List<Type> toIgnoreList=new List<Type>(toIgnore);
            foreach (T entity in entities)
            {
                if(entity==this||toIgnoreList.Contains(entity.GetType()))
                    continue;
                if(entity.Position.Distance(Position)<=500){
                    newEntities.Add(entity);
                }
            }
            return newEntities;
        }

        public abstract void Update(State currentState);

        public abstract void Move();

        public void CheckCollision(Entity entity){
            Position+=Speed;
            if(entity!=null){
                if (this.CollideWithEntity(entity))
                {
                    Colliding=true;
                }
            }
            Position -= Speed;
        }

        public void CheckMovement(){
            if(!Colliding){
                Position+=Speed;
            }
            Speed=new Vector2f();
            Colliding=false;
        }
    }
}