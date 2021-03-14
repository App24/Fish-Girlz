using System.Collections.Generic;
using Fish_Girlz.States;
using Fish_Girlz.UI;
using Fish_Girlz.Entities;
using Fish_Girlz.Utils;

namespace Fish_Girlz.Systems{
    public static class LogicSystem {
        public static void Update(){
            State currentState=StateMachine.ActiveState;
            if(currentState==null) return;
            UpdateGUIs(currentState);
            UpdateEntities(currentState);
            UpdateTileEntities(currentState);
        }

        static void UpdateTileEntities(State currentState){
            List<TileEntity> tileEntities=currentState.GetTileEntities();
            List<TileEntity> removeEntities=new List<TileEntity>();
            foreach (TileEntity entity in tileEntities)
            {
                if(entity.ToRemove){
                    removeEntities.Add(entity);
                    continue;
                }
                entity.Update();
            }
            foreach(TileEntity entity in removeEntities){
                currentState.RemoveTileEntity(entity);
            }
        }

        static void UpdateEntities(State currentState){
            List<Entity> entities=currentState.GetEntities();
            List<Entity> removeEntities=new List<Entity>();
            foreach (Entity entity in entities)
            {
                if(entity.ToRemove){
                    removeEntities.Add(entity);
                    continue;
                }
                entity.Update();
                entity.Move();
                entity.Speed*=Delta.DeltaTime;
                entity.CheckMovement();
            }
            foreach(Entity entity in removeEntities){
                currentState.RemoveEntity(entity);
            }
        }

        static void UpdateGUIs(State currentState){
            List<GUI> guis=currentState.GetGUIs();
            guis.Reverse();
            List<GUI> removeGuis=new List<GUI>();
            foreach (GUI gui in guis)
            {
                if(gui.ToRemove){
                    removeGuis.Add(gui);
                    continue;
                }
                if(gui.Visible)
                if(gui is UpdatableGUI){
                    UpdatableGUI updatableGUI=(UpdatableGUI)gui;
                    updatableGUI.Update();
                }
            }
            foreach (GUI gui in removeGuis)
            {
                currentState.RemoveGUI(gui);
            }
        }
    }
}