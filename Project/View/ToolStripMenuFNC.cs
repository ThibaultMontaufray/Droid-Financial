// log code 42 00
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Tools4Libraries;

namespace Droid_financial
{
    public class ToolStripMenuFNC : RibbonTab
    {
        #region Attribute
        private FinancialActivity _currentProjet;
        public event EventHandlerAction ActionAppened;
        private GUI _gui;
        private RibbonButton _rb_openProject;
        private RibbonButton _rb_newProject;
        private RibbonPanel _panelProject;

        private RibbonButton _rb_import;
        private RibbonButton _rb_balance;
        private RibbonButton _rb_export;
        private RibbonDescriptionMenuItem _detail_export_csv;
        private RibbonDescriptionMenuItem _detail_export_xml;
        private RibbonDescriptionMenuItem _detail_export_txt;
        private RibbonDescriptionMenuItem _detail_export_web;
        private RibbonDescriptionMenuItem _detail_export_pdf;
        private RibbonButton _rb_print;
        private RibbonButton _rb_add_user;
        private RibbonButton _rb_addExps;
        private RibbonButton _rb_takeBill;
        private RibbonPanel _panelTools;

        private RibbonButton _rb_add_devise;
        private RibbonComboBox _rb_cb_currency;
        private RibbonComboBox _rb_cb_change;
        private RibbonTextBox _rb_textbox_change;
        private RibbonPanel _panelCurrency;

        private RibbonTextBox _rb_projectName;
        private RibbonTextBox _rb_projectStartDate;
        private RibbonTextBox _rb_projectEndDate;
        private RibbonPanel _panelProjectSettings;

        private RibbonButton _rb_switchGraphMode;
        private RibbonButton _rb_menu_tile;
        public RibbonDescriptionMenuItem _detail_gop_rate;
        public RibbonDescriptionMenuItem _detail_user_list;
        public RibbonDescriptionMenuItem _detail_exps_list;
        public RibbonDescriptionMenuItem _detail_reconciliation;
        public RibbonDescriptionMenuItem _detail_presentation;
        private RibbonPanel _panelView;

        private RibbonItem _global_ri;
        #endregion

        #region Properties
        public GUI Gui
        {
            get { return _gui; }
            set { _gui = value; }
        }
        public RibbonComboBox Changes
        {
            get { return _rb_cb_change; }
        }
        public RibbonComboBox Currencies
        {
            get { return _rb_cb_currency; }
        }
        public RibbonTextBox ChangeValue
        {
            get { return _rb_textbox_change; }
            set { _rb_textbox_change = value; }
        }
        public RibbonTextBox ProjectName
        {
            get { return _rb_projectName; }
            set { _rb_projectName = value; }
        }
        public RibbonTextBox ProjectStartDate
        {
            get { return _rb_projectStartDate; }
            set { _rb_projectStartDate = value; }
        }
        public RibbonTextBox ProjectEndDate
        {
            get { return _rb_projectEndDate; }
            set { _rb_projectEndDate = value; }
        }
        #endregion

        #region Constructor
        public ToolStripMenuFNC()
        {
            Init();
        }
        #endregion

