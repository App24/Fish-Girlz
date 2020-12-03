using System;
using System.Collections.Generic;
using Fish_Girlz.Entities;
using Fish_Girlz.States;
using Fish_Girlz.Entities.Tiles;
using Fish_Girlz.UI;

namespace Fish_Girlz.Utils{
    public static class LogicSystem {
        public static void Update(){
            State currentState=StateMachine.ActiveState;
            UpdateTiles(currentState.GetTiles());
            UpdateEntities(currentState.GetEntities());
            UpdateGUI(currentState.GetGUIs());
        }

        static void UpdateGUI(List<GUI> guis){
            foreach (GUI gui in guis)
            {
                if(gui is UpdatableGUI){
                    UpdatableGUI updatableGUI=(UpdatableGUI)gui;
                    updatableGUI.Update();
                }
            }
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