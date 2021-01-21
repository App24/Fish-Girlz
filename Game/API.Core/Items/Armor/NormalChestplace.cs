using Fish_Girlz.Items;
using SFML.Graphics;

namespace Fish_Girlz.API.Core.Items{
    public class NormalChestplace : ChestPlateArmorItem
    {
        public NormalChestplace() : base("normal_chestplate", "normal_chestplate", AssetLoader.GetTexture(CoreAPIPlugin.Instance, "chestplate"), 13)
        {
        }
    }
}