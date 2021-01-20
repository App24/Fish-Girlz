using Newtonsoft.Json;

namespace Fish_Girlz.API{
    public struct Mod
    {
        public string Name{get;}
        public string ID{get;}
        public string Author{get;}
        public Version Version{get;}
        public bool Enabled{get;}
        public string AssemblyName{get;}

        [JsonConstructor]
        public Mod(string name, string id, string version, string assemblyName, string author, bool enabled)
        {
            Name = name;
            ID = id;
            Author = author;
            Version = API.Version.CreateFromString(version);
            Enabled = enabled;
            AssemblyName = assemblyName;
        }

        public Mod(string name, string id, string author, Version version)
        {
            Name = name;
            ID = id;
            Author = author;
            Version = version;
            Enabled = true;
            AssemblyName = "";
        }

        public override string ToString()
        {
            return $"ID: {ID}, Name: {Name}, Author: {Author}, Version: {Version}, Enabled: {Enabled}, AssemblyName: {AssemblyName}";
        }
    }
}