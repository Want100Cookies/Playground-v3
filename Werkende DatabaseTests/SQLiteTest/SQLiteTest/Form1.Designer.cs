namespace SQLiteTest
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
            this.btnOpenSQLite = new System.Windows.Forms.Button();
            this.openSQLiteFile = new System.Windows.Forms.OpenFileDialog();
            this.btnRetrGroups = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnOpenSQLite
            // 
            this.btnOpenSQLite.Location = new System.Drawing.Point(79, 107);
            this.btnOpenSQLite.Name = "btnOpenSQLite";
            this.btnOpenSQLite.Size = new System.Drawing.Size(108, 23);
            this.btnOpenSQLite.TabIndex = 0;
            this.btnOpenSQLite.Text = "Open SQLite DB";
            this.btnOpenSQLite.UseVisualStyleBackColor = true;
            this.btnOpenSQLite.Click += new System.EventHandler(this.btnOpenSQLiteFile_Click);
            // 
            // openSQLiteFile
            // 
            this.openSQLiteFile.FileName = "Playground.db";
            this.openSQLiteFile.Filter = "Database File (Playground.db)|Playground.db";
            this.openSQLiteFile.InitialDirectory = "%USERPROFILE%\\Desktop";
            this.openSQLiteFile.Title = "Opening the database";
            // 
            // btnRetrGroups
            // 
            this.btnRetrGroups.Location = new System.Drawing.Point(79, 137);
            this.btnRetrGroups.Name = "btnRetrGroups";
            this.btnRetrGroups.Size = new System.Drawing.Size(108, 23);
            this.btnRetrGroups.TabIndex = 1;
            this.btnRetrGroups.Text = "Retrieve groups";
            this.btnRetrGroups.UseVisualStyleBackColor = true;
            this.btnRetrGroups.Click += new System.EventHandler(this.btnRetrGroups_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.btnRetrGroups);
            this.Controls.Add(this.btnOpenSQLite);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOpenSQLite;
        private System.Windows.Forms.OpenFileDialog openSQLiteFile;
        private System.Windows.Forms.Button btnRetrGroups;
    }
}

