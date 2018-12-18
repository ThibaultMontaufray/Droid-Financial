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
using System.IO;
using Droid.financial.Properties;

namespace Droid.financial
{
    public partial class ViewActivityDetail : UserControlCustom
    {
        #region Attributes
        public event UserControlCustomEventHandler ActivityDetailUpdated;

        private FinancialActivity _activity;
        #endregion

        #region Properties
        public FinancialActivity Activity
        {
            get { return _activity; }
            set
            {
                _activity = value;
                RefreshData();
            }
        }
        #endregion

        #region Constructor
        public ViewActivityDetail()
        {
            InitializeComponent();
            Init();
        }
        public ViewActivityDetail(FinancialActivity activity)
        {
            _activity = activity;
            InitializeComponent();
            Init();
            RefreshData();
        }
        #endregion

        #region Methods public
        public override void ChangeLanguage()
        {
            labelName.Text = Droid.litterature.Parse.Traduction("Name", Settings.Default.Language);
            labelBrowsePath.Text = Droid.litterature.Parse.Traduction("Path", Settings.Default.Language);
            buttonBrowsePath.Text = Droid.litterature.Parse.Traduction("Browse", Settings.Default.Language);
            buttonCancel.Text = Droid.litterature.Parse.Traduction("Cancel", Settings.Default.Language);
            buttonSave.Text = Droid.litterature.Parse.Traduction("Save", Settings.Default.Language);
        }
        public override void RefreshData()
        {
            if (_activity != null)
            {
                textBoxName.Text = _activity.Name;
                textBoxPath.Text = _activity.PathActivity;
                comboBoxCurrency.SelectedItem = _activity.CurrencyProject;
                comboBoxFamily.SelectedItem = _activity.TypeAcc;
            }
        }
        #endregion

        #region Methods private
        private void Init()
        {
            comboBoxFamily.Items.Clear();
            foreach (TypeAccount item in Enum.GetValues(typeof(TypeAccount)))
            {
                comboBoxFamily.Items.Add(item);
            }
            comboBoxFamily.SelectedIndex = 0;
            comboBoxCurrency.SelectedIndex = 0;
        }
        private void SaveActivity()
        {
            bool alright = true;
            if (string.IsNullOrEmpty(textBoxName.Text)) {textBoxName.BackColor = Color.LemonChiffon; alright = false; }
            else { textBoxName.BackColor = Color.White; }

            if (string.IsNullOrEmpty(textBoxPath.Text)){textBoxPath.BackColor = Color.LemonChiffon; alright = false; }
            else { textBoxPath.BackColor = Color.White; }

            if (alright)
            { 
                if (_activity == null) { _activity = new FinancialActivity(textBoxPath.Text); }
                _activity.Name = textBoxName.Text;
                _activity.PathActivity = Path.Combine(textBoxPath.Text, textBoxName.Text.Replace(" ", "_") + ".fnc");
                _activity.CurrencyProject = comboBoxCurrency.Text;
                _activity.TypeAcc = (TypeAccount) comboBoxFamily.SelectedItem ;
                ActivityDetailUpdated?.Invoke(null);
            }
        }
        private void BrowsePath()
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (_activity != null && _activity != null && !string.IsNullOrEmpty(_activity.PathActivity))
            {
                fbd.SelectedPath = _activity.PathActivity;
            }
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                textBoxPath.Text = fbd.SelectedPath;
            }
        }
        #endregion

        #region Event
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            RefreshData();
            ActivityDetailUpdated?.Invoke(e);
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            SaveActivity();
        }
        private void buttonBrowsePath_Click(object sender, EventArgs e)
        {
            BrowsePath();
        }
        #endregion
    }
}
 