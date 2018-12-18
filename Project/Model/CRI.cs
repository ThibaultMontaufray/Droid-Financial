using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Droid.financial
{
    public class CRI
    {
        #region Attributes
        private DateTime _date;
        private double _amount;
        #endregion

        #region Properties
        public double Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }
        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }
        #endregion

        #region Consturctor
        public CRI()
        {
            _date = DateTime.Now;
        }
        #endregion
    }
}
