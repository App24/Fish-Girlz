using System;
using Fish_Girlz.Art;
using Fish_Girlz.Utils;

namespace Fish_Girlz.Tiles{
    public class AirTile : Tile
    {
        internal AirTile() : base("air", "air", Utilities.CreateTexture(64,64,new SFML.Graphics.Color(0,0,0,0)), false)
        {
            Tile.AddTile(this);
        }
    }
}