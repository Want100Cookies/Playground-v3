namespace ODBC_Data_browser
{
    partial class SelectDatabase
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
            this.txtConnectionString = new System.Windows.Forms.TextBox();
            this.lblConnectionString = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtConnectionString
            // 
            this.txtConnectionString.AutoCompleteCustomSource.AddRange(new string[] {
            "Dsn=IP21;trusted_connection=Yes;"});
            this.txtConnectionString.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtConnectionString.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtConnectionString.Location = new System.Drawing.Point(12, 39);
            this.txtConnectionString.Name = "txtConnectionString";
            this.txtConnectionString.Size = new System.Drawing.Size(418, 26);
            this.txtConnectionString.TabIndex = 0;
            // 
            // lblConnectionString
            // 
            this.lblConnectionString.AutoSize = true;
            this.lblConnectionString.Location = new System.Drawing.Point(12, 9);
            this.lblConnectionString.Name = "lblConnectionString";
            this.lblConnectionString.Size = new System.Drawing.Size(133, 20);
            this.lblConnectionString.TabIndex = 1;
            this.lblConnectionString.Text = "Connectionstring:";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(12, 71);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(418, 35);
            this.btnConnect.TabIndex = 2;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // SelectDatabase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 112);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.lblConnectionString);
            this.Controls.Add(this.txtConnectionString);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(464, 168);
            this.MinimumSize = new System.Drawing.Size(464, 168);
            this.Name = "SelectDatabase";
            this.Text = "Select database";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtConnectionString;
        private System.Windows.Forms.Label lblConnectionString;
        private System.Windows.Forms.Button btnConnect;
    }
}

