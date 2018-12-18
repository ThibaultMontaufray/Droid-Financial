using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Droid.financial
{
    public class Product
    {
        #region Attributes
        private int _id;
        private string _name;
        private string _description;
        private int _quantity;
        private int _cost;
        private Unit _unit;
        private PaymentSupport _support;
        #endregion

        #region Properites
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public PaymentSupport Support
        {
            get { return _support; }
            set { _support = value; }
        }
        public Unit Unit
        {
            get { return _unit; }
            set { _unit = value; }
        }
        public int Cost
        {
            get { return _cost; }
            set { _cost = value; }
        }
        public int Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        #endregion

        #region Constructor
        public Product()
        {

        }
        #endregion

        #region Methods public
        public override string ToString()
        {
            return _name + " - " + _description;
        }
        #endregion

        #region Methods private
        #endregion

        #region Event
        #endregion
    }
}
