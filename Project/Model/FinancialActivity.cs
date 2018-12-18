using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using Newtonsoft.Json;
using System.Xml.Serialization;
using System.Reflection;
using Droid.scheduler;

namespace Droid.financial
{
    // TODO
    /*
     * controler que les montants sont bien exportés dans la bonne devise
     * Ajouter l'impression
     * vérifier que l'import fonctionne
     */

    public class FinancialActivity
    {
        #region Attribute
        private string _id;
        private List<EntityFinancialDecorator> _entities;
        private List<CRE> _listCRE;
        private List<CRI> _listCRI;
        private List<Change> _changes;
        private List<Refund> _refunds;
        private List<EntityFinancialDecorator> _entityGiver;
        private List<EntityFinancialDecorator> _entityReceiver;
        private List<Bill> _bills;
        private Bill _currentBill;
        private List<Specification> _specifications;
        private List<Product> _products;
        private string _name;
        private string _pathActivity;
        private TypeAccount _typeAcc;
        private string _currencyDefault;
        private string _currencyProject;
        private List<string> _lstCurrencyNames;
        private List<int> _lstCurrencyWeigh;
        private double _solde;
        private double _soldeInitial;
        private DateTime _startDate;
        private DateTime _endDate;
        private double _expenses;
        private int[] _nbUserPerPeriods;
        private double[] _amountPerPeriods;
        private List<DateTime> _listDateBornes;
        private DateTime _startJalon;
        private bool _paramsSetAutomatialy;
        #endregion

