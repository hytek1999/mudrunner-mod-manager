using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mudrunner_Mod_Manager
{
    [Serializable]
    public class ModInfo
    {
        public ModInfo() { }

        public ModInfo(string modName, string filePath)
        {
            ModName = modName;
            FilePath = filePath; 
        }

        public string ModName { get; set; }
        public string FilePath { get; set; }

        public override string ToString()
        {
            return ModName; 
        }
    }
}
