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
            AssetManager.LoadSpriteSheet("dominique", "res/dominique spritesheet.png", 64, 64);
            AssetManager.LoadTexture("temp", "res/temp player.png");
            AssetManager.LoadSoundBuffer("Button Click", "res/audio/button_click.wav");
            AssetManager.LoadFont("Arial", "res/fonts/arial.ttf");
            AssetManager.LoadObject("Button Font", new FontInfo(AssetManager.GetFont("Arial"), 30));
        }
    }
}
