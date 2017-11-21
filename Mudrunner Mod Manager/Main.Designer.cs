namespace Mudrunner_Mod_Manager
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addModToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnRemoveMod = new System.Windows.Forms.Button();
            this.btnAddMod = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.listMods = new System.Windows.Forms.CheckedListBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.removeModToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(351, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "MudRunner Mod Manager";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addModToolStripMenuItem,
            this.removeModToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // addModToolStripMenuItem
            // 
            this.addModToolStripMenuItem.Name = "addModToolStripMenuItem";
            this.addModToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.addModToolStripMenuItem.Text = "&Add Mod...";
            this.addModToolStripMenuItem.Click += new System.EventHandler(this.AddMod);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(151, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.settingsToolStripMenuItem.Text = "Settings...";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnRemoveMod);
            this.panel1.Controls.Add(this.btnAddMod);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 237);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(351, 43);
            this.panel1.TabIndex = 1;
            // 
            // btnRemoveMod
            // 
            this.btnRemoveMod.Location = new System.Drawing.Point(227, 5);
            this.btnRemoveMod.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnRemoveMod.Name = "btnRemoveMod";
            this.btnRemoveMod.Size = new System.Drawing.Size(115, 30);
            this.btnRemoveMod.TabIndex = 1;
            this.btnRemoveMod.Text = "&Remove Mod";
            this.btnRemoveMod.UseVisualStyleBackColor = true;
            this.btnRemoveMod.Click += new System.EventHandler(this.RemoveMod);
            // 
            // btnAddMod
            // 
            this.btnAddMod.Location = new System.Drawing.Point(2, 5);
            this.btnAddMod.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAddMod.Name = "btnAddMod";
            this.btnAddMod.Size = new System.Drawing.Size(115, 30);
            this.btnAddMod.TabIndex = 0;
            this.btnAddMod.Text = "&Add Mod";
            this.btnAddMod.UseVisualStyleBackColor = true;
            this.btnAddMod.Click += new System.EventHandler(this.AddMod);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.listMods);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 24);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(351, 213);
            this.panel2.TabIndex = 2;
            // 
            // listMods
            // 
            this.listMods.CheckOnClick = true;
            this.listMods.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listMods.FormattingEnabled = true;
            this.listMods.Location = new System.Drawing.Point(0, 0);
            this.listMods.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.listMods.Name = "listMods";
            this.listMods.Size = new System.Drawing.Size(351, 213);
            this.listMods.TabIndex = 0;
            this.listMods.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.listMods_ItemCheck);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // removeModToolStripMenuItem
            // 
            this.removeModToolStripMenuItem.Name = "removeModToolStripMenuItem";
            this.removeModToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.removeModToolStripMenuItem.Text = "&Remove Mod...";
            this.removeModToolStripMenuItem.Click += new System.EventHandler(this.RemoveMod);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 280);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Main";
            this.Text = "Mudrunner Mod Manager";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addModToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnRemoveMod;
        private System.Windows.Forms.Button btnAddMod;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckedListBox listMods;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeModToolStripMenuItem;
    }
}

