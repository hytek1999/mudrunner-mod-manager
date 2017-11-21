using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Mudrunner_Mod_Manager
{
    public partial class SettingsWindow : Form
    {
        ManagerSettings _settings; 

        public SettingsWindow()
        {
            InitializeComponent();
        }

        public DialogResult ShowDialog(ManagerSettings settings)
        {
            _settings = settings;
            txtGameFolder.Text = _settings.GameFolder;

            return ShowDialog(); 
        }

        private void cmdBrowse_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(txtGameFolder.Text)) folderBrowserDialog.SelectedPath = txtGameFolder.Text;

            if (DialogResult.OK == folderBrowserDialog.ShowDialog())
            {
                txtGameFolder.Text = folderBrowserDialog.SelectedPath;
                if (!SaveSettings()) 
                    txtGameFolder.Text = _settings.GameFolder;
            }
        }

        private void SettingsWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (!SaveSettings())
                {
                    e.Cancel = true;
                }
            }
        }

        private bool SaveSettings()
        {
            string dialogText = string.Empty;

            switch (_settings.isGameFolderValid(txtGameFolder.Text))
            {
                case ManagerSettings.GameFolderValidEnum.FolderIsNotValid:
                    dialogText = "Spin Tires Mudrunner folder is not a valid folder.";
                    break;
                case ManagerSettings.GameFolderValidEnum.MudrunnerEXEMissing:
                    dialogText = string.Format("{0} not found in selected folder.", _settings.Defaults.ExeName);
                    break;
                default:
                    _settings.GameFolder = txtGameFolder.Text;
                    _settings.SaveSettings();
                    break;
            }

            if (dialogText != string.Empty)
                return (DialogResult.OK == MessageBox.Show(dialogText, "Mudrunner Mod Manager", MessageBoxButtons.OKCancel));

            return true; 
        }

        private void SettingsWindow_Load(object sender, EventArgs e)
        {

        }
    }
}
