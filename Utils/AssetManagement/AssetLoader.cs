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
            AssetManager.LoadSpriteSheet("dominique", "res/textures/Characters/Dominique/spritesheet.png", 64, 64);

            AssetManager.LoadTexture("dominique portrait", "res/textures/Characters/Dominique/portrait.png");
            AssetManager.LoadTexture("astra portrait", "res/textures/Characters/Astra/portrait.png");
            AssetManager.LoadTexture("laurely portrait", "res/textures/Characters/Laurely/portrait.png");

            AssetManager.LoadTexture("temp", "res/textures/temp player.png");
            AssetManager.LoadSoundBuffer("Button Click", "res/audio/button_click.wav");
            AssetManager.LoadFont("Arial", "res/fonts/arial.ttf");
            AssetManager.LoadObject("Button Font", new FontInfo(AssetManager.GetFont("Arial"), 30));
            AssetManager.LoadObject("Title Font", new FontInfo(AssetManager.GetFont("Arial"), 40));
            AssetManager.LoadObject("Input Font", new FontInfo(AssetManager.GetFont("Arial"), 40));

            AssetManager.LoadTexture("DialogBoxTopLeft", "res/textures/UI/Dialog Box/Top Left Corner.png");
            AssetManager.LoadTexture("DialogBoxTopRight", "res/textures/UI/Dialog Box/Top Right Corner.png");
            AssetManager.LoadTexture("DialogBoxBottomLeft", "res/textures/UI/Dialog Box/Bottom Left Corner.png");
            AssetManager.LoadTexture("DialogBoxBottomRight", "res/textures/UI/Dialog Box/Bottom Right Corner.png");
            AssetManager.LoadTexture("DialogBoxTop", "res/textures/UI/Dialog Box/Top.png");
            AssetManager.LoadTexture("DialogBoxBottom", "res/textures/UI/Dialog Box/Bottom.png");
            AssetManager.LoadTexture("DialogBoxLeft", "res/textures/UI/Dialog Box/Left.png");
            AssetManager.LoadTexture("DialogBoxRight", "res/textures/UI/Dialog Box/Right.png");
            AssetManager.LoadTexture("DialogBoxCenter", "res/textures/UI/Dialog Box/Center.png");
        }
    }
}
