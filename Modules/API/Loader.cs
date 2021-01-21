using System;

namespace Fish_Girlz.API{
    public abstract class APILoader {
        protected string ID{get;}

        public APILoader(string id){
            ID=id;
        }
    }
}