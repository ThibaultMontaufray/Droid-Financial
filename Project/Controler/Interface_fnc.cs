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
    public class Interface_fnc : GPInterface
    {
		#region Attributes
        private ToolStripMenuFNC _tsm;
		private Stream _stream;
        private Panel _sheetFinancial;
		private bool _openned;
        private PanelFinance _panfin;
        private ProjectFinancial _currentProject;
        private bool _viewTable = true;
        private string _fileName = string.Empty;
        #endregion

        #region Properties
        public new ToolStripMenuFNC Tsm
		{
			get { return _tsm; }
			set { _tsm = value as ToolStripMenuFNC; }
		}
        public Panel SheetFinancial
        {
            get { return _sheetFinancial; }
            set { _sheetFinancial = value; }
        }
		public override bool Openned
		{
			get { return _openned; }
		}
        public ProjectFinancial CurrentProject
        {
            get { return _currentProject; }
            set { _currentProject = value; }
        }
        public bool ViewTable
        {
            get { return _viewTable; }
            set { _viewTable = value; }
        }
		#endregion
		
		#region Constructor
        public Interface_fnc(List<String> lts)
		{
            BuildToolBar();
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
                Tsm._detail_mvt_list.Checked = false;
                Tsm._detail_reconciliation.Checked = false;
                Tsm._detail_user_list.Checked = false;

                _tsm.DisableOptions();
				_stream.Close();
			}
			catch
			{
				
			}
		}
		public override bool Save()
        {
            if (_currentProject != null)
            {
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "Financial files (*.fnc)|*.fnc|All files (*.*)|*.*";
                    if (!string.IsNullOrEmpty(_currentProject.Path))
                    {
                        FileInfo fi = new FileInfo(_currentProject.Path);
                        sfd.FileName = fi.Name;
                    }
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        _currentProject.Name = (new FileInfo(sfd.FileName).Name);
                        _currentProject.Path = sfd.FileName;
                        _currentProject.Save();
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
            //if (panelTB != null) { panelTB.Refresh(); }
            //if (panelGV != null) { panelGV.Refresh(); }
		}
		public override void GlobalAction(object sender, EventArgs e)
		{
			ToolBarEventArgs tbea = e as ToolBarEventArgs;
			string action = tbea.EventText;
			switch (action.ToLower())
            {
                case "dddevise":
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
            return _tsm;
        }
        public void RefreshPanel()
        {
            Balance();
            if (_panfin == null)
            {
                _panfin = new PanelFinance(this);
                _panfin.Dock = DockStyle.Fill;
                _panfin.BackgroundImage = _tsm.Gui.BackgroundImage;
                _panfin.BackgroundImageLayout = _tsm.Gui.BackgroundImageLayout;
                _panfin.Text = "Financial";
                _sheetFinancial.Controls.Add(_panfin);
            }
            else _panfin.Invalidate();
        }
        
        public void EditUser(int? userId)
        {
            using (UserEdit form = new UserEdit(this, userId))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    foreach (User usr in _currentProject.Users)
                    {
                        if (usr.ID == form.User.ID)
                        {
                            _currentProject.Users.Remove(usr);
                            break;
                        }
                    }
                    _currentProject.Users.Add(form.User);
                    RefreshPanel();
                }
            }
        }
        public void DeleteUser(int? userId)
        {   
            using (UserDelete form = new UserDelete(this, userId))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    foreach (User usr in _currentProject.Users)
                    {
                        if (usr.ID == form.User.ID)
                        {
                            _currentProject.Users.Remove(usr);
                            break;
                        }
                    }
                    RefreshPanel();
                }
            }
        }
        public void EditMvt(int? mvtId)
        {
            using (MvtEdit form = new MvtEdit(this, mvtId))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    foreach (Movement mvt in _currentProject.Movements)
                    {
                        if (mvt.ID == form.Movement.ID)
                        {
                            _currentProject.Movements.Remove(mvt);
                            break;
                        }
                    }
                    _currentProject.Movements.Add(form.Movement);
                    RefreshPanel();
                }
            }
        }
        public void EditMvt(string picPath)
        {
            using (MvtEdit form = new MvtEdit(this, picPath))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    foreach (Movement mvt in _currentProject.Movements)
                    {
                        if (mvt.ID == form.Movement.ID)
                        {
                            _currentProject.Movements.Remove(mvt);
                            break;
                        }
                    }
                    _currentProject.Movements.Add(form.Movement);
                    RefreshPanel();
                }
            }
        }
        public void DeleteMvt(int? mvtId)
        {
            using (MvtDelete form = new MvtDelete(this, mvtId))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    foreach (Movement mvt in _currentProject.Movements)
                    {
                        if (mvt.ID == form.Movement.ID)
                        {
                            _currentProject.Movements.Remove(mvt);
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
            Tsm.UpdateProjectDetails(_currentProject);
        }
        private void LaunchProjectUpdated()
        {
            DateTime dt = DateTime.MinValue;
            foreach (User user in _currentProject.Users)
            {
                foreach (var item in user.Calendars)
                {
                    if (item.Text.Equals(_currentProject.Name)) item.Text = _tsm.ProjectName.TextBoxText;
                }
            }
            _currentProject.Name = _tsm.ProjectName.TextBoxText;

            DateTime.TryParse(_tsm.ProjectStartDate.TextBoxText, out dt);
            if (dt != DateTime.MinValue) _currentProject.StartDate = dt;
            else _tsm.ProjectStartDate.TextBoxText = _currentProject.StartDate.ToShortDateString();
            dt = DateTime.MinValue;

            DateTime.TryParse(_tsm.ProjectEndDate.TextBoxText, out dt);
            if (dt != DateTime.MinValue) _currentProject.EndDate = dt;
            else _tsm.ProjectEndDate.TextBoxText = _currentProject.EndDate.ToShortDateString();
            dt = DateTime.MinValue;
        }
        private void LaunchBalance()
        {
            _currentProject.Balance();
        }
        private void LaunchWinUpdate()
        {
            _panfin.Refresh();
        }
        private void LaunchSwitchGraph()
        {
            if (_panfin.PanelGraphics.GraphMode == PanelGraph.GRAPHMODE.PIE) _panfin.SetGraphMode(PanelGraph.GRAPHMODE.BAR);
            else _panfin.SetGraphMode(PanelGraph.GRAPHMODE.PIE);
        }
        private void LaunchNewProject()
        {
            Tsm.DisablePresentation();
            Tsm.EnableUserList();
            Tsm.EnableGOP();
            Tsm.EnableMvtList();
            Tsm.EnableReconciliation();

            _currentProject = new ProjectFinancial();
            _tsm.UpdateProjectDetails(_currentProject);
            _tsm.EnableOptions();
            RefreshPanel();
        }
        private void LaunchOpenProject()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Financial files (*.fnc)|*.fnc|All files (*.*)|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                OpenProject(ofd.FileName);
            }
        }
        private void LaunchAddUser()
        {
            EditUser(null);
        }
        private void LaunchAddMovement()
        {
            EditMvt(string.Empty);
        }
        private void LaunchSwitchView()
        {
            _viewTable = !_viewTable;
            RefreshPanel();
        }
        private void LaunchCurrencyModif()
        {
            _currentProject.CurrencyProject = Movement.GetCurrency(_tsm.Currencies.SelectedItem.Text);
            _currentProject.Balance();
            RefreshPanel();
        }
        private void LaunchValueChangeModif()
        {
            if (_tsm.Changes.SelectedItem != null && !string.IsNullOrEmpty(_tsm.Changes.SelectedItem.Text) && _tsm.Changes.SelectedItem.Text.Split(' ').Length > 2)
            {
                string cur1, cur2;
                cur1 = _tsm.Changes.SelectedItem.Text.Split(' ')[0];
                cur2 = _tsm.Changes.SelectedItem.Text.Split(' ')[2];
                foreach (Change chg in _currentProject.Changes)
                {
                    if (cur1.Equals(chg.Currency1) && cur2.Equals(chg.Currency2))
                    {
                        chg.Rate = float.Parse(_tsm.ChangeValue.TextBoxText);
                    }
                    else if (cur2.Equals(chg.Currency1) && cur1.Equals(chg.Currency2))
                    {
                        chg.Rate = 1/float.Parse(_tsm.ChangeValue.TextBoxText);
                    }
                }
                _currentProject.Balance();
                RefreshPanel();
            }
        }
        private void LaunchChangeModif()
        {
            if (!string.IsNullOrEmpty(_tsm.Changes.SelectedItem.Text) && _tsm.Changes.SelectedItem.Text.Split(' ').Length > 2)
            {
                string cur1, cur2;
                cur1 = _tsm.Changes.SelectedItem.Text.Split(' ')[0];
                cur2 = _tsm.Changes.SelectedItem.Text.Split(' ')[2];
                foreach (Change chg in _currentProject.Changes)
                {
                    if (cur1.Equals(chg.Currency1) && cur2.Equals(chg.Currency2))
                    {
                        _tsm.LoadChangeValue(chg.Rate);
                        break;
                    }
                }
            }
        }
        private void LaunchImport()
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    _currentProject.Movements.AddRange(Movement.ImportMvt(ofd.FileName));
                }
            }
        }
        private void LaunchExportXml()
        {
            string exportStr = _currentProject.ExportXML();
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.FileName = "Export_" + _currentProject.Name + ".xml";
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
        }
        private void LaunchExportPdf()
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.FileName = "Export_" + _currentProject.Name + ".pdf";
                sfd.Filter = "PDF files (*.pdf)|*.pdf|All files (*.*)|*.*";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    _currentProject.ExportPDF(sfd.FileName);
                }
            }
        }
        private void LaunchExportWeb()
        {
            string exportStr = _currentProject.ExportWEB();
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.FileName = "Export_" + _currentProject.Name + ".html";
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
        }
        private void LaunchExportTxt()
        {
            string exportStr = _currentProject.ExportTXT();
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.FileName = "Export_" + _currentProject.Name + ".txt";
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
        }
        private void LaunchExportCsv()
        {
            string exportStr = _currentProject.ExportCSV();
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.FileName = "Export_" + _currentProject.Name + ".csv";
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
        }
        private void LaunchTakeBill()
        {
            using (CamGUI myCamGUi = new CamGUI())
            {
                if (myCamGUi.ShowDialog() == DialogResult.OK)
                {
                    EditMvt(myCamGUi.PicturePath);
                }
            }
        }
        #endregion

        #region Methods	private
        private void OpenProject(string fileName)
        {
            Tsm.DisablePresentation();
            Tsm.EnableUserList();
            Tsm.EnableGOP();
            Tsm.EnableMvtList();
            Tsm.EnableReconciliation();

            _fileName = fileName;
            _currentProject = new ProjectFinancial(fileName);
            _tsm.EnableOptions();
            RefreshPanel();
            _tsm.UpdateProjectDetails(_currentProject);
            this._openned = true;
        }
        private void Balance()
        {
            if (_currentProject!= null) _currentProject.Balance();
            if (_panfin != null) _panfin.Refresh();
        }
        #endregion
		
		#region Event
		#endregion
    }
}
