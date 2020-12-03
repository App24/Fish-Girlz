using System;
using System.Collections.Generic;
using SFML.Graphics;
using Fish_Girlz.UI.Components;

namespace Fish_Girlz.Utils
{
    public static class AssetLoader
    {
        public static void LoadAssets()
        {
            AssetManager.LoadSpriteSheet("dominique", "res/textures/dominique spritesheet", 64, 64);
            AssetManager.LoadTexture("temp", "res/textures/temp player");
            AssetManager.LoadSoundBuffer("Button Click", "res/audio/button_click");
            AssetManager.LoadFont("Arial", "res/fonts/arial");
            AssetManager.LoadObject("Button Font", new FontInfo(AssetManager.GetFont("Arial"), 30));
            AssetManager.LoadObject("Title Font", new FontInfo(AssetManager.GetFont("Arial"), 40));
            AssetManager.LoadObject("Input Font", new FontInfo(AssetManager.GetFont("Arial"), 40));
        }
    }
}
