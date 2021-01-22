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
using Newtonsoft.Json;
using System.IO;
using Fish_Girlz.World;
using Fish_Girlz.Items;
using Fish_Girlz.Entities.Items;
using Fish_Girlz.Systems;
using Fish_Girlz.Entities;

namespace Fish_Girlz.States{
    public class MapCreatorState : State
    {
        int tileId=1;
        int itemId=0, entityId=0;

        UIImage tileImage;
        UIText tileName, selectedMode;

        Tile selectedTile;

        Item selectedItem;

        Entity selectedEntity;

        LayeredSprite previewSprite;

        Dictionary<Vector2f, EntityEntity> tiles=new Dictionary<Vector2f, EntityEntity>();
        Dictionary<Vector2f, EntityEntity> items=new Dictionary<Vector2f, EntityEntity>();
        Dictionary<Vector2f, EntityEntity> entitiesEntities=new Dictionary<Vector2f, EntityEntity>();

        SelectedEdit selectedEdit=SelectedEdit.Tile;

        LayeredSprite playerPosSprite;
    
        GUIGroup saveGroup, loadGroup;

        UITextField saveNameField, loadNameField;

        string mapName;

        internal override void Init()
        {
            tileImage=AddGUI(new UIImage(new Vector2f()));
            tileName=AddGUI(new UIText(new FontInfo(AssetManager.GetFont("Arial"), 18), "", SFML.Graphics.Color.Black, new Vector2f(70,0)));
            tileName.OutlineColor=SFML.Graphics.Color.White;
            tileName.OutlineThickness=2;
            selectedTile=Tile.GetTile(tileId);
            selectedItem=Item.GetItem(Item.GetItems()[itemId].ID);
            selectedEntity=Entity.GetMapEntity(Entity.GetMapEntities()[entityId].ID);
            tileName.Text=selectedTile.Name;
            previewSprite=new LayeredSprite();
            sprites.Add(previewSprite);

            selectedMode=AddGUI(new UIText(new FontInfo(AssetManager.GetFont("Arial"), 18), "", Color.Black, new Vector2f(0,70)));
            selectedMode.OutlineColor=Color.White;
            selectedMode.OutlineThickness=2;

            playerPosSprite=new LayeredSprite(Utilities.CreateTexture(64,64,Color.Red));

            saveGroup=new GUIGroup();
            saveGroup.Position=new Vector2f(Utilities.CenterInWindow(WindowSize.WIDTH, 400),Utilities.CenterInWindow(WindowSize.HEIGHT, 120));
            saveGroup.AddGUI(new UIImage(new Vector2f(), Utilities.CreateTexture(400,120, new Color(255/3,255/3,255/3))));
            saveNameField=saveGroup.AddGUI(new UITextField(new Vector2f(10,10), new Vector2u(355,50)));
            saveGroup.AddGUI(new UIButton(new Vector2u(160,40), new Vector2f(10,70), "Save", new FontInfo(AssetManager.GetFont("Arial"), 18))).OnClick+=SaveClick;
            saveGroup.AddGUI(new UIButton(new Vector2u(20,20), new Vector2f(400-5-20, 5), "", new FontInfo(null,0), Color.Red, Color.Red)).OnClick+=new EventHandler((sender,e)=>{saveGroup.SetVisible(false);});
            saveGroup.AddGUIs(this);
            saveGroup.SetVisible(false);
            
            loadGroup=new GUIGroup();
            loadGroup.Position=new Vector2f(Utilities.CenterInWindow(WindowSize.WIDTH, 400),Utilities.CenterInWindow(WindowSize.HEIGHT, 120));
            loadGroup.AddGUI(new UIImage(new Vector2f(), Utilities.CreateTexture(400,120, new Color(255/3,255/3,255/3))));
            loadNameField=loadGroup.AddGUI(new UITextField(new Vector2f(10,10), new Vector2u(355,50)));
            loadNameField.SetText("map");
            loadGroup.AddGUI(new UIButton(new Vector2u(160,40), new Vector2f(10,70), "Load", new FontInfo(AssetManager.GetFont("Arial"), 18))).OnClick+=LoadClick;
            loadGroup.AddGUI(new UIButton(new Vector2u(20,20), new Vector2f(400-5-20, 5), "", new FontInfo(null,0), Color.Red, Color.Red)).OnClick+=new EventHandler((sender,e)=>{loadGroup.SetVisible(false);});
            loadGroup.AddGUIs(this);
            loadGroup.SetVisible(false);
        }

