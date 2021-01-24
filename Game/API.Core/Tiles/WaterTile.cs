using System;
using Fish_Girlz.Art;
using Fish_Girlz.Entities;
using Fish_Girlz.Utils;
using Fish_Girlz.Tiles;

namespace Fish_Girlz.API.Core.Tiles{
    public class WaterTile : TransformationTile
    {
        public WaterTile() : base("water", "water", Utils.Utilities.CreateTexture(64,64, new SFML.Graphics.Color(28,163,236)), true)
        {
        }
    }
}