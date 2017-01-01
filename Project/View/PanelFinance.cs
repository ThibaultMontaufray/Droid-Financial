using Tools4Libraries;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Tools4Libraries.Resources;

namespace Droid_financial
{
    public class PanelFinance : Panel
    {
        #region Attribute
        private Interface_fnc _intFnc;
        private List<UserPanel> _userPanels;
        private int _indexX = 10;
        private int _indexY = 10;
        private PanelGraph _panelGraph;
        private List<string> _lstGopName;
        private List<float> _lstGopValues;
        private List<window_tile_postit> _lstWinTile;
        private int _indexLeft = 0;
        private int _indexTop = 0;
        private int _indexHeight = 300;
        private const int MARGE = 5;
        private DataGridViewCellStyle _cellTemplateAlignRight;
        private DataGridViewCellStyle _cellTemplateAlignCenter;
        #region Design
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnId;
        private System.Windows.Forms.DataGridViewImageColumn ColumnAvatar;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFirstname;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnName;
        private System.Windows.Forms.DataGridViewImageColumn ColumnStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnExpense;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSolde;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCurrency;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnParticipation;
        private System.Windows.Forms.DataGridViewImageColumn ColumnEdit;
        private System.Windows.Forms.DataGridViewImageColumn ColumnDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMvtId;
        private System.Windows.Forms.DataGridViewImageColumn ColumnMvtEdit;
        private System.Windows.Forms.DataGridViewImageColumn ColumnMvtDel;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMvtName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMvtAmountOriginal;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMvtCurrencyOriginal;
        private System.Windows.Forms.DataGridViewImageColumn ColumnMvtMonaieOriginal;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMvtAmountChanged;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMvtCurrencyChanged;
        private System.Windows.Forms.DataGridViewImageColumn ColumnMvtMonaieChanged;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMvtGOP;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMvtUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMvtDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMvtStartParticipation;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMvtEndParticipation;
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
        public System.Windows.Forms.DataGridView _dataGridViewUsers;
        public System.Windows.Forms.DataGridView _dataGridViewMovement;
        public System.Windows.Forms.DataGridView _dataGridViewRefund;
        #endregion
        #endregion

        #region Properties
        public PanelGraph PanelGraphics
        {
            get { return _panelGraph; }
            set { _panelGraph = value; }
        }
        #endregion

        #region Constructor
        public PanelFinance(Interface_fnc intFnc)
        {
            _intFnc = intFnc;
            InitializeComponent();
        }
        #endregion

        #region Method public
        public void InitializeComponent()
        {
            this.SuspendLayout();
            _userPanels = new List<UserPanel>();
            _lstGopName = new List<string>();
            _lstGopValues = new List<float>();
            _lstWinTile = new List<window_tile_postit>();
            BuildDGV();
            BuildPanel();
            this.ResumeLayout(false);
        }
        public override void Refresh()
        {
            //base.Refresh();
            foreach (UserPanel up in _userPanels)
            {
                up.UpdateUser();
            }
            LoadProjectDetail();
            if (_intFnc.ViewTable) DisplayUserPanelTable();
            else DisplayUserPanelTile();

            _indexTop = 0;
            _indexLeft = 0;
            BuildWinTiles();

            int rowHeight = 24;
            _dataGridViewMovement.Height = _dataGridViewMovement.Rows.Count * rowHeight + _dataGridViewMovement.ColumnHeadersHeight;
            _dataGridViewUsers.Height = _dataGridViewUsers.Rows.Count * rowHeight + _dataGridViewUsers.ColumnHeadersHeight;
            _dataGridViewRefund.Height = _dataGridViewRefund.Rows.Count * rowHeight + _dataGridViewRefund.ColumnHeadersHeight;
        }
        public void SetGraphMode(PanelGraph.GRAPHMODE mode)
        {
            _panelGraph.GraphMode = mode;
        }
        #endregion

        #region Methods private
        private void CleanAll()
        {
            _userPanels.Clear();
            _dataGridViewMovement.Rows.Clear();
            _dataGridViewUsers.Rows.Clear();
            _dataGridViewRefund.Rows.Clear();
            _lstGopValues.Clear();
            _lstGopName.Clear();
        }

