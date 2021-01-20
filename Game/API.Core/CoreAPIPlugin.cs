using System;
using Fish_Girlz.Systems;
using Fish_Girlz.Items;
using Fish_Girlz.Localisation;

namespace Fish_Girlz.API.Core{
    public class CoreAPIPlugin : APIPlugin
    {
        public static CoreAPIPlugin Instance;

        public void LoadAssets()
        {
            AssetLoader.LoadTexture(this, "potion", "res/textures/items/potion.png");
            AssetLoader.LoadTexture(this, "boots", "res/textures/items/armor/normal/boots.png");
        }

        public override void OnUnload()
        {
            
        }

        public override void OnLoad()
        {
            Instance=this;
            LoadAssets();
            Language.GetDefault().AddLocalisation("item.health_potion", "Health Potion");
            Language.GetDefault().AddLocalisation("item.mana_potion", "Mana Potion");
        }

        public override void LoadItems(ItemLoader itemLoader)
        {
            itemLoader.AddItem(new Items.HealthPotion());
            itemLoader.AddItem(new Items.ManaPotion());
            itemLoader.AddItem(new Items.NormalBoots());
        }
    }
}