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
using Droid.People;

namespace Droid.financial
{
    public partial class ViewBillDetails : UserControlCustom
    {
        #region Attributes
        public event UserControlCustomEventHandler OnCancel;
        public event UserControlCustomEventHandler OnSave;

        private Bill _bill;
        private InterfaceFinance _intFin;
        #endregion

        #region Properties
        public InterfaceFinance InterfaceFinance
        {
            get { return _intFin; }
            set { _intFin = value; }
        }
        public Bill Bill
        {
            get { return _bill; }
            set
            {
                _bill = value;
                RefreshData();
            }
        }
        #endregion

        #region Constructor
        public ViewBillDetails()
        {
            InitializeComponent();
            Init();
        }
        public ViewBillDetails(InterfaceFinance intFin)
        {
            _intFin = intFin;
            InitializeComponent();
            Init();
        }
        #endregion

        #region Methods public
        public override void ChangeLanguage()
        {
            base.ChangeLanguage();
        }
        public override void RefreshData()
        {
            _dataGridViewProducts.Rows.Clear();
            if (_bill != null)
            {
                textBoxBank.Text = _bill.BankDetail;
                comboBoxOwner.SelectedItem = _bill.Owner;
                comboBoxClients.SelectedItem = _bill.Client;
                buttonColor.BackColor = _bill.Color;
                if (_bill.PayDate != DateTime.MinValue) { dateTimePickerPayDate.Value = _bill.PayDate; }
                if (_bill.CreateDate != DateTime.MinValue) { dateTimePickerCreation.Value = _bill.CreateDate; }
                if (_bill.LimitDate != DateTime.MinValue) { dateTimePickerLimit.Value = _bill.LimitDate; }

                foreach (var item in _bill.Products)
                {
                    _dataGridViewProducts.Rows.Add();
                    _dataGridViewProducts.Rows[_dataGridViewProducts.Rows.Count - 1].Tag = item;
                    _dataGridViewProducts.Rows[_dataGridViewProducts.Rows.Count - 1].Cells[ColumnId.Index].Value = item.Id;
                    _dataGridViewProducts.Rows[_dataGridViewProducts.Rows.Count - 1].Cells[ColumnDescription.Index].Value = item.Name + " - " + item.Description;
                    _dataGridViewProducts.Rows[_dataGridViewProducts.Rows.Count - 1].Cells[ColumnQuantity.Index].Value = item.Quantity;
                    _dataGridViewProducts.Rows[_dataGridViewProducts.Rows.Count - 1].Cells[ColumnAmount.Index].Value = item.Cost;
                    _dataGridViewProducts.Rows[_dataGridViewProducts.Rows.Count - 1].Cells[ColumnSubTotal.Index].Value = item.Quantity * item.Cost;
                    _dataGridViewProducts.Rows[_dataGridViewProducts.Rows.Count - 1].Cells[ColumnDel.Index].Value = Tools4Libraries.Resources.ResourceIconSet16Default.cross;
                }
            }
        }
        #endregion

        #region Methods private
        private void Init()
        {
            InitProduct();
            InitClients();

            RefreshData();
        }
        private void InitProduct()
        {
            comboBoxProducts.Items.Clear();
            if (_intFin != null && _intFin.CurrentActivity.Products?.Count > 0)
            {
                foreach (var item in _intFin.CurrentActivity.Products)
                {
                    comboBoxProducts.Items.Add(item);
                }
            }
        }
        private void InitClients()
        {
            comboBoxClients.Items.Clear();
            comboBoxOwner.Items.Clear();
            if (_intFin != null && _intFin.CurrentActivity.Entities?.Count > 0)
            {
                foreach (var item in _intFin.CurrentActivity.Entities)
                {
                    comboBoxClients.Items.Add(item);
                    comboBoxOwner.Items.Add(item);
                }
            }
        }
        private void Save()
        {
            _bill.Owner = (EntityFinancialDecorator)comboBoxOwner.SelectedItem;
            _bill.Client = (EntityFinancialDecorator)comboBoxClients.SelectedItem;
            _bill.CreateDate = dateTimePickerCreation.Value;
            _bill.LimitDate = dateTimePickerLimit.Value;
            _bill.PayDate = dateTimePickerPayDate.Value;
            _bill.BankDetail = textBoxBank.Text;
            _bill.Products.Clear();
            _bill.Color = buttonColor.BackColor;
            foreach (DataGridViewRow item in _dataGridViewProducts.Rows)
            {
                _bill.Products.Add((Product)item.Tag);
            }

            _intFin.CurrentActivity?.Bills.Add(_bill);
            OnSave?.Invoke(null);
        }
        #endregion

        #region Event
        private void buttonSave_Click(object sender, EventArgs e)
        {
            Save();
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            OnCancel?.Invoke(null);
        }
        private void buttonProductAdd_Click(object sender, EventArgs e)
        {
            _bill.Products.Add(((Product)comboBoxProducts.SelectedItem));
            RefreshData();
        }
        private void buttonProductNew_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not yet implemented", "Too bad !", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        private void buttonColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                buttonColor.BackColor = colorDialog1.Color;
            }
        }
        private void _dataGridViewProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == ColumnDel.Index)
            {
                if (MessageBox.Show("Are you sure ?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    _bill.Products.Remove((Product)_dataGridViewProducts.Rows[e.RowIndex].Tag);
                    _dataGridViewProducts.Rows.RemoveAt(e.RowIndex);
                }
            }
        }
        private void _dataGridViewProducts_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int val = 0;
                if (int.TryParse(_dataGridViewProducts.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString(), out val))
                { 
                    if (e.ColumnIndex == ColumnAmount.Index)
                    {
                        ((Product)_dataGridViewProducts.Rows[e.RowIndex].Tag).Cost = val;
                    }
                    if (e.ColumnIndex == ColumnQuantity.Index)
                    {
                        ((Product)_dataGridViewProducts.Rows[e.RowIndex].Tag).Quantity = val;
                    }
                    if (e.ColumnIndex == ColumnId.Index)
                    {
                        ((Product)_dataGridViewProducts.Rows[e.RowIndex].Tag).Id = val;
                    }
                    Product p = (Product)_dataGridViewProducts.Rows[e.RowIndex].Tag;
                    _dataGridViewProducts.Rows[_dataGridViewProducts.Rows.Count - 1].Cells[ColumnId.Index].Value = p.Id;
                    _dataGridViewProducts.Rows[_dataGridViewProducts.Rows.Count - 1].Cells[ColumnDescription.Index].Value = p.Name + " - " + p.Description;
                    _dataGridViewProducts.Rows[_dataGridViewProducts.Rows.Count - 1].Cells[ColumnQuantity.Index].Value = p.Quantity;
                    _dataGridViewProducts.Rows[_dataGridViewProducts.Rows.Count - 1].Cells[ColumnAmount.Index].Value = p.Cost;
                    _dataGridViewProducts.Rows[_dataGridViewProducts.Rows.Count - 1].Cells[ColumnSubTotal.Index].Value = p.Quantity * p.Cost;
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }
        #endregion
    }
}
