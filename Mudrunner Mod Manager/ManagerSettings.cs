using System;
using System.Collections.Generic;
using System.IO; 
using System.Xml.Serialization;

namespace Mudrunner_Mod_Manager
{
    [Serializable]
    public class ManagerSettings
    {
        public const string SETTINGS_FILE = "settings.xml";

        [Serializable]
        public class SettingsDefaults
        {
            public string ExeName = "MudRunner.exe";
            public string MudrunnerConfig = "config.xml";
            public string[] ModFolders = new string[] 
            {
                "levels", "billboards", "_templates",
                "classes", "joysticks", "scripts",
                "sounds", "strings"
            };
            public string[] LevelFiles = new string[] { "*.stg", "*.dds" };
            public string LevelFolderName = "Levels";
            public string ModsFolderName = "mods";
        }


        public enum GameFolderValidEnum
        {
            IsValid,
            FolderIsNotValid,
            MudrunnerEXEMissing
        }

        public SettingsDefaults Defaults = new SettingsDefaults(); 
        public string GameFolder = "C:\\Program Files (x86)\\Steam\\steamapps\\common\\Spintires MudRunner";
        public List<ModInfo> InstalledMods = new List<ModInfo>();

        public static ManagerSettings LoadSettings()
        {
            if (!File.Exists(SETTINGS_FILE)) return new ManagerSettings();

            using (FileStream stream = new FileStream(SETTINGS_FILE, FileMode.Open))
            {
                XmlSerializer mySerializer = new XmlSerializer(typeof(ManagerSettings));
                return (ManagerSettings)mySerializer.Deserialize(stream);
            }
        }

        public bool SaveSettings()
        {
            using (FileStream stream = new FileStream(SETTINGS_FILE, FileMode.Create))
            {
                XmlSerializer mySerializer = new XmlSerializer(typeof(ManagerSettings));
                mySerializer.Serialize(stream, this);
            }
            return true; 
        }

        public GameFolderValidEnum isGameFolderValid()
        {
            return isGameFolderValid(this.GameFolder);
        }

        public GameFolderValidEnum isGameFolderValid(string gameFolder)
        {
            if (!Directory.Exists(gameFolder)) return GameFolderValidEnum.FolderIsNotValid;

            if (!File.Exists(Path.Combine(gameFolder, Defaults.ExeName))) return GameFolderValidEnum.MudrunnerEXEMissing;

            return GameFolderValidEnum.IsValid; 
        }
    }
}
