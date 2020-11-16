using System;
using System.Collections.Generic;
using Fish_Girlz.Entities;
using Fish_Girlz.States;
using Fish_Girlz.Entities.Tiles;

namespace Fish_Girlz.Utils{
    public static class CollisionSystem {
        public static void CheckCollisions(){
            State currentState=StateMachine.ActiveState;
            CheckCollisions(currentState.GetEntities(), currentState.GetTiles());
        }

        static void CheckCollisions(List<Entity> entities, List<TileEntity> tiles){
            foreach (Entity entity in entities)
            {
                if(entity is LivingEntity){
                    LivingEntity livingEntity=(LivingEntity)entity;
                    List<Entity> nearbyEntities=livingEntity.GetNearbyEntities(entities);
                    List<TileEntity> nearbyTiles=livingEntity.GetNearbyEntities(tiles);
                    //Console.WriteLine(nearbyTiles.ToStringExtended());
                    livingEntity.Move();
                    foreach (Entity nearbyEntity in nearbyEntities)
                    {
                        livingEntity.CheckCollision(nearbyEntity);
                    }
                    foreach (TileEntity nearbyTile in nearbyTiles)
                    {
                        livingEntity.CheckCollision(nearbyTile);
                    }
                    livingEntity.CheckMovement();
                }
            }
        }
    }
}