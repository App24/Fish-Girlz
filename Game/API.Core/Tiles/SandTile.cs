using System;
using Fish_Girlz.Art;
using Fish_Girlz.Tiles;

namespace Fish_Girlz.API.Core.Tiles{
    public class SandTile : Tile
    {
        public SandTile() : base("sand", "sand", AssetLoader.GetTexture(CoreAPIPlugin.Instance, "sand tile"), false)
        {
        }
    }
}