

using System;
using Fish_Girlz.Systems;
using SFML.Graphics;
using SFML.System;

namespace Fish_Girlz.Utils{
    public static class Utilities {
        public static Texture CreateTexture(uint width, uint height, Color color){
            if(width<=0||height<=0)
                return new Texture(1,1).CreateTexture(new Color(0,0,0,0));
            return new Texture(width, height).CreateTexture(color);
        }
        
        public static Texture CreateTexture(Vector2u size, Color color){
            return CreateTexture(size.X, size.Y, color);
        }

        public static Texture TakeScreenshot(){
            Texture texture=new Texture(DisplayManager.Width, DisplayManager.Height);
            texture.Update(DisplayManager.Window);
            return texture;
        }

        public static float CenterInWindow(WindowSize windowSize, float size){
            uint wSize=(uint)Math.Abs(Math.Ceiling(size));
            switch (windowSize)
            {
                case WindowSize.WIDTH:
                    wSize=DisplayManager.Width;
                    break;
                case WindowSize.HEIGHT:
                    wSize=DisplayManager.Height;
                    break;
            }
            return (wSize-size)/2f;
        }
    }

    public enum WindowSize{
        WIDTH, HEIGHT
    }
}