using System;
using SFML.System;

namespace Fish_Girlz.Utils{
    public static class Delta {
        private static float delta;
        private static Clock clock=new Clock();

        public static void UpdateDelta(){
            delta=clock.Restart().AsSeconds();
        }

        public static float GetDelta(){
            return delta;
        }
    }
}