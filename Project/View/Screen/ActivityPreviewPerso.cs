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

namespace Droid.financial
{
    public partial class ActivityPreviewPerso : UserControlCustom
    {
        #region Attribute
        private FinancialActivity _activity;
        #endregion

        #region Properties
        public FinancialActivity Activity
        {
            get { return _activity; }
            set { _activity = value; }
        }
        #endregion

        #region Constructor
        public ActivityPreviewPerso()
        {
            InitializeComponent();
        }
        public ActivityPreviewPerso(FinancialActivity activity)
        {
            _activity = activity;
            InitializeComponent();
            Init();
        }
        #endregion

        #region Methods public
        public override void RefreshData()
        {
            viewExpences1.RefreshData();
            viewMovements1.RefreshData();
            viewAccountResume1.RefreshData();
        }
        #endregion

        #region Methods private
        private void Init()
        {
            this.Name = _activity != null ? _activity.Id : DateTime.Now.Ticks.ToString();

            viewExpences1.Activity = _activity;
            viewExpences1.RefreshData();

            viewMovements1.Activity = _activity;
            viewMovements1.RefreshData();

            viewAccountResume1.Activity = _activity;
            viewAccountResume1.RefreshData();
            
            InitClick();
        }
        #endregion

        #region Event
        protected override void OnPaint(PaintEventArgs e)
        {
            if (e.ClipRectangle.Width == this.Width)
            {
                base.OnPaint(e);
                int borderWidth = 1;
                Color borderColor = _isActive ? Color.DarkOrange : Color.DarkGray;
                ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle, borderColor, borderWidth, ButtonBorderStyle.Solid, borderColor, borderWidth, ButtonBorderStyle.Solid, borderColor, borderWidth, ButtonBorderStyle.Solid, borderColor, borderWidth, ButtonBorderStyle.Solid);
            }
        }
        private void buttonClose_Click(object sender, EventArgs e)
        {

        }
        #endregion
    }
}
