using System.Collections.Generic;
using Fish_Girlz.Utils;
using SFML.Graphics;

namespace Fish_Girlz.Tiles{
    public abstract class Tile {
        
        public Texture Texture{get;}
        public bool Collidable{get;protected set;}

        static List<Tile> tiles=new List<Tile>();

        protected Tile(Texture texture){
            Texture=texture;
            tiles.Add(this);
        }

        public static Tile GetTile(int index){
            if(index>=tiles.Count) return null;
            return tiles[index];
        }

        public static List<Tile> GetTiles(){
            return tiles.Clone();
        }

    }
}