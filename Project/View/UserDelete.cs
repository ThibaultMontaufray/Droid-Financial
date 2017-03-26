//using Tools4Libraries;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Windows.Forms;

//namespace Droid_financial
//{
//    public partial class UserDelete : window_popup
//    {
//        #region Attribute
//        private User _currentUser;
//        private Interface_fnc _intFnc;
//        #endregion

//        #region Properties
//        public User User
//        {
//            get { return _currentUser; }
//        }
//        #endregion

//        #region Constructor
//        public UserDelete(Interface_fnc intfnc)
//        {
//            _intFnc = intfnc;
//            _currentUser = new User();
//            InitializeComponent();
//            LoadUserList();
//            pictureBoxUser.Image = _intFnc.Tsm.Gui.imageListAvatars32.Images[0];
//            comboBoxListUsers.SelectedItem = comboBoxListUsers.Items[0];
//        }
//        public UserDelete(Interface_fnc intfnc, User user)
//        {
//            _intFnc = intfnc;
//            _currentUser = new User();
//            InitializeComponent();
//            LoadUserList();
//            Display(user);
//        }
//        public UserDelete(Interface_fnc intfnc, int? userId)
//        {
//            _intFnc = intfnc;
//            _currentUser = new User();
//            InitializeComponent();
//            LoadUserList();
//            if (userId != null) Display(userId);
//            else return;
//        }
//        #endregion

//        #region Methods private
//        private void LoadUserList()
//        {
//            comboBoxListUsers.Items.Clear();
//            foreach (User user in _intFnc.CurrentProject.Users)
//            {
//                comboBoxListUsers.Items.Add(user.Firstname + " " + user.Name);
//            }
//        }
//        private void DeleteIt()
//        {
//            foreach (Expense exps in _intFnc.CurrentProject.ListExpenses)
//            {
//                if (exps.UserId.Contains(_currentUser.ID))
//                {
//                    textBoxMessageHolder.Text = "The user had movement.\r\nRemove canceled.";
//                    textBoxMessageHolder.Height = 48;
//                    textBoxMessageHolder.Visible = true;
//                    textBoxMessageHolder.Invalidate();
//                    return;
//                }
//            }
//            foreach (User usr in _intFnc.CurrentProject.Users)
//            {
//                if (usr.Firstname.Equals(labelFirstnameValue.Text) && usr.Name.Equals(labelNameValue.Text))
//                {
//                    buttonDelete.DialogResult = System.Windows.Forms.DialogResult.OK;
//                    _currentUser = usr;
//                    this.Close();
//                    return;
//                }
//            }
//            textBoxMessageHolder.Text = "The user not found.\r\nRemove canceled.";
//            textBoxMessageHolder.Height = 48;
//            textBoxMessageHolder.Visible = true;
//            textBoxMessageHolder.Invalidate();
//            return;
//        }
//        private void UpdateAvatar()
//        {
//            pictureBoxUser.Image = _intFnc.Tsm.Gui.imageListAvatars32.Images[_currentUser.AvatarIndex < _intFnc.Tsm.Gui.imageListAvatars32.Images.Count ? _currentUser.AvatarIndex : 0];
//        }
//        private void LoadUser()
//        {
//            string tmp = string.Empty;
//            foreach (User user in _intFnc.CurrentProject.Users)
//            {
//                tmp = user.Firstname + " " + user.Name;
//                if (tmp.Equals(comboBoxListUsers.Text))
//                {
//                    Display(user);
//                    break;
//                }
//            }
//        }
//        private void Display(int? userId)
//        {
//            if (userId != null)
//            {
//                foreach (User user in _intFnc.CurrentProject.Users)
//                {
//                    if (userId.Equals(user.ID))
//                    {
//                        Display(user);
//                        break;
//                    }
//                }
//            }
//        }
//        private void Display(string firstName, string name)
//        {
//            foreach (User user in _intFnc.CurrentProject.Users)
//            {
//                if (firstName.Equals(user.Firstname) && name.Equals(user.Name))
//                {
//                    Display(user);
//                    break;
//                }
//            }
//        }
//        private void Display(User user)
//        {
//            labelNameValue.Text = user.Name;
//            labelFirstnameValue.Text = user.Firstname;
//            pictureBoxUser.Image = _intFnc.Tsm.Gui.imageListAvatars32.Images[user.AvatarIndex < _intFnc.Tsm.Gui.imageListAvatars32.Images.Count ? user.AvatarIndex : 0];
//            comboBoxListUsers.Text = user.Firstname + " " + user.Name;

//            _currentUser = user;
//        }
//        #endregion

//        #region Event
//        private void buttonCancel_Click(object sender, EventArgs e)
//        {
//            this.Close();
//        }
//        private void buttonApply_Click(object sender, EventArgs e)
//        {
//            DeleteIt();
//        }
//        private void buttonImgUp_Click(object sender, EventArgs e)
//        {
//            _currentUser.AvatarIndex = (_currentUser.AvatarIndex - 1) < 0 ? _intFnc.Tsm.Gui.imageListAvatars32.Images.Count - 1 : _currentUser.AvatarIndex - 1;
//            UpdateAvatar();
//        }
//        private void buttonImgDown_Click(object sender, EventArgs e)
//        {
//            _currentUser.AvatarIndex = (_currentUser.AvatarIndex + 1) % _intFnc.Tsm.Gui.imageListAvatars32.Images.Count;
//            UpdateAvatar();
//        }
//        private void comboBoxListUsers_SelectedIndexChanged(object sender, EventArgs e)
//        {
//            if (comboBoxListUsers.Text.Split(' ').Length > 0)
//            {
//                string firstname = comboBoxListUsers.Text.Split(' ')[0];
//                string name = comboBoxListUsers.Text.Split(' ')[1];
//                Display(firstname, name);
//            }
//        }
//        #endregion
//    }
//}
