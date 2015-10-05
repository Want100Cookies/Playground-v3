namespace DBTest3
{
    partial class form1
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
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.oDBC_TestDataSet = new DBTest3.ODBC_TestDataSet();
            this.oDBCTestDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.nawBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.nawTableAdapter = new DBTest3.ODBC_TestDataSetTableAdapters.nawTableAdapter();
            this.tableAdapterManager = new DBTest3.ODBC_TestDataSetTableAdapters.TableAdapterManager();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.nawTableAdapter1 = new DBTest3.ODBC_TestDataSetTableAdapters.nawTableAdapter();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.oDBC_TestDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.oDBCTestDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nawBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(51, 21);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(113, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Data ophalen";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // oDBC_TestDataSet
            // 
            this.oDBC_TestDataSet.DataSetName = "ODBC_TestDataSet";
            this.oDBC_TestDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // oDBCTestDataSetBindingSource
            // 
            this.oDBCTestDataSetBindingSource.DataSource = this.oDBC_TestDataSet;
            this.oDBCTestDataSetBindingSource.Position = 0;
            // 
            // nawBindingSource
            // 
            this.nawBindingSource.DataMember = "naw";
            this.nawBindingSource.DataSource = this.oDBC_TestDataSet;
            // 
            // nawTableAdapter
            // 
            this.nawTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.nawTableAdapter = this.nawTableAdapter;
            this.tableAdapterManager.trace_xe_action_mapTableAdapter = null;
            this.tableAdapterManager.trace_xe_event_mapTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = DBTest3.ODBC_TestDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 50);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(1338, 215);
            this.dataGridView1.TabIndex = 1;
            // 
            // nawTableAdapter1
            // 
            this.nawTableAdapter1.ClearBeforeFill = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(230, 21);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(103, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Change config";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1362, 360);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.Name = "form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.oDBC_TestDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.oDBCTestDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nawBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.BindingSource oDBCTestDataSetBindingSource;
        private ODBC_TestDataSet oDBC_TestDataSet;
        private System.Windows.Forms.BindingSource nawBindingSource;
        private ODBC_TestDataSetTableAdapters.nawTableAdapter nawTableAdapter;
        private ODBC_TestDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.DataGridView dataGridView1;
        private ODBC_TestDataSetTableAdapters.nawTableAdapter nawTableAdapter1;
        private System.Windows.Forms.Button button2;
    }
}