        #region Properties
        public Bill CurrentBill
        {
            get { return _currentBill; }
            set { _currentBill = value; }
        }
        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public bool ParamsSetAutomaticaly
        {
            get { return _paramsSetAutomatialy; }
            set { _paramsSetAutomatialy = value; }
        }
        public double Expenses
        {
            get { return _expenses; }
            set { _expenses = value; }
        }
        public bool HasMultipleCurrency
        {
            get 
            {
                string cur = null;
                foreach (CRE exps in _listCRE)
                {
                    if (string.IsNullOrEmpty(cur)) cur = exps.Currency;
                    else if (!cur.Equals(exps.Currency)) return true;
                }
                return false;
            }
        }
        public double Solde
        {
            get
            {
                if (ListCRI == null || ListCRI.Count == 0) { return 0; }
                else return ListCRI.OrderBy(l => l.Date).ToList().FirstOrDefault().Amount;
            }
        }
        public string PathActivity
        {
            get { return _pathActivity; }
            set { _pathActivity = value; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public TypeAccount TypeAcc
        {
            get { return _typeAcc; }
            set { _typeAcc = value; }
        }
        public DateTime EndDate
        {
            get
            {
                _endDate = DateTime.MinValue;
                foreach (CRE exps in ListCRE) if (_endDate > exps.EndDate) _endDate = exps.EndDate;
                return _endDate;
            }
            set { _endDate = value; }
        }
        public DateTime StartDate
        {
            get
            {
                _startDate = DateTime.MaxValue;
                foreach (CRE exps in ListCRE) if (_startDate > exps.StartDate) _startDate = exps.StartDate;
                return _startDate;
            }
            set { _startDate = value; }
        }
        public List<EntityFinancialDecorator> Entities
        {
            get { return _entities; }
            set { _entities = value; }
        }
        public List<CRE> ListCRE
        {
            //get { return _movements.OrderBy(x => x.StrGop).ToList(); }
            get { return _listCRE; }
            set 
            { 
                _listCRE = value;
                UpdateSolde();
            }
        }
        public List<CRI> ListCRI
        {
            get { return _listCRI; }
            set { _listCRI = value; }
        }
        public List<Change> Changes
        {
            get { return _changes; }
            set 
            {
                _changes = value;
                UpdateSolde();
            }
        }
        public List<Refund> Refunds
        {
            //get { return _refunds.OrderBy(x => x.Giver).ToList(); }
            get { return _refunds; }
            set { _refunds = value; }
        }
        /// <summary>
        /// Currency defined by the user
        /// </summary>
        public string CurrencyProject
        {
            get { return _currencyProject; }
            set 
            {
                _currencyProject = value;
                UpdateSolde();
            }
        }
        /// <summary>
        /// Default currency calculated by the most used one in project movements
        /// </summary>
        public string CurrencyDefault
        {
            get { return _currencyDefault; }
            set 
            {
                _currencyDefault = value;
                UpdateSolde();
            }
        }
        /// <summary>
        /// return the used currency. default one if user haven't define one
        /// </summary>
        public string CurrencyUsed
        {
            get
            {
                if (CurrencyProject == null) return CurrencyDefault;
                else return CurrencyProject;
            }
        }
        public double SoldeInitial
        {
            get { return _soldeInitial; }
            set { _soldeInitial = value; }
        }
        public List<Specification> Specifications
        {
            get { return _specifications; }
            set { _specifications = value; }
        }
        public List<Bill> Bills
        {
            get { return _bills; }
            set { _bills = value; }
        }
        public List<Product> Products
        {
            get { return _products; }
            set { _products = value; }
        }
        public int BillNexId
        {
            get
            {
                int id = 1;
                if (_bills?.Count > 0)
                {
                    foreach (var item in _bills)
                    {
                        if (item.Id > id) { id = item.Id; }
                    }
                }
                return id;
            }
        }
        public int CurrentTurnover
        {
            get
            {
                int ct = 0;
                foreach (var item in _bills.Where(b => b.CreateDate.Year == DateTime.Now.Year).ToList())
                {
                    ct += item.Amount;
                }
                return ct;
            }
        }
        #endregion

        #region Constructor
        public FinancialActivity(string path)
        {
            _pathActivity = path;

            Init();
            LoadProject();

            // TODO : ARRRRRRRRRRRRRGH but do it !!!!!!!!!!!!!
            _entities = new List<EntityFinancialDecorator>()
            {
                new EntityFinancialDecorator()
                {
                    Name = "BIMANDCO",
                    Address = "PARC ECO NORMANDIE",
                    City = "76430 Saint-romain-de-colbosc",
                    Siret = "810 000 943 00011"
                },
                new EntityFinancialDecorator()
                {
                    Name = "Thibault MONTAUFRAY",
                    Address = "2 Rue Léon Chapelle",
                    City = "76300 Sotteville Lès Rouen",
                    Siret = "838 095 909 00019"
                },
                new EntityFinancialDecorator()
                {
                    Name = "ExTeam",
                    Address = "53 RUE BAUDIN",
                    City = "92300 LEVALLOIS-PERRET",
                    Siret = "791 667 116 00036"
                }
            };

            _specifications = new List<Specification>()
            {
                new Specification()
                {
                    CreationDate = new DateTime(2018, 04, 01),
                    From = _entities[1],
                    To = _entities[2],
                    MaxDays = 45,
                    Deposit = 0,
                    Status = Status.PENDING,
                    Products = new List<Product>()
                    {
                        new Product()
                        {
                            Quantity = 10,
                            Unit = Unit.DAY,
                            Description = "Assistance à la gestion du parc informatique",
                            Cost = 480,
                            Name = "DevOps"
                        }
                    }
                }
            };
        }
        #endregion

        #region Methods public
        public void Save(string path = "")
        {
            if (!string.IsNullOrEmpty(path)) { _pathActivity = path; }
            SaveFile(_pathActivity);
        }
        public void Balance()
        {
            foreach (EntityFinancialDecorator user in Entities) user.Movements.Clear();
            CalculateExpenses();
            CalculateLoans();
            CalculateRefund();
        }
        public EntityFinancialDecorator GetEntityProfile(string userName)
        {
            string str;
            foreach (EntityFinancialDecorator usr in Entities)
            {
                str = usr.GetName();
                if (userName.Trim().Equals(str.Trim())) return usr;
            }
            return null;
        }
        public double GetTax(DateTime date)
        {
            int cumul = 0;
            foreach (var bill in _bills.Where(b => b.CreateDate.Year == date.Year && b.CreateDate.Month == date.Month).ToList())
            {
                cumul += bill.Amount;
            }
            return cumul * 0.25;
        }
        public string ExportXML()
        {
            string serializedObject = string.Empty;

            XmlSerializer xsSubmit = new XmlSerializer(typeof(FinancialActivity));
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
        public string ExportTXT()
        {
            return BuildExportTxt();
        }
        public string ExportCSV()
        {
            return BuildExportCsv();
        }
        public string ExportWEB()
        {
            return BuildExportWeb();
        }
        public string ExportPDF(string path)
        {
            return BuildExportPdf(path);
        }
        public string ExportJson()
        {
            return JsonConvert.SerializeObject(this);
        }
        public string ExportCsv()
        {
            string separator = ";";
            string ret = string.Empty;

            PropertyInfo[] props = typeof(FinancialActivity).GetProperties();
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
        #endregion

        #region Methods private
        private void Init()
        {
            _specifications = new List<Specification>();
            _bills = new List<Bill>();
            _products = new List<Product>()
            {
                new Product()
                {
                    Name = "DevOps",
                    Description = "Assistance à la gestion du parc informatique",
                    Quantity = 18,
                    Cost = 270,
                    Unit = Unit.DAY
                }
            };

            Random rand = new Random((int)DateTime.Now.Ticks);
            _id = string.Format("financial.{0}-{1}-{2}", rand.Next(), (int)DateTime.Now.Ticks, rand.Next());

            Entities = new List<EntityFinancialDecorator>();
            ListCRE = new List<CRE>();
            ListCRI = new List<CRI>();
            Changes = new List<Change>();
            Refunds = new List<Refund>();

            _lstCurrencyNames = new List<string>();
            _lstCurrencyWeigh = new List<int>();
            _currencyDefault = "EUR";
            _currencyProject = _currencyDefault;
            _solde = 0;
            _soldeInitial = 0;
            _name = "DefaultProject_" + DateTime.Now.ToString("yyyy_MM_dd_hh_mm_ss");
            _startDate = DateTime.Now.AddDays(-42);
            _endDate = DateTime.Now.AddDays(42);
            _paramsSetAutomatialy = true;
        }
        private void SaveFile(string path)
        {
            if (!string.IsNullOrEmpty(path))
            { 
                FileInfo fi = new FileInfo(path);
                if (!Directory.Exists(fi.DirectoryName))
                {
                    Directory.CreateDirectory(path);
                }
                //if (!Directory.Exists(Path.Combine(path, _id)))
                //{
                //    Directory.CreateDirectory(Path.Combine(path, _id));
                //}
                //string filePath = Path.Combine(path, string.Format("{0}//{0}.xml", _id));
                using (StreamWriter sw = new StreamWriter(path, false))
                {
                    sw.Write(ExportJson());
                }
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
        private void ProjectLoadNode(XmlReader node)
        {
            int count = 0;
            for (int i = 0; i < node.AttributeCount; i++)
            {
                try
                {
                    node.MoveToAttribute(i);
                    switch (node.Name.ToLower())
                    {
                        case "name": this.Name = node.Value; count++; break;
                        case "type": this.TypeAcc = (TypeAccount)Enum.Parse(typeof(TypeAccount),node.Value); break;
                        case "startdate": this.StartDate = DateTime.Parse(node.Value); count++; break;
                        case "enddate": this.EndDate = DateTime.Parse(node.Value); count++; break;
                    }
                }
                catch (Exception)
                {
                }
            }
            if (count == 3) _paramsSetAutomatialy = false;
        }
        
        private void CalculateExpenses()
        {
            string currentCurrency = (_currencyProject == null ? _currencyDefault : _currencyProject);
            _expenses = 0;

            // initialisation
            foreach (EntityFinancialDecorator user in Entities)
            {
                user.Solde = 0;
                user.SoldeSimulation = 0;
                user.SumExpances = 0;
                user.Currency = CurrencyUsed;
            }
            // for each movement add the amount on the user that do it
            foreach (CRE exps in ListCRE)
            {
                _expenses += exps.Convert(GetChange(currentCurrency, exps.Currency), currentCurrency);
                foreach (EntityFinancialDecorator user in Entities)
                {
                    // TODO : adapt the calcul with the new dll Droid.people
                    //if (exps.UserId.Contains(user.ID))
                    //{
                    //    Expense tmpExps = exps.Clone() as Expense;
                    //    tmpExps.SubMovement = false;
                    //    expense = exps.Convert(Change.Find(Changes, exps.Currency, CurrencyUsed), CurrencyUsed) / exps.UserId.Count;
                    //    user.Solde += expense;
                    //    user.SoldeSimulation += expense;
                    //    user.SumExpances += expense;
                    //    tmpExps.Amount = expense;
                    //    if (tmpExps.Amount != 0) user.Movements.Add(tmpExps);
                    //}
                }
            }
        }
        private void CalculateLoans()
        {
            CalculateIntervals();
            if (_listDateBornes != null && _listDateBornes.Count > 0)
            {
                CalculateImpactExps();
            }
        }
        private void CalculateRefund()
        {
            CalculateOldExchanges();
            CalculateNewExchanges();
        }
        private void CalculateOldExchanges()
        {
            List<Refund> newListRfd = new List<Refund>();
            foreach (Refund oldRfd in Refunds)
            {
                if (oldRfd.CurrentStatus != Refund.Status.NONE)
                {
                    newListRfd.Add(oldRfd);
                    if (oldRfd.CurrentStatus == Refund.Status.CANCELED)
                    {
                    }
                    else if ((oldRfd.CurrentStatus == Refund.Status.GIFT)  || (oldRfd.CurrentStatus == Refund.Status.REFUNDED))
                    {
                        EntityFinancialDecorator.GetUser(Entities, oldRfd.Receiver).Solde -= oldRfd.Amount;
                        EntityFinancialDecorator.GetUser(Entities, oldRfd.Receiver).SoldeSimulation -= oldRfd.Amount;
                        EntityFinancialDecorator.GetUser(Entities, oldRfd.Giver).Solde += oldRfd.Amount;
                        EntityFinancialDecorator.GetUser(Entities, oldRfd.Giver).SoldeSimulation += oldRfd.Amount;
                    }
                }
            }
            Refunds = newListRfd;
        }
        private void CalculateNewExchanges()
        {
            int indexReceiver = 0;
            BuildUserLists();
            foreach (EntityFinancialDecorator user in _entityGiver)
            {
                RefundUser(user, ref indexReceiver);
            }
        }
        private void CalculateIntervals()
        {
            // get the list of intervals
            _listDateBornes = new List<DateTime>();
            foreach (EntityFinancialDecorator user in _entities)
            {
                foreach (ICalendar pp in user.Calendars)
                {
                    if (pp.Text.Equals(Name))
                    {
                        if (!_listDateBornes.Contains(pp.BeginDate)) _listDateBornes.Add(pp.BeginDate);
                        if (!_listDateBornes.Contains(pp.EndDate)) _listDateBornes.Add(pp.EndDate);
                    }
                }
            }
            _listDateBornes.Sort();
        }
        private void CalculateUserPerIntervals(List<EntityFinancialDecorator> lstUsers, CRE exps)
        {
            _nbUserPerPeriods = new int[_listDateBornes.Count];
            _amountPerPeriods = new double[_listDateBornes.Count];
            for (int i = 0; i < _nbUserPerPeriods.Length; i++) _nbUserPerPeriods[i] = 0;
            for (int i = 0; i < _amountPerPeriods.Length; i++) _amountPerPeriods[i] = 0;

            // get the nb of participant in each interval
            foreach (EntityFinancialDecorator user in lstUsers)
            {
                if (exps.AllParticipant || exps.Movements.Where(p => p.UserId.Equals(user.Id)).Count() > 0)
                {
                    _startJalon = _listDateBornes[0];
                    foreach (ICalendar pp in user.Calendars)
                    {
                        if (pp.Text.Equals(_name))
                        {
                            for (int i = 1; i < _listDateBornes.Count; i++)
                            {
                                if (_startJalon >= pp.BeginDate && _listDateBornes[i] <= pp.EndDate) _nbUserPerPeriods[i]++;
                                _startJalon = _listDateBornes[i];
                            }
                        }
                    }
                }
            }
        }
        private void CalculateSumPerPeriodWithoutPermanentExps(CRE exps)
        {
            for (int i = 1; i < _listDateBornes.Count; i++)
            {
                // we are exactly in the period. 
                if (_listDateBornes[i - 1] <= exps.StartDate && _listDateBornes[i] >= exps.EndDate) _amountPerPeriods[i] += exps.Convert(Change.Find(Changes, exps.Currency, CurrencyUsed), CurrencyUsed);
                // out of the period, nothing to do
                else if (_listDateBornes[i - 1] > exps.EndDate || _listDateBornes[i] < exps.StartDate) continue;
                // we cut the period after
                else if (_listDateBornes[i - 1] <= exps.StartDate && _listDateBornes[i] < exps.EndDate)
                {
                    double extraitLength = (_listDateBornes[i] - exps.StartDate).TotalDays;
                    double periodLength = (exps.EndDate - exps.StartDate).TotalDays;
                    double val = exps.Convert(Change.Find(Changes, exps.Currency, CurrencyUsed), CurrencyUsed);
                    _amountPerPeriods[i] += (val * extraitLength) / (periodLength);
                }
                // we cut the period before
                else if (_listDateBornes[i - 1] > exps.StartDate && _listDateBornes[i] >= exps.EndDate)
                {
                    double extraitLength = (exps.EndDate - _listDateBornes[i - 1]).TotalDays;
                    double periodLength = (exps.EndDate - exps.StartDate).TotalDays;
                    double val = exps.Convert(Change.Find(Changes, exps.Currency, CurrencyUsed), CurrencyUsed);
                    _amountPerPeriods[i] += (double)(val * extraitLength) / (periodLength);
                }
                // we cut the period on the middle
                else if (_listDateBornes[i - 1] > exps.StartDate && _listDateBornes[i] <= exps.EndDate)
                {
                    double extraitLength = (_listDateBornes[i] - _listDateBornes[i - 1]).TotalDays;
                    double periodLength = (exps.EndDate - exps.StartDate).TotalDays;
                    double val = exps.Convert(Change.Find(Changes, exps.Currency, CurrencyUsed), CurrencyUsed);
                    _amountPerPeriods[i] += (double)(val * extraitLength) / (periodLength);
                }
                // this case the exps have bornes extract project... not managed case.
                else
                {
                }
            }
        }
        private void CalculateImpactPeriodOnUser(CRE exps)
        {
            // finaly, attribute the amount per user
            _startJalon = _listDateBornes[0];
            for (int i = 1; i < _listDateBornes.Count; i++)
            {
                foreach (EntityFinancialDecorator user in Entities)
                {
                    if (exps.Movements.Where(p => p.UserId.Equals(user.Id)).Count() > 0 || exps.AllParticipant)
                    {
                        foreach (ICalendar pp in user.Calendars)
                        {
                            if (pp.Text.Equals(_name))
                            {
                                if (pp.BeginDate <= _startJalon && pp.EndDate >= _listDateBornes[i])
                                {
                                    CRE tmpExps = exps.Clone() as CRE;
                                    tmpExps.SubMovement = true;
                                    user.Solde -= (double)(_amountPerPeriods[i] / _nbUserPerPeriods[i]);
                                    user.SoldeSimulation -= (double)(_amountPerPeriods[i] / _nbUserPerPeriods[i]);
                                    tmpExps.Amount = (double)(_amountPerPeriods[i] / _nbUserPerPeriods[i]);
                                    foreach (CRE m in user.Movements)
                                    {
                                        if (m.Id == tmpExps.Id && m.SubMovement == tmpExps.SubMovement)
                                        {
                                            tmpExps.Amount += m.Amount;
                                            user.Movements.Remove(m);
                                            break;
                                        }
                                    }
                                    if (tmpExps.Amount != 0) user.Movements.Add(tmpExps);
                                }
                            }
                        }
                    }
                }
                _startJalon = _listDateBornes[i];
            }
        }        
        private void CalculateImpactExps()
        {
            foreach (CRE exps in _listCRE)
            {
                if (!exps.IsPartial) CalculateImpactPermanentExps(exps);
                else CalculateImpactCalendarExps(exps);
            }
        }
        private void CalculateImpactPermanentExps(CRE exps)
        {
            bool checkDate = false;
            foreach (EntityFinancialDecorator user in _entities)
            {
                checkDate = false;
                foreach (ICalendar cal in user.Calendars) if ((exps.EndDate <= cal.EndDate && exps.EndDate >= cal.BeginDate) || (exps.StartDate >= cal.BeginDate && exps.StartDate <= cal.EndDate)) checkDate = true;

                if (checkDate)
                { 
                    if (exps.AllParticipant)
                    {
                        CRE tmpExps = exps.Clone() as CRE;
                        tmpExps.SubMovement = true;
                        user.Solde -= exps.Amount / _entities.Count;
                        user.SoldeSimulation -= exps.Amount / _entities.Count;
                        tmpExps.Amount = (double)(exps.Amount / _entities.Count);
                        foreach (CRE m in user.Movements)
                        {
                            if (m.Id == tmpExps.Id && m.SubMovement == tmpExps.SubMovement)
                            {
                                tmpExps.Amount += m.Amount;
                                user.Movements.Remove(m);
                                break;
                            }
                        }
                        if (tmpExps.Amount != 0) user.Movements.Add(tmpExps);
                    }
                    else if (exps.Movements.Where(p => p.UserId.Equals(user.Id)).Count() > 0)
                    {
                        CRE tmpExps = exps.Clone() as CRE;
                        tmpExps.SubMovement = true;
                        user.Solde -= exps.Amount / exps.Movements.Count;
                        user.SoldeSimulation -= exps.Amount / exps.Movements.Count;
                        tmpExps.Amount = (double)(exps.Amount / exps.Movements.Count);
                        foreach (CRE m in user.Movements)
                        {
                            if (m.Id == tmpExps.Id && m.SubMovement == tmpExps.SubMovement)
                            {
                                tmpExps.Amount += m.Amount;
                                user.Movements.Remove(m);
                                break;
                            }
                        }
                        if (tmpExps.Amount != 0) user.Movements.Add(tmpExps);
                    }
                }
            }
        }
        private void CalculateImpactCalendarExps(CRE exps)
        {
            if (exps.AllParticipant) CalculateForAll(exps);
            else CalculateForPartial(exps);

            CalculateSumPerPeriodWithoutPermanentExps(exps);
            CalculateImpactPeriodOnUser(exps);
        }
        private void CalculateForAll(CRE exps)
        {
            CalculateUserPerIntervals(Entities, exps);
        }
        private void CalculateForPartial(CRE exps)
        {
            List<EntityFinancialDecorator> lstUsers = new List<EntityFinancialDecorator>();
            foreach (EntityFinancialDecorator user in _entities)
            {
                if (exps.Movements.Where(p => p.UserId.Equals(user.Id)).Count() > 0)
                {
                    lstUsers.Add(user);
                }
            }
            CalculateUserPerIntervals(lstUsers, exps);
        }

        private void RefundUser(EntityFinancialDecorator user, ref int indexReceiver)
        {
            int watchDog = 10000;
            double rest;
            Refund r;
            while (user.SoldeSimulation <= -0.01 && watchDog > 0)
            {
                watchDog--;
                for (int i = 0; i < _entityReceiver.Count; i++)
                {
                    if (_entityReceiver[i].SoldeSimulation > 0)
                    {
                        indexReceiver = i;
                        break;
                    }
                }
                if (indexReceiver < _entityReceiver.Count)
                {
                    r = new Refund();
                    r.Receiver = _entityReceiver[indexReceiver].Id;
                    r.Giver = user.Id;
                    rest = user.SoldeSimulation + _entityReceiver[indexReceiver].SoldeSimulation;
                    if (rest > 0) // receiver must have more money
                    {
                        r.Amount = -user.SoldeSimulation;
                        _entityReceiver[indexReceiver].SoldeSimulation += user.SoldeSimulation;
                        user.SoldeSimulation = 0;
                    }
                    else if (rest == 0) // receiver had all money 
                    {
                        r.Amount = -user.SoldeSimulation;
                        _entityReceiver[indexReceiver].SoldeSimulation = 0;
                        user.SoldeSimulation = 0;
                    }
                    else // receiver ok, giver have to refund another receiver
                    {
                        r.Amount = _entityReceiver[indexReceiver].SoldeSimulation;
                        _entityReceiver[indexReceiver].SoldeSimulation = 0;
                        user.SoldeSimulation = rest;
                    }
                    _refunds.Add(r);
                }
                else return;
            }
        }
        private void BuildUserLists()
        {
            _entityGiver = new List<EntityFinancialDecorator>();
            _entityReceiver = new List<EntityFinancialDecorator>();
            foreach (EntityFinancialDecorator user in Entities)
            {
                if (user.Solde > 0) _entityReceiver.Add(user);
                if (user.Solde < 0) _entityGiver.Add(user);
            }
            _entityGiver = _entityGiver.OrderBy(x => x.Solde).ToList();
            _entityReceiver = _entityReceiver.OrderByDescending(x => x.Solde).ToList();
        }
        private void LoadProject()
        {
            ClearAllLists();
            ParseFile();
            GetDefaultCurrency();
            Balance();
        }
        private void ClearAllLists()
        {
            _listCRE.Clear();
            _entities.Clear();
            _changes.Clear();
            _lstCurrencyWeigh.Clear();
            _lstCurrencyNames.Clear();
        }
        private void GetDefaultCurrency()
        {
            foreach (CRE exps in ListCRE)
            {
                if (!_lstCurrencyNames.Contains(exps.Currency)) 
                {
                    _lstCurrencyNames.Add(exps.Currency);
                    _lstCurrencyWeigh.Add(0);
                }
                for(int i=0 ; i < _lstCurrencyNames.Count ; i++)
                {
                    if (_lstCurrencyNames[i].Equals(exps.Currency))
                    {
                        _lstCurrencyWeigh[i]++;
                        break;
                    }
                }
            }
            int targetIndex = 0;
            int maxVal = 0;
            for (int i = 0; i < _lstCurrencyWeigh.Count; i++)
            {
                if (_lstCurrencyWeigh[i] > maxVal)
                {
                    maxVal = _lstCurrencyWeigh[i];
                    targetIndex = i;
                }
            }
            _currencyDefault = targetIndex < _lstCurrencyNames.Count ? _lstCurrencyNames[targetIndex] : "XXX";
            UpdateSolde();
        }
        private void UpdateSolde()
        {
            _solde = _soldeInitial;
            foreach (CRE exps in _listCRE)
            {
                foreach (Change chg in Changes)
                {
                    if (chg.Currency1.Equals(exps.Currency) && chg.Currency2.Equals(this.CurrencyUsed))
                    {
                        _solde += exps.Convert(chg, this.CurrencyUsed);
                        break;
                    }
                }
            }
        }
        private void Import(FinancialActivity source, FinancialActivity target)
        {
            target._bills = source._bills;
            target._amountPerPeriods = source._amountPerPeriods;
            target._changes = source._changes;
            target._currencyDefault = source._currencyDefault;
            target._currencyProject = source._currencyProject;
            target._endDate = source._endDate;
            target._expenses = source._expenses;
            target._id = source._id;
            target._listDateBornes = source._listDateBornes != null ?  new List<DateTime>(source._listDateBornes) : new List<DateTime>();
            target._lstCurrencyNames = source._lstCurrencyNames != null ? new List<string>( source._lstCurrencyNames) : new List<string>();
            target._lstCurrencyWeigh = source._lstCurrencyWeigh != null ? new List<int>(source._lstCurrencyWeigh) : new List<int>();
            target._listCRE = source._listCRE != null ? new List<CRE>(source._listCRE) : new List<CRE>();
            target._name = source._name;
            target._nbUserPerPeriods = source._nbUserPerPeriods;
            target._paramsSetAutomatialy = source._paramsSetAutomatialy;
            target._pathActivity = source._pathActivity;
            target._refunds = source._refunds;
            target._solde = source._solde;
            target._startDate = source._startDate;
            target._startJalon = source._startJalon;
            target._typeAcc = source._typeAcc;
            target._entityGiver = source._entityGiver != null ? new List<EntityFinancialDecorator>(source._entityGiver) : new List<EntityFinancialDecorator>();
            target._entityReceiver = source._entityReceiver != null ? new List<EntityFinancialDecorator>(source._entityReceiver) : new List<EntityFinancialDecorator>();
            target._entities = source._entities != null ? new List<EntityFinancialDecorator>(source._entities) : new List<EntityFinancialDecorator>();

            source = null;
        }
        private void ParseFile()
        {
            if (Directory.Exists(_pathActivity))
            {
                foreach (string file in Directory.GetFiles(_pathActivity))
                {
                    if (Path.GetFileName(file).StartsWith("financial.") && Path.GetExtension(file).Equals(".xml"))
                    {
                        using (StreamReader sr = new StreamReader(file))
                        {
                            var json = sr.ReadToEnd();
                            var data = JsonConvert.DeserializeObject<FinancialActivity>(json);
                            if (data != null)
                            {
                                Import(data, this);
                            }
                        }
                        break;
                    }
                }
            }
            else if (File.Exists(_pathActivity))
            {
                using (StreamReader sr = new StreamReader(_pathActivity))
                {
                    var json = sr.ReadToEnd();
                    var data = JsonConvert.DeserializeObject<FinancialActivity>(json);
                    if (data != null) { Import(data, this); }
                }
            }
            else if (!File.Exists(_pathActivity))
            {
                this.Save(_pathActivity);
            }

            //if (!string.IsNullOrEmpty(_path))
            //{ 
            //    XmlTextReader textReader = new XmlTextReader(_path);
            //    if (File.Exists(_path))
            //    {
            //        try
            //        {
            //            while (textReader.Read())
            //            {
            //                XmlNodeType nType = textReader.NodeType;
            //                if (nType == XmlNodeType.Element && textReader.Name.Equals("user")) Users.Add(new User(textReader));
            //                else if (nType == XmlNodeType.Element && textReader.Name.Equals("project")) ProjectLoadNode(textReader);
            //                else if (nType == XmlNodeType.Element && textReader.Name.Equals("refund")) _refunds.Add(new Refund(textReader));
            //                else if (nType == XmlNodeType.Element && textReader.Name.Equals("movement"))
            //                {
            //                    Movement exps = new Movement();
            //                    exps.Load(_path);
            //                    _movements.Add(exps);
            //                }
            //                else if (nType == XmlNodeType.Element && textReader.Name.Equals("change"))
            //                {
            //                    Changes.Add(new Change(textReader, true));
            //                    Changes.Add(new Change(textReader, false));
            //                }
            //            }
            //        }
            //        catch (Exception exp)
            //        {
            //            MessageBox.Show(exp.Message);
            //        }
            //    }
            //}
        }
        private Change GetChange(string cur1, string cur2)
        {
            if (cur1 == cur2) return new Change(cur1, cur2, 1);
            foreach (Change chg in Changes)
            {
                if (cur1.Equals(chg.Currency1) && cur2.Equals(chg.Currency2))
                {
                    return chg;
                }
                else if (cur2.Equals(chg.Currency1) && cur1.Equals(chg.Currency2))
                {
                    return chg;
                }
            }
            MessageBox.Show("Cannot convert the movement. There is no taux change set for " + cur1.ToString() + "/" + cur2.ToString());
            return null;
        }

        private string BuildExportCsv()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(BuildExportCsvResume());
            sb.Append(BuildExportCsvGop());
            sb.Append(BuildExportCsvLoans());
            sb.Append(BuildExportCsvUsers());
            sb.AppendLine("Powered by TOBI Assistant, at your service.;;;;;;;;;;");
            return sb.ToString();
        }
        private string BuildExportCsvResume()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format("{0};{1};{2};", Name, StartDate.ToShortDateString(), EndDate.ToShortDateString()));
            return sb.ToString();
        }
        private string BuildExportCsvGop()
        {
            StringBuilder sb = new StringBuilder();
            List<CRE.GOP> lstGop = new List<CRE.GOP>();
            foreach (CRE exps in ListCRE) if (!lstGop.Contains(exps.Gop)) lstGop.Add(exps.Gop);
            double sum;
            sb.AppendLine(";;;;;;;;;;");
            foreach (CRE.GOP g in lstGop)
            {
                sum = 0;
                foreach (CRE exps in ListCRE)
                {
                    if (exps.Gop.Equals(g))
                    {
                        sum += exps.Amount;
                    }
                }
                sb.AppendLine(string.Format("operation_group;{0};{1};", g.ToString(), String.Format("{0:0.00}", sum)));
            }
            return sb.ToString();
        }
        private string BuildExportCsvLoans()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(";;;;;;;;;;");
            foreach (Refund r in Refunds)
            {
                sb.AppendLine(String.Format("refund;{0};{1};{2}",
                    EntityFinancialDecorator.GetUser(Entities, r.Giver).GetName(),
                    EntityFinancialDecorator.GetUser(Entities, r.Receiver).GetName(),
                    String.Format("{0:0.00}", r.Amount))
                    );
            }
            return sb.ToString();
        }
        private string BuildExportCsvUsers()
        {
            StringBuilder sb = new StringBuilder();
            string line;
            sb.AppendLine(";;;;;;;;;;");
            foreach (EntityFinancialDecorator usr in Entities)
            {
                foreach (CRE exps in usr.Movements)
                {
                    line = "user;";
                    line += usr.GetName() + ";";
                    // TODO : adapt the calcul with the new dll Droid.people
                    //line += exps.UserId.Contains(usr.ID) ? "expense;" : "participant;";
                    //if (exps.UserId.Contains(usr.ID) && !exps.SubMovement) line += "bill;";
                    //else if (exps.UserId.Contains(usr.ID)) line += "real expense;";
                    //else line += "participation;";

                    line += "participation;";
                    line += string.Format("{0};{1};{2}", exps.Amount, exps.Name, exps.Description);
                    sb.AppendLine(line);
                }
            }
            return sb.ToString();
        }
        
        private string BuildExportTxt()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(BuildExportTxtResume());
            sb.AppendLine(BuildExportTxtGop());
            sb.AppendLine(BuildExportTxtLoans());
            sb.AppendLine(BuildExportTxtUsers());
            sb.AppendLine("\r\n____________________________________________________________________________");
            sb.AppendLine("Powered by TOBI Assistant, at your service.");
            return sb.ToString();
        }
        private string BuildExportTxtResume()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("____________________________________________________________________________\r\n\r\n");
            sb.AppendLine(string.Format("\t\t\t {0} ({1}-{2})", Name, StartDate.ToShortDateString(), EndDate.ToShortDateString()));
            sb.Append("____________________________________________________________________________");
            return sb.ToString();
        }
        private string BuildExportTxtGop()
        {
            StringBuilder sb = new StringBuilder();
            List<CRE.GOP> lstGop = new List<CRE.GOP>();
            foreach (CRE exps in ListCRE) if (!lstGop.Contains(exps.Gop)) lstGop.Add(exps.Gop);
            double sum;
            sb.Append("____________________________________________________________________________\r\n");
            sb.AppendLine("\r\n\tOperation group : \r\n");
            foreach (CRE.GOP g in lstGop)
            {
                sum = 0;
                foreach (CRE exps in ListCRE)
                {
                    if (exps.Gop.Equals(g))
                    {
                        sum += exps.Amount;
                    }
                }
                sb.AppendLine(string.Format(" - {0} \t\t: \t{1}", g.ToString(), String.Format("{0:0.00}", sum)));
            }
            return sb.ToString();
        }
        private string BuildExportTxtLoans()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("____________________________________________________________________________\r\n");
            sb.Append("\r\n\tLoans : \r\n\r\n");
            foreach (Refund r in Refunds)
            {
                sb.AppendLine(String.Format(" - {0} => {1}\t\t{2}",
                    EntityFinancialDecorator.GetUser(Entities, r.Giver).GetName(),
                    EntityFinancialDecorator.GetUser(Entities, r.Receiver).GetName(),
                    String.Format("{0:0.00}", r.Amount))
                    );
            }
            return sb.ToString();
        }
        private string BuildExportTxtUsers()
        {
            StringBuilder sb = new StringBuilder();
            double sum;
            string line;
            sb.Append("____________________________________________________________________________\r\n");
            sb.Append("\r\n\tUser details :\r\n");
            foreach (EntityFinancialDecorator usr in Entities)
            {
                sum = 0;
                foreach (CRE exps in usr.Movements) if (exps.SubMovement) sum += exps.Amount;
                sb.AppendLine(string.Format("\r\n\t\t . Resume for {0} (total of expenses {1})\r\n", usr.GetName(), String.Format("{0:0.00}", sum)));
                foreach (CRE exps in usr.Movements.OrderBy(x => x.SubMovement).ToList())
                {
                    line = " - ";
                    // TODO : adapt the calcul with the new dll Droid.people
                    //if (exps.UserId.Contains(usr.ID) && !exps.SubMovement) line += "Paid for ";
                    //else if (exps.UserId.Contains(usr.ID)) line += "Real cost for ";
                    //else line += "Participation of ";
                    line += "Participation of ";

                    if (!string.IsNullOrEmpty(exps.Description)) line += string.Format("{1} {0} ({2})", String.Format("{0:0.00}", exps.Amount), exps.Name, exps.Description);
                    else line += string.Format("{1} {0}", String.Format("{0:0.00}", exps.Amount), exps.Name);
                    sb.AppendLine(line);
                };
            }
            return sb.ToString();
        }

