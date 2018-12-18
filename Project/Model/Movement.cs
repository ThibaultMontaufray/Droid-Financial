using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;

namespace Droid.financial
{
    public class Movement : ICloneable
    {
        #region Enum
        public enum GOP
        {
            OTHER,
            TRANSPORT,
            FOOD,
            ACTIVITIES,
            COMODITIES,
            CLOTHES,
            LOGEMENT,
            ABONMENT,
            LOANS
        }
        #endregion

        #region Attribute
        private bool _subMovement;
        private float _amount;
        private string _name;
        private List<string> _userId;
        private GOP _gop;
        private string _billPath;
        private string _currency;
        private string _description;
        private int _id;
        private DateTime _startDate;
        private DateTime _endDate;
        private List<string> _gopExample;
        private bool _isPartial;
        private List<string> _userIdParticipant;
        private bool _allParticipant;
        #endregion

        #region Properties
        public bool SubMovement
        {
            get { return _subMovement; }
            set { _subMovement = value; }
        }
        public bool IsPartial
        {
            get { return _isPartial; }
            set { _isPartial = value; }
        }
        public string Currency
        {
            get { return _currency; }
            set { _currency = value; }
        }
        public string BillPath
        {
            get { return _billPath; }
            set { _billPath = value; }
        }
        public GOP Gop
        {
            get { return _gop; }
            set { _gop = value; }
        }
        public string StrGop
        {
            set
            {
                GOP tmp;
                if (Enum.TryParse(value, out tmp))
                {
                    _gop = tmp;
                }
                else
                {
                    _gop = GOP.OTHER;
                }
            }
            get { return _gop.ToString(); }
        }
        public List<string> UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public float Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        public DateTime EndDate
        {
            get { return _endDate; }
            set { _endDate = value; }
        }
        public DateTime StartDate
        {
            get { return _startDate; }
            set { _startDate = value; }
        }
        public List<string> UserIdParticipant
        {
            get { return _userIdParticipant; }
            set { _userIdParticipant = value; }
        }
        public bool AllParticipant
        {
            get { return _allParticipant; }
            set { _allParticipant = value; }
        }
        #endregion

        #region Constructor
        public Movement()
        {
            _currency = "EUR";
            _allParticipant = true;
            _gopExample = new List<string>();
            _userId = new List<string>();
            _userIdParticipant = new List<string>();
            _startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
            _endDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);
            _id = DateTime.Now.GetHashCode();
            _amount = 0;
        }
        public Movement(XmlReader node)
        {
            _currency = "EUR";
            _allParticipant = true;
            _gopExample = new List<string>();
            _userId = new List<string>();
            _userIdParticipant = new List<string>();
            for (int i = 0; i < node.AttributeCount; i++)
            {
                try
                {
                    node.MoveToAttribute(i);
                    switch (node.Name.ToLower())
                    {
                        case "name": this.Name = node.Value; break;
                        case "amount": this.Amount = float.Parse(node.Value); break;
                        case "billpath": this.BillPath = node.Value; break;
                        case "currency": this.Currency = node.Value; break;
                        case "gop": this.StrGop = node.Value; break;
                        case "description": this.Description = node.Value; break;
                        case "mvtid": this.ID = int.Parse(node.Value); break;
                        case "startdate": this.StartDate = DateTime.Parse(node.Value); break;
                        case "enddate": this.EndDate = DateTime.Parse(node.Value); break;
                        case "ispartial": this.IsPartial = bool.Parse(node.Value); break;
                        case "allparticipant": this.AllParticipant = bool.Parse(node.Value); break;
                        case "userid": foreach (string item in node.Value.Split(';')) this.UserId.Add(item); break;
                        case "useridparticipant": foreach (string item in node.Value.Split(';')) this.UserIdParticipant.Add(item); break;
                    }
                }
                catch (Exception)
                {
                }
            }
        }
        #endregion

