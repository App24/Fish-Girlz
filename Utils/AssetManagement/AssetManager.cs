using System;
using System.Collections.Generic;
using Fish_Girlz.Art;
using SFML;
using SFML.Audio;
using SFML.Graphics;
using System.IO;

namespace Fish_Girlz.Utils
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
                Texture texture = new Texture(filePath);
                LoadTexture(name, texture);
                //Collision.CreateBitmask(texture);
            }
            catch (LoadingFailedException)
            {
                Console.WriteLine("Couldn't load texture: " + filePath);
            }
        }

        public static void LoadTexture(string name, Texture texture){
            textures.Add(name, texture);
        }

        public static void LoadSpriteSheet(string name, string filePath, int spriteWidth, int spriteHeight)
        {
            try
            {
                Texture texture = new Texture(filePath);
                SpriteSheet spriteSheet = new SpriteSheet(texture, spriteWidth, spriteHeight);
                spriteSheets.Add(name, spriteSheet);
                //Collision.CreateBitmask(texture);
            }
            catch (LoadingFailedException)
            {
                Console.WriteLine("Couldn't load texture: " + filePath);
            }
        }

        public static void LoadFont(string name, string filePath)
        {
            try
            {
                Font font = new Font(filePath);
                fonts.Add(name, font);
                //File.Delete(Utilities.GetFileInTemp(name+".ttf"));
            }
            catch (LoadingFailedException)
            {
                Console.WriteLine("Couldn't load font: " + filePath);
            }
        }

        public static void LoadObject(string name, object value){
            objects.Add(name, value);
        }

        public static void LoadSoundBuffer(string name, string filePath)
        {
            try
            {
                SoundBuffer soundBuffer = new SoundBuffer(filePath);
                soundBuffers.Add(name, soundBuffer);
            }
            catch (LoadingFailedException)
            {
                Console.WriteLine("Couldn't load sound buffer: " + filePath);
            }
        }

        public static Texture GetTexture(string name)
        {
            Texture tex;
            bool successful = textures.TryGetValue(name, out tex);
            if(!successful)
                throw new Exception("Could not find any texture by the name of "+name);
            return tex;
        }

        public static Font GetFont(string name)
        {
            Font font;
            bool successful = fonts.TryGetValue(name, out font);
            if(!successful)
                throw new Exception("Could not find any font by the name of "+name);
            return font;
        }

        public static SoundBuffer GetSoundBuffer(string name)
        {
            SoundBuffer soundBuffer;
            bool successful = soundBuffers.TryGetValue(name, out soundBuffer);
            if(!successful)
                throw new Exception("Could not find any sound buffer by the name of "+name);
            return soundBuffer;
        }

        public static SpriteSheet GetSpriteSheet(string name)
        {
            SpriteSheet spriteSheet;
            bool successful = spriteSheets.TryGetValue(name, out spriteSheet);
            if(!successful)
                throw new Exception("Could not find any spreadsheet by the name of "+name);
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
    }
}
