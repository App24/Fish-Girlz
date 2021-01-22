using System;
using Fish_Girlz.Art;
using Fish_Girlz.Utils;

namespace Fish_Girlz.Tiles{
    internal class AirTile : Tile
    {
        public AirTile() : base("Air", new SpriteInfo(Utilities.CreateTexture(64,64,new SFML.Graphics.Color(0,0,0,0)), new SFML.Graphics.IntRect(0,0,64,64)), false)
        {
        }
    }
}