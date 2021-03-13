namespace Fish_Girlz.UI.Components{
    public abstract class GUIComponent {
        public GUI ParentGUI{get;set;}

        public bool Visible{get;set;}=true;
    }
}