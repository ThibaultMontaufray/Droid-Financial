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
using System.Windows.Forms.DataVisualization.Charting;

namespace Droid.financial
{
    public partial class ActivityPreviewPro : UserControlCustom
    {
        #region Attributes
        string[] MONTH = new string[] { "Jan.", "Feb.", "Mar.", "Apr.", "May", "Jun.", "July", "Aug.", "Sep.", "Oct.", "Nov.", "Dec." };
        private const int CEILING = 32000;
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
        public ActivityPreviewPro()
        {
            InitializeComponent();
            Init();
        }
        public ActivityPreviewPro(FinancialActivity activity)
        {
            _activity = activity;
            InitializeComponent();
            Init();
        }
        #endregion

        #region Methods public
        public override void RefreshData()
        {
            RefreshDataResume();
            RefreshDataTurnover();
            RefreshDataBills();
            RefreshDataUnpaidBills();
            RefreshDataTurnoverChart();
            RefreshDataCeiling();
            RefreshDataCotisation();
        }
        public override void ChangeLanguage()
        {
            base.ChangeLanguage();
        }
        #endregion

        #region Methods private
        private void Init()
        {
            this.Name = _activity != null ? _activity.Id : DateTime.Now.Ticks.ToString();

            dataGridViewCotisation.Rows.Clear();
            dataGridViewCotisation.Rows.Add(4);
            dataGridViewCotisation.Rows[0].Cells[0].Value = "Turnover collected";
            dataGridViewCotisation.Rows[0].Cells[1].Value = "0.00 €";
            dataGridViewCotisation.Rows[1].Cells[0].Value = "Cotisation rate";
            dataGridViewCotisation.Rows[1].Cells[1].Value = "22.0 %";
            dataGridViewCotisation.Rows[2].Cells[0].Value = "Tax";
            dataGridViewCotisation.Rows[2].Cells[1].Value = "2.2 %";
            dataGridViewCotisation.Rows[3].Cells[0].Value = "Cotisation amount";
            dataGridViewCotisation.Rows[3].Cells[1].Value = "0.00 €";

            int headerHeight = dataGridViewCotisation.ColumnHeadersHeight;
            int height = dataGridViewCotisation.Size.Height - headerHeight;
            int rowHeight = height / dataGridViewCotisation.RowCount;
            for (int i = 0; i < dataGridViewCotisation.Rows.Count; i++) { dataGridViewCotisation.Rows[i].Height = rowHeight; }

            viewAccountResume.Activity = _activity;
            RefreshData();
            InitClick();
        }
        private void RefreshDataResume()
        {
            viewAccountResume.RefreshData();
        }
        private void RefreshDataTurnover()
        {
            int val = 0;
            if (_activity != null && _activity.Bills != null)
            {
                foreach (var item in _activity.Bills)
                {
                    val += item.Amount;
                }
            }
            labelAmountTurnover.Text = val + " €";
            //labelTurnoverThisMonth.Text = _activity.Bills.Where(b => b.CreateDate < DateTime.Now) " € this month";
        }
        private void RefreshDataBills()
        {
            int val = 0;
            if (_activity != null && _activity.Bills != null)
            {
                foreach (var item in _activity.Bills.Where(b => b.PayDate != DateTime.MinValue))
                {
                    val += item.Amount;
                }
            }
            labelAmountBills.Text = val + " €";
            labelCountPendingBills.Text = _activity.Bills.Where(b => b.PayDate != DateTime.MinValue).Count() + " pending bills";
        }
        private void RefreshDataUnpaidBills()
        {
            int val = 0;
            if (_activity != null && _activity.Bills != null)
            {
                foreach (var item in _activity.Bills.Where(b => b.PayDate == DateTime.MinValue))
                {
                    val += item.Amount;
                }
            }
            labelAmountUnpaidBills.Text = val + " €";
            labelCountUnpaidBills.Text = _activity.Bills.Where(b => b.PayDate == DateTime.MinValue).Count() + " bills unpaid";
        }
        private void RefreshDataTurnoverChart()
        {
            int cumulTurnover;
            double[] cumulYearTurnover = new double[12];
            double[] cumulYearBenefit = new double[12];
            for (int month = 1; month < 13; month++)
            {
                cumulTurnover = 0;
                foreach (var bill in _activity.Bills.Where(b => b.CreateDate.Year == DateTime.Now.Year && b.CreateDate.Month == month).ToList())
                {
                    cumulTurnover += bill.Amount;
                }
                cumulYearTurnover[month - 1] = cumulTurnover;
                cumulYearBenefit[month - 1] = cumulTurnover - _activity.GetTax(new DateTime(DateTime.Now.Year, month, 1));
            }
            chartTurnover.Series["SerieTurnover"].Points.DataBindXY(MONTH, cumulYearTurnover);
            chartTurnover.Series["SerieBenefit"].Points.DataBindXY(MONTH, cumulYearBenefit);
        }
        private void RefreshDataCeiling()
        {
            double rate = (_activity.CurrentTurnover * 100) / CEILING;
            chartCeiling.Series["Series1"].Points.Add(new DataPoint(1, rate));
            chartCeiling.Series["Series2"].Points.Add(new DataPoint(1, 100 - rate));
            labelCeilingValue.Text = rate + " %";
        }
        private void RefreshDataCotisation()
        {
            double totalTax = 0;
            for (int i = 1; i < 13; i++)
            {
                totalTax += _activity.GetTax(new DateTime(DateTime.Now.Year, i, 1));
            }
            dataGridViewCotisation.Rows[0].Cells[1].Value = _activity.CurrentTurnover + " €";
            dataGridViewCotisation.Rows[3].Cells[1].Value = totalTax + " €";
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
                ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle, borderColor, borderWidth, ButtonBorderStyle.Solid, borderColor, borderWidth, ButtonBorderStyle.Solid, borderColor, borderWidth, ButtonBorderStyle.Solid,  borderColor, borderWidth, ButtonBorderStyle.Solid);
            }
        }
        private void buttonClose_Click(object sender, EventArgs e)
        {

        }
        #endregion
    }
}
