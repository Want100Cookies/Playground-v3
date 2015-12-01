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
            this.labelValue = new System.Windows.Forms.Label();
            this.labelRecords = new System.Windows.Forms.Label();
            this.labelData = new System.Windows.Forms.Label();
            this.labelKolomnaam = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lstBoxDatabases = new System.Windows.Forms.ListBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lblUitleg = new System.Windows.Forms.Label();
            this.labelColumnname2 = new System.Windows.Forms.Label();
            this.labelData2 = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panelFormulaControls = new System.Windows.Forms.Panel();
            this.labelOperator = new System.Windows.Forms.Label();
            this.labelAmountRecords2 = new System.Windows.Forms.Label();
            this.buttonNewLine = new System.Windows.Forms.Button();
            this.buttonOpenFormula = new System.Windows.Forms.Button();
            this.btnSaveFormula = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.buttonDeleteRow = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabPage2.SuspendLayout();
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
            this.menuStrip1.Size = new System.Drawing.Size(1272, 28);
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
            // labelValue
            // 
            this.labelValue.AutoSize = true;
            this.labelValue.Location = new System.Drawing.Point(560, 0);
            this.labelValue.Name = "labelValue";
            this.labelValue.Size = new System.Drawing.Size(48, 17);
            this.labelValue.TabIndex = 45;
            this.labelValue.Text = "Value:";
            // 
            // labelRecords
            // 
            this.labelRecords.AutoSize = true;
            this.labelRecords.Location = new System.Drawing.Point(379, 0);
            this.labelRecords.Name = "labelRecords";
            this.labelRecords.Size = new System.Drawing.Size(112, 17);
            this.labelRecords.TabIndex = 43;
            this.labelRecords.Text = "Amount records:";
            // 
            // labelData
            // 
            this.labelData.AutoSize = true;
            this.labelData.Location = new System.Drawing.Point(252, 0);
            this.labelData.Name = "labelData";
            this.labelData.Size = new System.Drawing.Size(42, 17);
            this.labelData.TabIndex = 41;
            this.labelData.Text = "Data:";
            // 
            // labelKolomnaam
            // 
            this.labelKolomnaam.AutoSize = true;
            this.labelKolomnaam.Location = new System.Drawing.Point(5, 0);
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
            // labelColumnname2
            // 
            this.labelColumnname2.AutoSize = true;
            this.labelColumnname2.Location = new System.Drawing.Point(670, 0);
            this.labelColumnname2.Name = "labelColumnname2";
            this.labelColumnname2.Size = new System.Drawing.Size(98, 17);
            this.labelColumnname2.TabIndex = 28;
            this.labelColumnname2.Text = "Column name:";
            // 
            // labelData2
            // 
            this.labelData2.AutoSize = true;
            this.labelData2.Location = new System.Drawing.Point(917, 0);
            this.labelData2.Name = "labelData2";
            this.labelData2.Size = new System.Drawing.Size(42, 17);
            this.labelData2.TabIndex = 30;
            this.labelData2.Text = "Data:";
            // 
            // tabPage1
            // 
            this.tabPage1.AutoScroll = true;
            this.tabPage1.Controls.Add(this.buttonDeleteRow);
            this.tabPage1.Controls.Add(this.panelFormulaControls);
            this.tabPage1.Controls.Add(this.buttonNewLine);
            this.tabPage1.Controls.Add(this.buttonOpenFormula);
            this.tabPage1.Controls.Add(this.btnSaveFormula);
            this.tabPage1.Controls.Add(this.lblUitleg);
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
            this.panelFormulaControls.Controls.Add(this.labelValue);
            this.panelFormulaControls.Controls.Add(this.labelOperator);
            this.panelFormulaControls.Controls.Add(this.labelRecords);
            this.panelFormulaControls.Controls.Add(this.labelData);
            this.panelFormulaControls.Controls.Add(this.labelKolomnaam);
            this.panelFormulaControls.Controls.Add(this.labelAmountRecords2);
            this.panelFormulaControls.Controls.Add(this.labelColumnname2);
            this.panelFormulaControls.Controls.Add(this.labelData2);
            this.panelFormulaControls.Location = new System.Drawing.Point(3, 23);
            this.panelFormulaControls.Name = "panelFormulaControls";
            this.panelFormulaControls.Size = new System.Drawing.Size(1265, 176);
            this.panelFormulaControls.TabIndex = 95;
            // 
            // labelOperator
            // 
            this.labelOperator.AutoSize = true;
            this.labelOperator.Location = new System.Drawing.Point(486, 2);
            this.labelOperator.Name = "labelOperator";
            this.labelOperator.Size = new System.Drawing.Size(69, 17);
            this.labelOperator.TabIndex = 43;
            this.labelOperator.Text = "Operator:";
            // 
            // labelAmountRecords2
            // 
            this.labelAmountRecords2.AutoSize = true;
            this.labelAmountRecords2.Location = new System.Drawing.Point(1044, 0);
            this.labelAmountRecords2.Name = "labelAmountRecords2";
            this.labelAmountRecords2.Size = new System.Drawing.Size(112, 17);
            this.labelAmountRecords2.TabIndex = 32;
            this.labelAmountRecords2.Text = "Amount records:";
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
            // buttonDeleteRow
            // 
            this.buttonDeleteRow.Location = new System.Drawing.Point(202, 238);
            this.buttonDeleteRow.Name = "buttonDeleteRow";
            this.buttonDeleteRow.Size = new System.Drawing.Size(175, 27);
            this.buttonDeleteRow.TabIndex = 98;
            this.buttonDeleteRow.Text = "Delete row";
            this.buttonDeleteRow.UseVisualStyleBackColor = true;
            this.buttonDeleteRow.Click += new System.EventHandler(this.buttonDeleteRow_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1272, 439);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Playground (v3)";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
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
        private System.Windows.Forms.Label labelValue;
        private System.Windows.Forms.Label labelRecords;
        private System.Windows.Forms.Label labelData;
        private System.Windows.Forms.Label labelKolomnaam;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ListBox lstBoxDatabases;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label lblUitleg;
        private System.Windows.Forms.Label labelColumnname2;
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
        private System.Windows.Forms.Button buttonDeleteRow;
    }
}

