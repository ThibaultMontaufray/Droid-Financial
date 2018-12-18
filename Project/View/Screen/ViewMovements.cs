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

namespace Droid.financial
{
    public partial class ViewMovements : Tools4Libraries.UserControlCustom
    {
        #region Attribute
        private FinancialActivity _activity;
        #endregion

        #region Properties
        public FinancialActivity Activity
        {
            get { return _activity; }
            set { _activity = value; }
        }
        #endregion

        #region Constructor
        public ViewMovements()
        {
            InitializeComponent();
        }
        public ViewMovements(FinancialActivity activity)
        {
            _activity = activity;
            InitializeComponent();
        }
        #endregion

        #region Methods public
        public new void RefreshData()
        {
            LoadMovement();
        }
        #endregion

        #region Methods private
        private void LoadMovement()
        {
            DataGridViewRow row;
            this.SuspendLayout();
            _dataGridViewMovement.Rows.Clear();
            if (_activity != null && _activity != null)
            {
                foreach (CRE expense in _activity.ListCRE.Where(e => e.StartDate.Date >= DateTime.Now.Date.AddMonths(-1) && e.StartDate.Date <= DateTime.Now))
                {
                    _dataGridViewMovement.Rows.Add();
                    row = _dataGridViewMovement.Rows[_dataGridViewMovement.Rows.Count - 1];
                    row.Cells[ColumnExpsDescription.Index].Value = expense.Description;
                    row.Cells[ColumnExpsId.Index].Value = expense.Id;
                    row.Cells[ColumnExpsAmountOrg.Index].Value = expense.Amount;
                    row.Cells[ColumnExpsDel.Index].Value = Tools4Libraries.Resources.ResourceIconSet16Default.cross;
                    row.Cells[ColumnExpsEdit.Index].Value = Tools4Libraries.Resources.ResourceIconSet16Default.feed_edit;
                    row.Cells[ColumnExpsName.Index].Value = expense.Name;
                    row.Cells[ColumnGOP.Index].Value = expense.StrGop;
                    row.Cells[ColumnExpsStartParticipation.Index].Value = expense.StartDate;
                    row.Cells[ColumnExpsEndParticipation.Index].Value = expense.EndDate;
                    row.Height = 24;
                }
            }
            this.Invalidate();
            this.ResumeLayout();
        }
        #endregion

        #region Event
        #endregion
    }
}
