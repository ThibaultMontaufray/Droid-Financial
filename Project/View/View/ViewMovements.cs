using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tools4Libraries;

namespace Droid_financial
{
    public partial class ViewMovements : UserControlCustom
    {
        #region Attribute
        private Interface_fnc _intFnc;
        #endregion

        #region Properties
        public Interface_fnc InterfaceFinancial
        {
            get { return _intFnc; }
            set { _intFnc = value; }
        }
        #endregion

        #region COnstructor
        public ViewMovements()
        {
            InitializeComponent();
        }
        public ViewMovements(Interface_fnc intFnc)
        {
            _intFnc = intFnc;
            InitializeComponent();
        }
        #endregion

        #region Methods public
        #endregion

        #region Methods private
        private void LoadMovement()
        {
            DataGridViewRow row;
            if (_intFnc != null && _intFnc.CurrentProject != null)
            {
                _dataGridViewMovement.Rows.Clear();
                foreach (Expense expense in _intFnc.CurrentProject.ListExpenses.Where(e => e.StartDate.Date >= DateTime.Now.Date.AddMonths(-1) && e.StartDate.Date <= DateTime.Now))
                {
                    _dataGridViewMovement.Rows.Add();
                    row = _dataGridViewMovement.Rows[_dataGridViewMovement.Rows.Count - 1];
                    row.Cells[ColumnExpsDescription.Index].Value = expense.Description;
                    row.Cells[ColumnExpsId.Index].Value = expense.Id;
                    row.Cells[ColumnExpsAmountOrg.Index].Value = expense.Amount;
                    row.Cells[ColumnExpsDel.Index].Value = Tools4Libraries.Resources.ResourceIconSet16Default.cross;
                    row.Cells[ColumnExpsEdit.Index].Value = Tools4Libraries.Resources.ResourceIconSet16Default.feed_edit;
                    row.Cells[ColumnExpsName.Index].Value = expense.Name;
                    row.Cells[ColumnExpsStartParticipation.Index].Value = expense.StartDate;
                    row.Cells[ColumnExpsEndParticipation.Index].Value = expense.EndDate;
                }
            }
        }
        #endregion

        #region Event
        #endregion
    }
}
