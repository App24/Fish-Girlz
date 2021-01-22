using System;
using Fish_Girlz.Art;

namespace Fish_Girlz.Tiles{
    internal class SandTile : Tile
    {
        public SandTile() : base("Sand", new SpriteInfo(Utils.Utilities.CreateTexture(64,64, new SFML.Graphics.Color(237, 201, 175)), new SFML.Graphics.IntRect(0,0,64,64)), false)
        {
        }
    }
}