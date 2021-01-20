using System;

namespace Fish_Girlz.API{
    public abstract class APIPlugin {

        public abstract void OnLoad();
        public abstract void LoadAssets(AssetManager assetManager);
        public abstract void OnUnload();
    }
}