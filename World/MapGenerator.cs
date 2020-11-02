using System;
using System.Collections.Generic;
using System.IO;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using Fish_Girlz.Entities.Tiles;

namespace Fish_Girlz.World{
    public static class MapGenerator {
        public static int TileSize=64;

        private static List<TileEntity> tiles=new List<TileEntity>();
        public static int MapSize=24;

        public static void InitMap(){
            for (int x = -MapSize/2; x <= MapSize/2; x++)
            {
                for (int y = -MapSize/2; y <= MapSize/2; y++)
                {
                    if(x==-MapSize/2||x==MapSize/2||y==-MapSize/2||y==MapSize/2){
                        tiles.Add(new WallTileEntity(new SFML.System.Vector2f(x*TileSize,y*TileSize)));
                    }
                }
            }
        }

        public static List<TileEntity> GetTiles(){
            return tiles;
        }
    }
}