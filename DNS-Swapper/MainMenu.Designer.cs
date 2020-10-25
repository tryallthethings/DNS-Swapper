namespace DNS_Swapper
{
    partial class MainMenu
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
            this.NIC_select = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.IPerrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.taskBarIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.notify_context = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.IPv4_Label = new System.Windows.Forms.Label();
            this.IPv4_Text = new System.Windows.Forms.Label();
            this.NIC_info = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.IPv6_GW_Text = new System.Windows.Forms.Label();
            this.IPv6_Label = new System.Windows.Forms.Label();
            this.IPv6_Text = new System.Windows.Forms.Label();
            this.GW_Label = new System.Windows.Forms.Label();
            this.IPv4_GW_Text = new System.Windows.Forms.Label();
            this.settingsGB = new System.Windows.Forms.GroupBox();
            this.activeNICsCB = new System.Windows.Forms.CheckBox();
            this.refreshBTN = new System.Windows.Forms.Button();
            this.DNS_2 = new IPAddressControlLib.IPAddressControl();
            this.DNS_1 = new IPAddressControlLib.IPAddressControl();
            this.toggle_DNS = new ToggleBox();
            this.Warning = new System.Windows.Forms.Label();
            this.checkForUpdatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IPerrorProvider)).BeginInit();
            this.notify_context.SuspendLayout();
            this.NIC_info.SuspendLayout();
            this.settingsGB.SuspendLayout();
            this.SuspendLayout();
            // 
            // NIC_select
            // 
            this.NIC_select.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.NIC_select.FormattingEnabled = true;
            this.NIC_select.Location = new System.Drawing.Point(10, 57);
            this.NIC_select.Name = "NIC_select";
            this.NIC_select.Size = new System.Drawing.Size(324, 21);
            this.NIC_select.TabIndex = 0;
            this.NIC_select.SelectedIndexChanged += new System.EventHandler(this.updateIP);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Network interface";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(244, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Ad-Blocking DNS";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(645, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.Resize += new System.EventHandler(this.menuStrip1_Resize);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.resetToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // resetToolStripMenuItem
            // 
            this.resetToolStripMenuItem.Name = "resetToolStripMenuItem";
            this.resetToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.resetToolStripMenuItem.Text = "Reset";
            this.resetToolStripMenuItem.Click += new System.EventHandler(this.resetToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.checkForUpdatesToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(24, 20);
            this.toolStripMenuItem1.Text = "?";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 186);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(645, 22);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // IPerrorProvider
            // 
            this.IPerrorProvider.ContainerControl = this;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Regular DNS";
            // 
            // taskBarIcon
            // 
            this.taskBarIcon.ContextMenuStrip = this.notify_context;
            this.taskBarIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("taskBarIcon.Icon")));
            this.taskBarIcon.Text = "DNS-Swapper";
            this.taskBarIcon.Visible = true;
            this.taskBarIcon.DoubleClick += new System.EventHandler(this.taskBarIcon_DoubleClick);
            this.taskBarIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.taskBarIcon_Click);
            // 
            // notify_context
            // 
            this.notify_context.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.exitToolStripMenuItem1});
            this.notify_context.Name = "notify_context";
            this.notify_context.Size = new System.Drawing.Size(104, 48);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            this.exitToolStripMenuItem1.Size = new System.Drawing.Size(103, 22);
            this.exitToolStripMenuItem1.Text = "Exit";
            this.exitToolStripMenuItem1.Click += new System.EventHandler(this.exitToolStripMenuItem1_Click);
            // 
            // IPv4_Label
            // 
            this.IPv4_Label.AutoSize = true;
            this.IPv4_Label.Location = new System.Drawing.Point(6, 16);
            this.IPv4_Label.Name = "IPv4_Label";
            this.IPv4_Label.Size = new System.Drawing.Size(72, 13);
            this.IPv4_Label.TabIndex = 10;
            this.IPv4_Label.Text = "IPv4 address:";
            // 
            // IPv4_Text
            // 
            this.IPv4_Text.AutoSize = true;
            this.IPv4_Text.Location = new System.Drawing.Point(84, 16);
            this.IPv4_Text.Name = "IPv4_Text";
            this.IPv4_Text.Size = new System.Drawing.Size(17, 13);
            this.IPv4_Text.TabIndex = 11;
            this.IPv4_Text.Text = "IP";
            // 
            // NIC_info
            // 
            this.NIC_info.Controls.Add(this.label4);
            this.NIC_info.Controls.Add(this.IPv6_GW_Text);
            this.NIC_info.Controls.Add(this.IPv6_Label);
            this.NIC_info.Controls.Add(this.IPv6_Text);
            this.NIC_info.Controls.Add(this.GW_Label);
            this.NIC_info.Controls.Add(this.IPv4_GW_Text);
            this.NIC_info.Controls.Add(this.IPv4_Label);
            this.NIC_info.Controls.Add(this.IPv4_Text);
            this.NIC_info.Location = new System.Drawing.Point(358, 27);
            this.NIC_info.Name = "NIC_info";
            this.NIC_info.Size = new System.Drawing.Size(275, 129);
            this.NIC_info.TabIndex = 13;
            this.NIC_info.TabStop = false;
            this.NIC_info.Text = "NIC Info";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "IPv6 Gateway:";
            // 
            // IPv6_GW_Text
            // 
            this.IPv6_GW_Text.AutoSize = true;
            this.IPv6_GW_Text.Location = new System.Drawing.Point(84, 86);
            this.IPv6_GW_Text.Name = "IPv6_GW_Text";
            this.IPv6_GW_Text.Size = new System.Drawing.Size(26, 13);
            this.IPv6_GW_Text.TabIndex = 17;
            this.IPv6_GW_Text.Text = "GW";
            // 
            // IPv6_Label
            // 
            this.IPv6_Label.AutoSize = true;
            this.IPv6_Label.Location = new System.Drawing.Point(6, 67);
            this.IPv6_Label.Name = "IPv6_Label";
            this.IPv6_Label.Size = new System.Drawing.Size(72, 13);
            this.IPv6_Label.TabIndex = 15;
            this.IPv6_Label.Text = "IPv6 address:";
            // 
            // IPv6_Text
            // 
            this.IPv6_Text.AutoSize = true;
            this.IPv6_Text.Location = new System.Drawing.Point(84, 67);
            this.IPv6_Text.Name = "IPv6_Text";
            this.IPv6_Text.Size = new System.Drawing.Size(17, 13);
            this.IPv6_Text.TabIndex = 16;
            this.IPv6_Text.Text = "IP";
            // 
            // GW_Label
            // 
            this.GW_Label.AutoSize = true;
            this.GW_Label.Location = new System.Drawing.Point(6, 37);
            this.GW_Label.Name = "GW_Label";
            this.GW_Label.Size = new System.Drawing.Size(77, 13);
            this.GW_Label.TabIndex = 14;
            this.GW_Label.Text = "IPv4 Gateway:";
            // 
            // IPv4_GW_Text
            // 
            this.IPv4_GW_Text.AutoSize = true;
            this.IPv4_GW_Text.Location = new System.Drawing.Point(84, 37);
            this.IPv4_GW_Text.Name = "IPv4_GW_Text";
            this.IPv4_GW_Text.Size = new System.Drawing.Size(26, 13);
            this.IPv4_GW_Text.TabIndex = 13;
            this.IPv4_GW_Text.Text = "GW";
            // 
            // settingsGB
            // 
            this.settingsGB.Controls.Add(this.activeNICsCB);
            this.settingsGB.Controls.Add(this.refreshBTN);
            this.settingsGB.Controls.Add(this.DNS_2);
            this.settingsGB.Controls.Add(this.DNS_1);
            this.settingsGB.Controls.Add(this.label1);
            this.settingsGB.Controls.Add(this.NIC_select);
            this.settingsGB.Controls.Add(this.toggle_DNS);
            this.settingsGB.Controls.Add(this.label2);
            this.settingsGB.Controls.Add(this.label3);
            this.settingsGB.Location = new System.Drawing.Point(12, 27);
            this.settingsGB.Name = "settingsGB";
            this.settingsGB.Size = new System.Drawing.Size(340, 129);
            this.settingsGB.TabIndex = 14;
            this.settingsGB.TabStop = false;
            this.settingsGB.Text = "Settings";
            // 
            // activeNICsCB
            // 
            this.activeNICsCB.AutoSize = true;
            this.activeNICsCB.Checked = true;
            this.activeNICsCB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.activeNICsCB.Location = new System.Drawing.Point(6, 19);
            this.activeNICsCB.Name = "activeNICsCB";
            this.activeNICsCB.Size = new System.Drawing.Size(244, 17);
            this.activeNICsCB.TabIndex = 13;
            this.activeNICsCB.Text = "Only list active (connected) network interfaces";
            this.activeNICsCB.UseVisualStyleBackColor = true;
            this.activeNICsCB.CheckStateChanged += new System.EventHandler(this.activeNICsCB_CheckStateChanged);
            // 
            // refreshBTN
            // 
            this.refreshBTN.Location = new System.Drawing.Point(259, 19);
            this.refreshBTN.Name = "refreshBTN";
            this.refreshBTN.Size = new System.Drawing.Size(75, 23);
            this.refreshBTN.TabIndex = 12;
            this.refreshBTN.Text = "Refresh";
            this.refreshBTN.UseVisualStyleBackColor = true;
            this.refreshBTN.Click += new System.EventHandler(this.refreshBTN_Click);
            // 
            // DNS_2
            // 
            this.DNS_2.AllowInternalTab = false;
            this.DNS_2.AutoHeight = true;
            this.DNS_2.BackColor = System.Drawing.SystemColors.Window;
            this.DNS_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DNS_2.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.DNS_2.Location = new System.Drawing.Point(247, 97);
            this.DNS_2.MinimumSize = new System.Drawing.Size(87, 20);
            this.DNS_2.Name = "DNS_2";
            this.DNS_2.ReadOnly = false;
            this.DNS_2.Size = new System.Drawing.Size(87, 20);
            this.DNS_2.TabIndex = 11;
            this.DNS_2.Text = "...";
            this.DNS_2.Leave += new System.EventHandler(this.ValidateIPField);
            // 
            // DNS_1
            // 
            this.DNS_1.AllowInternalTab = false;
            this.DNS_1.AutoHeight = true;
            this.DNS_1.BackColor = System.Drawing.SystemColors.Window;
            this.DNS_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DNS_1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.DNS_1.Location = new System.Drawing.Point(10, 97);
            this.DNS_1.MinimumSize = new System.Drawing.Size(87, 20);
            this.DNS_1.Name = "DNS_1";
            this.DNS_1.ReadOnly = false;
            this.DNS_1.Size = new System.Drawing.Size(87, 20);
            this.DNS_1.TabIndex = 10;
            this.DNS_1.Text = "...";
            this.DNS_1.Leave += new System.EventHandler(this.ValidateIPField);
            // 
            // toggle_DNS
            // 
            this.toggle_DNS.AutoSize = true;
            this.toggle_DNS.Location = new System.Drawing.Point(125, 93);
            this.toggle_DNS.Name = "toggle_DNS";
            this.toggle_DNS.Padding = new System.Windows.Forms.Padding(6);
            this.toggle_DNS.Size = new System.Drawing.Size(96, 29);
            this.toggle_DNS.TabIndex = 9;
            this.toggle_DNS.Text = "toggle_DNS";
            this.toggle_DNS.UseVisualStyleBackColor = true;
            this.toggle_DNS.CheckedChanged += new System.EventHandler(this.toggle_DNS_CheckedChanged);
            // 
            // Warning
            // 
            this.Warning.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Warning.AutoSize = true;
            this.Warning.Location = new System.Drawing.Point(12, 164);
            this.Warning.Name = "Warning";
            this.Warning.Size = new System.Drawing.Size(626, 13);
            this.Warning.TabIndex = 15;
            this.Warning.Text = "Note: Using this tool will remove any configured DNS servers on the selected netw" +
    "ork interface and replace it with the value above!";
            // 
            // checkForUpdatesToolStripMenuItem
            // 
            this.checkForUpdatesToolStripMenuItem.Name = "checkForUpdatesToolStripMenuItem";
            this.checkForUpdatesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.checkForUpdatesToolStripMenuItem.Text = "Check for Updates";
            this.checkForUpdatesToolStripMenuItem.Click += new System.EventHandler(this.checkForUpdatesToolStripMenuItem_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 208);
            this.Controls.Add(this.Warning);
            this.Controls.Add(this.settingsGB);
            this.Controls.Add(this.NIC_info);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(661, 247);
            this.MinimumSize = new System.Drawing.Size(661, 247);
            this.Name = "MainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DNS-Swapper";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IPerrorProvider)).EndInit();
            this.notify_context.ResumeLayout(false);
            this.NIC_info.ResumeLayout(false);
            this.NIC_info.PerformLayout();
            this.settingsGB.ResumeLayout(false);
            this.settingsGB.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox NIC_select;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ErrorProvider IPerrorProvider;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NotifyIcon taskBarIcon;
        private System.Windows.Forms.ContextMenuStrip notify_context;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
        private ToggleBox toggle_DNS;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.Label IPv4_Text;
        private System.Windows.Forms.Label IPv4_Label;
        private System.Windows.Forms.GroupBox NIC_info;
        private System.Windows.Forms.Label IPv4_GW_Text;
        private System.Windows.Forms.GroupBox settingsGB;
        private System.Windows.Forms.Label GW_Label;
        private System.Windows.Forms.Label IPv6_Label;
        private System.Windows.Forms.Label IPv6_Text;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label IPv6_GW_Text;
        private IPAddressControlLib.IPAddressControl DNS_2;
        private IPAddressControlLib.IPAddressControl DNS_1;
        private System.Windows.Forms.Label Warning;
        private System.Windows.Forms.Button refreshBTN;
        private System.Windows.Forms.CheckBox activeNICsCB;
        private System.Windows.Forms.ToolStripMenuItem checkForUpdatesToolStripMenuItem;
    }
}

