using System;
using Fish_Girlz.Art;
using Fish_Girlz.Systems;
using Fish_Girlz.Tiles;

namespace Fish_Girlz.API.Core.Tiles{
    public class WallTile : Tile
    {
        public WallTile() : base("wall", "wall", AssetLoader.GetTexture(CoreAPIPlugin.Instance, "wall tile"))
        {
        }
    }
}