        private void BuildPanel()
        {
            //this.Width = 650;
            //this.Height = 650;
            this.Dock = DockStyle.Fill;
            if (_intFnc.CurrentProject != null)
            {
                LoadProjectDetail();
                
                if (_intFnc.ViewTable) DisplayUserPanelTable();
                else DisplayUserPanelTile();

                this.SizeChanged += PanelFinance_Resize;
                this.BackgroundImage = _intFnc.Tsm.Gui.BackgroundImage;
                this.BackgroundImageLayout = _intFnc.Tsm.Gui.BackgroundImageLayout;
                this.ResumeLayout();
            }
            BuildWinTiles();
        }
        private void BuildWinTiles()
        {
            this.Controls.Clear();
            _lstWinTile.Clear();
            if (_intFnc.Tsm._detail_presentation.Text.StartsWith("Disable")) _lstWinTile.Add(BuildWinTilesMenu());
            if (_intFnc.Tsm._detail_gop_rate.Text.StartsWith("Disable")) _lstWinTile.Add(BuildWinTilesGOP());
            if (_intFnc.Tsm._detail_mvt_list.Text.StartsWith("Disable")) _lstWinTile.Add(BuildWinTilesMovements());
            if (_intFnc.Tsm._detail_user_list.Text.StartsWith("Disable")) _lstWinTile.Add(BuildWinTilesUsers());
            if (_intFnc.Tsm._detail_reconciliation.Text.StartsWith("Disable")) _lstWinTile.Add(BuildWinTilesReconciliation());
            foreach (window_tile_postit wt in _lstWinTile)
            {
                DisplayWinTile(wt);
            }
        }
        private window_tile_postit BuildWinTilesMenu()
        {
            Label labelDesc = new Label();
            labelDesc.Text = "Welcome to financial module.";
            labelDesc.ForeColor = Color.Black;
            labelDesc.BackColor = Color.Transparent;
            labelDesc.Width = 250;
            labelDesc.Top = 5;
            labelDesc.Left = 5;

            window_tile_postit winPanelMenu = new window_tile_postit();
            winPanelMenu.Visible = false;
            winPanelMenu.Controls.Add(labelDesc);
            winPanelMenu.Text = "Menu";
            winPanelMenu.Width = 250;
            winPanelMenu.Height = _indexHeight;
            winPanelMenu.panelMiddle.Controls.Add(labelDesc);
            winPanelMenu.panelMiddle.AutoScroll = true;
            this.Controls.Add(winPanelMenu);
            return winPanelMenu;
        }
        private window_tile_postit BuildWinTilesUsers()
        {
            window_tile_postit winPanelUsers = new window_tile_postit();
            winPanelUsers.Visible = false;
            winPanelUsers.BodyControls.Add(_dataGridViewUsers);
            winPanelUsers.Text = "Users";
            winPanelUsers.Width = 600;
            winPanelUsers.Height = _indexHeight;
            winPanelUsers.panelMiddle.AutoScroll = true;
            this.Controls.Add(winPanelUsers);
            return winPanelUsers;
        }
        private window_tile_postit BuildWinTilesMovements()
        {
            window_tile_postit winPanelMvts = new window_tile_postit();
            winPanelMvts.Visible = false;
            winPanelMvts.BodyControls.Add(_dataGridViewMovement);
            winPanelMvts.Text = "Movements";
            winPanelMvts.Width = 700;
            winPanelMvts.Height = _indexHeight;
            winPanelMvts.panelMiddle.AutoScroll = true;
            this.Controls.Add(winPanelMvts);
            return winPanelMvts;
        }
        private window_tile_postit BuildWinTilesReconciliation()
        {
            window_tile_postit winPanelRefunds = new window_tile_postit();
            winPanelRefunds.Visible = false;
            winPanelRefunds.BodyControls.Add(_dataGridViewRefund);
            winPanelRefunds.Text = "Balance users loans";
            winPanelRefunds.Width = 500;
            winPanelRefunds.Height = _indexHeight;
            winPanelRefunds.panelMiddle.AutoScroll = true;
            this.Controls.Add(winPanelRefunds);
            return winPanelRefunds;
        }
        private window_tile_postit BuildWinTilesGOP()
        {
            window_tile_postit winPanelGraphs = new window_tile_postit();
            winPanelGraphs.Visible = false;
            winPanelGraphs.BodyControls.Add(PanelGraphics);
            winPanelGraphs.Text = "Graphics";
            winPanelGraphs.Width = 480;
            winPanelGraphs.Height = _indexHeight;
            winPanelGraphs.panelMiddle.AutoScroll = true;
            this.Controls.Add(winPanelGraphs);
            return winPanelGraphs;
        }
        private void BuildDGV()
        {
            _cellTemplateAlignRight = new DataGridViewCellStyle();
            _cellTemplateAlignRight.Alignment = DataGridViewContentAlignment.MiddleRight;

            _cellTemplateAlignCenter = new DataGridViewCellStyle();
            _cellTemplateAlignCenter.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this._dataGridViewUsers = new System.Windows.Forms.DataGridView();
            this._dataGridViewUsers.ScrollBars = ScrollBars.Both;
            this.ColumnAvatar = new System.Windows.Forms.DataGridViewImageColumn();
            this.ColumnFirstname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStatus = new System.Windows.Forms.DataGridViewImageColumn();
            this.ColumnExpense = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSolde = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCurrency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnParticipation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnEdit = new System.Windows.Forms.DataGridViewImageColumn();
            this.ColumnDelete = new System.Windows.Forms.DataGridViewImageColumn();
            this._dataGridViewMovement = new System.Windows.Forms.DataGridView();
            this.ColumnMvtEdit = new System.Windows.Forms.DataGridViewImageColumn();
            this.ColumnMvtDel = new System.Windows.Forms.DataGridViewImageColumn();
            this.ColumnMvtName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMvtId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMvtAmountOriginal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMvtCurrencyOriginal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMvtMonaieOriginal = new System.Windows.Forms.DataGridViewImageColumn();
            this.ColumnMvtAmountChanged = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMvtCurrencyChanged = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMvtStartParticipation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMvtEndParticipation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMvtMonaieChanged = new System.Windows.Forms.DataGridViewImageColumn();
            this.ColumnMvtGOP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMvtUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMvtDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this._dataGridViewUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._dataGridViewMovement)).BeginInit();
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
            this._panelGraph = new PanelGraph();

