using System;
using System.Collections.Generic;
using Fish_Girlz.Misc;
using Fish_Girlz.Systems;
using SFML.Graphics;
using SFML.System;

namespace Fish_Girlz.UI{
    public class UISelectTextMenu {
        List<UISelectableText> selectableTexts=new List<UISelectableText>();
        int index;

        Vector2f position;
        float spacing;

        public UISelectTextMenu(Vector2f position=new Vector2f(), float spacing=2){
            this.position=position;
            this.spacing=spacing;
        }

        FloatRect GetBiggestBounds(){
            FloatRect biggestBounds=new FloatRect();
            foreach (UISelectableText item in selectableTexts)
            {
                if(item.Bounds.Width>biggestBounds.Width) biggestBounds.Width=item.Bounds.Width;
                biggestBounds.Height+=item.Bounds.Height;
            }
            biggestBounds.Height+=spacing*(selectableTexts.Count-1);
            return biggestBounds;
        }

        FloatRect GetActualBiggestBounds(){
            FloatRect biggestBounds=new FloatRect();
            foreach (UISelectableText item in selectableTexts)
            {
                if(item.ActualBounds.Width>biggestBounds.Width) biggestBounds.Width=item.ActualBounds.Width;
                biggestBounds.Height+=item.Bounds.Height;
            }
            biggestBounds.Height+=spacing*(selectableTexts.Count-1);
            return biggestBounds;
        }

        // public UISelectableText AddText(string text, Vector2f offset=new Vector2f(), bool ignoreSpacing=false, bool center=true){
        //     FloatRect biggestBounds=GetBiggestBounds();
        //     Vector2f textPos=position+offset;
        //     if(center)
        //     textPos+=new Vector2f(biggestBounds.Width/2f,0);
        //     if(!ignoreSpacing)
        //     textPos+=new Vector2f(0, (fontInfo.CharacterSize+spacing)*selectableTexts.Count);
        //     UISelectableText uiSelectableText=new UISelectableText(fontInfo, text, textPos);
        //     selectableTexts.Add(uiSelectableText);
        //     if(center)
        //     SetPosition(position);
        //     return uiSelectableText;
        // }

        public UISelectableText AddText(UISelectableText uiSelectableText, bool ignoreSpacing=false, bool center=true){
            FloatRect biggestBounds=GetBiggestBounds();
            Vector2f textPos=position+uiSelectableText.Position;
            if(center)
            textPos+=new Vector2f(biggestBounds.Width/2f,0);
            if(!ignoreSpacing)
            textPos+=new Vector2f(0, (uiSelectableText.TextComponent.FontInfo.CharacterSize+spacing)*selectableTexts.Count);
            uiSelectableText.Position=textPos;
            selectableTexts.Add(uiSelectableText);
            if(center)
            SetPosition(position);
            return uiSelectableText;
        }

        public void SetPosition(Vector2f position){
            FloatRect biggestBounds=GetBiggestBounds();
            foreach (UISelectableText item in selectableTexts)
            {
                if(item.Bounds.Width==biggestBounds.Width){
                    item.Position=new Vector2f(position.X, (item.Position.Y-this.position.Y)+position.Y);
                    continue;
                }
                item.Position=new Vector2f(position.X+(biggestBounds.Width-item.Bounds.Width)/2f, (item.Position.Y-this.position.Y)+position.Y);
            }
            this.position=position;
        }

        public void CenterInWindow(){
            FloatRect biggestBounds=GetActualBiggestBounds();
            float xPosition=Utils.Utilities.CenterInWindow(Utils.WindowSize.WIDTH, biggestBounds.Width);
            float yPosition=Utils.Utilities.CenterInWindow(Utils.WindowSize.HEIGHT, biggestBounds.Height);
            SetPosition(new Vector2f(xPosition, yPosition));
        }

        public void Increase(){
            selectableTexts[index].Selected=false;
            index++;
            if(index>selectableTexts.Count-1) index=0;
            selectableTexts[index].Selected=true;
        }

        public void Decrease(){
            selectableTexts[index].Selected=false;
            index--;
            if(index<0) index=selectableTexts.Count-1;
            selectableTexts[index].Selected=true;
        }

        public void Select(int index){
            selectableTexts[this.index].Selected=false;
            this.index=index;
            selectableTexts[this.index].Selected=true;
        }

        public void SelectCurrent(){
            selectableTexts[index].OnSelect?.Invoke(selectableTexts[index], new EventArgs());
        }

        public void Update(){
            if(InputManager.IsDownPressed()){
                Increase();
            }else if(InputManager.IsUpPressed()){
                Decrease();
            }
            if(InputManager.IsSelectPressed()){
                SelectCurrent();
            }
        }
    }
}