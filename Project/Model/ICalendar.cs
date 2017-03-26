using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Droid_financial
{
    public class ICalendar
    {
        #region Attribute
        private DateTime _beginDate;
        private DateTime _endDate;
        private string _text;        
        #endregion

        #region Properties
        public DateTime EndDate
        {
            get { return _endDate; }
            set { _endDate = value; }
        }
        public DateTime BeginDate
        {
            get { return _beginDate; }
            set { _beginDate = value; }
        }
        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }
        #endregion

        #region Constructor
        public ICalendar()
        {

        }
        public ICalendar(FinancialActivity pf)
        {
            this.Text = pf.Name;
            this.BeginDate = pf.StartDate;
            this.EndDate = pf.EndDate;
        }
        #endregion

        #region Methods
        #endregion
    }
}
