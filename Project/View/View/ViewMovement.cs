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

namespace Droid_financial
{
    public partial class ViewMovement : UserControlCustom
    {
        #region Attribute
        private Interface_fnc _intFnc;
        private PanelGraph _panelGraph;
        private List<string> _lstGopName;
        private List<double> _lstGopValues;
        private DataGridViewCellStyle _cellTemplateAlignRight;
        private DataGridViewCellStyle _cellTemplateAlignCenter;

        private System.ComponentModel.IContainer components = null;
        public System.Windows.Forms.DataGridView _dataGridViewMovement;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnExpsId;
        private System.Windows.Forms.DataGridViewImageColumn ColumnExpsEdit;
        private System.Windows.Forms.DataGridViewImageColumn ColumnExpsDel;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnExpsName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnExpsAmountOriginal;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnExpsCurrencyOriginal;
        private System.Windows.Forms.DataGridViewImageColumn ColumnExpsMonaieOriginal;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnExpsAmountChanged;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnExpsCurrencyChanged;
        private System.Windows.Forms.DataGridViewImageColumn ColumnExpsMonaieChanged;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnExpsGOP;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnExpsUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnExpsDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnExpsStartParticipation;
        private DataGridViewTextBoxColumn ColumnExpsAmountOrg;
        private DataGridViewImageColumn ColumnExpsMonaieOrg;
        private DataGridViewTextBoxColumn ColumnExpsAmountChg;
        private DataGridViewImageColumn ColumnExpsMonaieChg;
        private DataGridViewTextBoxColumn ColumnExpsFamily;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnExpsEndParticipation;
        #endregion

        #region Properties
        public Interface_fnc InterfaceFinancial
        {
            get { return _intFnc; }
            set { _intFnc = value; }
        }
        #endregion

        #region Constructor
        public ViewMovement()
        {
            InitializeComponent();
            _lstGopName = new List<string>();
            _lstGopValues = new List<double>();
        }
        public ViewMovement(Interface_fnc intFnc)
        {
            _intFnc = intFnc;
            InitializeComponent();
            _lstGopName = new List<string>();
            _lstGopValues = new List<double>();
        }
        #endregion