        private string BuildExportWeb()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(BuildExportWebHeader());
            sb.AppendLine(BuildExportWebStyleSheet());
            sb.AppendLine(BuildExportWebResume());
            sb.AppendLine(BuildExportWebGop());
            sb.AppendLine(BuildExportMovementDetail());            
            sb.AppendLine(BuildExportWebLoans());
            sb.AppendLine(BuildExportWebUsers());
            sb.AppendLine(BuildExportWebFooter());
            return sb.ToString();
        }
        private string BuildExportWebHeader()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<html>                                  ");
            sb.AppendLine("	<head>                                 ");
            sb.AppendLine("		<title>" + Name + "</title> ");
            sb.AppendLine("		<style type=\"text/css\">          ");
            return sb.ToString();
        }
        private string BuildExportWebStyleSheet()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("			* {                            ");
            sb.AppendLine("				margin : 0px;              ");
            sb.AppendLine("				padding : 2px;             ");
            sb.AppendLine("				font-family: calibri;      ");
            sb.AppendLine("			}                              ");
            sb.AppendLine("			body {                         ");
            sb.AppendLine("				background-color:#333;     ");
            sb.AppendLine("			}                              ");
            sb.AppendLine("			table{                         ");
            sb.AppendLine("				margin : 24px;             ");
            sb.AppendLine("				background-color:#000;     ");
            sb.AppendLine("				color: #ddd;               ");
            sb.AppendLine("			}                              ");
            sb.AppendLine("			.header {                      ");
            sb.AppendLine("				font-family: arial;        ");
            sb.AppendLine("				height:180px;              ");
            sb.AppendLine("				background:#aaa;           ");
            sb.AppendLine("				color:#222;                ");
            //sb.AppendLine("				background-image:url(monurl.jpg);");
            sb.AppendLine("				opacity: 0.6;              ");
            sb.AppendLine("				background-size:100% 100%; ");
            sb.AppendLine("				font-size:60px;            ");
            sb.AppendLine("				font-weight:bold;          ");
            sb.AppendLine("			}                              ");
            sb.AppendLine("			.footer {                      ");
            sb.AppendLine("				font-family: arial;        ");
            sb.AppendLine("				background:#000;           ");
            sb.AppendLine("				color:#999;                ");
            sb.AppendLine("			}                              ");
            sb.AppendLine("			.description                   ");
            sb.AppendLine("			{                              ");
            sb.AppendLine("				height: 40px;              ");
            sb.AppendLine("				padding: 50px;             ");
            sb.AppendLine("				padding-left: 40px;        ");
            sb.AppendLine("				background:#ddd;           ");
            sb.AppendLine("				color:#000;                ");
            sb.AppendLine("			}                              ");
            sb.AppendLine("			.detail_table{                 ");
            sb.AppendLine("				background:#bbb;           ");
            sb.AppendLine("				color:#000;                ");
            sb.AppendLine("				border:1px solid #222;     ");
            sb.AppendLine("				text-align:left;           ");
            sb.AppendLine("				width:970px;               ");
            sb.AppendLine("			}                              ");
            sb.AppendLine("			.date{                         ");
            sb.AppendLine("				background:#bbb;           ");
            sb.AppendLine("				color:#000;                ");
            sb.AppendLine("				border:1px solid #222;     ");
            sb.AppendLine("				text-align:left;           ");
            sb.AppendLine("				width:970px;               ");
            sb.AppendLine("			}                              ");
            sb.AppendLine("			.ok{                           ");
            sb.AppendLine("				background:#666;           ");
            sb.AppendLine("			}                              ");
            return sb.ToString();
        }
        private string BuildExportWebResume()
        {
            double sum = 0;
            foreach (var v in _listCRE) sum += v.Amount;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("		</style>                           ");
            sb.AppendLine("	</head>                                ");
            sb.AppendLine("	<body>                                 ");
            sb.AppendLine("		<center>                           ");
            sb.AppendLine("			<table width=\"1024\">         ");
        
            sb.AppendLine("<tr class=\"header\"><td><br/><br/>&nbsp;&nbsp; " + Name + "</td></td>");
            sb.AppendLine("<tr><td>Dates</td></tr>");
            sb.AppendLine("<tr class=\"description\"><td>  ");

            sb.AppendLine("<table class=\"date\">         ");
            sb.AppendLine("	<tr>                        ");
            sb.AppendLine("		<td>                    ");
            sb.AppendLine("		<b>Start date</b>          ");
            sb.AppendLine("		<br/>" + StartDate.ToShortDateString());
            sb.AppendLine("		</td>                   ");
            sb.AppendLine("		<td>                    ");
            sb.AppendLine("		<b>End date</b>           ");
            sb.AppendLine("		<br/>" + EndDate.ToShortDateString());
            sb.AppendLine("		</td>                   ");
            sb.AppendLine("		<td>                    ");
            sb.AppendLine("		<b>Budget</b>           ");
            sb.AppendLine("		<br/>" + sum.ToString());
            sb.AppendLine("		</td>                   ");
            sb.AppendLine("	</tr>                       ");
            sb.AppendLine("</table>                     ");

            sb.AppendLine("</td></tr>                    ");
            return sb.ToString();
        }
        private string BuildExportWebGop()
        {
            StringBuilder sb = new StringBuilder();   
            sb.AppendLine("<tr><td>Operation groups</td></tr>");
            sb.AppendLine("<tr class=\"description\"><td>  ");
            sb.AppendLine("<table class=\"detail_table\">");
            sb.AppendLine("<tr><th>Operation group</th><th>Amount</th></tr>");

            List<CRE.GOP> lstGop = new List<CRE.GOP>();
            foreach (CRE exps in ListCRE) if (!lstGop.Contains(exps.Gop)) lstGop.Add(exps.Gop);
            double sum;
            foreach (CRE.GOP g in lstGop)
            {
                sum = 0;
                foreach (CRE exps in ListCRE)
                {
                    if (exps.Gop.Equals(g))
                    {
                        sum += exps.Amount;
                    }
                }
                sb.AppendLine(string.Format(" <tr><td>{0}</td><td>{1}</td></tr>", g.ToString(), String.Format("{0:0.00}", sum)));
            }

            sb.AppendLine("</table>");
            sb.AppendLine("</td></tr>                    ");
            return sb.ToString();
        }
        private string BuildExportMovementDetail()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<tr><td>Operation detail</td></tr>");
            sb.AppendLine("<tr class=\"description\"><td>  ");
            sb.AppendLine("<table class=\"detail_table\">");
            sb.AppendLine("<tr><th>Movement name</th><th>Amount</th><th>Currency</th><th>Paid by</th></tr>");

            string users = string.Empty;
            foreach (CRE exps in ListCRE)
            {
                users = string.Empty;
                // TODO : adapt the calcul with the new dll Droid.people
                //foreach (var v in Users.Where(i => exps.UserId.Contains(i.ID))) users += v.Firstname + " " + v.Name.ToUpper() + " / ";
                if (users.EndsWith(" / ")) users = users.Substring(0, users.Length - 3);
                sb.AppendLine(string.Format(" <tr><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td></tr>", exps.Name, exps.Amount, exps.Currency, users));
            }
            
            sb.AppendLine("</table>");
            sb.AppendLine("</td></tr>                    ");
            return sb.ToString();
        }
        private string BuildExportWebLoans()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<tr><td>Refunds</td></tr>");
            sb.AppendLine("<tr class=\"description\"><td>  ");
            sb.AppendLine("<table class=\"detail_table\">");
            sb.AppendLine("<tr><th>From</th><th>To</th><th>Amount</th></tr>");

            foreach (Refund r in Refunds)
            {
                sb.AppendLine(string.Format(" <tr><td>{0}</td><td>{1}</td><td>{2}</td></tr>",
                    EntityFinancialDecorator.GetUser(Entities, r.Giver).GetName(),
                    EntityFinancialDecorator.GetUser(Entities, r.Receiver).GetName(),
                    String.Format("{0:0.00}", r.Amount))
                    );
            }

            sb.AppendLine("</table>");
            sb.AppendLine("</td></tr>                    ");
            return sb.ToString();
        }
        private string BuildExportWebUsers()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<tr><td>User details</td></tr>");
            sb.AppendLine("<tr class=\"description\"><td>  ");

            DateTime start, end;
            double sum;
            string line;
            foreach (EntityFinancialDecorator usr in Entities)
            {
                sum = 0;
                foreach (CRE exps in usr.Movements) if (exps.SubMovement) sum += exps.Amount;

                start = DateTime.MaxValue;
                foreach (ICalendar cal in usr.Calendars) if (cal.BeginDate < start) start = cal.BeginDate;
                if (start < this.StartDate) start = this.StartDate;

                end = DateTime.MinValue;
                foreach (ICalendar cal in usr.Calendars) if (cal.EndDate > end) end = cal.EndDate;
                if (end > this.EndDate) end = this.EndDate;


                sb.AppendLine("\t<table class=\"detail_table\">");
                sb.AppendLine(string.Format("\t\t<tr><th collspan=\"3\">&nbsp;{0} [ {1} - {2} ] total expenses : {3}</th></tr>", usr.GetName(), start.ToShortDateString(), end.ToShortDateString(), String.Format("{0:0.00}", sum)));
                sb.AppendLine("\t\t<tr><th>Type</th><th>Amount</th><th>Name</th><th>Description</th></tr>");
                
                foreach (CRE exps in usr.Movements.OrderBy(x => x.SubMovement).ToList())
                {
                    line = "\t\t<tr><td>";
                    // TODO : adapt the calcul with the new dll Droid.people
                    //if (exps.UserId.Contains(usr.ID) && !exps.SubMovement) line += "bill</td>";
                    //else if (exps.UserId.Contains(usr.ID)) line += "real expense</td>";
                    //else line += "participation</td>";
                    line += "participation</td>";

                    line += string.Format("<td>{0}</td><td>{1}</td><td>{2}</td>", String.Format("{0:0.00}", exps.Amount), exps.Name, exps.Description);
                    sb.AppendLine(line);
                }
                sb.AppendLine("\t</table>");
            }
            
            sb.AppendLine("</td></tr>                    ");
            return sb.ToString();
        }
        private string BuildExportWebFooter()
        {
            StringBuilder sb = new StringBuilder();   
            sb.AppendLine("				<tr class=\"footer\"><td>Copyright @Tobi assistant 2015 at your service</td></tr> ");
            sb.AppendLine("			</table>                                                        ");
            sb.AppendLine("		</center>                                                           ");
            sb.AppendLine("	</body>                                                                 ");
            sb.AppendLine("</html>                                                                  ");
            return sb.ToString();
        }

        private string BuildExportPdf(string path)
        {
            Cursor.Current = Cursors.WaitCursor;

            Document document = new Document();
            //PdfWriter.GetInstance(document, new FileStream(Request.PhysicalApplicationPath + "\\MySamplePDF.pdf", FileMode.Create));
            PdfWriter.GetInstance(document, new FileStream(path, FileMode.Create));
            document.AddAuthor("Tobi assistant");
            document.Open();
            StyleSheet ss = new StyleSheet();
            HTMLWorker hw = new HTMLWorker(document);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(BuildExportWebHeader());
            //sb.AppendLine(BuildExportWebStyleSheet());
            sb.AppendLine(BuildExportWebResume());
            sb.AppendLine(BuildExportWebGop());
            sb.AppendLine(BuildExportMovementDetail());
            sb.AppendLine(BuildExportWebLoans());
            sb.AppendLine(BuildExportWebUsers());
            sb.AppendLine(BuildExportWebFooter());

            hw.Parse(new StringReader(sb.ToString()));
            BuildExportPdfStyleSheet(ss);
            document.Close();

            Cursor.Current = Cursors.Arrow;

            return string.Empty;
        }
        private void BuildExportPdfStyleSheet(StyleSheet ss)
        {
            ss.LoadStyle("*", "margin", "0px");
            ss.LoadStyle("*", "padding", "2px");
            ss.LoadStyle("*", "font-family", "calibri");

            ss.LoadStyle("body", "background-color", ":#333");

            ss.LoadStyle("table", "margin", "24px");
            ss.LoadStyle("table", "background-color", "#000");
            ss.LoadStyle("table", "color", "#ddd");

            ss.LoadStyle("header", "font-family", "arial");
            ss.LoadStyle("header", "height", "180px");
            ss.LoadStyle("header", "background", "#aaa");
            ss.LoadStyle("header", "color", "#222");
            ss.LoadStyle("header", "opacity", " 0.6");
            ss.LoadStyle("header", "background-size", "100% 100%");
            ss.LoadStyle("header", "font-size", "60px");
            ss.LoadStyle("header", "font-weight", "bold");

            ss.LoadStyle("footer", "font-family", " arial");
            ss.LoadStyle("footer", "background", "#000");
            ss.LoadStyle("footer", "color", "#999");

            ss.LoadStyle("description", "height", " 40px");
            ss.LoadStyle("description", "padding", " 50px");
            ss.LoadStyle("description", "padding-left", " 40px");
            ss.LoadStyle("description", "background", "#ddd");
            ss.LoadStyle("description", "color", "#000");

            ss.LoadStyle("detail_table", "background", "#bbb");
            ss.LoadStyle("detail_table", "color", "#000");
            ss.LoadStyle("detail_table", "border", "1px solid #222");
            ss.LoadStyle("detail_table", "text-align", "left");
            ss.LoadStyle("detail_table", "width", "970px");

            ss.LoadStyle("date", "background", "#bbb");
            ss.LoadStyle("date", "color", "#000");
            ss.LoadStyle("date", "border", "1px solid #222");
            ss.LoadStyle("date", "text-align", "left");
            ss.LoadStyle("date", "width", "970px");

            ss.LoadStyle("ok", "background", "#666");
        }
        #endregion
    }
}
