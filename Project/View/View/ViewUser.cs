//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Drawing;
//using System.Data;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;
//using Tools4Libraries;
//using Tools4Libraries.Resources;

//namespace Droid_financial
//{
//    public partial class ViewUser : UserControlCustom
//    {
//        #region Attribute
//        private Interface_fnc _intFnc;
//        //private List<UserPanel> _userPanels;
//        private int _indexX = 10;
//        private int _indexY = 10;
//        private DataGridViewCellStyle _cellTemplateAlignRight;
//        private DataGridViewCellStyle _cellTemplateAlignCenter;

//        private System.ComponentModel.IContainer components = null;
//        public System.Windows.Forms.DataGridView _dataGridViewUsers;
//        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnId;
//        private System.Windows.Forms.DataGridViewImageColumn ColumnAvatar;
//        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFirstname;
//        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnName;
//        private System.Windows.Forms.DataGridViewImageColumn ColumnStatus;
//        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnExpense;
//        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSolde;
//        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCurrency;
//        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnParticipation;
//        private System.Windows.Forms.DataGridViewImageColumn ColumnEdit;
//        private System.Windows.Forms.DataGridViewImageColumn ColumnDelete;
//        #endregion

//        #region Properties
//        #endregion

//        #region Constructor
//        public ViewUser()
//        {
//            InitializeComponent();
//        }
//        public ViewUser(Interface_fnc intFnc)
//        {
//            _intFnc = intFnc;
//            InitializeComponent();
//        }
//        #endregion

//        #region Methods public
//        public override void Refresh()
//        {
//            int rowHeight = 24;
//            _dataGridViewUsers.Height = _dataGridViewUsers.Rows.Count * rowHeight + _dataGridViewUsers.ColumnHeadersHeight;
//        }
//        #endregion

//        #region Methods protected
//        protected override void Dispose(bool disposing)
//        {
//            if (disposing && (components != null))
//            {
//                components.Dispose();
//            }
//            base.Dispose(disposing);
//        }
//        #endregion

//        #region Methods private
//        private void InitializeComponent()
//        {
//            components = new System.ComponentModel.Container();
//            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;

//            _cellTemplateAlignRight = new DataGridViewCellStyle();
//            _cellTemplateAlignRight.Alignment = DataGridViewContentAlignment.MiddleRight;

//            _cellTemplateAlignCenter = new DataGridViewCellStyle();
//            _cellTemplateAlignCenter.Alignment = DataGridViewContentAlignment.MiddleCenter;