        internal override void HandleInput()
        {
            Vector2f tilePos=new Vector2f(MathF.Floor((InputManager.MousePosition.X+(DisplayManager.View.Center.X-640))/64)*64,MathF.Floor((InputManager.MousePosition.Y+(DisplayManager.View.Center.Y-360))/64)*64);;
            if(InputManager.IsMouseButtonPressed(SFML.Window.Mouse.Button.XButton1)){
                selectedEdit=selectedEdit.Next();
            }
            if(InputManager.IsMouseButtonPressed(SFML.Window.Mouse.Button.XButton2)){
                selectedEdit=selectedEdit.Previous();
            }
            switch (selectedEdit)
            {
                case SelectedEdit.Tile:
                    tileName.Text=selectedTile.Name;
                    break;
                case SelectedEdit.PlayerPos:
                    tileName.Text="";
                    break;
                case SelectedEdit.Entity:
                    tileName.Text=selectedEntity.Name;
                    break;
                case SelectedEdit.Item:
                    tileName.Text=selectedItem.Name;
                    break;
            }
            selectedMode.Text=$"Selected Mode: {Enum.GetName(typeof(SelectedEdit), selectedEdit)}";
            previewSprite.Position=tilePos;

            switch(selectedEdit){
                case SelectedEdit.Tile:
                    if(InputManager.ScrollDelta<0){
                        tileId--;
                        if(tileId<1) tileId=Tile.GetTiles().Count-1;
                        selectedTile=Tile.GetTile(tileId);
                    }
                    if(InputManager.ScrollDelta>0){
                        tileId++;
                        if(tileId>Tile.GetTiles().Count-1) tileId=1;
                        selectedTile=Tile.GetTile(tileId);
                    }
                    if(InputManager.IsMouseButtonHeld(SFML.Window.Mouse.Button.Left)){
                        if(tiles.ContainsKey(tilePos)){
                            EntityEntity tileEntity;
                            tiles.TryGetValue(tilePos, out tileEntity);
                            tileEntity.ToRemove=true;
                        }
                        tiles.AddOrReplace(tilePos, AddTileEntity(new EntityEntity(tilePos, new TileEntity(selectedTile))));
                    }

                    if(InputManager.IsMouseButtonHeld(SFML.Window.Mouse.Button.Right)){
                        if(tiles.ContainsKey(tilePos)){
                            EntityEntity tileEntity;
                            tiles.TryGetValue(tilePos, out tileEntity);
                            tileEntity.ToRemove=true;
                            tiles.Remove(tilePos);
                        }
                    }
                    break;
                case SelectedEdit.PlayerPos:
                    if(InputManager.IsMouseButtonPressed(SFML.Window.Mouse.Button.Left)){
                        playerPosSprite.Position=tilePos;
                        if(!sprites.Contains(playerPosSprite)) sprites.Add(playerPosSprite);
                    }
                    if(InputManager.IsMouseButtonPressed(SFML.Window.Mouse.Button.Right)){
                        if(sprites.Contains(playerPosSprite)) sprites.Remove(playerPosSprite);
                    }
                    break;
                case SelectedEdit.Entity:
                    if(InputManager.ScrollDelta<0){
                        entityId--;
                        if(entityId<0) entityId=Entity.GetEntities().Count-1;
                        selectedEntity=Entity.GetMapEntity(Entity.GetMapEntities()[entityId].ID);
                    }
                    if(InputManager.ScrollDelta>0){
                        entityId++;
                        if(entityId>Entity.GetEntities().Count-1) entityId=0;
                        selectedEntity=Entity.GetMapEntity(Entity.GetMapEntities()[entityId].ID);
                    }

                    if(InputManager.IsMouseButtonHeld(SFML.Window.Mouse.Button.Left)){
                        if(entitiesEntities.ContainsKey(tilePos)){
                            EntityEntity entity;
                            entitiesEntities.TryGetValue(tilePos, out entity);
                            entity.ToRemove=true;
                        }
                        entitiesEntities.AddOrReplace(tilePos, AddItem(new EntityEntity(tilePos, selectedEntity)));
                    }

                    if(InputManager.IsMouseButtonHeld(SFML.Window.Mouse.Button.Right)){
                        if(entitiesEntities.ContainsKey(tilePos)){
                            EntityEntity entity;
                            entitiesEntities.TryGetValue(tilePos, out entity);
                            entity.ToRemove=true;
                            entitiesEntities.Remove(tilePos);
                        }
                    }
                    break;
                case SelectedEdit.Item:
                    if(InputManager.ScrollDelta<0){
                        itemId--;
                        if(itemId<0) itemId=Item.GetItems().Count-1;
                        selectedItem=Item.GetItem(Item.GetItems()[itemId].ID);
                    }
                    if(InputManager.ScrollDelta>0){
                        itemId++;
                        if(itemId>Item.GetItems().Count-1) itemId=0;
                        selectedItem=Item.GetItem(Item.GetItems()[itemId].ID);
                    }

                    if(InputManager.IsMouseButtonHeld(SFML.Window.Mouse.Button.Left)){
                        if(items.ContainsKey(tilePos)){
                            EntityEntity itemEntity;
                            items.TryGetValue(tilePos, out itemEntity);
                            itemEntity.ToRemove=true;
                        }
                        items.AddOrReplace(tilePos, AddItem(new EntityEntity(tilePos, new ItemEntity(selectedItem))));
                    }

                    if(InputManager.IsMouseButtonHeld(SFML.Window.Mouse.Button.Right)){
                        if(items.ContainsKey(tilePos)){
                            EntityEntity itemEntity;
                            items.TryGetValue(tilePos, out itemEntity);
                            itemEntity.ToRemove=true;
                            items.Remove(tilePos);
                        }
                    }
                    break;
            }

            if(InputManager.IsKeyHeld(SFML.Window.Keyboard.Key.A)){
                Camera.Move(new Vector2f(-200*Delta.DeltaTime, 0));
            }else if(InputManager.IsKeyHeld(SFML.Window.Keyboard.Key.D)){
                Camera.Move(new Vector2f(200*Delta.DeltaTime, 0));
            }

            if(InputManager.IsKeyHeld(SFML.Window.Keyboard.Key.W)){
                Camera.Move(new Vector2f(0, -200*Delta.DeltaTime));
            }else if(InputManager.IsKeyHeld(SFML.Window.Keyboard.Key.S)){
                Camera.Move(new Vector2f(0, 200*Delta.DeltaTime));
            }

            if(InputManager.IsKeyHeld(SFML.Window.Keyboard.Key.LControl)){
                if(InputManager.IsKeyPressed(SFML.Window.Keyboard.Key.S)){
                    if(sprites.Contains(playerPosSprite)){
                        saveGroup.SetVisible(true);
                    }
                }else if(InputManager.IsKeyPressed(SFML.Window.Keyboard.Key.L)){
                    loadGroup.SetVisible(true);
                }
            }

            if(InputManager.IsKeyPressed(SFML.Window.Keyboard.Key.Escape)){
                StateMachine.AddState(new MainMenuState());
            }
        }

