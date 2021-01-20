using System;
using Fish_Girlz.Utils;
using System.Reflection;

namespace Fish_Girlz.API{
    public class AssetManager {

        private string id;
        private string folder;

        public AssetManager(string id, string folder){
            this.id=id;
            this.folder=folder;
        }

        public void LoadTexture(string name, string fileName){
            Fish_Girlz.Systems.AssetManager.LoadTexture($"{id}.{name}", fileName);
        }

        public void LoadSpriteSheet(string name, string fileName, int spriteWidth, int spriteHeight){
            Fish_Girlz.Systems.AssetManager.LoadSpriteSheet($"{id}.{name}", fileName, spriteWidth, spriteHeight);
        }

        public void LoadFont(string name, string fileName){
            Fish_Girlz.Systems.AssetManager.LoadFont($"{id}.{name}", fileName);
        }

        public void LoadSoundBuffer(string name, string fileName){
            Fish_Girlz.Systems.AssetManager.LoadSoundBuffer($"{id}.{name}", fileName);
        }
    }
}