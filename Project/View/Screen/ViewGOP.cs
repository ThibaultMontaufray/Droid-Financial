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

namespace Droid.financial
{
    public partial class ViewGOP : Tools4Libraries.UserControlCustom
    {
        #region Attribute
        private InterfaceFinance _intFnc;

        private System.ComponentModel.IContainer components = null;
        #endregion

        #region Properties
        #endregion

        #region Constructor
        public ViewGOP()
        {
            InitializeComponent();
        }
        public ViewGOP(InterfaceFinance intFnc)
        {
            _intFnc = intFnc;
            InitializeComponent();
        }
        #endregion

        #region Methods public
        public override void Refresh()
        {

        }
        #endregion

        #region Methods protected
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        #endregion

        #region Methods private
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        }
        #endregion

        #region Event
        #endregion
        }
    }
