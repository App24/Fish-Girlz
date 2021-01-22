using System;
using Fish_Girlz.Entities;

namespace Fish_Girlz.API{
    public class EntityLoader : APILoader
    {
        internal EntityLoader(string id) : base(id)
        {
        }

        public void AddEntity(Entity entity){
            Entity.AddEntity(entity, ID);
        }
    }
}