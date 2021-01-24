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
using Fish_Girlz.Entities;
using Fish_Girlz.Items;
using Fish_Girlz.Utils;

namespace Fish_Girlz.World{
    public static class MapGenerator {
        private static List<EntityEntity> tileEntities=new List<EntityEntity>();
        private static List<EntityEntity> itemEntities=new List<EntityEntity>();
        private static List<EntityEntity> entityEntities=new List<EntityEntity>();

        private static Vector2f playerPos;

        public static void InitMap(string map="map"){
            string mapFile=Path.Combine(Utilities.ExecutingFolder, "res/maps", $"{map}.json");
            if(!File.Exists(mapFile)){ return; }

            MapData mapData=JsonConvert.DeserializeObject<MapData>(File.ReadAllText(mapFile));
            playerPos=mapData.PlayerPos*Statics.UNIT_SIZE;
            tileEntities.Clear();
            itemEntities.Clear();
            entityEntities.Clear();
            foreach (TileData tileData in mapData.TilesData)
            {
                Tile tile=Tile.GetTile(tileData.ID);
                if(tile==null)continue;
                tileEntities.Add(new EntityEntity(tileData.Position*Statics.UNIT_SIZE, new TileEntity(tile)));
            }
            foreach (ItemData itemData in mapData.ItemsData)
            {
                Item item=Item.GetItem(itemData.ID);
                if(item==null)continue;
                itemEntities.Add(new EntityEntity(itemData.Position*Statics.UNIT_SIZE, new ItemEntity(item)));
            }
            foreach (EntityData entityData in mapData.EntitiesData)
            {
                Entity entity=Entity.GetMapEntity(entityData.ID);
                if(entity==null)continue;
                entityEntities.Add(new EntityEntity(entityData.Position*Statics.UNIT_SIZE, entity));
            }
        }

        public static List<EntityEntity> GetTileEntities(){
            return tileEntities;
        }
        
        public static Vector2f GetPlayerPos(){
            return playerPos;
        }

        public static List<EntityEntity> GetItemEntities(){
            return itemEntities;
        }

        public static List<EntityEntity> GetEntityEntities(){
            return entityEntities;
        }
    }

    public struct TileData{
        public Vector2f Position{get;}
        public string ID{get;}

        public TileData(Vector2f position, string id){
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

    public struct EntityData{
        public Vector2f Position{get;}
        public string ID{get;}

        public EntityData(Vector2f position, string id){
            Position=position;
            ID=id;
        }
    }

    public struct MapData{
        public Vector2f PlayerPos{get;}
        public List<TileData> TilesData{get;}
        public List<ItemData> ItemsData{get;}
        public List<EntityData> EntitiesData{get;}

        public MapData(Vector2f playerPos, List<TileData> tilesData, List<ItemData> itemsData, List<EntityData> entitiesData){
            PlayerPos=playerPos;
            TilesData=tilesData;
            ItemsData=itemsData;
            EntitiesData=entitiesData;
        }
    }
}