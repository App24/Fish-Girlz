using System;
using System.Collections.Generic;
using Fish_Girlz.Art;
using SFML.Graphics;
using Fish_Girlz.Utils;
using Fish_Girlz.Entities.Components;
using Fish_Girlz.States;
using SFML.System;

namespace Fish_Girlz.Entities{
    public abstract class Entity {
        public string ID{get; private set;}
        public string Name{get; private set;}
        public SpriteInfo Sprite{get; protected set;}

        static List<Entity> entities=new List<Entity>();
        static List<Entity> mapEntities=new List<Entity>();
        List<EntityComponent> components=new List<EntityComponent>();

        public EntityEntity EntityEntity{get;set;}

        public virtual bool ShowOnMapEditor=>true;
        public virtual int Max=>0;

        public Entity(string id, string name, Texture texture, Vector2i offset){
            ID=id;
            Name=name;
            if(!Name.StartsWith("entity.")) Name=$"entity.{Name}";
            Sprite=new SpriteInfo(texture, new IntRect(offset.X,offset.Y,Statics.UNIT_SIZE, Statics.UNIT_SIZE));
        }

        public Entity(string id, string name, Texture texture):this(id,name,texture,new Vector2i()){
        }

        internal static void AddEntity<T>(T entity, string modId="") where T:Entity{
            if(entity.Max>0){
                if(entities.FindAll(delegate(Entity other){return other.GetType().IsSubclassOf(entity.GetType());}).Count>=entity.Max) return;
            }
            if(!string.IsNullOrEmpty(modId)){
                entity.ID=$"{modId}.{entity.ID}";
                entity.Name=$"{modId}.{entity.Name}";
            }
            if(entities.Find(delegate(Entity other){if(other.ID==entity.ID) return true; return false;})!=null) return;
            entities.Add(entity);
            if(entity.ShowOnMapEditor) mapEntities.Add(entity);
        }

        public static Entity GetEntity(string id){
            return entities.Find(delegate(Entity entity){if(entity.ID==id)return true; return false;});
        }

        public static Entity GetMapEntity(string id){
            return mapEntities.Find(delegate(Entity entity){if(entity.ID==id)return true; return false;});
        }

        public static List<Entity> GetEntities(){
            return entities.Clone();
        }

        public static List<Entity> GetMapEntities(){
            return mapEntities.Clone();
        }

        public T GetComponent<T>() where T : EntityComponent{
            EntityComponent component=components.Find(delegate(EntityComponent e){if(e is T)return true; return false;});
            if(component!=null){
                return (T)component;
            }
            return null;
        }

        public T AddComponent<T>(T component) where T:EntityComponent{
            component.ParentEntity=this;
            component.Init();
            components.Add(component);
            return component;
        }

        public List<EntityComponent> GetComponents(){
            return components;
        }

        public abstract void Update(State currentState);

        public abstract void Move();
    }
}