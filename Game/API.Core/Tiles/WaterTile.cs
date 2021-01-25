using System;
using Fish_Girlz.Art;
using Fish_Girlz.Entities;
using Fish_Girlz.Utils;
using Fish_Girlz.Tiles;

namespace Fish_Girlz.API.Core.Tiles{
    public class WaterTile : TransformationTile
    {
        public WaterTile() : base("water", "water", AssetLoader.GetTexture(CoreAPIPlugin.Instance, "water tile"), true)
        {
        }
    }
}