        internal override void Update()
        {
            switch(selectedEdit){
                case SelectedEdit.Tile:
                    previewSprite.Texture=selectedTile.Sprite.Texture;
                    tileImage.Texture=selectedTile.Sprite.Texture;
                    break;
                case SelectedEdit.PlayerPos:
                    previewSprite.Texture=Utilities.CreateTexture(64,64,new Color(255,0,0));
                    break;
                case SelectedEdit.Item:
                    tileImage.Texture=selectedItem.Sprite.Texture;
                    previewSprite.Texture=selectedItem.Sprite.Texture;
                    break;
                case SelectedEdit.Entity:
                    tileImage.Texture=selectedEntity.Sprite.Texture;
                    previewSprite.Texture=selectedEntity.Sprite.Texture;
                    break;
            }
            previewSprite.Color=new Color(255,255,255,(byte)(255/1.5f));
        }

        void SaveClick(object sender, EventArgs e){
            if(!string.IsNullOrEmpty(saveNameField.Text)){
                string text=saveNameField.Text;
                foreach (var item in Path.GetInvalidFileNameChars())
                {
                    text=text.Replace(item.ToString(), "");
                }
                Save(text);
                saveGroup.SetVisible(false);
            }
        }

        void LoadClick(object sender, EventArgs e){
            if(!string.IsNullOrEmpty(loadNameField.Text)){
                string text=loadNameField.Text;
                foreach (var item in Path.GetInvalidFileNameChars())
                {
                    text=text.Replace(item.ToString(), "");
                }
                Load(text);
                mapName=text;
                saveNameField.SetText(mapName);
                loadGroup.SetVisible(false);
            }
        }

