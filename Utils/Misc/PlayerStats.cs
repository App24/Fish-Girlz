using System;
using System.Collections.Generic;

namespace Fish_Girlz.Utils{
    public static class PlayerStats {
        static Dictionary<string, object> stats=new Dictionary<string, object>();

        public static void Store(string key, object value){
            stats.AddOrReplace(key, value);
        }

        public static object Get(string key){
            object obj;
            if(!stats.TryGetValue(key, out obj))
                throw new Exception();
            return obj;
        }

        public static void ClearPlayerStats(){
            stats.Clear();
        }
    }
}