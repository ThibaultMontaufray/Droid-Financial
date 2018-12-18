using Droid.financial.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tools4Libraries;

namespace Droid.financial.View
{
    public partial class MainForm : Form
    {
        #region Attributes
        private RibbonButton _btn_open;
        private RibbonButton _btn_exit;
        private Ribbon _ribbon;
        private InterfaceFinance _intFnc;
        #endregion

        #region Properties
        #endregion

        #region Constructor
        public MainForm()
        {
            InitializeComponent();

            _intFnc = new InterfaceFinance(string.Empty);
            _intFnc.Sheet.Dock = DockStyle.Fill;

            InitRibbon();
            InitSheet();
        }
        #endregion

        #region Methods public
        #endregion

        #region Methods private
        private void InitRibbon()
        {
            _ribbon = new Ribbon();
            _ribbon.Height = 150;
            _ribbon.ThemeColor = RibbonTheme.Black;
            _ribbon.OrbDropDown.Width = 150;
            _ribbon.OrbStyle = RibbonOrbStyle.Office_2013;
            _ribbon.OrbText = Droid.litterature.Parse.Traduction("File", Settings.Default.Language);
            _ribbon.QuickAccessToolbar.MenuButtonVisible = false;
            _ribbon.QuickAccessToolbar.Visible = false;
            _ribbon.QuickAccessToolbar.MinSizeMode = RibbonElementSizeMode.Compact;
            _ribbon.Dock = DockStyle.None;
            _ribbon.Top = -25;
            _ribbon.Left = 0;
            _ribbon.Width = this.Width;
            _ribbon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            _ribbon.Tabs.Add(_intFnc.Tsm);
            this.Controls.Add(_ribbon);

            _btn_open = new RibbonButton(Droid.litterature.Parse.Traduction("Open", Settings.Default.Language));
            _btn_open.Image = Tools4Libraries.Resources.ResourceIconSet32Default.open_folder;
            _btn_open.SmallImage = Tools4Libraries.Resources.ResourceIconSet16Default.open_folder;
            _btn_open.Click += B_open_Click;
            _ribbon.OrbDropDown.MenuItems.Add(_btn_open);
            
            _btn_exit = new RibbonButton(Droid.litterature.Parse.Traduction("Exit", Settings.Default.Language));
            _btn_exit.Image = Tools4Libraries.Resources.ResourceIconSet32Default.door_out;
            _btn_exit.SmallImage = Tools4Libraries.Resources.ResourceIconSet16Default.door_out;
            _btn_exit.Click += B_exit_Click;
            _ribbon.OrbDropDown.MenuItems.Add(_btn_exit);
        }
        private void InitSheet()
        {
            _intFnc.Sheet.Dock = DockStyle.None;
            _intFnc.Sheet.Top = 62;
            _intFnc.Sheet.Left = 0;
            _intFnc.Sheet.Width = this.Width;
            _intFnc.Sheet.Height = this.Height - _intFnc.Sheet.Top;
            _intFnc.Sheet.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right) | System.Windows.Forms.AnchorStyles.Bottom)));
            this.Controls.Add(_intFnc.Sheet);
        }
        #endregion

        #region event
        private void B_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void B_open_Click(object sender, EventArgs e)
        {
            _intFnc.Open(null);
        }
        #endregion
    }
}
