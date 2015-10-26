﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Playground_v3
{
    public partial class UserManagement : Form
    {
        private Dictionary<int, string> _userDictionary;
        private Dictionary<int, string> _groupDictionary;
        private List<KeyValuePair<int, int>> _userGroupList;

        public UserManagement()
        {
            InitializeComponent();
        }

        /// <summary>
        /// After loading get all tables from the sqlite database. 
        /// Bind the group list to the lstBoxGroups.
        /// Set selected index to 0 and set display and value members to KeyValuePair standard
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserManagement_Load(object sender, EventArgs e)
        {
            RefreshTables();

            lstBoxGroups.DataSource = new BindingSource(_groupDictionary, null);
            lstBoxGroups.DisplayMember = "Value";
            lstBoxGroups.ValueMember = "Key";

            lstBoxGroups.SelectedIndex = 0;
        }

        private void RefreshTables()
        {
            _groupDictionary = Auth.GetGroupList();
            _userDictionary = Auth.GetUserList();
            _userGroupList = Auth.GetUserGroupList();
        }

        /// <summary>
        /// Update the lstBoxUsers and lstBoxUserGroup to match the variables _userDictionary and _userGroupList
        /// </summary>
        private void UpdateUsers()
        {
            // Get all user id's who are in the selected group using LinQ
            List<int> usersInGroup = (
                    from kvPair 
                    in _userGroupList
                    where kvPair.Value == (int) lstBoxGroups.SelectedValue
                    select kvPair.Key
                ).ToList();

            // Clear both listboxes
            lstBoxUserGroup.Items.Clear();
            lstBoxUsers.Items.Clear();

            // For each user
            foreach (KeyValuePair<int, string> user in _userDictionary)
            {
                // If they are in the current group add them to the lstBoxUserGroup (middle listbox)
                if (usersInGroup.Contains(user.Key))
                {
                    lstBoxUserGroup.Items.Add(user);
                }
                else // else add them to the lstBoxUsers (left listbox)
                {
                    lstBoxUsers.Items.Add(user);
                }
            }
        }


        private void btnAddUser_Click(object sender, EventArgs e)
        {
            string username = Prompt.ShowDialog("Add new user", "Enter the new username:");

            if (username.Equals("")) return;
            
            int userId = (int) Auth.AddUser(username);

            if (userId == 0) return;

            _userDictionary.Add(userId, username);

            UpdateUsers();
        }

        private void btnCreateGroup_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Join the selected user (from the left lstbox) to the selected group (right lstbox)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnJoinGroup_Click(object sender, EventArgs e)
        {
            // Get the selected user and cast it to a KeyValuePair to get the user id
            KeyValuePair<int, string> user = (KeyValuePair<int, string>) lstBoxUsers.SelectedItem;
            // The key has to be saved to a new variable to be used in the userGroupPair 
            int userId = user.Key;
            
            // Generate a userGroupPair using the user id and the group id
            KeyValuePair<int, int> userGroupPair = new KeyValuePair<int, int>(userId, (int) lstBoxGroups.SelectedValue);

            // Add the userGroupPair to the _userGroupList
            _userGroupList.Add(userGroupPair);

            // Update the left and middle listbox
            UpdateUsers();
        }

        /// <summary>
        /// Delete the selected user (middle lstbox) from the selected group (right lstbox)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLeaveGroup_Click(object sender, EventArgs e)
        {
            // Get the selected user and cast it to a KeyValuePair to get the user id
            KeyValuePair<int, string> user = (KeyValuePair<int, string>) lstBoxUserGroup.SelectedItem;
            // The key has to be saved to a new variable to be used in the userGroupPair 
            int userId = user.Key;

            // Generate a userGroupPair using the user id and the group id
            KeyValuePair<int, int> userGroupPair = new KeyValuePair<int, int>(userId, (int)lstBoxGroups.SelectedValue);

            // Remove the userGroupPair from the _userGroupList
            _userGroupList.Remove(userGroupPair);

            // Update the left and middle listbox
            UpdateUsers();
        }

        /// <summary>
        /// Update the left and middle listbox when group has changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstBoxGroups_SelectedValueChanged(object sender, EventArgs e)
        {
            // Only update when selected value is an actual integer to prevent runtime errors
            if (lstBoxGroups.SelectedValue is int)
            {
                UpdateUsers();
            }
        }
    }
}
