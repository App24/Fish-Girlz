using System;
using Fish_Girlz.Utils;
using Fish_Girlz.UI;
using Fish_Girlz.UI.Components;
using SFML.System;
using SFML.Graphics;
using Fish_Girlz.Systems;

namespace Fish_Girlz.Inventory.UI{
    public class UISlot : GUIComponent {
        public Vector2f Position{get;set;}
        public Texture SlotTexture{get;}

        public FontInfo FontInfo{get;}
        public bool ShowItemName{get;private set;}

        public Slot Slot{get;private set;}


        public UISlot(Vector2f position){
            Position=position;
            SlotTexture=Utilities.CreateTexture(64,64,Color.White);
            FontInfo=new FontInfo(AssetManager.GetFont("Arial"), 18);
            ShowItemName=false;
        }

        public void Update()
        {
            if(InputManager.Hover(new Vector4f(Position+ParentGUI.Position, new Vector2f(64,64)))){
                if(Slot!=null){
                    ShowItemName=true;
                }
            }else{
                ShowItemName=false;
            }
        }

        public void UpdateSlot(Slot slot){
            Slot=slot;
        }
    }
}