//            this._dataGridViewUsers = new System.Windows.Forms.DataGridView();
//            this.ColumnAvatar = new System.Windows.Forms.DataGridViewImageColumn();
//            this.ColumnFirstname = new System.Windows.Forms.DataGridViewTextBoxColumn();
//            this.ColumnId = new System.Windows.Forms.DataGridViewTextBoxColumn();
//            this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
//            this.ColumnStatus = new System.Windows.Forms.DataGridViewImageColumn();
//            this.ColumnExpense = new System.Windows.Forms.DataGridViewTextBoxColumn();
//            this.ColumnSolde = new System.Windows.Forms.DataGridViewTextBoxColumn();
//            this.ColumnCurrency = new System.Windows.Forms.DataGridViewTextBoxColumn();
//            this.ColumnParticipation = new System.Windows.Forms.DataGridViewTextBoxColumn();
//            this.ColumnEdit = new System.Windows.Forms.DataGridViewImageColumn();
//            this.ColumnDelete = new System.Windows.Forms.DataGridViewImageColumn();
//            ((System.ComponentModel.ISupportInitialize)(this._dataGridViewUsers)).BeginInit();
//            // 
//            // dataGridViewUsers
//            // 
//            this._dataGridViewUsers.ScrollBars = ScrollBars.Both;
//            this._dataGridViewUsers.AllowUserToAddRows = false;
//            this._dataGridViewUsers.AllowUserToDeleteRows = false;
//            this._dataGridViewUsers.BackgroundColor = System.Drawing.Color.Black;
//            this._dataGridViewUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
//            this._dataGridViewUsers.ColumnHeadersVisible = true;
//            this._dataGridViewUsers.ScrollBars = ScrollBars.Both;
//            this._dataGridViewUsers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
//            this.ColumnId,
//            this.ColumnAvatar,
//            this.ColumnFirstname,
//            this.ColumnName,
//            this.ColumnStatus,
//            this.ColumnExpense,
//            this.ColumnSolde,
//            this.ColumnCurrency,
//            this.ColumnParticipation,
//            this.ColumnEdit,
//            this.ColumnDelete});
//            this._dataGridViewUsers.Dock = System.Windows.Forms.DockStyle.Top;
//            this._dataGridViewUsers.Location = new System.Drawing.Point(0, 0);
//            this._dataGridViewUsers.MultiSelect = false;
//            this._dataGridViewUsers.Name = "dataGridViewUsers";
//            this._dataGridViewUsers.RowHeadersVisible = false;
//            this._dataGridViewUsers.AutoSize = false;
//            this._dataGridViewUsers.TabIndex = 0;
//            this._dataGridViewUsers.BackgroundColor = Color.FromArgb(255, 85, 85, 85);
//            this._dataGridViewUsers.ForeColor = Color.Silver;
//            this._dataGridViewUsers.DefaultCellStyle.BackColor = Color.FromArgb(255, 85, 85, 85);
//            this._dataGridViewUsers.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
//            this._dataGridViewUsers.DefaultCellStyle.SelectionBackColor = this._dataGridViewUsers.DefaultCellStyle.BackColor;
//            this._dataGridViewUsers.CellClick += _dataGridViewUsers_CellClick;
//            // 
//            // ColumnId
//            // 
//            this.ColumnId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
//            this.ColumnId.HeaderText = string.Empty;
//            this.ColumnId.Name = "ColumnId";
//            this.ColumnId.Visible = false;
//            // 
//            // ColumnAvatar
//            // 
//            this.ColumnAvatar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
//            this.ColumnAvatar.HeaderText = string.Empty;
//            this.ColumnAvatar.Image = ((System.Drawing.Image)(ResourceIconSet16Default.user_gray));
//            this.ColumnAvatar.Name = "ColumnAvatar";
//            this.ColumnAvatar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
//            this.ColumnAvatar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
//            this.ColumnAvatar.Width = 5;
//            // 
//            // ColumnFirstname
//            // 
//            this.ColumnFirstname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
//            this.ColumnFirstname.HeaderText = "First name";
//            this.ColumnFirstname.Name = "ColumnFirstname";
//            this.ColumnFirstname.Width = 5;
//            // 
//            // ColumnName
//            // 
//            this.ColumnName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
//            this.ColumnName.HeaderText = "Name";
//            this.ColumnName.Name = "ColumnName";
//            // 
//            // ColumnStatus
//            // 
//            this.ColumnStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
//            this.ColumnStatus.HeaderText = string.Empty;
//            this.ColumnStatus.Image = ((System.Drawing.Image)(ResourceIconSet16Default.money_bag));
//            this.ColumnStatus.Name = "ColumnStatus";
//            this.ColumnStatus.Width = 5;
//            // 
//            // ColumnExpense
//            // 
//            this.ColumnExpense.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
//            this.ColumnExpense.HeaderText = "Exp.";
//            this.ColumnExpense.Name = "ColumnSolde";
//            this.ColumnExpense.DefaultCellStyle = _cellTemplateAlignRight;
//            this.ColumnExpense.Width = 5;
//            // 
//            // ColumnCurrency
//            // 
//            this.ColumnCurrency.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
//            this.ColumnCurrency.HeaderText = "Currency";
//            this.ColumnCurrency.Name = "ColumnCurrency";
//            this.ColumnCurrency.DefaultCellStyle = _cellTemplateAlignCenter;
//            this.ColumnCurrency.Width = 20;
//            // 
//            // ColumnSolde
//            // 
//            this.ColumnSolde.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
//            this.ColumnSolde.HeaderText = "Solde";
//            this.ColumnSolde.Name = "ColumnSolde";
//            this.ColumnSolde.DefaultCellStyle = _cellTemplateAlignRight;
//            this.ColumnSolde.Width = 5;
//            // 
//            // ColumnStartParticipation
//            // 
//            this.ColumnParticipation.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
//            this.ColumnParticipation.HeaderText = "Participation period";
//            this.ColumnParticipation.Name = "ColumnStartParticipation";
//            this.ColumnParticipation.Width = 20;
//            // 
//            // ColumnEdit
//            // 
//            this.ColumnEdit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
//            this.ColumnEdit.HeaderText = string.Empty;
//            this.ColumnEdit.Image = ((System.Drawing.Image)(ResourceIconSet16Default.user_edit));
//            this.ColumnEdit.Name = "ColumnEdit";
//            this.ColumnEdit.Width = 5;
//            // 
//            // ColumnDelete
//            // 
//            this.ColumnDelete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
//            this.ColumnDelete.HeaderText = string.Empty;
//            this.ColumnDelete.Image = ((System.Drawing.Image)(ResourceIconSet16Default.user_delete));
//            this.ColumnDelete.Name = "ColumnDelete";
//            this.ColumnDelete.Width = 5;
//            this.Controls.Add(_dataGridViewUsers);
//            ((System.ComponentModel.ISupportInitialize)(this._dataGridViewUsers)).EndInit();
//        }
//        private void EditUser(int rowIndex)
//        {
//            _intFnc.EditUser(int.Parse(_dataGridViewUsers.Rows[rowIndex].Cells[ColumnId.Index].Value.ToString()));
//        }
//        private void DeleteUser(int rowIndex)
//        {
//            _intFnc.DeleteUser(int.Parse(_dataGridViewUsers.Rows[rowIndex].Cells[ColumnId.Index].Value.ToString()));
//        }
//        private void LoadUsers()
//        {
//            _dataGridViewUsers.Rows.Clear();
//            _dataGridViewUsers.Visible = _intFnc.CurrentProject.Users.Count > 0 ? true : false;
//            foreach (User user in _intFnc.CurrentProject.Users)
//            {
//                _userPanels.Add(new UserPanel(user, _intFnc.Tsm.Gui));
//                DGVAddUser(user);
//            }
//        }
//        private void DGVAddUser(User user)
//        {
//            _dataGridViewUsers.Rows.Add();
//            _dataGridViewUsers.Rows[_dataGridViewUsers.Rows.Count - 1].Cells[ColumnId.Index].Value = user.ID;
//            _dataGridViewUsers.Rows[_dataGridViewUsers.Rows.Count - 1].Cells[ColumnAvatar.Index].Value = _intFnc.Tsm.Gui.imageListAvatars16.Images[user.AvatarIndex < _intFnc.Tsm.Gui.imageListAvatars16.Images.Count ? user.AvatarIndex : 0];
//            _dataGridViewUsers.Rows[_dataGridViewUsers.Rows.Count - 1].Cells[ColumnName.Index].Value = user.Name;
//            _dataGridViewUsers.Rows[_dataGridViewUsers.Rows.Count - 1].Cells[ColumnFirstname.Index].Value = user.Firstname;
//            if (user.Solde > (_intFnc.CurrentProject.Solde * 0.01)) _dataGridViewUsers.Rows[_dataGridViewUsers.Rows.Count - 1].Cells[ColumnStatus.Index].Value = ResourceIconSet16Default.tick;
//            else if (user.Solde < (_intFnc.CurrentProject.Solde * -0.01)) _dataGridViewUsers.Rows[_dataGridViewUsers.Rows.Count - 1].Cells[ColumnStatus.Index].Value = ResourceIconSet16Default.exclamation;
//            else _dataGridViewUsers.Rows[_dataGridViewUsers.Rows.Count - 1].Cells[ColumnStatus.Index].Value = ResourceIconSet16Default.error;
//            _dataGridViewUsers.Rows[_dataGridViewUsers.Rows.Count - 1].Cells[ColumnExpense.Index].Value = String.Format("{0:0.00}", user.SumExpances);
//            _dataGridViewUsers.Rows[_dataGridViewUsers.Rows.Count - 1].Cells[ColumnSolde.Index].Value = String.Format("{0:0.00}", user.Solde);
//            _dataGridViewUsers.Rows[_dataGridViewUsers.Rows.Count - 1].Cells[ColumnCurrency.Index].Value = _intFnc.CurrentProject.CurrencyUsed.ToString();

