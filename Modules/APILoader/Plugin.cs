using System;

namespace Fish_Girlz.API.Loader{
    public class Plugin {
        public APIPlugin APIPlugin{get;}
        public Mod Mod{get;}
        public string Directory{get;}

        public Plugin(APIPlugin apiPlugin, Mod mod, string directory)
        {
            APIPlugin = apiPlugin;
            Mod=mod;
            Directory=directory;
        }
    }
}