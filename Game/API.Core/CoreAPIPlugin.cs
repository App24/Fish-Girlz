using System;
using Fish_Girlz.Systems;
using Fish_Girlz.Items;
using Fish_Girlz.Localisation;

namespace Fish_Girlz.API.Core{
    public class CoreAPIPlugin : APIPlugin
    {
        public static CoreAPIPlugin Instance;

        public override void LoadAssets()
        {
            AssetLoader.LoadTexture(this, "temp", "res/textures/temp.png");
            AssetLoader.LoadTexture(this, "potion", "res/textures/items/potion.png");
            AssetLoader.LoadTexture(this, "boots", "res/textures/items/armor/normal/boots.png");
            AssetLoader.LoadTexture(this, "leggings", "res/textures/items/armor/normal/leggings.png");
            AssetLoader.LoadTexture(this, "chestplate", "res/textures/items/armor/normal/chestplate.png");
            AssetLoader.LoadTexture(this, "helmet", "res/textures/items/armor/normal/helmet.png");
        }

        public override void OnUnload()
        {
            
        }

        public override void OnLoad()
        {
            Instance=this;
        }

        public override void LoadItems(ItemLoader itemLoader)
        {
            itemLoader.AddItem(new Items.HealthPotion());
            itemLoader.AddItem(new Items.ManaPotion());
            itemLoader.AddItem(new Items.NormalBoots());
            itemLoader.AddItem(new Items.NormalLeggings());
            itemLoader.AddItem(new Items.NormalChestplace());
            itemLoader.AddItem(new Items.NormalHelmet());
        }

        public override void LoadLocalisation(LocalisationLoader localisationLoader)
        {
            localisationLoader.AddItemLocalisation("health_potion", "Health Potion");
            localisationLoader.AddItemLocalisation("mana_potion", "Mana Potion");
            localisationLoader.AddItemLocalisation("normal_boots", "Normal Boots");
            localisationLoader.AddItemLocalisation("normal_leggings", "Normal Leggings");
            localisationLoader.AddItemLocalisation("normal_chestplate", "Normal Chestplate");
            localisationLoader.AddItemLocalisation("normal_helmet", "Normal Helmet");
        }

        public override void LoadEntities(EntityLoader entityLoader)
        {
            entityLoader.AddEntity(new Entities.TestEntity());
        }
    }
}