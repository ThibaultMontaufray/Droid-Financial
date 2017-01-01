using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Droid_financial
{
    public class Refund
    {
        #region Enum
        public enum Status
        {
            NONE,
            REFUNDED,
            GIFT,
            CANCELED
        }
        #endregion

        #region Attribute
        private int _id;
        private string _currency;
        private int _receiver;
        private int _giver;
        private float _amount;
        private Status _status;
        #endregion

        #region Properties
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Currency 
        { 
            get {return _currency; } 
            set { _currency = value; }
        }
        public int Receiver
        {
            get { return _receiver; }
            set { _receiver = value; }
        }
        public int Giver
        {
            get { return _giver; }
            set { _giver = value; }
        }
        public float Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }
        public Status CurrentStatus
        {
            get { return _status; }
            set { _status = value; }
        }
        #endregion

        #region Constructor
        public Refund()
        {
            CurrentStatus = Status.NONE;
            _currency = string.Empty;
            _id = this.GetHashCode();
        }
        public Refund(XmlReader node)
        {
            _currency = string.Empty;
            for (int i = 0; i < node.AttributeCount; i++)
            {
                try
                {
                    node.MoveToAttribute(i);
                    switch (node.Name.ToLower())
                    {
                        case "id": this.ID = int.Parse(node.Value); break;
                        case "receiver": this.Receiver = int.Parse(node.Value); break;
                        case "giver": this.Giver = int.Parse(node.Value); break;
                       //case "currency": this.Currency = (CURRENCY)Enum.Parse(typeof(CURRENCY), node.Value); break;
                        case "currency": this.Currency = node.Value; break;
                        case "amount": this.Amount = float.Parse(node.Value); break;
                        case "status": this.CurrentStatus = (Status)Enum.Parse(typeof(Status), node.Value); break;
                    }
                }
                catch (Exception)
                {
                }
            }
            if (_id == 0) ID = this.GetHashCode();
        }
        #endregion

        #region Methods static
        public static Refund GetRefund(List<Refund> lstRfd, int index)
        {
            foreach(Refund rfd in lstRfd)
            {
                if (rfd.ID == index) return rfd;
            }
            return new Refund();
        }
        #endregion

        #region Methods public
        public string ToXml()
        {
            string ret = string.Empty;
            ret = "\t<refund id=\"" + _id + "\" currency=\"" + _currency + "\" receiver=\"" + _receiver + "\" giver=\"" + _giver + "\" amount=\"" + _amount + "\" status=\"" + _status + "\" />";
            return ret;
        }
        #endregion

        #region Methods private
        #endregion
    }
}
