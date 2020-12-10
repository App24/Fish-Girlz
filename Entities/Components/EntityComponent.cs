using System;

namespace Fish_Girlz.Entities.Components{
    public abstract class EntityComponent{
        public Entity ParentEntity{get;set;}

        public abstract void Init();

        public abstract void Update(params object[] args);
    }
}