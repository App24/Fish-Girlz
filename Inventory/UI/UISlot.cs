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
        public Vector2f ItemPosition{get;set;}

        bool movingItem;

        public UISlot(Vector2f position){
            Position=position;
            SlotTexture=Utilities.CreateTexture(64,64,Color.White);
            FontInfo=new FontInfo(AssetManager.GetFont("Arial"), 18);
            ItemPosition=Position;
        }

        public void Update()
        {
            if(InputManager.IsMouseButtonPressed(SFML.Window.Mouse.Button.Left)){
                if(InputManager.Hover(new Vector4f(Position, new Vector2f(64,64)))){
                    movingItem=true;
                }else{
                    movingItem=false;
                }
            }
            if(movingItem){
                ItemPosition=InputManager.MousePosition;
            }else{
                ItemPosition=Position;
            }
        }

        public void UpdateSlot(Slot slot){
            if(slot.Item!=null){
                ItemTexture=slot.Item.ItemTexture;
                TextAmount=slot.Amount.ToString();
            }
        }
    }
}