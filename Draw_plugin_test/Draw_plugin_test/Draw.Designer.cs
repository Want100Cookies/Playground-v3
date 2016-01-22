namespace Draw_plugin_test
{
    partial class Draw
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
            this.btnVierkant = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnRechthoek = new System.Windows.Forms.Button();
            this.btnDriehoek = new System.Windows.Forms.Button();
            this.btnCirkel = new System.Windows.Forms.Button();
            this.btnOvaal = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnVierkant
            // 
            this.btnVierkant.Location = new System.Drawing.Point(12, 12);
            this.btnVierkant.Name = "btnVierkant";
            this.btnVierkant.Size = new System.Drawing.Size(75, 23);
            this.btnVierkant.TabIndex = 0;
            this.btnVierkant.Text = "Vierkant";
            this.btnVierkant.UseVisualStyleBackColor = true;
            this.btnVierkant.Click += new System.EventHandler(this.btnVierkant_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(194, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(614, 390);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // btnRechthoek
            // 
            this.btnRechthoek.Location = new System.Drawing.Point(12, 41);
            this.btnRechthoek.Name = "btnRechthoek";
            this.btnRechthoek.Size = new System.Drawing.Size(75, 23);
            this.btnRechthoek.TabIndex = 2;
            this.btnRechthoek.Text = "Rechthoek";
            this.btnRechthoek.UseVisualStyleBackColor = true;
            this.btnRechthoek.Click += new System.EventHandler(this.btnRechthoek_Click);
            // 
            // btnDriehoek
            // 
            this.btnDriehoek.Location = new System.Drawing.Point(12, 70);
            this.btnDriehoek.Name = "btnDriehoek";
            this.btnDriehoek.Size = new System.Drawing.Size(75, 23);
            this.btnDriehoek.TabIndex = 3;
            this.btnDriehoek.Text = "Driehoek";
            this.btnDriehoek.UseVisualStyleBackColor = true;
            this.btnDriehoek.Click += new System.EventHandler(this.btnDriehoek_Click);
            // 
            // btnCirkel
            // 
            this.btnCirkel.Location = new System.Drawing.Point(93, 12);
            this.btnCirkel.Name = "btnCirkel";
            this.btnCirkel.Size = new System.Drawing.Size(75, 23);
            this.btnCirkel.TabIndex = 4;
            this.btnCirkel.Text = "Cirkel";
            this.btnCirkel.UseVisualStyleBackColor = true;
            this.btnCirkel.Click += new System.EventHandler(this.btnCirkel_Click);
            // 
            // btnOvaal
            // 
            this.btnOvaal.Location = new System.Drawing.Point(93, 41);
            this.btnOvaal.Name = "btnOvaal";
            this.btnOvaal.Size = new System.Drawing.Size(75, 23);
            this.btnOvaal.TabIndex = 5;
            this.btnOvaal.Text = "Ovaal";
            this.btnOvaal.UseVisualStyleBackColor = true;
            this.btnOvaal.Click += new System.EventHandler(this.btnOvaal_Click);
            // 
            // Draw
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(896, 414);
            this.Controls.Add(this.btnOvaal);
            this.Controls.Add(this.btnCirkel);
            this.Controls.Add(this.btnDriehoek);
            this.Controls.Add(this.btnRechthoek);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.btnVierkant);
            this.Name = "Draw";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnVierkant;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnRechthoek;
        private System.Windows.Forms.Button btnDriehoek;
        private System.Windows.Forms.Button btnCirkel;
        private System.Windows.Forms.Button btnOvaal;
    }
}

