

using System;
using System.Collections.Generic;
using SFML.Graphics;
using SFML.System;

namespace Fish_Girlz.Utils{
    public static class Extensions {
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

        public static double Distance(this Vector2f v1, Vector2f v2){
            Vector2f dif=v1-v2;
            float total=0;
            total+=(dif.X*dif.X);
            total+=(dif.Y*dif.Y);
            return Math.Sqrt(total);
        }

        public static double Magnitude(this Vector2f v){
            return Math.Sqrt(v.X*v.X+v.Y*v.Y);
        }

        public static double SqrMagnitude(this Vector2f v){
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

        public static uint GetSpriteWidth(this Texture texture){
            (uint leftPos, uint rightPos)=texture.GetSpriteBounds().Item1;
            return rightPos-leftPos;
        }

        public static uint GetSpriteWHeight(this Texture texture){
            (uint topPos, uint bottomPos)=texture.GetSpriteBounds().Item2;
            return bottomPos-topPos;
        }

        public static ((uint, uint), (uint, uint)) GetSpriteBounds(this Texture texture){
            uint leftPos=0, rightPos=0;
            uint topPos=0, bottomPos=0;
            Image textureImage=texture.CopyToImage();
            for (uint x = 0; x < texture.Size.X; x++)
            {
                for (uint y = 0; y < texture.Size.Y; y++)
                {
                    if(textureImage.GetPixel(x,y).A!=0){
                        leftPos=x;
                        goto leftLoopEnd;
                    }
                }
            }

            leftLoopEnd:
            if(leftPos==0) return ((0,0),(0,0));
            for (uint x = texture.Size.X-1; x > 0; x--)
            {
                for (uint y = texture.Size.Y-1; y > 0; y--)
                {
                    if(textureImage.GetPixel(x,y).A!=0){
                        rightPos=x+1;
                        goto rightLoopEnd;
                    }
                }
            }

            rightLoopEnd:
            for (uint y = 0; y < texture.Size.Y; y++)
            {
                for (uint x = 0; x < texture.Size.X; x++)
                {
                    if(textureImage.GetPixel(x,y).A!=0){
                        topPos=y;
                        goto topLoopEnd;
                    }
                }
            }

            topLoopEnd:
            if(topPos==0) return ((0,0),(0,0));
            for (uint y = texture.Size.Y-1; y > 0; y--)
            {
                for (uint x = texture.Size.X-1; x > 0; x--)
                {
                    if(textureImage.GetPixel(x,y).A!=0){
                        bottomPos=y+1;
                        goto bottomLoopEnd;
                    }
                }
            }

            bottomLoopEnd:
            return ((leftPos, rightPos), (topPos, bottomPos));
        }

        public static Texture AdjustTexture(this Texture texture){
            (uint leftPos, uint rightPos)=texture.GetSpriteBounds().Item1;
            return new Texture(texture.CopyToImage(), new IntRect((int)leftPos, (int)0, (int)rightPos, (int)texture.Size.Y));
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
    }
}