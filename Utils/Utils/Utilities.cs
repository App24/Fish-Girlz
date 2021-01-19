using System;
using System.Collections.Generic;
using SFML.Graphics;
using SFML.System;
using System.IO;
using Fish_Girlz.Systems;
using System.Reflection;

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
        
        public static Texture CreateTexture(Vector2u size, Color color){
            return CreateTexture(size.X, size.Y, color);
        }

        public static string ExecutingFolder{get{
            return Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
        }}

        // public static float CenterInWindow(float windowSize, float size){
        //     return (windowSize-size)/2f;
        // }

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

        public static string GetFileInTemp(string fileName){
            return Path.Combine(TempFolder, fileName);
        }
    }

    public enum WindowSize{
        WIDTH, HEIGHT
    }

    public static class Extensions{

        public static T Next<T>(this T src) where T : struct
        {
            if (!typeof(T).IsEnum) throw new ArgumentException(String.Format("Argument {0} is not an Enum", typeof(T).FullName));

            T[] Arr = (T[])Enum.GetValues(src.GetType());
            int j = Array.IndexOf<T>(Arr, src) + 1;
            return (Arr.Length==j) ? Arr[0] : Arr[j];            
        }
        public static T Previous<T>(this T src) where T : struct
        {
            if (!typeof(T).IsEnum) throw new ArgumentException(String.Format("Argument {0} is not an Enum", typeof(T).FullName));

            T[] Arr = (T[])Enum.GetValues(src.GetType());
            int j = Array.IndexOf<T>(Arr, src) - 1;
            return (j<0) ? Arr[Arr.Length-1] : Arr[j];            
        }
        
        public static T Clamp<T>(this T val, T min, T max) where T : IComparable<T>
        {
            if (val.CompareTo(min) < 0) return min;
            else if(val.CompareTo(max) > 0) return max;
            else return val;
        }

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

        public static Texture SetColor(this Texture texture, Color color, Color toReplaceColor){
            List<byte> pixels=new List<byte>(texture.CopyToImage().Pixels);
            for (int i = 0; i < pixels.Count; i+=4)
            {
                if(pixels[i]==color.R&&pixels[i+1]==color.G&&pixels[i+2]==color.B&&pixels[i+3]==color.A){
                    pixels[i]=toReplaceColor.R;
                    pixels[i+1]=toReplaceColor.G;
                    pixels[i+2]=toReplaceColor.B;
                    pixels[i+3]=toReplaceColor.A;
                }
            }
            Texture newTexture=new Texture(texture.Size.X, texture.Size.Y);
            newTexture.Update(pixels.ToArray());
            return newTexture;
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

        /*public static string GetFileNameWithoutExtension(this string filePath){
            return Path.GetFileNameWithoutExtension(filePath);
        }*/

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

        public static void AddOrReplace<T, D>(this Dictionary<T, D> dictionary, T key, D value){
            if(!dictionary.ContainsKey(key)){
                dictionary.Add(key, value);
            }else{
                dictionary.Remove(key);
                dictionary.Add(key, value);
            }
        }

        public static void AddOrReplace<T>(this IList<T> list, T value){
            if(!list.Contains(value)){
                list.Add(value);
            }else{
                list.Remove(value);
                list.Add(value);
            }
        }

        public static void AddOrInsert<T>(this IList<T> list, T value){
            if(!list.Contains(value)){
                list.Add(value);
            }else{
                int index=list.IndexOf(value);
                list.Remove(value);
                list.Insert(index, value);
            }
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