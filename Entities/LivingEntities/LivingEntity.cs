using System;
using Fish_Girlz.Art;
using SFML.System;
using Fish_Girlz.Utils;

namespace Fish_Girlz.Entities{
    public abstract class LivingEntity : Entity
    {
        public int MaxHealth {get; protected set;}
        public int Health {get; protected set;}

        public bool Colliding{get;protected set;}

        protected Vector2f Movement{get; set;}

        public LivingEntity(Vector2f position, SpriteInfo sprite, int maxHealth) : base(position, sprite)
        {
            MaxHealth=maxHealth;
            Health=maxHealth;
        }
    
        public void Damage(int amount){
            if(amount<0) Heal(Math.Abs(amount));
            Health-=amount;
            if(Health<=0)
                Die();
        }

        public void Heal(int amount){
            if(amount<0) Damage(Math.Abs(amount));
            Health+=amount;
            if(Health>MaxHealth)
                Health=MaxHealth;
        }

        private void Die(){
            ToRemove=true;
            OnDeath();
        }

        protected abstract void OnDeath();

        public abstract void Move();

        public void CheckCollision(Entity entity){
            Position+=Movement;
            if(entity!=null){
                if (this.CollideWithEntity(entity))
                {
                    Colliding=true;
                }
            }
            Position -= Movement;
        }

        public void CheckMovement(){
            if(!Colliding){
                Position+=Movement;
            }
            Movement=new Vector2f();
            Colliding=false;
        }

    }
}