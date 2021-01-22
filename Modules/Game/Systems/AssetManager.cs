using System;
using System.Collections.Generic;
using Fish_Girlz.Art;
using SFML;
using SFML.Audio;
using SFML.Graphics;
using Fish_Girlz.Utils;
using System.IO;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Fish Girlz")]
[assembly: InternalsVisibleTo("API")]
[assembly: InternalsVisibleTo("APILoader")]
namespace Fish_Girlz.Systems
{
    internal static class AssetManager
    {
        private static Dictionary<string, Texture> textures = new Dictionary<string, Texture>();
        private static Dictionary<string, Font> fonts = new Dictionary<string, Font>();
        private static Dictionary<string, SoundBuffer> soundBuffers = new Dictionary<string, SoundBuffer>();
        private static Dictionary<string, SpriteSheet> spriteSheets = new Dictionary<string, SpriteSheet>();
        private static Dictionary<string, object> objects = new Dictionary<string, object>();

        internal static void LoadTexture(string name, string fileName)
        {
            string filePath=Path.Combine(Utilities.ExecutingFolder, fileName);
            try
            {
                if(textures.ContainsKey(name.ToLower())){
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

        internal static void LoadSpriteSheet(string name, string fileName, int spriteWidth, int spriteHeight)
        {
            string filePath=Path.Combine(Utilities.ExecutingFolder, fileName);
            try
            {
                if(spriteSheets.ContainsKey(name.ToLower())){
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

        internal static void LoadFont(string name, string fileName)
        {
            string filePath=Path.Combine(Utilities.ExecutingFolder, fileName);
            try
            {
                if(fonts.ContainsKey(name.ToLower())){
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

        internal static void LoadSoundBuffer(string name, string fileName)
        {
            string filePath=Path.Combine(Utilities.ExecutingFolder, fileName);
            try
            {
                if(fonts.ContainsKey(name.ToLower())){
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

        internal static void LoadObject(string name, object value){
            if(objects.ContainsKey(name)) return;
            objects.Add(name, value);
        }

        internal static Texture GetTexture(string name)
        {
            Texture tex;
            bool successful = textures.TryGetValue(name.ToLower(), out tex);
            if(!successful)
                throw new NoAssetException("Texture", name);
            return tex;
        }

        internal static Font GetFont(string name)
        {
            Font font;
            bool successful = fonts.TryGetValue(name.ToLower(), out font);
            if(!successful)
                throw new NoAssetException("Font", name);
            return font;
        }

        internal static SoundBuffer GetSoundBuffer(string name)
        {
            SoundBuffer soundBuffer;
            bool successful = soundBuffers.TryGetValue(name.ToLower(), out soundBuffer);
            if(!successful)
                throw new NoAssetException("Sound Buffer", name);
            return soundBuffer;
        }

        internal static SpriteSheet GetSpriteSheet(string name)
        {
            SpriteSheet spriteSheet;
            bool successful = spriteSheets.TryGetValue(name.ToLower(), out spriteSheet);
            if(!successful)
                throw new NoAssetException("Spritesheet", name);
            return spriteSheet;
        }

        internal static T GetObject<T>(string name)
        {
            object obj;
            bool successful = objects.TryGetValue(name, out obj);
            if(!successful)
                throw new Exception("Could not find any object by the name of "+name);
            return (T)obj;
        }

        internal static void CleanUp(){
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
        internal NoAssetException(string assetType, string assetName) : base($"Could Not Find Any {assetType} By The Name Of \"{assetName}\""){
            Logger.Log($"Could Not Find Any {assetType} By The Name Of \"{assetName}\"", Logger.LogLevel.Error);
        }
    }
}