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
using Tools4Libraries.Resources;

namespace Droid.financial
{
    public partial class ViewRefund : Tools4Libraries.UserControlCustom
    {
        #region Attribute
        private InterfaceFinance _intFnc;
        private DataGridViewCellStyle _cellTemplateAlignRight;
        private DataGridViewCellStyle _cellTemplateAlignCenter;

        private System.ComponentModel.IContainer components = null;
        public System.Windows.Forms.DataGridView _dataGridViewRefund;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnRfdUserGiver;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnRfdUserReceiver;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnRfdAmount;
        private System.Windows.Forms.DataGridViewImageColumn ColumnRfdCurrencyPict;
        private System.Windows.Forms.DataGridViewImageColumn ColumnRfdExchangeDone;
        private System.Windows.Forms.DataGridViewImageColumn ColumnRfdGift;
        private System.Windows.Forms.DataGridViewImageColumn ColumnRfdCanceled;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnRfdCurrency;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnRfdStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnRfdId;
        private System.Windows.Forms.DataGridViewImageColumn ColumnRfdAvatar;
        #endregion

        #region Properties
        #endregion

        #region Constructor
        public ViewRefund()
        {
            InitializeComponent();
        }
        public ViewRefund(InterfaceFinance intFnc)
        {
            _intFnc = intFnc;
            InitializeComponent();
        }
        #endregion

        #region Methods public
        public override void Refresh()
        {
            int rowHeight = 24;
            _dataGridViewRefund.Height = _dataGridViewRefund.Rows.Count * rowHeight + _dataGridViewRefund.ColumnHeadersHeight;
        }
        #endregion

        #region Methods protected
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        #endregion

        #region Methods private
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;

            _cellTemplateAlignRight = new DataGridViewCellStyle();
            _cellTemplateAlignRight.Alignment = DataGridViewContentAlignment.MiddleRight;

