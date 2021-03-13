using Fish_Girlz.Systems;

namespace Fish_Girlz.Utils{
    public static class Assets {
        public static void Load(){
            AssetManager.LoadFont("Arial", "Assets/fonts/arial.ttf");
            Logger.Log("Assets Loaded!");
        }
    }
}