using System;
using System.Collections.Generic;
using SFML.Graphics;
using Fish_Girlz.Art;

namespace Fish_Girlz.Systems{
    public static class AssetManager {
        static Dictionary<string, Texture> textures=new Dictionary<string, Texture>();
        static Dictionary<string, Font> fonts=new Dictionary<string, Font>();
        static Dictionary<string, Spritesheet> spritesheets=new Dictionary<string, Spritesheet>();

        public static void LoadTexture(string name, string filePath){
            if(textures.TryGetValue(name, out _)) throw new Exception($"Texture {name} already loaded!");
            try{
                Texture texture=new Texture(filePath);
                textures.Add(name, texture);
            }catch(SFML.LoadingFailedException e){
                throw e;
            }
        }

        public static void LoadFont(string name, string filePath){
            if(fonts.TryGetValue(name, out _)) throw new Exception($"Font {name} already loaded!");
            try{
                Font font=new Font(filePath);
                fonts.Add(name, font);
            }catch(SFML.LoadingFailedException e){
                throw e;
            }
        }

        public static void LoadSpritesheet(string name, string filePath, uint spriteWidth, uint spriteHeight){
            if(spritesheets.TryGetValue(name, out _)) throw new Exception($"Spritesheet {name} already loaded!");
            try{
                Texture texture=new Texture(filePath);
                Spritesheet spritesheet=new Spritesheet(texture, spriteWidth, spriteHeight);
                spritesheets.Add(name, spritesheet);
            }catch(SFML.LoadingFailedException e){
                throw e;
            }
        }

        public static Texture GetTexture(string name){
            if(textures.TryGetValue(name, out Texture texture)){
                return texture;
            }
            throw new Exception($"Texture {name} has not been loaded!");
        }

        public static Font GetFont(string name){
            if(fonts.TryGetValue(name, out Font font)){
                return font;
            }
            throw new Exception($"Font {name} has not been loaded!");
        }

        public static Spritesheet GetSpritesheet(string name){
            if(spritesheets.TryGetValue(name, out Spritesheet spritesheet)){
                return spritesheet;
            }
            throw new Exception($"Spritesheet {name} has not been loaded!");
        }

        public static void CleanUp(){
            foreach (var texture in textures.Values)
            {
                texture.Dispose();
            }

            foreach (var font in fonts.Values)
            {
                font.Dispose();
            }

            Logger.Log("Assets Cleaned!");
        }
    }
}