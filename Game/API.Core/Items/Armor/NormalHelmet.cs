using Fish_Girlz.Items;
using SFML.Graphics;

namespace Fish_Girlz.API.Core.Items{
    public class NormalHelmet : HelmetArmorItem
    {
        public NormalHelmet() : base("normal_helmet", "normal_helmet", AssetLoader.GetTexture(CoreAPIPlugin.Instance, "helmet"), 7.5f)
        {
        }
    }
}