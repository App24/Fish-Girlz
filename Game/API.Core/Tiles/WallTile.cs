using System;
using Fish_Girlz.Art;
using Fish_Girlz.Systems;
using Fish_Girlz.Tiles;

namespace Fish_Girlz.API.Core.Tiles{
    public class WallTile : Tile
    {
        public WallTile() : base("wall", "wall", Utils.Utilities.CreateTexture(64,64,SFML.Graphics.Color.White))
        {
        }
    }
}