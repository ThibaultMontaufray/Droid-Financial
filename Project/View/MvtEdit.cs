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
    public partial class ExpsEdit : window_popup
    {
        #region Attribute
        private Interface_fnc _intFnc;
        private Expense _expsCurrent;
        private Expense _expsNew;
        private Regex _rexFloat = new Regex(@"^[0-9]*(?:\,[0-9]*)?$");
        private bool _billFullScreen = false;
        private Form _fullScreenForm;
        #endregion

        #region Properties
        public Expense Movement
        {
            get { return _expsCurrent; }
            set { _expsCurrent = value; }
        }
        #endregion

        #region Constructor
        public ExpsEdit(Interface_fnc intFnc, int? expsId)
        {
            _intFnc = intFnc;
            InitializeComponent();
            LoadPrj(expsId);
            _expsNew = new Expense();
            if (expsId != null)
            {
                textBoxMovementName.Visible = false;
                buttonValidateMovement.Text = "Update movement";
                checkBoxNewMovement.Checked = false;
            }
            else
            {
                _expsCurrent = _expsNew;
                checkBoxNewMovement.Checked = true;
            }
            this.comboBoxMovement.SelectedValueChanged += new System.EventHandler(this.comboBoxMovement_SelectionChanged);
        }
        public ExpsEdit(Interface_fnc intFnc, string picPath)
        {
            _intFnc = intFnc;
            InitializeComponent();
            checkBoxNewMovement.Checked = true;
            textBoxBillPath.Text = picPath;
            _expsNew = new Expense();
            LoadPrj(null);
            _expsCurrent = _expsNew;
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
        private void LoadPrj(int? expsId)
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
            foreach (Expense exps in _intFnc.CurrentProject.ListExpenses)
            {
                comboBoxMovement.Items.Add(exps.Name);
                if (expsId != null && exps.Id.Equals(expsId)) _expsCurrent = exps;
            }
            if (comboBoxMovement.Items.Count > 0) comboBoxMovement.SelectedItem = comboBoxMovement.Items[0];
            if (expsId == null)
            {
                _expsCurrent = new Expense();
                _expsNew = new Expense();
                checkBoxNewMovement.Checked = true;
                LoadExpense(_expsNew);
            }
            else LoadExpense(_expsCurrent);
            comboBoxMovement.Enabled = !checkBoxNewMovement.Checked;
        }
        private void LoadExpense(Expense exps)
        {
            if (exps != null)
            {
                checkBoxAllRegardingParticipants.Checked = exps.AllParticipant;
                checkBoxIsPartial.Checked = exps.IsPartial;
                if (exps.StartDate > dateTimePickerStartDate.MinDate && exps.StartDate < dateTimePickerStartDate.MaxDate) dateTimePickerStartDate.Value = exps.StartDate;
                else dateTimePickerStartDate.Value = DateTime.Now;

                if (exps.EndDate > dateTimePickerEndDate.MinDate && exps.EndDate < dateTimePickerEndDate.MaxDate) dateTimePickerEndDate.Value = exps.EndDate;
                else dateTimePickerEndDate.Value = DateTime.Now;

                if (!string.IsNullOrEmpty(exps.Name))
                {
                    comboBoxMovement.SelectedItem = comboBoxMovement.Items.IndexOf(exps.Name) == -1 ? null : comboBoxMovement.Items[comboBoxMovement.Items.IndexOf(exps.Name)];
                }
                comboBoxCurrency.SelectedItem = (string.IsNullOrEmpty(exps.Currency) || comboBoxCurrency.Items.IndexOf(exps.Currency) == -1) ? comboBoxCurrency.Items[0] : comboBoxCurrency.Items[comboBoxCurrency.Items.IndexOf(exps.Currency)];
                textBoxDescription.Text = exps.Description;
                textBoxAmount.Text = exps.Amount.ToString();
                textBoxMovementName.Text = exps.Name;
                textBoxBillPath.Text = exps.BillPath;
                LoadPicture();
                User userTmp;
                List<string> ls = new List<string>();
                foreach (string s in comboBoxParticipantList.Items) ls.Add(s) ;
                foreach (string userStr in ls)
                {
                    userTmp = _intFnc.CurrentProject.Users.Find(x => (x.Firstname + " " + x.Name).Trim().Equals(userStr.Trim()));
                    if (userTmp != null && exps.Movements.Where(p => p.UserId.Equals(userTmp.ID)).Count() > 0)
                    {
                        if (comboBoxParticipantList.Items.IndexOf(userStr.Trim()) != -1) comboBoxParticipantList.SetItemChecked(comboBoxParticipantList.Items.IndexOf(userStr.Trim()), true);
                    }
                }
                foreach (string s in comboBoxWho.Items) ls.Add(s);
                foreach (string userStr in ls)
                {
                    userTmp = _intFnc.CurrentProject.Users.Find(x => (x.Firstname + " " + x.Name).Trim().Equals(userStr.Trim()));
                    //if (userTmp != null && exps. UserId.Contains(userTmp.ID))
                    //{
                    //    if (comboBoxWho.Items.IndexOf(userStr.Trim()) != -1) comboBoxWho.SetItemChecked(comboBoxWho.Items.IndexOf(userStr.Trim()), true);
                    //}
                }
                switch (exps.Gop)
                {
                    case Expense.GOP.COMODITIES: radioButtonComodities.Checked = true; break;
                    case Expense.GOP.ACTIVITIES: radioButtonActivities.Checked = true; break;
                    case Expense.GOP.FOOD: radioButtonFood.Checked = true; break;
                    case Expense.GOP.OTHER: radioButtonOther.Checked = true; break;
                    case Expense.GOP.TRANSPORT: radioButtonTransport.Checked = true; break;
                    case Expense.GOP.CLOTHES: radioButtonClothe.Checked = true; break;
                    case Expense.GOP.LOGEMENT: radioButtonLogement.Checked = true; break;
                    case Expense.GOP.ABONMENT: radioButtonAbonmnent.Checked = true; break;
                    case Expense.GOP.LOANS: radioButtonLoan.Checked = true; break;
                }
                if (!checkBoxNewMovement.Checked)
                {
                    foreach (var item in comboBoxMovement.Items)
                    {
                        if (item.ToString().Equals(exps.Name))
                        {
                            comboBoxMovement.SelectedItem = item;
                            break;
                        }
                    }
                }
                else textBoxMovementName.Text = exps.Name;
            }
        }
        private void SaveExpense(bool newExps)
        {
            if (_expsCurrent != null)
            {
                if (newExps)
                {
                    UpdateAmount(_expsNew);
                    _expsNew.BillPath = textBoxBillPath.Text;
                    _expsNew.Currency = comboBoxCurrency.Text;
                    _expsNew.Name = textBoxMovementName.Text;
                    _expsNew.Description = textBoxDescription.Text;
                    _expsNew.AllParticipant = checkBoxAllRegardingParticipants.Checked;

                    //_expsNew.UserId.Clear();
                    //foreach (string item in comboBoxWho.Text.Split(','))
                    //    if (!string.IsNullOrEmpty(item))
                    //    {
                    //        User u = _intFnc.CurrentProject.GetUser(item.Trim());
                    //        if (u != null) _expsNew.UserId.Add(u.ID);
                    //    }
                    _expsNew.Movements.Clear();
                    foreach (string item in comboBoxParticipantList.Text.Split(','))
                        if (!string.IsNullOrEmpty(item))
                        {
                            User u = _intFnc.CurrentProject.GetUser(item.Trim());
                            if (u != null) _expsNew.Movements.Add(new Movement() { UserId = u.ID, Amount = 0, Date = DateTime.Now });
                        }

                    _expsNew.StartDate = dateTimePickerStartDate.Value;
                    _expsNew.EndDate = dateTimePickerEndDate.Value;

                    if (radioButtonActivities.Checked) _expsNew.Gop = Expense.GOP.ACTIVITIES;
                    else if (radioButtonComodities.Checked) _expsNew.Gop = Expense.GOP.COMODITIES;
                    else if (radioButtonFood.Checked) _expsNew.Gop = Expense.GOP.FOOD;
                    else if (radioButtonOther.Checked) _expsNew.Gop = Expense.GOP.OTHER;
                    else if (radioButtonTransport.Checked) _expsNew.Gop = Expense.GOP.TRANSPORT;
                    else if (radioButtonAbonmnent.Checked) _expsNew.Gop = Expense.GOP.ABONMENT;
                    else if (radioButtonLogement.Checked) _expsNew.Gop = Expense.GOP.LOGEMENT;
                    else if (radioButtonLoan.Checked) _expsNew.Gop = Expense.GOP.LOANS;
                    else if (radioButtonClothe.Checked) _expsNew.Gop = Expense.GOP.CLOTHES;
                }
                else
                {
                    UpdateAmount(_expsCurrent);
                    _expsCurrent.BillPath = textBoxBillPath.Text;
                    _expsCurrent.Currency = comboBoxCurrency.Text;
                    _expsCurrent.Name = comboBoxMovement.Text;
                    _expsCurrent.Description = textBoxDescription.Text;
                    _expsCurrent.StartDate = dateTimePickerStartDate.Value;
                    _expsCurrent.EndDate = dateTimePickerEndDate.Value;
                    _expsCurrent.IsPartial = checkBoxIsPartial.Checked;
                    _expsCurrent.AllParticipant = checkBoxAllRegardingParticipants.Checked;

                    //_expsCurrent.UserId.Clear();
                    //foreach (string item in comboBoxWho.Text.Split(','))
                    //    if (!string.IsNullOrEmpty(item))
                    //    {
                    //        User u = _intFnc.CurrentProject.GetUser(item.Trim());
                    //        if (u != null) _expsCurrent.UserId.Add(u.ID);
                    //    }
                    _expsCurrent.Movements.Clear();
                    foreach (string item in comboBoxParticipantList.Text.Split(','))
                        if (!string.IsNullOrEmpty(item))
                        {
                            User u = _intFnc.CurrentProject.GetUser(item.Trim());
                            if (u != null) _expsCurrent.Movements.Add(new Movement() { UserId = u.ID, Amount = 0, Date = DateTime.Now });
                        }
                    
                    if (radioButtonActivities.Checked) _expsCurrent.Gop = Expense.GOP.ACTIVITIES;
                    else if (radioButtonComodities.Checked) _expsCurrent.Gop = Expense.GOP.COMODITIES;
                    else if (radioButtonFood.Checked) _expsCurrent.Gop = Expense.GOP.FOOD;
                    else if (radioButtonOther.Checked) _expsCurrent.Gop = Expense.GOP.OTHER;
                    else if (radioButtonTransport.Checked) _expsCurrent.Gop = Expense.GOP.TRANSPORT;
                    else if (radioButtonAbonmnent.Checked) _expsCurrent.Gop = Expense.GOP.ABONMENT;
                    else if (radioButtonLogement.Checked) _expsCurrent.Gop = Expense.GOP.LOGEMENT;
                    else if (radioButtonLoan.Checked) _expsCurrent.Gop = Expense.GOP.LOANS;
                    else if (radioButtonClothe.Checked) _expsCurrent.Gop = Expense.GOP.CLOTHES;
                }
            }
        }
        private Expense FindExpense()
        {
            foreach (Expense exps in _intFnc.CurrentProject.ListExpenses)
            {
                if (textBoxMovementName.Text.Equals(exps.Name))
                {
                    return exps;
                }
            }
            if (_intFnc.CurrentProject.ListExpenses.Count > 0) return _intFnc.CurrentProject.ListExpenses[0];
            return null;
        }
        private void UpdateAmount(Expense exps)
        {
            if (exps != null) 
            {
                textBoxAmount.Text = textBoxAmount.Text.Replace('.', ',');
                if (_rexFloat.IsMatch(textBoxAmount.Text))
                {
                    try
                    {
                        exps.Amount = float.Parse(textBoxAmount.Text);
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
                else textBoxAmount.Text = exps.Amount.ToString();
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
            SaveExpense(checkBoxNewMovement.Checked);
            if (checkBoxNewMovement.Checked) _expsCurrent = _expsNew;
            this.Close();
        }
        private void buttonCancel_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
        private void textBoxAmount_TextChanged(object sender, EventArgs e)
        {
            UpdateAmount(checkBoxNewMovement.Checked ? _expsNew : _expsCurrent);
        }
        private void checkBoxNewMovement_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxMovement.Enabled = !checkBoxNewMovement.Checked;
            //textBoxMovementName.Enabled = checkBoxNewMovement.Checked;
            if (!checkBoxNewMovement.Checked)
            {
                buttonValidateMovement.Text = "Save";
                SaveExpense(true);
                if (_expsCurrent != null) LoadExpense(_expsCurrent);
                else LoadExpense(FindExpense());
            }
            else
            {
                buttonValidateMovement.Text = "Create";
                SaveExpense(false);
                LoadExpense(_expsNew);
            }
        }
        private void comboBoxMovement_SelectionChanged(object sender, EventArgs e)
        {
            LoadExpense(FindExpense());
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