        #region Methods public
        public void Init()
        {
            try
            {
                _gui = new GUI();

                BuildPanelMain();
                BuildPanelProjectSettings();
                BuildPanelTools();
                BuildPanelCurrency();
                BuildPanelView();
                DisableOptions();

                this.Panels.Add(_panelProject);
                this.Panels.Add(_panelView);
                this.Panels.Add(_panelProjectSettings);
                this.Panels.Add(_panelTools);
                this.Panels.Add(_panelCurrency);
                this.Text = "Financial";
            }
            catch (Exception exp4200)
            {
                Log.Write("[ CRT : 4200 ] Cannot open financial menu.\n" + exp4200.Message);
                //this.Dispose();
            }
        }
        public void OnAction(EventArgs e)
        {
            if (ActionAppened != null) ActionAppened(this, e);
        }
        public void EnableOptions()
        {
            _panelTools.Enabled = true;
            _panelCurrency.Enabled = true;
            _panelProjectSettings.Enabled = true;
            _rb_switchGraphMode.Enabled = true;
            _detail_gop_rate.Enabled = true;
            _detail_exps_list.Enabled = true;
            _detail_user_list.Enabled = true;
            _detail_reconciliation.Enabled = true;

            _rb_print.Enabled = false;
        }
        public void DisableOptions()
        {
            _panelTools.Enabled = false;
            _panelCurrency.Enabled = false;
            _panelProjectSettings.Enabled = false;
            _rb_switchGraphMode.Enabled = false;
            _detail_gop_rate.Enabled = false;
            _detail_exps_list.Enabled = false;
            _detail_user_list.Enabled = false;
            _detail_reconciliation.Enabled = false;
        }
        public void UpdateProjectDetails(FinancialActivity pj)
        {
            if (pj != null)
            {
                _currentProjet = pj;
                _rb_cb_change.DropDownItems.Clear();
                _rb_cb_currency.DropDownItems.Clear();
                List<string> ls = new List<string>();
                foreach (Expense item in pj.ListExpenses)
                {
                    if (!ls.Contains(item.Currency.ToString())) ls.Add(item.Currency.ToString());
                }
                foreach (Change item in pj.Changes)
                {
                    if (!ls.Contains(item.Currency1.ToString())) ls.Add(item.Currency1.ToString());
                    if (!ls.Contains(item.Currency2.ToString())) ls.Add(item.Currency2.ToString());

                    _global_ri = new RibbonLabel();
                    _global_ri.Text = item.Currency1.ToString() + " => " + item.Currency2.ToString();
                    _global_ri.Image = ((System.Drawing.Image)(Tools4Libraries.Resources.ResourceIconSet16Default.conversion_of_currency));
                    _rb_cb_change.DropDownItems.Add(_global_ri);
                }
                foreach (string s in ls)
                {
                    _global_ri = new RibbonLabel();
                    _global_ri.Text = s;
                    _global_ri.Image = ((System.Drawing.Image)(Tools4Libraries.Resources.ResourceIconSet16Default.coins));
                    _rb_cb_currency.DropDownItems.Add(_global_ri);
                }
                foreach (RibbonItem item in _rb_cb_currency.DropDownItems)
                {
                    if (item.Text.Equals(pj.CurrencyUsed.ToString()))
                    {
                        _rb_cb_currency.SelectedItem = item;
                        break;
                    }
                }
                foreach (RibbonItem item in _rb_cb_change.DropDownItems)
                {
                    if (item.Text.StartsWith(pj.CurrencyUsed.ToString()))
                    {
                        _rb_cb_change.SelectedItem = item;
                        break;
                    }
                }
                _rb_projectName.TextBoxText = pj.Name;
                _rb_projectStartDate.TextBoxText = pj.StartDate.ToShortDateString();
                _rb_projectEndDate.TextBoxText = pj.EndDate.ToShortDateString();
            }
        }
        public void LoadChangeValue(double val)
        {
            _rb_textbox_change.TextBoxText = val.ToString();
        }

        public void EnablePresentation()
        {
            _detail_presentation.Text = "Disable financial module presentation                       ";
            _detail_presentation.Image = Tools4Libraries.Resources.ResourceIconSet32Default.directory_listing_checked;
        }
        public void EnableUserList()
        {
            _detail_user_list.Text = "Disable users list                                          ";
            _detail_user_list.Image = Tools4Libraries.Resources.ResourceIconSet32Default.participation_rate_checked;
        }
        public void EnableExpsList()
        {
            _detail_exps_list.Text = "Disable movement list                                       ";
            _detail_exps_list.Image = Tools4Libraries.Resources.ResourceIconSet32Default.table_money_checked;
        }
        public void EnableReconciliation()
        {
            _detail_reconciliation.Text = "Disable reconciliation                                      ";
            _detail_reconciliation.Image = Tools4Libraries.Resources.ResourceIconSet32Default.balance_unbalance_checked;
        }
        public void EnableGOP()
        {
            _detail_gop_rate.Text = "Disable group of operation                                  ";
            _detail_gop_rate.Image = Tools4Libraries.Resources.ResourceIconSet32Default.statistics_checked;
        }

