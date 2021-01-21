using System;
using System.Collections.Generic;
using Fish_Girlz.Art;
using Fish_Girlz.Utils;
using Fish_Girlz.States;
using Fish_Girlz.Battle;
using SFML.System;
using System.Collections;
using Fish_Girlz.Entities.Components;
using Fish_Girlz.Systems;

namespace Fish_Girlz.Entities{
    public abstract class EnemyEntity : LivingEntity
    {
        protected int damage;
        protected CollisionComponent collisionComponent;

        public EnemyEntity(string id, string name, SpriteInfo sprite, int maxHealth, int damage) : base(id, name, sprite, maxHealth)
        {
            this.damage=damage;
            collisionComponent=AddComponent(new CollisionComponent());
            collisionComponent.OnCollision+=Collision;
        }

        private void Collision(object sender, CollisionEventArgs e){
            if(e.Other.Entity is PlayerEntity){
                List<EnemyEntity> nearbyEntities=EntityEntity.GetNearbyEnemies(StateMachine.ActiveState.GetEntities());
                EnemyEntity[] enemies=new EnemyEntity[2];
                for (int i = 0; i < Math.Min(2, nearbyEntities.Count); i++)
                {
                    enemies[i]=nearbyEntities[i];
                }
                BattleData battleData=new BattleData((PlayerEntity)e.Other.Entity, this, enemies[0], enemies[1]);
                BattleSystem.TriggerBattle(battleData);
            }
        }
    }
}