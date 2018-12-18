using Droid.People;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Tools4Libraries;

namespace Droid.financial.View
{
    public partial class ViewCompanies : UserControlCustom
    {
        #region Attributes
        public event EventHandler OnClosing;
        public event EventHandler OnEdit;
        public event EventHandler OnDelete;

        private InterfaceFinance _intFin;
        #endregion

        #region Properties
        #endregion

        #region Constructor
        public ViewCompanies(InterfaceFinance intFin)
        {
            _intFin = intFin;

            InitializeComponent();
            Init();
        }
        #endregion

        #region Methods public
        public void LoadData(List<EntityFinancialDecorator> companies)
        {
            dataGridViewComp.Rows.Clear();
            foreach (var comp in companies)
            {
                dataGridViewComp.Rows.Add();
                dataGridViewComp.Rows[dataGridViewComp.Rows.Count - 1].Tag = comp;
                dataGridViewComp.Rows[dataGridViewComp.Rows.Count - 1].Cells[ColumnName.Index].Value = comp.GetName();
                dataGridViewComp.Rows[dataGridViewComp.Rows.Count - 1].Cells[ColumnIcon.Index].Value = comp.Logo;
                dataGridViewComp.Rows[dataGridViewComp.Rows.Count - 1].Cells[ColumnAddress.Index].Value = comp.Address;
                dataGridViewComp.Rows[dataGridViewComp.Rows.Count - 1].Cells[ColumnDel.Index].Value = Tools4Libraries.Resources.ResourceIconSet16Default.cross;
                dataGridViewComp.Rows[dataGridViewComp.Rows.Count - 1].Cells[ColumnEdit.Index].Value = Tools4Libraries.Resources.ResourceIconSet16Default.document_editing;
            }
        }
        #endregion

        #region Methods private
        private void Init()
        {

        }
        private void Delete(EntityFinancialDecorator comp)
        {
            _intFin.CurrentEntity = comp;
            OnDelete(comp, null);
        }
        private void Edit(EntityFinancialDecorator comp)
        {
            _intFin.CurrentEntity = comp;
            OnEdit(comp, null);
        }
        #endregion

        #region Event
        private void dataGridViewComp_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == ColumnDel.Index)
            {
                Delete(dataGridViewComp.Rows[e.RowIndex].Tag as EntityFinancialDecorator);
            }
            else if (e.ColumnIndex == ColumnEdit.Index)
            {
                Edit(dataGridViewComp.Rows[e.RowIndex].Tag as EntityFinancialDecorator);
            }
        }
        private void buttonClose_Click(object sender, System.EventArgs e)
        {
            OnClosing?.Invoke(null, null);
        }
        #endregion
    }
}
