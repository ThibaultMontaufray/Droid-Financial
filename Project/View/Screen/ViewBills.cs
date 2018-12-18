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

namespace Droid.financial.View.Screen
{
    public partial class ViewBills : UserControlCustom
    {
        #region Attributes
        private InterfaceFinance _intFin;
        #endregion

        #region Properties
        public InterfaceFinance InterfaceFin
        {
            get { return _intFin; }
            set { _intFin = value; }
        }
        #endregion

        #region Constructor
        public ViewBills()
        {
            InitializeComponent();
            Init();
        }
        public ViewBills(InterfaceFinance intFin)
        {
            _intFin = intFin;
            InitializeComponent();
            Init();
        }
        #endregion

        #region Methods public.
        public override void RefreshData()
        {
            _dataGridViewBills.Rows.Clear();

            if (_intFin != null && _intFin.CurrentActivity.Bills?.Count > 0)
            {
                foreach (var item in _intFin.CurrentActivity.Bills)
                {
                    _dataGridViewBills.Rows.Add();
                    _dataGridViewBills.Rows[_dataGridViewBills.Rows.Count - 1].Tag = item;
                    _dataGridViewBills.Rows[_dataGridViewBills.Rows.Count - 1].Cells[ColumnId.Index].Value = item.Id;
                    _dataGridViewBills.Rows[_dataGridViewBills.Rows.Count - 1].Cells[ColumnName.Index].Value = item.Client;
                    _dataGridViewBills.Rows[_dataGridViewBills.Rows.Count - 1].Cells[ColumnCreateDate.Index].Value = item.CreateDate.ToShortDateString();
                    _dataGridViewBills.Rows[_dataGridViewBills.Rows.Count - 1].Cells[ColumnDueDate.Index].Value = item.LimitDate.ToShortDateString();
                    _dataGridViewBills.Rows[_dataGridViewBills.Rows.Count - 1].Cells[ColumnAmount.Index].Value = item.Amount;
                    _dataGridViewBills.Rows[_dataGridViewBills.Rows.Count - 1].Cells[ColumnPaid.Index].Value = item.PayDate == null;
                    _dataGridViewBills.Rows[_dataGridViewBills.Rows.Count - 1].Cells[ColumnDel.Index].Value = Tools4Libraries.Resources.ResourceIconSet16Default.cross;
                    _dataGridViewBills.Rows[_dataGridViewBills.Rows.Count - 1].Cells[ColumnInspect.Index].Value = Tools4Libraries.Resources.ResourceIconSet16Default.shape_square_edit;
                    _dataGridViewBills.Rows[_dataGridViewBills.Rows.Count - 1].Cells[ColumnPrint.Index].Value = Tools4Libraries.Resources.ResourceIconSet16Default.printer;
                }
            }
        }
        #endregion

        #region Methods private
        private void Init()
        {
            RefreshData();
        }
        #endregion

        #region Event
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            _intFin.GoAction("newbill");
        }
        private void _dataGridViewBills_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == ColumnDel.Index)
            {
                if (MessageBox.Show("Are you sure ?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                { 
                    _intFin.CurrentActivity.Bills.Remove((Bill)_dataGridViewBills.Rows[e.RowIndex].Tag);
                    _dataGridViewBills.Rows.RemoveAt(e.RowIndex);
                    _intFin.Save();
                }
            }
            else if (e.ColumnIndex == ColumnInspect.Index)
            {
                _intFin.CurrentActivity.CurrentBill = (Bill)_dataGridViewBills.Rows[e.RowIndex].Tag;
                _intFin.GoAction("editbill");
            }
            else if (e.ColumnIndex == ColumnPrint.Index)
            {
                _intFin.CurrentActivity.CurrentBill = (Bill)_dataGridViewBills.Rows[e.RowIndex].Tag;
                _intFin.GoAction("printbill");
            }
        }
        #endregion
    }
}
