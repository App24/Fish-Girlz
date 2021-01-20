using System;

namespace Fish_Girlz.API{
    public abstract class Loader {
        protected string ID{get;}

        public Loader(string id){
            ID=id;
        }
    }
}