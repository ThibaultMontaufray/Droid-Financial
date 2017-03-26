using Tools4Libraries;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Droid_financial
{
    public class DeviseEdition : window_classic
    {
        #region Attribute
        private TextBox textBoxName;
        private GroupBox groupBoxChange;
        private TextBox textBoxValue;
        private Label label1;
        private ComboBox comboBoxDevise;
        private Button buttonCancel;
        private Button buttonOK;
        private Label labelName;
        private Interface_fnc _ifn;
        #endregion

        #region Properties
        #endregion

        #region Constructor
        public DeviseEdition(Interface_fnc intfn)
        {
            _ifn = intfn;
            InitializeComponent();
            InitData();
        }
        #endregion

        #region Methods public
        #endregion

        #region Methods private
        private void InitData()
        {
            if (_ifn.CurrentProject.Changes.Count > 0)
            {
                foreach (var item in _ifn.CurrentProject.Changes)
                {
                    if (!comboBoxDevise.Items.Contains(item.Currency1)) comboBoxDevise.Items.Add(item.Currency1);
                    if (!comboBoxDevise.Items.Contains(item.Currency2)) comboBoxDevise.Items.Add(item.Currency2);
                }
            }
            else
            {
                comboBoxDevise.Items.Add("EUR");
                comboBoxDevise.Items.Add("USD");
            }
            comboBoxDevise.SelectedIndex = 0;
        }
        private void InitializeComponent()
        {
            this.labelName = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.groupBoxChange = new System.Windows.Forms.GroupBox();
            this.comboBoxDevise = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxValue = new System.Windows.Forms.TextBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.groupBoxChange.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(12, 15);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(35, 13);
            this.labelName.TabIndex = 23;
            this.labelName.Text = "Name";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(84, 12);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(88, 20);
            this.textBoxName.TabIndex = 24;
            // 
            // groupBoxChange
            // 
            this.groupBoxChange.Controls.Add(this.textBoxValue);
            this.groupBoxChange.Controls.Add(this.label1);
            this.groupBoxChange.Controls.Add(this.comboBoxDevise);
            this.groupBoxChange.Location = new System.Drawing.Point(15, 38);
            this.groupBoxChange.Name = "groupBoxChange";
            this.groupBoxChange.Size = new System.Drawing.Size(157, 73);
            this.groupBoxChange.TabIndex = 25;
            this.groupBoxChange.TabStop = false;
            this.groupBoxChange.Text = "Change with other devises";
            // 
            // comboBoxDevise
            // 
            this.comboBoxDevise.FormattingEnabled = true;
            this.comboBoxDevise.Location = new System.Drawing.Point(6, 19);
            this.comboBoxDevise.Name = "comboBoxDevise";
            this.comboBoxDevise.Size = new System.Drawing.Size(145, 21);
            this.comboBoxDevise.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "Value : ";
            // 
            // textBoxValue
            // 
            this.textBoxValue.Location = new System.Drawing.Point(63, 45);
            this.textBoxValue.Name = "textBoxValue";
            this.textBoxValue.Size = new System.Drawing.Size(88, 20);
            this.textBoxValue.TabIndex = 25;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(15, 117);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 26;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(97, 117);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 27;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // DeviseEdition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(183, 151);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.groupBoxChange);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.labelName);
            this.Name = "DeviseEdition";
            this.groupBoxChange.ResumeLayout(false);
            this.groupBoxChange.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private bool ControlStupidUser()
        {
            bool flag = true;
            textBoxValue.Text = textBoxValue.Text.Replace('.', ',');
            Regex r = new Regex(@"^[0-9]+(?:\,[0-9]*)?$");
            if (!r.IsMatch(textBoxValue.Text))
            {
                flag = false;
                textBoxValue.BackColor = Color.Yellow;
            }
            else textBoxValue.BackColor = Color.White;
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                flag = false;
                textBoxName.BackColor = Color.Yellow;
            }
            else textBoxName.BackColor = Color.White;
            return flag;
        }
        #endregion

        #region Event
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (ControlStupidUser())
            {
                Change chg = new Change(textBoxName.Text, comboBoxDevise.Text, double.Parse(textBoxValue.Text));
                if (_ifn.CurrentProject.Changes.Contains(chg)) _ifn.CurrentProject.Changes.Remove(chg);
                _ifn.CurrentProject.Changes.Add(chg);

                Change chg_revert = new Change(comboBoxDevise.Text, textBoxName.Text, 1/ double.Parse(textBoxValue.Text));
                if (_ifn.CurrentProject.Changes.Contains(chg_revert)) _ifn.CurrentProject.Changes.Remove(chg_revert);
                _ifn.CurrentProject.Changes.Add(chg_revert);

                this.Close();
            }
        }
        #endregion
    }
}
