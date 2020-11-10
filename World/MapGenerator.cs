using System;
using System.Collections.Generic;
using System.IO;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using Fish_Girlz.Entities.Tiles;
using SFML.System;

namespace Fish_Girlz.World{
    public static class MapGenerator {
        public static int TileSize=64;

        private static List<TileEntity> tiles=new List<TileEntity>();
        public static int MapWidth=24;
        public static int MapHeight=24;

        private static string MapFile="res/maps/map01.dat";

        private static Vector2f playerPos;

        public static void InitMap(){
            if(File.Exists(MapFile)){
                int counter = 0;  
                string line;  
                
                // Read the file and display it line by line.  
                System.IO.StreamReader file =
                    new System.IO.StreamReader(MapFile);  
                string map="";
                while((line = file.ReadLine()) != null)  
                {
                    if(counter==0){
                        string[] size=line.Split(",");
                        try
                        {
                            MapWidth=int.Parse(size[0]);
                        }
                        catch (System.FormatException)
                        {
                            throw new FormatException("Width in "+MapFile+" is not an integer.");
                        }
                        try
                        {
                            MapHeight=int.Parse(size[1]);
                        }
                        catch (System.FormatException)
                        {
                            throw new FormatException("Height in "+MapFile+" is not an integer.");
                        }
                    }else if(counter==1){
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
                        map+=line;
                    }
                    counter++;  
                } 
                
            }

            for (int x = 0; x < MapWidth; x++)
            {
                for (int y = 0; y < MapHeight; y++)
                {
                    if(x==0||x==MapWidth-1||y==0||y==MapHeight-1){
                        tiles.Add(new WallTileEntity(new SFML.System.Vector2f(x*TileSize,y*TileSize)));
                    }
                }
            }
        }

        public static List<TileEntity> GetTiles(){
            return tiles;
        }
        
        public static Vector2f GetPlayerPos(){
            return playerPos;
        }
    }
}