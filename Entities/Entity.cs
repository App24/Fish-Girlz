using System;
using System.Collections.Generic;
using Fish_Girlz.Art;
using Fish_Girlz.Utils;
using Fish_Girlz.States;
using Fish_Girlz.Effects;
using SFML.System;
using SFML.Graphics;
using Fish_Girlz.Entities.Components;

namespace Fish_Girlz.Entities{
    public abstract class Entity : IComparable<Entity> {
        public SpriteInfo Sprite {get; protected set;}

        public Vector2f Position{get; private set;}
        public Vector2f Speed {get; protected set;}

        public bool ToRemove{get;protected set;}

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
            return newEntities;
        }

        public List<EnemyEntity> GetNearbyEnemies(List<Entity> entities, float distance=500){
            List<EnemyEntity> newEntities=new List<EnemyEntity>();
            foreach (Entity entity in entities)
            {
                if(entity==this||!(entity is EnemyEntity))
                    continue;
                if(entity.Position.Distance(Position)<=distance){
                    newEntities.Add((EnemyEntity)entity);
                }
            }
            return newEntities;
        }

        public abstract void Update(State currentState);

        public abstract void Move();

        public T GetComponent<T>(Type componentType) where T : EntityComponent{
            EntityComponent component=components.Find(delegate(EntityComponent e){if(e.GetType()==componentType)return true; return false;});
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
                CollisionComponent collisionComponent=GetComponent<CollisionComponent>(typeof(CollisionComponent));
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
            CollisionComponent collisionComponent=GetComponent<CollisionComponent>(typeof(CollisionComponent));
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