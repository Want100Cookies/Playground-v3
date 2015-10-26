namespace Playground_v3
{
    partial class UserManagement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserManagement));
            this.lstBoxUsers = new System.Windows.Forms.ListBox();
            this.lstBoxGroups = new System.Windows.Forms.ListBox();
            this.lstBoxUserGroup = new System.Windows.Forms.ListBox();
            this.btnLeaveGroup = new System.Windows.Forms.Button();
            this.btnJoinGroup = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCreateGroup = new System.Windows.Forms.Button();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstBoxUsers
            // 
            this.lstBoxUsers.DisplayMember = "Value";
            this.lstBoxUsers.FormattingEnabled = true;
            this.lstBoxUsers.ItemHeight = 20;
            this.lstBoxUsers.Location = new System.Drawing.Point(12, 32);
            this.lstBoxUsers.Name = "lstBoxUsers";
            this.lstBoxUsers.Size = new System.Drawing.Size(194, 404);
            this.lstBoxUsers.TabIndex = 0;
            this.lstBoxUsers.ValueMember = "Key";
            // 
            // lstBoxGroups
            // 
            this.lstBoxGroups.FormattingEnabled = true;
            this.lstBoxGroups.ItemHeight = 20;
            this.lstBoxGroups.Location = new System.Drawing.Point(493, 32);
            this.lstBoxGroups.Name = "lstBoxGroups";
            this.lstBoxGroups.Size = new System.Drawing.Size(194, 404);
            this.lstBoxGroups.TabIndex = 1;
            this.lstBoxGroups.SelectedValueChanged += new System.EventHandler(this.lstBoxGroups_SelectedValueChanged);
            // 
            // lstBoxUserGroup
            // 
            this.lstBoxUserGroup.DisplayMember = "Value";
            this.lstBoxUserGroup.FormattingEnabled = true;
            this.lstBoxUserGroup.ItemHeight = 20;
            this.lstBoxUserGroup.Location = new System.Drawing.Point(293, 32);
            this.lstBoxUserGroup.Name = "lstBoxUserGroup";
            this.lstBoxUserGroup.Size = new System.Drawing.Size(194, 404);
            this.lstBoxUserGroup.TabIndex = 2;
            this.lstBoxUserGroup.ValueMember = "Key";
            // 
            // btnLeaveGroup
            // 
            this.btnLeaveGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLeaveGroup.Location = new System.Drawing.Point(212, 189);
            this.btnLeaveGroup.Name = "btnLeaveGroup";
            this.btnLeaveGroup.Size = new System.Drawing.Size(75, 151);
            this.btnLeaveGroup.TabIndex = 3;
            this.btnLeaveGroup.Text = "←";
            this.btnLeaveGroup.UseVisualStyleBackColor = true;
            this.btnLeaveGroup.Click += new System.EventHandler(this.btnLeaveGroup_Click);
            // 
            // btnJoinGroup
            // 
            this.btnJoinGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJoinGroup.Location = new System.Drawing.Point(212, 32);
            this.btnJoinGroup.Name = "btnJoinGroup";
            this.btnJoinGroup.Size = new System.Drawing.Size(75, 151);
            this.btnJoinGroup.TabIndex = 4;
            this.btnJoinGroup.Text = "→";
            this.btnJoinGroup.UseVisualStyleBackColor = true;
            this.btnJoinGroup.Click += new System.EventHandler(this.btnJoinGroup_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Users:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(298, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Users in group x:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(498, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Groups:";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(212, 346);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 90);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCreateGroup
            // 
            this.btnCreateGroup.Location = new System.Drawing.Point(493, 442);
            this.btnCreateGroup.Name = "btnCreateGroup";
            this.btnCreateGroup.Size = new System.Drawing.Size(194, 36);
            this.btnCreateGroup.TabIndex = 7;
            this.btnCreateGroup.Text = "Create new group";
            this.btnCreateGroup.UseVisualStyleBackColor = true;
            this.btnCreateGroup.Click += new System.EventHandler(this.btnCreateGroup_Click);
            // 
            // btnAddUser
            // 
            this.btnAddUser.Location = new System.Drawing.Point(12, 442);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(194, 36);
            this.btnAddUser.TabIndex = 7;
            this.btnAddUser.Text = "Add new user";
            this.btnAddUser.UseVisualStyleBackColor = true;
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            // 
            // UserManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(703, 499);
            this.Controls.Add(this.btnAddUser);
            this.Controls.Add(this.btnCreateGroup);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnJoinGroup);
            this.Controls.Add(this.btnLeaveGroup);
            this.Controls.Add(this.lstBoxUserGroup);
            this.Controls.Add(this.lstBoxGroups);
            this.Controls.Add(this.lstBoxUsers);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UserManagement";
            this.Text = "User Management";
            this.Load += new System.EventHandler(this.UserManagement_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstBoxUsers;
        private System.Windows.Forms.ListBox lstBoxGroups;
        private System.Windows.Forms.ListBox lstBoxUserGroup;
        private System.Windows.Forms.Button btnLeaveGroup;
        private System.Windows.Forms.Button btnJoinGroup;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCreateGroup;
        private System.Windows.Forms.Button btnAddUser;
    }
}