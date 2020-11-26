using System;
using System.IO;

namespace Fish_Girlz.Utils{
    public static class FileObfuscator {
        public static Stream Deobfuscate(string fileName){
            byte[] fileBytes=File.ReadAllBytes(fileName);
            int seed=BitConverter.ToInt32(fileBytes);
            byte[] obfuscatedBytes=new byte[fileBytes.Length-4];
            Array.Copy(fileBytes, 4, obfuscatedBytes, 0, obfuscatedBytes.Length);
            byte[] deobfuscatedBytes=new byte[obfuscatedBytes.Length];
            int i=0;
            Random random=new Random(seed);
            foreach (byte obfuscatedByte in obfuscatedBytes)
            {
                deobfuscatedBytes[i]=(byte)(obfuscatedByte-random.Next(255));
                i++;
            }
            return new MemoryStream(deobfuscatedBytes);
        }
    }
}