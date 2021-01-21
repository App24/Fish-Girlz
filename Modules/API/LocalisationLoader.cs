using System;
using Fish_Girlz.Localisation;

namespace Fish_Girlz.API{
    public class LocalisationLoader : APILoader
    {
        public LocalisationLoader(string id) : base(id)
        {
        }

        public void AddLocalisation(string key, string name){
            Language.GetDefault().AddLocalisation(key, name);
        }

        public void AddItemLocalisation(string key, string name){
            AddLocalisation($"{ID}.item.{key}", name);
        }
    }
}