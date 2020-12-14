using System;
using Fish_Girlz.Art;
using Fish_Girlz.Utils;

namespace Fish_Girlz.Tiles{
    public class WallTile : Tile
    {
        public WallTile() : base("Wall", new SpriteInfo(AssetManager.GetTexture("temp"), new SFML.Graphics.IntRect(0,0,64,64)))
        {
        }
    }
}