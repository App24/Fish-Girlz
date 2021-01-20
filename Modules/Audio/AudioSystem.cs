using System;
using System.Collections.Generic;
using SFML.Audio;

namespace Fish_Girlz.Audio{
    public static class AudioSystem {
        private static List<Sound> sounds=new List<Sound>();
        public static void CleanUp(){
            foreach(Sound sound in sounds){
                SoundBuffer soundBuffer=sound.GetSound().SoundBuffer;
                sound.GetSound().Dispose();
                soundBuffer.Dispose();
            }
        }
        
        public static void AddSound(Sound sound){
            sounds.Add(sound);
        }
    }
}