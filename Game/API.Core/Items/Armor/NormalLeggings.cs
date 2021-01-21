using System;
using Fish_Girlz.Items;
using SFML.Graphics;

namespace Fish_Girlz.API.Core.Items{
    public class NormalLeggings : LeggingsArmorItem
    {
        public NormalLeggings() : base("normal_leggings", "normal_leggings", AssetLoader.GetTexture(CoreAPIPlugin.Instance, "leggings"), 10)
        {
        }
    }
}