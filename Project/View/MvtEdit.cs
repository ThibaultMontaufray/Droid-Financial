using Tools4Libraries;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
//using Touchless.Vision.Camera;

namespace Droid_financial
{
    public partial class MvtEdit : window_popup
    {
        #region Attribute
        private Interface_fnc _intFnc;
        private Movement _mvtCurrent;
        private Movement _mvtNew;
        private Regex _rexFloat = new Regex(@"^[0-9]*(?:\,[0-9]*)?$");
        private bool _billFullScreen = false;
        private Form _fullScreenForm;
        #endregion

        #region Properties
        public Movement Movement
        {
            get { return _mvtCurrent; }
            set { _mvtCurrent = value; }
        }
        #endregion

        #region Constructor
        public MvtEdit(Interface_fnc intFnc, int? mvtId)
        {
            _intFnc = intFnc;
            InitializeComponent();
            LoadPrj(mvtId);
            _mvtNew = new Movement();
            if (mvtId != null)
            {
                textBoxMovementName.Visible = false;
                buttonValidateMovement.Text = "Update movement";
                checkBoxNewMovement.Checked = false;
            }
            else
            {
                _mvtCurrent = _mvtNew;
                checkBoxNewMovement.Checked = true;
            }
            this.comboBoxMovement.SelectedValueChanged += new System.EventHandler(this.comboBoxMovement_SelectionChanged);
        }
        public MvtEdit(Interface_fnc intFnc, string picPath)
        {
            _intFnc = intFnc;
            InitializeComponent();
            checkBoxNewMovement.Checked = true;
            textBoxBillPath.Text = picPath;
            _mvtNew = new Movement();
            LoadPrj(null);
            _mvtCurrent = _mvtNew;
            if (!string.IsNullOrEmpty(picPath)) LoadPicture();
            this.comboBoxMovement.SelectedValueChanged += new System.EventHandler(this.comboBoxMovement_SelectionChanged);
        }
        #endregion

        #region Methods public
        #endregion

