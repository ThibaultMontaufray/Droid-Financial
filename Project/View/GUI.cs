using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Droid_financial
{
    public partial class GUI : Form
    {
        private Interface_fnc _intFnc;
        public GUI()
        {
            InitializeComponent();

            _intFnc = new Interface_fnc(new List<string>());
            _intFnc.SheetFinancial.Dock = DockStyle.Fill;
            this.Controls.Add(_intFnc.SheetFinancial);
        }
    }
}
