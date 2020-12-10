using System;
using System.Collections.Generic;
using Fish_Girlz.Entities;
using Fish_Girlz.States;
using Fish_Girlz.Entities.Tiles;
using Fish_Girlz.Entities.Components;
using Fish_Girlz.UI;

namespace Fish_Girlz.Utils{
    public static class LogicSystem {
        public static void Update(){
            State currentState=StateMachine.ActiveState;
            UpdateTiles(currentState);
            UpdateEntities(currentState);
            UpdateGUI(currentState);
        }

        static void UpdateGUI(State currentState){
            List<GUI> guis=currentState.GetGUIs();
            List<GUI> newGuis=new List<GUI>();
            foreach (GUI gui in guis)
            {
                if(gui is UpdatableGUI){
                    UpdatableGUI updatableGUI=(UpdatableGUI)gui;
                    updatableGUI.Update();
                }
                if(!gui.ToRemove)
                    newGuis.Add(gui);
            }
            guis.Clear();
            guis.AddRange(newGuis);
        }

        static void UpdateEntities(State currentState){
            List<Entity> entities=currentState.GetEntities();
            List<Entity> newEntities=new List<Entity>();
            foreach (Entity entity in entities)
            {
                entity.Update(currentState);
                List<EntityComponent> components=entity.GetComponents();
                foreach (EntityComponent component in components)
                {
                    component.Update(currentState.GetPlayer(), currentState.GetDialogBox());
                }
                if(!entity.ToRemove){
                    newEntities.Add(entity);
                }
            }
            entities.Clear();
            entities.AddRange(newEntities);
        }

        static void UpdateTiles(State currentState){
            List<TileEntity> tiles=currentState.GetTiles();
            List<TileEntity> newTiles=new List<TileEntity>();
            foreach (TileEntity tile in tiles)
            {
                tile.Update(currentState);
                if(!tile.ToRemove)
                    newTiles.Add(tile);
            }
            tiles.Clear();
            tiles.AddRange(newTiles);
        }
    }
}