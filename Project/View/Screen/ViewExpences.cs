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
    public partial class ViewExpences : Tools4Libraries.UserControlCustom
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
        public ViewExpences()
        {
            InitializeComponent();
            Init();
        }
        public ViewExpences(FinancialActivity activity)
        {
            _activity = activity;
            InitializeComponent();
            Init();
            LoadData();
        }
        #endregion

        #region Methods public
        public override void ChangeLanguage()
        {

        }
        public override void RefreshData()
        {
            LoadData();
        }
        #endregion

        #region Methods private
        private void Init()
        {
        }
        private void LoadData()
        {
            int paid = 0;
            int unpaid = 0;
            if (_activity != null && _activity != null)
            {
                chart1.Series["Series1"].Points.Clear();
                foreach (CRE expense in _activity.ListCRE.Where(e => e.StartDate.Date >= DateTime.Now.Date.AddMonths(-1) && e.StartDate.Date <= DateTime.Now))
                {
                    if (expense.Amount == expense.Paid) { paid++; }
                    else { unpaid++; }
                }
                var bookings = _activity.Expenses;
                chart1.Series["Series1"].Points.AddXY("Paid", paid);
                chart1.Series["Series1"].Points.AddXY("Unpaid", unpaid);
                chart1.Series["Series1"].Points[0].Color = System.Drawing.Color.DarkOrange;
                chart1.Series["Series1"].Points[1].Color = System.Drawing.Color.Maroon;
            }
        }
        #endregion

        #region Event
        #endregion
    }
}
