using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Mudrunner_Mod_Manager
{
    public class ModNotFoundException : Exception { public ModNotFoundException(string message) : base(message) { } };

    public class MRConfigHandler
    {
        private const string ROOT_ELEMENT = "Config";
        private const string MEDIAPATHS_ROOT = ROOT_ELEMENT; 
        private const string MEDIAPATH_ELEMENT = "MediaPath";
        private const string PATH_ATTR = "Path";
        private const string MODS_DIR = "/mods/";

        private Dictionary<string, string> additionalAttrs = new Dictionary<string, string>()
            { { "DoPrepend", "true" } };

        private bool _isValid = false;
        private string _filePath = "";
        private Exception _lastException = null; 

        private MRConfigHandler() { }

        public static MRConfigHandler Load(string configFilePath)
        {
            MRConfigHandler handler = new MRConfigHandler();
            handler._filePath = configFilePath; 

            XDocument doc = XDocument.Load(configFilePath);
            
            if (doc.Root.Name.LocalName == ROOT_ELEMENT)
            {
                List<XElement> mediaPaths = doc.Descendants(MEDIAPATH_ELEMENT).ToList();
                if (mediaPaths.Count > 0) handler._isValid = true; 
            }

            return handler;             
        }

        public string filePath { get { return _filePath; } }
        public bool isValid { get { return _isValid; } }
        public Exception lastException { get { return _lastException; } }

        public List<string> getActivatedMods()
        {
            if (!_isValid) return new List<string>();

            XDocument doc = XDocument.Load(_filePath);
            List<string> modPaths = doc.Descendants(MEDIAPATH_ELEMENT).Select(e => e.Attribute(PATH_ATTR).Value).ToList();

            return modPaths.Where(p => p.StartsWith(MODS_DIR)).Select(p => p.Replace(MODS_DIR, "")).ToList();
        }

        public bool deactivateMod(string modFileName)
        {
            string modFilePath = MODS_DIR + modFileName; 
            XDocument doc = XDocument.Load(_filePath);
            XElement modElement = doc.Descendants(MEDIAPATH_ELEMENT).Where(e => e.Attribute(PATH_ATTR).Value == modFilePath).FirstOrDefault();
            if (modElement != null)
            {
                modElement.Remove();
                try
                {
                    doc.Save(_filePath);
                }
                catch (Exception ex)
                {
                    _lastException = ex;
                    return false;
                }
                return true; 
            }
            else
            {
                _lastException = new ModNotFoundException(string.Format("{0} was not found in {1}", modFileName, _filePath));
                return false;
            }
        }

        public bool activateMod(string modFileName)
        {
            string modFilePath = MODS_DIR + modFileName;

            XDocument doc = XDocument.Load(_filePath);
            XElement root = doc.Descendants(MEDIAPATHS_ROOT).FirstOrDefault();

            List<XElement> existingMods = root.Descendants().Where(
                m => m.Name == MEDIAPATH_ELEMENT &&
                m.Attributes().Count(a => a.Name == PATH_ATTR && a.Value == modFilePath) > 0
                )
                .ToList();

            if (existingMods.Count > 0)
            {
                return true;
            }

            XElement mediaPath = new XElement(MEDIAPATH_ELEMENT);
            mediaPath.Add(new XAttribute(PATH_ATTR, modFilePath));
            foreach (var item in additionalAttrs)
            {
                mediaPath.Add(new XAttribute(item.Key, item.Value));
            }
            root.Add(mediaPath);
            try
            {
                doc.Save(_filePath);
            }
            catch (Exception ex)
            {
                _lastException = ex;
                return false;
            }
            return true; 
        }
    }
}
