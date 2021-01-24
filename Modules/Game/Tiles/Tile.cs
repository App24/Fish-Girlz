using System;
using System.Collections.Generic;
using Fish_Girlz.Art;
using Fish_Girlz.Utils;
using SFML.Graphics;
using SFML.System;

namespace Fish_Girlz.Tiles{
    public abstract class Tile {
        public string ID {get;private set;}
        static List<Tile> tiles=new List<Tile>();
        public SpriteInfo Sprite{get;protected set;}
        public bool Collidable{get;protected set;}
        public string Name{get;private set;}

        public static AirTile AIR=new AirTile();

        public Tile(string id, string name, Texture texture, bool collidable=true):this(id,name,texture,new Vector2i(), collidable){
        }

        public Tile(string id, string name, Texture texture, Vector2i offset, bool collidable=true){
            ID=id;
            Name=name;
            if(!Name.StartsWith("tile.")) Name=$"tile.{Name}";
            Sprite=new SpriteInfo(texture, new IntRect(offset.X, offset.Y, Statics.UNIT_SIZE, Statics.UNIT_SIZE));
            Collidable=collidable;
        }

        public static Tile GetTile(string id){
            Tile tile=tiles.Find(delegate(Tile _tile){if(_tile.ID==id)return true; return false;});
            return tile!=null?tile:AIR;
        }

        internal static void AddTile<T>(T tile, string modId="") where T : Tile{
            if(!string.IsNullOrEmpty(modId)){
                tile.ID=$"{modId}.{tile.ID}";
                tile.Name=$"{modId}.{tile.Name}";
            }
            if(tiles.Find(delegate(Tile other){if(other.ID==tile.ID) return true; return false;})!=null) return;
            tiles.Add(tile);
        }

        public static List<Tile> GetTiles(){
            return tiles.Clone();
        }

        public virtual CollisionBehaviour OnEnterCollision(CollisionEventArgs e){
            return CollisionBehaviour.Collision;
        }

        public virtual CollisionBehaviour OnContiueCollision(CollisionEventArgs e){
            return CollisionBehaviour.Collision;
        }

        public virtual void OnExitCollision(CollisionEventArgs e){

        }
    }
}