        #region Methods public
        public override void Refresh()
        {
            int rowHeight = 24;
            _dataGridViewMovement.Height = _dataGridViewMovement.Rows.Count * rowHeight + _dataGridViewMovement.ColumnHeadersHeight;
        }
        public override void RefreshData()
        {
            LoadMovement();
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewMovement));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this._dataGridViewMovement = new System.Windows.Forms.DataGridView();
            this.ColumnExpsId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnExpsEdit = new System.Windows.Forms.DataGridViewImageColumn();
            this.ColumnExpsDel = new System.Windows.Forms.DataGridViewImageColumn();
            this.ColumnExpsName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnExpsAmountOrg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnExpsCurrencyOriginal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnExpsMonaieOrg = new System.Windows.Forms.DataGridViewImageColumn();
            this.ColumnExpsAmountChg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnExpsCurrencyChanged = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnExpsMonaieChg = new System.Windows.Forms.DataGridViewImageColumn();
            this.ColumnExpsFamily = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnExpsUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnExpsStartParticipation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnExpsEndParticipation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnExpsDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this._dataGridViewMovement)).BeginInit();
            this.SuspendLayout();
            // 
            // _dataGridViewMovement
            // 
            this._dataGridViewMovement.AllowUserToAddRows = false;
            this._dataGridViewMovement.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            this._dataGridViewMovement.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this._dataGridViewMovement.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dataGridViewMovement.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnExpsId,
            this.ColumnExpsEdit,
            this.ColumnExpsDel,
            this.ColumnExpsName,
            this.ColumnExpsAmountOrg,
            this.ColumnExpsCurrencyOriginal,
            this.ColumnExpsMonaieOrg,
            this.ColumnExpsAmountChg,
            this.ColumnExpsCurrencyChanged,
            this.ColumnExpsMonaieChg,
            this.ColumnExpsFamily,
            this.ColumnExpsUser,
            this.ColumnExpsStartParticipation,
            this.ColumnExpsEndParticipation,
            this.ColumnExpsDescription});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(85)))), ((int)(((byte)(85)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this._dataGridViewMovement.DefaultCellStyle = dataGridViewCellStyle2;
            this._dataGridViewMovement.Dock = System.Windows.Forms.DockStyle.Fill;
            this._dataGridViewMovement.Location = new System.Drawing.Point(0, 0);
            this._dataGridViewMovement.Name = "_dataGridViewMovement";
            this._dataGridViewMovement.RowHeadersVisible = false;
            this._dataGridViewMovement.Size = new System.Drawing.Size(715, 307);
            this._dataGridViewMovement.TabIndex = 1;
            // 
            // ColumnExpsId
            // 
            this.ColumnExpsId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColumnExpsId.HeaderText = "";
            this.ColumnExpsId.Name = "ColumnExpsId";
            this.ColumnExpsId.Visible = false;
            this.ColumnExpsId.Width = 5;
            // 
            // ColumnExpsEdit
            // 
            this.ColumnExpsEdit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.ColumnExpsEdit.HeaderText = "";
            this.ColumnExpsEdit.Image = ((System.Drawing.Image)(resources.GetObject("ColumnExpsEdit.Image")));
            this.ColumnExpsEdit.Name = "ColumnExpsEdit";
            this.ColumnExpsEdit.Width = 5;
            // 
            // ColumnExpsDel
            // 
            this.ColumnExpsDel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.ColumnExpsDel.HeaderText = "";
            this.ColumnExpsDel.Image = ((System.Drawing.Image)(resources.GetObject("ColumnExpsDel.Image")));
            this.ColumnExpsDel.Name = "ColumnExpsDel";
            this.ColumnExpsDel.Width = 5;
            // 
            // ColumnExpsName
            // 
            this.ColumnExpsName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.ColumnExpsName.HeaderText = "Name";
            this.ColumnExpsName.Name = "ColumnExpsName";
            this.ColumnExpsName.Width = 5;
            // 
            // ColumnExpsAmountOrg
            // 
            this.ColumnExpsAmountOrg.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ColumnExpsAmountOrg.DefaultCellStyle = dataGridViewCellStyle1;
            this.ColumnExpsAmountOrg.HeaderText = "Orginal amount";
            this.ColumnExpsAmountOrg.Name = "ColumnExpsAmountOrg";
            this.ColumnExpsAmountOrg.Width = 5;
            // 
            // ColumnExpsCurrencyOriginal
            // 
            this.ColumnExpsCurrencyOriginal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.ColumnExpsCurrencyOriginal.HeaderText = "";
            this.ColumnExpsCurrencyOriginal.Name = "ColumnExpsCurrencyOriginal";
            this.ColumnExpsCurrencyOriginal.Width = 5;
            // 
            // ColumnExpsMonaieOrg
            // 
            this.ColumnExpsMonaieOrg.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.ColumnExpsMonaieOrg.HeaderText = "";
            this.ColumnExpsMonaieOrg.Name = "ColumnExpsMonaieOrg";
            this.ColumnExpsMonaieOrg.Width = 5;
            // 
            // ColumnExpsAmountChg
            // 
            this.ColumnExpsAmountChg.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.ColumnExpsAmountChg.DefaultCellStyle = dataGridViewCellStyle1;
            this.ColumnExpsAmountChg.HeaderText = "Converted amount";
            this.ColumnExpsAmountChg.Name = "ColumnExpsAmountChg";
            this.ColumnExpsAmountChg.Width = 5;
            // 
            // ColumnExpsCurrencyChanged
            // 
            this.ColumnExpsCurrencyChanged.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.ColumnExpsCurrencyChanged.HeaderText = "";
            this.ColumnExpsCurrencyChanged.Name = "ColumnExpsCurrencyChanged";
            this.ColumnExpsCurrencyChanged.Width = 5;
            // 
            // ColumnExpsMonaieChg
            // 
            this.ColumnExpsMonaieChg.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.ColumnExpsMonaieChg.HeaderText = "";
            this.ColumnExpsMonaieChg.Name = "ColumnExpsMonaieChg";
            this.ColumnExpsMonaieChg.Width = 5;
            // 
            // ColumnExpsFamily
            // 
            this.ColumnExpsFamily.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.ColumnExpsFamily.HeaderText = "GOP";
            this.ColumnExpsFamily.Name = "ColumnExpsFamily";
            this.ColumnExpsFamily.Width = 5;
            // 
            // ColumnExpsUser
            // 
            this.ColumnExpsUser.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.ColumnExpsUser.HeaderText = "Buyer";
            this.ColumnExpsUser.Name = "ColumnExpsUser";
            this.ColumnExpsUser.Width = 5;
            // 
            // ColumnExpsStartParticipation
            // 
            this.ColumnExpsStartParticipation.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.ColumnExpsStartParticipation.HeaderText = "Start date";
            this.ColumnExpsStartParticipation.Name = "ColumnExpsStartParticipation";
            this.ColumnExpsStartParticipation.Width = 5;
            // 
            // ColumnExpsEndParticipation
            // 
            this.ColumnExpsEndParticipation.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.ColumnExpsEndParticipation.HeaderText = "End date";
            this.ColumnExpsEndParticipation.Name = "ColumnExpsEndParticipation";
            this.ColumnExpsEndParticipation.Width = 5;
            // 
            // ColumnExpsDescription
            // 
            this.ColumnExpsDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnExpsDescription.HeaderText = "Description";
            this.ColumnExpsDescription.Name = "ColumnExpsDescription";
            // 
            // ViewMovement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._dataGridViewMovement);
            this.Name = "ViewMovement";
            this.Size = new System.Drawing.Size(715, 307);
            ((System.ComponentModel.ISupportInitialize)(this._dataGridViewMovement)).EndInit();
            this.ResumeLayout(false);

        }
        private void EditExps(int rowIndex)
        {
            _intFnc.EditExps(int.Parse(_dataGridViewMovement.Rows[rowIndex].Cells[ColumnExpsId.Index].Value.ToString()));
        }
        private void DeleteExps(int rowIndex)
        {
            _intFnc.DeleteExps(int.Parse(_dataGridViewMovement.Rows[rowIndex].Cells[ColumnExpsId.Index].Value.ToString()));
        }
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
                    //row.Cells[ColumnExpsGOP.Index].Value = expense.Gop.ToString();
                    row.Cells[ColumnExpsAmountOrg.Index].Value = expense.Amount;
                    row.Cells[ColumnExpsDel.Index].Value = Tools4Libraries.Resources.ResourceIconSet16Default.cross;
                    row.Cells[ColumnExpsEdit.Index].Value = Tools4Libraries.Resources.ResourceIconSet16Default.feed_edit;
                    row.Cells[ColumnExpsName.Index].Value = expense.Name;
                    row.Cells[ColumnExpsStartParticipation.Index].Value = expense.StartDate;
                    row.Cells[ColumnExpsEndParticipation.Index].Value = expense.EndDate;
                }
            }
            this.Invalidate();
            //double sum = 0;
            //_dataGridViewMovement.Rows.Clear();
            //if (_intFnc != null)
            //{ 
            //    _dataGridViewMovement.Visible = _intFnc.CurrentProject?.ListExpenses.Count > 0 ? true : false;
            //    foreach (Expense exps in _intFnc.CurrentProject.ListExpenses)
            //    {
            //        if (!_lstGopName.Contains(exps.StrGop))
            //        {
            //            if (exps.Currency != _intFnc.CurrentProject.CurrencyUsed)
            //            {
            //                foreach (Change item in _intFnc.CurrentProject.Changes)
            //                {
            //                    if (item.Currency1.Equals(exps.Currency) && item.Currency2.Equals(_intFnc.CurrentProject.CurrencyUsed))
            //                    {
            //                        _lstGopValues.Add(exps.Convert(item, _intFnc.CurrentProject.CurrencyUsed));
            //                        _lstGopName.Add(exps.StrGop);
            //                        break;
            //                    }
            //                }
            //            }
            //            else
            //            {
            //                _lstGopValues.Add(exps.Amount);
            //                _lstGopName.Add(exps.StrGop);
            //            }
            //        }
            //        else
            //        {
            //            foreach (Change item in _intFnc.CurrentProject.Changes)
            //            {
            //                _lstGopValues[_lstGopName.IndexOf(exps.StrGop)] += exps.Convert(item, _intFnc.CurrentProject.CurrencyUsed);
            //            }
            //        }
            //        DGVAddExps(exps);
            //    }
            //    if (_lstGopValues != null)
            //    { 
            //        foreach (double val in _lstGopValues)
            //        {
            //            sum += val;
            //        }
            //        if (_panelGraph != null) { _panelGraph.SetValues(_lstGopName, _lstGopValues, sum); }
            //        if (!_intFnc.CurrentProject.HasMultipleCurrency)
            //        {
            //            ColumnExpsAmountChanged.Visible = false;
            //            ColumnExpsCurrencyChanged.Visible = false;
            //            ColumnExpsMonaieChanged.Visible = false;
            //        }
            //        else
            //        {
            //            ColumnExpsAmountChanged.Visible = true;
            //            ColumnExpsCurrencyChanged.Visible = true;
            //            ColumnExpsMonaieChanged.Visible = true;
            //        }
            //    }
            //}
        }
        private void DGVAddExps(Expense exps)
        {
            _dataGridViewMovement.Rows.Add();
            _dataGridViewMovement.Rows[_dataGridViewMovement.Rows.Count - 1].Cells[ColumnExpsId.Index].Value = exps.Id;
            _dataGridViewMovement.Rows[_dataGridViewMovement.Rows.Count - 1].Cells[ColumnExpsName.Index].Value = exps.Name;
            _dataGridViewMovement.Rows[_dataGridViewMovement.Rows.Count - 1].Cells[ColumnExpsStartParticipation.Index].Value = exps.StartDate.ToShortDateString();
            _dataGridViewMovement.Rows[_dataGridViewMovement.Rows.Count - 1].Cells[ColumnExpsEndParticipation.Index].Value = exps.EndDate.ToShortDateString();
            _dataGridViewMovement.Rows[_dataGridViewMovement.Rows.Count - 1].Cells[ColumnExpsAmountOriginal.Index].Value = String.Format("{0:0.00}", exps.Amount);
            _dataGridViewMovement.Rows[_dataGridViewMovement.Rows.Count - 1].Cells[ColumnExpsCurrencyOriginal.Index].Value = exps.Currency.ToString();
            _dataGridViewMovement.Rows[_dataGridViewMovement.Rows.Count - 1].Cells[ColumnExpsMonaieOriginal.Index].Value = GetCurrencyImage(exps.Currency);
            if (exps.Currency == _intFnc.CurrentProject.CurrencyUsed)
            {
                _dataGridViewMovement.Rows[_dataGridViewMovement.Rows.Count - 1].Cells[ColumnExpsAmountChanged.Index].Value = String.Format("{0:0.00}", exps.Amount);
                _dataGridViewMovement.Rows[_dataGridViewMovement.Rows.Count - 1].Cells[ColumnExpsCurrencyChanged.Index].Value = exps.Currency.ToString();
            }
            else
            {
                _dataGridViewMovement.Rows[_dataGridViewMovement.Rows.Count - 1].Cells[ColumnExpsAmountChanged.Index].Value = "???";
                foreach (Change chg in _intFnc.CurrentProject.Changes)
                {
                    if (chg.Currency1 == exps.Currency && chg.Currency2 == _intFnc.CurrentProject.CurrencyUsed)
                    {
                        _dataGridViewMovement.Rows[_dataGridViewMovement.Rows.Count - 1].Cells[ColumnExpsAmountChanged.Index].Value = String.Format("{0:0.00}", exps.Convert(chg, _intFnc.CurrentProject.CurrencyUsed));
                        _dataGridViewMovement.Rows[_dataGridViewMovement.Rows.Count - 1].Cells[ColumnExpsCurrencyChanged.Index].Value = _intFnc.CurrentProject.CurrencyUsed.ToString();
                        break;
                    }
                }
            }
            _dataGridViewMovement.Rows[_dataGridViewMovement.Rows.Count - 1].Cells[ColumnExpsMonaieChanged.Index].Value = GetCurrencyImage(_intFnc.CurrentProject.CurrencyUsed);
            _dataGridViewMovement.Rows[_dataGridViewMovement.Rows.Count - 1].Cells[ColumnExpsGOP.Index].Value = exps.Gop;
            //if (exps.UserId.Count > 0) _dataGridViewMovement.Rows[_dataGridViewMovement.Rows.Count - 1].Cells[ColumnExpsUser.Index].Value = GetUserLabel(exps.UserId[0]);
            _dataGridViewMovement.Rows[_dataGridViewMovement.Rows.Count - 1].Cells[ColumnExpsDescription.Index].Value = exps.Description;
        }
        private string GetUserLabel(string userId)
        {
            foreach (User user in _intFnc.CurrentProject.Users)
            {
                if (user.ID == userId)
                {
                    return user.Firstname + " " + user.Name;
                }
            }
            return string.Empty;
        }
        private Image GetCurrencyImage(string cur)
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
        private void _dataGridViewMovement_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (_dataGridViewMovement.Columns[e.ColumnIndex].Equals(ColumnExpsEdit))
            {
                EditExps(e.RowIndex);
            }
            else if (_dataGridViewMovement.Columns[e.ColumnIndex].Equals(ColumnExpsDel))
            {
                DeleteExps(e.RowIndex);
            }
        }
        #endregion
    }
}
