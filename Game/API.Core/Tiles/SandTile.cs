using System;
using Fish_Girlz.Art;
using Fish_Girlz.Tiles;

namespace Fish_Girlz.API.Core.Tiles{
    public class SandTile : Tile
    {
        public SandTile() : base("sand", "sand", Utils.Utilities.CreateTexture(64,64, new SFML.Graphics.Color(237, 201, 175)), false)
        {
        }
    }
}