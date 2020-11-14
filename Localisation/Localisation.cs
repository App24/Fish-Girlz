using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Fish_Girlz.Localisation{
    public class Language {
        private string langName;
        private Dictionary<string, string> translations=new Dictionary<string, string>();

        private static Language ENGLISH=new Language("en");

        private Language(string langName){
            this.langName=langName;
            LoadLanguage();
        }

        void LoadLanguage(){
            if(File.Exists("res/lang/"+langName+".json")){
                translations=JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText("res/lang/"+langName+".json"));
            }else{
                throw new FileNotFoundException("Could not load language file: "+langName);
            }
        }

        public string GetTranslation(string key, params object[] args){
            string text=key;
            foreach (string name in translations.Keys)
            {
                if(name==key){
                    if(translations.TryGetValue(key, out text)){
                        text=string.Format(text, args);
                    }
                }
            }
            return text;
        }

        public static Language GetCurrentLanguage(){
            return ENGLISH;
        }
    }
}