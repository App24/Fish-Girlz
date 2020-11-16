using System;
using System.Collections.Generic;
using Fish_Girlz.Entities;
using Fish_Girlz.States;
using Fish_Girlz.Entities.Tiles;

namespace Fish_Girlz.Utils{
    public static class LogicSystem {
        public static void Update(){
            State currentState=StateMachine.ActiveState;
            UpdateTiles(currentState.GetTiles());
            UpdateEntities(currentState.GetEntities());
        }

        static void UpdateEntities(List<Entity> entities){
            foreach (Entity entity in entities)
            {
                entity.Update();
            }
        }

        static void UpdateTiles(List<TileEntity> tiles){
            foreach (TileEntity tile in tiles)
            {
                tile.Update();
            }
        }
    }
}