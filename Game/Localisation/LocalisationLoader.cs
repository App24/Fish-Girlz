using System;
using Fish_Girlz.Systems;

namespace Fish_Girlz.Localisation{
    public static class LocalisationLoader {
        public static void LoadDefault(){
            Language.AddLanguage(new Language("English"));
            Language.GetDefault().AddLocalisation("text.version", "Version: {0}");
            Language.GetDefault().AddLocalisation("text.Paused", "Paused");

            Language.GetDefault().AddLocalisation("button.start", "Start Game");
            Language.GetDefault().AddLocalisation("button.quit", "Quit");
            Language.GetDefault().AddLocalisation("button.menu", "Menu");
            Language.GetDefault().AddLocalisation("button.continue", "Continue");
        }
    }
}