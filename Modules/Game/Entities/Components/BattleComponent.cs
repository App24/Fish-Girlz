using System;
using System.Collections.Generic;
using Fish_Girlz.Battle;
using Fish_Girlz.Systems;
using Fish_Girlz.Utils;
using Fish_Girlz.Entities;

namespace Fish_Girlz.Entities.Components{
    public class BattleComponent : EntityComponent
    {
        public override void Init()
        {

        }

        public CollisionBehaviour OnEnterCollision(CollisionEventArgs e){
            if(e.Other.Entity is PlayerEntity){
                if(!(ParentEntity is LivingEntity)) return CollisionBehaviour.Collision;
                List<EntityEntity> nearbyEntities=ParentEntity.EntityEntity.GetNearbyEntitiesWithComponent<BattleComponent, EntityEntity>(StateMachine.ActiveState.GetEntities());
                List<EntityEntity> nearbyLivingEntities=nearbyEntities.FindAll(delegate(EntityEntity other){if(other.Entity is LivingEntity)return true; return false;});
                EntityEntity[] enemies=new EntityEntity[2];
                for (int i = 0; i < Math.Min(2, nearbyLivingEntities.Count); i++)
                {
                    enemies[i]=nearbyLivingEntities[i];
                }
                BattleData battleData=new BattleData((PlayerEntity)e.Other.Entity, (LivingEntity)ParentEntity, (LivingEntity)enemies[0].Entity, (LivingEntity)enemies[1].Entity);
                BattleSystem.TriggerBattle(battleData);
            }
            return CollisionBehaviour.Collision;
        }
    }
}