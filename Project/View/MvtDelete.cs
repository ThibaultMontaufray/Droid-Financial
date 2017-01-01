using Tools4Libraries;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Droid_financial
{
    public partial class MvtDelete : window_popup
    {
        #region Attribute
        private Movement _currentMovement;
        private Interface_fnc _intFnc;
        #endregion

        #region Properties
        public Movement Movement
        {
            get { return _currentMovement; }
        }
        #endregion

        #region Constructor
        public MvtDelete(Interface_fnc intfnc)
        {
            _intFnc = intfnc;
            _currentMovement = new Movement();
            InitializeComponent();
            LoadMovementList();
            comboBoxListMovements.SelectedItem = comboBoxListMovements.Items[0];
        }
        public MvtDelete(Interface_fnc intfnc, Movement mvt)
        {
            _intFnc = intfnc;
            _currentMovement = new Movement();
            InitializeComponent();
            LoadMovementList();
            Display(mvt);
        }
        public MvtDelete(Interface_fnc intfnc, int? mvtId)
        {
            _intFnc = intfnc;
            _currentMovement = new Movement();
            InitializeComponent();
            LoadMovementList();
            if (mvtId != null) Display(mvtId);
            else return;
        }
        #endregion

        #region Methods private
        private void LoadMovementList()
        {
            comboBoxListMovements.Items.Clear();
            foreach (Movement mvt in _intFnc.CurrentProject.Movements)
            {
                comboBoxListMovements.Items.Add(mvt.Gop.ToString() + " " + mvt.Name);
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
            foreach (Movement mvt in _intFnc.CurrentProject.Movements)
            {
                tmp = mvt.StrGop + " " + mvt.Name;
                if (tmp.Equals(comboBoxListMovements.Text))
                {
                    Display(mvt);
                    break;
                }
            }
        }
        private void Display(int? mvtId)
        {
            foreach (Movement mvt in _intFnc.CurrentProject.Movements)
            {
                if (mvtId.Equals(mvt.ID))
                {
                    Display(mvt);
                    break;
                }
            }
        }
        private void Display(string gop, string name)
        {
            foreach (Movement mvt in _intFnc.CurrentProject.Movements)
            {
                if (gop.Equals(mvt.StrGop) && name.Equals(mvt.Name))
                {
                    Display(mvt);
                    break;
                }
            }
        }
        private void Display(Movement mvt)
        {
            labelNameValue.Text = mvt.Name;
            labelGopValue.Text = mvt.StrGop;
            comboBoxListMovements.Text = mvt.StrGop + " " + mvt.Name;

            _currentMovement = mvt;
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
