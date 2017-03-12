using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Droid_financial.View
{
    public partial class Demo : Form
    {
        private Interface_fnc _intFnc;
        public Demo()
        {
            InitializeComponent();

            _intFnc = new Interface_fnc(new List<string>());
            _intFnc.Sheet.Dock = DockStyle.Fill;
            this.Controls.Add(_intFnc.Sheet);
        }
    }
}
