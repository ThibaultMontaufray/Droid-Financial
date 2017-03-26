using System.Windows.Forms;
using Tools4Libraries;

namespace Droid_financial
{
    public partial class ViewWelcome : UserControlCustom
    {
        #region Attribute
        private Interface_fnc _intFnc;
        #endregion

        #region Properties
        #endregion

        #region Constructor
        public ViewWelcome(Interface_fnc intFnc)
        {
            _intFnc = intFnc;
            InitializeComponent();
            Init();
        }
        #endregion

        #region Methods public
        public override void RefreshData()
        {
            viewExpences1.RefreshData();
            viewMovement1.RefreshData();
        }
        #endregion

        #region Methods private
        private void Init()
        {
            viewExpences1.InterfaceFinancial = _intFnc;
            viewExpences1.RefreshData();

            viewMovement1.InterfaceFinancial = _intFnc;
            viewMovement1.RefreshData();
        }
        #endregion

        #region Event
        #endregion
    }
}
