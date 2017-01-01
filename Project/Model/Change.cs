using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Droid_financial
{
    public class Change
    {
        #region Attribute
        private string _currency1;
        private string _currency2;
        private float _rate;        
        #endregion

        #region Properties
        public float Rate
        {
            get { return _rate; }
            set { _rate = value; }
        }
        public string Currency2
        {
            get { return _currency2; }
            set { _currency2 = value; }
        }
        public string Currency1
        {
            get { return _currency1; }
            set { _currency1 = value; }
        }
        #endregion

        #region Constructor
        public Change()
        {
        }
        public Change(XmlReader node, bool direction)
        {
            for (int i = 0; i < node.AttributeCount; i++)
            {
                try
                {
                    node.MoveToAttribute(i);
                    if (direction)
                    {
                        switch (node.Name.ToLower())
                        {
                            case "cur1": this.Currency1 = node.Value; break;
                            case "cur2": this.Currency2 = node.Value; break;
                            case "rate": this._rate = float.Parse(node.Value); break;
                        }
                    }
                    else
                    {
                        switch (node.Name.ToLower())
                        {
                            case "cur1": this.Currency2 = node.Value; break;
                            case "cur2": this.Currency1 = node.Value; break;
                            case "rate": this._rate = (1 / float.Parse(node.Value)); break;
                        }
                    }
                }
                catch (Exception)
                {
                }
            }
        }
        public Change(string cur1, string cur2, float taux)
        {
            this._currency1 = cur1;
            this._currency2 = cur2;
            this._rate = taux;
        }
        #endregion

        #region Methods public
        public float ConvertToCur2(float val)
        {
            return val * Rate;
        }
        public float ConvertToCur1(float val)
        {
            return val / Rate;
        }
        public string ToXml()
        {
            string ret = string.Empty;
            ret = "\t<change " +
                "cur1=\"" + this._currency1 + "\" " +
                "cur2=\"" + this._currency2 + "\" " +
                "rate=\"" + this._rate + "\" " +
                "/>";
            return ret;
        }
        #endregion

        #region Methods public static
        public static Change Find(List<Change> lstChg, string cur1, string cur2)
        {
            foreach (Change item in lstChg) if (cur1.Equals(item.Currency1) && cur2.Equals(item.Currency2)) return item;
            return null;
        }
        #endregion
    }
}
