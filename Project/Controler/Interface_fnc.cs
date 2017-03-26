using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text;
using Tools4Libraries;

namespace Droid_financial
{
    /// <summary>
    /// Interface for Tobi Assistant application : take care, some french word here to allow Tobi to speak with natural langage.
    /// </summary>            
    public delegate void InterfaceEventHandler();
    public class Interface_fnc : GPInterface
    {
        #region Attributes
        public event InterfaceEventHandler SheetDisplayRequested;

        public readonly int TOP_OFFSET = 150;
        private ToolStripMenuFNC _tsm;
		private bool _openned;
        //private PanelFinance _panfin;
        private List<FinancialActivity> _activities;
        private FinancialActivity _currentActivity;
        private bool _viewTable = true;
        private string _pathFile;

        private UserControlCustom _viewWelcome;
        #endregion

        #region Properties
        public ToolStripMenuFNC Tsm
		{
			get { return _tsm; }
			set { _tsm = value as ToolStripMenuFNC; }
		}
        public Panel Sheet
        {
            get { return _sheet; }
            set { _sheet = value; }
        }
		public override bool Openned
		{
			get { return _openned; }
		}
        public FinancialActivity CurrentProject
        {
            get { return _currentActivity; }
            set { _currentActivity = value; }
        }
        public bool ViewTable
        {
            get { return _viewTable; }
            set { _viewTable = value; }
        }
        public new string PathFile
        {
            get { return _pathFile; }
            set { _pathFile = value; }
        }
		#endregion
		
		#region Constructor
        public Interface_fnc(string pathActivity = "")
        {
            _activities = new List<FinancialActivity>();
            _pathFile = pathActivity;
            BuildToolBar();
            Init();
		}
		#endregion

        #region Action
        public static Dictionary<string, string> ACTION_130_lister_participant(string fichier_project)
        {
            Dictionary<string, string> participants = new Dictionary<string, string>();

            // TODO : get participant on database

            return participants;
        }
        public static string ACTION_131_localiser_export(string fichier_projet)
        {
            // TODO Get the pdf path in database project
            return string.Empty;
        }
        public static string ACTION_132_recuperer_titre(string fichier_projet)
        {
            // TODO  : get project name from db
            return string.Empty;
        }
        public static string ACTION_133_recuperer_resume(string fichier_projet)
        {
            StringBuilder sb = new StringBuilder();

            // TODO : format the db data for the mail in html 

            return sb.ToString();
        }
        #endregion

