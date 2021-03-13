using System;
using SFML.System;

namespace Fish_Girlz.Utils{
    public static class Delta {
        public static float DeltaTime{get;private set;}
        private static Clock clock=new Clock();

        public static void UpdateDelta(){
            DeltaTime=clock.Restart().AsSeconds();
        }
    }
}