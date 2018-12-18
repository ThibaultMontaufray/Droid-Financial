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
using Droid.People;

namespace Droid.financial
{
    public partial class ViewSpecification : UserControlCustom
    {
        #region Attributes
        public event UserControlCustomEventHandler OnCancel;
        public event UserControlCustomEventHandler OnSave;

        private Specification _spec;
        #endregion

        #region Properties
        public Specification Spec
        {
            get { return _spec; }
            set
            {
                _spec = value;
                RefreshData();
            }
        }
        #endregion

        #region Constructor
        public ViewSpecification()
        {
            InitializeComponent();
            Init();
        }
        #endregion

        #region Methods public
        public override void ChangeLanguage()
        {
            base.ChangeLanguage();
        }
        public override void RefreshData()
        {

        }
        #endregion

        #region Methods private
        private void Init()
        {
            comboBoxPayment.Items.Clear();
            foreach (PaymentSupport item in Enum.GetValues(typeof(PaymentSupport)))
            {
                comboBoxPayment.Items.Add(item);
            }
            comboBoxPayment.SelectedIndex = 0;
            textBoxOfferDays.Text = "30";
            textBoxSpecId.Text = "#00001";
        }
        private void Save()
        {
            if (_spec == null) { _spec = new Specification(); }
            _spec.CreationDate = dateTimePickerSpecDate.Value;
            _spec.From = comboBoxEntityFrom.SelectedItem != null ? (Entity)comboBoxEntityFrom.SelectedItem : null;
            _spec.To = comboBoxEntityTo.SelectedItem != null ? (Entity)comboBoxEntityTo.SelectedItem : null;
            _spec.Id = textBoxSpecId.Text;
            _spec.MaxDays = int.Parse(textBoxOfferDays.Text);
            _spec.Save();
            OnSave?.Invoke(null);
        }
        #endregion

        #region Event
        private void buttonSave_Click(object sender, EventArgs e)
        {
            Save();
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            OnCancel?.Invoke(null);
        }
        private void buttonAddProduct_Click(object sender, EventArgs e)
        {

        }
        private void buttonEntityAdd_Click(object sender, EventArgs e)
        {

        }
        private void textBoxOfferDays_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.')) { e.Handled = true; }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1)) { e.Handled = true; }
        }
        #endregion
    }
}
