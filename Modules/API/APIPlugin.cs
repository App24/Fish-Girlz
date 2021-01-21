using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("APILoader")]
namespace Fish_Girlz.API{
    public abstract class APIPlugin {

        internal string ID{get;set;}
        internal string Directory{get;set;}

        public abstract void OnLoad();
        public abstract void LoadItems(ItemLoader itemLoader);
        public abstract void LoadLocalisation(LocalisationLoader localisationLoader);
        public abstract void LoadEntities(EntityLoader entityLoader);
        public abstract void LoadAssets();
        public abstract void OnUnload();
    }
}