        #region Methods private
        private void LoadPicture()
        {
            if (File.Exists(textBoxBillPath.Text))
            {
                pictureBox.ImageLocation = textBoxBillPath.Text;
                pictureBox.BackColor = Color.Black;
                pictureBox.Invalidate();
            }
        }
        private void LoadPrj(int? mvtId)
        {
            comboBoxCurrency.Items.Add("AUD");
            comboBoxCurrency.Items.Add("EUR");
            comboBoxCurrency.Items.Add("GBP");
            comboBoxCurrency.Items.Add("JPY");
            comboBoxCurrency.Items.Add("INR");
            comboBoxCurrency.Items.Add("USD");
            comboBoxCurrency.Items.Add("XXX");

            comboBoxWho.Items.Clear();
            comboBoxParticipantList.Items.Clear();
            comboBoxMovement.Items.Clear();

            foreach (User usr in _intFnc.CurrentProject.Users)
	        {
                comboBoxWho.Items.Add((usr.Firstname + " " + usr.Name).Trim());
                comboBoxParticipantList.Items.Add((usr.Firstname + " " + usr.Name).Trim());
	        }
            foreach (Movement mvt in _intFnc.CurrentProject.Movements)
            {
                comboBoxMovement.Items.Add(mvt.Name);
                if (mvtId != null && mvt.ID.Equals(mvtId)) _mvtCurrent = mvt;
            }
            if (comboBoxMovement.Items.Count > 0) comboBoxMovement.SelectedItem = comboBoxMovement.Items[0];
            if (mvtId == null)
            {
                _mvtCurrent = new Movement();
                _mvtNew = new Movement();
                checkBoxNewMovement.Checked = true;
                LoadMovement(_mvtNew);
            }
            else LoadMovement(_mvtCurrent);
            comboBoxMovement.Enabled = !checkBoxNewMovement.Checked;
        }
        private void LoadMovement(Movement mvt)
        {
            if (mvt != null)
            {
                checkBoxAllRegardingParticipants.Checked = mvt.AllParticipant;
                checkBoxIsPartial.Checked = mvt.IsPartial;
                if (mvt.StartDate > dateTimePickerStartDate.MinDate && mvt.StartDate < dateTimePickerStartDate.MaxDate) dateTimePickerStartDate.Value = mvt.StartDate;
                else dateTimePickerStartDate.Value = DateTime.Now;

                if (mvt.EndDate > dateTimePickerEndDate.MinDate && mvt.EndDate < dateTimePickerEndDate.MaxDate) dateTimePickerEndDate.Value = mvt.EndDate;
                else dateTimePickerEndDate.Value = DateTime.Now;

                if (!string.IsNullOrEmpty(mvt.Name))
                {
                    comboBoxMovement.SelectedItem = comboBoxMovement.Items.IndexOf(mvt.Name) == -1 ? null : comboBoxMovement.Items[comboBoxMovement.Items.IndexOf(mvt.Name)];
                }
                comboBoxCurrency.SelectedItem = (string.IsNullOrEmpty(mvt.Currency) || comboBoxCurrency.Items.IndexOf(mvt.Currency) == -1) ? comboBoxCurrency.Items[0] : comboBoxCurrency.Items[comboBoxCurrency.Items.IndexOf(mvt.Currency)];
                textBoxDescription.Text = mvt.Description;
                textBoxAmount.Text = mvt.Amount.ToString();
                textBoxMovementName.Text = mvt.Name;
                textBoxBillPath.Text = mvt.BillPath;
                LoadPicture();
                User userTmp;
                List<string> ls = new List<string>();
                foreach (string s in comboBoxParticipantList.Items) ls.Add(s) ;
                foreach (string userStr in ls)
                {
                    userTmp = _intFnc.CurrentProject.Users.Find(x => (x.Firstname + " " + x.Name).Trim().Equals(userStr.Trim()));
                    if (userTmp != null && mvt.UserIdParticipant.Contains(userTmp.ID))
                    {
                        if (comboBoxParticipantList.Items.IndexOf(userStr.Trim()) != -1) comboBoxParticipantList.SetItemChecked(comboBoxParticipantList.Items.IndexOf(userStr.Trim()), true);
                    }
                }
                foreach (string s in comboBoxWho.Items) ls.Add(s);
                foreach (string userStr in ls)
                {
                    userTmp = _intFnc.CurrentProject.Users.Find(x => (x.Firstname + " " + x.Name).Trim().Equals(userStr.Trim()));
                    if (userTmp != null && mvt.UserId.Contains(userTmp.ID))
                    {
                        if (comboBoxWho.Items.IndexOf(userStr.Trim()) != -1) comboBoxWho.SetItemChecked(comboBoxWho.Items.IndexOf(userStr.Trim()), true);
                    }
                }
                switch (mvt.Gop)
                {
                    case Movement.GOP.COMODITIES: radioButtonComodities.Checked = true; break;
                    case Movement.GOP.ACTIVITIES: radioButtonActivities.Checked = true; break;
                    case Movement.GOP.FOOD: radioButtonFood.Checked = true; break;
                    case Movement.GOP.OTHER: radioButtonOther.Checked = true; break;
                    case Movement.GOP.TRANSPORT: radioButtonTransport.Checked = true; break;
                    case Movement.GOP.CLOTHES: radioButtonClothe.Checked = true; break;
                    case Movement.GOP.LOGEMENT: radioButtonLogement.Checked = true; break;
                    case Movement.GOP.ABONMENT: radioButtonAbonmnent.Checked = true; break;
                    case Movement.GOP.LOANS: radioButtonLoan.Checked = true; break;
                }
                if (!checkBoxNewMovement.Checked)
                {
                    foreach (var item in comboBoxMovement.Items)
                    {
                        if (item.ToString().Equals(mvt.Name))
                        {
                            comboBoxMovement.SelectedItem = item;
                            break;
                        }
                    }
                }
                else textBoxMovementName.Text = mvt.Name;
            }
        }
        private void SaveMovement(bool newMvt)
        {
            if (_mvtCurrent != null)
            {
                if (newMvt)
                {
                    UpdateAmount(_mvtNew);
                    _mvtNew.BillPath = textBoxBillPath.Text;
                    _mvtNew.Currency = comboBoxCurrency.Text;
                    _mvtNew.Name = textBoxMovementName.Text;
                    _mvtNew.Description = textBoxDescription.Text;
                    _mvtNew.AllParticipant = checkBoxAllRegardingParticipants.Checked;

                    _mvtNew.UserId.Clear();
                    foreach (string item in comboBoxWho.Text.Split(','))
                        if (!string.IsNullOrEmpty(item))
                        {
                            User u = _intFnc.CurrentProject.GetUser(item.Trim());
                            if (u != null) _mvtNew.UserId.Add(u.ID);
                        }
                    _mvtNew.UserIdParticipant.Clear();
                    foreach (string item in comboBoxParticipantList.Text.Split(','))
                        if (!string.IsNullOrEmpty(item))
                        {
                            User u = _intFnc.CurrentProject.GetUser(item.Trim());
                            if (u != null) _mvtNew.UserIdParticipant.Add(u.ID);
                        }

                    _mvtNew.StartDate = dateTimePickerStartDate.Value;
                    _mvtNew.EndDate = dateTimePickerEndDate.Value;

                    if (radioButtonActivities.Checked) _mvtNew.Gop = Movement.GOP.ACTIVITIES;
                    else if (radioButtonComodities.Checked) _mvtNew.Gop = Movement.GOP.COMODITIES;
                    else if (radioButtonFood.Checked) _mvtNew.Gop = Movement.GOP.FOOD;
                    else if (radioButtonOther.Checked) _mvtNew.Gop = Movement.GOP.OTHER;
                    else if (radioButtonTransport.Checked) _mvtNew.Gop = Movement.GOP.TRANSPORT;
                    else if (radioButtonAbonmnent.Checked) _mvtNew.Gop = Movement.GOP.ABONMENT;
                    else if (radioButtonLogement.Checked) _mvtNew.Gop = Movement.GOP.LOGEMENT;
                    else if (radioButtonLoan.Checked) _mvtNew.Gop = Movement.GOP.LOANS;
                    else if (radioButtonClothe.Checked) _mvtNew.Gop = Movement.GOP.CLOTHES;
                }
                else
                {
                    UpdateAmount(_mvtCurrent);
                    _mvtCurrent.BillPath = textBoxBillPath.Text;
                    _mvtCurrent.Currency = comboBoxCurrency.Text;
                    _mvtCurrent.Name = comboBoxMovement.Text;
                    _mvtCurrent.Description = textBoxDescription.Text;
                    _mvtCurrent.StartDate = dateTimePickerStartDate.Value;
                    _mvtCurrent.EndDate = dateTimePickerEndDate.Value;
                    _mvtCurrent.IsPartial = checkBoxIsPartial.Checked;
                    _mvtCurrent.AllParticipant = checkBoxAllRegardingParticipants.Checked;

                    _mvtCurrent.UserId.Clear();
                    foreach (string item in comboBoxWho.Text.Split(','))
                        if (!string.IsNullOrEmpty(item))
                        {
                            User u = _intFnc.CurrentProject.GetUser(item.Trim());
                            if (u != null) _mvtCurrent.UserId.Add(u.ID);
                        }
                    _mvtCurrent.UserIdParticipant.Clear();
                    foreach (string item in comboBoxParticipantList.Text.Split(','))
                        if (!string.IsNullOrEmpty(item))
                        {
                            User u = _intFnc.CurrentProject.GetUser(item.Trim());
                            if (u != null) _mvtCurrent.UserIdParticipant.Add(u.ID);
                        }
                    
                    if (radioButtonActivities.Checked) _mvtCurrent.Gop = Movement.GOP.ACTIVITIES;
                    else if (radioButtonComodities.Checked) _mvtCurrent.Gop = Movement.GOP.COMODITIES;
                    else if (radioButtonFood.Checked) _mvtCurrent.Gop = Movement.GOP.FOOD;
                    else if (radioButtonOther.Checked) _mvtCurrent.Gop = Movement.GOP.OTHER;
                    else if (radioButtonTransport.Checked) _mvtCurrent.Gop = Movement.GOP.TRANSPORT;
                    else if (radioButtonAbonmnent.Checked) _mvtCurrent.Gop = Movement.GOP.ABONMENT;
                    else if (radioButtonLogement.Checked) _mvtCurrent.Gop = Movement.GOP.LOGEMENT;
                    else if (radioButtonLoan.Checked) _mvtCurrent.Gop = Movement.GOP.LOANS;
                    else if (radioButtonClothe.Checked) _mvtCurrent.Gop = Movement.GOP.CLOTHES;
                }
            }
        }
        private Movement FindMovement()
        {
            foreach (Movement mvt in _intFnc.CurrentProject.Movements)
            {
                if (textBoxMovementName.Text.Equals(mvt.Name))
                {
                    return mvt;
                }
            }
            if (_intFnc.CurrentProject.Movements.Count > 0) return _intFnc.CurrentProject.Movements[0];
            return null;
        }
        private void UpdateAmount(Movement mvt)
        {
            if (mvt != null) 
            {
                textBoxAmount.Text = textBoxAmount.Text.Replace('.', ',');
                if (_rexFloat.IsMatch(textBoxAmount.Text))
                {
                    try
                    {
                        mvt.Amount = float.Parse(textBoxAmount.Text);
                    }
                    catch (FormatException fexp)
                    {
                        Console.WriteLine(fexp.Message);
                    }
                    catch (Exception exp)
                    {
                        Console.WriteLine(exp.Message);
                    }
                }
                else textBoxAmount.Text = mvt.Amount.ToString();
            }
        }
        private void BrowseImage()
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    textBoxBillPath.Text = ofd.FileName;
                    LoadPicture();
                }
            }
        }
        private void BillClick()
        {
            _billFullScreen = !_billFullScreen;
            if (!_billFullScreen)
            {
                // switch in non fullscreen
                if (_fullScreenForm != null) _fullScreenForm.Close();
            }
            else
            {
                // switch in fullscreen
                _fullScreenForm = new Form();
                _fullScreenForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                PictureBox pb = new PictureBox();
                pb.BackgroundImage = pictureBox.Image;
                pb.BackgroundImageLayout = ImageLayout.Zoom;
                pb.BackColor = Color.Black;
                pb.Dock = DockStyle.Fill;
                pb.DoubleClick += pb_DoubleClick;
                _fullScreenForm.Controls.Add(pb);
                _fullScreenForm.WindowState = FormWindowState.Maximized;
                _fullScreenForm.ShowDialog();
            }
        }
        #endregion

        #region Event
        private void buttonValidateMovement_Click(object sender, EventArgs e)
        {
            SaveMovement(checkBoxNewMovement.Checked);
            if (checkBoxNewMovement.Checked) _mvtCurrent = _mvtNew;
            this.Close();
        }
        private void buttonCancel_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
        private void textBoxAmount_TextChanged(object sender, EventArgs e)
        {
            UpdateAmount(checkBoxNewMovement.Checked ? _mvtNew : _mvtCurrent);
        }
        private void checkBoxNewMovement_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxMovement.Enabled = !checkBoxNewMovement.Checked;
            //textBoxMovementName.Enabled = checkBoxNewMovement.Checked;
            if (!checkBoxNewMovement.Checked)
            {
                buttonValidateMovement.Text = "Save";
                SaveMovement(true);
                if (_mvtCurrent != null) LoadMovement(_mvtCurrent);
                else LoadMovement(FindMovement());
            }
            else
            {
                buttonValidateMovement.Text = "Create";
                SaveMovement(false);
                LoadMovement(_mvtNew);
            }
        }
        private void comboBoxMovement_SelectionChanged(object sender, EventArgs e)
        {
            LoadMovement(FindMovement());
        }
        private void buttonCamera_Click(object sender, EventArgs e)
        {
            using (CamGUI myCamGUi = new CamGUI())
            {
                if (myCamGUi.ShowDialog() == DialogResult.OK)
                {
                    textBoxBillPath.Text = myCamGUi.PicturePath;
                    LoadPicture();
                }
            }
        }
        private void buttonBrowseBill_Click(object sender, EventArgs e)
        {
            BrowseImage();
        }
        private void pictureBox_DoubleClick(object sender, EventArgs e)
        {
            BillClick();
        }
        private void pb_DoubleClick(object sender, EventArgs e)
        {
            _fullScreenForm.Close();
        }
        private void checkBoxIsPartial_CheckedChanged(object sender, EventArgs e)
        {
            labelStartDate.Enabled = checkBoxIsPartial.Checked;
            labelEndDate.Enabled = checkBoxIsPartial.Checked;
            dateTimePickerStartDate.Enabled = checkBoxIsPartial.Checked;
            dateTimePickerEndDate.Enabled = checkBoxIsPartial.Checked;
        }
        private void textBoxParticipantList_Click(object sender, EventArgs e)
        {
            MessageBox.Show("add participant");
        }
        private void checkBoxAllRegardingParticipants_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxParticipantList.Enabled = !checkBoxAllRegardingParticipants.Checked;
        }
        #endregion
    }
}
