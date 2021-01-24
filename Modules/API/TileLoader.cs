using System;
using Fish_Girlz.Tiles;

namespace Fish_Girlz.API{
    public class TileLoader : APILoader
    {
        internal TileLoader(string id) : base(id)
        {
        }

        public void AddTile<T>(T tile) where T : Tile{
            Tile.AddTile(tile, ID);
        }
    }
}