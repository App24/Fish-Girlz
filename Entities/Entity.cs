using System;
using System.Linq;
using System.Collections.Generic;
using Fish_Girlz.Art;
using Fish_Girlz.Utils;
using Fish_Girlz.States;
using Fish_Girlz.Effects;
using SFML.System;
using SFML.Graphics;
using Fish_Girlz.Entities.Components;
using Fish_Girlz.Entities.Items;

namespace Fish_Girlz.Entities{
    public abstract class Entity : IComparable<Entity> {
        public SpriteInfo Sprite {get; protected set;}

        public Vector2f Position{get; private set;}
        public Vector2f Speed {get; set;}

        public bool ToRemove{get;set;}

        public float Rotation{get;protected set;}

        List<EntityComponent> components=new List<EntityComponent>();

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
            LayeredSprite sprite=new LayeredSprite(Sprite.Texture);
            sprite.TextureRect=Sprite.Bounds;
            sprite.Position=Position;
            return sprite;
        }

        public List<T> GetNearbyEntities<T>(List<T> entities, float distance=500, params Type[] toIgnore) where T: Entity{
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

        public List<T> GetNearbyEntitiesWithComponent<C, T>(List<T> entities, float distance=500) where T : Entity where C : EntityComponent{
            List<T> nearbyEntities=GetNearbyEntities(entities, distance);
            List<T> newEntities=nearbyEntities.FindAll(delegate(T entity){if(entity.GetComponent<C>()!=null)return true; return false;});
            return newEntities;
        }

        public List<EnemyEntity> GetNearbyEnemies(List<Entity> entities, float distance=500){
            List<Entity> nearbyEntities=GetNearbyEntities(entities, distance);
            List<EnemyEntity> newEntities=nearbyEntities.FindAll(delegate(Entity entity){if(entity is EnemyEntity)return true; return false;}).Cast<EnemyEntity>().ToList();
            return newEntities;
        }

        public abstract void Update(State currentState);

        public abstract void Move();

        public T GetComponent<T>() where T : EntityComponent{
            EntityComponent component=components.Find(delegate(EntityComponent e){if(e is T)return true; return false;});
            if(component!=null){
                return (T)component;
            }
            return null;
        }

        protected T AddComponent<T>(T component) where T:EntityComponent{
            component.ParentEntity=this;
            component.Init();
            components.Add(component);
            return component;
        }

        public void CheckCollision(Entity entity){
            Position+=Speed;
            if(entity!=null){
                CollisionComponent collisionComponent=GetComponent<CollisionComponent>();
                if(collisionComponent!=null){
                    if (this.CollideWithEntity(entity))
                    {
                        collisionComponent.Colliding=true;
                    }
                }
            }
            Position -= Speed;
        }

        public void CheckMovement(){
            CollisionComponent collisionComponent=GetComponent<CollisionComponent>();
            if((collisionComponent!=null&&!collisionComponent.Colliding)||(collisionComponent==null)){
                Position+=Speed;
            }
            Speed=new Vector2f();
            if(collisionComponent!=null)
                collisionComponent.Colliding=false;
        }

        public List<EntityComponent> GetComponents(){
            return components;
        }
    }
}