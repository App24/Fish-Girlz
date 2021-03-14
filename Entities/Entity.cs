using System;
using System.Collections.Generic;
using Fish_Girlz.Entities.Components;
using Fish_Girlz.Utils;
using SFML.Graphics;
using SFML.System;

namespace Fish_Girlz.Entities{
    public abstract class Entity {
        List<EntityComponent> components=new List<EntityComponent>();
        public Vector2f Position{get;set;}
        public Vector2f Speed {get; set;}

        public bool ToRemove{get;set;}

        public Texture Texture{get;protected set;}

        public Entity(Vector2f position, Texture texture){
            Position=position;
            Texture=texture;
        }

        public abstract void Update();
        public abstract void Move();

        public List<EntityComponent> GetComponents(){
            return components.Clone();
        }

        protected T GetComponent<T>() where T : EntityComponent{
            EntityComponent component=components.Find(delegate(EntityComponent e){if(e is T)return true; return false;});
            if(component!=null){
                return (T)component;
            }
            return null;
        }

        public void CheckCollision(Entity entity){
            Position+=Speed;
            if(entity!=null){
                // CollisionComponent collisionComponent=GetComponent<CollisionComponent>();
                // if(collisionComponent!=null){
                //     if (this.CollideWithEntity(entity))
                //     {
                //         collisionComponent.Colliding=true;
                //     }
                // }
            }
            Position -= Speed;
        }

        public void CheckMovement(){
            // CollisionComponent collisionComponent=GetComponent<CollisionComponent>();
            // if((collisionComponent!=null&&!collisionComponent.Colliding)||(collisionComponent==null)){
                Position+=Speed;
            // }
            Speed=new Vector2f();
            // if(collisionComponent!=null)
            //     collisionComponent.Colliding=false;
        }

        protected T AddComponent<T>(T component) where T:EntityComponent{
            component.ParentEntity=this;
            component.Init();
            components.Add(component);
            return component;
        }
    }
}