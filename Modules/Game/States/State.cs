using System;
using Fish_Girlz.Art;
using Fish_Girlz.UI;
using Fish_Girlz.Entities;
using Fish_Girlz.Entities.Tiles;
using System.Collections.Generic;
using Fish_Girlz.UI.Components;
using Fish_Girlz.Utils;
using SFML.Graphics;
using SFML.System;
using Fish_Girlz.Entities.Items;
using Fish_Girlz.Systems;

namespace Fish_Girlz.States{
    public abstract class State {
        protected List<LayeredSprite> sprites=new List<LayeredSprite>();
        private List<GUI> guis=new List<GUI>();
        protected List<EntityEntity> entities=new List<EntityEntity>();
        protected List<EntityEntity> tileEntities=new List<EntityEntity>();
        protected List<EntityEntity> itemEntities=new List<EntityEntity>();

        private List<EntityEntity> toAddEntities=new List<EntityEntity>();
        private List<EntityEntity> toAddTileEntities=new List<EntityEntity>();
        private List<GUI> toAddGuis=new List<GUI>();
        private List<EntityEntity> toAddItems=new List<EntityEntity>();

        internal abstract void Init();
        internal abstract void HandleInput();
        internal abstract void Update();
        internal virtual void Pause(){
            
        }
        internal virtual void Resume(){
            
        }
        internal virtual void Remove(){
            
        }
        internal void StateLogic(){
            entities.AddRange(toAddEntities);
            toAddEntities.Clear();

            tileEntities.AddRange(toAddTileEntities);
            toAddTileEntities.Clear();

            guis.AddRange(toAddGuis);
            toAddGuis.Clear();

            itemEntities.AddRange(toAddItems);
            toAddItems.Clear();
        }

        internal List<LayeredSprite> GetSprites(){
            return sprites;//.Clone();
        }

        internal List<GUI> GetGUIs(){
            return guis;//.Clone();
        }

        internal List<EntityEntity> GetEntities(){
            return entities;//.Clone();
        }

        internal List<EntityEntity> GetTileEntities(){
            return tileEntities;//.Clone();
        }

        internal List<EntityEntity> GetItems(){
            return itemEntities;
        }

        internal T AddEntity<T>(T entity) where T: EntityEntity{
            toAddEntities.Add(entity);
            return entity;
        }

        internal T AddTileEntity<T>(T tileEntity) where T : EntityEntity{
            toAddTileEntities.Add(tileEntity);
            return tileEntity;
        }

        internal T AddGUI<T>(T gui) where T:GUI{
            toAddGuis.Add(gui);
            return gui;
        }

        internal T AddItem<T>(T item) where T : EntityEntity{
            toAddItems.Add(item);
            return item;
        }
    }
}