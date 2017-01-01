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

namespace Droid_financial
{
    // TODO
    /*
     * controler que les montants sont bien exportés dans la bonne devise
     * Ajouter l'impression
     * vérifier que l'import fonctionne
     */

    public class ProjectFinancial
    {
        #region Enum
        public enum TypeAccount
        {
            NONE,
            FRIEND,
            PERSONNAL,
            PROFESSIONNAL
        }
        #endregion

        #region Attribute
        private List<User> _users;
        private List<Movement> _movements;
        private List<Change> _changes;
        private List<Refund> _refunds;
        private List<User> _userGiver;
        private List<User> _userReceiver;
        private string _name;
        private string _path;
        private TypeAccount _typeAcc;
        private string _currencyDefault;
        private string _currencyProject;
        private List<string> _lstCurrencyNames;
        private List<int> _lstCurrencyWeigh;
        private float _solde;
        private DateTime _startDate;
        private DateTime _endDate;
        private float _expenses;
        private int[] _nbUserPerPeriods;
        private double[] _amountPerPeriods;
        private List<DateTime> _listDateBornes;
        private DateTime _startJalon;
        private bool _paramsSetAutomatialy;        
        #endregion

        #region Properties
        public bool ParamsSetAutomaticaly
        {
            get { return _paramsSetAutomatialy; }
            set { _paramsSetAutomatialy = value; }
        }
        public float Expenses
        {
            get { return _expenses; }
            set { _expenses = value; }
        }
        public bool HasMultipleCurrency
        {
            get 
            {
                string cur = null;
                foreach (Movement mvt in _movements)
                {
                    if (string.IsNullOrEmpty(cur)) cur = mvt.Currency;
                    else if (!cur.Equals(mvt.Currency)) return true;
                }
                return false;
            }
        }
        public float Solde
        {
            get { return _solde; }
            set { _solde = value; }
        }
        public string Path
        {
            get { return _path; }
            set { _path = value; }
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
                foreach (Movement mvt in Movements) if (_endDate > mvt.EndDate) _endDate = mvt.EndDate;
                return _endDate;
            }
            set { _endDate = value; }
        }
        public DateTime StartDate
        {
            get
            {
                _startDate = DateTime.MaxValue;
                foreach (Movement mvt in Movements) if (_startDate > mvt.StartDate) _startDate = mvt.StartDate;
                return _startDate;
            }
            set { _startDate = value; }
        }
        public List<User> Users
        {
            get { return _users; }
            set { _users = value; }
        }
        public List<Movement> Movements
        {
            //get { return _movements.OrderBy(x => x.StrGop).ToList(); }
            get { return _movements; }
            set 
            { 
                _movements = value;
                UpdateSolde();
            }
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
        #endregion

        #region Constructor
        public ProjectFinancial()
        {
            Users = new List<User>();
            Movements = new List<Movement>();
            Changes = new List<Change>();
            Refunds = new List<Refund>();
            _lstCurrencyNames = new List<string>();
            _lstCurrencyWeigh = new List<int>();
            _currencyDefault = "EUR";
            _solde = 0;
            _name = "DefaultProject_" + DateTime.Now.ToString();
            _startDate = DateTime.Now.AddDays(-42);
            _endDate = DateTime.Now.AddDays(42);
            _paramsSetAutomatialy = true;
        }
        public ProjectFinancial(string path)
        {
            Users = new List<User>();
            Movements = new List<Movement>();
            Changes = new List<Change>();
            Refunds = new List<Refund>();
            _lstCurrencyNames = new List<string>();
            _lstCurrencyWeigh = new List<int>();
            _currencyDefault = "EUR";
            _solde = 0;
            _name = "DefaultProject_" + DateTime.Now.ToString();
            _startDate = DateTime.Now.AddDays(-42);
            _endDate = DateTime.Now.AddDays(42);
            _paramsSetAutomatialy = true;

            this.Path = path;
            LoadProject();
        }
        public ProjectFinancial(XmlReader node)
        {
            _name = "DefaultProject_" + DateTime.Now.ToString();
            _startDate = DateTime.Now.AddDays(-42);
            _endDate = DateTime.Now.AddDays(42);
            _paramsSetAutomatialy = true;
            ProjectLoadNode(node);
        }
        #endregion

        #region Methods public
        public void Save()
        {
            using (StreamWriter sw = new StreamWriter(_path))
            {
                sw.WriteLine("<project name=\"" + _name + "\" type=\"" + _typeAcc + "\" startdate=\"" + StartDate.ToShortDateString() + "\" enddate=\"" + EndDate.ToShortDateString() +"\" >");
                foreach (User user in Users)
                {
                    sw.WriteLine(user.ToXml());
                }
                foreach (Movement mvt in Movements)
                {
                    sw.WriteLine(mvt.ToXml());
                }
                foreach (Change chg in Changes)
                {
                    sw.WriteLine(chg.ToXml());
                }
                foreach (Refund rfd in Refunds)
                {
                    sw.WriteLine(rfd.ToXml());
                }
                sw.WriteLine("</project>");
            }
        }
        public void Balance()
        {
            foreach (User user in Users) user.Movements.Clear();
            CalculateExpenses();
            CalculateLoans();
            CalculateRefund();
        }
        public User GetUser(string userName)
        {
            string str;
            foreach (User usr in Users)
            {
                str = usr.Firstname + " " + usr.Name;
                if (userName.Trim().Equals(str.Trim())) return usr;
            }
            return null;
        }
        public string ExportXML()
        {
            return BuildExportXml();
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
        #endregion

        #region Methods private
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
            float expense = 0;
            string currentCurrency = (_currencyProject == null ? _currencyDefault : _currencyProject);
            _expenses = 0;

            // initialisation
            foreach (User user in Users)
            {
                user.Solde = 0;
                user.SoldeSimulation = 0;
                user.SumExpances = 0;
                user.Currency = CurrencyUsed;
            }
            // for each movement add the amount on the user that do it
            foreach (Movement mvt in Movements)
            {
                _expenses += mvt.Convert(GetChange(currentCurrency, mvt.Currency), currentCurrency);
                foreach (User user in Users)
                {
                    if (mvt.UserId.Contains(user.ID))
                    {
                        Movement tmpMvt = mvt.Clone() as Movement;
                        tmpMvt.SubMovement = false;
                        expense = mvt.Convert(Change.Find(Changes, mvt.Currency, CurrencyUsed), CurrencyUsed) / mvt.UserId.Count;
                        user.Solde += expense;
                        user.SoldeSimulation += expense;
                        user.SumExpances += expense;
                        tmpMvt.Amount = expense;
                        if (tmpMvt.Amount != 0) user.Movements.Add(tmpMvt);
                    }
                }
            }
        }
        private void CalculateLoans()
        {
            CalculateIntervals();
            if (_listDateBornes != null && _listDateBornes.Count > 0)
            {
                CalculateImpactMvt();
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
                        User.GetUser(Users, oldRfd.Receiver).Solde -= oldRfd.Amount;
                        User.GetUser(Users, oldRfd.Receiver).SoldeSimulation -= oldRfd.Amount;
                        User.GetUser(Users, oldRfd.Giver).Solde += oldRfd.Amount;
                        User.GetUser(Users, oldRfd.Giver).SoldeSimulation += oldRfd.Amount;
                    }
                }
            }
            Refunds = newListRfd;
        }
        private void CalculateNewExchanges()
        {
            int indexReceiver = 0;
            BuildUserLists();
            foreach (User user in _userGiver)
            {
                RefundUser(user, ref indexReceiver);
            }
        }
        private void CalculateIntervals()
        {
            // get the list of intervals
            _listDateBornes = new List<DateTime>();
            foreach (User user in _users)
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
        private void CalculateUserPerIntervals(List<User> lstUsers, Movement mvt)
        {
            _nbUserPerPeriods = new int[_listDateBornes.Count];
            _amountPerPeriods = new double[_listDateBornes.Count];
            for (int i = 0; i < _nbUserPerPeriods.Length; i++) _nbUserPerPeriods[i] = 0;
            for (int i = 0; i < _amountPerPeriods.Length; i++) _amountPerPeriods[i] = 0;

            // get the nb of participant in each interval
            foreach (User user in lstUsers)
            {
                if (mvt.AllParticipant || mvt.UserIdParticipant.Contains(user.ID))
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
        private void CalculateSumPerPeriodWithoutPermanentMvt(Movement mvt)
        {
            for (int i = 1; i < _listDateBornes.Count; i++)
            {
                // we are exactly in the period. 
                if (_listDateBornes[i - 1] <= mvt.StartDate && _listDateBornes[i] >= mvt.EndDate) _amountPerPeriods[i] += mvt.Convert(Change.Find(Changes, mvt.Currency, CurrencyUsed), CurrencyUsed);
                // out of the period, nothing to do
                else if (_listDateBornes[i - 1] > mvt.EndDate || _listDateBornes[i] < mvt.StartDate) continue;
                // we cut the period after
                else if (_listDateBornes[i - 1] <= mvt.StartDate && _listDateBornes[i] < mvt.EndDate)
                {
                    double extraitLength = (_listDateBornes[i] - mvt.StartDate).TotalDays;
                    double periodLength = (mvt.EndDate - mvt.StartDate).TotalDays;
                    float val = mvt.Convert(Change.Find(Changes, mvt.Currency, CurrencyUsed), CurrencyUsed);
                    _amountPerPeriods[i] += (val * extraitLength) / (periodLength);
                }
                // we cut the period before
                else if (_listDateBornes[i - 1] > mvt.StartDate && _listDateBornes[i] >= mvt.EndDate)
                {
                    double extraitLength = (mvt.EndDate - _listDateBornes[i - 1]).TotalDays;
                    double periodLength = (mvt.EndDate - mvt.StartDate).TotalDays;
                    float val = mvt.Convert(Change.Find(Changes, mvt.Currency, CurrencyUsed), CurrencyUsed);
                    _amountPerPeriods[i] += (float)(val * extraitLength) / (periodLength);
                }
                // we cut the period on the middle
                else if (_listDateBornes[i - 1] > mvt.StartDate && _listDateBornes[i] <= mvt.EndDate)
                {
                    double extraitLength = (_listDateBornes[i] - _listDateBornes[i - 1]).TotalDays;
                    double periodLength = (mvt.EndDate - mvt.StartDate).TotalDays;
                    float val = mvt.Convert(Change.Find(Changes, mvt.Currency, CurrencyUsed), CurrencyUsed);
                    _amountPerPeriods[i] += (float)(val * extraitLength) / (periodLength);
                }
                // this case the mvt have bornes extract project... not managed case.
                else
                {
                }
            }
        }
        private void CalculateImpactPeriodOnUser(Movement mvt)
        {
            // finaly, attribute the amount per user
            _startJalon = _listDateBornes[0];
            for (int i = 1; i < _listDateBornes.Count; i++)
            {
                foreach (User user in Users)
                {
                    if (mvt.UserIdParticipant.Contains(user.ID) || mvt.AllParticipant)
                    {
                        foreach (ICalendar pp in user.Calendars)
                        {
                            if (pp.Text.Equals(_name))
                            {
                                if (pp.BeginDate <= _startJalon && pp.EndDate >= _listDateBornes[i])
                                {
                                    Movement tmpMvt = mvt.Clone() as Movement;
                                    tmpMvt.SubMovement = true;
                                    user.Solde -= (float)(_amountPerPeriods[i] / _nbUserPerPeriods[i]);
                                    user.SoldeSimulation -= (float)(_amountPerPeriods[i] / _nbUserPerPeriods[i]);
                                    tmpMvt.Amount = (float)(_amountPerPeriods[i] / _nbUserPerPeriods[i]);
                                    foreach (Movement m in user.Movements)
                                    {
                                        if (m.ID == tmpMvt.ID && m.SubMovement == tmpMvt.SubMovement)
                                        {
                                            tmpMvt.Amount += m.Amount;
                                            user.Movements.Remove(m);
                                            break;
                                        }
                                    }
                                    if (tmpMvt.Amount != 0) user.Movements.Add(tmpMvt);
                                }
                            }
                        }
                    }
                }
                _startJalon = _listDateBornes[i];
            }
        }        
        private void CalculateImpactMvt()
        {
            foreach (Movement mvt in _movements)
            {
                if (!mvt.IsPartial) CalculateImpactPermanentMvt(mvt);
                else CalculateImpactCalendarMvt(mvt);
            }
        }
        private void CalculateImpactPermanentMvt(Movement mvt)
        {
            bool checkDate = false;
            foreach (User user in _users)
            {
                checkDate = false;
                foreach (ICalendar cal in user.Calendars) if ((mvt.EndDate <= cal.EndDate && mvt.EndDate >= cal.BeginDate) || (mvt.StartDate >= cal.BeginDate && mvt.StartDate <= cal.EndDate)) checkDate = true;

                if (checkDate)
                { 
                    if (mvt.AllParticipant)
                    {
                        Movement tmpMvt = mvt.Clone() as Movement;
                        tmpMvt.SubMovement = true;
                        user.Solde -= mvt.Amount / _users.Count;
                        user.SoldeSimulation -= mvt.Amount / _users.Count;
                        tmpMvt.Amount = (float)(mvt.Amount / _users.Count);
                        foreach (Movement m in user.Movements)
                        {
                            if (m.ID == tmpMvt.ID && m.SubMovement == tmpMvt.SubMovement)
                            {
                                tmpMvt.Amount += m.Amount;
                                user.Movements.Remove(m);
                                break;
                            }
                        }
                        if (tmpMvt.Amount != 0) user.Movements.Add(tmpMvt);
                    }
                    else if (mvt.UserIdParticipant.Contains(user.ID))
                    {
                        Movement tmpMvt = mvt.Clone() as Movement;
                        tmpMvt.SubMovement = true;
                        user.Solde -= mvt.Amount / mvt.UserIdParticipant.Count;
                        user.SoldeSimulation -= mvt.Amount / mvt.UserIdParticipant.Count;
                        tmpMvt.Amount = (float)(mvt.Amount / mvt.UserIdParticipant.Count);
                        foreach (Movement m in user.Movements)
                        {
                            if (m.ID == tmpMvt.ID && m.SubMovement == tmpMvt.SubMovement)
                            {
                                tmpMvt.Amount += m.Amount;
                                user.Movements.Remove(m);
                                break;
                            }
                        }
                        if (tmpMvt.Amount != 0) user.Movements.Add(tmpMvt);
                    }
                }
            }
        }
        private void CalculateImpactCalendarMvt(Movement mvt)
        {
            if (mvt.AllParticipant) CalculateForAll(mvt);
            else CalculateForPartial(mvt);

            CalculateSumPerPeriodWithoutPermanentMvt(mvt);
            CalculateImpactPeriodOnUser(mvt);
        }
        private void CalculateForAll(Movement mvt)
        {
            CalculateUserPerIntervals(Users, mvt);
        }
        private void CalculateForPartial(Movement mvt)
        {
            List<User> lstUsers = new List<User>();
            foreach (User user in _users)
            {
                if (mvt.UserIdParticipant.Contains(user.ID))
                {
                    lstUsers.Add(user);
                }
            }
            CalculateUserPerIntervals(lstUsers, mvt);
        }

        private void RefundUser(User user, ref int indexReceiver)
        {
            int watchDog = 10000;
            float rest;
            Refund r;
            while (user.SoldeSimulation <= -0.01 && watchDog > 0)
            {
                watchDog--;
                for (int i = 0; i < _userReceiver.Count; i++)
                {
                    if (_userReceiver[i].SoldeSimulation > 0)
                    {
                        indexReceiver = i;
                        break;
                    }
                }
                if (indexReceiver < _userReceiver.Count)
                {
                    r = new Refund();
                    r.Receiver = _userReceiver[indexReceiver].ID;
                    r.Giver = user.ID;
                    rest = user.SoldeSimulation + _userReceiver[indexReceiver].SoldeSimulation;
                    if (rest > 0) // receiver must have more money
                    {
                        r.Amount = -user.SoldeSimulation;
                        _userReceiver[indexReceiver].SoldeSimulation += user.SoldeSimulation;
                        user.SoldeSimulation = 0;
                    }
                    else if (rest == 0) // receiver had all money 
                    {
                        r.Amount = -user.SoldeSimulation;
                        _userReceiver[indexReceiver].SoldeSimulation = 0;
                        user.SoldeSimulation = 0;
                    }
                    else // receiver ok, giver have to refund another receiver
                    {
                        r.Amount = _userReceiver[indexReceiver].SoldeSimulation;
                        _userReceiver[indexReceiver].SoldeSimulation = 0;
                        user.SoldeSimulation = rest;
                    }
                    _refunds.Add(r);
                }
                else return;
            }
        }
        private void BuildUserLists()
        {
            _userGiver = new List<User>();
            _userReceiver = new List<User>();
            foreach (User user in Users)
            {
                if (user.Solde > 0) _userReceiver.Add(user);
                if (user.Solde < 0) _userGiver.Add(user);
            }
            _userGiver = _userGiver.OrderBy(x => x.Solde).ToList();
            _userReceiver = _userReceiver.OrderByDescending(x => x.Solde).ToList();
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
            _movements.Clear();
            _users.Clear();
            _changes.Clear();
            _lstCurrencyWeigh.Clear();
            _lstCurrencyNames.Clear();
        }
        private void GetDefaultCurrency()
        {
            foreach (Movement mvt in Movements)
            {
                if (!_lstCurrencyNames.Contains(mvt.Currency)) 
                {
                    _lstCurrencyNames.Add(mvt.Currency);
                    _lstCurrencyWeigh.Add(0);
                }
                for(int i=0 ; i < _lstCurrencyNames.Count ; i++)
                {
                    if (_lstCurrencyNames[i].Equals(mvt.Currency))
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
            _solde = 0;
            foreach (Movement mvt in _movements)
            {
                foreach (Change chg in Changes)
                {
                    if (chg.Currency1.Equals(mvt.Currency) && chg.Currency2.Equals(this.CurrencyUsed))
                    {
                        _solde += mvt.Convert(chg, this.CurrencyUsed);
                        break;
                    }
                }
            }
        }
        private void ParseFile()
        {
            XmlTextReader textReader = new XmlTextReader(_path);
            if (File.Exists(_path))
            {
                try
                {
                    while (textReader.Read())
                    {
                        XmlNodeType nType = textReader.NodeType;
                        if (nType == XmlNodeType.Element && textReader.Name.Equals("user")) Users.Add(new User(textReader));
                        else if (nType == XmlNodeType.Element && textReader.Name.Equals("project")) ProjectLoadNode(textReader);
                        else if (nType == XmlNodeType.Element && textReader.Name.Equals("refund")) _refunds.Add(new Refund(textReader));
                        else if (nType == XmlNodeType.Element && textReader.Name.Equals("movement")) _movements.Add(new Movement(textReader));
                        else if (nType == XmlNodeType.Element && textReader.Name.Equals("change"))
                        {
                            Changes.Add(new Change(textReader, true));
                            Changes.Add(new Change(textReader, false));
                        }
                    }
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message);
                }
            }
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
            List<Movement.GOP> lstGop = new List<Movement.GOP>();
            foreach (Movement mvt in Movements) if (!lstGop.Contains(mvt.Gop)) lstGop.Add(mvt.Gop);
            float sum;
            sb.AppendLine(";;;;;;;;;;");
            foreach (Movement.GOP g in lstGop)
            {
                sum = 0;
                foreach (Movement mvt in Movements)
                {
                    if (mvt.Gop.Equals(g))
                    {
                        sum += mvt.Amount;
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
                    User.GetUser(Users, r.Giver).Firstname + " " + User.GetUser(Users, r.Giver).Name,
                    User.GetUser(Users, r.Receiver).Firstname + " " + User.GetUser(Users, r.Receiver).Name,
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
            foreach (User usr in Users)
            {
                foreach (Movement mvt in usr.Movements)
                {
                    line = "user;";
                    line += usr.Firstname + " " + usr.Name + ";";
                    line += mvt.UserId.Contains(usr.ID) ? "expense;" : "participant;";
                    if (mvt.UserId.Contains(usr.ID) && !mvt.SubMovement) line += "bill;";
                    else if (mvt.UserId.Contains(usr.ID)) line += "real expense;";
                    else line += "participation;";
                    line += string.Format("{0};{1};{2}", mvt.Amount, mvt.Name, mvt.Description);
                    sb.AppendLine(line);
                }
            }
            return sb.ToString();
        }
        
        private string BuildExportXml()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<financial>");
            sb.AppendLine(BuildExportXmlResume());
            sb.AppendLine(BuildExportXmlGop());
            sb.AppendLine(BuildExportXmlLoans());
            sb.AppendLine(BuildExportXmlUsers());
            sb.AppendLine("\t<credentials value=\"Powered by TOBI Assistant, at your service.\"/>");
            sb.AppendLine("</financial>");
            return sb.ToString();
        }
        private string BuildExportXmlResume()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format("\t<project name=\"{0}\" start=\"{1}\" end=\"{2}\" />", Name, StartDate.ToShortDateString(), EndDate.ToShortDateString()));
            return sb.ToString();
        }
        private string BuildExportXmlGop()
        {
            StringBuilder sb = new StringBuilder();
            List<Movement.GOP> lstGop = new List<Movement.GOP>();
            foreach (Movement mvt in Movements) if (!lstGop.Contains(mvt.Gop)) lstGop.Add(mvt.Gop);
            float sum;
            foreach (Movement.GOP g in lstGop)
            {
                sum = 0;
                foreach(Movement mvt in Movements)
                {
                    if (mvt.Gop.Equals(g))
                    {
                        sum += mvt.Amount;
                    }
                }
                sb.AppendLine(string.Format("\t<operation_group name=\"{0}\" amount=\"{1}\" />", g.ToString(), String.Format("{0:0.00}", sum)));
            }
            return sb.ToString();
        }
        private string BuildExportXmlLoans()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Refund r in Refunds)
            {
                sb.AppendLine(String.Format("\t<refund from=\"{0}\" to=\"{1}\" amount=\"{2}\" />", 
                    User.GetUser(Users, r.Giver).Firstname + " " + User.GetUser(Users, r.Giver).Name,
                    User.GetUser(Users, r.Receiver).Firstname + " " + User.GetUser(Users, r.Receiver).Name,
                    String.Format("{0:0.00}", r.Amount))
                    );
            }
            return sb.ToString();
        }
        private string BuildExportXmlUsers()
        {
            StringBuilder sb = new StringBuilder();
            float sum;
            string line;
            foreach (User usr in Users)
            {
                sum = 0;
                foreach (Movement mvt in usr.Movements) if (mvt.SubMovement) sum += mvt.Amount;
                sb.AppendLine(string.Format("\t<user firstname=\"{0}\" name=\"{1}\" total=\"{2}\">", usr.Firstname, usr.Name, String.Format("{0:0.00}", sum)));
                foreach (Movement mvt in usr.Movements.OrderBy(x => x.SubMovement).ToList())
                {
                    line = "\t\t<movement ";
                    if (mvt.UserId.Contains(usr.ID) && !mvt.SubMovement) line += "type=\"bill\" ";
                    else if (mvt.UserId.Contains(usr.ID)) line += "type=\"real expense\" ";
                    else line += "type=\"participation\" ";
                    line += string.Format("amount=\"{0}\" name=\"{1}\" description=\"{2}\"", String.Format("{0:0.00}", mvt.Amount), mvt.Name, mvt.Description);
                    line += " />";
                    sb.AppendLine(line);
                }
                sb.AppendLine("\t</user>");
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
            List<Movement.GOP> lstGop = new List<Movement.GOP>();
            foreach (Movement mvt in Movements) if (!lstGop.Contains(mvt.Gop)) lstGop.Add(mvt.Gop);
            float sum;
            sb.Append("____________________________________________________________________________\r\n");
            sb.AppendLine("\r\n\tOperation group : \r\n");
            foreach (Movement.GOP g in lstGop)
            {
                sum = 0;
                foreach (Movement mvt in Movements)
                {
                    if (mvt.Gop.Equals(g))
                    {
                        sum += mvt.Amount;
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
                    User.GetUser(Users, r.Giver).Firstname + " " + User.GetUser(Users, r.Giver).Name,
                    User.GetUser(Users, r.Receiver).Firstname + " " + User.GetUser(Users, r.Receiver).Name,
                    String.Format("{0:0.00}", r.Amount))
                    );
            }
            return sb.ToString();
        }
        private string BuildExportTxtUsers()
        {
            StringBuilder sb = new StringBuilder();
            float sum;
            string line;
            sb.Append("____________________________________________________________________________\r\n");
            sb.Append("\r\n\tUser details :\r\n");
            foreach (User usr in Users)
            {
                sum = 0;
                foreach (Movement mvt in usr.Movements) if (mvt.SubMovement) sum += mvt.Amount;
                sb.AppendLine(string.Format("\r\n\t\t . Resume for {0} {1} (total of expenses {2})\r\n", usr.Firstname, usr.Name, String.Format("{0:0.00}", sum)));
                foreach (Movement mvt in usr.Movements.OrderBy(x => x.SubMovement).ToList())
                {
                    line = " - ";
                    if (mvt.UserId.Contains(usr.ID) && !mvt.SubMovement) line += "Paid for ";
                    else if (mvt.UserId.Contains(usr.ID)) line += "Real cost for ";
                    else line += "Participation of ";
                    if (!string.IsNullOrEmpty(mvt.Description)) line += string.Format("{1} {0} ({2})", String.Format("{0:0.00}", mvt.Amount), mvt.Name, mvt.Description);
                    else line += string.Format("{1} {0}", String.Format("{0:0.00}", mvt.Amount), mvt.Name);
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
            float sum = 0;
            foreach (var v in _movements) sum += v.Amount;
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

            List<Movement.GOP> lstGop = new List<Movement.GOP>();
            foreach (Movement mvt in Movements) if (!lstGop.Contains(mvt.Gop)) lstGop.Add(mvt.Gop);
            float sum;
            foreach (Movement.GOP g in lstGop)
            {
                sum = 0;
                foreach (Movement mvt in Movements)
                {
                    if (mvt.Gop.Equals(g))
                    {
                        sum += mvt.Amount;
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
            foreach (Movement mvt in Movements)
            {
                users = string.Empty;
                foreach (var v in Users.Where(i => mvt.UserId.Contains(i.ID))) users += v.Firstname + " " + v.Name.ToUpper() + " / ";
                if (users.EndsWith(" / ")) users = users.Substring(0, users.Length - 3);
                sb.AppendLine(string.Format(" <tr><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td></tr>", mvt.Name, mvt.Amount, mvt.Currency, users));
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
                    User.GetUser(Users, r.Giver).Firstname + " " + User.GetUser(Users, r.Giver).Name,
                    User.GetUser(Users, r.Receiver).Firstname + " " + User.GetUser(Users, r.Receiver).Name,
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
            float sum;
            string line;
            foreach (User usr in Users)
            {
                sum = 0;
                foreach (Movement mvt in usr.Movements) if (mvt.SubMovement) sum += mvt.Amount;

                start = DateTime.MaxValue;
                foreach (ICalendar cal in usr.Calendars) if (cal.BeginDate < start) start = cal.BeginDate;
                if (start < this.StartDate) start = this.StartDate;

                end = DateTime.MinValue;
                foreach (ICalendar cal in usr.Calendars) if (cal.EndDate > end) end = cal.EndDate;
                if (end > this.EndDate) end = this.EndDate;


                sb.AppendLine("\t<table class=\"detail_table\">");
                sb.AppendLine(string.Format("\t\t<tr><th collspan=\"3\">&nbsp;{0} [ {1} - {2} ] {3} total expenses : {4}</th></tr>", usr.Firstname, start.ToShortDateString(), end.ToShortDateString(), usr.Name, String.Format("{0:0.00}", sum)));
                sb.AppendLine("\t\t<tr><th>Type</th><th>Amount</th><th>Name</th><th>Description</th></tr>");
                
                foreach (Movement mvt in usr.Movements.OrderBy(x => x.SubMovement).ToList())
                {
                    line = "\t\t<tr><td>";
                    if (mvt.UserId.Contains(usr.ID) && !mvt.SubMovement) line += "bill</td>";
                    else if (mvt.UserId.Contains(usr.ID)) line += "real expense</td>";
                    else line += "participation</td>";
                    line += string.Format("<td>{0}</td><td>{1}</td><td>{2}</td>", String.Format("{0:0.00}", mvt.Amount), mvt.Name, mvt.Description);
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
