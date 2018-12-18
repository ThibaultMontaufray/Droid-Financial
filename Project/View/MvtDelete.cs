using Tools4Libraries;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Droid.financial
{
    public partial class ExpsDelete : window_popup
    {
        #region Attribute
        private CRE _currentMovement;
        private InterfaceFinance _intFnc;
        #endregion

        #region Properties
        public CRE Movement
        {
            get { return _currentMovement; }
        }
        #endregion

        #region Constructor
        public ExpsDelete(InterfaceFinance intfnc)
        {
            _intFnc = intfnc;
            _currentMovement = new CRE();
            InitializeComponent();
            LoadMovementList();
            comboBoxListMovements.SelectedItem = comboBoxListMovements.Items[0];
        }
        public ExpsDelete(InterfaceFinance intfnc, CRE exps)
        {
            _intFnc = intfnc;
            _currentMovement = new CRE();
            InitializeComponent();
            LoadMovementList();
            Display(exps);
        }
        public ExpsDelete(InterfaceFinance intfnc, int? expsId)
        {
            _intFnc = intfnc;
            _currentMovement = new CRE();
            InitializeComponent();
            LoadMovementList();
            if (expsId != null) Display(expsId);
            else return;
        }
        #endregion

        #region Methods private
        private void LoadMovementList()
        {
            comboBoxListMovements.Items.Clear();
            foreach (CRE exps in _intFnc.CurrentActivity.ListCRE)
            {
                comboBoxListMovements.Items.Add(exps.Gop.ToString() + " " + exps.Name);
            }
        }
        private void DeleteIt()
        {
            _currentMovement.Name = labelNameValue.Text;
            _currentMovement.StrGop = labelGopValue.Text;
            this.Close();
        }
        private void LoadMovement()
        {
            string tmp = string.Empty;
            foreach (CRE exps in _intFnc.CurrentActivity.ListCRE)
            {
                tmp = exps.StrGop + " " + exps.Name;
                if (tmp.Equals(comboBoxListMovements.Text))
                {
                    Display(exps);
                    break;
                }
            }
        }
        private void Display(int? expsId)
        {
            foreach (CRE exps in _intFnc.CurrentActivity.ListCRE)
            {
                if (expsId.Equals(exps.Id))
                {
                    Display(exps);
                    break;
                }
            }
        }
        private void Display(string gop, string name)
        {
            foreach (CRE exps in _intFnc.CurrentActivity.ListCRE)
            {
                if (gop.Equals(exps.StrGop) && name.Equals(exps.Name))
                {
                    Display(exps);
                    break;
                }
            }
        }
        private void Display(CRE exps)
        {
            labelNameValue.Text = exps.Name;
            labelGopValue.Text = exps.StrGop;
            comboBoxListMovements.Text = exps.StrGop + " " + exps.Name;

            _currentMovement = exps;
        }
        #endregion

        #region Event
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void buttonApply_Click(object sender, EventArgs e)
        {
            DeleteIt();
        }
        private void comboBoxListMovements_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxListMovements.Text.Split(' ').Length > 1)
            {
                string gop = comboBoxListMovements.Text.Split(' ')[0];
                string name = comboBoxListMovements.Text.Split(' ')[1];
                Display(gop, name);
            }
        }
        #endregion

        private void labelNameValue_Click(object sender, EventArgs e)
        {

        }

        private void labelProjectList_Click(object sender, EventArgs e)
        {

        }

        private void labelName_Click(object sender, EventArgs e)
        {

        }

        private void labelFirstName_Click(object sender, EventArgs e)
        {

        }
    }
}
