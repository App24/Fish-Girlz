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
                List<Entity> nearbyEntities=entity.GetNearbyEntities(entities);
                List<TileEntity> nearbyTiles=entity.GetNearbyEntities(tiles);
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
                entity.CheckMovement();
            }
        }
    }
}