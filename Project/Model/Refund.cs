using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Droid.financial
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
        private string _id;
        private string _currency;
        private string _receiver;
        private string _giver;
        private double _amount;
        private Status _status;
        #endregion

        #region Properties
        public string ID
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Currency 
        { 
            get {return _currency; } 
            set { _currency = value; }
        }
        public string Receiver
        {
            get { return _receiver; }
            set { _receiver = value; }
        }
        public string Giver
        {
            get { return _giver; }
            set { _giver = value; }
        }
        public double Amount
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
            _id = this.GetHashCode().ToString();
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
                        case "id": this.ID = node.Value; break;
                        case "receiver": this.Receiver = node.Value; break;
                        case "giver": this.Giver = node.Value; break;
                       //case "currency": this.Currency = (CURRENCY)Enum.Parse(typeof(CURRENCY), node.Value); break;
                        case "currency": this.Currency = node.Value; break;
                        case "amount": this.Amount = double.Parse(node.Value); break;
                        case "status": this.CurrentStatus = (Status)Enum.Parse(typeof(Status), node.Value); break;
                    }
                }
                catch (Exception)
                {
                }
            }
            if (string.IsNullOrEmpty(_id)) ID = this.GetHashCode().ToString();
        }
        #endregion

        #region Methods static
        public static Refund GetRefund(List<Refund> lstRfd, string index)
        {
            foreach(Refund rfd in lstRfd)
            {
                if (rfd.ID.Equals(index)) return rfd;
            }
            return new Refund();
        }
        #endregion

        #region Methods public
        public void Load(string pathFile)
        {
            if (File.Exists(pathFile))
            {
                using (StreamReader sr = new StreamReader(pathFile))
                {
                    var json = sr.ReadToEnd();
                    var data = JsonConvert.DeserializeObject<Refund>(json);
                    if (data != null) { Import(data, this); }
                }
            }
            else if (Directory.Exists(pathFile))
            {
                foreach (string file in Directory.GetFiles(pathFile))
                {
                    if (Path.GetFileName(file).StartsWith("movement.") && Path.GetExtension(file).Equals(".xml"))
                    {
                        using (StreamReader sr = new StreamReader(file))
                        {
                            var json = sr.ReadToEnd();
                            var data = JsonConvert.DeserializeObject<Refund>(json);
                            if (data != null)
                            {
                                Import(data, this);
                            }
                        }
                        break;
                    }
                }
            }
        }
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
        public string ToCsv()
        {
            string separator = ";";
            string ret = string.Empty;

            PropertyInfo[] props = typeof(Refund).GetProperties();
            foreach (PropertyInfo prop in props)
            {
                //Console.WriteLine(this.GetType().GetProperty(prop.Name).GetValue(this));
                if (!string.IsNullOrEmpty(ret)) { ret += separator; }
                ret += prop.Name;
            }
            ret += "\r\n";
            foreach (PropertyInfo prop in props)
            {
                //Console.WriteLine(this.GetType().GetProperty(prop.Name).GetValue(this));
                if (!ret.EndsWith("\r\n")) { ret += separator; }
                ret += this.GetType().GetProperty(prop.Name).GetValue(this);
            }

            return ret;
        }
        public string ToXml()
        {
            string serializedObject = string.Empty;

            XmlSerializer xsSubmit = new XmlSerializer(typeof(Refund));
            using (var sww = new StringWriter())
            {
                using (XmlWriter writer = XmlWriter.Create(sww))
                {
                    xsSubmit.Serialize(writer, this);
                    serializedObject = sww.ToString();
                }
            }
            return serializedObject;
        }
        #endregion

        #region Methods private
        private void Import(Refund source, Refund target)
        {
            target._amount = source._amount;
            target._currency = source._currency;
            target._giver = source._giver;
            target._id = source._id;
            target._receiver = source._receiver;
            target._status = source._status;

            source = null;
        }
        #endregion
    }
}
