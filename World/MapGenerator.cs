using System;
using System.Collections.Generic;
using System.IO;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using Fish_Girlz.Entities.Tiles;
using SFML.System;
using Fish_Girlz.Tiles;

namespace Fish_Girlz.World{
    public static class MapGenerator {
        public static int TileSize=64;

        private static List<TileEntity> tileEntities=new List<TileEntity>();
        public static int MapWidth=24;
        public static int MapHeight=24;

        private static string MapFile="res/maps/map01.dat";

        private static Vector2f playerPos;

        public static void InitMap(){
            if(!File.Exists(MapFile)){ return; }

            int counter = 0;  
            string line;
            string tempMap="";
            
            // Read the file and display it line by line.  
            System.IO.StreamReader file =
                new System.IO.StreamReader(MapFile);  
            while((line = file.ReadLine()) != null)  
            {
                if(counter==0){
                    string[] size=line.Split(",");
                    int x, y;
                    try
                    {
                        x=int.Parse(size[0]);
                    }
                    catch (System.FormatException)
                    {
                        throw new FormatException("Player X in "+MapFile+" is not an integer.");
                    }
                    try
                    {
                        y=int.Parse(size[1]);
                    }
                    catch (System.FormatException)
                    {
                        throw new FormatException("Player Y in "+MapFile+" is not an integer.");
                    }
                    playerPos=new Vector2f(x*TileSize, y*TileSize);
                }else{
                    tempMap+=line+"\n";
                }
                counter++;  
            }
            string[] height=tempMap.Split("\n");
            MapHeight=height.Length-1;
            string[] width=height[0].Split(",");
            MapWidth=width.Length;
            int[,] map=new int[MapWidth,MapHeight];
            for (int y = 0; y < MapHeight; y++)
            {
                string[] lineWidth=height[y].Split(",");
                for (int x = 0; x < lineWidth.Length; x++)
                {
                    string block=lineWidth[x];
                    int intBlock=0;
                    try{
                        intBlock=Int32.Parse(block);
                    }catch(System.FormatException){

                    }
                    map[x,y]=intBlock;
                }
            }


            for (int x = 0; x < MapWidth; x++)
            {
                for (int y = 0; y < MapHeight; y++)
                {
                    if(x>=0||x<=MapWidth-1||y>=0||y<=MapHeight-1){
                        tileEntities.Add(new TileEntity(new Vector2f(x*TileSize, y*TileSize), Tile.GetTile(map[x,y])));
                        //tileEntities.Add(new WallTileEntity(new SFML.System.Vector2f(x*TileSize,y*TileSize)));
                    }
                }
            }
        }

        public static List<TileEntity> GetTiles(){
            return tileEntities;
        }
        
        public static Vector2f GetPlayerPos(){
            return playerPos;
        }
    }
}