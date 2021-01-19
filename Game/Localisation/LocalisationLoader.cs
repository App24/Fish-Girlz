namespace Fish_Girlz.Localisation{
    public class LocalisationLoader {
        
        private static Language ENGLISH=new Language("res/lang", "en");

        public static Language GetCurrentLanguage(){
            return ENGLISH;
        }
    }
}