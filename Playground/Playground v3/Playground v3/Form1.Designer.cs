namespace Playground_v3
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.databaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.txtBoxSearch = new System.Windows.Forms.TextBox();
            this.radioButtonValue = new System.Windows.Forms.RadioButton();
            this.radioButtonAbsolute = new System.Windows.Forms.RadioButton();
            this.pictureBoxSearch = new System.Windows.Forms.PictureBox();
            this.labelValue = new System.Windows.Forms.Label();
            this.textBoxValue = new System.Windows.Forms.TextBox();
            this.labelRecords = new System.Windows.Forms.Label();
            this.numericUpDownRecords = new System.Windows.Forms.NumericUpDown();
            this.comboBoxOperator1 = new System.Windows.Forms.ComboBox();
            this.labelData = new System.Windows.Forms.Label();
            this.comboBoxOperator2 = new System.Windows.Forms.ComboBox();
            this.labelKolomnaam = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lstBoxDatabases = new System.Windows.Forms.ListBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.textBoxColumnname = new System.Windows.Forms.TextBox();
            this.lblUitleg = new System.Windows.Forms.Label();
            this.pictureBoxSearch2 = new System.Windows.Forms.PictureBox();
            this.textBoxColumnname2 = new System.Windows.Forms.TextBox();
            this.labelColumnname2 = new System.Windows.Forms.Label();
            this.numericUpDownRecords2 = new System.Windows.Forms.NumericUpDown();
            this.comboBoxOperator3 = new System.Windows.Forms.ComboBox();
            this.labelData2 = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panelFormulaControls = new System.Windows.Forms.Panel();
            this.buttonNewLine = new System.Windows.Forms.Button();
            this.buttonOpenFormula = new System.Windows.Forms.Button();
            this.btnSaveFormula = new System.Windows.Forms.Button();
            this.labelOperator = new System.Windows.Forms.Label();
            this.labelAmountRecords2 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRecords)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSearch2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRecords2)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.panelFormulaControls.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1182, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.databaseToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(74, 24);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // databaseToolStripMenuItem
            // 
            this.databaseToolStripMenuItem.Name = "databaseToolStripMenuItem";
            this.databaseToolStripMenuItem.Size = new System.Drawing.Size(147, 26);
            this.databaseToolStripMenuItem.Text = "Database";
            this.databaseToolStripMenuItem.Click += new System.EventHandler(this.databaseToolStripMenuItem_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(1495, 445);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Administration";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // txtBoxSearch
            // 
            this.txtBoxSearch.Location = new System.Drawing.Point(6, 64);
            this.txtBoxSearch.Name = "txtBoxSearch";
            this.txtBoxSearch.Size = new System.Drawing.Size(154, 22);
            this.txtBoxSearch.TabIndex = 6;
            // 
            // radioButtonValue
            // 
            this.radioButtonValue.AutoSize = true;
            this.radioButtonValue.Location = new System.Drawing.Point(703, 20);
            this.radioButtonValue.Name = "radioButtonValue";
            this.radioButtonValue.Size = new System.Drawing.Size(114, 21);
            this.radioButtonValue.TabIndex = 48;
            this.radioButtonValue.Text = "Current value";
            this.radioButtonValue.UseVisualStyleBackColor = true;
            this.radioButtonValue.CheckedChanged += new System.EventHandler(this.radioButtonValue_CheckedChanged);
            // 
            // radioButtonAbsolute
            // 
            this.radioButtonAbsolute.AutoSize = true;
            this.radioButtonAbsolute.Checked = true;
            this.radioButtonAbsolute.Location = new System.Drawing.Point(564, 20);
            this.radioButtonAbsolute.Name = "radioButtonAbsolute";
            this.radioButtonAbsolute.Size = new System.Drawing.Size(122, 21);
            this.radioButtonAbsolute.TabIndex = 47;
            this.radioButtonAbsolute.TabStop = true;
            this.radioButtonAbsolute.Text = "Absolute value";
            this.radioButtonAbsolute.UseVisualStyleBackColor = true;
            // 
            // pictureBoxSearch
            // 
            this.pictureBoxSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxSearch.Image = global::Playground_v3.Properties.Resources._1426093958_common_search_lookup__128;
            this.pictureBoxSearch.Location = new System.Drawing.Point(194, 3);
            this.pictureBoxSearch.Name = "pictureBoxSearch";
            this.pictureBoxSearch.Size = new System.Drawing.Size(50, 22);
            this.pictureBoxSearch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxSearch.TabIndex = 46;
            this.pictureBoxSearch.TabStop = false;
            this.pictureBoxSearch.Click += new System.EventHandler(this.pictureBoxSearch_Click);
            // 
            // labelValue
            // 
            this.labelValue.AutoSize = true;
            this.labelValue.Location = new System.Drawing.Point(561, 44);
            this.labelValue.Name = "labelValue";
            this.labelValue.Size = new System.Drawing.Size(48, 17);
            this.labelValue.TabIndex = 45;
            this.labelValue.Text = "Value:";
            // 
            // textBoxValue
            // 
            this.textBoxValue.Location = new System.Drawing.Point(558, 2);
            this.textBoxValue.Name = "textBoxValue";
            this.textBoxValue.Size = new System.Drawing.Size(100, 22);
            this.textBoxValue.TabIndex = 44;
            // 
            // labelRecords
            // 
            this.labelRecords.AutoSize = true;
            this.labelRecords.Location = new System.Drawing.Point(380, 44);
            this.labelRecords.Name = "labelRecords";
            this.labelRecords.Size = new System.Drawing.Size(112, 17);
            this.labelRecords.TabIndex = 43;
            this.labelRecords.Text = "Amount records:";
            // 
            // numericUpDownRecords
            // 
            this.numericUpDownRecords.AccessibleDescription = "Standaard op disabled, wordt pas enabled als comboBoxOperator1 als waarde gemidde" +
    "lde heeft.";
            this.numericUpDownRecords.Enabled = false;
            this.numericUpDownRecords.Location = new System.Drawing.Point(377, 3);
            this.numericUpDownRecords.Maximum = new decimal(new int[] {
            250,
            0,
            0,
            0});
            this.numericUpDownRecords.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDownRecords.Name = "numericUpDownRecords";
            this.numericUpDownRecords.Size = new System.Drawing.Size(101, 22);
            this.numericUpDownRecords.TabIndex = 40;
            this.numericUpDownRecords.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // comboBoxOperator1
            // 
            this.comboBoxOperator1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxOperator1.FormattingEnabled = true;
            this.comboBoxOperator1.Items.AddRange(new object[] {
            "Most recent",
            "Average"});
            this.comboBoxOperator1.Location = new System.Drawing.Point(250, 3);
            this.comboBoxOperator1.Name = "comboBoxOperator1";
            this.comboBoxOperator1.Size = new System.Drawing.Size(121, 24);
            this.comboBoxOperator1.TabIndex = 38;
            this.comboBoxOperator1.SelectedIndexChanged += new System.EventHandler(this.comboBoxOperator1_SelectedIndexChanged);
            // 
            // labelData
            // 
            this.labelData.AutoSize = true;
            this.labelData.Location = new System.Drawing.Point(253, 44);
            this.labelData.Name = "labelData";
            this.labelData.Size = new System.Drawing.Size(42, 17);
            this.labelData.TabIndex = 41;
            this.labelData.Text = "Data:";
            // 
            // comboBoxOperator2
            // 
            this.comboBoxOperator2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxOperator2.FormattingEnabled = true;
            this.comboBoxOperator2.Items.AddRange(new object[] {
            ">",
            "<",
            "=",
            ">=",
            "<=",
            "≠"});
            this.comboBoxOperator2.Location = new System.Drawing.Point(484, 3);
            this.comboBoxOperator2.Name = "comboBoxOperator2";
            this.comboBoxOperator2.Size = new System.Drawing.Size(68, 24);
            this.comboBoxOperator2.TabIndex = 42;
            // 
            // labelKolomnaam
            // 
            this.labelKolomnaam.AutoSize = true;
            this.labelKolomnaam.Location = new System.Drawing.Point(6, 44);
            this.labelKolomnaam.Name = "labelKolomnaam";
            this.labelKolomnaam.Size = new System.Drawing.Size(98, 17);
            this.labelKolomnaam.TabIndex = 39;
            this.labelKolomnaam.Text = "Column name:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(166, 64);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(40, 22);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // lstBoxDatabases
            // 
            this.lstBoxDatabases.FormattingEnabled = true;
            this.lstBoxDatabases.ItemHeight = 16;
            this.lstBoxDatabases.Location = new System.Drawing.Point(6, 6);
            this.lstBoxDatabases.Name = "lstBoxDatabases";
            this.lstBoxDatabases.Size = new System.Drawing.Size(200, 52);
            this.lstBoxDatabases.TabIndex = 7;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.pictureBox1);
            this.tabPage2.Controls.Add(this.lstBoxDatabases);
            this.tabPage2.Controls.Add(this.txtBoxSearch);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1495, 445);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Create pictures";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // textBoxColumnname
            // 
            this.textBoxColumnname.AccessibleDescription = "";
            this.textBoxColumnname.Location = new System.Drawing.Point(3, 3);
            this.textBoxColumnname.Name = "textBoxColumnname";
            this.textBoxColumnname.Size = new System.Drawing.Size(187, 22);
            this.textBoxColumnname.TabIndex = 37;
            // 
            // lblUitleg
            // 
            this.lblUitleg.AccessibleDescription = "Note: het idee is om een begeleiding hierin te maken";
            this.lblUitleg.AutoSize = true;
            this.lblUitleg.Location = new System.Drawing.Point(6, 3);
            this.lblUitleg.Name = "lblUitleg";
            this.lblUitleg.Size = new System.Drawing.Size(308, 17);
            this.lblUitleg.TabIndex = 36;
            this.lblUitleg.Text = "First, fill in an columnname, or search a column.";
            // 
            // pictureBoxSearch2
            // 
            this.pictureBoxSearch2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxSearch2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxSearch2.Image")));
            this.pictureBoxSearch2.Location = new System.Drawing.Point(859, 3);
            this.pictureBoxSearch2.Name = "pictureBoxSearch2";
            this.pictureBoxSearch2.Size = new System.Drawing.Size(50, 22);
            this.pictureBoxSearch2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxSearch2.TabIndex = 35;
            this.pictureBoxSearch2.TabStop = false;
            this.pictureBoxSearch2.Click += new System.EventHandler(this.pictureBoxSearch_Click);
            // 
            // textBoxColumnname2
            // 
            this.textBoxColumnname2.AccessibleDescription = "";
            this.textBoxColumnname2.Location = new System.Drawing.Point(668, 3);
            this.textBoxColumnname2.Name = "textBoxColumnname2";
            this.textBoxColumnname2.Size = new System.Drawing.Size(187, 22);
            this.textBoxColumnname2.TabIndex = 26;
            // 
            // labelColumnname2
            // 
            this.labelColumnname2.AutoSize = true;
            this.labelColumnname2.Location = new System.Drawing.Point(671, 44);
            this.labelColumnname2.Name = "labelColumnname2";
            this.labelColumnname2.Size = new System.Drawing.Size(98, 17);
            this.labelColumnname2.TabIndex = 28;
            this.labelColumnname2.Text = "Column name:";
            // 
            // numericUpDownRecords2
            // 
            this.numericUpDownRecords2.AccessibleDescription = "Standaard op disabled, wordt pas enabled als comboBoxOperator1 als waarde gemidde" +
    "lde heeft.";
            this.numericUpDownRecords2.Enabled = false;
            this.numericUpDownRecords2.Location = new System.Drawing.Point(1042, 3);
            this.numericUpDownRecords2.Maximum = new decimal(new int[] {
            250,
            0,
            0,
            0});
            this.numericUpDownRecords2.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDownRecords2.Name = "numericUpDownRecords2";
            this.numericUpDownRecords2.Size = new System.Drawing.Size(101, 22);
            this.numericUpDownRecords2.TabIndex = 29;
            this.numericUpDownRecords2.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // comboBoxOperator3
            // 
            this.comboBoxOperator3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxOperator3.FormattingEnabled = true;
            this.comboBoxOperator3.Items.AddRange(new object[] {
            "Meest recente",
            "Gemiddelde"});
            this.comboBoxOperator3.Location = new System.Drawing.Point(915, 3);
            this.comboBoxOperator3.Name = "comboBoxOperator3";
            this.comboBoxOperator3.Size = new System.Drawing.Size(121, 24);
            this.comboBoxOperator3.TabIndex = 27;
            this.comboBoxOperator3.SelectedIndexChanged += new System.EventHandler(this.comboBoxOperator3_SelectedIndexChanged);
            // 
            // labelData2
            // 
            this.labelData2.AutoSize = true;
            this.labelData2.Location = new System.Drawing.Point(918, 44);
            this.labelData2.Name = "labelData2";
            this.labelData2.Size = new System.Drawing.Size(42, 17);
            this.labelData2.TabIndex = 30;
            this.labelData2.Text = "Data:";
            // 
            // tabPage1
            // 
            this.tabPage1.AutoScroll = true;
            this.tabPage1.Controls.Add(this.panelFormulaControls);
            this.tabPage1.Controls.Add(this.buttonNewLine);
            this.tabPage1.Controls.Add(this.buttonOpenFormula);
            this.tabPage1.Controls.Add(this.btnSaveFormula);
            this.tabPage1.Controls.Add(this.radioButtonValue);
            this.tabPage1.Controls.Add(this.radioButtonAbsolute);
            this.tabPage1.Controls.Add(this.labelValue);
            this.tabPage1.Controls.Add(this.labelOperator);
            this.tabPage1.Controls.Add(this.labelRecords);
            this.tabPage1.Controls.Add(this.labelData);
            this.tabPage1.Controls.Add(this.labelKolomnaam);
            this.tabPage1.Controls.Add(this.lblUitleg);
            this.tabPage1.Controls.Add(this.labelAmountRecords2);
            this.tabPage1.Controls.Add(this.labelColumnname2);
            this.tabPage1.Controls.Add(this.labelData2);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1495, 445);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Create formulas";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panelFormulaControls
            // 
            this.panelFormulaControls.AutoScroll = true;
            this.panelFormulaControls.Controls.Add(this.textBoxColumnname);
            this.panelFormulaControls.Controls.Add(this.comboBoxOperator3);
            this.panelFormulaControls.Controls.Add(this.numericUpDownRecords2);
            this.panelFormulaControls.Controls.Add(this.textBoxColumnname2);
            this.panelFormulaControls.Controls.Add(this.pictureBoxSearch2);
            this.panelFormulaControls.Controls.Add(this.comboBoxOperator2);
            this.panelFormulaControls.Controls.Add(this.pictureBoxSearch);
            this.panelFormulaControls.Controls.Add(this.comboBoxOperator1);
            this.panelFormulaControls.Controls.Add(this.numericUpDownRecords);
            this.panelFormulaControls.Controls.Add(this.textBoxValue);
            this.panelFormulaControls.Location = new System.Drawing.Point(3, 66);
            this.panelFormulaControls.Name = "panelFormulaControls";
            this.panelFormulaControls.Size = new System.Drawing.Size(1175, 133);
            this.panelFormulaControls.TabIndex = 95;
            // 
            // buttonNewLine
            // 
            this.buttonNewLine.Location = new System.Drawing.Point(202, 205);
            this.buttonNewLine.Name = "buttonNewLine";
            this.buttonNewLine.Size = new System.Drawing.Size(175, 27);
            this.buttonNewLine.TabIndex = 97;
            this.buttonNewLine.Text = "New Line";
            this.buttonNewLine.UseVisualStyleBackColor = true;
            this.buttonNewLine.Click += new System.EventHandler(this.buttonNewLine_Click);
            // 
            // buttonOpenFormula
            // 
            this.buttonOpenFormula.Location = new System.Drawing.Point(9, 238);
            this.buttonOpenFormula.Name = "buttonOpenFormula";
            this.buttonOpenFormula.Size = new System.Drawing.Size(187, 27);
            this.buttonOpenFormula.TabIndex = 96;
            this.buttonOpenFormula.Text = "Open formula";
            this.buttonOpenFormula.UseVisualStyleBackColor = true;
            this.buttonOpenFormula.Click += new System.EventHandler(this.buttonOpenFormula_Click);
            // 
            // btnSaveFormula
            // 
            this.btnSaveFormula.Location = new System.Drawing.Point(9, 205);
            this.btnSaveFormula.Name = "btnSaveFormula";
            this.btnSaveFormula.Size = new System.Drawing.Size(187, 27);
            this.btnSaveFormula.TabIndex = 95;
            this.btnSaveFormula.Text = "Save formula";
            this.btnSaveFormula.UseVisualStyleBackColor = true;
            this.btnSaveFormula.Click += new System.EventHandler(this.btnSaveFormula_Click);
            // 
            // labelOperator
            // 
            this.labelOperator.AutoSize = true;
            this.labelOperator.Location = new System.Drawing.Point(487, 46);
            this.labelOperator.Name = "labelOperator";
            this.labelOperator.Size = new System.Drawing.Size(69, 17);
            this.labelOperator.TabIndex = 43;
            this.labelOperator.Text = "Operator:";
            // 
            // labelAmountRecords2
            // 
            this.labelAmountRecords2.AutoSize = true;
            this.labelAmountRecords2.Location = new System.Drawing.Point(1045, 44);
            this.labelAmountRecords2.Name = "labelAmountRecords2";
            this.labelAmountRecords2.Size = new System.Drawing.Size(112, 17);
            this.labelAmountRecords2.TabIndex = 32;
            this.labelAmountRecords2.Text = "Amount records:";
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1495, 445);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Display pictures";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(0, 31);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1503, 474);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.tabControl1.TabIndex = 94;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 439);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Playground (v3)";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRecords)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSearch2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRecords2)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.panelFormulaControls.ResumeLayout(false);
            this.panelFormulaControls.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem databaseToolStripMenuItem;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TextBox txtBoxSearch;
        private System.Windows.Forms.RadioButton radioButtonValue;
        private System.Windows.Forms.RadioButton radioButtonAbsolute;
        private System.Windows.Forms.PictureBox pictureBoxSearch;
        private System.Windows.Forms.Label labelValue;
        private System.Windows.Forms.TextBox textBoxValue;
        private System.Windows.Forms.Label labelRecords;
        private System.Windows.Forms.NumericUpDown numericUpDownRecords;
        private System.Windows.Forms.ComboBox comboBoxOperator1;
        private System.Windows.Forms.Label labelData;
        private System.Windows.Forms.ComboBox comboBoxOperator2;
        private System.Windows.Forms.Label labelKolomnaam;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ListBox lstBoxDatabases;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox textBoxColumnname;
        private System.Windows.Forms.Label lblUitleg;
        private System.Windows.Forms.PictureBox pictureBoxSearch2;
        private System.Windows.Forms.TextBox textBoxColumnname2;
        private System.Windows.Forms.Label labelColumnname2;
        private System.Windows.Forms.NumericUpDown numericUpDownRecords2;
        private System.Windows.Forms.ComboBox comboBoxOperator3;
        private System.Windows.Forms.Label labelData2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label labelAmountRecords2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Label labelOperator;
        private System.Windows.Forms.Button btnSaveFormula;
        private System.Windows.Forms.Button buttonOpenFormula;
        private System.Windows.Forms.Button buttonNewLine;
        private System.Windows.Forms.Panel panelFormulaControls;
    }
}

