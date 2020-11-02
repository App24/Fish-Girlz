using System;
using System.Collections.Generic;
using Fish_Girlz.Art;
using Fish_Girlz.Utils;
using SFML.System;
using SFML.Graphics;

namespace Fish_Girlz.Entities{
    public abstract class Entity : IComparable<Entity> {
        public SpriteInfo Sprite {get; protected set;}

        public Vector2f Position{get;set;}

        public CollisionEventHandler OnCollision;

        public Entity(Vector2f position, SpriteInfo sprite){
            this.Sprite=sprite;
            Position=position;
        }

        public int CompareTo(Entity other)
        {
            if(other==null)
                return 1;
            return Sprite.Layer.CompareTo(other.Sprite.Layer);
        }

        public LayeredSprite ToLayeredSprite(){
            LayeredSprite sprite=new LayeredSprite(Sprite.texture);
            sprite.TextureRect=Sprite.bounds;
            sprite.Position=Position;
            return sprite;
        }

        public List<T> GetNearbyEntities<T>(List<T> entities) where T: Entity{
            List<T> newEntities=new List<T>();
            foreach (T entity in entities)
            {
                if(entity==this)
                    continue;
                if(entity.Position.Distance(Position)<=1000)
                    Console.WriteLine(entity.Position.Distance(Position));
                if(entity.Position.Distance(Position)<=500){
                    newEntities.Add(entity);
                }
            }
            return newEntities;
        }

        public abstract void Update();
    }
}