using System;
using System.Collections.Generic;
using SFML.Graphics;
using SFML.System;

namespace Fish_Girlz.Utils{
    public static class Utilities {
        public static Texture CreateTexture(uint width, uint height, Color color){
            return new Texture(width, height).CreateTexture(color);
        }

        public static float CenterInWindow(float windowSize, float size){
            return (windowSize-size)/2f;
        }
    }

    public static class Extensions{
        public static Texture CreateTexture(this Texture texture, Color color){
            List<byte> pixels=new List<byte>();
            for (int x = 0; x < texture.Size.X; x++)
            {
                for (int y = 0; y < texture.Size.Y; y++)
                {
                    pixels.Add(color.R);
                    pixels.Add(color.G);
                    pixels.Add(color.B);
                    pixels.Add(color.A);
                }
            }
            texture.Update(pixels.ToArray());
            return texture;
        }

        public static double Distance(this Vector2f v1, Vector2f v2){
            float a=v1.X-v2.Y;
            float b=v1.Y-v2.Y;
            float c2=(a*a)+(b*b);
            double c=Math.Sqrt(c2);
            return c;
        }

        public static String ToStringExtended<T>(this IList<T> list){
            string text="[";
            foreach (T item in list)
            {
                if(item!=null)
                text+=item.ToString()+", ";
            }
            text=text.Substring(0, text.Length-2);
            text+="]";
            return text;
        }
    }
}