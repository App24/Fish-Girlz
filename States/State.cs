using Fish_Girlz.UI;
using Fish_Girlz.Entities;
using Fish_Girlz.Utils;
using System.Collections.Generic;
using SFML.Graphics;

namespace Fish_Girlz.States{
    public abstract class State {
        
        List<GUI> toAddGuis=new List<GUI>();
        List<GUI> guis=new List<GUI>();

        List<Entity> toAddEntities=new List<Entity>();
        List<Entity> entities=new List<Entity>();

        List<TileEntity> tileEntities=new List<TileEntity>();
        List<TileEntity> toAddTileEntities=new List<TileEntity>();

        List<Sprite> sprites=new List<Sprite>();

        public abstract void Init();
        public abstract void Update();
        public abstract void HandleInput();

        public virtual void Resume(){}
        public virtual void Pause(){}
        public virtual void Remove(){}

        public void StateLogic(){
            guis.AddRange(toAddGuis);
            toAddGuis.Clear();

            entities.AddRange(toAddEntities);
            toAddEntities.Clear();

            tileEntities.AddRange(toAddTileEntities);
            toAddTileEntities.Clear();
        }

        public List<GUI> GetGUIs(){
            return guis.Clone();
        }

        public List<Entity> GetEntities(){
            return entities.Clone();
        }

        public List<TileEntity> GetTileEntities(){
            return tileEntities.Clone();
        }

        public List<Sprite> GetSprites(){
            return sprites.Clone();
        }

        public void RemoveGUI<T>(T gui) where T : GUI{
            if(guis.Contains(gui)){
                guis.Remove(gui);
            }else if(toAddGuis.Contains(gui)){
                toAddGuis.Remove(gui);
            }
        }

        public void RemoveEntity<T>(T entity) where T : Entity{
            if(entities.Contains(entity)){
                entities.Remove(entity);
            }else if(toAddEntities.Contains(entity)){
                toAddEntities.Remove(entity);
            }
        }

        public void RemoveTileEntity<T>(T tileEntity) where T : TileEntity{
            if(tileEntities.Contains(tileEntity)){
                tileEntities.Remove(tileEntity);
            }else if(toAddTileEntities.Contains(tileEntity)){
                toAddTileEntities.Remove(tileEntity);
            }
        }

        public void RemoveSprite(Sprite sprite){
            if(sprites.Contains(sprite)){
                sprites.Remove(sprite);
            }
        }

        protected T AddGUI<T>(T gui) where T:GUI{
            toAddGuis.Add(gui);
            return gui;
        }

        protected T AddEntity<T>(T entity) where T : Entity{
            toAddEntities.Add(entity);
            return entity;
        }

        protected T AddTileEntity<T>(T tileEntity) where T : TileEntity{
            toAddTileEntities.Add(tileEntity);
            return tileEntity;
        }

        protected Sprite AddSprite(Sprite sprite){
            sprites.Add(sprite);
            return sprite;
        }

    }
}