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

        static void CheckCollisions(List<Entity> entities, List<TileEntity> tiles, List<ItemEntity> items){
            foreach (Entity entity in entities)
            {
                List<Entity> nearbyEntities=entity.GetNearbyEntities(entities);
                List<TileEntity> nearbyTiles=entity.GetNearbyEntities(tiles);
                List<ItemEntity> nearbyItems=entity.GetNearbyEntities(items);
                entity.Move();
                entity.Speed*=Delta.DeltaTime;
                foreach (Entity nearbyEntity in nearbyEntities)
                {
                    entity.CheckCollision(nearbyEntity);
                }
                foreach (TileEntity nearbyTile in nearbyTiles)
                {
                    entity.CheckCollision(nearbyTile);
                }
                foreach (ItemEntity item in nearbyItems)
                {
                    entity.CheckCollision(item);
                }
                entity.CheckMovement();
            }
        }
    }
}