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

namespace Fish_Girlz.World{
    public static class MapGenerator {
        public static int TileSize=64;

        private static List<TileEntity> tileEntities=new List<TileEntity>();
        public static int MapWidth=24;
        public static int MapHeight=24;

        private static string MapFile="res/maps/map.json";

        private static Vector2f playerPos;

        public static void InitMap(){
            if(!File.Exists(MapFile)){ return; }

            MapData mapData=JsonConvert.DeserializeObject<MapData>(File.ReadAllText(MapFile));
            playerPos=mapData.PlayerPos*64;
            tileEntities.Clear();
            foreach (TileData tileData in mapData.TileData)
            {
                tileEntities.Add(new TileEntity(tileData.Position*64, Tile.GetTile(tileData.ID)));
            }
        }

        public static List<TileEntity> GetTiles(){
            return tileEntities;
        }
        
        public static Vector2f GetPlayerPos(){
            return playerPos;
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

    public struct MapData{
        public Vector2f PlayerPos{get;}
        public List<TileData> TileData{get;}

        public MapData(Vector2f playerPos, List<TileData> tileData){
            PlayerPos=playerPos;
            TileData=tileData;
        }
    }
}