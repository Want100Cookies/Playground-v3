namespace Draw_plugin_test
{
    partial class Movement
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
            this.btnRechthoek = new System.Windows.Forms.Button();
            this.btnDriehoek = new System.Windows.Forms.Button();
            this.btnCirkel = new System.Windows.Forms.Button();
            this.btnOvaal = new System.Windows.Forms.Button();
            this.shapeContainer = new System.Windows.Forms.Panel();
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
            // btnRechthoek
            // 
            this.btnRechthoek.Location = new System.Drawing.Point(12, 41);
            this.btnRechthoek.Name = "btnRechthoek";
            this.btnRechthoek.Size = new System.Drawing.Size(75, 23);
            this.btnRechthoek.TabIndex = 2;
            this.btnRechthoek.Text = "Rechthoek";
            this.btnRechthoek.UseVisualStyleBackColor = true;
            // 
            // btnDriehoek
            // 
            this.btnDriehoek.Location = new System.Drawing.Point(12, 70);
            this.btnDriehoek.Name = "btnDriehoek";
            this.btnDriehoek.Size = new System.Drawing.Size(75, 23);
            this.btnDriehoek.TabIndex = 3;
            this.btnDriehoek.Text = "Driehoek";
            this.btnDriehoek.UseVisualStyleBackColor = true;
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
            // 
            // shapeContainer
            // 
            this.shapeContainer.Location = new System.Drawing.Point(205, 12);
            this.shapeContainer.Name = "shapeContainer";
            this.shapeContainer.Size = new System.Drawing.Size(679, 301);
            this.shapeContainer.TabIndex = 6;

            // 
            // Movement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(896, 414);
            this.Controls.Add(this.shapeContainer);
            this.Controls.Add(this.btnOvaal);
            this.Controls.Add(this.btnCirkel);
            this.Controls.Add(this.btnDriehoek);
            this.Controls.Add(this.btnRechthoek);
            this.Controls.Add(this.btnVierkant);
            this.Name = "Movement";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnVierkant;
        private System.Windows.Forms.Button btnRechthoek;
        private System.Windows.Forms.Button btnDriehoek;
        private System.Windows.Forms.Button btnCirkel;
        private System.Windows.Forms.Button btnOvaal;
        private System.Windows.Forms.Panel shapeContainer;
    }
}

