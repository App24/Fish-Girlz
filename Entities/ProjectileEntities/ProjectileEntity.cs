using System;
using Fish_Girlz.Art;
using Fish_Girlz.Utils;
using Fish_Girlz.States;
using SFML.System;

namespace Fish_Girlz.Entities{
    public abstract class ProjectileEntity : Entity
    {
        protected int damage;

        protected bool removeOnImpact;

        private LivingEntity originEntity;

        public ProjectileEntity(Vector2f position, SpriteInfo sprite, int damage) : this(position, sprite, damage, null)
        {
        }

        public ProjectileEntity(Vector2f position, SpriteInfo sprite, int damage, LivingEntity originEntity) : base(position, sprite)
        {
            this.damage=damage;
            this.originEntity=originEntity;
            Collidable=false;
            OnCollision+=Collision;
            removeOnImpact=true;
        }

        private void Collision(object sender, CollisionEventArgs e){
            if(e.Other is LivingEntity){
                LivingEntity livingEntity=(LivingEntity)e.Other;
                if(livingEntity!=originEntity){
                    livingEntity.Damage(damage);
                    if(removeOnImpact)
                    ToRemove=true;
                }
            }
        }
    }
}