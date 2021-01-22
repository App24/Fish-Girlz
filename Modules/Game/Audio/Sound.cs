using SFML.Audio;

namespace Fish_Girlz.Audio
{
    public class Sound {
        private SFML.Audio.Sound sound;

        public Sound(SoundBuffer soundBuffer){
            sound=new SFML.Audio.Sound(soundBuffer);
            AudioSystem.AddSound(this);
        }

        public void Play(){
            if(sound.Status!=SoundStatus.Playing){
                sound.Play();
            }
        }

        public void Pause(){
            if(sound.Status!=SoundStatus.Paused)
                sound.Pause();
        }

        public void Stop(){
            if(sound.Status!=SoundStatus.Stopped)
                sound.Stop();
        }

        public SFML.Audio.Sound GetSound(){
            return sound;
        }
    }
}