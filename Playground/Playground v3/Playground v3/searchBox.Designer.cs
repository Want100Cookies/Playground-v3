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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lstBoxDatabases = new System.Windows.Forms.ListBox();
            this.txtBoxSearch = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(294, 274);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(159, 35);
            this.buttonCancel.TabIndex = 18;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonOk
            // 
            this.buttonOk.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.Location = new System.Drawing.Point(12, 273);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(159, 35);
            this.buttonOk.TabIndex = 19;
            this.buttonOk.Text = "Ok";
            this.buttonOk.UseVisualStyleBackColor = true;
            // 
            // checkedListBoxResultaten
            // 
            this.checkedListBoxResultaten.FormattingEnabled = true;
            this.checkedListBoxResultaten.Items.AddRange(new object[] {
            "extruder1temp",
            "extruder2temp",
            "extruder3temp",
            "extruder4temp",
            "voorraad1",
            "voorraad2",
            "voorraad3",
            "voorraad4"});
            this.checkedListBoxResultaten.Location = new System.Drawing.Point(12, 92);
            this.checkedListBoxResultaten.Name = "checkedListBoxResultaten";
            this.checkedListBoxResultaten.Size = new System.Drawing.Size(441, 174);
            this.checkedListBoxResultaten.TabIndex = 17;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(413, 64);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(40, 22);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // lstBoxDatabases
            // 
            this.lstBoxDatabases.FormattingEnabled = true;
            this.lstBoxDatabases.ItemHeight = 16;
            this.lstBoxDatabases.Items.AddRange(new object[] {
            "Aspentec",
            "Wonderware"});
            this.lstBoxDatabases.Location = new System.Drawing.Point(12, 6);
            this.lstBoxDatabases.Name = "lstBoxDatabases";
            this.lstBoxDatabases.Size = new System.Drawing.Size(441, 52);
            this.lstBoxDatabases.TabIndex = 15;
            // 
            // txtBoxSearch
            // 
            this.txtBoxSearch.Location = new System.Drawing.Point(12, 64);
            this.txtBoxSearch.Name = "txtBoxSearch";
            this.txtBoxSearch.Size = new System.Drawing.Size(395, 22);
            this.txtBoxSearch.TabIndex = 14;
            // 
            // searchBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 315);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.checkedListBoxResultaten);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lstBoxDatabases);
            this.Controls.Add(this.txtBoxSearch);
            this.Name = "searchBox";
            this.Text = "searchBox";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOk;
        public System.Windows.Forms.CheckedListBox checkedListBoxResultaten;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ListBox lstBoxDatabases;
        private System.Windows.Forms.TextBox txtBoxSearch;
    }
}