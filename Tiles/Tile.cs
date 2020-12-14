using System;
using System.Collections.Generic;
using Fish_Girlz.Art;
using Fish_Girlz.Utils;

namespace Fish_Girlz.Tiles{
    public abstract class Tile {
        public int ID {get;}
        static List<Tile> tiles=new List<Tile>();
        public SpriteInfo Sprite{get;protected set;}
        public bool Collidable{get;protected set;}
        public string Name{get;}

        public static AirTile AIR=new AirTile();
        public static WallTile WALL=new WallTile();
        public static SandTile SAND=new SandTile();
        public static WaterTile WATER=new WaterTile();

        public Tile(string name, SpriteInfo sprite, bool collidable=true){
            ID=tiles.Count;
            Sprite=sprite;
            Collidable=collidable;
            Name=name;
            tiles.Add(this);
        }

        public static Tile GetTile(int id){
            Tile tile=tiles.Find(delegate(Tile _tile){if(_tile.ID==id)return true; return false;});
            return tile!=null?tile:AIR;
        }

        public static List<Tile> GetTiles(){
            return tiles.Clone();
        }
    }
}