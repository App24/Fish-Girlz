using SFML.Graphics;
using SFML.System;

namespace Fish_Girlz.Art{
    public class Animation {
        
        float fps;
        Texture[] textures;
        Clock clock;
        int currentFrame;

        public Animation(float fps, params Texture[] textures){
            this.fps=fps;
            this.textures=textures;
            clock=new Clock();
        }

        public bool Update(){
            if(clock.ElapsedTime.AsMilliseconds()>=1000f/fps){
                currentFrame++;
                if(currentFrame>textures.Length-1)
                    currentFrame=0;
                clock.Restart();
                return true;
            }
            return false;
        }

        public Texture GetCurrentFrame(){
            return textures[currentFrame];
        }

    }
}