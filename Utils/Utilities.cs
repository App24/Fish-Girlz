

using System;
using System.Text;
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

        public static string AddSpacesToSentence(string text, bool preserveAcronyms)
        {
                if (string.IsNullOrWhiteSpace(text))
                return string.Empty;
                StringBuilder newText = new StringBuilder(text.Length * 2);
                newText.Append(text[0]);
                for (int i = 1; i < text.Length; i++)
                {
                    if (char.IsUpper(text[i]))
                        if ((text[i - 1] != ' ' && !char.IsUpper(text[i - 1])) ||
                            (preserveAcronyms && char.IsUpper(text[i - 1]) && 
                            i < text.Length - 1 && !char.IsUpper(text[i + 1])))
                            newText.Append(' ');
                    newText.Append(text[i]);
                }
                return newText.ToString();
        }
    }

    public enum WindowSize{
        WIDTH, HEIGHT
    }
}