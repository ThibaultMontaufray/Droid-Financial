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
    public partial class ViewWelcome : UserControlCustom
    {
        #region Attribute
        private InterfaceFinance _intFnc;
        private List<UserControlCustom> _activityTiles;
        #endregion

        #region Properties
        #endregion

        #region Constructor
        public ViewWelcome(InterfaceFinance intFnc)
        {
            _intFnc = intFnc;
            InitializeComponent();
            Init();
        }
        #endregion

        #region Methods public
        public override void RefreshData()
        {
            UserControlCustom ucc;
            _activityTiles.Clear();
            foreach (FinancialActivity activity in _intFnc.Activities)
            {
                switch (activity.TypeAcc)
                {
                    case TypeAccount.PROFESSIONNAL:
                        ucc = new ActivityPreviewPro(activity);
                        break;
                    case TypeAccount.FRIEND:
                    case TypeAccount.PERSONNAL:
                    default:
                        ucc = new ActivityPreviewPerso(activity);
                        break;
                }
                ucc.IsActive = activity == _intFnc.CurrentActivity;
                _activityTiles.Add(ucc);
            }
            _panelScrollable.Controls.Clear();
            foreach (UserControlCustom item in _activityTiles)
            {
                item.ControlClick += Item_ControlClick;
                _panelScrollable.Controls.Add(item);
            }
            DrawIt();
        }
        #endregion

        #region Methods private
        private void Init()
        {
            _activityTiles = new List<UserControlCustom>();
            RefreshData();
            this.Resize += ViewWelcome_Resize;
        }
        private void DrawIt()
        {
            bool one = false;
            int y = _intFnc.TOP_OFFSET;
            //foreach (UserControlCustom tile in _activityTiles)
            if (_activityTiles != null)
            { 
                for (int i = 0; i < _activityTiles.Count; i++)
                {
                    _activityTiles[i].Top = y;
                    if (!(_activityTiles.Count % 2 == 1 && _activityTiles.Count - i == 1) && this.Width > ((_activityTiles[i].Width * 2) + 30))
                    {
                        one = !one;
                        if (one)
                        {
                            _activityTiles[i].Left = (this.Width / 2) - 5 - _activityTiles[i].Width;
                        }
                        else
                        {
                            _activityTiles[i].Left = (this.Width / 2) + 5;
                            y += 10 + _activityTiles[i].Height;
                        }
                    }
                    else
                    {
                        _activityTiles[i].Left = (this.Width / 2) - _activityTiles[i].Width / 2;
                        y += 10 + _activityTiles[i].Height;
                    }
                }
            }
        }
        private void ActivatedActivityChanged(object o)
        {
            UserControlCustom selectedActivityView = (UserControlCustom) o;
            foreach (UserControlCustom item in _activityTiles)
            {
                item.IsActive = item.Name == selectedActivityView.Name;
                item.Refresh();
                if (item.IsActive)
                {
                    switch (item.GetType().ToString())
                    {
                        case "Droid.financial.ActivityPreviewPerso":
                            _intFnc.CurrentActivity = ((ActivityPreviewPerso)item).Activity;
                            break;
                        case "Droid.financial.ActivityPreviewPro":
                            _intFnc.CurrentActivity = ((ActivityPreviewPro)item).Activity;
                            break;
                    }
                }
            }
        }
        #endregion

        #region Event
        private void ViewWelcome_Resize(object sender, EventArgs e)
        {
            DrawIt();
        }
        private void Item_ControlClick(object o)
        {
            ActivatedActivityChanged(o);
        }
        #endregion
    }
}
