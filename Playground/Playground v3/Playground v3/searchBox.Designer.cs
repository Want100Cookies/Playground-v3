namespace Playground_v3
{
    partial class searchBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(searchBox));
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOk = new System.Windows.Forms.Button();
            this.checkedListBoxResultaten = new System.Windows.Forms.CheckedListBox();
            this.pictureBoxSearch = new System.Windows.Forms.PictureBox();
            this.lstBoxDatabases = new System.Windows.Forms.ListBox();
            this.txtBoxSearch = new System.Windows.Forms.TextBox();
            this.lableGuide = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(223, 240);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(119, 38);
            this.buttonCancel.TabIndex = 18;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonOk
            // 
            this.buttonOk.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.Location = new System.Drawing.Point(11, 240);
            this.buttonOk.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(119, 38);
            this.buttonOk.TabIndex = 19;
            this.buttonOk.Text = "Ok";
            this.buttonOk.UseVisualStyleBackColor = true;
            // 
            // checkedListBoxResultaten
            // 
            this.checkedListBoxResultaten.FormattingEnabled = true;
            this.checkedListBoxResultaten.Location = new System.Drawing.Point(11, 93);
            this.checkedListBoxResultaten.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.checkedListBoxResultaten.Name = "checkedListBoxResultaten";
            this.checkedListBoxResultaten.Size = new System.Drawing.Size(332, 139);
            this.checkedListBoxResultaten.TabIndex = 17;
            this.checkedListBoxResultaten.SelectedIndexChanged += new System.EventHandler(this.checkedListBoxResultaten_SelectedIndexChanged);
            // 
            // pictureBoxSearch
            // 
            this.pictureBoxSearch.BackColor = System.Drawing.Color.White;
            this.pictureBoxSearch.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxSearch.Image")));
            this.pictureBoxSearch.Location = new System.Drawing.Point(312, 70);
            this.pictureBoxSearch.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBoxSearch.Name = "pictureBoxSearch";
            this.pictureBoxSearch.Size = new System.Drawing.Size(29, 18);
            this.pictureBoxSearch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxSearch.TabIndex = 16;
            this.pictureBoxSearch.TabStop = false;
            // 
            // lstBoxDatabases
            // 
            this.lstBoxDatabases.FormattingEnabled = true;
            this.lstBoxDatabases.Items.AddRange(new object[] {
            "Aspentec",
            "Wonderware"});
            this.lstBoxDatabases.Location = new System.Drawing.Point(11, 23);
            this.lstBoxDatabases.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lstBoxDatabases.Name = "lstBoxDatabases";
            this.lstBoxDatabases.Size = new System.Drawing.Size(332, 43);
            this.lstBoxDatabases.TabIndex = 15;
            this.lstBoxDatabases.SelectedIndexChanged += new System.EventHandler(this.lstBoxDatabases_SelectedIndexChanged);
            // 
            // txtBoxSearch
            // 
            this.txtBoxSearch.Location = new System.Drawing.Point(11, 70);
            this.txtBoxSearch.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtBoxSearch.Name = "txtBoxSearch";
            this.txtBoxSearch.Size = new System.Drawing.Size(297, 20);
            this.txtBoxSearch.TabIndex = 14;
            this.txtBoxSearch.Text = "Search here";
            this.txtBoxSearch.TextChanged += new System.EventHandler(this.txtBoxSearch_TextChanged);
            this.txtBoxSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBoxSearch_KeyPress);
            // 
            // lableGuide
            // 
            this.lableGuide.AutoSize = true;
            this.lableGuide.Location = new System.Drawing.Point(9, 7);
            this.lableGuide.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lableGuide.Name = "lableGuide";
            this.lableGuide.Size = new System.Drawing.Size(119, 13);
            this.lableGuide.TabIndex = 20;
            this.lableGuide.Text = "First, select a database:";
            // 
            // searchBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 285);
            this.Controls.Add(this.lableGuide);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.checkedListBoxResultaten);
            this.Controls.Add(this.pictureBoxSearch);
            this.Controls.Add(this.lstBoxDatabases);
            this.Controls.Add(this.txtBoxSearch);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "searchBox";
            this.Text = "Search";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSearch)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOk;
        public System.Windows.Forms.CheckedListBox checkedListBoxResultaten;
        private System.Windows.Forms.PictureBox pictureBoxSearch;
        private System.Windows.Forms.ListBox lstBoxDatabases;
        private System.Windows.Forms.TextBox txtBoxSearch;
        private System.Windows.Forms.Label lableGuide;
    }
}