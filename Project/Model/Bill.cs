using Droid.People;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Droid.financial
{
    public class Bill
    {
        #region Attributes
        private int _id;
        private List<Product> _products;
        private EntityFinancialDecorator _client;
        private EntityFinancialDecorator _owner;
        private DateTime _createDate;
        private DateTime _limitDate;
        private string _bankDetail;
        private DateTime _payDate;
        private Color _color;
        #endregion

        #region Properites
        public Color Color
        {
            get { return _color; }
            set { _color = value; }
        }
        public int Amount
        {
            get
            {
                int amount = 0;
                if (_products?.Count != 0)
                {
                    foreach (var item in _products)
                    {
                        amount += item.Cost * item.Quantity;
                    }
                }
                return amount;
            }
        }
        public DateTime PayDate
        {
            get { return _payDate; }
            set { _payDate = value; }
        }
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public List<Product> Products
        {
            get { return _products; }
            set { _products = value; }
        }
        public string BankDetail
        {
            get { return _bankDetail; }
            set { _bankDetail = value; }
        }
        public DateTime LimitDate
        {
            get { return _limitDate; }
            set { _limitDate = value; }
        }
        public DateTime CreateDate
        {
            get { return _createDate; }
            set { _createDate = value; }
        }
        public EntityFinancialDecorator Owner
        {
            get { return _owner; }
            set { _owner = value; }
        }
        public EntityFinancialDecorator Client
        {
            get { return _client; }
            set { _client = value; }
        }
        #endregion

        #region Constructor
        public Bill()
        {
            _products = new List<Product>();
        }
        #endregion

        #region Methods public
        public void Save()
        {

        }
        public string ExportJson()
        {
            return JsonConvert.SerializeObject(this);
        }
        #endregion

        #region Methods private
        #endregion

        #region Event
        #endregion
    }
}
