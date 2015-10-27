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
            this.btnUserLeaveGroup = new System.Windows.Forms.Button();
            this.btnUserJoinGroup = new System.Windows.Forms.Button();
            this.lblUsers = new System.Windows.Forms.Label();
            this.lblUserGroup = new System.Windows.Forms.Label();
            this.lblGroup = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCreateGroup = new System.Windows.Forms.Button();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.btnDeleteUser = new System.Windows.Forms.Button();
            this.btnDeleteGroup = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lstBoxFunc = new System.Windows.Forms.ListBox();
            this.lblFunctionality = new System.Windows.Forms.Label();
            this.lstBoxFuncGroup = new System.Windows.Forms.ListBox();
            this.btnFuncAssign = new System.Windows.Forms.Button();
            this.btnFuncRemove = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstBoxUsers
            // 
            this.lstBoxUsers.DisplayMember = "Value";
            this.lstBoxUsers.FormattingEnabled = true;
            this.lstBoxUsers.ItemHeight = 20;
            this.lstBoxUsers.Location = new System.Drawing.Point(12, 32);
            this.lstBoxUsers.Name = "lstBoxUsers";
            this.lstBoxUsers.Size = new System.Drawing.Size(244, 404);
            this.lstBoxUsers.TabIndex = 0;
            this.lstBoxUsers.ValueMember = "Key";
            // 
            // lstBoxGroups
            // 
            this.lstBoxGroups.FormattingEnabled = true;
            this.lstBoxGroups.ItemHeight = 20;
            this.lstBoxGroups.Location = new System.Drawing.Point(594, 32);
            this.lstBoxGroups.Name = "lstBoxGroups";
            this.lstBoxGroups.Size = new System.Drawing.Size(244, 404);
            this.lstBoxGroups.TabIndex = 1;
            this.lstBoxGroups.SelectedValueChanged += new System.EventHandler(this.lstBoxGroups_SelectedValueChanged);
            // 
            // lstBoxUserGroup
            // 
            this.lstBoxUserGroup.DisplayMember = "Value";
            this.lstBoxUserGroup.FormattingEnabled = true;
            this.lstBoxUserGroup.ItemHeight = 20;
            this.lstBoxUserGroup.Location = new System.Drawing.Point(344, 32);
            this.lstBoxUserGroup.Name = "lstBoxUserGroup";
            this.lstBoxUserGroup.Size = new System.Drawing.Size(244, 404);
            this.lstBoxUserGroup.TabIndex = 2;
            this.lstBoxUserGroup.ValueMember = "Key";
            // 
            // btnUserLeaveGroup
            // 
            this.btnUserLeaveGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUserLeaveGroup.Location = new System.Drawing.Point(262, 244);
            this.btnUserLeaveGroup.Name = "btnUserLeaveGroup";
            this.btnUserLeaveGroup.Size = new System.Drawing.Size(75, 192);
            this.btnUserLeaveGroup.TabIndex = 3;
            this.btnUserLeaveGroup.Text = "←";
            this.btnUserLeaveGroup.UseVisualStyleBackColor = true;
            this.btnUserLeaveGroup.Click += new System.EventHandler(this.btnLeaveGroup_Click);
            // 
            // btnUserJoinGroup
            // 
            this.btnUserJoinGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUserJoinGroup.Location = new System.Drawing.Point(263, 32);
            this.btnUserJoinGroup.Name = "btnUserJoinGroup";
            this.btnUserJoinGroup.Size = new System.Drawing.Size(75, 192);
            this.btnUserJoinGroup.TabIndex = 4;
            this.btnUserJoinGroup.Text = "→";
            this.btnUserJoinGroup.UseVisualStyleBackColor = true;
            this.btnUserJoinGroup.Click += new System.EventHandler(this.btnJoinGroup_Click);
            // 
            // lblUsers
            // 
            this.lblUsers.AutoSize = true;
            this.lblUsers.Location = new System.Drawing.Point(17, 9);
            this.lblUsers.Name = "lblUsers";
            this.lblUsers.Size = new System.Drawing.Size(55, 20);
            this.lblUsers.TabIndex = 5;
            this.lblUsers.Text = "Users:";
            // 
            // lblUserGroup
            // 
            this.lblUserGroup.AutoSize = true;
            this.lblUserGroup.Location = new System.Drawing.Point(349, 9);
            this.lblUserGroup.MinimumSize = new System.Drawing.Size(244, 0);
            this.lblUserGroup.Name = "lblUserGroup";
            this.lblUserGroup.Size = new System.Drawing.Size(244, 20);
            this.lblUserGroup.TabIndex = 6;
            this.lblUserGroup.Text = "Users in group <group>:";
            // 
            // lblGroup
            // 
            this.lblGroup.AutoSize = true;
            this.lblGroup.Location = new System.Drawing.Point(599, 9);
            this.lblGroup.Name = "lblGroup";
            this.lblGroup.Size = new System.Drawing.Size(66, 20);
            this.lblGroup.TabIndex = 6;
            this.lblGroup.Text = "Groups:";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(344, 442);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(244, 78);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCreateGroup
            // 
            this.btnCreateGroup.Location = new System.Drawing.Point(594, 442);
            this.btnCreateGroup.Name = "btnCreateGroup";
            this.btnCreateGroup.Size = new System.Drawing.Size(244, 36);
            this.btnCreateGroup.TabIndex = 7;
            this.btnCreateGroup.Text = "Create new group";
            this.btnCreateGroup.UseVisualStyleBackColor = true;
            this.btnCreateGroup.Click += new System.EventHandler(this.btnCreateGroup_Click);
            // 
            // btnAddUser
            // 
            this.btnAddUser.Location = new System.Drawing.Point(12, 442);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(244, 36);
            this.btnAddUser.TabIndex = 7;
            this.btnAddUser.Text = "Add new user";
            this.btnAddUser.UseVisualStyleBackColor = true;
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            // 
            // btnDeleteUser
            // 
            this.btnDeleteUser.Location = new System.Drawing.Point(12, 484);
            this.btnDeleteUser.Name = "btnDeleteUser";
            this.btnDeleteUser.Size = new System.Drawing.Size(244, 36);
            this.btnDeleteUser.TabIndex = 8;
            this.btnDeleteUser.Text = "Delete selected user";
            this.btnDeleteUser.UseVisualStyleBackColor = true;
            // 
            // btnDeleteGroup
            // 
            this.btnDeleteGroup.Location = new System.Drawing.Point(594, 484);
            this.btnDeleteGroup.Name = "btnDeleteGroup";
            this.btnDeleteGroup.Size = new System.Drawing.Size(244, 36);
            this.btnDeleteGroup.TabIndex = 9;
            this.btnDeleteGroup.Text = "Delete selected group";
            this.btnDeleteGroup.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 531);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 20);
            this.label1.TabIndex = 11;
            this.label1.Text = "Functionality:";
            // 
            // lstBoxFunc
            // 
            this.lstBoxFunc.FormattingEnabled = true;
            this.lstBoxFunc.ItemHeight = 20;
            this.lstBoxFunc.Location = new System.Drawing.Point(12, 554);
            this.lstBoxFunc.Name = "lstBoxFunc";
            this.lstBoxFunc.Size = new System.Drawing.Size(244, 404);
            this.lstBoxFunc.TabIndex = 10;
            // 
            // lblFunctionality
            // 
            this.lblFunctionality.AutoSize = true;
            this.lblFunctionality.Location = new System.Drawing.Point(349, 531);
            this.lblFunctionality.Name = "lblFunctionality";
            this.lblFunctionality.Size = new System.Drawing.Size(251, 20);
            this.lblFunctionality.TabIndex = 13;
            this.lblFunctionality.Text = "Functionality assigned to <group>:";
            // 
            // lstBoxFuncGroup
            // 
            this.lstBoxFuncGroup.FormattingEnabled = true;
            this.lstBoxFuncGroup.ItemHeight = 20;
            this.lstBoxFuncGroup.Location = new System.Drawing.Point(344, 554);
            this.lstBoxFuncGroup.Name = "lstBoxFuncGroup";
            this.lstBoxFuncGroup.Size = new System.Drawing.Size(244, 404);
            this.lstBoxFuncGroup.TabIndex = 12;
            // 
            // btnFuncAssign
            // 
            this.btnFuncAssign.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFuncAssign.Location = new System.Drawing.Point(263, 554);
            this.btnFuncAssign.Name = "btnFuncAssign";
            this.btnFuncAssign.Size = new System.Drawing.Size(75, 192);
            this.btnFuncAssign.TabIndex = 15;
            this.btnFuncAssign.Text = "→";
            this.btnFuncAssign.UseVisualStyleBackColor = true;
            // 
            // btnFuncRemove
            // 
            this.btnFuncRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFuncRemove.Location = new System.Drawing.Point(262, 766);
            this.btnFuncRemove.Name = "btnFuncRemove";
            this.btnFuncRemove.Size = new System.Drawing.Size(75, 192);
            this.btnFuncRemove.TabIndex = 14;
            this.btnFuncRemove.Text = "←";
            this.btnFuncRemove.UseVisualStyleBackColor = true;
            // 
            // UserManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(867, 978);
            this.Controls.Add(this.btnFuncAssign);
            this.Controls.Add(this.btnFuncRemove);
            this.Controls.Add(this.lblFunctionality);
            this.Controls.Add(this.lstBoxFuncGroup);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstBoxFunc);
            this.Controls.Add(this.btnDeleteUser);
            this.Controls.Add(this.btnDeleteGroup);
            this.Controls.Add(this.btnAddUser);
            this.Controls.Add(this.btnCreateGroup);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblGroup);
            this.Controls.Add(this.lblUserGroup);
            this.Controls.Add(this.lblUsers);
            this.Controls.Add(this.btnUserJoinGroup);
            this.Controls.Add(this.btnUserLeaveGroup);
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
        private System.Windows.Forms.Button btnUserLeaveGroup;
        private System.Windows.Forms.Button btnUserJoinGroup;
        private System.Windows.Forms.Label lblUsers;
        private System.Windows.Forms.Label lblUserGroup;
        private System.Windows.Forms.Label lblGroup;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCreateGroup;
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.Button btnDeleteUser;
        private System.Windows.Forms.Button btnDeleteGroup;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstBoxFunc;
        private System.Windows.Forms.Label lblFunctionality;
        private System.Windows.Forms.ListBox lstBoxFuncGroup;
        private System.Windows.Forms.Button btnFuncAssign;
        private System.Windows.Forms.Button btnFuncRemove;
    }
}