            BuildDGVRefund();
            BuildDGVUser();
            BuildDGVMovement();

            //
            // panelGraph
            //
            this._panelGraph.Dock = DockStyle.Fill;
            this._panelGraph.BackColor = Color.Transparent;

            this.AutoScroll = true;
            ((System.ComponentModel.ISupportInitialize)(this._dataGridViewUsers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._dataGridViewMovement)).EndInit();
        }
        private void BuildDGVRefund()
        {
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
        }
        private void BuildDGVUser()
        {
            // 
            // dataGridViewUsers
            // 
            this._dataGridViewUsers.AllowUserToAddRows = false;
            this._dataGridViewUsers.AllowUserToDeleteRows = false;
            this._dataGridViewUsers.BackgroundColor = System.Drawing.Color.Black;
            this._dataGridViewUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dataGridViewUsers.ColumnHeadersVisible = true;
            this._dataGridViewUsers.ScrollBars = ScrollBars.Both;
            this._dataGridViewUsers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnId,
            this.ColumnAvatar,
            this.ColumnFirstname,
            this.ColumnName,
            this.ColumnStatus,
            this.ColumnExpense,
            this.ColumnSolde,
            this.ColumnCurrency,
            this.ColumnParticipation,
            this.ColumnEdit,
            this.ColumnDelete});
            this._dataGridViewUsers.Dock = System.Windows.Forms.DockStyle.Top;
            this._dataGridViewUsers.Location = new System.Drawing.Point(0, 0);
            this._dataGridViewUsers.MultiSelect = false;
            this._dataGridViewUsers.Name = "dataGridViewUsers";
            this._dataGridViewUsers.RowHeadersVisible = false;
            this._dataGridViewUsers.AutoSize = false;
            this._dataGridViewUsers.TabIndex = 0;
            this._dataGridViewUsers.BackgroundColor = Color.FromArgb(255, 85, 85, 85);
            this._dataGridViewUsers.ForeColor = Color.Silver;
            this._dataGridViewUsers.DefaultCellStyle.BackColor = Color.FromArgb(255, 85, 85, 85);
            this._dataGridViewUsers.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            this._dataGridViewUsers.DefaultCellStyle.SelectionBackColor = this._dataGridViewUsers.DefaultCellStyle.BackColor;
            this._dataGridViewUsers.CellClick += _dataGridViewUsers_CellClick;
            // 
            // ColumnId
            // 
            this.ColumnId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColumnId.HeaderText = string.Empty;
            this.ColumnId.Name = "ColumnId";
            this.ColumnId.Visible = false;
            // 
            // ColumnAvatar
            // 
            this.ColumnAvatar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.ColumnAvatar.HeaderText = string.Empty;
            this.ColumnAvatar.Image = ((System.Drawing.Image)(ResourceIconSet16Default.user_gray));
            this.ColumnAvatar.Name = "ColumnAvatar";
            this.ColumnAvatar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnAvatar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnAvatar.Width = 5;
            // 
            // ColumnFirstname
            // 
            this.ColumnFirstname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColumnFirstname.HeaderText = "First name";
            this.ColumnFirstname.Name = "ColumnFirstname";
            this.ColumnFirstname.Width = 5;
            // 
            // ColumnName
            // 
            this.ColumnName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnName.HeaderText = "Name";
            this.ColumnName.Name = "ColumnName";
            // 
            // ColumnStatus
            // 
            this.ColumnStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.ColumnStatus.HeaderText = string.Empty;
            this.ColumnStatus.Image = ((System.Drawing.Image)(ResourceIconSet16Default.money_bag));
            this.ColumnStatus.Name = "ColumnStatus";
            this.ColumnStatus.Width = 5;
            // 
            // ColumnExpense
            // 
            this.ColumnExpense.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColumnExpense.HeaderText = "Exp.";
            this.ColumnExpense.Name = "ColumnSolde";
            this.ColumnExpense.DefaultCellStyle = _cellTemplateAlignRight;
            this.ColumnExpense.Width = 5;
            // 
            // ColumnCurrency
            // 
            this.ColumnCurrency.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColumnCurrency.HeaderText = "Currency";
            this.ColumnCurrency.Name = "ColumnCurrency";
            this.ColumnCurrency.DefaultCellStyle = _cellTemplateAlignCenter;
            this.ColumnCurrency.Width = 20;
            // 
            // ColumnSolde
            // 
            this.ColumnSolde.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColumnSolde.HeaderText = "Solde";
            this.ColumnSolde.Name = "ColumnSolde";
            this.ColumnSolde.DefaultCellStyle = _cellTemplateAlignRight;
            this.ColumnSolde.Width = 5;
            // 
            // ColumnStartParticipation
            // 
            this.ColumnParticipation.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.ColumnParticipation.HeaderText = "Participation period";
            this.ColumnParticipation.Name = "ColumnStartParticipation";
            this.ColumnParticipation.Width = 20;
            // 
            // ColumnEdit
            // 
            this.ColumnEdit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.ColumnEdit.HeaderText = string.Empty;
            this.ColumnEdit.Image = ((System.Drawing.Image)(ResourceIconSet16Default.user_edit));
            this.ColumnEdit.Name = "ColumnEdit";
            this.ColumnEdit.Width = 5;
            // 
            // ColumnDelete
            // 
            this.ColumnDelete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.ColumnDelete.HeaderText = string.Empty;
            this.ColumnDelete.Image = ((System.Drawing.Image)(ResourceIconSet16Default.user_delete));
            this.ColumnDelete.Name = "ColumnDelete";
            this.ColumnDelete.Width = 5;            
        }
        private void BuildDGVMovement()
        {
            // 
            // dataGridViewMovement
            // 
            this._dataGridViewMovement.AllowUserToAddRows = false;
            this._dataGridViewMovement.BackgroundColor = System.Drawing.Color.Black;
            this._dataGridViewMovement.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dataGridViewMovement.ColumnHeadersVisible = true;
            this._dataGridViewMovement.ScrollBars = ScrollBars.Both;
            this._dataGridViewMovement.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnMvtId,
            this.ColumnMvtEdit,
            this.ColumnMvtDel,
            this.ColumnMvtName,
            this.ColumnMvtAmountOriginal,
            this.ColumnMvtCurrencyOriginal,
            this.ColumnMvtMonaieOriginal,
            this.ColumnMvtAmountChanged,
            this.ColumnMvtCurrencyChanged,
            this.ColumnMvtMonaieChanged,
            this.ColumnMvtGOP,
            this.ColumnMvtUser,
            this.ColumnMvtStartParticipation,
            this.ColumnMvtEndParticipation,
            this.ColumnMvtDescription});
            this._dataGridViewMovement.AutoSize = false;
            this._dataGridViewMovement.Dock = System.Windows.Forms.DockStyle.Top;
            this._dataGridViewMovement.Location = new System.Drawing.Point(0, 0);
            this._dataGridViewMovement.Name = "dataGridViewMovement";
            this._dataGridViewMovement.RowHeadersVisible = false;
            this._dataGridViewMovement.Size = new System.Drawing.Size(305, 317);
            this._dataGridViewMovement.TabIndex = 1;
            this._dataGridViewMovement.BackgroundColor = Color.FromArgb(255, 85, 85, 85);
            this._dataGridViewMovement.ForeColor = Color.Silver;
            this._dataGridViewMovement.DefaultCellStyle.BackColor = Color.FromArgb(255, 85, 85, 85);
            this._dataGridViewMovement.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            this._dataGridViewMovement.DefaultCellStyle.SelectionBackColor = this._dataGridViewMovement.DefaultCellStyle.BackColor;
            this._dataGridViewMovement.CellClick += _dataGridViewMovement_CellClick;
            // 
            // ColumnMvtId
            // 
            this.ColumnMvtId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColumnMvtId.HeaderText = string.Empty;
            this.ColumnMvtId.Name = "ColumnMvtId";
            this.ColumnMvtId.Width = 5;
            this.ColumnMvtId.Visible = false;
            // 
            // ColumnMvtEdit
            // 
            this.ColumnMvtEdit.HeaderText = string.Empty;
            this.ColumnMvtEdit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            //this.ColumnMvtEdit.Image = ((System.Drawing.Image)(resources.GetObject("ColumnMvtEdit.Image")));
            this.ColumnMvtEdit.Image = ((System.Drawing.Image)(ResourceIconSet16Default.table_edit));
            this.ColumnMvtEdit.Name = "ColumnMvtEdit";
            // 
            // ColumnMvtDel
            // 
            this.ColumnMvtDel.HeaderText = string.Empty;
            this.ColumnMvtDel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            //this.ColumnMvtDel.Image = ((System.Drawing.Image)(resources.GetObject("ColumnMvtDel.Image")));
            this.ColumnMvtDel.Image = ((System.Drawing.Image)(ResourceIconSet16Default.table_delete));
            this.ColumnMvtDel.Name = "ColumnMvtDel";
            // 
            // ColumnMvtName
            // 
            this.ColumnMvtName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.ColumnMvtName.HeaderText = "Name";
            this.ColumnMvtName.Name = "ColumnMvtName";
            this.ColumnMvtName.Width = 5;
            // 
            // ColumnMvtAmountOrg
            // 
            this.ColumnMvtAmountOriginal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.ColumnMvtAmountOriginal.HeaderText = "Orginal amount";
            this.ColumnMvtAmountOriginal.Name = "ColumnMvtAmountOrg";
            this.ColumnMvtAmountOriginal.DefaultCellStyle = _cellTemplateAlignRight;
            this.ColumnMvtAmountOriginal.Width = 5;
            // 
            // ColumnMvtCurrencyOrg
            // 
            this.ColumnMvtCurrencyOriginal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.ColumnMvtCurrencyOriginal.HeaderText = string.Empty;
            this.ColumnMvtCurrencyOriginal.Name = "ColumnMvtCurrencyOriginal";
            this.ColumnMvtCurrencyOriginal.Width = 5;
            // 
            // ColumnMvtMonaieOrg
            // 
            this.ColumnMvtMonaieOriginal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.ColumnMvtMonaieOriginal.HeaderText = string.Empty;
            this.ColumnMvtMonaieOriginal.Name = "ColumnMvtMonaieOrg";
            this.ColumnMvtMonaieOriginal.Width = 5;
            // 
            // ColumnMvtAmountChg
            // 
            this.ColumnMvtAmountChanged.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.ColumnMvtAmountChanged.HeaderText = "Converted amount";
            this.ColumnMvtAmountChanged.Name = "ColumnMvtAmountChg";
            this.ColumnMvtAmountChanged.DefaultCellStyle = _cellTemplateAlignRight;
            this.ColumnMvtAmountChanged.Width = 5;
            // 
            // ColumnMvtCurrencyChanged
            // 
            this.ColumnMvtCurrencyChanged.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.ColumnMvtCurrencyChanged.HeaderText = string.Empty;
            this.ColumnMvtCurrencyChanged.Name = "ColumnMvtCurrencyChanged";
            this.ColumnMvtCurrencyChanged.Width = 5;
            // 
            // ColumnMvtStartParticipation
            // 
            this.ColumnMvtStartParticipation.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.ColumnMvtStartParticipation.HeaderText = "Start date";
            this.ColumnMvtStartParticipation.Name = "ColumnMvtStartParticipation";
            this.ColumnMvtStartParticipation.Width = 20;
            // 
            // ColumnMvtEndParticipation
            // 
            this.ColumnMvtEndParticipation.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.ColumnMvtEndParticipation.HeaderText = "End date";
            this.ColumnMvtEndParticipation.Name = "ColumnMvtEndParticipation";
            this.ColumnMvtEndParticipation.Width = 20;
            // 
            // ColumnMvtMonaieChg
            // 
            this.ColumnMvtMonaieChanged.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.ColumnMvtMonaieChanged.HeaderText = string.Empty;
            this.ColumnMvtMonaieChanged.Name = "ColumnMvtMonaieChg";
            this.ColumnMvtMonaieChanged.Width = 5;
            // 
            // ColumnMvtFamily
            // 
            this.ColumnMvtGOP.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.ColumnMvtGOP.HeaderText = "GOP";
            this.ColumnMvtGOP.Name = "ColumnMvtFamily";
            this.ColumnMvtGOP.Width = 5;
            // 
            // ColumnMvtFamily
            // 
            this.ColumnMvtUser.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.ColumnMvtUser.HeaderText = "Buyer";
            this.ColumnMvtUser.Name = "ColumnMvtUser";
            this.ColumnMvtUser.Width = 50;
            // 
            // ColumnMvtDescription
            // 
            this.ColumnMvtDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnMvtDescription.HeaderText = "Description";
            this.ColumnMvtDescription.Name = "ColumnMvtDescription";
        }

        private void LoadProjectDetail()
        {
            if (_intFnc.CurrentProject != null)
            {
                this.SuspendLayout();
                CleanAll();
                LoadUsers();
                LoadMovement();
                LoadRefund();
                this.ResumeLayout();
            }
        }
        private void LoadUsers()
        {
            _dataGridViewUsers.Visible = _intFnc.CurrentProject.Users.Count > 0 ? true : false;
            foreach (User user in _intFnc.CurrentProject.Users)
            {
                _userPanels.Add(new UserPanel(user, _intFnc.Tsm.Gui));
                DGVAddUser(user);
            }
        }
        private void LoadMovement()
        {
            float sum = 0;
            _dataGridViewMovement.Visible = _intFnc.CurrentProject.Movements.Count > 0 ? true : false;
            foreach (Movement mvt in _intFnc.CurrentProject.Movements)
            {
                if (!_lstGopName.Contains(mvt.StrGop))
                {
                    if (mvt.Currency != _intFnc.CurrentProject.CurrencyUsed)
                    {
                        foreach (Change item in _intFnc.CurrentProject.Changes)
                        {
                            if (item.Currency1.Equals(mvt.Currency) && item.Currency2.Equals(_intFnc.CurrentProject.CurrencyUsed))
                            {
                                _lstGopValues.Add(mvt.Convert(item, _intFnc.CurrentProject.CurrencyUsed));
                                _lstGopName.Add(mvt.StrGop);
                                break;
                            }
                        }
                    }
                    else
                    {
                        _lstGopValues.Add(mvt.Amount);
                        _lstGopName.Add(mvt.StrGop);
                    }
                }
                else
                {
                    foreach (Change item in _intFnc.CurrentProject.Changes)
                    {
                        _lstGopValues[_lstGopName.IndexOf(mvt.StrGop)] += mvt.Convert(item, _intFnc.CurrentProject.CurrencyUsed);
                    }
                }
                DGVAddMvt(mvt);
            }
            foreach (float val in _lstGopValues)
            {
                sum += val;
            }
            _panelGraph.SetValues(_lstGopName, _lstGopValues, sum);
            if (!_intFnc.CurrentProject.HasMultipleCurrency)
            {
                ColumnMvtAmountChanged.Visible = false;
                ColumnMvtCurrencyChanged.Visible = false;
                ColumnMvtMonaieChanged.Visible = false;
            }
            else
            {
                ColumnMvtAmountChanged.Visible = true;
                ColumnMvtCurrencyChanged.Visible = true;
                ColumnMvtMonaieChanged.Visible = true;
            }
        }
        private void LoadRefund()
        {
            _dataGridViewRefund.Visible = _intFnc.CurrentProject.Refunds.Count > 0 ? true : false;
            foreach (Refund r in _intFnc.CurrentProject.Refunds)
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
                row.Cells[ColumnRfdCurrency.Index].Value = _intFnc.CurrentProject.CurrencyUsed;
                row.Cells[ColumnRfdCurrencyPict.Index].Value = GetCurrencyImage(_intFnc.CurrentProject.CurrencyUsed);
                row.Cells[ColumnRfdUserGiver.Index].Value = User.GetUser(_intFnc.CurrentProject.Users, r.Giver).Firstname + " " + User.GetUser(_intFnc.CurrentProject.Users, r.Giver).Name;
                row.Cells[ColumnRfdAvatar.Index].Value = ResourceIconSet16Default.error;
                row.Cells[ColumnRfdUserReceiver.Index].Value = User.GetUser(_intFnc.CurrentProject.Users, r.Receiver).Firstname + " " + User.GetUser(_intFnc.CurrentProject.Users, r.Receiver).Name;
                row.Cells[ColumnRfdExchangeDone.Index].Value = ResourceIconSet16Default.coins_in_hand;
                row.Cells[ColumnRfdExchangeDone.Index].ToolTipText = "This exchange is completed.";
                row.Cells[ColumnRfdGift.Index].Value = ResourceIconSet16Default.gift_add;
                row.Cells[ColumnRfdGift.Index].ToolTipText = "No refund, the receiver make a gift.";
                row.Cells[ColumnRfdCanceled.Index].Value = ResourceIconSet16Default.exit;
                row.Cells[ColumnRfdCanceled.Index].ToolTipText = "This exchange will never be done. \r\nAmount will be paid by other participants.";
                row.Cells[ColumnRfdStatus.Index].Value = r.CurrentStatus;
                row.Cells[ColumnRfdId.Index].Value = r.ID;
            }
        }
        private void DGVAddMvt(Movement mvt)
        {
            _dataGridViewMovement.Rows.Add();
            _dataGridViewMovement.Rows[_dataGridViewMovement.Rows.Count - 1].Cells[ColumnMvtId.Index].Value = mvt.ID;
            _dataGridViewMovement.Rows[_dataGridViewMovement.Rows.Count - 1].Cells[ColumnMvtName.Index].Value = mvt.Name;
            _dataGridViewMovement.Rows[_dataGridViewMovement.Rows.Count - 1].Cells[ColumnMvtStartParticipation.Index].Value = mvt.StartDate.ToShortDateString();
            _dataGridViewMovement.Rows[_dataGridViewMovement.Rows.Count - 1].Cells[ColumnMvtEndParticipation.Index].Value = mvt.EndDate.ToShortDateString();
            _dataGridViewMovement.Rows[_dataGridViewMovement.Rows.Count - 1].Cells[ColumnMvtAmountOriginal.Index].Value = String.Format("{0:0.00}", mvt.Amount);
            _dataGridViewMovement.Rows[_dataGridViewMovement.Rows.Count - 1].Cells[ColumnMvtCurrencyOriginal.Index].Value = mvt.Currency.ToString();
            _dataGridViewMovement.Rows[_dataGridViewMovement.Rows.Count - 1].Cells[ColumnMvtMonaieOriginal.Index].Value = GetCurrencyImage(mvt.Currency);
            if (mvt.Currency == _intFnc.CurrentProject.CurrencyUsed)
            {
                _dataGridViewMovement.Rows[_dataGridViewMovement.Rows.Count - 1].Cells[ColumnMvtAmountChanged.Index].Value = String.Format("{0:0.00}", mvt.Amount);
                _dataGridViewMovement.Rows[_dataGridViewMovement.Rows.Count - 1].Cells[ColumnMvtCurrencyChanged.Index].Value = mvt.Currency.ToString();
            }
            else
            {
                _dataGridViewMovement.Rows[_dataGridViewMovement.Rows.Count - 1].Cells[ColumnMvtAmountChanged.Index].Value = "???";
                foreach (Change chg in _intFnc.CurrentProject.Changes)
                {
                    if (chg.Currency1 == mvt.Currency && chg.Currency2 == _intFnc.CurrentProject.CurrencyUsed)
                    {
                        _dataGridViewMovement.Rows[_dataGridViewMovement.Rows.Count - 1].Cells[ColumnMvtAmountChanged.Index].Value = String.Format("{0:0.00}", mvt.Convert(chg, _intFnc.CurrentProject.CurrencyUsed));
                        _dataGridViewMovement.Rows[_dataGridViewMovement.Rows.Count - 1].Cells[ColumnMvtCurrencyChanged.Index].Value = _intFnc.CurrentProject.CurrencyUsed.ToString();
                        break;
                    }
                }
            }
            _dataGridViewMovement.Rows[_dataGridViewMovement.Rows.Count - 1].Cells[ColumnMvtMonaieChanged.Index].Value = GetCurrencyImage(_intFnc.CurrentProject.CurrencyUsed);
            _dataGridViewMovement.Rows[_dataGridViewMovement.Rows.Count - 1].Cells[ColumnMvtGOP.Index].Value = mvt.Gop;
            if (mvt.UserId.Count > 0) _dataGridViewMovement.Rows[_dataGridViewMovement.Rows.Count - 1].Cells[ColumnMvtUser.Index].Value = GetUserLabel(mvt.UserId[0]);
            _dataGridViewMovement.Rows[_dataGridViewMovement.Rows.Count - 1].Cells[ColumnMvtDescription.Index].Value = mvt.Description;
        }
        private void DGVAddUser(User user)
        {
            _dataGridViewUsers.Rows.Add();
            _dataGridViewUsers.Rows[_dataGridViewUsers.Rows.Count - 1].Cells[ColumnId.Index].Value = user.ID;
            _dataGridViewUsers.Rows[_dataGridViewUsers.Rows.Count - 1].Cells[ColumnAvatar.Index].Value = _intFnc.Tsm.Gui.imageListAvatars16.Images[user.AvatarIndex < _intFnc.Tsm.Gui.imageListAvatars16.Images.Count ? user.AvatarIndex : 0];
            _dataGridViewUsers.Rows[_dataGridViewUsers.Rows.Count - 1].Cells[ColumnName.Index].Value = user.Name;
            _dataGridViewUsers.Rows[_dataGridViewUsers.Rows.Count - 1].Cells[ColumnFirstname.Index].Value = user.Firstname;
            if (user.Solde > (_intFnc.CurrentProject.Solde * 0.01)) _dataGridViewUsers.Rows[_dataGridViewUsers.Rows.Count - 1].Cells[ColumnStatus.Index].Value = ResourceIconSet16Default.tick;
            else if (user.Solde < (_intFnc.CurrentProject.Solde * -0.01)) _dataGridViewUsers.Rows[_dataGridViewUsers.Rows.Count - 1].Cells[ColumnStatus.Index].Value = ResourceIconSet16Default.exclamation;
            else _dataGridViewUsers.Rows[_dataGridViewUsers.Rows.Count - 1].Cells[ColumnStatus.Index].Value = ResourceIconSet16Default.error;
            _dataGridViewUsers.Rows[_dataGridViewUsers.Rows.Count - 1].Cells[ColumnExpense.Index].Value = String.Format("{0:0.00}", user.SumExpances);
            _dataGridViewUsers.Rows[_dataGridViewUsers.Rows.Count - 1].Cells[ColumnSolde.Index].Value = String.Format("{0:0.00}", user.Solde);
            _dataGridViewUsers.Rows[_dataGridViewUsers.Rows.Count - 1].Cells[ColumnCurrency.Index].Value = _intFnc.CurrentProject.CurrencyUsed.ToString();

            foreach (ICalendar pp in user.Calendars)
            {
                if ((_intFnc.CurrentProject.StartDate >= pp.BeginDate && _intFnc.CurrentProject.StartDate < pp.EndDate) ||
                    (_intFnc.CurrentProject.EndDate > pp.BeginDate && _intFnc.CurrentProject.EndDate < pp.EndDate))
                {
                    _dataGridViewUsers.Rows[_dataGridViewUsers.Rows.Count - 1].Cells[ColumnParticipation.Index].Value = pp.BeginDate.ToShortDateString() + " - " + pp.EndDate.ToShortDateString();
                }
            }
        }
        
        private void DisplayWinTile(window_tile_postit wt)
        {
            if ((_indexLeft + wt.Width + 5) >= this.Width)
            {
                _indexTop += _indexHeight + 5;
                _indexLeft = 0;
            }
            wt.Top = _indexTop;
            wt.Left = _indexLeft + 5;
            wt.Visible = true;
            wt.Invalidate();

            _indexLeft += wt.Width;
        }
        private void DisplayUserPanelTable()
        {
            this.Controls.Clear();
            foreach (window_tile_postit wt in _lstWinTile)
            {
                this.Controls.Add(wt);
            }
        }
        private void DisplayUserPanelTile()
        {
            this.Controls.Clear();

            int offsetX = 30;
            int offsetY = 100;
            this.Controls.Clear();
            _indexY = this.Height /2;
            _indexX = this.Width / 2;
            for (int i = 0; i < _userPanels.Count; i++)
            {
                //up.Show();
                this.Controls.Add(_userPanels[i]);
                _userPanels[i].Top = _indexY;
                _userPanels[i].Left = _indexX - _userPanels[i].Width / 2;

                if (i < _userPanels.Count / 3)
                {
                    _indexX += _userPanels[i].Width + offsetX;
                    _indexY -= offsetY;
                }
                else if (i < _userPanels.Count / 2)
                {
                    _indexX -= _userPanels[i].Width + offsetX;
                    _indexY -= offsetY;
                }
                else if (i < (_userPanels.Count * 2 / 3))
                {
                    _indexX -= _userPanels[i].Width + offsetX;
                    _indexY += offsetY;
                }
                else
                {
                    _indexX += _userPanels[i].Width + offsetX;
                    _indexY += offsetY;
                }
            }
        }

        private Image GetCurrencyImage(string cur)
        {
            if (cur.ToUpper().Equals("EUR")) return ResourceIconSet16Default.Currency_Euro;
            else if (cur.ToUpper().Equals("USD") || cur.ToUpper().Equals("AUD")) return ResourceIconSet16Default.Currency_Dollar;
            else if (cur.ToUpper().Equals("GBP")) return ResourceIconSet16Default.Currency_Pound;
            else if (cur.ToUpper().Equals("JPY")) return ResourceIconSet16Default.coins;
            else if (cur.ToUpper().Equals("INR")) return ResourceIconSet16Default.coins;
            else return ResourceIconSet16Default.coins;
        }
        private string GetUserLabel(int userId)
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

        private void EditUser(int rowIndex)
        {
            _intFnc.EditUser(int.Parse(_dataGridViewUsers.Rows[rowIndex].Cells[ColumnId.Index].Value.ToString()));
        }
        private void DeleteUser(int rowIndex)
        {
            _intFnc.DeleteUser(int.Parse(_dataGridViewUsers.Rows[rowIndex].Cells[ColumnId.Index].Value.ToString()));
        }
        private void EditMvt(int rowIndex)
        {
            _intFnc.EditMvt(int.Parse(_dataGridViewMovement.Rows[rowIndex].Cells[ColumnMvtId.Index].Value.ToString()));
        }
        private void DeleteMvt(int rowIndex)
        {
            _intFnc.DeleteMvt(int.Parse(_dataGridViewMovement.Rows[rowIndex].Cells[ColumnMvtId.Index].Value.ToString()));
        }
        private void RefundGift(int rowIndex)
        {
            _dataGridViewRefund.Rows[rowIndex].Cells[_dataGridViewRefund.Columns.IndexOf(ColumnRfdStatus)].Value = "Gift";
            Refund.GetRefund(_intFnc.CurrentProject.Refunds, int.Parse(_dataGridViewRefund.Rows[rowIndex].Cells[ColumnRfdId.Index].Value.ToString())).CurrentStatus = Refund.Status.GIFT;
        }
        private void RefundCompleteExchange(int rowIndex)
        {
            _dataGridViewRefund.Rows[rowIndex].Cells[_dataGridViewRefund.Columns.IndexOf(ColumnRfdStatus)].Value = "Completed";
            Refund.GetRefund(_intFnc.CurrentProject.Refunds, int.Parse(_dataGridViewRefund.Rows[rowIndex].Cells[ColumnRfdId.Index].Value.ToString())).CurrentStatus = Refund.Status.REFUNDED;
        }
        private void RefundCancel(int rowIndex)
        {
            _dataGridViewRefund.Rows[rowIndex].Cells[_dataGridViewRefund.Columns.IndexOf(ColumnRfdStatus)].Value = "Canceled";
            Refund.GetRefund(_intFnc.CurrentProject.Refunds, int.Parse(_dataGridViewRefund.Rows[rowIndex].Cells[ColumnRfdId.Index].Value.ToString())).CurrentStatus = Refund.Status.CANCELED;
        }
        #endregion

        #region Event
        private void PanelFinance_Resize(object sender, EventArgs e)
        {
            Refresh();
        }
        private void _dataGridViewRefund_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (_dataGridViewRefund.Columns[e.ColumnIndex].Equals(ColumnRfdCanceled))
            {
                RefundCancel(e.RowIndex);
                _intFnc.CurrentProject.Balance();
                Refresh();
            }
            else if (_dataGridViewRefund.Columns[e.ColumnIndex].Equals(ColumnRfdGift))
            {
                RefundGift(e.RowIndex);
                _intFnc.CurrentProject.Balance();
                Refresh();
            }
            else if (_dataGridViewRefund.Columns[e.ColumnIndex].Equals(ColumnRfdExchangeDone))
            {
                RefundCompleteExchange(e.RowIndex);
                _intFnc.CurrentProject.Balance();
                Refresh();
            }
        }
        private void _dataGridViewUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (_dataGridViewUsers.Columns[e.ColumnIndex].Equals(ColumnEdit))
            {
                EditUser(e.RowIndex);
            }
            else if (_dataGridViewUsers.Columns[e.ColumnIndex].Equals(ColumnDelete))
            {
                DeleteUser(e.RowIndex);
            }
        }
        private void _dataGridViewMovement_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (_dataGridViewMovement.Columns[e.ColumnIndex].Equals(ColumnMvtEdit))
            {
                EditMvt(e.RowIndex);
            }
            else if (_dataGridViewMovement.Columns[e.ColumnIndex].Equals(ColumnMvtDel))
            {
                DeleteMvt(e.RowIndex);
            }
        }
        #endregion
    }
}