        public void DisablePresentation()
        {
            _detail_presentation.Text = "Enable financial module presentation                       ";
            _detail_presentation.Image = Tools4Libraries.Resources.ResourceIconSet32Default.directory_listing_unchecked;
        }
        public void DisableUserList()
        {
            _detail_user_list.Text = "Enable users list                                          ";
            _detail_user_list.Image = Tools4Libraries.Resources.ResourceIconSet32Default.participation_rate_unchecked;
        }
        public void DisableExpsList()
        {
            _detail_exps_list.Text = "Enable movement list                                       ";
            _detail_exps_list.Image = Tools4Libraries.Resources.ResourceIconSet32Default.table_money_unchecked;
        }
        public void DisableReconciliation()
        {
            _detail_reconciliation.Text = "Enable reconciliation                                      ";
            _detail_reconciliation.Image = Tools4Libraries.Resources.ResourceIconSet32Default.balance_unbalance_unchecked;
        }
        public void DisableGOP()
        {
            _detail_gop_rate.Text = "Enable group of operation                                  ";
            _detail_gop_rate.Image = Tools4Libraries.Resources.ResourceIconSet32Default.statistics_unchecked;
        }
        #endregion

        #region Methods private
        private void BuildPanelMain()
        {
            _rb_openProject = new RibbonButton("Open project");
            _rb_openProject.Click += new EventHandler(rb_openProject_Click);
            _rb_openProject.Image = ((System.Drawing.Image)(Tools4Libraries.Resources.ResourceIconSet32Default.open_folder));
            _rb_openProject.SmallImage = ((System.Drawing.Image)(Tools4Libraries.Resources.ResourceIconSet16Default.open_folder));

            _rb_newProject = new RibbonButton("New project");
            _rb_newProject.Click += new EventHandler(rb_newProject_Click);
            _rb_newProject.Image = ((System.Drawing.Image)(Tools4Libraries.Resources.ResourceIconSet32Default.folder_add));
            _rb_newProject.SmallImage = ((System.Drawing.Image)(Tools4Libraries.Resources.ResourceIconSet16Default.folder_add));

            _panelProject = new RibbonPanel();
            _panelProject.Text = "Project";
            _panelProject.Items.Add(_rb_newProject);
            _panelProject.Items.Add(_rb_openProject);
        }
        private void BuildPanelTools()
        {
            _rb_import = new RibbonButton("Import movements");
            _rb_import.Click += new EventHandler(rb_import_Click);
            _rb_import.Image = ((System.Drawing.Image)(Tools4Libraries.Resources.ResourceIconSet32Default.file_extension_xls));
            _rb_import.SmallImage = ((System.Drawing.Image)(Tools4Libraries.Resources.ResourceIconSet16Default.file_extension_xls));

            _detail_export_csv = new RibbonDescriptionMenuItem();
            _detail_export_csv.Image = Tools4Libraries.Resources.ResourceIconSet32Default.file_extension_csv;
            _detail_export_csv.Text = "Export CSV                                                ";
            _detail_export_csv.Description = "Table format to make other calculs";
            _detail_export_csv.MinSizeMode = RibbonElementSizeMode.Large;
            _detail_export_csv.Click += detail_export_csv_Click;

            _detail_export_txt = new RibbonDescriptionMenuItem();
            _detail_export_txt.Image = Tools4Libraries.Resources.ResourceIconSet32Default.file_extension_txt;
            _detail_export_txt.Text = "Export TXT                                                ";
            _detail_export_txt.Description = "Text description of the project";
            _detail_export_txt.MinSizeMode = RibbonElementSizeMode.Large;
            _detail_export_txt.Click += detail_export_txt_Click;

            _detail_export_xml = new RibbonDescriptionMenuItem();
            _detail_export_xml.Image = Tools4Libraries.Resources.ResourceIconSet32Default.page_white_code;
            _detail_export_xml.Text = "Export XML                                                ";
            _detail_export_xml.Description = "XML format to inject in other applications";
            _detail_export_xml.MinSizeMode = RibbonElementSizeMode.Large;
            _detail_export_xml.Click += detail_export_xml_Click;

            _detail_export_web = new RibbonDescriptionMenuItem();
            _detail_export_web.Image = Tools4Libraries.Resources.ResourceIconSet32Default.file_extension_html;
            _detail_export_web.Text = "Export web                                                ";
            _detail_export_web.Description = "Format HTML to be displayed in web browser";
            _detail_export_web.MinSizeMode = RibbonElementSizeMode.Large;
            _detail_export_web.Click += detail_export_web_Click;

            _detail_export_pdf = new RibbonDescriptionMenuItem();
            _detail_export_pdf.Image = Tools4Libraries.Resources.ResourceIconSet32Default.file_extension_pdf;
            _detail_export_pdf.Text = "Export PDF                                                ";
            _detail_export_pdf.Description = "PDF presentation for officcial report";
            _detail_export_pdf.MinSizeMode = RibbonElementSizeMode.Large;
            _detail_export_pdf.Click += detail_export_pdf_Click;

            _rb_export = new RibbonButton("export movements");
            _rb_export.Image = Tools4Libraries.Resources.ResourceIconSet32Default.insert_element;
            _rb_export.MinSizeMode = RibbonElementSizeMode.Large;
            _rb_export.MaxSizeMode = RibbonElementSizeMode.Large;
            _rb_export.Style = RibbonButtonStyle.SplitDropDown;
            _rb_export.DropDownItems.Add(_detail_export_pdf);
            _rb_export.DropDownItems.Add(_detail_export_csv);
            _rb_export.DropDownItems.Add(_detail_export_xml);
            _rb_export.DropDownItems.Add(_detail_export_web);
            _rb_export.DropDownItems.Add(_detail_export_txt);
            //_rb_export.DrawIconsBar = false;
            _rb_export.TextAlignment = RibbonItem.RibbonItemTextAlignment.Left;
            
            _rb_print = new RibbonButton("print");
            _rb_print.Enabled = false;
            _rb_print.Click += new EventHandler(rb_print_Click);
            _rb_print.Image = ((System.Drawing.Image)(Tools4Libraries.Resources.ResourceIconSet32Default.printer));
            _rb_print.SmallImage = ((System.Drawing.Image)(Tools4Libraries.Resources.ResourceIconSet32Default.printer));

            _rb_add_user = new RibbonButton("Add owner");
            _rb_add_user.Click += new EventHandler(rb_addUser_Click);
            _rb_add_user.SmallImage = ((System.Drawing.Image)(Tools4Libraries.Resources.ResourceIconSet16Default.user_add));
            _rb_add_user.Image = ((System.Drawing.Image)(Tools4Libraries.Resources.ResourceIconSet32Default.user_add));

            _rb_balance = new RibbonButton("Balance");
            _rb_balance.Click += new EventHandler(rb_balance_Click);
            _rb_balance.SmallImage = ((System.Drawing.Image)(Tools4Libraries.Resources.ResourceIconSet16Default.small_business));
            _rb_balance.Image = ((System.Drawing.Image)(Tools4Libraries.Resources.ResourceIconSet32Default.balance_unbalance));

            _rb_takeBill = new RibbonButton("Take bill");
            _rb_takeBill.Click += new EventHandler(rb_takeBill_Click);
            _rb_takeBill.SmallImage = ((System.Drawing.Image)(Tools4Libraries.Resources.ResourceIconSet16Default.webcam));
            _rb_takeBill.Image = ((System.Drawing.Image)(Tools4Libraries.Resources.ResourceIconSet32Default.webcam));
            
            _rb_addExps = new RibbonButton("Add movement");
            _rb_addExps.Click += new EventHandler(rb_addevent_Click);
            _rb_addExps.Image = ((System.Drawing.Image)(Tools4Libraries.Resources.ResourceIconSet32Default.note_add));
            _rb_addExps.SmallImage = ((System.Drawing.Image)(Tools4Libraries.Resources.ResourceIconSet16Default.note_add));

            _panelTools = new RibbonPanel();
            _panelTools.Text = "Tools";
            _panelTools.Items.Add(_rb_add_user);
            _panelTools.Items.Add(_rb_takeBill);
            _panelTools.Items.Add(_rb_addExps);
            _panelTools.Items.Add(_rb_balance);
            _panelTools.Items.Add(_rb_export);
            _panelTools.Items.Add(_rb_import);
            _panelTools.Items.Add(_rb_print);
        }
        private void BuildPanelCurrency()
        {
            _rb_add_devise = new RibbonButton("Add devise");
            _rb_add_devise.Click += new EventHandler(rb_add_devise_Click);
            _rb_add_devise.SmallImage = ((System.Drawing.Image)(Tools4Libraries.Resources.ResourceIconSet16Default.conversion_of_currency));
            _rb_add_devise.Image = ((System.Drawing.Image)(Tools4Libraries.Resources.ResourceIconSet32Default.conversion_of_currency));

            _rb_textbox_change = new RibbonTextBox();
            _rb_textbox_change.Text = "Value : ";
            _rb_textbox_change.LabelWidth = 70;
            _rb_textbox_change.TextBoxWidth = 130;
            _rb_textbox_change.TextBoxValidated += rb_textbox_change_TextBoxTextChanged;

            _rb_cb_currency = new RibbonComboBox();
            _rb_cb_currency.AllowTextEdit = false;
            _rb_cb_currency.TextBoxValidated += rb_cb_currency_TextBoxTextChanged;
            _rb_cb_currency.Text = "Used currency : ";
            _rb_cb_currency.LabelWidth = 100;
            _rb_cb_currency.TextBoxWidth = 100;

            _rb_cb_change = new RibbonComboBox();
            _rb_cb_change.AllowTextEdit = false;
            _rb_cb_change.TextBoxTextChanged += rb_cb_change_TextBoxTextChanged;
            _rb_cb_change.Text = "Changes taux : ";
            _rb_cb_change.LabelWidth = 100;
            _rb_cb_change.TextBoxWidth = 100;

            _panelCurrency = new RibbonPanel();
            _panelCurrency.Text = "Currency - change";
            _panelCurrency.Items.Add(_rb_cb_currency);
            _panelCurrency.Items.Add(_rb_cb_change);
            _panelCurrency.Items.Add(_rb_textbox_change);
            _panelCurrency.Items.Add(_rb_add_devise);
        }
        private void BuildPanelView()
        {
            _rb_switchGraphMode = new RibbonButton("Graph mode");
            _rb_switchGraphMode.ToolTip = "Switch to bar graph mode";
            _rb_switchGraphMode.Click += new EventHandler(rb_graphMode_Click);
            _rb_switchGraphMode.Image = ((System.Drawing.Image)(Tools4Libraries.Resources.ResourceIconSet32Default.barchart));
            _rb_switchGraphMode.SmallImage = ((System.Drawing.Image)(Tools4Libraries.Resources.ResourceIconSet16Default.shape_align_bottom));

            _detail_presentation = new RibbonDescriptionMenuItem();
            _detail_presentation.Image = Tools4Libraries.Resources.ResourceIconSet32Default.directory_listing_checked;
            _detail_presentation.Text = "Disable financial module presentation                       ";
            _detail_presentation.Description = "Display the panel of presentation of this module";
            _detail_presentation.MinSizeMode = RibbonElementSizeMode.Large;
            _detail_presentation.Click += _detail_presentation_Click;

            _detail_gop_rate = new RibbonDescriptionMenuItem();
            _detail_gop_rate.Image = Tools4Libraries.Resources.ResourceIconSet32Default.statistics_unchecked;
            _detail_gop_rate.Text = "Enable group of operation                                  ";
            _detail_gop_rate.Description = "Display the detail of operation group with graphics rates";
            _detail_gop_rate.MinSizeMode = RibbonElementSizeMode.Large;
            _detail_gop_rate.Click += _detail_gop_rate_Click;

            _detail_exps_list = new RibbonDescriptionMenuItem();
            _detail_exps_list.Image = Tools4Libraries.Resources.ResourceIconSet32Default.table_money_unchecked;
            _detail_exps_list.Text = "Enable movement list                                       ";
            _detail_exps_list.Description = "Display the list of all movement with details";
            _detail_exps_list.MinSizeMode = RibbonElementSizeMode.Large;
            _detail_exps_list.Click += _detail_exps_list_Click;

            _detail_user_list = new RibbonDescriptionMenuItem();
            _detail_user_list.Image = Tools4Libraries.Resources.ResourceIconSet32Default.participation_rate_unchecked;
            _detail_user_list.Text = "Enable users list                                          ";
            _detail_user_list.Description = "Display the list of account owners";
            _detail_user_list.MinSizeMode = RibbonElementSizeMode.Large;
            _detail_user_list.Click += _detail_user_list_Click;

            _detail_reconciliation = new RibbonDescriptionMenuItem();
            _detail_reconciliation.Image = Tools4Libraries.Resources.ResourceIconSet32Default.balance_unbalance_unchecked;
            _detail_reconciliation.Text = "Enable reconciliation                                      ";
            _detail_reconciliation.Description = "Display the equilibration table between account owners";
            _detail_reconciliation.MinSizeMode = RibbonElementSizeMode.Large;
            _detail_reconciliation.Click += _detail_reconciliation_Click;

            _rb_menu_tile = new RibbonButton();
            _rb_menu_tile.Text = "Menu tiles";
            _rb_menu_tile.Image = Tools4Libraries.Resources.ResourceIconSet32Default.large_tiles;
            _rb_menu_tile.MinSizeMode = RibbonElementSizeMode.Large;
            _rb_menu_tile.MaxSizeMode = RibbonElementSizeMode.Large;
            _rb_menu_tile.Style = RibbonButtonStyle.SplitDropDown;
            _rb_menu_tile.DropDownItems.Add(_detail_presentation);
            _rb_menu_tile.DropDownItems.Add(_detail_gop_rate);
            _rb_menu_tile.DropDownItems.Add(_detail_user_list);
            _rb_menu_tile.DropDownItems.Add(_detail_exps_list);
            _rb_menu_tile.DropDownItems.Add(_detail_reconciliation);
            //_rb_menu_tile.DrawIconsBar = false;
            _rb_menu_tile.TextAlignment = RibbonItem.RibbonItemTextAlignment.Left;

            _panelView = new RibbonPanel();
            _panelView.Text = "Views";
            _panelView.Items.Add(_rb_menu_tile);
            _panelView.Items.Add(_rb_switchGraphMode);
        }
        private void BuildPanelProjectSettings()
        {
            _rb_projectName = new RibbonTextBox();
            _rb_projectName.Text = "Name : ";
            _rb_projectName.LabelWidth = 70;
            _rb_projectName.TextBoxWidth = 170;
            _rb_projectName.TextBoxValidated += rb_projectUpdated;

            _rb_projectStartDate = new RibbonTextBox();
            _rb_projectStartDate.Text = "End date : ";
            _rb_projectStartDate.LabelWidth = 70;
            _rb_projectStartDate.TextBoxWidth = 170;
            _rb_projectStartDate.TextBoxValidated += rb_projectUpdated;

            _rb_projectEndDate = new RibbonTextBox();
            _rb_projectEndDate.Text = "Start date : ";
            _rb_projectEndDate.LabelWidth = 70;
            _rb_projectEndDate.TextBoxWidth = 170;
            _rb_projectEndDate.TextBoxValidated += rb_projectUpdated;

            _panelProjectSettings = new RibbonPanel();
            _panelProjectSettings.Text = "Project settings";
            _panelProjectSettings.Items.Add(_rb_projectName);
            _panelProjectSettings.Items.Add(_rb_projectStartDate);
            _panelProjectSettings.Items.Add(_rb_projectEndDate);
        }
        #endregion

