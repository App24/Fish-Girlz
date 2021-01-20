using System;
using System.Collections.Generic;
using System.IO;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using Fish_Girlz.Entities.Tiles;
using SFML.System;
using Fish_Girlz.Tiles;
using Newtonsoft.Json;
using Fish_Girlz.Entities.Items;
using Fish_Girlz.Items;

namespace Fish_Girlz.World{
    public static class MapGenerator {
        public static int TileSize=64;

        private static List<TileEntity> tileEntities=new List<TileEntity>();
        private static List<ItemEntity> itemEntities=new List<ItemEntity>();
        public static int MapWidth=24;
        public static int MapHeight=24;

        private static string MapFile="res/maps/map.json";

        private static Vector2f playerPos;

        public static void InitMap(){
            if(!File.Exists(MapFile)){ return; }

            MapData mapData=JsonConvert.DeserializeObject<MapData>(File.ReadAllText(MapFile));
            playerPos=mapData.PlayerPos*64;
            tileEntities.Clear();
            itemEntities.Clear();
            foreach (TileData tileData in mapData.TilesData)
            {
                Tile tile=Tile.GetTile(tileData.ID);
                if(tile==null)continue;
                tileEntities.Add(new TileEntity(tileData.Position*64, tile));
            }
            foreach (ItemData itemData in mapData.ItemsData)
            {
                Item item=Item.GetItem(itemData.ID);
                if(item==null)continue;
                itemEntities.Add(new ItemEntity(itemData.Position*64, item));
            }
        }

        public static List<TileEntity> GetTileEntities(){
            return tileEntities;
        }
        
        public static Vector2f GetPlayerPos(){
            return playerPos;
        }

        public static List<ItemEntity> GetItemEntities(){
            return itemEntities;
        }
    }

    public struct TileData{
        public Vector2f Position{get;}
        public int ID{get;}

        public TileData(Vector2f position, int id){
            Position=position;
            ID=id;
        }
    }

    public struct ItemData{
        public Vector2f Position{get;}
        public string ID{get;}

        public ItemData(Vector2f position, string id){
            Position=position;
            ID=id;
        }
    }

    public struct MapData{
        public Vector2f PlayerPos{get;}
        public List<TileData> TilesData{get;}
        public List<ItemData> ItemsData{get;}

        public MapData(Vector2f playerPos, List<TileData> tilesData, List<ItemData> itemsData){
            PlayerPos=playerPos;
            TilesData=tilesData;
            ItemsData=itemsData;
        }
    }
}