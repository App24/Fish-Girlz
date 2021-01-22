using System;
using SFML.Graphics;
using Fish_Girlz.Utils;
using Fish_Girlz.Systems;

namespace Fish_Girlz.Misc{
    public struct CharacterInfo {
        public string Name{get;}
        public Texture Portrait{get;}

        public CharacterInfo(string name, Texture portrait){
            Name=name;
            Portrait=portrait;
        }

        public static CharacterInfo DOMINIQUE=new CharacterInfo("Dominique", AssetManager.GetTexture("dominique portrait"));
        public static CharacterInfo ASTRA=new CharacterInfo("Astra", AssetManager.GetTexture("astra portrait"));
        public static CharacterInfo LAURELY=new CharacterInfo("Laurely", AssetManager.GetTexture("laurely portrait"));
    }
}