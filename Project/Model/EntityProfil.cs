using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Xml;
using System.Text.RegularExpressions;
using Droid.scheduler;
using Droid.People;

namespace Droid.financial
{
    public class EntityFinancialDecorator : Entity
    {
        #region Attribute
        private Color _color;
        private int _avatarIndex;
        private double _solde;
        private double _soldeSimulation;
        private double _sumExpances;
        private string _currency;
        private List<CRE> _movements;
        private string _siret;
        #endregion

        #region Properties
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
        public List<CRE> Movements
        {
            get { return _movements; }
            set { _movements = value; }
        }        
        public string Siret
        {
            get { return _siret; }
            set { _siret = value; }
        }
        #endregion

        #region Constructor
        public EntityFinancialDecorator()
        {
            _movements = new List<CRE>();
            _id = DateTime.Now.GetHashCode().ToString();
            _calendars = new List<ICalendar>();
        }
        public EntityFinancialDecorator(XmlReader node)
        {
            string[] tab;
            _movements = new List<CRE>();
            _calendars = new List<ICalendar>();
            for (int i = 0; i < node.AttributeCount; i++)
            {
                try
                {
                    node.MoveToAttribute(i);
                    switch (node.Name.ToLower())
                    {
                        case "name": this.Name = node.Value; break;
                        //case "firstname": this.FirstName = new FirstName(node.Value); break;
                        case "avatar": this.AvatarIndex = int.Parse(node.Value); break;
                        case "userid": this.Id = node.Value; break;
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
        public EntityFinancialDecorator(Entity.Family fam, string name, string firstname, Color col, int avatarIndex, List<ICalendar> lstPP)
        {
            _movements = new List<CRE>();
            _id = DateTime.Now.GetHashCode().ToString();
            this.FamilyType = fam;
            this.Name = name;
            //this.FirstName = new FirstName(firstname);
            this.Color = col;
            this.AvatarIndex = avatarIndex;
            this.Calendars = lstPP;
        }
        #endregion

        #region Methods static
        public static EntityFinancialDecorator GetUser(List<EntityFinancialDecorator> lstUsr, string index)
        {
            foreach (EntityFinancialDecorator usr in lstUsr)
            {
                if (usr.Id.Equals(index)) return usr;
            }
            return new EntityFinancialDecorator();
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
            ret = "\t<user name=\"" + GetName() + "\" avatar=\"" + _avatarIndex + "\" color=\"" + _color.A + "|" + _color.R + "|" + _color.G + "|" + _color.B + "|" + "\" userid=\"" + _id + "\"  pjparticipations=\"" + part + "\" />";
            return ret;
        }
        public override string ToString()
        {
            return _name;
        }
        #endregion

        #region Methods private
        #endregion
    }
}
