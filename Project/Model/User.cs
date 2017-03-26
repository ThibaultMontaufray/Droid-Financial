using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Xml;
using System.Text.RegularExpressions;

namespace Droid_financial
{
    public class User
    {
        #region Attribute
        private string _name;
        private string _firstname;
        private Color _color;
        private int _avatarIndex;
        private double _solde;
        private double _soldeSimulation;
        private double _sumExpances;
        private string _currency;
        private string _id;
        private List<ICalendar> _calendars;
        private List<Expense> _movements;
        #endregion

        #region Properties
        public List<ICalendar> Calendars
        {
            get { return _calendars; }
            set { _calendars = value; }
        }
        public double SumExpances
        {
            get { return _sumExpances; }
            set { _sumExpances = value; }
        }
        public string Currency
        {
            get { return _currency; }
            set { _currency = value; }
        }
        public double Solde
        {
            get { return _solde; }
            set { _solde = value; }
        }
        public double SoldeSimulation
        {
            get { return _soldeSimulation; }
            set { _soldeSimulation = value; }
        }
        public int AvatarIndex
        {
            get { return _avatarIndex; }
            set { _avatarIndex = value; }
        }
        public Color Color
        {
            get { return _color; }
            set { _color = value; }
        }
        public string Firstname
        {
            get { return _firstname; }
            set { _firstname = value; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string ID
        {
            get { return _id; }
            set { _id = value; }
        }
        public List<Expense> Movements
        {
            get { return _movements; }
            set { _movements = value; }
        }
        #endregion

        #region Constructor
        public User()
        {
            _movements = new List<Expense>();
            _id = DateTime.Now.GetHashCode().ToString();
            _calendars = new List<ICalendar>();
        }
        public User(XmlReader node)
        {
            string[] tab;
            _movements = new List<Expense>();
            _calendars = new List<ICalendar>();
            for (int i = 0; i < node.AttributeCount; i++)
            {
                try
                {
                    node.MoveToAttribute(i);
                    switch (node.Name.ToLower())
                    {
                        case "name": this.Name = node.Value; break;
                        case "firstname": this.Firstname = node.Value; break;
                        case "avatar": this.AvatarIndex = int.Parse(node.Value); break;
                        case "userid": this.ID = node.Value; break;
                        case "taux": this.Solde = double.Parse(node.Value); break;
                        case "color":
                            tab = node.Value.Split('|');
                            if (tab.Length == 5) this.Color = Color.FromArgb(int.Parse(tab[0]), int.Parse(tab[1]), int.Parse(tab[2]), int.Parse(tab[3]));
                            else this.Color = Color.Maroon;
                            break;
                        case "pjparticipations":
                            tab = node.Value.Split('|');
                            string[] tab2;
                            foreach (string item in tab)
                            {
                                tab2 = item.Split(';');
                                if (tab2.Length == 3)
                                {
                                    ICalendar pp = new ICalendar();
                                    pp.Text = tab2[0];
                                    pp.BeginDate = DateTime.Parse(tab2[1]);
                                    pp.EndDate = DateTime.Parse(tab2[2]);
                                    _calendars.Add(pp);
                                }
                            }
                            break;
                    }
                }
                catch (Exception)
                {
                }
            }
        }
        public User(string name, string firstname, Color col, int avatarIndex, List<ICalendar> lstPP)
        {
            _movements = new List<Expense>();
            _id = DateTime.Now.GetHashCode().ToString();
            this.Name = name;
            this.Firstname = firstname;
            this.Color = col;
            this.AvatarIndex = avatarIndex;
            this.Calendars = lstPP;
        }
        #endregion

        #region Methods static
        public static User GetUser(List<User> lstUsr, string index)
        {
            foreach (User usr in lstUsr)
            {
                if (usr.ID.Equals(index)) return usr;
            }
            return new User();
        }
        #endregion

        #region Methods public
        public string ToXml()
        {
            string ret = string.Empty;
            string part = string.Empty;
            foreach (ICalendar pp in _calendars)
            {
                part += pp.Text + ";" + pp.BeginDate.ToString() + ";" + pp.EndDate.ToString() + "|";
            }   
            ret = "\t<user name=\"" + _name + "\" firstname=\"" + _firstname + "\" avatar=\"" + _avatarIndex + "\" color=\"" + _color.A + "|" + _color.R + "|" + _color.G + "|" + _color.B + "|" + "\" userid=\"" + _id + "\"  pjparticipations=\"" + part + "\" />";
            return ret;
        }
        #endregion

        #region Methods private
        #endregion
    }
}
