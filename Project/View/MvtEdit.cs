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

namespace Droid.financial
{
    public partial class ExpsEdit : window_popup
    {
        #region Attribute
        private InterfaceFinance _intFnc;
        private CRE _expsCurrent;
        private CRE _expsNew;
        private Regex _rexFloat = new Regex(@"^[0-9]*(?:\,[0-9]*)?$");
        private bool _billFullScreen = false;
        private Form _fullScreenForm;
        #endregion

        #region Properties
        public CRE Movement
        {
            get { return _expsCurrent; }
            set { _expsCurrent = value; }
        }
        #endregion

        #region Constructor
        public ExpsEdit(InterfaceFinance intFnc, int? expsId)
        {
            _intFnc = intFnc;
            InitializeComponent();
            LoadPrj(expsId);
            _expsNew = new CRE();
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
        public ExpsEdit(InterfaceFinance intFnc, string picPath)
        {
            _intFnc = intFnc;
            InitializeComponent();
            checkBoxNewMovement.Checked = true;
            textBoxBillPath.Text = picPath;
            _expsNew = new CRE();
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

            foreach (EntityFinancialDecorator usr in _intFnc.CurrentActivity.Entities)
	        {
                comboBoxWho.Items.Add((usr.GetName()).Trim());
                comboBoxParticipantList.Items.Add((usr.GetName()).Trim());
	        }
            foreach (CRE exps in _intFnc.CurrentActivity.ListCRE)
            {
                comboBoxMovement.Items.Add(exps.Name);
                if (expsId != null && exps.Id.Equals(expsId)) _expsCurrent = exps;
            }
            if (comboBoxMovement.Items.Count > 0) comboBoxMovement.SelectedItem = comboBoxMovement.Items[0];
            if (expsId == null)
            {
                _expsCurrent = new CRE();
                _expsNew = new CRE();
                checkBoxNewMovement.Checked = true;
                LoadExpense(_expsNew);
            }
            else LoadExpense(_expsCurrent);
            comboBoxMovement.Enabled = !checkBoxNewMovement.Checked;
        }
        private void LoadExpense(CRE exps)
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
                EntityFinancialDecorator userTmp;
                List<string> ls = new List<string>();
                foreach (string s in comboBoxParticipantList.Items) ls.Add(s) ;
                foreach (string userStr in ls)
                {
                    userTmp = _intFnc.CurrentActivity.Entities.Find(x => (x.GetName()).Trim().Equals(userStr.Trim()));
                    if (userTmp != null && exps.Movements.Where(p => p.UserId.Equals(userTmp.Id)).Count() > 0)
                    {
                        if (comboBoxParticipantList.Items.IndexOf(userStr.Trim()) != -1) comboBoxParticipantList.SetItemChecked(comboBoxParticipantList.Items.IndexOf(userStr.Trim()), true);
                    }
                }
                foreach (string s in comboBoxWho.Items) ls.Add(s);
                foreach (string userStr in ls)
                {
                    userTmp = _intFnc.CurrentActivity.Entities.Find(x => (x.GetName()).Trim().Equals(userStr.Trim()));
                    //if (userTmp != null && exps. UserId.Contains(userTmp.ID))
                    //{
                    //    if (comboBoxWho.Items.IndexOf(userStr.Trim()) != -1) comboBoxWho.SetItemChecked(comboBoxWho.Items.IndexOf(userStr.Trim()), true);
                    //}
                }
                switch (exps.Gop)
                {
                    case CRE.GOP.COMODITIES: radioButtonComodities.Checked = true; break;
                    case CRE.GOP.ACTIVITIES: radioButtonActivities.Checked = true; break;
                    case CRE.GOP.FOOD: radioButtonFood.Checked = true; break;
                    case CRE.GOP.OTHER: radioButtonOther.Checked = true; break;
                    case CRE.GOP.TRANSPORT: radioButtonTransport.Checked = true; break;
                    case CRE.GOP.CLOTHES: radioButtonClothe.Checked = true; break;
                    case CRE.GOP.LOGEMENT: radioButtonLogement.Checked = true; break;
                    case CRE.GOP.ABONMENT: radioButtonAbonmnent.Checked = true; break;
                    case CRE.GOP.LOANS: radioButtonLoan.Checked = true; break;
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
                            EntityFinancialDecorator u = _intFnc.CurrentActivity.GetEntityProfile(item.Trim());
                            if (u != null) _expsNew.Movements.Add(new Movement() { UserId = new List<string>() {u.Id}, Amount = 0, StartDate = DateTime.Now });
                        }

                    _expsNew.StartDate = dateTimePickerStartDate.Value;
                    _expsNew.EndDate = dateTimePickerEndDate.Value;

                    if (radioButtonActivities.Checked) _expsNew.Gop = CRE.GOP.ACTIVITIES;
                    else if (radioButtonComodities.Checked) _expsNew.Gop = CRE.GOP.COMODITIES;
                    else if (radioButtonFood.Checked) _expsNew.Gop = CRE.GOP.FOOD;
                    else if (radioButtonOther.Checked) _expsNew.Gop = CRE.GOP.OTHER;
                    else if (radioButtonTransport.Checked) _expsNew.Gop = CRE.GOP.TRANSPORT;
                    else if (radioButtonAbonmnent.Checked) _expsNew.Gop = CRE.GOP.ABONMENT;
                    else if (radioButtonLogement.Checked) _expsNew.Gop = CRE.GOP.LOGEMENT;
                    else if (radioButtonLoan.Checked) _expsNew.Gop = CRE.GOP.LOANS;
                    else if (radioButtonClothe.Checked) _expsNew.Gop = CRE.GOP.CLOTHES;
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
                            EntityFinancialDecorator u = _intFnc.CurrentActivity.GetEntityProfile(item.Trim());
                            if (u != null) _expsCurrent.Movements.Add(new Movement() { UserId = new List<string>() { u.Id }, Amount = 0, StartDate = DateTime.Now });
                        }
                    
                    if (radioButtonActivities.Checked) _expsCurrent.Gop = CRE.GOP.ACTIVITIES;
                    else if (radioButtonComodities.Checked) _expsCurrent.Gop = CRE.GOP.COMODITIES;
                    else if (radioButtonFood.Checked) _expsCurrent.Gop = CRE.GOP.FOOD;
                    else if (radioButtonOther.Checked) _expsCurrent.Gop = CRE.GOP.OTHER;
                    else if (radioButtonTransport.Checked) _expsCurrent.Gop = CRE.GOP.TRANSPORT;
                    else if (radioButtonAbonmnent.Checked) _expsCurrent.Gop = CRE.GOP.ABONMENT;
                    else if (radioButtonLogement.Checked) _expsCurrent.Gop = CRE.GOP.LOGEMENT;
                    else if (radioButtonLoan.Checked) _expsCurrent.Gop = CRE.GOP.LOANS;
                    else if (radioButtonClothe.Checked) _expsCurrent.Gop = CRE.GOP.CLOTHES;
                }
            }
        }
        private CRE FindExpense()
        {
            foreach (CRE exps in _intFnc.CurrentActivity.ListCRE)
            {
                if (textBoxMovementName.Text.Equals(exps.Name))
                {
                    return exps;
                }
            }
            if (_intFnc.CurrentActivity.ListCRE.Count > 0) return _intFnc.CurrentActivity.ListCRE[0];
            return null;
        }
        private void UpdateAmount(CRE exps)
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
