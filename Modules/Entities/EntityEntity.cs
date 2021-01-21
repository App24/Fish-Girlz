using System;
using System.Linq;
using System.Collections.Generic;
using Fish_Girlz.Art;
using Fish_Girlz.Utils;
using Fish_Girlz.States;
using SFML.System;
using SFML.Graphics;
using Fish_Girlz.Entities.Components;
using Fish_Girlz.Entities.Items;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Fish Girlz")]
[assembly: InternalsVisibleTo("Render")]
[assembly: InternalsVisibleTo("States")]
[assembly: InternalsVisibleTo("Utils")]
[assembly: InternalsVisibleTo("World")]
[assembly: InternalsVisibleTo("API")]
namespace Fish_Girlz.Entities{
    public class EntityEntity : IComparable<EntityEntity> {
        // public SpriteInfo Sprite {get; protected set;}

        public Vector2f Position{get; private set;}
        public Vector2f Speed {get; set;}

        public bool ToRemove{get;set;}

        // List<EntityComponent> components=new List<EntityComponent>();

        public Entity Entity{get;}

        public EntityEntity(Vector2f position, Entity entity){
            Entity=entity;
            Entity.EntityEntity=this;
            Position=position;
        }

        public int CompareTo(EntityEntity other)
        {
            if(other==null)
                return 1;
            return Entity.Sprite.Layer.CompareTo(other.Entity.Sprite.Layer);
        }

        public LayeredSprite ToLayeredSprite(){
            LayeredSprite sprite=new LayeredSprite(Entity.Sprite.Texture);
            sprite.TextureRect=Entity.Sprite.Bounds;
            sprite.Position=Position;
            return sprite;
        }

        public List<T> GetNearbyEntities<T>(List<T> entities, float distance=500, params Type[] toIgnore) where T: EntityEntity{
            List<T> newEntities=new List<T>();
            List<Type> toIgnoreList=new List<Type>(toIgnore);
            foreach (T entity in entities)
            {
                if(entity==this||toIgnoreList.Contains(entity.GetType()))
                    continue;
                if(entity.Position.Distance(Position)<=distance){
                    newEntities.Add(entity);
                }
            }
            newEntities.Sort(delegate(T x, T y){
                return x.Position.Distance(Position).CompareTo(y.Position.Distance(Position));
            });
            return newEntities;
        }

        public List<T> GetNearbyEntitiesWithComponent<C, T>(List<T> entities, float distance=500) where T : EntityEntity where C : EntityComponent{
            List<T> nearbyEntities=GetNearbyEntities(entities, distance);
            List<T> newEntities=nearbyEntities.FindAll(delegate(T entity){if(entity.Entity.GetComponent<C>()!=null)return true; return false;});
            return newEntities;
        }

        public List<EnemyEntity> GetNearbyEnemies(List<EntityEntity> entities, float distance=500){
            List<EntityEntity> nearbyEntities=GetNearbyEntities(entities, distance);
            List<EnemyEntity> newEntities=nearbyEntities.FindAll(delegate(EntityEntity entity){if(entity.Entity is EnemyEntity)return true; return false;}).Cast<EnemyEntity>().ToList();
            return newEntities;
        }

        internal void CheckCollision(EntityEntity entity){
            Position+=Speed;
            if(entity!=null){
                CollisionComponent collisionComponent=this.Entity.GetComponent<CollisionComponent>();
                if(collisionComponent!=null){
                    if (this.CollideWithEntity(entity))
                    {
                        collisionComponent.Colliding=true;
                    }
                }
            }
            Position -= Speed;
        }

        internal void CheckMovement(){
            CollisionComponent collisionComponent=Entity.GetComponent<CollisionComponent>();
            if((collisionComponent!=null&&!collisionComponent.Colliding)||(collisionComponent==null)){
                Position+=Speed;
            }
            Speed=new Vector2f();
            if(collisionComponent!=null)
                collisionComponent.Colliding=false;
        }

        protected T AddComponent<T>(T component) where T:EntityComponent{
            return Entity.AddComponent(component);
        }

        public T GetComponent<T>() where T : EntityComponent{
            return Entity.GetComponent<T>();
        }
    }
}