using System;
using SFML.Graphics;
using SFML.System;

namespace Fish_Girlz.Entities{
    public abstract class LivingEntity : Entity
    {
        public int MaxHealth{get;}
        public int Health{get;protected set;}

        public LivingEntity(int maxHealth, Vector2f position, Texture texture) : base(position, texture)
        {
            MaxHealth=maxHealth;
            Health=MaxHealth;
        }

        public void Damage(int amount){
            if(amount<0){
                Heal(Math.Abs(amount));
                return;
            }
            Health-=amount;
            if(Health<=0) Die();
        }

        public void Heal(int amount){
            if(amount<0){
                Damage(Math.Abs(amount));
                return;
            }
            Health+=amount;
            if(Health>MaxHealth) Health=MaxHealth;
        }

        void Die(){
            ToRemove=true;
            OnDeath();
        }

        protected abstract void OnDeath();
    }
}