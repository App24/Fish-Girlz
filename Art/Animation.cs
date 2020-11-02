using System;
using SFML.Graphics;
using SFML.System;

namespace Fish_Girlz.Art{
    public class Animation {
        float fps;
        IntRect[] intRects;
        Clock clock;
        int currentFrame;

        public Animation(float fps, params IntRect[] intRects){
            this.fps=fps;
            this.intRects=intRects;
            clock=new Clock();
        }

        public bool Update(){
            if(clock.ElapsedTime.AsMilliseconds()>=1000f/fps){
                currentFrame++;
                if(currentFrame>intRects.Length-1)
                    currentFrame=0;
                clock.Restart();
                return true;
            }
            return false;
        }

        public IntRect GetCurrentIntRect(){
            return intRects[currentFrame];
        }
    }
}