namespace ODBC_Data_browser
{
    partial class SelectTable
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
            this.lstBoxTables = new System.Windows.Forms.ListBox();
            this.lblSelectTable = new System.Windows.Forms.Label();
            this.btnOpen = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstBoxTables
            // 
            this.lstBoxTables.FormattingEnabled = true;
            this.lstBoxTables.ItemHeight = 20;
            this.lstBoxTables.Location = new System.Drawing.Point(12, 32);
            this.lstBoxTables.Name = "lstBoxTables";
            this.lstBoxTables.Size = new System.Drawing.Size(600, 344);
            this.lstBoxTables.TabIndex = 0;
            // 
            // lblSelectTable
            // 
            this.lblSelectTable.AutoSize = true;
            this.lblSelectTable.Location = new System.Drawing.Point(12, 9);
            this.lblSelectTable.Name = "lblSelectTable";
            this.lblSelectTable.Size = new System.Drawing.Size(149, 20);
            this.lblSelectTable.TabIndex = 2;
            this.lblSelectTable.Text = "Select table to view:";
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(12, 390);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(600, 43);
            this.btnOpen.TabIndex = 3;
            this.btnOpen.Text = "View";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // SelectTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 445);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.lblSelectTable);
            this.Controls.Add(this.lstBoxTables);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(646, 501);
            this.MinimumSize = new System.Drawing.Size(646, 501);
            this.Name = "SelectTable";
            this.Text = "SelectTable";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SelectTable_FormClosed);
            this.Load += new System.EventHandler(this.SelectTable_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstBoxTables;
        private System.Windows.Forms.Label lblSelectTable;
        private System.Windows.Forms.Button btnOpen;
    }
}