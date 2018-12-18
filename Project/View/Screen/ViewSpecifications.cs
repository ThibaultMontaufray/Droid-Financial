using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Tools4Libraries;

namespace Droid.financial.View
{
    public partial class ViewSpecifications : UserControlCustom
    {
        #region Attributes
        public event EventHandler OnClosing;
        public event EventHandler OnEdit;
        public event EventHandler OnDelete;
        #endregion

        #region Properties
        #endregion

        #region Constructor
        public ViewSpecifications()
        {
            InitializeComponent();
            Init();
        }
        #endregion

        #region Methods public
        public void LoadData(List<Specification> specifications)
        {
            dataGridViewSpec.Rows.Clear();
            foreach (var spec in specifications)
            {
                dataGridViewSpec.Rows.Add();
                dataGridViewSpec.Rows[dataGridViewSpec.Rows.Count - 1].Tag = spec;
                dataGridViewSpec.Rows[dataGridViewSpec.Rows.Count - 1].Cells[ColumnId.Index].Value = spec.Id;
                dataGridViewSpec.Rows[dataGridViewSpec.Rows.Count - 1].Cells[ColumnFrom.Index].Value = spec.From;
                dataGridViewSpec.Rows[dataGridViewSpec.Rows.Count - 1].Cells[ColumnTo.Index].Value = spec.To;
                dataGridViewSpec.Rows[dataGridViewSpec.Rows.Count - 1].Cells[ColumnMaxDay.Index].Value = spec.MaxDays;
                dataGridViewSpec.Rows[dataGridViewSpec.Rows.Count - 1].Cells[ColumnDel.Index].Value = Tools4Libraries.Resources.ResourceIconSet16Default.cross;
                dataGridViewSpec.Rows[dataGridViewSpec.Rows.Count - 1].Cells[ColumnEdit.Index].Value = Tools4Libraries.Resources.ResourceIconSet16Default.document_editing;
            }
        }
        #endregion

        #region Methods private
        private void Init()
        {

        }
        private void Delete(Specification comp)
        {
            OnDelete(comp, null);
        }
        private void Edit(Specification comp)
        {
            OnEdit(comp, null);
        }
        #endregion

        #region Event
        private void dataGridViewSpec_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == ColumnDel.Index)
            {
                Delete(dataGridViewSpec.Rows[e.RowIndex].Tag as Specification);
            }
            else if (e.ColumnIndex == ColumnEdit.Index)
            {
                Edit(dataGridViewSpec.Rows[e.RowIndex].Tag as Specification);
            }
        }
        private void buttonClose_Click(object sender, System.EventArgs e)
        {
            OnClosing?.Invoke(null, null);
        }
        #endregion
    }
}
