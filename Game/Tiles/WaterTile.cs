using System;
using Fish_Girlz.Art;

namespace Fish_Girlz.Tiles{
    public class WaterTile : Tile
    {
        public WaterTile() : base("Water", new SpriteInfo(Utils.Utilities.CreateTexture(64,64, new SFML.Graphics.Color(28,163,236)), new SFML.Graphics.IntRect(0,0,64,64)), true)
        {
        }
    }
}