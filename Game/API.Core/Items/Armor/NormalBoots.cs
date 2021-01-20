using System;
using Fish_Girlz.Items;

namespace Fish_Girlz.API.Core.Items{
    public class NormalBoots : BootsArmorItem {
        public NormalBoots() : base("normal_boots", "normal_boots", AssetLoader.GetTexture(CoreAPIPlugin.Instance, "boots"), 5)
        {
        }
    }
}