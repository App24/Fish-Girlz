using Fish_Girlz.Misc;
using Fish_Girlz.Localisation;

namespace Fish_Girlz.Dialog{
    public struct DialogInfo{
        public CharacterInfo CharacterInfo{get;}
        public string Text{get;}

        public DialogInfo(CharacterInfo characterInfo, string text, Language language, bool localisation=false, params object[] textArgs){
            CharacterInfo=characterInfo;
            if(!localisation){
                Text=text;
            }else{
                Text=language.GetTranslation(text, textArgs);
            }
        }
    }
}