using System;
using Fish_Girlz.Art;
using Fish_Girlz.UI;
using Fish_Girlz.Entities;
using System.Collections.Generic;

namespace Fish_Girlz.States{
    public abstract class State {
        protected List<LayeredSprite> sprites=new List<LayeredSprite>();
        protected List<GUI> guis=new List<GUI>();
        protected List<Entity> entities=new List<Entity>();

        public abstract void Init();
        public abstract void HandleInput();
        public abstract void Update();
        public virtual void Pause(){
            
        }
        public virtual void Resume(){
            
        }
        public virtual void Remove(){
            
        }

        public List<LayeredSprite> GetSprites(){
            return sprites;
        }

        public List<GUI> GetGUIs(){
            return guis;
        }

        public List<Entity> GetEntities(){
            return entities;
        }

        protected void CheckCollisions(){
            foreach (Entity entity in entities)
            {
                if(entity is LivingEntity){
                    LivingEntity livingEntity=(LivingEntity)entity;
                    List<Entity> nearbyEntities=livingEntity.GetNearbyEntities(entities);
                    livingEntity.Move();
                    foreach (Entity nearbyEntity in nearbyEntities)
                    {
                        livingEntity.CheckCollision(nearbyEntity);
                    }
                    livingEntity.CheckMovement();
                }
            }
        }
    }
}