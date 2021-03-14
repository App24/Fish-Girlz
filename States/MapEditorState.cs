using Fish_Girlz.Systems;
using Fish_Girlz.Utils;
using Fish_Girlz.UI;
using Fish_Girlz.Tiles;

namespace Fish_Girlz.States{
    public class MapEditorState : State
    {
        UIImage objectSelectImage;
        UIText objectSelectText, selectModeText;
        int tileIndex;
        SelectMode selectMode=SelectMode.Tile;

        public override void Init()
        {
            tileIndex=0;
            objectSelectImage=AddGUI(new UIImage(Tile.GetTile(tileIndex).Texture, new SFML.System.Vector2f()));
            objectSelectImage.TextureComponent.Size=new SFML.System.Vector2f(64,64);
            selectModeText=AddGUI(new UIText(new Misc.FontInfo(AssetManager.GetFont("Arial"), 18), "Tile Mode", new SFML.System.Vector2f(64,0)));
            objectSelectText=AddGUI(new UIText(new Misc.FontInfo(AssetManager.GetFont("Arial"), 18), Utilities.AddSpacesToSentence(Tile.GetTile(tileIndex).GetType().Name, true), new SFML.System.Vector2f(64,20)));
        }

        void UpdateSelect(){
            switch (selectMode)
            {
                case SelectMode.Tile:
                    objectSelectImage.TextureComponent.Texture=Tile.GetTile(tileIndex).Texture;
                    objectSelectText.TextComponent.Text=Utilities.AddSpacesToSentence(Tile.GetTile(tileIndex).GetType().Name, true);
                    selectModeText.TextComponent.Text="Tile Mode";
                break;
                case SelectMode.PlayerPos:
                    objectSelectImage.TextureComponent.Texture=Utilities.CreateTexture(64, 64, SFML.Graphics.Color.Red);
                    objectSelectText.TextComponent.Text="";
                    selectModeText.TextComponent.Text="Player Position Mode";
                break;
            }
        }

        public override void HandleInput()
        {
            if(InputManager.IsEscPressed()){
                StateMachine.AddState(new PauseState(), false).SetBackgroundTexture(Utilities.TakeScreenshot());
            }
            if(InputManager.ScrollDelta>0){
                IncreaseIndex();
            }
            if(InputManager.ScrollDelta<0){
                DecreaseIndex();
            }
            if(InputManager.IsMouseButtonPressed(SFML.Window.Mouse.Button.XButton1)){
                selectMode=selectMode.Next();
                UpdateSelect();
            }
            if(InputManager.IsMouseButtonPressed(SFML.Window.Mouse.Button.XButton2)){
                selectMode=selectMode.Previous();
                UpdateSelect();
            }
        }

        void IncreaseIndex(){
            switch (selectMode)
            {
                case SelectMode.Tile:{
                    tileIndex++;
                    if(tileIndex>Tile.GetTiles().Count-1){
                        tileIndex=0;
                    }
                    goto default;
                }break;
                default:{
                    UpdateSelect();
                }break;
            }
        }

        void DecreaseIndex(){
            switch (selectMode)
            {
                case SelectMode.Tile:{
                    tileIndex--;
                    if(tileIndex<0){
                        tileIndex=Tile.GetTiles().Count-1;
                    }
                    goto default;
                }break;
                default:{
                    UpdateSelect();
                }break;
            }
        }

        public override void Update()
        {
            
        }

        enum SelectMode{
            Tile, PlayerPos
        }
    }
}