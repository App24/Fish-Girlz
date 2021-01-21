using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Fish_Girlz.Utils;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Fish Girlz")]
[assembly: InternalsVisibleTo("API")]
namespace Fish_Girlz.Localisation{
    public class Language {
        private string langName;
        private Dictionary<string, string> translations=new Dictionary<string, string>();

        static List<Language> languages=new List<Language>();

        public Language(string langName){
            this.langName=langName;
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

        internal void AddLocalisation(string key, string value){
            translations.Add(key, value);
        }

        internal static void AddLanguage(Language language){
            languages.Add(language);
        }

        internal static Language GetLanguage(string name){
            return languages.Find(delegate(Language language){return language.langName==name;});
        }

        public static Language GetDefault(){
            return GetLanguage("English");
        }
    }
}