//            foreach (ICalendar pp in user.Calendars)
//            {
//                if ((_intFnc.CurrentProject.StartDate >= pp.BeginDate && _intFnc.CurrentProject.StartDate < pp.EndDate) ||
//                    (_intFnc.CurrentProject.EndDate > pp.BeginDate && _intFnc.CurrentProject.EndDate < pp.EndDate))
//                {
//                    _dataGridViewUsers.Rows[_dataGridViewUsers.Rows.Count - 1].Cells[ColumnParticipation.Index].Value = pp.BeginDate.ToShortDateString() + " - " + pp.EndDate.ToShortDateString();
//                }
//            }
//        }
//        private void DisplayUserPanelTile()
//        {
//            this.Controls.Clear();

//            int offsetX = 30;
//            int offsetY = 100;
//            this.Controls.Clear();
//            _indexY = this.Height / 2;
//            _indexX = this.Width / 2;
//            for (int i = 0; i < _userPanels.Count; i++)
//            {
//                //up.Show();
//                this.Controls.Add(_userPanels[i]);
//                _userPanels[i].Top = _indexY;
//                _userPanels[i].Left = _indexX - _userPanels[i].Width / 2;

//                if (i < _userPanels.Count / 3)
//                {
//                    _indexX += _userPanels[i].Width + offsetX;
//                    _indexY -= offsetY;
//                }
//                else if (i < _userPanels.Count / 2)
//                {
//                    _indexX -= _userPanels[i].Width + offsetX;
//                    _indexY -= offsetY;
//                }
//                else if (i < (_userPanels.Count * 2 / 3))
//                {
//                    _indexX -= _userPanels[i].Width + offsetX;
//                    _indexY += offsetY;
//                }
//                else
//                {
//                    _indexX += _userPanels[i].Width + offsetX;
//                    _indexY += offsetY;
//                }
//            }
//        }
//        #endregion

//        #region Event
//        private void _dataGridViewUsers_CellClick(object sender, DataGridViewCellEventArgs e)
//        {
//            if (_dataGridViewUsers.Columns[e.ColumnIndex].Equals(ColumnEdit))
//            {
//                EditUser(e.RowIndex);
//            }
//            else if (_dataGridViewUsers.Columns[e.ColumnIndex].Equals(ColumnDelete))
//            {
//                DeleteUser(e.RowIndex);
//            }
//        }
//        #endregion
//    }
//}
