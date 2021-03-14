using Fish_Girlz.UI;
using Fish_Girlz.Entities;
using Fish_Girlz.Utils;
using System.Collections.Generic;

namespace Fish_Girlz.States{
    public abstract class State {
        
        List<GUI> toAddGuis=new List<GUI>();
        List<GUI> guis=new List<GUI>();

        List<Entity> toAddEntities=new List<Entity>();
        List<Entity> entities=new List<Entity>();

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
        }

        public List<GUI> GetGUIs(){
            return guis.Clone();
        }

        public List<Entity> GetEntities(){
            return entities.Clone();
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

        protected T AddGUI<T>(T gui) where T:GUI{
            toAddGuis.Add(gui);
            return gui;
        }

        protected T AddEntity<T>(T entity) where T : Entity{
            toAddEntities.Add(entity);
            return entity;
        }

    }
}