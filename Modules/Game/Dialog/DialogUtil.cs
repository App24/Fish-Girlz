using Fish_Girlz.Misc;

namespace Fish_Girlz.Dialog{
    internal static class DialogUtil {
        internal static string FormatDialog(string dialog, CharacterInfo speaker){
            return dialog.Replace("[speaker]", speaker.Name);
        }
    }
}