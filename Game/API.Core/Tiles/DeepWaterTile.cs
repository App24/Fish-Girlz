using System;
using Fish_Girlz.Art;
using Fish_Girlz.Entities;
using Fish_Girlz.Utils;
using Fish_Girlz.Tiles;

namespace Fish_Girlz.API.Core.Tiles{
    public class DeepWaterTile : TransformationTile
    {
        public DeepWaterTile() : base("deep_water", "deep_water", AssetLoader.GetTexture(CoreAPIPlugin.Instance, "deep_water tile"), true)
        {
        }
    }
}