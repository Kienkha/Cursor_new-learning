namespace AddInManager
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnEnDis = new System.Windows.Forms.Button();
            this.btnAll = new System.Windows.Forms.Button();
            this.btnInvert = new System.Windows.Forms.Button();
            this.btnSelEnabled = new System.Windows.Forms.Button();
            this.btnSelDis = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cboVersion = new System.Windows.Forms.ComboBox();
            this.btnAbout = new System.Windows.Forms.Button();
            this.AddinName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserSpecific = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsEnabled = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Version = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AddinPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AddinName,
            this.UserSpecific,
            this.IsEnabled,
            this.Version,
            this.AddinPath});
            this.dataGridView1.Location = new System.Drawing.Point(12, 39);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(915, 192);
            this.dataGridView1.TabIndex = 0;
            // 
            // btnEnDis
            // 
            this.btnEnDis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEnDis.Location = new System.Drawing.Point(810, 237);
            this.btnEnDis.Name = "btnEnDis";
            this.btnEnDis.Size = new System.Drawing.Size(117, 23);
            this.btnEnDis.TabIndex = 1;
            this.btnEnDis.Text = "&Enable / Disable";
            this.btnEnDis.UseVisualStyleBackColor = true;
            this.btnEnDis.Click += new System.EventHandler(this.btnEnDis_Click);
            // 
            // btnAll
            // 
            this.btnAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAll.Location = new System.Drawing.Point(12, 237);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(75, 23);
            this.btnAll.TabIndex = 2;
            this.btnAll.Text = "Select &All";
            this.btnAll.UseVisualStyleBackColor = true;
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // btnInvert
            // 
            this.btnInvert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnInvert.Location = new System.Drawing.Point(93, 237);
            this.btnInvert.Name = "btnInvert";
            this.btnInvert.Size = new System.Drawing.Size(75, 23);
            this.btnInvert.TabIndex = 3;
            this.btnInvert.Text = "&Invert";
            this.btnInvert.UseVisualStyleBackColor = true;
            this.btnInvert.Click += new System.EventHandler(this.btnInvert_Click);
            // 
            // btnSelEnabled
            // 
            this.btnSelEnabled.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSelEnabled.Location = new System.Drawing.Point(333, 237);
            this.btnSelEnabled.Name = "btnSelEnabled";
            this.btnSelEnabled.Size = new System.Drawing.Size(106, 23);
            this.btnSelEnabled.TabIndex = 4;
            this.btnSelEnabled.Text = "&Select Enabled";
            this.btnSelEnabled.UseVisualStyleBackColor = true;
            this.btnSelEnabled.Click += new System.EventHandler(this.btnSelEnabled_Click);
            // 
            // btnSelDis
            // 
            this.btnSelDis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSelDis.Location = new System.Drawing.Point(445, 237);
            this.btnSelDis.Name = "btnSelDis";
            this.btnSelDis.Size = new System.Drawing.Size(106, 23);
            this.btnSelDis.TabIndex = 5;
            this.btnSelDis.Text = "Select &Disabled";
            this.btnSelDis.UseVisualStyleBackColor = true;
            this.btnSelDis.Click += new System.EventHandler(this.btnSelDis_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Choose Version:";
            // 
            // cboVersion
            // 
            this.cboVersion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboVersion.FormattingEnabled = true;
            this.cboVersion.Location = new System.Drawing.Point(102, 6);
            this.cboVersion.Name = "cboVersion";
            this.cboVersion.Size = new System.Drawing.Size(121, 21);
            this.cboVersion.TabIndex = 7;
            this.cboVersion.SelectedIndexChanged += new System.EventHandler(this.cboVersion_SelectedIndexChanged);
            // 
            // btnAbout
            // 
            this.btnAbout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAbout.Location = new System.Drawing.Point(875, 9);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(52, 23);
            this.btnAbout.TabIndex = 8;
            this.btnAbout.Text = "About";
            this.btnAbout.UseVisualStyleBackColor = true;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // AddinName
            // 
            this.AddinName.FillWeight = 50F;
            this.AddinName.HeaderText = "Name";
            this.AddinName.Name = "AddinName";
            this.AddinName.ReadOnly = true;
            // 
            // UserSpecific
            // 
            this.UserSpecific.FillWeight = 25F;
            this.UserSpecific.HeaderText = "User Specific";
            this.UserSpecific.Name = "UserSpecific";
            this.UserSpecific.ReadOnly = true;
            // 
            // IsEnabled
            // 
            this.IsEnabled.FillWeight = 25F;
            this.IsEnabled.HeaderText = "Enabled";
            this.IsEnabled.Name = "IsEnabled";
            this.IsEnabled.ReadOnly = true;
            // 
            // Version
            // 
            this.Version.FillWeight = 25F;
            this.Version.HeaderText = "Version";
            this.Version.Name = "Version";
            this.Version.ReadOnly = true;
            // 
            // AddinPath
            // 
            this.AddinPath.HeaderText = ".ADDIN Path";
            this.AddinPath.Name = "AddinPath";
            this.AddinPath.ReadOnly = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(939, 272);
            this.Controls.Add(this.btnAbout);
            this.Controls.Add(this.cboVersion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSelDis);
            this.Controls.Add(this.btnSelEnabled);
            this.Controls.Add(this.btnInvert);
            this.Controls.Add(this.btnAll);
            this.Controls.Add(this.btnEnDis);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Stantec Addin Manager";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnEnDis;
        private System.Windows.Forms.Button btnAll;
        private System.Windows.Forms.Button btnInvert;
        private System.Windows.Forms.Button btnSelEnabled;
        private System.Windows.Forms.Button btnSelDis;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboVersion;
        private System.Windows.Forms.Button btnAbout;
        private System.Windows.Forms.DataGridViewTextBoxColumn AddinName;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserSpecific;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsEnabled;
        private System.Windows.Forms.DataGridViewTextBoxColumn Version;
        private System.Windows.Forms.DataGridViewTextBoxColumn AddinPath;
    }
}

