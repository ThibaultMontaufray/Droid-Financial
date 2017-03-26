using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Droid_financial
{
    public struct Movement
    {
        #region Enum
        public enum PaymentType
        {
            CASH,
            CREDITCARD
        }
        #endregion

        #region Attribute
        private string _userId;
        private double _amount;
        private DateTime _date;
        private PaymentType _type;
        #endregion

        #region Properties
        public PaymentType Type
        {
            get { return _type; }
            set { _type = value; }
        }
        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }
        public double Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }
        public string UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }
        #endregion

        #region Methods public
        public override string ToString()
        {
            return string.Format("{0} {1} {2}", _userId, _amount, _date);
        }
        public static PaymentType GetPaymentType(string s)
        {
            switch (s.Replace(" ", string.Empty).ToLower())
            {
                case "creditcard":
                case "cartebancaire":
                    return PaymentType.CREDITCARD;
                case "liquide":
                case "cash":
                default:
                    return PaymentType.CASH;
            }
        }
        #endregion

        #region Methods private
        #endregion

        #region Event
        #endregion
    }
}
