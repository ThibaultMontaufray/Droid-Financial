using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tools4Libraries;
using Droid.financial.Properties;

namespace Droid.financial
{
    public partial class ViewAccountResume : UserControlCustom
    {
        #region Attributes
        private FinancialActivity _activity;
        #endregion

        #region Properties
        public FinancialActivity Activity
        {
            get { return _activity; }
            set { _activity = value; RefreshData(); }
        }
        #endregion

        #region Constructor
        public ViewAccountResume()
        {
            InitializeComponent();
        }
        #endregion

        #region Methods public
        public override void RefreshData()
        {
            RefreshAll();
        }
        public override void ChangeLanguage()
        {
            labelAccountName.Text = Droid.litterature.Parse.Traduction("Account_name", Settings.Default.Language);
            labelSolde.Text = Droid.litterature.Parse.Traduction("Solde", Settings.Default.Language);
        }
        #endregion

        #region Methods private
        private void RefreshAll()
        {
            if (_activity != null && _activity != null)
            {
                labelSolde.Text = _activity.Solde.ToString() + " " + _activity.CurrencyUsed.ToLower();
                labelAccountName.Text = _activity.Name;
            }
        }
        #endregion

        #region Event
        #endregion
    }
}
