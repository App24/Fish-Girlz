using System;
using System.IO;
using System.Collections.Generic;
using Fish_Girlz.Utils;
using Fish_Girlz.Systems;
using Newtonsoft.Json;
using System.Reflection;

namespace Fish_Girlz.API.Loader{
    public static class PluginLoader {
        static List<Plugin> plugins=new List<Plugin>();

        public static void AddPlugin<T>(T plugin) where T : Plugin{
            plugins.Add(plugin);
        }

        public static void LoadPlugins(){
            string modsFolder=Path.Combine(Utilities.ExecutingFolder, "mods");
            if(!Directory.Exists(modsFolder)) Directory.CreateDirectory(modsFolder);
            ProcessDirectory(modsFolder);
            foreach (var plugin in plugins)
            {
                plugin.APIPlugin.Directory=plugin.Directory;
                plugin.APIPlugin.ID=plugin.Mod.ID;
            }
            Load();
        }

        static void ProcessDirectory(string targetDirectory) 
        {
            string [] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
            foreach(string subdirectory in subdirectoryEntries){
                string [] fileEntries = Directory.GetFiles(subdirectory);
                foreach(string fileName in fileEntries)
                    ProcessFile(fileName);
            }
        }

        static void ProcessFile(string fileName){
            if(Path.GetFileName(fileName).ToLower()=="mod.json"){
                Mod mod=JsonConvert.DeserializeObject<Mod>(File.ReadAllText(fileName));
                if(!mod.Enabled) return;
                try{
                    AddPlugin(TryToLoadPlugin(mod, Path.GetDirectoryName(fileName)));
                    Logger.Log($"Loaded Plugin: {mod.Name}");
                }catch(Exception e){
                    Logger.Log($"Could not load {mod.Name}, because {e.Message}", Logger.LogLevel.Warn);
                    return;
                }
            }
        }

        static Plugin TryToLoadPlugin(Mod mod, string directory){
            if(string.IsNullOrEmpty(mod.Name)) throw new Exception("No Name");
            if(string.IsNullOrEmpty(mod.ID)) throw new Exception("No ID");
            if(string.IsNullOrEmpty(mod.AssemblyName)) throw new Exception("No AssemblyName");
            Assembly assembly=null;
            try{
                assembly=Assembly.LoadFile(Path.Combine(directory, mod.AssemblyName));
            }catch(FileNotFoundException){
                throw new Exception($"Was not possible to find {mod.AssemblyName}");
            }
            APIPlugin apiPlugin=null;
            foreach (var type in assembly.GetTypes())
            {
                if(type.IsSubclassOf(typeof(APIPlugin))){
                    dynamic plugin=Activator.CreateInstance(type);
                    if(apiPlugin!=null) throw new Exception($"Multiple APIPlugins detected in {mod.AssemblyName}");
                    apiPlugin=plugin;
                }
            }
            if(apiPlugin==null) throw new Exception($"No APIPlugin was detected in {mod.AssemblyName}");
            if(plugins.Find(delegate(Plugin plugin){return mod.ID==plugin.Mod.ID;})!=null) throw new Exception($"There is a plugin by the ID {mod.ID} already loaded!");
            
            return new Plugin(apiPlugin, mod, directory);
        }

        static void Load(){
            foreach (var plugin in plugins)
            {
                plugin.APIPlugin.OnLoad();
            }
        }

        public static void UnloadPlugins(){
            foreach (var plugin in plugins)
            {
                plugin.APIPlugin.OnUnload();
            }
        }

        public static void LoadItems(){
            foreach (var plugin in plugins)
            {
                ItemLoader itemLoader=new ItemLoader(plugin.Mod.ID);
                plugin.APIPlugin.LoadItems(itemLoader);
            }
        }

        public static void LoadLocalisation(){
            foreach (var plugin in plugins)
            {
                LocalisationLoader localisationLoader=new LocalisationLoader(plugin.Mod.ID);
                plugin.APIPlugin.LoadLocalisation(localisationLoader);
            }
        }

        public static void LoadAssets(){
            foreach (var plugin in plugins)
            {
                plugin.APIPlugin.LoadAssets();
            }
        }

        public static void LoadEntities(){
            foreach (var plugin in plugins)
            {
                EntityLoader entityLoader=new EntityLoader(plugin.Mod.ID);
                plugin.APIPlugin.LoadEntities(entityLoader);
            }
        }
    }
}