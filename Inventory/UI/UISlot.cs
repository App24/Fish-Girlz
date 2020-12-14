using System;
using Fish_Girlz.Utils;
using Fish_Girlz.Inventory.Items;
using Fish_Girlz.UI;
using Fish_Girlz.UI.Components;
using SFML.System;
using SFML.Graphics;

namespace Fish_Girlz.Inventory.UI{
    public class UISlot : GUIComponent {
        public Vector2f Position{get;set;}
        public Texture SlotTexture{get;}
        public Texture ItemTexture{get; private set;}

        public string TextAmount{get;private set;}
        public FontInfo FontInfo{get;}

        public string ItemText{get;private set;}
        public bool ShowItemName{get;private set;}

        public UISlot(Vector2f position){
            Position=position;
            SlotTexture=Utilities.CreateTexture(64,64,Color.White);
            FontInfo=new FontInfo(AssetManager.GetFont("Arial"), 18);
            ShowItemName=false;
        }

        public void Update()
        {
            if(InputManager.Hover(new Vector4f(Position+ParentGUI.Position, new Vector2f(64,64)))){
                if(ItemTexture!=null){
                    ShowItemName=true;
                }
            }else{
                ShowItemName=false;
            }
        }

        public void UpdateSlot(Slot slot){
            ItemText="";
            ItemTexture=null;
            TextAmount="";
            if(slot.Item!=null){
                ItemTexture=slot.Item.Sprite.Texture;
                TextAmount=slot.Amount.ToString();
                ItemText=slot.Item.Name;
            }
        }
    }
}