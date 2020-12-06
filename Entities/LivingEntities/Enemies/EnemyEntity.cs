using System;
using System.Collections.Generic;
using Fish_Girlz.Art;
using Fish_Girlz.Utils;
using Fish_Girlz.States;
using SFML.System;
using System.Collections;

namespace Fish_Girlz.Entities{
    public abstract class EnemyEntity : LivingEntity
    {
        protected int damage;

        public EnemyEntity(Vector2f position, SpriteInfo sprite, int maxHealth, int damage) : base(position, sprite, maxHealth)
        {
            this.damage=damage;
            base.OnCollision+=Collision;
        }

        private void Collision(object sender, CollisionEventArgs e){
            if(e.Other is PlayerEntity){
                PlayerStats.Store("enemy 0", this);
                List<Entity> nearbyEntities=GetNearbyEntities(StateMachine.ActiveState.GetEntities(), typeof(PlayerEntity));
                nearbyEntities.Sort(delegate(Entity x, Entity y){
                    return x.Position.Distance(Position).CompareTo(y.Position.Distance(Position));
                });
                for (int i = 0; i < Math.Min(2, nearbyEntities.Count); i++)
                {
                    PlayerStats.Store($"enemy {i+1}", nearbyEntities[i]);
                }
                StateMachine.AddState(new BattleState(), false);
            }
        }
    }
}