            _cellTemplateAlignCenter = new DataGridViewCellStyle();
            _cellTemplateAlignCenter.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this._dataGridViewRefund = new DataGridView();
            this.ColumnRfdAvatar = new DataGridViewImageColumn();
            this.ColumnRfdAmount = new DataGridViewTextBoxColumn();
            this.ColumnRfdUserGiver = new DataGridViewTextBoxColumn();
            this.ColumnRfdUserReceiver = new DataGridViewTextBoxColumn();
            this.ColumnRfdCurrency = new DataGridViewTextBoxColumn();
            this.ColumnRfdCurrencyPict = new DataGridViewImageColumn();
            this.ColumnRfdExchangeDone = new DataGridViewImageColumn();
            this.ColumnRfdGift = new DataGridViewImageColumn();
            this.ColumnRfdCanceled = new DataGridViewImageColumn();
            this.ColumnRfdStatus = new DataGridViewTextBoxColumn();
            this.ColumnRfdId = new DataGridViewTextBoxColumn();
            // 
            // dataGridViewRefund
            // 
            this._dataGridViewRefund.AllowUserToAddRows = false;
            this._dataGridViewRefund.AllowUserToDeleteRows = false;
            this._dataGridViewRefund.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dataGridViewRefund.ColumnHeadersVisible = true;
            this._dataGridViewRefund.ScrollBars = ScrollBars.Both;
            this._dataGridViewRefund.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnRfdId,
            this.ColumnRfdAmount,
            this.ColumnRfdCurrency,
            this.ColumnRfdCurrencyPict,
            this.ColumnRfdUserGiver,
            this.ColumnRfdAvatar,
            this.ColumnRfdUserReceiver,
            this.ColumnRfdExchangeDone,
            this.ColumnRfdGift,
            this.ColumnRfdCanceled,
            this.ColumnRfdStatus});
            this._dataGridViewRefund.Dock = System.Windows.Forms.DockStyle.Top;
            this._dataGridViewRefund.Location = new System.Drawing.Point(0, 0);
            this._dataGridViewRefund.MultiSelect = false;
            this._dataGridViewRefund.Name = "dataGridViewRefund";
            this._dataGridViewRefund.RowHeadersVisible = false;
            this._dataGridViewRefund.AutoSize = false;
            this._dataGridViewRefund.TabIndex = 0;
            this._dataGridViewRefund.BackgroundColor = Color.FromArgb(255, 85, 85, 85);
            this._dataGridViewRefund.ForeColor = Color.Silver;
            this._dataGridViewRefund.DefaultCellStyle.BackColor = Color.FromArgb(255, 85, 85, 85);
            this._dataGridViewRefund.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            this._dataGridViewRefund.DefaultCellStyle.SelectionBackColor = this._dataGridViewRefund.DefaultCellStyle.BackColor;
            this._dataGridViewRefund.CellClick += _dataGridViewRefund_CellClick;
            ((System.ComponentModel.ISupportInitialize)(this._dataGridViewRefund)).BeginInit();
            // 
            // ColumnRfdAvatar
            // 
            this.ColumnRfdAvatar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.ColumnRfdAvatar.HeaderText = string.Empty;
            this.ColumnRfdAvatar.Image = ((System.Drawing.Image)(ResourceIconSet16Default.user_gray));
            this.ColumnRfdAvatar.Name = "ColumnRfdAvatar";
            this.ColumnRfdAvatar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnRfdAvatar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnRfdAvatar.Width = 5;
            // 
            // ColumnRfdId
            // 
            this.ColumnRfdId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.ColumnRfdId.HeaderText = string.Empty;
            this.ColumnRfdId.Name = "ColumnRfdId";
            this.ColumnRfdId.Width = 5;
            this.ColumnRfdId.Visible = false;
            // 
            // ColumnRfdUserGiver
            // 
            this.ColumnRfdUserGiver.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnRfdUserGiver.HeaderText = "Giver";
            this.ColumnRfdUserGiver.Name = "ColumnRfdUserGiver";
            this.ColumnRfdUserGiver.Width = 5;
            // 
            // ColumnRfdUserReceiver
            // 
            this.ColumnRfdUserReceiver.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnRfdUserReceiver.HeaderText = "Receiver";
            this.ColumnRfdUserReceiver.Name = "ColumnRfdUserReceiver";
            this.ColumnRfdUserReceiver.Width = 5;
            // 
            // ColumnRfdAmount
            // 
            this.ColumnRfdAmount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.ColumnRfdAmount.HeaderText = "Amount";
            this.ColumnRfdAmount.Name = "ColumnRfdAmount";
            this.ColumnRfdAmount.Width = 5;
            this.ColumnRfdAmount.DefaultCellStyle = _cellTemplateAlignRight;
            // 
            // ColumnRfdCurrency
            // 
            this.ColumnRfdCurrency.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.ColumnRfdCurrency.HeaderText = string.Empty;
            this.ColumnRfdCurrency.Name = "ColumnRfdCurrency";
            this.ColumnRfdCurrency.Width = 5;
            this.ColumnRfdCurrency.ToolTipText = "Used currency";
            // 
            // ColumnRfdCurrencyPict
            // 
            this.ColumnRfdCurrencyPict.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.ColumnRfdCurrencyPict.HeaderText = string.Empty;
            this.ColumnRfdCurrencyPict.Name = "ColumnRfdCurrencyPict";
            this.ColumnRfdCurrencyPict.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnRfdCurrencyPict.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnRfdCurrencyPict.Width = 5;
            // 
            // ColumnRfdStatus
            // 
            this.ColumnRfdStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.ColumnRfdStatus.HeaderText = "Status";
            this.ColumnRfdStatus.Name = "ColumnRfdStatus";
            this.ColumnRfdStatus.Width = 5;
            // 
            // ColumnRfdExchangeDone
            // 
            this.ColumnRfdExchangeDone.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.ColumnRfdExchangeDone.HeaderText = string.Empty;
            this.ColumnRfdExchangeDone.Name = "ColumnRfdExchangeDone";
            this.ColumnRfdExchangeDone.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnRfdExchangeDone.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnRfdExchangeDone.Width = 5;
            // 
            // ColumnRfdGift
            // 
            this.ColumnRfdGift.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.ColumnRfdGift.HeaderText = string.Empty;
            this.ColumnRfdGift.Name = "ColumnRfdGift";
            this.ColumnRfdGift.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnRfdGift.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnRfdGift.Width = 5;
            // 
            // ColumnRfdCanceled
            // 
            this.ColumnRfdCanceled.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.ColumnRfdCanceled.HeaderText = string.Empty;
            this.ColumnRfdCanceled.Name = "ColumnRfdCanceled";
            this.ColumnRfdCanceled.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnRfdCanceled.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnRfdCanceled.Width = 5;
            this.Controls.Add(_dataGridViewRefund);
            ((System.ComponentModel.ISupportInitialize)(this._dataGridViewRefund)).EndInit();
        }
        private void RefundGift(int rowIndex)
        {
            _dataGridViewRefund.Rows[rowIndex].Cells[_dataGridViewRefund.Columns.IndexOf(ColumnRfdStatus)].Value = "Gift";
            Refund.GetRefund(_intFnc.CurrentActivity.Refunds, _dataGridViewRefund.Rows[rowIndex].Cells[ColumnRfdId.Index].Value.ToString()).CurrentStatus = Refund.Status.GIFT;
        }
        private void RefundCompleteExchange(int rowIndex)
        {
            _dataGridViewRefund.Rows[rowIndex].Cells[_dataGridViewRefund.Columns.IndexOf(ColumnRfdStatus)].Value = "Completed";
            Refund.GetRefund(_intFnc.CurrentActivity.Refunds, _dataGridViewRefund.Rows[rowIndex].Cells[ColumnRfdId.Index].Value.ToString()).CurrentStatus = Refund.Status.REFUNDED;
        }
        private void RefundCancel(int rowIndex)
        {
            _dataGridViewRefund.Rows[rowIndex].Cells[_dataGridViewRefund.Columns.IndexOf(ColumnRfdStatus)].Value = "Canceled";
            Refund.GetRefund(_intFnc.CurrentActivity.Refunds, _dataGridViewRefund.Rows[rowIndex].Cells[ColumnRfdId.Index].Value.ToString()).CurrentStatus = Refund.Status.CANCELED;
        }
        private void LoadRefund()
        {
            _dataGridViewRefund.Rows.Clear();
            _dataGridViewRefund.Visible = _intFnc.CurrentActivity.Refunds.Count > 0 ? true : false;
            foreach (Refund r in _intFnc.CurrentActivity.Refunds)
            {
                DGVAddRefund(r);
            }
        }
        private void DGVAddRefund(Refund r)
        {
            _dataGridViewRefund.Rows.Add();
            using (var row = _dataGridViewRefund.Rows[_dataGridViewRefund.Rows.Count - 1])
            {
                row.Cells[ColumnRfdAmount.Index].Value = String.Format("{0:0.00}", r.Amount);
                row.Cells[ColumnRfdCurrency.Index].Value = _intFnc.CurrentActivity.CurrencyUsed;
                row.Cells[ColumnRfdCurrencyPict.Index].Value = GetCurrencyImage(_intFnc.CurrentActivity.CurrencyUsed);
                row.Cells[ColumnRfdUserGiver.Index].Value = EntityFinancialDecorator.GetUser(_intFnc.CurrentActivity.Entities, r.Giver).GetName();
                row.Cells[ColumnRfdAvatar.Index].Value = ResourceIconSet16Default.error;
                row.Cells[ColumnRfdUserReceiver.Index].Value = EntityFinancialDecorator.GetUser(_intFnc.CurrentActivity.Entities, r.Receiver).GetName();
                row.Cells[ColumnRfdExchangeDone.Index].Value = ResourceIconSet16Default.coins_in_hand;
                row.Cells[ColumnRfdExchangeDone.Index].ToolTipText = "This exchange is completed.";
                row.Cells[ColumnRfdGift.Index].Value = ResourceIconSet16Default.gift_add;
                row.Cells[ColumnRfdGift.Index].ToolTipText = "No refund, the receiver make a gift.";
                row.Cells[ColumnRfdCanceled.Index].Value = ResourceIconSet16Default.door_out;
                row.Cells[ColumnRfdCanceled.Index].ToolTipText = "This exchange will never be done. \r\nAmount will be paid by other participants.";
                row.Cells[ColumnRfdStatus.Index].Value = r.CurrentStatus;
                row.Cells[ColumnRfdId.Index].Value = r.ID;
            }
        }
        private string GetUserLabel(string userId)
        {
            foreach (EntityFinancialDecorator user in _intFnc.CurrentActivity.Entities)
            {
                if (user.Id.Equals(userId))
                {
                    return user.GetName();
                }
            }
            return string.Empty;
        }
        private System.Drawing.Image GetCurrencyImage(string cur)
        {
            if (cur.ToUpper().Equals("EUR")) return ResourceIconSet16Default.money_euro;
            else if (cur.ToUpper().Equals("USD") || cur.ToUpper().Equals("AUD")) return ResourceIconSet16Default.money_dollar;
            else if (cur.ToUpper().Equals("GBP")) return ResourceIconSet16Default.money_pound;
            else if (cur.ToUpper().Equals("JPY")) return ResourceIconSet16Default.coins;
            else if (cur.ToUpper().Equals("INR")) return ResourceIconSet16Default.coins;
            else return ResourceIconSet16Default.coins;
        }
        #endregion

        #region Event
        private void _dataGridViewRefund_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (_dataGridViewRefund.Columns[e.ColumnIndex].Equals(ColumnRfdCanceled))
            {
                RefundCancel(e.RowIndex);
                _intFnc.CurrentActivity.Balance();
                Refresh();
            }
            else if (_dataGridViewRefund.Columns[e.ColumnIndex].Equals(ColumnRfdGift))
            {
                RefundGift(e.RowIndex);
                _intFnc.CurrentActivity.Balance();
                Refresh();
            }
            else if (_dataGridViewRefund.Columns[e.ColumnIndex].Equals(ColumnRfdExchangeDone))
            {
                RefundCompleteExchange(e.RowIndex);
                _intFnc.CurrentActivity.Balance();
                Refresh();
            }
        }
        #endregion
    }
}
