using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Serialization;

namespace Droid_financial
{
    public class Expense : ICloneable
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
        private double _amount;
        private string _name;
        private GOP _gop;
        private string _billPath;
        private string _currency;
        private string _description;
        private string _id;
        private DateTime _startDate;
        private DateTime _endDate;
        private List<string> _gopExample;
        private bool _isPartial;
        private List<Movement> _movements;
        private bool _allParticipant;
        #endregion

        #region Properties
        [XmlIgnore]
        public double Paid
        {
            get
            {
                double paid = 0;
                foreach (var parDep in Movements)
                {
                    paid += parDep.Amount;
                }
                return paid;
            }
        }
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
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public double Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        public string Id
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
        public List<Movement> Movements
        {
            get { return _movements; }
            set { _movements = value; }
        }
        public bool AllParticipant
        {
            get { return _allParticipant; }
            set { _allParticipant = value; }
        }
        #endregion

        #region Constructor
        public Expense()
        {
            Random rand = new Random((int)DateTime.Now.Ticks);
            _id = string.Format("expense.{0}-{1}-{2}", rand.Next(), (int)DateTime.Now.Ticks, rand.Next());

            _currency = "EUR";
            _allParticipant = true;
            _gopExample = new List<string>();
            _movements = new List<Movement>();
            _startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
            _endDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);
            _amount = 0;
        }
        public Expense(string path)
        {
            Random rand = new Random((int)DateTime.Now.Ticks);
            _id = string.Format("expense.{0}-{1}-{2}", rand.Next(), (int)DateTime.Now.Ticks, rand.Next());

            _currency = "EUR";
            _allParticipant = true;
            _gopExample = new List<string>();
            _movements = new List<Movement>();
            _startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
            _endDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);
            _amount = 0;

            Load(path);
        }
        #endregion

        #region Methods public
        public void Save(string path)
        {
            SaveFile(path);
        }
        public void Load(string pathFile)
        {
            if (File.Exists(pathFile))
            {
                using (StreamReader sr = new StreamReader(pathFile))
                {
                    var json = sr.ReadToEnd();
                    var data = JsonConvert.DeserializeObject<Expense>(json);
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
                            var data = JsonConvert.DeserializeObject<Expense>(json);
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

            PropertyInfo[] props = typeof(Expense).GetProperties();
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

            XmlSerializer xsSubmit = new XmlSerializer(typeof(Expense));
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
        public double Convert(Change chg, string targetCurrency)
        {
            if (chg == null || targetCurrency.Equals(this.Currency)) return this._amount;
            else if (chg.Currency1.Equals(targetCurrency)) return this._amount / chg.Rate;
            else if (chg.Currency2.Equals(targetCurrency)) return this._amount * chg.Rate;
            else return 0;
        }
        public object Clone()
        {
            Expense exps = new Expense();
            exps.Amount = _amount;
            exps.Name = _name;
            exps.Gop = _gop;
            exps.BillPath = _billPath;
            exps.Currency = _currency;
            exps.Description = _description;
            exps.Id = _id;
            exps.StartDate = _startDate;
            exps.EndDate = _endDate;
            exps._gopExample = new List<string>(_gopExample);
            exps.IsPartial = _isPartial;
            exps.Movements = new List<Movement>(_movements);
            exps.AllParticipant = _allParticipant;
            exps.SubMovement = _subMovement;
            return exps;
        }
        public override string ToString()
        {
            return string.Format("");
        }
        #endregion

        #region Methods public static
        public static string GetCurrency(string currency)
        {
            return currency.ToUpper();
        }
        public static List<Expense> ImportExps(string filePath)
        {
            return null;
        }
        public static Expense GetExpense(object o, List<Expense> expenses)
        {
            if (o == null) return null;
            string areaText = o.ToString();

            foreach (Expense exp in expenses)
            {
                if (areaText.Equals(exp.ToString()))
                {
                    return exp;
                }
            }
            return null;
        }
        public static Expense GetExpenseFromId(string idExpense, List<Expense> expenses)
        {
            if (string.IsNullOrEmpty(idExpense) || expenses == null) return null;
            var v =  expenses.Where(e => e.Id.Equals(idExpense));
            return v.Count() > 0 ? expenses.Where(e => e.Id.Equals(idExpense)).First() : null ;
        }
        #endregion

        #region Methods private
        private void Import(Expense source, Expense target)
        {
            target._allParticipant = source._allParticipant;
            target._amount = source._amount;
            target._billPath = source._billPath;
            target._currency = source._currency;
            target._description = source._description;
            target._endDate = source._endDate;
            target._gop = source._gop;
            target._gopExample = source._gopExample;
            target._id = source._id;
            target._isPartial = source._isPartial;
            target._name = source._name;
            target._movements = source._movements;
            target._startDate = source._startDate;
            target._subMovement = source._subMovement;

            source = null;
        }
        private void SaveFile(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            if (!Directory.Exists(Path.Combine(path, _id)))
            {
                Directory.CreateDirectory(Path.Combine(path, _id));
            }
            string filePath = Path.Combine(path, string.Format("{0}//{0}.xml", _id));
            using (StreamWriter sw = new StreamWriter(filePath, false))
            {
                sw.Write(ToJson());
            }
        }
        private void SaveXml(string xmlObject, string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string filePath = Path.Combine(path, string.Format("{0}//{0}.xml", _id));
            using (StreamWriter sw = new StreamWriter(filePath, false))
            {
                sw.Write(xmlObject);
            }
        }
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
            List<string> expss = new List<string>();
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
                        if (!string.IsNullOrEmpty(sb.ToString())) expss.Add(sb.ToString());
                        sb = new StringBuilder();
                        sb.Append(line.Trim());
                    }
                    else
                    {
                        sb.Append(line.Trim());
                    }
                }
            }
            if (!string.IsNullOrEmpty(sb.ToString())) expss.Add(sb.ToString());
            return expss;
        }
        private List<string> ImportXML(string file)
        {
            List<string> expss = new List<string>();
            return expss;
        }
        private List<Expense> Parse(List<string> listFlatExps)
        {
            string analyseString = string.Empty;
            List<Expense> lstExps = new List<Expense>();
            foreach (string flatExps in listFlatExps)
            {
                Expense exps = new Expense();
                string[] tab = flatExps.Split(';');

                foreach (string item in tab)
                {
                    analyseString = CleanString(item);
                    if (!string.IsNullOrEmpty(analyseString))
                    {
                        if (SearchDate(exps, analyseString)) { }
                        else if (SearchAmount(exps, analyseString)) { }
                        else
                        {
                            if (string.IsNullOrEmpty(exps.Name)) exps.Name = analyseString;
                            exps.Description += analyseString + " ";
                        }
                    }
                }
                SearchGop(exps);
                lstExps.Add(exps);
            }
            return lstExps;
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
        private bool SearchDate(Expense exps, string s)
        {
            DateTime dt;
            if (DateTime.TryParse(s, out dt))
            {
                exps._startDate = dt;
                exps._startDate = dt.AddDays(1);
                return true;
            }
            return false;
        }
        private bool SearchAmount(Expense exps, string s)
        {
            Regex r = new Regex(@"^[0-9]*(?:\,[0-9]*)?$");
            if (r.IsMatch(s))
            {
                exps._amount = double.Parse(s);
                return true;
            }
            return false;
        }
        private bool SearchGop(Expense exps)
        {
            foreach (string gopList in _gopExample)
            {
                string[] tab = gopList.Split('|');
                if (tab.Length > 1 && tab[1].Contains(exps.Name.ToLower()))
                {
                    exps.StrGop = tab[0];
                    return true;
                }
            }
            return false;
        }
        #endregion
    }
}
