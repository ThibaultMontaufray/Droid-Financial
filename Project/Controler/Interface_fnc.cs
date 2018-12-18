using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text;
using Tools4Libraries;
using System.Drawing;
using Droid.People;
using System.Xml.Serialization;
using Droid.financial.View.Screen;
using Droid.financial.View;

namespace Droid.financial
{
    /// <summary>
    /// Interface for Tobi Assistant application : take care, some french word here to allow Tobi to speak with natural langage.
    /// </summary>       
    [Serializable]
    [XmlRoot("financial")]
    public class InterfaceFinance : GPInterface
    {
        #region Attributes
        public readonly string WORKING_DIRECTORY = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Servodroid\Droid-Finances\";
        public new event InterfaceEventHandler SheetDisplayRequested;

        public readonly int TOP_OFFSET = 50;
		private bool _openned;
        //private PanelFinance _panfin;
        //private List<FinancialActivity> _activities;
        private FinancialActivity _currentActivity;
        private EntityFinancialDecorator entityFinancialDecorator;
        private Specification _cuurrentSpecification;

        private bool _viewTable = true;
        private string _pathFile;
        private new ToolStripMenuFNC _tsm;

        private ViewSpecifications _viewSpecifications;
        private ViewCompanies _viewCompanies;
        private ViewCompany _viewCompany;
        private ViewBillDetails _viewBillDetail;
        private ViewBills _viewBillManage;
        private ViewBillPreview _viewBillPreview;
        private ViewSpecification _viewNewSpecification;
        private ViewWelcome _viewWelcome;
        private ViewActivityDetail _viewActivityDetail;
        private List<Person> _entities;
        private List<FinancialActivity> _activities;
        #endregion