        #region Methods public
        public string ToXml()
        {
            string lstUser = string.Empty;
            string strUser = string.Empty;
            string lstUserParticipant = string.Empty;
            string strUserParticipant = string.Empty;

            foreach (string item in _userId) lstUser += item + ";";
            if (lstUser.EndsWith(";")) strUser = lstUser.Substring(0, lstUser.Length - 1);

            foreach (string item in _userIdParticipant) lstUserParticipant += item + ";";
            if (lstUserParticipant.EndsWith(";")) strUserParticipant = lstUserParticipant.Substring(0, lstUserParticipant.Length - 1);

            return "\t<movement name=\"" + _name + "\" amount=\"" + _amount + "\" userid=\"" + strUser + "\" useridparticipant=\"" + strUserParticipant + "\" allparticipant=\"" + _allParticipant.ToString() + "\" gop=\"" + _gop.ToString() + "\" billpath=\"" + _billPath + "\" currency=\"" + _currency.ToString() + "\" mvtid=\"" + _id.ToString() + "\" description=\"" + _description + "\" startDate=\"" + _startDate.ToString() + "\" endDate=\"" + _endDate.ToString() + "\" isPartial=\"" + _isPartial.ToString() + "\" />";
        }
        public double Convert(Change chg, string targetCurrency)
        {
            if (chg == null || targetCurrency.Equals(this.Currency)) return this._amount;
            else if (chg.Currency1.Equals(targetCurrency)) return this._amount / chg.Rate;
            else if (chg.Currency2.Equals(targetCurrency)) return this._amount * chg.Rate;
            else return 0;
        }
        public object Clone()
        {
            Movement mvt = new Movement();
            mvt.Amount = _amount;
            mvt.Name = _name;
            mvt.UserId = new List<string>(_userId);
            mvt.Gop = _gop;
            mvt.BillPath = _billPath;
            mvt.Currency = _currency;
            mvt.Description = _description;
            mvt.ID = _id;
            mvt.StartDate = _startDate;
            mvt.EndDate = _endDate;
            mvt._gopExample = new List<string>(_gopExample);
            mvt.IsPartial = _isPartial;
            mvt.UserIdParticipant = new List<string>(_userIdParticipant);
            mvt.AllParticipant = _allParticipant;
            mvt.SubMovement = _subMovement;
            return mvt;
        }
        #endregion

        #region Methods public static
        public static string GetCurrency(string currency)
        {
            return currency.ToUpper();
        }
        public static List<Movement> ImportMvt(string filePath)
        {
            return null;
        }
        #endregion

        #region Methods private
        private void BuildGopExample()
        {
            _gopExample = new List<string>();
            _gopExample.Add("TRANSPORT|ratp;sncf");
            _gopExample.Add("FOOD|franprix");
        }
        private List<string> ImportCSV(string file)
        {
            string tabSep = ";";
            int indexFirstRow = 0;
            List<string> mvts = new List<string>();
            StringBuilder sb = new StringBuilder();
            bool started = false;

            string[] lines = System.IO.File.ReadAllLines(file);
            foreach (string line in lines)
            {
                if (!started && !line.Contains(tabSep)) indexFirstRow++;
                else
                {
                    if (line.Contains(DateTime.Now.Year.ToString()) || line.Contains((DateTime.Now.Year - 1).ToString()) || line.Contains((DateTime.Now.Year - 2).ToString()))
                    {
                        if (!string.IsNullOrEmpty(sb.ToString())) mvts.Add(sb.ToString());
                        sb = new StringBuilder();
                        sb.Append(line.Trim());
                    }
                    else
                    {
                        sb.Append(line.Trim());
                    }
                }
            }
            if (!string.IsNullOrEmpty(sb.ToString())) mvts.Add(sb.ToString());
            return mvts;
        }
        private List<string> ImportXML(string file)
        {
            List<string> mvts = new List<string>();
            return mvts;
        }
        private List<Movement> Parse(List<string> listFlatMvt)
        {
            string analyseString = string.Empty;
            List<Movement> lstMvt = new List<Movement>();
            foreach (string flatMvt in listFlatMvt)
            {
                Movement mvt = new Movement();
                string[] tab = flatMvt.Split(';');

                foreach (string item in tab)
                {
                    analyseString = CleanString(item);
                    if (!string.IsNullOrEmpty(analyseString))
                    {
                        if (SearchDate(mvt, analyseString)) { }
                        else if (SearchAmount(mvt, analyseString)) { }
                        else
                        {
                            if (string.IsNullOrEmpty(mvt.Name)) mvt.Name = analyseString;
                            mvt.Description += analyseString + " ";
                        }
                    }
                }
                SearchGop(mvt);
                lstMvt.Add(mvt);
            }
            return lstMvt;
        }
        private string CleanString(string s)
        {
            if (!string.IsNullOrEmpty(s))
            {
                string retString = string.Empty;
                retString = s.Replace(',', '.');
                retString = retString.Replace("\"", "");
                retString = retString.Trim();
                if (retString.Substring(retString.Length - 1, 1).Equals(".")) retString = retString.Substring(0, retString.Length - 1);
                retString = retString.Trim();
                return retString;
            }
            return s;
        }
        private bool SearchDate(Movement mvt, string s)
        {
            DateTime dt;
            if (DateTime.TryParse(s, out dt))
            {
                mvt._startDate = dt;
                mvt._startDate = dt.AddDays(1);
                return true;
            }
            return false;
        }
        private bool SearchAmount(Movement mvt, string s)
        {
            Regex r = new Regex(@"^[0-9]*(?:\,[0-9]*)?$");
            if (r.IsMatch(s))
            {
                mvt._amount = float.Parse(s);
                return true;
            }
            return false;
        }
        private bool SearchGop(Movement mvt)
        {
            foreach (string gopList in _gopExample)
            {
                string[] tab = gopList.Split('|');
                if (tab.Length > 1 && tab[1].Contains(mvt.Name.ToLower()))
                {
                    mvt.StrGop = tab[0];
                    return true;
                }
            }
            return false;
        }
        #endregion
    }
}