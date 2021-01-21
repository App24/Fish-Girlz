using System;
using System.Collections.Generic;
using Fish_Girlz.Entities;
using Fish_Girlz.States;
using Fish_Girlz.Entities.Tiles;
using Fish_Girlz.Entities.Components;
using Fish_Girlz.UI;
using Fish_Girlz.Entities.Items;

namespace Fish_Girlz.Systems{
    public static class LogicSystem {
        public static void Update(){
            State currentState=StateMachine.ActiveState;
            UpdateTileEntities(currentState);
            UpdateItemEntities(currentState);
            UpdateEntities(currentState);
            UpdateGUI(currentState);
        }

        static void UpdateItemEntities(State currentState){
            List<EntityEntity> itemEntities=currentState.GetItems();
            List<EntityEntity> newItems=new List<EntityEntity>();
            foreach (EntityEntity item in itemEntities)
            {
                item.Entity.Update(currentState);
                if(!item.ToRemove){
                    newItems.Add(item);
                }
            }
            itemEntities.Clear();
            itemEntities.AddRange(newItems);
        }

        static void UpdateGUI(State currentState){
            List<GUI> guis=currentState.GetGUIs();
            guis.Reverse();
            List<GUI> newGuis=new List<GUI>();
            foreach (GUI gui in guis)
            {
                if(gui.Visible)
                if(gui is UpdatableGUI){
                    UpdatableGUI updatableGUI=(UpdatableGUI)gui;
                    updatableGUI.Update();
                }
                if(!gui.ToRemove)
                    newGuis.Add(gui);
            }
            newGuis.Reverse();
            guis.Clear();
            guis.AddRange(newGuis);
        }

        static void UpdateEntities(State currentState){
            List<EntityEntity> entities=currentState.GetEntities();
            List<EntityEntity> newEntities=new List<EntityEntity>();
            foreach (EntityEntity entity in entities)
            {
                entity.Entity.Update(currentState);
                if(!entity.ToRemove){
                    newEntities.Add(entity);
                }
            }
            entities.Clear();
            entities.AddRange(newEntities);
        }

        static void UpdateTileEntities(State currentState){
            List<EntityEntity> tiles=currentState.GetTileEntities();
            List<EntityEntity> newTiles=new List<EntityEntity>();
            foreach (EntityEntity tile in tiles)
            {
                tile.Entity.Update(currentState);
                if(!tile.ToRemove)
                    newTiles.Add(tile);
            }
            tiles.Clear();
            tiles.AddRange(newTiles);
        }
    }
}