//using Tools4Libraries;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Windows.Forms;

//namespace Droid.financial
//{
//    public partial class UserEdit : window_popup
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
//        public UserEdit(Interface_fnc intfnc)
//        {
//            _intFnc = intfnc;
//            _currentUser = new User();
//            InitializeComponent();
//            LoadUserList();
//            pictureBoxUser.Image = _intFnc.Tsm.Gui.imageListAvatars32.Images[0];
//            comboBoxListUsers.SelectedItem = comboBoxListUsers.Items[0];
//        }
//        public UserEdit(Interface_fnc intfnc, User user)
//        {
//            _intFnc = intfnc;
//            _currentUser = new User();
//            _currentUser.Calendars.Add(new ICalendar(_intFnc.CurrentProject));
//            InitializeComponent();
//            LoadUserList();
//            Display(user);
//        }
//        public UserEdit(Interface_fnc intfnc, int? userId)
//        {
//            _intFnc = intfnc;
//            _currentUser = new User();
//            _currentUser.Calendars.Add(new ICalendar(_intFnc.CurrentProject));
//            InitializeComponent();
//            LoadUserList();
//            if (userId != null) Display(userId ?? 0);
//            else
//            {
//                checkBoxNew.Checked = true;
//                _currentUser = new User();
//                _currentUser.Calendars.Add(new ICalendar(_intFnc.CurrentProject));
//            }
//        }
//        public UserEdit(Interface_fnc intfnc, string firstName, string name)
//        {
//            _intFnc = intfnc;
//            _currentUser = new User();
//            _currentUser.Calendars.Add(new ICalendar(_intFnc.CurrentProject));
//            InitializeComponent();
//            LoadUserList();
//            Display(firstName, name);
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
//        private void SaveChange()
//        {
//            foreach (User usr in _intFnc.CurrentProject.Users)
//	        {
//                if (usr.Name.Equals(textBoxName.Text) && usr.Firstname.Equals(textBoxFirstname.Text) && checkBoxNew.Checked)
//                {
//                    textBoxMessageHolder.Text = "The user already exist. Saving canceled";
//                    textBoxMessageHolder.Visible = true;
//                    return;
//                }
//	        }

//            _currentUser.Name = textBoxName.Text;
//            _currentUser.Firstname = textBoxFirstname.Text;
//            _currentUser.Color = buttonColor.BackColor;
//            SaveCalendar();
//            this.DialogResult = System.Windows.Forms.DialogResult.OK;
//            this.Close();
//        }
//        private void SaveCalendar()
//        {
//            bool calAlreadyExist = false;
//            foreach (ICalendar cal in _currentUser.Calendars)
//            {
//                if (cal.Text.Equals(_intFnc.CurrentProject.Name))
//                {
//                    calAlreadyExist = true;
//                    cal.Text = _intFnc.CurrentProject.Name;
//                    cal.BeginDate = new DateTime(dateTimePickerStart.Value.Year,
//                        dateTimePickerStart.Value.Month,dateTimePickerStart.Value.Day,
//                        0, 0, 0);
//                    cal.EndDate = new DateTime(dateTimePickerEnd.Value.Year,
//                        dateTimePickerEnd.Value.Month, dateTimePickerEnd.Value.Day,
//                        23, 59, 59);
//                    break;
//                }
//            }
//            if (!calAlreadyExist)
//            {
//                ICalendar ic = new ICalendar();
//                ic.Text = _intFnc.CurrentProject.Name;
//                ic.BeginDate = dateTimePickerStart.Value;
//                ic.EndDate = dateTimePickerEnd.Value;
//                _currentUser.Calendars.Add(ic);
//            }
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
//        private void Display(int userId)
//        {
//            foreach (User user in _intFnc.CurrentProject.Users)
//            {
//                if (userId.Equals(user.ID))
//                {
//                    Display(user);
//                    break;
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
//            textBoxName.Text = user.Name;
//            textBoxFirstname.Text = user.Firstname;
//            buttonColor.BackColor = user.Color;
//            pictureBoxUser.Image = _intFnc.Tsm.Gui.imageListAvatars32.Images[user.AvatarIndex < _intFnc.Tsm.Gui.imageListAvatars32.Images.Count ? user.AvatarIndex : 0];
//            comboBoxListUsers.Text = user.Firstname + " " + user.Name;
//            foreach (ICalendar pp in user.Calendars)
//            {
//                if (pp.Text.Equals(_intFnc.CurrentProject.Name))
//                {
//                    dateTimePickerStart.Value = pp.BeginDate;
//                    dateTimePickerEnd.Value = pp.EndDate;
//                    break;
//                }
//            }
//            _currentUser = user;
//        }
//        #endregion

//        #region Event
//        private void buttonCancel_Click(object sender, EventArgs e)
//        {
//            this.Close();
//        }
//        private void buttonColor_Click(object sender, EventArgs e)
//        {
//            if (colorDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
//            {
//                buttonColor.BackColor = colorDialog1.Color;
//            }
//        }
//        private void buttonApply_Click(object sender, EventArgs e)
//        {
//            SaveChange();
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
//        private void checkBoxNew_CheckedChanged(object sender, EventArgs e)
//        {
//            comboBoxListUsers.Enabled = !checkBoxNew.Checked;
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
