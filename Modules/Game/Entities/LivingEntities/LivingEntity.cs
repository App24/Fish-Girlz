using System;
using Fish_Girlz.Art;
using SFML.System;
using SFML.Graphics;
using Fish_Girlz.Utils;

namespace Fish_Girlz.Entities{
    public abstract class LivingEntity : Entity
    {
        public int MaxHealth {get; protected set;}
        public int Health {get; protected set;}

        public EntityStats Stats{get;protected set;}

        public LivingEntity(string id, string name, int maxHealth, Texture texture) : this(id, name, maxHealth, texture, new Vector2i())
        {
        }

        public LivingEntity(string id, string name, int maxHealth, Texture texture, Vector2i offset) : base(id, name, texture, offset)
        {
            MaxHealth=maxHealth;
            Health=maxHealth;
            Stats=new EntityStats(2,2,2,2,2,2,2);
        }
    
        public void Damage(int amount){
            if(amount<0){
                Heal(Math.Abs(amount));
                return;
            }
            Health-=amount;
            if(Health<=0)
                Die();
        }

        public void Heal(int amount){
            if(amount<0){
                Damage(Math.Abs(amount));
                return;
            }
            Health+=amount;
            if(Health>MaxHealth)
                Health=MaxHealth;
        }

        private void Die(){
            EntityEntity.ToRemove=true;
            OnDeath();
        }

        protected abstract void OnDeath();

        

    }
}