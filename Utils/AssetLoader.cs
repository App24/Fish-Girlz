using System;
using System.Collections.Generic;
using SFML.Graphics;

namespace Fish_Girlz.Utils
{
    public static class AssetLoader
    {
        public static void LoadAssets()
        {
            AssetManager.LoadSpriteSheet("dominique", "res/dominique spritesheet.png", 64, 64);
            AssetManager.LoadTexture("temp", "res/temp player.png");
            AssetManager.LoadSoundBuffer("Button Click", "res/audio/button_click.wav");
            AssetManager.LoadFont("Arial", "res/fonts/arial.ttf");
        }
    }
}
