using System;
using System.Collections.Generic;
using SFML.Graphics;
using SFML.System;
using System.IO;

namespace Fish_Girlz.Utils{
    public static class Utilities {
        public static string TempFolder{get{
            return Path.Combine(Path.GetTempPath(), "FishGirlz");
        }}
        
        public static Texture CreateTexture(uint width, uint height, Color color){
            if(width<=0||height<=0)
                return new Texture(1,1).CreateTexture(new Color(0,0,0,0));
            return new Texture(width, height).CreateTexture(color);
        }

        public static float CenterInWindow(float windowSize, float size){
            return (windowSize-size)/2f;
        }

        public static string GetFileInTemp(string fileName){
            return Path.Combine(TempFolder, fileName);
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

        public static Texture SetColor(this Texture texture, Color color){
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

        public static string GetFileNameWithoutExtension(this string filePath){
            return Path.GetFileNameWithoutExtension(filePath);
        }

        public static double Distance(this Vector2f v1, Vector2f v2){
            Vector2f dif=v1-v2;
            float total=0;
            total+=(dif.X*dif.X);
            total+=(dif.Y*dif.Y);
            return Math.Sqrt(total);
        }

        public static double Distance(this Vector3f v1, Vector3f v2){
            Vector3f dif=v1-v2;
            float total=0;
            total+=(dif.X*dif.X);
            total+=(dif.Y*dif.Y);
            total+=(dif.Z*dif.Z);
            return Math.Sqrt(total);
        }

        public static double Distance(this Vector4f v1, Vector4f v2){
            Vector4f dif=v1-v2;
            float total=0;
            total+=(dif.X*dif.X);
            total+=(dif.Y*dif.Y);
            total+=(dif.Z*dif.Z);
            total+=(dif.W*dif.W);
            return Math.Sqrt(total);
        }

        public static double Magnitude(this Vector2f v){
            return Math.Sqrt(v.X*v.X+v.Y*v.Y);
        }

        public static double Magnitude(this Vector3f v){
            return Math.Sqrt(v.X*v.X+v.Y*v.Y+v.Z*v.Z);
        }

        public static double Magnitude(this Vector4f v){
            return Math.Sqrt(v.X*v.X+v.Y*v.Y+v.Z*v.Z+v.W*v.W);
        }

        public static double SqrMagnitude(this Vector2f v){
            return v.Magnitude()*v.Magnitude();
        }

        public static double SqrMagnitude(this Vector3f v){
            return v.Magnitude()*v.Magnitude();
        }

        public static double SqrMagnitude(this Vector4f v){
            return v.Magnitude()*v.Magnitude();
        }

        public static String ToStringExtended<T>(this IList<T> list){
            string text="[";
            foreach (T item in list)
            {
                if(item!=null)
                text+=item.ToString()+", ";
            }
            if(text.Length>2)
            text=text.Substring(0, text.Length-2);
            text+="]";
            return text;
        }

        public static List<T> Clone<T>(this List<T> list){
            T[] array=new T[list.Count];
            list.CopyTo(array);
            List<T> newList=array.ToList();
            return newList;
        }

        public static List<T> ToList<T>(this T[] array){
            List<T> newList=new List<T>();
            foreach (T item in array)
            {
                newList.Add(item);
            }
            return newList;
        }

        public static Color Divide(this Color color, byte amount, bool alpha=false){
            Color newColor=new Color(color);
            newColor.R/=amount;
            newColor.G/=amount;
            newColor.B/=amount;
            if(alpha)
                newColor.A/=amount;
            return newColor;
        }
    }
}