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

namespace Fish_Girlz.States{
    public abstract class State {
        protected List<LayeredSprite> sprites=new List<LayeredSprite>();
        private List<GUI> guis=new List<GUI>();
        private List<Entity> entities=new List<Entity>();
        protected List<TileEntity> tileEntities=new List<TileEntity>();

        private List<Entity> toAddEntities=new List<Entity>();
        private List<TileEntity> toAddTileEntities=new List<TileEntity>();
        private List<GUI> toAddGuis=new List<GUI>();

        #if (DEV || DEBUG)
            private UIText dev;
        #endif

        public void InitState(){
            #if DEV
                dev=new UIText(new FontInfo(AssetManager.GetFont("Arial"), 24), "Development Build", Color.White, new Vector2f(DisplayManager.Width-214,DisplayManager.Height-30));
            #elif DEBUG
                dev=new UIText(new FontInfo(AssetManager.GetFont("Arial"), 24), "Debug Build", Color.White, new Vector2f(DisplayManager.Width-140,DisplayManager.Height-30));
            #endif
            #if (DEV || DEBUG)
                dev.OutlineColor=Color.Black;
                dev.OutlineThickness=2;
                dev.TextColor=Color.White;
                guis.Add(dev);
            #endif
        }

        public abstract void Init();
        public abstract void HandleInput();
        public abstract void Update();
        public virtual void Pause(){
            
        }
        public virtual void Resume(){
            
        }
        public virtual void Remove(){
            
        }
        public void StateLogic(){
            entities.AddRange(toAddEntities);
            toAddEntities.Clear();

            tileEntities.AddRange(toAddTileEntities);
            toAddTileEntities.Clear();

            guis.AddRange(toAddGuis);
            toAddGuis.Clear();
        }

        public List<LayeredSprite> GetSprites(){
            return sprites;//.Clone();
        }

        public List<GUI> GetGUIs(){
            return guis;//.Clone();
        }

        public List<Entity> GetEntities(){
            return entities;//.Clone();
        }

        public List<TileEntity> GetTiles(){
            return tileEntities;//.Clone();
        }

        public Entity AddEntity(Entity entity){
            toAddEntities.Add(entity);
            return entity;
        }

        public TileEntity AddTileEntity(TileEntity tileEntity){
            toAddTileEntities.Add(tileEntity);
            return tileEntity;
        }

        public GUI AddGUI(GUI gui){
            toAddGuis.Add(gui);
            return gui;
        }
    }
}