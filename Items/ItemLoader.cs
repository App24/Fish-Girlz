using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.IO;
using SFML.Graphics;
using Fish_Girlz.Utils;
using Newtonsoft.Json.Linq;
using Fish_Girlz.Systems;

namespace Fish_Girlz.Items{
    public static class ItemLoader {

        public static bool Loaded{get;private set;}

        public static void LoadItems(){
            if(Directory.Exists($"res/Items")){
                ProcessDirectory($"res/Items");
                Loaded=true;
            }
        }

        // Process all files in the directory passed in, recurse on any directories 
        // that are found, and process the files they contain.
        static void ProcessDirectory(string targetDirectory) 
        {
            // Process the list of files found in the directory.
            string [] fileEntries = Directory.GetFiles(targetDirectory);
            foreach(string fileName in fileEntries)
                ProcessFile(fileName);

            // Recurse into subdirectories of this directory.
            string [] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
            foreach(string subdirectory in subdirectoryEntries)
                ProcessDirectory(subdirectory);
        }
        
        // Insert logic for processing found files here.
        static void ProcessFile(string path) 
        {
            if(Path.GetExtension(path)==".json"){
                LoadItemData loadItemData=JsonConvert.DeserializeObject<LoadItemData>(File.ReadAllText(path));
                AssetManager.LoadTexture(loadItemData.TextureName, $"res/textures/items/{loadItemData.TextureName}");
                string id=Path.GetFileNameWithoutExtension(path);
                Texture texture=AssetManager.GetTexture(loadItemData.TextureName);
                List<ItemTypeData> itemData=loadItemData.ItemData;
                switch (loadItemData.Type)
                {
                    case ItemType.Potion:
                        Color potionColor=new Color(0,0,0,0);
                        PotionType potionType=PotionType.None;
                        Dictionary<string, object> valuePairs=new Dictionary<string, object>();
                        foreach (ItemTypeData item in itemData)
                        {
                            switch (item.Name.ToLower())
                            {
                                case "color":
                                    potionColor=item.GetValue<Color>();
                                    break;
                                case "potiontype":
                                    try{
                                        potionType=(PotionType)Enum.Parse(typeof(PotionType), item.GetValue<string>());
                                    }catch{
                                        potionType=PotionType.None;
                                    }
                                    break;
                                default:
                                    valuePairs.Add(item.Name.ToLower(), item.GetValue<int>());
                                    break;
                            }
                        }
                        new PotionItem(id, loadItemData.Name, texture, potionColor, potionType, valuePairs);
                        break;
                    case ItemType.Helmet:{
                        float defense=0;
                        foreach (ItemTypeData item in itemData)
                        {
                            switch (item.Name.ToLower())
                            {
                                case "defense":
                                    defense=item.GetValue<float>();
                                    break;
                            }
                        }
                        new HelmetArmorItem(id, loadItemData.Name, texture, defense);
                        }
                        break;
                    case ItemType.Chestplate:{
                        float defense=0;
                        foreach (ItemTypeData item in itemData)
                        {
                            switch (item.Name.ToLower())
                            {
                                case "defense":
                                    defense=item.GetValue<float>();
                                    break;
                            }
                        }
                        new ChestPlateArmorItem(id, loadItemData.Name, texture, defense);
                        }
                        break;
                    case ItemType.Leggings:{
                        float defense=0;
                        foreach (ItemTypeData item in itemData)
                        {
                            switch (item.Name.ToLower())
                            {
                                case "defense":
                                    defense=item.GetValue<float>();
                                    break;
                            }
                        }
                        new LeggingsArmorItem(id, loadItemData.Name, texture, defense);
                        }
                        break;
                    case ItemType.Boots:{
                        float defense=0;
                        foreach (ItemTypeData item in itemData)
                        {
                            switch (item.Name.ToLower())
                            {
                                case "defense":
                                    defense=item.GetValue<float>();
                                    break;
                            }
                        }
                        new BootsArmorItem(id, loadItemData.Name, texture, defense);
                        }
                        break;
                    case ItemType.Ring:{
                        StatModifier stat=StatModifier.None;
                        int amount=0;
                        foreach (ItemTypeData item in itemData)
                        {
                            switch (item.Name.ToLower())
                            {
                                case "stat":
                                    stat=(StatModifier)Enum.Parse(typeof(StatModifier), item.GetValue<string>());
                                    break;
                                case "amount":
                                    amount=item.GetValue<int>();
                                    break;
                            }
                        }
                        new RingItem(id, loadItemData.Name, texture, stat, amount);
                        }
                        break;
                    case ItemType.Necklace:{
                        StatModifier stat=StatModifier.None;
                        int amount=0;
                        foreach (ItemTypeData item in itemData)
                        {
                            switch (item.Name.ToLower())
                            {
                                case "stat":
                                    stat=(StatModifier)Enum.Parse(typeof(StatModifier), item.GetValue<string>());
                                    break;
                                case "amount":
                                    amount=item.GetValue<int>();
                                    break;
                            }
                        }
                        new NecklaceItem(id, loadItemData.Name, texture, stat, amount);
                        }
                        break;
                    case ItemType.Sword:
                        int damage=0;
                        foreach (ItemTypeData item in itemData)
                        {
                            switch (item.Name.ToLower())
                            {
                                case "damage":
                                    damage=item.GetValue<int>();
                                    break;
                            }
                        }
                        new SwordItem(id, loadItemData.Name, texture, damage);
                        break;
                    default:
                        new BasicItem(id, loadItemData.Name, new Art.SpriteInfo(AssetManager.GetTexture(loadItemData.TextureName), new IntRect(0,0,64,64)));
                        break;
                }
            }
        }

        class LoadItemData{
            public ItemType Type{get;}
            public List<ItemTypeData> ItemData{get;}
            public string Name{get;}
            public string TextureName{get;}

            public LoadItemData(ItemType type, string name, string textureName, List<ItemTypeData> itemData=null){
                Type=type;
                Name=name;
                TextureName=textureName;
                ItemData=itemData;
            }
        }

        struct ItemTypeData{
            public string Name{get;}
            public object Value{get;}

            public ItemTypeData(string name, object value){
                Name=name;
                Value=value;
            }

            public T GetValue<T>(){
                try{
                    return ((JObject)Convert.ChangeType(Value, typeof(JObject))).ToObject<T>();
                }catch{
                    return (T)Convert.ChangeType(Value, typeof(T));
                }
            }
        }
    
        enum ItemType{
            Potion, Sword,
            //Armor
            Helmet, Chestplate, Leggings, Boots,
            Ring, Necklace
        }
    }
}