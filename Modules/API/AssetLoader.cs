using System;
using System.IO;
using Fish_Girlz.Utils;
using System.Reflection;
using Fish_Girlz.Systems;
using SFML.Graphics;
using SFML.Audio;
using Fish_Girlz.Art;

namespace Fish_Girlz.API{
    public static class AssetLoader {

        public static void LoadTexture(APIPlugin plugin, string name, string fileName){
            AssetManager.LoadTexture($"{plugin.ID}.{name}", Path.Combine(plugin.Directory, fileName));
        }

        public static void LoadSpriteSheet(APIPlugin plugin, string name, string fileName, int spriteWidth, int spriteHeight){
            AssetManager.LoadSpriteSheet($"{plugin.ID}.{name}", Path.Combine(plugin.Directory, fileName), spriteWidth, spriteHeight);
        }

        public static void LoadFont(APIPlugin plugin, string name, string fileName){
            AssetManager.LoadFont($"{plugin.ID}.{name}", Path.Combine(plugin.Directory, fileName));
        }

        public static void LoadSoundBuffer(APIPlugin plugin, string name, string fileName){
            AssetManager.LoadSoundBuffer($"{plugin.ID}.{name}", Path.Combine(plugin.Directory, fileName));
        }

        public static void LoadObject(APIPlugin plugin, string name, object value){
            AssetManager.LoadObject($"{plugin.ID}.{name}", value);
        }

        public static Texture GetTexture(APIPlugin plugin, string name){
            return AssetManager.GetTexture($"{plugin.ID}.{name}");
        }

        public static SpriteSheet GetSpriteSheet(APIPlugin plugin, string name){
            return AssetManager.GetSpriteSheet($"{plugin.ID}.{name}");
        }

        public static Font GetFont(APIPlugin plugin, string name){
            return AssetManager.GetFont($"{plugin.ID}.{name}");
        }

        public static SoundBuffer GetSoundBuffer(APIPlugin plugin, string name){
            return AssetManager.GetSoundBuffer($"{plugin.ID}.{name}");
        }

        public static T GetObject<T>(APIPlugin plugin, string name){
            return AssetManager.GetObject<T>($"{plugin.ID}.{name}");
        }

    }
}