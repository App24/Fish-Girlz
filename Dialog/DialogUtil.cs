using System;
using Fish_Girlz.Misc;

namespace Fish_Girlz.Dialog{
    public static class DialogUtil {
        public static string FormatDialog(string dialog, CharacterInfo speaker){
            return dialog.Replace("[speaker]", speaker.Name);
        }
    }
}