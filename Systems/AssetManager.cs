using System;
using System.Collections.Generic;
using Fish_Girlz.Art;
using SFML;
using SFML.Audio;
using SFML.Graphics;
using System.IO;

namespace Fish_Girlz.Systems
{
    public static class AssetManager
    {
        private static Dictionary<string, Texture> textures = new Dictionary<string, Texture>();
        private static Dictionary<string, Font> fonts = new Dictionary<string, Font>();
        private static Dictionary<string, SoundBuffer> soundBuffers = new Dictionary<string, SoundBuffer>();
        private static Dictionary<string, SpriteSheet> spriteSheets = new Dictionary<string, SpriteSheet>();
        private static Dictionary<string, object> objects = new Dictionary<string, object>();

        public static void LoadTexture(string name, string filePath)
        {
            try
            {
                Logger.Log($"Loading Texture: {name}, File: {filePath}");
                if(textures.ContainsKey(name.ToLower())){
                    Logger.Log($"Texture Already Loaded: {name}", Logger.LogLevel.Warn);
                    return;
                }
                Texture texture = new Texture(filePath);
                textures.Add(name.ToLower(), texture);
                //Collision.CreateBitmask(texture);
            }
            catch (LoadingFailedException e)
            {
                Logger.Log($"Failed To Load Texture From File \"{filePath}\"", Logger.LogLevel.Error);
                throw e;
            }
        }

        public static void LoadSpriteSheet(string name, string filePath, int spriteWidth, int spriteHeight)
        {
            try
            {
                Logger.Log($"Loading Spritesheet: {name}, File: {filePath}");
                if(spriteSheets.ContainsKey(name.ToLower())){
                    Logger.Log($"Spritesheet Already Loaded: {name}", Logger.LogLevel.Warn);
                    return;
                }
                Texture texture = new Texture(filePath);
                SpriteSheet spriteSheet = new SpriteSheet(texture, spriteWidth, spriteHeight);
                spriteSheets.Add(name.ToLower(), spriteSheet);
            }
            catch (LoadingFailedException e)
            {
                Logger.Log($"Failed To Load Spritesheet From File \"{filePath}\"", Logger.LogLevel.Error);
                throw e;
            }
        }

        public static void LoadFont(string name, string filePath)
        {
            try
            {
                Logger.Log($"Loading Font: {name}, File: {filePath}");
                if(fonts.ContainsKey(name.ToLower())){
                    Logger.Log($"Font Already Loaded: {name}", Logger.LogLevel.Warn);
                    return;
                }
                fonts.Add(name.ToLower(), new Font(filePath));
            }
            catch (LoadingFailedException e)
            {
                Logger.Log($"Failed To Load Font From File \"{filePath}\"", Logger.LogLevel.Error);
                throw e;
            }
        }

        public static void LoadSoundBuffer(string name, string filePath)
        {
            try
            {
                Logger.Log($"Loading Sound Buffer: {name}, File: {filePath}");
                if(fonts.ContainsKey(name.ToLower())){
                    Logger.Log($"Sound Buffer Already Loaded: {name}", Logger.LogLevel.Warn);
                    return;
                }
                SoundBuffer soundBuffer = new SoundBuffer(filePath);
                soundBuffers.Add(name.ToLower(), soundBuffer);
            }
            catch (LoadingFailedException e)
            {
                Logger.Log($"Failed To Load Sound Buffer From File \"{filePath}\"", Logger.LogLevel.Error);
                throw e;
            }
        }

        public static void LoadObject(string name, object value){
            if(objects.ContainsKey(name)) return;
            objects.Add(name, value);
        }

        public static Texture GetTexture(string name)
        {
            Texture tex;
            bool successful = textures.TryGetValue(name.ToLower(), out tex);
            if(!successful)
                throw new NoAssetException("Texture", name);
            return tex;
        }

        public static Font GetFont(string name)
        {
            Font font;
            bool successful = fonts.TryGetValue(name.ToLower(), out font);
            if(!successful)
                throw new NoAssetException("Font", name);
            return font;
        }

        public static SoundBuffer GetSoundBuffer(string name)
        {
            SoundBuffer soundBuffer;
            bool successful = soundBuffers.TryGetValue(name.ToLower(), out soundBuffer);
            if(!successful)
                throw new NoAssetException("Sound Buffer", name);
            return soundBuffer;
        }

        public static SpriteSheet GetSpriteSheet(string name)
        {
            SpriteSheet spriteSheet;
            bool successful = spriteSheets.TryGetValue(name.ToLower(), out spriteSheet);
            if(!successful)
                throw new NoAssetException("Spritesheet", name);
            return spriteSheet;
        }

        public static T GetObject<T>(string name)
        {
            object obj;
            bool successful = objects.TryGetValue(name, out obj);
            if(!successful)
                throw new Exception("Could not find any object by the name of "+name);
            return (T)obj;
        }

        public static void CleanUp(){
            foreach (KeyValuePair<string, Texture> item in textures)
            {
                item.Value.Dispose();
            }
            foreach (KeyValuePair<string, SpriteSheet> item in spriteSheets)
            {
                item.Value.Texture.Dispose();
            }
            foreach (KeyValuePair<string, Font> item in fonts)
            {
                item.Value.Dispose();
            }
            foreach (KeyValuePair<string, SoundBuffer> item in soundBuffers)
            {
                item.Value.Dispose();
            }
            Logger.Log("Assets Cleaned!");
        }
    }

    class NoAssetException : Exception{
        public NoAssetException(string assetType, string assetName) : base($"Could Not Find Any {assetType} By The Name Of \"{assetName}\""){
            Logger.Log($"Could Not Find Any {assetType} By The Name Of \"{assetName}\"", Logger.LogLevel.Error);
        }
    }
}
