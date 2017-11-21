using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Mudrunner_Mod_Manager
{
    public partial class Main : Form
    {
        ManagerSettings _settings;
        MRConfigHandler _configHandler; 

        public Main()
        {
            InitializeComponent();
            _settings = ManagerSettings.LoadSettings();
            if (_settings.isGameFolderValid(_settings.GameFolder) == ManagerSettings.GameFolderValidEnum.IsValid)
                _configHandler = MRConfigHandler.Load(Path.Combine(_settings.GameFolder, _settings.Defaults.MudrunnerConfig));

            RefreshModList(); 
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsWindow settingsWindow = new SettingsWindow();
            settingsWindow.ShowDialog(_settings);
            if (_settings.isGameFolderValid(_settings.GameFolder) == ManagerSettings.GameFolderValidEnum.IsValid)
                _configHandler = MRConfigHandler.Load(Path.Combine(_settings.GameFolder, _settings.Defaults.MudrunnerConfig));

        }

        private void AddMod(object sender, EventArgs e)
        {
            if (_settings.isGameFolderValid() != ManagerSettings.GameFolderValidEnum.IsValid)
            {
                MessageBox.Show("The SpinTires Mudrunner folder game folder is invalid. Please update the folder name in Settings.");
                return; 
            }

            openFileDialog.Filter = "Archive Files (*.zip, *.rar, *.7z)|*.zip;*.rar;*.7z|All Files (*.*)|*.*";
            openFileDialog.ShowDialog();

            Cursor.Current = Cursors.WaitCursor;

            string result = ModFileReader.OpenFile(openFileDialog.FileName, _settings);

            if (result == string.Empty) return;

            string modName = Path.GetFileNameWithoutExtension(openFileDialog.FileName);

            string modFolder = Path.Combine(_settings.GameFolder, _settings.Defaults.ModsFolderName);
            if (!Directory.Exists(modFolder)) Directory.CreateDirectory(modFolder);

            string modFileName = Path.Combine(modFolder, modName.Replace(" ", "_") + ".zip");

            File.Copy(result, modFileName);

            _settings.InstalledMods.Add(new ModInfo(modName, modFileName));
            _settings.SaveSettings();
            RefreshModList();

            Cursor.Current = Cursors.Default;
        }

        private void RemoveMod(object sender, EventArgs e)
        {
            ModInfo selectedMod = listMods.SelectedItem as ModInfo;
            if (selectedMod == null) return;

            if (DialogResult.No == MessageBox.Show(string.Format("Are you sure you wish to remove: {0}?", selectedMod.ModName), "Confirm Mod Removal", MessageBoxButtons.YesNo)) return;

            Cursor.Current = Cursors.WaitCursor;
            if (_configHandler != null)
            {
                string fileName = Path.GetFileName(selectedMod.FilePath);
                _configHandler.deactivateMod(fileName);
            }
            File.Delete(selectedMod.FilePath);
            _settings.InstalledMods.Remove(selectedMod);
            _settings.SaveSettings(); 
            RefreshModList();
            Cursor.Current = Cursors.Default;
        }

        private void RefreshModList()
        {
            List<string> activatedMods = new List<string>();
            if (_configHandler != null)
                activatedMods = _configHandler.getActivatedMods();

            listMods.Items.Clear();
            foreach (ModInfo item in _settings.InstalledMods)
            {
                int index = listMods.Items.Add(item);
                string fileName = Path.GetFileName(item.FilePath);
                if (activatedMods.Exists(m => m == fileName))
                    listMods.SetItemChecked(index, true);
            }
        }

        private void listMods_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (_configHandler == null)
            {
                e.NewValue = CheckState.Unchecked;
                return; 
            }

            Cursor.Current = Cursors.WaitCursor;
            ModInfo mod = (ModInfo)listMods.Items[e.Index];
            string fileName = Path.GetFileName(mod.FilePath);
            if (e.NewValue == CheckState.Checked)
            {
                _configHandler.activateMod(fileName);
            }
            else
            {
                _configHandler.deactivateMod(fileName);
            }
            Cursor.Current = Cursors.Default;
        }
    }
}
