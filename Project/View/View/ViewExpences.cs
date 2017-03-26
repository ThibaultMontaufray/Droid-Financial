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

namespace Droid_financial
{
    public partial class ViewExpences : UserControlCustom
    {
        #region Attribute
        private Interface_fnc _intFnc;
        #endregion

        #region Properties
        public Interface_fnc InterfaceFinancial
        {
            get { return _intFnc; }
            set { _intFnc = value; }
        }
        #endregion

        #region Constructor
        public ViewExpences()
        {
            InitializeComponent();
            Init();
        }
        public ViewExpences(Interface_fnc intFnc)
        {
            _intFnc = intFnc;
            InitializeComponent();
            Init();
            LoadData();
        }
        #endregion

        #region Methods public
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
            if (_intFnc != null && _intFnc.CurrentProject != null)
            {
                chart1.Series["Series1"].Points.Clear();
                foreach (Expense expense in _intFnc.CurrentProject.ListExpenses.Where(e => e.StartDate.Date >= DateTime.Now.Date.AddMonths(-1) && e.StartDate.Date <= DateTime.Now))
                {
                    if (expense.Amount == expense.Paid) { paid++; }
                    else { unpaid++; }
                }
                var bookings = _intFnc.CurrentProject.Expenses;
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