        #region Event
        private void rb_openProject_Click(object sender, EventArgs e)
        {
            _rb_openProject.Checked = false;
            ToolBarEventArgs action = new ToolBarEventArgs("openProject");
            OnAction(action);
        }
        private void rb_newProject_Click(object sender, EventArgs e)
        {
            _rb_newProject.Checked = false;
            ToolBarEventArgs action = new ToolBarEventArgs("newProject");
            OnAction(action);
        }
        private void rb_addUser_Click(object sender, EventArgs e)
        {
            _rb_add_user.Checked = false;
            ToolBarEventArgs action = new ToolBarEventArgs("addUser");
            OnAction(action);
        }
        private void rb_takeBill_Click(object sender, EventArgs e)
        {
            _rb_takeBill.Checked = false;
            ToolBarEventArgs action = new ToolBarEventArgs("takeBill");
            OnAction(action);
        }
        private void rb_import_Click(object sender, EventArgs e)
        {
            _rb_import.Checked = false;
            ToolBarEventArgs action = new ToolBarEventArgs("import");
            OnAction(action);
        }
        private void rb_print_Click(object sender, EventArgs e)
        {
            _rb_print.Checked = false;
            ToolBarEventArgs action = new ToolBarEventArgs("print");
            OnAction(action);
        }
        private void rb_balance_Click(object sender, EventArgs e)
        {
            _rb_balance.Checked = false;
            ToolBarEventArgs action = new ToolBarEventArgs("balance");
            OnAction(action);
        }
        private void rb_add_devise_Click(object sender, EventArgs e)
        {
            _rb_balance.Checked = false;
            ToolBarEventArgs action = new ToolBarEventArgs("adddevise");
            OnAction(action);
        }
        private void detail_export_csv_Click(object sender, EventArgs e)
        {
            _rb_export.Checked = false;
            ToolBarEventArgs action = new ToolBarEventArgs("exportcsv");
            OnAction(action);
        }
        private void detail_export_txt_Click(object sender, EventArgs e)
        {
            _rb_export.Checked = false;
            ToolBarEventArgs action = new ToolBarEventArgs("exporttxt");
            OnAction(action);
        }
        private void detail_export_xml_Click(object sender, EventArgs e)
        {
            _rb_export.Checked = false;
            ToolBarEventArgs action = new ToolBarEventArgs("exportxml");
            OnAction(action);
        }
        private void detail_export_web_Click(object sender, EventArgs e)
        {
            _rb_export.Checked = false;
            ToolBarEventArgs action = new ToolBarEventArgs("exportweb");
            OnAction(action);
        }
        private void detail_export_pdf_Click(object sender, EventArgs e)
        {
            _rb_export.Checked = false;
            ToolBarEventArgs action = new ToolBarEventArgs("exportpdf");
            OnAction(action);
        }
        private void rb_addevent_Click(object sender, EventArgs e)
        {
            _rb_addExps.Checked = false;
            ToolBarEventArgs action = new ToolBarEventArgs("addevent");
            OnAction(action);
        }
        private void rb_cb_change_TextBoxTextChanged(object sender, EventArgs e)
        {
            _rb_cb_change.Checked = false;
            ToolBarEventArgs action = new ToolBarEventArgs("changemodified");
            OnAction(action);
        }
        private void rb_cb_currency_TextBoxTextChanged(object sender, EventArgs e)
        {
            _rb_cb_currency.Checked = false;
            ToolBarEventArgs action = new ToolBarEventArgs("currencymodified");
            OnAction(action);
        }
        private void rb_textbox_change_TextBoxTextChanged(object sender, EventArgs e)
        {
            _rb_textbox_change.Checked = false;
            _rb_textbox_change.TextBoxText = _rb_textbox_change.TextBoxText.Replace('.', ',');
            Regex rexFloat = new Regex(@"^[0-9]*(?:\,[0-9]*)?$");
            if (rexFloat.IsMatch(_rb_textbox_change.TextBoxText))
            {
                ToolBarEventArgs action = new ToolBarEventArgs("valueChangemodified");
                OnAction(action);
            }
            else if (_currentProjet != null)
            {
                foreach(Change chg in _currentProjet.Changes)
                {
                    if (_rb_cb_change.SelectedItem.Text.Equals(chg.Currency1 + " => " + chg.Currency2))
                    {
                        _rb_textbox_change.TextBoxText = chg.Rate.ToString();
                        break;
                    }
                }
            }
        }
        private void rb_graphMode_Click(object sender, EventArgs e)
        {
            _rb_switchGraphMode.Checked = false;
            if (_rb_switchGraphMode.ToolTip == "Switch to pie graph mode")
            {
                _rb_switchGraphMode.ToolTip = "Switch to bar graph mode";
                _rb_switchGraphMode.Image = Tools4Libraries.Resources.ResourceIconSet32Default.barchart;
                _rb_switchGraphMode.SmallImage = Tools4Libraries.Resources.ResourceIconSet16Default.shape_align_bottom;
            }
            else
            {
                _rb_switchGraphMode.ToolTip = "Switch to pie graph mode";
                _rb_switchGraphMode.Image = Tools4Libraries.Resources.ResourceIconSet32Default.piechart;
                _rb_switchGraphMode.SmallImage = Tools4Libraries.Resources.ResourceIconSet16Default.piechart;
            }
            ToolBarEventArgs action = new ToolBarEventArgs("changeGraphMode");
            OnAction(action);
        }
        private void rb_projectUpdated(object sender, EventArgs e)
        {
            _rb_projectName.Checked = false;
            _rb_projectStartDate.Checked = false;
            _rb_projectEndDate.Checked = false;
            ToolBarEventArgs action = new ToolBarEventArgs("projectUpdated");
            OnAction(action);
        }
        private void actualTextbox_LostFocus(object sender, EventArgs e)
        {
            ToolBarEventArgs action = new ToolBarEventArgs("changeValModified");
            OnAction(action);
        }
        private void _detail_reconciliation_Click(object sender, EventArgs e)
        {
            if (_detail_reconciliation.Text.StartsWith("Disable")) DisableReconciliation();
            else EnableReconciliation();
            ToolBarEventArgs action = new ToolBarEventArgs("winupdate");
            OnAction(action);
        }
        private void _detail_user_list_Click(object sender, EventArgs e)
        {
            if (_detail_user_list.Text.StartsWith("Disable")) DisableUserList();
            else EnableUserList();
            ToolBarEventArgs action = new ToolBarEventArgs("winupdate");
            OnAction(action);
        }
        private void _detail_exps_list_Click(object sender, EventArgs e)
        {
            if (_detail_exps_list.Text.StartsWith("Disable")) DisableExpsList();
            else EnableExpsList();
            ToolBarEventArgs action = new ToolBarEventArgs("winupdate");
            OnAction(action);
        }
        private void _detail_gop_rate_Click(object sender, EventArgs e)
        {
            if (_detail_gop_rate.Text.StartsWith("Disable")) DisableGOP();
            else EnableGOP();
            ToolBarEventArgs action = new ToolBarEventArgs("winupdate");
            OnAction(action);
        }
        private void _detail_presentation_Click(object sender, EventArgs e)
        {
            if (_detail_presentation.Text.StartsWith("Disable")) DisablePresentation();
            else EnablePresentation();
            ToolBarEventArgs action = new ToolBarEventArgs("winupdate");
            OnAction(action);
        }
        #endregion
    }
}
