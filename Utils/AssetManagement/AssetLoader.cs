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
            AssetManager.LoadSpriteSheet("dominique", "res/textures/Characters/Dominique/spritesheet", 64, 64);

            AssetManager.LoadTexture("dominique portrait", "res/textures/Characters/Dominique/portrait");
            AssetManager.LoadTexture("astra portrait", "res/textures/Characters/Astra/portrait");
            AssetManager.LoadTexture("laurely portrait", "res/textures/Characters/Laurely/portrait");

            AssetManager.LoadTexture("potion", "res/textures/Items/potion");

            AssetManager.LoadTexture("temp", "res/textures/temp player");
            AssetManager.LoadSoundBuffer("Button Click", "res/audio/button_click");
            AssetManager.LoadFont("Arial", "res/fonts/arial");
            AssetManager.LoadObject("Button Font", new FontInfo(AssetManager.GetFont("Arial"), 30));
            AssetManager.LoadObject("Title Font", new FontInfo(AssetManager.GetFont("Arial"), 40));
            AssetManager.LoadObject("Input Font", new FontInfo(AssetManager.GetFont("Arial"), 40));

            AssetManager.LoadTexture("DialogBoxTopLeft", "res/textures/UI/Dialog Box/Top Left Corner");
            AssetManager.LoadTexture("DialogBoxTopRight", "res/textures/UI/Dialog Box/Top Right Corner");
            AssetManager.LoadTexture("DialogBoxBottomLeft", "res/textures/UI/Dialog Box/Bottom Left Corner");
            AssetManager.LoadTexture("DialogBoxBottomRight", "res/textures/UI/Dialog Box/Bottom Right Corner");
            AssetManager.LoadTexture("DialogBoxTop", "res/textures/UI/Dialog Box/Top");
            AssetManager.LoadTexture("DialogBoxBottom", "res/textures/UI/Dialog Box/Bottom");
            AssetManager.LoadTexture("DialogBoxLeft", "res/textures/UI/Dialog Box/Left");
            AssetManager.LoadTexture("DialogBoxRight", "res/textures/UI/Dialog Box/Right");
            AssetManager.LoadTexture("DialogBoxCenter", "res/textures/UI/Dialog Box/Center");
        }
    }
}
