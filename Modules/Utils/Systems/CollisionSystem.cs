using System;
using System.Collections.Generic;
using Fish_Girlz.Entities;
using Fish_Girlz.States;
using Fish_Girlz.Entities.Tiles;
using Fish_Girlz.Entities.Items;
using Fish_Girlz.Utils;

namespace Fish_Girlz.Systems{
    public static class CollisionSystem {
        public static void CheckCollisions(){
            State currentState=StateMachine.ActiveState;
            CheckCollisions(currentState.GetEntities(), currentState.GetTileEntities(), currentState.GetItems());
        }

        static void CheckCollisions(List<EntityEntity> entities, List<EntityEntity> tiles, List<EntityEntity> items){
            foreach (EntityEntity entity in entities)
            {
                List<EntityEntity> nearbyEntities=entity.GetNearbyEntities(entities);
                List<EntityEntity> nearbyTiles=entity.GetNearbyEntities(tiles);
                List<EntityEntity> nearbyItems=entity.GetNearbyEntities(items);
                entity.Entity.Move();
                entity.Speed*=Delta.DeltaTime;
                foreach (EntityEntity nearbyEntity in nearbyEntities)
                {
                    entity.CheckCollision(nearbyEntity);
                }
                foreach (EntityEntity nearbyTile in nearbyTiles)
                {
                    entity.CheckCollision(nearbyTile);
                }
                foreach (EntityEntity item in nearbyItems)
                {
                    entity.CheckCollision(item);
                }
                entity.CheckMovement();
            }
        }
    }
}