using System;
using Fish_Girlz.Localisation;

namespace Fish_Girlz.API{
    public class LocalisationLoader : APILoader
    {
        internal LocalisationLoader(string id) : base(id)
        {
        }

        public void AddLocalisation(string key, string name){
            Language.GetDefault().AddLocalisation($"{ID}.{key}", name);
        }

        public void AddItemLocalisation(string key, string name){
            AddLocalisation($"item.{key}", name);
        }

        public void AddTileLocalisation(string key, string name){
            AddLocalisation($"tile.{key}", name);
        }

        public void AddEntityLocalisation(string key, string name){
            AddLocalisation($"entity.{key}", name);
        }
    }
}