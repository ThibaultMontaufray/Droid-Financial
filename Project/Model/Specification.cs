using Droid.People;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Droid.financial
{
    public class Specification
    {
        #region Attributes
        private string _id;
        private Entity _from;
        private Entity _to;
        private DateTime _creationDate;
        private int _maxDays;
        private List<Product> _products;
        private int _deposit;
        private Status _status;
        #endregion

        #region Properites
        public Status Status
        {
            get { return _status; }
            set { _status = value; }
        }
        public int Deposit
        {
            get { return _deposit; }
            set { _deposit = value; }
        }
        public List<Product> Products
        {
            get { return _products; }
            set { _products = value; }
        }
        public int MaxDays
        {
            get { return _maxDays; }
            set { _maxDays = value; }
        }
        public DateTime CreationDate
        {
            get { return _creationDate; }
            set { _creationDate = value; }
        }
        public Entity To
        {
            get { return _to; }
            set { _to = value; }
        }
        public Entity From
        {
            get { return _from; }
            set { _from = value; }
        }
        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }
        #endregion

        #region Constructor
        public Specification()
        {
            _creationDate = DateTime.Now;
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
