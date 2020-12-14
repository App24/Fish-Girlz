using System;
using System.Collections.Generic;
using Fish_Girlz.Tiles;
using Fish_Girlz.Utils;
using Fish_Girlz.UI;
using Fish_Girlz.UI.Components;
using SFML.Graphics;
using SFML.System;
using Fish_Girlz.Art;
using Fish_Girlz.Entities.Tiles;

namespace Fish_Girlz.States{
    public class MapCreatorState : State
    {
        int tileId=1;

        UIImage tileImage;
        UIText tileName;

        Tile selectedTile;

        LayeredSprite previewSprite;

        Dictionary<Vector2f, TileEntity> tiles=new Dictionary<Vector2f, TileEntity>();

        public override void Init()
        {
            tileImage=AddGUI(new UIImage(new Vector2f()));
            tileName=AddGUI(new UIText(new FontInfo(AssetManager.GetFont("Arial"), 18), "", SFML.Graphics.Color.Black, new Vector2f(70,0)));
            tileName.OutlineColor=SFML.Graphics.Color.White;
            tileName.OutlineThickness=2;
            selectedTile=Tile.GetTile(tileId);
            tileName.Text=selectedTile.Name;
            previewSprite=new LayeredSprite();
            sprites.Add(previewSprite);
        }

        public override void HandleInput()
        {
            if(InputManager.ScrollDelta<0){
                tileId--;
                if(tileId<1) tileId=1;
                selectedTile=Tile.GetTile(tileId);
                tileName.Text=selectedTile.Name;
            }
            if(InputManager.ScrollDelta>0){
                tileId++;
                if(tileId>Tile.GetTiles().Count-1) tileId=Tile.GetTiles().Count-1;
                selectedTile=Tile.GetTile(tileId);
                tileName.Text=selectedTile.Name;
            }
            Vector2f tilePos=new Vector2f(MathF.Floor(InputManager.MousePosition.X/64)*64,MathF.Floor(InputManager.MousePosition.Y/64)*64);;
            previewSprite.Position=tilePos;
            if(InputManager.IsMouseButtonHeld(SFML.Window.Mouse.Button.Left)){
                if(tiles.ContainsKey(tilePos)){
                    TileEntity tileEntity;
                    tiles.TryGetValue(tilePos, out tileEntity);
                    if(tileEntity.Tile==selectedTile) return;
                    tileEntity.ToRemove=true;
                }
                tiles.AddOrReplace(tilePos, AddTileEntity(new TileEntity(tilePos, selectedTile)));
            }

            if(InputManager.IsMouseButtonHeld(SFML.Window.Mouse.Button.Right)){
                if(tiles.ContainsKey(tilePos)){
                    TileEntity tileEntity;
                    tiles.TryGetValue(tilePos, out tileEntity);
                    tileEntity.ToRemove=true;
                    tiles.Remove(tilePos);
                }
            }
        }

        public override void Update()
        {
            tileImage.Texture=selectedTile.Sprite.Texture;
            previewSprite.Texture=selectedTile.Sprite.Texture;
            previewSprite.Color=new Color(255,255,255,(byte)(255/1.5f));
        }
    }
}