        #region Methods Public
        public override bool Open(object fileName)
		{
            OpenProject(fileName as string);
			return true;
		}
		public override void Print()
		{
			
		}
		public override void Close()
		{
			try
            {
                Tsm._detail_presentation.Checked = true;
                Tsm._detail_gop_rate.Checked = false;
                Tsm._detail_exps_list.Checked = false;
                Tsm._detail_reconciliation.Checked = false;
                Tsm._detail_user_list.Checked = false;

                _tsm.DisableOptions();
				//_stream.Close();
			}
			catch
			{
				
			}
		}
		public override bool Save()
        {
            if (_currentActivity != null)
            {
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "Financial files (*.fnc)|*.fnc|All files (*.*)|*.*";
                    if (!string.IsNullOrEmpty(_currentActivity.PathActivity))
                    {
                        FileInfo fi = new FileInfo(_currentActivity.PathActivity);
                        sfd.FileName = fi.Name;
                    }
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        _currentActivity.Name = (new FileInfo(sfd.FileName).Name);
                        _currentActivity.Save(sfd.FileName);
                        return true;
                    }
                }
            }
			return false;
		}
		public override void ZoomIn()
		{
			
		}
		public override void ZoomOut()
		{
			
		}
		public override void Copy()
		{
			
		}
		public override void Cut()
		{
			
		}
		public override void Paste()
		{
			
		}
		public override void Resize()
        {
            foreach (Control ctrl in _sheet.Controls)
            {
                if (ctrl.Name.Equals("CurrentView"))
                {
                    ctrl.Left = (_sheet.Width / 2) - (ctrl.Width / 2);
                }
            }
        }
        public override void GlobalAction(object sender, EventArgs e)
        {
            ToolBarEventArgs tbea = e as ToolBarEventArgs;
            string action = tbea.EventText;
            GoAction(action);
        }

        public void GoAction(string action)
        {
			switch (action.ToLower())
            {
                case "adddevise":
                    LaunchAddDevise();
                    break;
                case "exportcsv":
                    LaunchExportCsv();
                    break;
                case "exportpdf":
                    LaunchExportPdf();
                    break;
                case "exportweb":
                    LaunchExportWeb();
                    break;
                case "exporttxt":
                    LaunchExportTxt();
                    break;
                case "exportxml":
                    LaunchExportXml();
                    break;
                case "projectupdated":
                    LaunchProjectUpdated();
                    break;
                case "changegraphmode":
                    LaunchSwitchGraph();
                    break;
                case "openproject":
                    LaunchOpenProject();
                    break;
                case "loadproject":
                    LaunchLoadProject();
                    break;
                case "newproject":
                    LaunchNewProject();
                    break;
                case "dduser":
                    LaunchAddUser();
                    break;
                case "ddevent" :
                    LaunchAddMovement();
                    break;
                case "import":
                    LaunchImport();
                    break;
                case "changeview":
                    LaunchSwitchView();
                    break;
                case "changemodified":
                    LaunchChangeModif();
                    break;
                case "currencymodified":
                    LaunchCurrencyModif();
                    break;
                case "valuechangemodified":
                    LaunchValueChangeModif();
                    break;
                case "winupdate" :
                    LaunchWinUpdate();
                    break;
                case "takebill":
                    LaunchTakeBill();
                    break;
                case "balance":
                    LaunchBalance();
                    break;
			}
		}		
		public RibbonTab BuildToolBar()
		{
            _tsm = new ToolStripMenuFNC();
            _tsm.ActionAppened += GlobalAction;
            return _tsm;
        }
        public void RefreshPanel()
        {
            Balance();
            //_panfin.Invalidate();
        }        
        //public void EditUser(int? userId)
        //{
        //    using (UserEdit form = new UserEdit(this, userId))
        //    {
        //        if (form.ShowDialog() == DialogResult.OK)
        //        {
        //            foreach (User usr in _currentProject.Users)
        //            {
        //                if (usr.ID == form.User.ID)
        //                {
        //                    _currentProject.Users.Remove(usr);
        //                    break;
        //                }
        //            }
        //            _currentProject.Users.Add(form.User);
        //            RefreshPanel();
        //        }
        //    }
        //}
        //public void DeleteUser(int? userId)
        //{   
        //    using (UserDelete form = new UserDelete(this, userId))
        //    {
        //        if (form.ShowDialog() == DialogResult.OK)
        //        {
        //            foreach (User usr in _currentProject.Users)
        //            {
        //                if (usr.ID == form.User.ID)
        //                {
        //                    _currentProject.Users.Remove(usr);
        //                    break;
        //                }
        //            }
        //            RefreshPanel();
        //        }
        //    }
        //}
        public void EditExps(int? expsId)
        {
            using (ExpsEdit form = new ExpsEdit(this, expsId))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    foreach (Expense exps in _currentActivity.ListExpenses)
                    {
                        if (exps.Id == form.Movement.Id)
                        {
                            _currentActivity.ListExpenses.Remove(exps);
                            break;
                        }
                    }
                    _currentActivity.ListExpenses.Add(form.Movement);
                    RefreshPanel();
                }
            }
        }
        public void EditExps(string picPath)
        {
            using (ExpsEdit form = new ExpsEdit(this, picPath))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    foreach (Expense exps in _currentActivity.ListExpenses)
                    {
                        if (exps.Id == form.Movement.Id)
                        {
                            _currentActivity.ListExpenses.Remove(exps);
                            break;
                        }
                    }
                    _currentActivity.ListExpenses.Add(form.Movement);
                    RefreshPanel();
                }
            }
        }
        public void DeleteExps(int? expsId)
        {
            using (ExpsDelete form = new ExpsDelete(this, expsId))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    foreach (Expense exps in _currentActivity.ListExpenses)
                    {
                        if (exps.Id == form.Movement.Id)
                        {
                            _currentActivity.ListExpenses.Remove(exps);
                            break;
                        }
                    }
                    RefreshPanel();
                }
            }
        }        
        #endregion

        #region Methods Launcher
        private void LaunchAddDevise()
        {
            DeviseEdition de = new DeviseEdition(this);
            de.ShowDialog();
            Tsm.UpdateProjectDetails(_currentActivity);
            if (SheetDisplayRequested != null) SheetDisplayRequested();
        }
        private void LaunchProjectUpdated()
        {
            DateTime dt = DateTime.MinValue;
            foreach (User user in _currentActivity.Users)
            {
                foreach (var item in user.Calendars)
                {
                    if (item.Text.Equals(_currentActivity.Name)) item.Text = _tsm.ProjectName.TextBoxText;
                }
            }
            _currentActivity.Name = _tsm.ProjectName.TextBoxText;

            DateTime.TryParse(_tsm.ProjectStartDate.TextBoxText, out dt);
            if (dt != DateTime.MinValue) _currentActivity.StartDate = dt;
            else _tsm.ProjectStartDate.TextBoxText = _currentActivity.StartDate.ToShortDateString();
            dt = DateTime.MinValue;

            DateTime.TryParse(_tsm.ProjectEndDate.TextBoxText, out dt);
            if (dt != DateTime.MinValue) _currentActivity.EndDate = dt;
            else _tsm.ProjectEndDate.TextBoxText = _currentActivity.EndDate.ToShortDateString();
            dt = DateTime.MinValue;
            if (SheetDisplayRequested != null) SheetDisplayRequested();
        }
        private void LaunchBalance()
        {
            _currentActivity.Balance();
            if (SheetDisplayRequested != null) SheetDisplayRequested();
        }
        private void LaunchWinUpdate()
        {
            //_panfin.Refresh();
            if (SheetDisplayRequested != null) SheetDisplayRequested();
        }
        private void LaunchSwitchGraph()
        {
            //if (_panfin.PanelGraphics.GraphMode == PanelGraph.GRAPHMODE.PIE) _panfin.SetGraphMode(PanelGraph.GRAPHMODE.BAR);
            //else _panfin.SetGraphMode(PanelGraph.GRAPHMODE.PIE);
            if (SheetDisplayRequested != null) SheetDisplayRequested();
        }
        private void LaunchNewProject()
        {
            Tsm.DisablePresentation();
            Tsm.EnableUserList();
            Tsm.EnableGOP();
            Tsm.EnableExpsList();
            Tsm.EnableReconciliation();

            _currentActivity = new FinancialActivity();
            _tsm.UpdateProjectDetails(_currentActivity);
            _tsm.EnableOptions();
            RefreshPanel();
            if (SheetDisplayRequested != null) SheetDisplayRequested();
        }
        private void LaunchOpenProject()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Financial files (*.fnc)|*.fnc|All files (*.*)|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                OpenProject(ofd.FileName);
            }
            if (SheetDisplayRequested != null) SheetDisplayRequested();
        }
        private void LaunchLoadProject()
        {
            OpenProject(_pathFile);
            if (SheetDisplayRequested != null) SheetDisplayRequested();
        }
        private void LaunchAddUser()
        {
            // TODO : manage it with the new dll Droid_people
            //EditUser(null);
            if (SheetDisplayRequested != null) SheetDisplayRequested();
        }
        private void LaunchAddMovement()
        {
            EditExps(string.Empty);
        }
        private void LaunchSwitchView()
        {
            _viewTable = !_viewTable;
            RefreshPanel();
            if (SheetDisplayRequested != null) SheetDisplayRequested();
        }
        private void LaunchCurrencyModif()
        {
            _currentActivity.CurrencyProject = Expense.GetCurrency(_tsm.Currencies.SelectedItem.Text);
            _currentActivity.Balance();
            RefreshPanel();
            if (SheetDisplayRequested != null) SheetDisplayRequested();
        }
        private void LaunchValueChangeModif()
        {
            if (_tsm.Changes.SelectedItem != null && !string.IsNullOrEmpty(_tsm.Changes.SelectedItem.Text) && _tsm.Changes.SelectedItem.Text.Split(' ').Length > 2)
            {
                string cur1, cur2;
                cur1 = _tsm.Changes.SelectedItem.Text.Split(' ')[0];
                cur2 = _tsm.Changes.SelectedItem.Text.Split(' ')[2];
                foreach (Change chg in _currentActivity.Changes)
                {
                    if (cur1.Equals(chg.Currency1) && cur2.Equals(chg.Currency2))
                    {
                        chg.Rate = double.Parse(_tsm.ChangeValue.TextBoxText);
                    }
                    else if (cur2.Equals(chg.Currency1) && cur1.Equals(chg.Currency2))
                    {
                        chg.Rate = 1/ double.Parse(_tsm.ChangeValue.TextBoxText);
                    }
                }
                _currentActivity.Balance();
                RefreshPanel();
                if (SheetDisplayRequested != null) SheetDisplayRequested();
            }
        }
        private void LaunchChangeModif()
        {
            if (!string.IsNullOrEmpty(_tsm.Changes.SelectedItem.Text) && _tsm.Changes.SelectedItem.Text.Split(' ').Length > 2)
            {
                string cur1, cur2;
                cur1 = _tsm.Changes.SelectedItem.Text.Split(' ')[0];
                cur2 = _tsm.Changes.SelectedItem.Text.Split(' ')[2];
                foreach (Change chg in _currentActivity.Changes)
                {
                    if (cur1.Equals(chg.Currency1) && cur2.Equals(chg.Currency2))
                    {
                        _tsm.LoadChangeValue(chg.Rate);
                        break;
                    }
                }
                if (SheetDisplayRequested != null) SheetDisplayRequested();
            }
        }
        private void LaunchImport()
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    _currentActivity.ListExpenses.AddRange(Expense.ImportExps(ofd.FileName));
                }
            }
            if (SheetDisplayRequested != null) SheetDisplayRequested();
        }
        private void LaunchExportXml()
        {
            string exportStr = _currentActivity.ExportXML();
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.FileName = "Export_" + _currentActivity.Name + ".xml";
                sfd.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter sw = new StreamWriter(sfd.FileName))
                    {
                        sw.Write(exportStr);
                        sw.Close();
                    }
                }
            }
            if (SheetDisplayRequested != null) SheetDisplayRequested();
        }
        private void LaunchExportPdf()
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.FileName = "Export_" + _currentActivity.Name + ".pdf";
                sfd.Filter = "PDF files (*.pdf)|*.pdf|All files (*.*)|*.*";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    _currentActivity.ExportPDF(sfd.FileName);
                }
            }
            if (SheetDisplayRequested != null) SheetDisplayRequested();
        }
        private void LaunchExportWeb()
        {
            string exportStr = _currentActivity.ExportWEB();
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.FileName = "Export_" + _currentActivity.Name + ".html";
                sfd.Filter = "WEB files (*.html)|*.html|All files (*.*)|*.*";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter sw = new StreamWriter(sfd.FileName))
                    {
                        sw.Write(exportStr);
                        sw.Close();
                    }
                }
            }
            if (SheetDisplayRequested != null) SheetDisplayRequested();
        }
        private void LaunchExportTxt()
        {
            string exportStr = _currentActivity.ExportTXT();
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.FileName = "Export_" + _currentActivity.Name + ".txt";
                sfd.Filter = "TXT files (*.txt)|*.txt|All files (*.*)|*.*";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter sw = new StreamWriter(sfd.FileName))
                    {
                        sw.Write(exportStr);
                        sw.Close();
                    }
                }
            }
            if (SheetDisplayRequested != null) SheetDisplayRequested();
        }
        private void LaunchExportCsv()
        {
            string exportStr = _currentActivity.ExportCSV();
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.FileName = "Export_" + _currentActivity.Name + ".csv";
                sfd.Filter = "CSV files (*.csv)|*.txt|All files (*.*)|*.*";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter sw = new StreamWriter(sfd.FileName))
                    {
                        sw.Write(exportStr);
                        sw.Close();
                    }
                }
            }
            if (SheetDisplayRequested != null) SheetDisplayRequested();
        }
        private void LaunchTakeBill()
        {
            using (CamGUI myCamGUi = new CamGUI())
            {
                if (myCamGUi.ShowDialog() == DialogResult.OK)
                {
                    EditExps(myCamGUi.PicturePath);
                }
            }
            if (SheetDisplayRequested != null) SheetDisplayRequested();
        }
        private void LaunchViewWelcome()
        {
            _sheet.Controls.Clear();

            _viewWelcome.Top = TOP_OFFSET;
            _viewWelcome.RefreshData();
            _viewWelcome.Left = (_sheet.Width / 2) - (_viewWelcome.Width / 2);
            _viewWelcome.ChangeLanguage();
            _sheet.Controls.Add(_viewWelcome);
            if (SheetDisplayRequested != null) SheetDisplayRequested();
        }
        #endregion

        #region Methods	private
        private void OpenProject(string fileName = "")
        {
            if (!string.IsNullOrEmpty(fileName)) { _pathFile = fileName; }
            Tsm.DisablePresentation();
            Tsm.EnableUserList();
            Tsm.EnableGOP();
            Tsm.EnableExpsList();
            Tsm.EnableReconciliation();
            
            if (!string.IsNullOrEmpty(_pathFile))
            {
                _activities.Clear();
                foreach (string dir in Directory.GetDirectories(_pathFile))
                {
                    _activities.Add(new FinancialActivity(dir));
                }
                _currentActivity = _activities.Count > 0 ? _activities[0] : null;
                _tsm.EnableOptions();
                RefreshPanel();
                _tsm.UpdateProjectDetails(_currentActivity);
                this._openned = true;
            }
        }
        private void Balance()
        {
            if (_currentActivity!= null) _currentActivity.Balance();
        }
        private void Init()
        {
            OpenProject();

            _sheet = new Panel();
            _sheet.Name = "SheetFinance";
            _sheet.BackColor = System.Drawing.Color.DimGray;
            _sheet.Dock = DockStyle.Fill;
            _sheet.BackgroundImage = Properties.Resources.ShieldTileBg;
            _sheet.BackgroundImageLayout = ImageLayout.Tile;
            _sheet.Resize += _sheet_Resize;

            _viewWelcome = new ViewWelcome(this);
            _viewWelcome.Top = TOP_OFFSET;
            _viewWelcome.Left = (_sheet.Width / 2) - (_viewWelcome.Width / 2);
            _viewWelcome.Name = "CurrentView";
            _sheet.Controls.Add(_viewWelcome);

            //_panfin = new PanelFinance(this);
            //_panfin.BackgroundImage = _tsm.Gui.BackgroundImage;
            //_panfin.BackgroundImageLayout = _tsm.Gui.BackgroundImageLayout;
            //_panfin.Text = "Financial";
            //_panfin.Width = 600;
            //_panfin.Height = 400;
            //_panfin.Top = TOP_OFFSET;
            //_panfin.Left = (_sheet.Width / 2) - (_viewWelcome.Width / 2);
            //_panfin.Name = "CurrentView";
            //_sheet.Controls.Add(_panfin);
        }
        #endregion

        #region Event
        private void _sheet_Resize(object sender, EventArgs e)
        {
            Resize();
        }
        #endregion
    }
}
