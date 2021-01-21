using System;
using Fish_Girlz.Art;
using SFML.System;
using Fish_Girlz.Utils;

namespace Fish_Girlz.Entities{
    public abstract class LivingEntity : Entity
    {
        public int MaxHealth {get; protected set;}
        public int Health {get; protected set;}

        public EntityStats Stats{get;protected set;}

        public LivingEntity(string id, string name, SpriteInfo sprite, int maxHealth) : base(id, name, sprite)
        {
            MaxHealth=maxHealth;
            Health=maxHealth;
            Stats=new EntityStats(2,2,2,2,2,2,2);
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
            EntityEntity.ToRemove=true;
            OnDeath();
        }

        protected abstract void OnDeath();

        

    }
}