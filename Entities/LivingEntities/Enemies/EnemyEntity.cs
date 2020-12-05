using System;
using Fish_Girlz.Art;
using Fish_Girlz.Utils;
using SFML.System;

namespace Fish_Girlz.Entities{
    public abstract class EnemyEntity : LivingEntity
    {
        protected int damage;
        protected bool collideDamage;

        public EnemyEntity(Vector2f position, SpriteInfo sprite, int maxHealth, int damage) : base(position, sprite, maxHealth)
        {
            this.damage=damage;
            base.OnCollision+=Collision;
            collideDamage=true;
        }

        private void Collision(object sender, CollisionEventArgs e){
            if(e.Other is PlayerEntity){
                PlayerEntity player=(PlayerEntity)e.Other;
                if(collideDamage)
                player.Damage(damage);
            }
        }
    }
}