        void Save(string mapName="map"){
            List<TileData> tileDatas=new List<TileData>();
            foreach (KeyValuePair<Vector2f, EntityEntity> pair in tiles)
            {
                tileDatas.Add(new TileData(new Vector2f(MathF.Floor(pair.Key.X/64), MathF.Floor(pair.Key.Y/64)), ((TileEntity)pair.Value.Entity).Tile.ID));
            }
            List<ItemData> itemDatas=new List<ItemData>();
            foreach (KeyValuePair<Vector2f, EntityEntity> pair in items)
            {
                itemDatas.Add(new ItemData(new Vector2f(MathF.Floor(pair.Key.X/64), MathF.Floor(pair.Key.Y/64)), ((ItemEntity)pair.Value.Entity).Item.ID));
            }
            List<EntityData> entityDatas=new List<EntityData>();
            foreach (KeyValuePair<Vector2f, EntityEntity> pair in entitiesEntities)
            {
                entityDatas.Add(new EntityData(new Vector2f(MathF.Floor(pair.Key.X/64), MathF.Floor(pair.Key.Y/64)), pair.Value.Entity.ID));
            }
            MapData mapData=new MapData(new Vector2f(MathF.Floor(playerPosSprite.Position.X/64), MathF.Floor(playerPosSprite.Position.Y/64)), tileDatas, itemDatas, entityDatas);
            string text=JsonConvert.SerializeObject(mapData, Formatting.Indented);
            File.WriteAllText(Path.Combine(Utilities.ExecutingFolder, $"res/maps/{mapName}.json"), text);
            Console.WriteLine("Saved!");
        }

        void Load(string mapName="map"){
            if(File.Exists(Path.Combine(Utilities.ExecutingFolder, $"res/maps/{mapName}.json"))){
                MapData mapData=JsonConvert.DeserializeObject<MapData>(File.ReadAllText(Path.Combine(Utilities.ExecutingFolder, $"res/maps/{mapName}.json")));
                tiles.Clear();
                GetTileEntities().Clear();
                GetItems().Clear();
                items.Clear();
                entitiesEntities.Clear();
                GetEntities().Clear();
                if(mapData.TilesData!=null)
                foreach (TileData tileData in mapData.TilesData)
                {
                    Tile tile=Tile.GetTile(tileData.ID);
                    if(tile==null)continue;
                    tiles.Add(tileData.Position*64, AddTileEntity(new EntityEntity(tileData.Position*64, new TileEntity(tile))));
                }
                if(mapData.ItemsData!=null)
                foreach (ItemData itemData in mapData.ItemsData)
                {
                    Item item=Item.GetItem(itemData.ID);
                    if(item==null)continue;
                    items.Add(itemData.Position*64, AddItem(new EntityEntity(itemData.Position*64, new ItemEntity(item))));
                }
                if(mapData.EntitiesData!=null)
                foreach (EntityData entityData in mapData.EntitiesData)
                {
                    Entity entity=Entity.GetMapEntity(entityData.ID);
                    if(entity==null)continue;
                    entitiesEntities.Add(entityData.Position*64, AddItem(new EntityEntity(entityData.Position*64, entity)));
                }
                playerPosSprite.Position=mapData.PlayerPos*64;
                if(!sprites.Contains(playerPosSprite))
                sprites.Add(playerPosSprite);
            }
        }
    }

    enum SelectedEdit{
        Tile, PlayerPos, Entity, Item
    }
}