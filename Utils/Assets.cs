using Fish_Girlz.Systems;

namespace Fish_Girlz.Utils{
    public static class Assets {
        public static void Load(){
            AssetManager.LoadFont("Arial", "Assets/fonts/arial.ttf");

            AssetManager.LoadTexture("Temp", "Assets/textures/temp.png");
            
            AssetManager.LoadSpritesheet("Dominique Spritesheet", "Assets/textures/entities/characters/Dominique/spritesheet.png", 64, 64);

            Logger.Log("Assets Loaded!");
        }
    }
}