        #region Properties
        public ToolStripMenuFNC Tsm
		{
			get { return _tsm; }
			set { _tsm = value as ToolStripMenuFNC; }
		}
   		public override bool Openned
		{
			get { return _openned; }
		}
        public FinancialActivity CurrentActivity
        {
            get { return _currentActivity; }
            set
            {
                _currentActivity = value;
                RefreshAccountDetails();
            }
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
        public List<Person> Entities
        {
            get
            {
                if (_entities == null) { _entities = new List<Person>(); }
                return _entities;
            }
            set { _entities = value; }
        }
        public List<FinancialActivity> Activities
        {
            get { return _activities; }
            set { _activities = value; }
        }
        public Specification CurrentSpecification
        {
            get { return _cuurrentSpecification; }
            set { _cuurrentSpecification = value; }
        }
        public EntityFinancialDecorator CurrentEntity
        {
            get { return entityFinancialDecorator; }
            set { entityFinancialDecorator = value; }
        }
        #endregion

        #region Constructor
        public InterfaceFinance(string pathActivity = "")
        {
            //ParserCreditAgricole.Process(@"D:\Download\CA20180202_1550.CSV");
            
            //_activities = new List<FinancialActivity>();
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
                        _currentActivity.Name = _currentActivity.Name;
                        _currentActivity.Save(_currentActivity.PathActivity);
                        return true;
                    }
                    else if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        _currentActivity.Name = (new FileInfo(sfd.FileName).Name);
                        _currentActivity.Save(sfd.FileName);
                        return true;
                    }
                }
            }
            return false;
        }
        public bool SaveAs()
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

        public override void GoAction(string action)
        {
			switch (action.ToLower())
            {
                case "deletecompany":
                    break;
                case "editcompany":
                    break;
                case "welcome":
                    LaunchViewWelcome();
                    break;
                case "addclient":
                    LaunchAddClient();
                    break;
                case "newbill":
                    LaunchNewBill();
                    break;
                case "managebill":
                    LaunchManageBill();
                    break;
                case "managespec":
                    LaunchManageSpec();
                    break;
                case "managepeople":
                    LaunchManagePeople();
                    break;
                case "editbill":
                    LaunchEditBill();
                    break;
                case "printbill":
                    LaunchPrintBill();
                    break;
                case "newspec":
                    LaunchNewSpecification();
                    break;
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
                    foreach (CRE exps in _currentActivity.ListCRE)
                    {
                        if (exps.Id == form.Movement.Id)
                        {
                            _currentActivity.ListCRE.Remove(exps);
                            break;
                        }
                    }
                    _currentActivity.ListCRE.Add(form.Movement);
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
                    foreach (CRE exps in _currentActivity.ListCRE)
                    {
                        if (exps.Id == form.Movement.Id)
                        {
                            _currentActivity.ListCRE.Remove(exps);
                            break;
                        }
                    }
                    _currentActivity.ListCRE.Add(form.Movement);
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
                    foreach (CRE exps in _currentActivity.ListCRE)
                    {
                        if (exps.Id == form.Movement.Id)
                        {
                            _currentActivity.ListCRE.Remove(exps);
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
            SheetDisplayRequested?.Invoke(null);
        }
        private void LaunchProjectUpdated()
        {
            DateTime dt = DateTime.MinValue;
            foreach (EntityFinancialDecorator user in _currentActivity.Entities)
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
            SheetDisplayRequested?.Invoke(null);
        }
        private void LaunchBalance()
        {
            _currentActivity.Balance();
            SheetDisplayRequested?.Invoke(null);
        }
        private void LaunchWinUpdate()
        {
            //_panfin.Refresh();
            SheetDisplayRequested?.Invoke(null);
        }
        private void LaunchSwitchGraph()
        {
            //if (_panfin.PanelGraphics.GraphMode == PanelGraph.GRAPHMODE.PIE) _panfin.SetGraphMode(PanelGraph.GRAPHMODE.BAR);
            //else _panfin.SetGraphMode(PanelGraph.GRAPHMODE.PIE);
            SheetDisplayRequested?.Invoke(null);
        }
        private void LaunchNewProject()
        {
            Tsm.DisablePresentation();
            Tsm.EnableUserList();
            Tsm.EnableGOP();
            Tsm.EnableExpsList();
            Tsm.EnableReconciliation();
            
            _currentActivity = new FinancialActivity(this.WORKING_DIRECTORY);
            _viewActivityDetail = new ViewActivityDetail();
            _viewActivityDetail.Activity = _currentActivity;
            this.Activities.Add(_viewActivityDetail.Activity);
            this.CurrentActivity = _viewActivityDetail.Activity;
            _viewActivityDetail.ActivityDetailUpdated += _viewActivityDetail_ActivityDetailUpdated;

            _sheet.Controls.Clear();

            _viewActivityDetail.Top = TOP_OFFSET;
            _viewActivityDetail.RefreshData();
            _viewActivityDetail.Left = (_sheet.Width / 2) - (_viewActivityDetail.Width / 2);
            _viewActivityDetail.ChangeLanguage();

            _sheet.Controls.Add(_viewActivityDetail);

            //_tsm.UpdateProjectDetails(_currentActivity);
            //_tsm.EnableOptions();
            //RefreshPanel();
            SheetDisplayRequested?.Invoke(null);
        }
        private void LaunchOpenProject()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Financial files (*.fnc)|*.fnc|All files (*.*)|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                OpenProject(ofd.FileName);
            }
            LaunchViewWelcome();
            SheetDisplayRequested?.Invoke(null);
        }
        private void LaunchLoadProject()
        {
            OpenProject(_pathFile);
            SheetDisplayRequested?.Invoke(null);
        }
        private void LaunchAddUser()
        {
            // TODO : manage it with the new dll Droid.people
            //EditUser(null);
            SheetDisplayRequested?.Invoke(null);
        }
        private void LaunchAddMovement()
        {
            EditExps(string.Empty);
        }
        private void LaunchSwitchView()
        {
            _viewTable = !_viewTable;
            RefreshPanel();
            SheetDisplayRequested?.Invoke(null);
        }
        private void LaunchCurrencyModif()
        {
            _currentActivity.CurrencyProject = CRE.GetCurrency(_tsm.Currencies.SelectedItem.Text);
            _currentActivity.Balance();
            RefreshPanel();
            SheetDisplayRequested?.Invoke(null);
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
                SheetDisplayRequested?.Invoke(null);
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
                SheetDisplayRequested?.Invoke(null);
            }
        }
        private void LaunchImport()
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    CRE.ImportExps(ofd.FileName, this);
                    _viewWelcome.RefreshData();
                }
            }
            SheetDisplayRequested?.Invoke(null);
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
            SheetDisplayRequested?.Invoke(null);
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
            SheetDisplayRequested?.Invoke(null);
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
            SheetDisplayRequested?.Invoke(null);
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
            SheetDisplayRequested?.Invoke(null);
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
            SheetDisplayRequested?.Invoke(null);
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
            SheetDisplayRequested?.Invoke(null);
        }
        private void LaunchViewWelcome()
        {
            if (_viewWelcome == null) { _viewWelcome = new ViewWelcome(this); }
            LaunchSheet(_viewWelcome, fullSize: true);
        }

        private void LaunchAddClient()
        {
            _sheet.Controls.Clear();

            if (_viewCompany == null)
            {
                _viewCompany = new ViewCompany();
                _viewCompany.OnCancel += EventRequestWelcomeScreen;
                _viewCompany.OnSave += EventRequestWelcomeScreen;
            }
            Company c = new Company();
            _viewCompany.Company = c;
            LaunchSheet(_viewCompany, offset: 250);
        }
        private void LaunchNewBill()
        {
            if (_viewBillDetail == null)
            {
                _viewBillDetail = new ViewBillDetails(this);
                _viewBillDetail.OnCancel += EventRequestWelcomeScreen;
                _viewBillDetail.OnSave += _viewOnSave;
            }
            _viewBillDetail.Bill = new Bill();
            _viewBillDetail.Bill.Id = _currentActivity.BillNexId;
            LaunchSheet(_viewBillDetail, offset:250);
        }
        private void LaunchEditBill()
        {
            if (_viewBillDetail == null)
            {
                _viewBillDetail = new ViewBillDetails(this);
                _viewBillDetail.OnCancel += EventRequestWelcomeScreen;
                _viewBillDetail.OnSave += _viewOnSave;
            }
            _viewBillDetail.Bill = _currentActivity?.CurrentBill;
            LaunchSheet(_viewBillDetail, offset: 250);
        }
        private void LaunchPrintBill()
        {
            if (_viewBillPreview == null)
            {
                _viewBillPreview = new ViewBillPreview();
            }
            _viewBillPreview.Bill = _currentActivity?.CurrentBill;
            LaunchSheet(_viewBillPreview, offset: 250);
        }
        private void LaunchManageBill()
        {
            if (_viewBillManage == null)
            {
                _viewBillManage = new ViewBills(this);
            }
            LaunchSheet(_viewBillManage, offset: 250);
        }
        private void LaunchManageSpec()
        {
            if (_viewBillManage == null)
            {
                _viewSpecifications = new ViewSpecifications();
            }
            _viewSpecifications.LoadData(_currentActivity.Specifications);
            LaunchSheet(_viewSpecifications, offset: 250);
        }
        private void LaunchManagePeople()
        {
            if (_viewCompanies == null)
            {
                _viewCompanies = new ViewCompanies(this);
                _viewCompanies.OnEdit += _viewCompanies_OnEdit;
                _viewCompanies.OnDelete += _viewCompanies_OnDelete;
            }
            _viewCompanies.LoadData(_currentActivity.Entities);
            LaunchSheet(_viewCompanies, offset: 250);
        }
        private void LaunchNewSpecification()
        {
            _sheet.Controls.Clear();

            if (_viewNewSpecification == null)
            {
                _viewNewSpecification = new ViewSpecification();
                _viewNewSpecification.OnCancel += EventRequestWelcomeScreen;
                _viewNewSpecification.OnSave += _viewOnSave;
            }
            LaunchSheet(_viewNewSpecification, offset: 250);
        }
        #endregion

        #region Methods	private
        private void OpenProject(string fileName = "")
        {
            _pathFile = fileName;
            Tsm.DisablePresentation();
            Tsm.EnableUserList();
            Tsm.EnableGOP();
            Tsm.EnableExpsList();
            Tsm.EnableReconciliation();
            
            if (string.IsNullOrEmpty(_pathFile))
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Financial Files (.fnc)|*.fnc|All Files (*.*)|*.*";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    _pathFile = ofd.FileName;
                }
            }
            if (!string.IsNullOrEmpty(_pathFile))
            {
                //_activities.Clear();
                //FileInfo fi = new FileInfo(_pathFile);
                //foreach (string dir in Directory.GetDirectories(fi.DirectoryName))
                //{
                //    _activities.Add(new FinancialActivity(dir));
                //}
                _currentActivity = new FinancialActivity(_pathFile);
                _activities.Add(_currentActivity);
                //_currentActivity = _activities.Count > 0 ? _activities[0] : null;
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
            if (!Directory.Exists(WORKING_DIRECTORY)) { Directory.CreateDirectory(WORKING_DIRECTORY); }

            _activities = new List<FinancialActivity>();
            _entities = new List<Person>();
            //if (!string.IsNullOrEmpty(_pathFile)) { OpenProject(); }

            _sheet = new PanelScrollableCustom();
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
        private void RefreshAccountDetails()
        {
            _tsm.UpdateProjectDetails(_currentActivity);
        }
        #endregion

        #region Event
        private void _sheet_Resize(object sender, EventArgs e)
        {
            Resize();
        }
        private void _viewActivityDetail_ActivityDetailUpdated(object o)
        {
            Save();
            LaunchViewWelcome();

            Tsm.DisablePresentation();
            Tsm.EnableUserList();
            Tsm.EnableGOP();
            Tsm.EnableExpsList();
            Tsm.EnableReconciliation();
        }
        private void EventRequestWelcomeScreen(object o)
        {
            LaunchViewWelcome();
        }
        private void _viewOnSave(object o)
        {
            Save();
            LaunchViewWelcome();
        }
        private void _viewCompanies_OnDelete(object sender, EventArgs e)
        {
            GoAction("deletecompany");
        }
        private void _viewCompanies_OnEdit(object sender, EventArgs e)
        {
            GoAction("editcompany");
        }
        #endregion
    }
}
