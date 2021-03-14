using Fish_Girlz.Systems;

namespace Fish_Girlz.Utils{
    public static class Assets {
        public static void Load(){
            AssetManager.LoadFont("Arial", "Assets/fonts/arial.ttf");

            AssetManager.LoadTexture("Temp", "Assets/textures/temp.png");

            AssetManager.LoadTexture("Wall", "Assets/textures/tiles/wall.png");
            AssetManager.LoadTexture("Sand", "Assets/textures/tiles/sand.png");
            AssetManager.LoadTexture("Water", "Assets/textures/tiles/water.png");
            AssetManager.LoadTexture("Deep Water", "Assets/textures/tiles/deepWater.png");
            
            AssetManager.LoadSpritesheet("Dominique Spritesheet", "Assets/textures/entities/characters/Dominique/spritesheet.png", 64, 64);

            Logger.Log("Assets Loaded!");
        }
    }
}