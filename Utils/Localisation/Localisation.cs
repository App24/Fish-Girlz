using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Fish_Girlz.Utils;

namespace Fish_Girlz.Localisation{
    public class Language {
        private string langName;
        private Dictionary<string, string> translations=new Dictionary<string, string>();

        public string languagePath;

        public Language(string languagePath, string langName){
            this.langName=langName;
            this.languagePath=Path.Combine(Utilities.ExecutingFolder, languagePath);
            LoadLanguage();
        }

        void LoadLanguage(){
            if(File.Exists(Path.Combine(languagePath, $"{langName}.json"))){
                translations=JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText(Path.Combine(languagePath, $"{langName}.json")));
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
                        break;
                    }
                }
            }
            return text;
        }
    }
}