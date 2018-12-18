using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static Droid.financial.CRE;

namespace Droid.financial
{
    public class ParserCreditAgricole : Parser
    {
        #region Attributes
        private const string HEADER = "Date;Libellé;Débit Euros;Crédit Euros;";
        private static FinancialActivity _extractedActivity;
        private static string _path;
        private static bool _header;
        private static bool _inMovement;
        private static DateTime _extractDate;
        private static DateTime _startDate;
        private static DateTime _endDate;
        private static DateTime _soldeDate;
        #endregion

        #region Properties
        public static FinancialActivity ExtractedActivity
        {
            get { return _extractedActivity; }
            set { _extractedActivity = value; }
        }
        public static DateTime ExtractDate
        {
            get { return _extractDate; }
            set { _extractDate = value; }
        }
        public static DateTime EndDate
        {
            get { return _endDate; }
            set { _endDate = value; }
        }
        public static DateTime StartDate
        {
            get { return _startDate; }
            set { _startDate = value; }
        }
        public static DateTime SoldeDate
        {
            get { return _soldeDate; }
            set { _soldeDate = value; }
        }
        #endregion

        #region Methods public
        public new static void Process(string filePath)
        {
            _path = filePath;
            _extractedActivity = new FinancialActivity(filePath);
            if (!string.IsNullOrEmpty(_path) && File.Exists(_path))
            {
                Extract();
            }
        }
        #endregion

        #region Methods private
        private static void Extract()
        {
            int watchdog;
            string line;
            _header = true;
            _inMovement = false;
            using (StreamReader sr = new StreamReader(_path, Encoding.GetEncoding("iso-8859-15")))
            {
                while(sr.Peek() != -1)
                { 
                    line = sr.ReadLine();
                    if (_inMovement)
                    {
                        watchdog = 37;
                        while (true)
                        { 
                            line += sr.ReadLine();
                            watchdog--;
                            if (string.IsNullOrEmpty(line) || line.Count(s => s == '"') >= 2)
                            {
                                break;
                            }
                            if (watchdog < 0) { new Exception("loop in movment parsing"); }
                        }
                    }
                    Parse(line);
                    if (!_header)
                    {
                        _inMovement = true;
                    }
                }
            }
        }
        private static void Parse(string line)
        {
            if (string.IsNullOrEmpty(line)) { return; }
            else if (_header && line.StartsWith("Téléchargement du")) { ExtractExportDate(line); }
            else if (_header && (line.ToLower().StartsWith("m.") || line.ToLower().StartsWith("mr.") || line.ToLower().StartsWith("mme.") || line.ToLower().StartsWith("mlle."))) { ExtractOwner(line); }
            else if (_header && line.StartsWith("CCHQ")) { ExtractAccountNumber(line); }
            else if (_header && line.StartsWith("Liste des opérations")) { ExtractDates(line); }
            else if (_header && line.StartsWith("Solde au")) { ExtractSolde(line); }
            else if (line.Equals(HEADER)) { _header = false; }
            else if (!_header) { ExtractMovement(line); }
        }
        private static void ExtractExportDate(string line)
        {
            DateTime.TryParse(line.Replace("Téléchargement du ", string.Empty).Replace(';', ' ').Trim(), out _extractDate);
        }
        private static void ExtractDates(string line)
        {
            string[] dump = line.Split(' ');
            if( dump.Count() > 9)
            { 
                DateTime.TryParse(dump[7], out _startDate);
                DateTime.TryParse(dump[10].Replace(";", string.Empty), out _endDate);
            }
        }
        private static void ExtractOwner(string line)
        {
            string name = line.Substring(5, line.Length - 5).Trim();
            if (!string.IsNullOrEmpty(name))
            { 
                EntityFinancialDecorator user = new EntityFinancialDecorator();
                //user.FirstName = new Droid.People.FirstName(name.Split(' ')[1]);
                user.Name = name.Split(' ')[0];
                _extractedActivity.Entities.Add(user);
            }
        }
        private static void ExtractAccountNumber(string line)
        {
            string number = line.Split(' ')[line.Split(' ').Count() - 1];
            number = number.Replace(";", string.Empty);
            _extractedActivity.Name = number;
        }
        private static void ExtractSolde(string line)
        {
            double val = 0;
            string solde = line.Split(':')[1];
            string date = line.Split(':')[0];
            date = date.Split(' ')[date.Split(' ').Count() - 2];
            DateTime dateCri = DateTime.MaxValue;
            DateTime.TryParse(date, out dateCri);

            _extractedActivity.CurrencyProject = solde.Substring(solde.Length - 3, 3);
            double.TryParse(solde.Replace(_extractedActivity.CurrencyProject, string.Empty).Trim(), out val);
            _extractedActivity.ListCRI.Add(new CRI() { Amount = val, Date = dateCri });
        }
        private static void ExtractMovement(string line)
        {
            float tmpAmount = 0;
            string[] dump = line.Split(';');
            DateTime tmpDate = DateTime.MinValue;
            Movement mvt = new Movement();

            DateTime.TryParse(dump[0], out tmpDate);
            if (tmpDate !=DateTime.MinValue) { mvt.StartDate = tmpDate; }

            mvt.Name = dump[1];
            mvt.Description = dump[1];
            if (string.IsNullOrEmpty(dump[2]) && !string.IsNullOrEmpty(dump[3]))
            {
                float.TryParse(dump[3], out tmpAmount);
                mvt.Amount = tmpAmount;
            }
            if (!string.IsNullOrEmpty(dump[2]) && string.IsNullOrEmpty(dump[3]))
            {
                float.TryParse(dump[2], out tmpAmount);
                mvt.Amount = -tmpAmount;
            }

            CRE exp = new CRE();
            exp.Gop = DetermineGOP(mvt.Name);
            exp.Movements.Add(mvt);
            exp.Amount = tmpAmount;
            exp.Description = mvt.Name;
            exp.IsPartial = false;
            _extractedActivity.ListCRE.Add(exp);

            //Expense activityExpense = _extractedActivity.ListExpenses.Where(e => e.Gop == exp.Gop).FirstOrDefault();
            //if (activityExpense == null) { _extractedActivity.ListExpenses.Add(exp); }
            //else { activityExpense.Movements.Add(mvt); }
        }
        private static GOP DetermineGOP(string desc)
        {
            return GOP.OTHER;
        }
        #endregion

        #region Event
        #endregion
    }
}
