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
        //private List<UserPanel> _userPanels;
        private PanelGraph _panelGraph;
        private List<string> _lstGopName;
        private List<float> _lstGopValues;
        private List<window_tile_postit> _lstWinTile;
        private int _indexLeft = 0;
        private int _indexTop = 0;
        private int _indexHeight = 300;
        private const int MARGE = 5;
        #endregion

        #region Properties
        public PanelGraph PanelGraphics
        {
            get { return _panelGraph; }
            set { _panelGraph = value; }
        }
        #endregion

        #region Constructor
        public PanelFinance()
        {
            InitializeComponent();
        }
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
            //_userPanels = new List<UserPanel>();
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
            //foreach (UserPanel up in _userPanels)
            //{
            //    up.UpdateUser();
            //}
            LoadProjectDetail();

            _indexTop = 0;
            _indexLeft = 0;
            BuildWinTiles();

        }
        public void SetGraphMode(PanelGraph.GRAPHMODE mode)
        {
            _panelGraph.GraphMode = mode;
        }
        #endregion

        #region Methods private
        private void CleanAll()
        {
            //_userPanels.Clear();
            _lstGopValues.Clear();
            _lstGopName.Clear();
        }

        private void BuildPanel()
        {
            //this.Width = 650;
            //this.Height = 650;
            this.Dock = DockStyle.Fill;
            if (_intFnc != null && _intFnc.CurrentProject != null)
            {
                LoadProjectDetail();
                
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
            if (_intFnc != null && _intFnc.Tsm != null)
            {
                //_lstWinTile.Add(BuildWinTilesMenu());
                //_lstWinTile.Add(BuildWinTilesGOP());
                //_lstWinTile.Add(BuildWinTilesMovements());
                //_lstWinTile.Add(BuildWinTilesUsers());
                //_lstWinTile.Add(BuildWinTilesReconciliation());

                //if (_intFnc.Tsm._detail_presentation != null && !string.IsNullOrEmpty(_intFnc.Tsm._detail_presentation.Text) && _intFnc.Tsm._detail_presentation.Text.StartsWith("Disable")) _lstWinTile.Add(BuildWinTilesMenu());
                //if (_intFnc.Tsm._detail_gop_rate != null && !string.IsNullOrEmpty(_intFnc.Tsm._detail_gop_rate.Text) && _intFnc.Tsm._detail_gop_rate.Text.StartsWith("Disable")) _lstWinTile.Add(BuildWinTilesGOP());
                //if (_intFnc.Tsm._detail_exps_list != null && !string.IsNullOrEmpty(_intFnc.Tsm._detail_exps_list.Text) && _intFnc.Tsm._detail_exps_list.Text.StartsWith("Disable")) _lstWinTile.Add(BuildWinTilesMovements());
                //if (_intFnc.Tsm._detail_user_list != null && !string.IsNullOrEmpty(_intFnc.Tsm._detail_user_list.Text) && _intFnc.Tsm._detail_user_list.Text.StartsWith("Disable")) _lstWinTile.Add(BuildWinTilesUsers());
                //if (_intFnc.Tsm._detail_reconciliation != null && !string.IsNullOrEmpty(_intFnc.Tsm._detail_reconciliation.Text) && _intFnc.Tsm._detail_reconciliation.Text.StartsWith("Disable")) _lstWinTile.Add(BuildWinTilesReconciliation());
            }
            foreach (window_tile_postit wt in _lstWinTile)
            {
                DisplayWinTile(wt);
            }
        }
        private void BuildDGV()
        {
            this._panelGraph = new PanelGraph();
            
            //
            // panelGraph
            //
            this._panelGraph.Dock = DockStyle.Fill;
            this._panelGraph.BackColor = Color.Transparent;

            this.AutoScroll = true;
        }

        private void LoadProjectDetail()
        {
            if (_intFnc.CurrentProject != null)
            {
                this.SuspendLayout();
                CleanAll();
                //LoadUsers();
                //LoadMovement();
                //LoadRefund();
                this.ResumeLayout();
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
        
        #endregion

        #region Event
        private void PanelFinance_Resize(object sender, EventArgs e)
        {
            Refresh();
        }
        #endregion
    }
}
