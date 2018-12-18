namespace Droid.financial
{
    partial class ActivityPreviewPro
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series9 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series10 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series11 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series12 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelCA = new System.Windows.Forms.Panel();
            this.labelAmountTurnover = new System.Windows.Forms.Label();
            this.labelTurnoverThisMonth = new System.Windows.Forms.Label();
            this.labelCA = new System.Windows.Forms.Label();
            this.panelPendingBills = new System.Windows.Forms.Panel();
            this.labelAmountBills = new System.Windows.Forms.Label();
            this.labelCountPendingBills = new System.Windows.Forms.Label();
            this.labelPendingBills = new System.Windows.Forms.Label();
            this.panelBillsUnpaid = new System.Windows.Forms.Panel();
            this.labelAmountUnpaidBills = new System.Windows.Forms.Label();
            this.labelCountUnpaidBills = new System.Windows.Forms.Label();
            this.labelUnpaidBills = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chartTurnover = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.labelCollectedTurnover = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chartCeiling = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.labelCeilingValue = new System.Windows.Forms.Label();
            this.labelCeilingForEarning = new System.Windows.Forms.Label();
            this.panelMis = new System.Windows.Forms.Panel();
            this.dataGridViewCotisation = new System.Windows.Forms.DataGridView();
            this.ColumnLabel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labelEstimationContributions = new System.Windows.Forms.Label();
            this.viewAccountResume = new Droid.financial.ViewAccountResume();
            this.buttonClose = new System.Windows.Forms.Button();
            this.panelCA.SuspendLayout();
            this.panelPendingBills.SuspendLayout();
            this.panelBillsUnpaid.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartTurnover)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartCeiling)).BeginInit();
            this.panelMis.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCotisation)).BeginInit();
            this.SuspendLayout();
            // 
            // panelCA
            // 
            this.panelCA.Controls.Add(this.labelAmountTurnover);
            this.panelCA.Controls.Add(this.labelTurnoverThisMonth);
            this.panelCA.Controls.Add(this.labelCA);
            this.panelCA.Location = new System.Drawing.Point(10, 55);
            this.panelCA.Name = "panelCA";
            this.panelCA.Size = new System.Drawing.Size(150, 100);
            this.panelCA.TabIndex = 0;
            // 
            // labelAmountTurnover
            // 
            this.labelAmountTurnover.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelAmountTurnover.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAmountTurnover.ForeColor = System.Drawing.Color.Lime;
            this.labelAmountTurnover.Location = new System.Drawing.Point(0, 28);
            this.labelAmountTurnover.Name = "labelAmountTurnover";
            this.labelAmountTurnover.Size = new System.Drawing.Size(150, 41);
            this.labelAmountTurnover.TabIndex = 12;
            this.labelAmountTurnover.Text = "0,00 €";
            this.labelAmountTurnover.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelTurnoverThisMonth
            // 
            this.labelTurnoverThisMonth.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelTurnoverThisMonth.Location = new System.Drawing.Point(0, 69);
            this.labelTurnoverThisMonth.Name = "labelTurnoverThisMonth";
            this.labelTurnoverThisMonth.Size = new System.Drawing.Size(150, 31);
            this.labelTurnoverThisMonth.TabIndex = 11;
            this.labelTurnoverThisMonth.Text = "0,00 this month";
            this.labelTurnoverThisMonth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelCA
            // 
            this.labelCA.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelCA.Location = new System.Drawing.Point(0, 0);
            this.labelCA.Name = "labelCA";
            this.labelCA.Size = new System.Drawing.Size(150, 28);
            this.labelCA.TabIndex = 6;
            this.labelCA.Text = "Turnover 2018";
            this.labelCA.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelPendingBills
            // 
            this.panelPendingBills.Controls.Add(this.labelAmountBills);
            this.panelPendingBills.Controls.Add(this.labelCountPendingBills);
            this.panelPendingBills.Controls.Add(this.labelPendingBills);
            this.panelPendingBills.Location = new System.Drawing.Point(175, 55);
            this.panelPendingBills.Name = "panelPendingBills";
            this.panelPendingBills.Size = new System.Drawing.Size(150, 100);
            this.panelPendingBills.TabIndex = 1;
            // 
            // labelAmountBills
            // 
            this.labelAmountBills.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelAmountBills.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAmountBills.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.labelAmountBills.Location = new System.Drawing.Point(0, 28);
            this.labelAmountBills.Name = "labelAmountBills";
            this.labelAmountBills.Size = new System.Drawing.Size(150, 41);
            this.labelAmountBills.TabIndex = 13;
            this.labelAmountBills.Text = "0,00 €";
            this.labelAmountBills.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelCountPendingBills
            // 
            this.labelCountPendingBills.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelCountPendingBills.Location = new System.Drawing.Point(0, 69);
            this.labelCountPendingBills.Name = "labelCountPendingBills";
            this.labelCountPendingBills.Size = new System.Drawing.Size(150, 31);
            this.labelCountPendingBills.TabIndex = 12;
            this.labelCountPendingBills.Text = "0 pending bills";
            this.labelCountPendingBills.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelPendingBills
            // 
            this.labelPendingBills.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelPendingBills.Location = new System.Drawing.Point(0, 0);
            this.labelPendingBills.Name = "labelPendingBills";
            this.labelPendingBills.Size = new System.Drawing.Size(150, 28);
            this.labelPendingBills.TabIndex = 7;
            this.labelPendingBills.Text = "Pending bills";
            this.labelPendingBills.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelBillsUnpaid
            // 
            this.panelBillsUnpaid.Controls.Add(this.labelAmountUnpaidBills);
            this.panelBillsUnpaid.Controls.Add(this.labelCountUnpaidBills);
            this.panelBillsUnpaid.Controls.Add(this.labelUnpaidBills);
            this.panelBillsUnpaid.Location = new System.Drawing.Point(340, 55);
            this.panelBillsUnpaid.Name = "panelBillsUnpaid";
            this.panelBillsUnpaid.Size = new System.Drawing.Size(150, 100);
            this.panelBillsUnpaid.TabIndex = 2;
            // 
            // labelAmountUnpaidBills
            // 
            this.labelAmountUnpaidBills.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelAmountUnpaidBills.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAmountUnpaidBills.ForeColor = System.Drawing.Color.Red;
            this.labelAmountUnpaidBills.Location = new System.Drawing.Point(0, 28);
            this.labelAmountUnpaidBills.Name = "labelAmountUnpaidBills";
            this.labelAmountUnpaidBills.Size = new System.Drawing.Size(150, 41);
            this.labelAmountUnpaidBills.TabIndex = 14;
            this.labelAmountUnpaidBills.Text = "0,00 €";
            this.labelAmountUnpaidBills.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelCountUnpaidBills
            // 
            this.labelCountUnpaidBills.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelCountUnpaidBills.Location = new System.Drawing.Point(0, 69);
            this.labelCountUnpaidBills.Name = "labelCountUnpaidBills";
            this.labelCountUnpaidBills.Size = new System.Drawing.Size(150, 31);
            this.labelCountUnpaidBills.TabIndex = 13;
            this.labelCountUnpaidBills.Text = "0 unpaid bills";
            this.labelCountUnpaidBills.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelUnpaidBills
            // 
            this.labelUnpaidBills.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelUnpaidBills.Location = new System.Drawing.Point(0, 0);
            this.labelUnpaidBills.Name = "labelUnpaidBills";
            this.labelUnpaidBills.Size = new System.Drawing.Size(150, 28);
            this.labelUnpaidBills.TabIndex = 8;
            this.labelUnpaidBills.Text = "Unpaid bills";
            this.labelUnpaidBills.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chartTurnover);
            this.panel1.Controls.Add(this.labelCollectedTurnover);
            this.panel1.Location = new System.Drawing.Point(10, 168);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(232, 160);
            this.panel1.TabIndex = 3;
            // 
            // chartTurnover
            // 
            this.chartTurnover.BackColor = System.Drawing.Color.Transparent;
            this.chartTurnover.BorderlineColor = System.Drawing.Color.Transparent;
            chartArea5.AxisX.IsLabelAutoFit = false;
            chartArea5.AxisX.LabelStyle.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea5.AxisX.LabelStyle.ForeColor = System.Drawing.Color.DarkGray;
            chartArea5.AxisX.LineColor = System.Drawing.Color.DarkGray;
            chartArea5.AxisX.TitleForeColor = System.Drawing.Color.DarkGray;
            chartArea5.AxisX2.InterlacedColor = System.Drawing.Color.White;
            chartArea5.AxisX2.LineColor = System.Drawing.Color.DarkGray;
            chartArea5.AxisX2.TitleForeColor = System.Drawing.Color.DarkGray;
            chartArea5.AxisY.IsLabelAutoFit = false;
            chartArea5.AxisY.LabelStyle.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea5.AxisY.LabelStyle.ForeColor = System.Drawing.Color.DarkGray;
            chartArea5.AxisY.LineColor = System.Drawing.Color.DarkGray;
            chartArea5.AxisY.TitleForeColor = System.Drawing.Color.DarkGray;
            chartArea5.AxisY2.InterlacedColor = System.Drawing.Color.White;
            chartArea5.AxisY2.LineColor = System.Drawing.Color.DarkGray;
            chartArea5.AxisY2.TitleForeColor = System.Drawing.Color.DarkGray;
            chartArea5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            chartArea5.BorderColor = System.Drawing.Color.Silver;
            chartArea5.Name = "ChartArea1";
            this.chartTurnover.ChartAreas.Add(chartArea5);
            this.chartTurnover.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartTurnover.Location = new System.Drawing.Point(0, 27);
            this.chartTurnover.Name = "chartTurnover";
            this.chartTurnover.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.EarthTones;
            series9.ChartArea = "ChartArea1";
            series9.Color = System.Drawing.Color.DimGray;
            series9.LabelForeColor = System.Drawing.Color.WhiteSmoke;
            series9.Name = "SerieTurnover";
            series10.ChartArea = "ChartArea1";
            series10.Color = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            series10.Name = "SerieBenefit";
            this.chartTurnover.Series.Add(series9);
            this.chartTurnover.Series.Add(series10);
            this.chartTurnover.Size = new System.Drawing.Size(232, 133);
            this.chartTurnover.TabIndex = 8;
            this.chartTurnover.Text = "chart1";
            // 
            // labelCollectedTurnover
            // 
            this.labelCollectedTurnover.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelCollectedTurnover.Location = new System.Drawing.Point(0, 0);
            this.labelCollectedTurnover.Name = "labelCollectedTurnover";
            this.labelCollectedTurnover.Size = new System.Drawing.Size(232, 27);
            this.labelCollectedTurnover.TabIndex = 7;
            this.labelCollectedTurnover.Text = "Collected turnover / benefit";
            this.labelCollectedTurnover.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.chartCeiling);
            this.panel2.Controls.Add(this.labelCeilingValue);
            this.panel2.Controls.Add(this.labelCeilingForEarning);
            this.panel2.Location = new System.Drawing.Point(258, 168);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(232, 160);
            this.panel2.TabIndex = 4;
            // 
            // chartCeiling
            // 
            this.chartCeiling.BackColor = System.Drawing.Color.Transparent;
            this.chartCeiling.BorderlineColor = System.Drawing.Color.Transparent;
            chartArea6.AxisX.IsLabelAutoFit = false;
            chartArea6.AxisX.LabelStyle.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea6.AxisX.LabelStyle.ForeColor = System.Drawing.Color.Transparent;
            chartArea6.AxisX.LineColor = System.Drawing.Color.Transparent;
            chartArea6.AxisX.MajorGrid.LineColor = System.Drawing.Color.Transparent;
            chartArea6.AxisX.TitleForeColor = System.Drawing.Color.Transparent;
            chartArea6.AxisX2.InterlacedColor = System.Drawing.Color.White;
            chartArea6.AxisX2.LineColor = System.Drawing.Color.Transparent;
            chartArea6.AxisX2.TitleForeColor = System.Drawing.Color.Transparent;
            chartArea6.AxisY.IsLabelAutoFit = false;
            chartArea6.AxisY.LabelStyle.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea6.AxisY.LabelStyle.ForeColor = System.Drawing.Color.Transparent;
            chartArea6.AxisY.LineColor = System.Drawing.Color.Transparent;
            chartArea6.AxisY.MajorGrid.LineColor = System.Drawing.Color.Transparent;
            chartArea6.AxisY.TitleForeColor = System.Drawing.Color.Transparent;
            chartArea6.AxisY2.InterlacedColor = System.Drawing.Color.White;
            chartArea6.AxisY2.LineColor = System.Drawing.Color.Transparent;
            chartArea6.AxisY2.TitleForeColor = System.Drawing.Color.Transparent;
            chartArea6.BackColor = System.Drawing.Color.Transparent;
            chartArea6.BorderColor = System.Drawing.Color.Transparent;
            chartArea6.Name = "ChartArea1";
            chartArea6.ShadowColor = System.Drawing.Color.Transparent;
            this.chartCeiling.ChartAreas.Add(chartArea6);
            this.chartCeiling.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartCeiling.Location = new System.Drawing.Point(0, 27);
            this.chartCeiling.Name = "chartCeiling";
            this.chartCeiling.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.EarthTones;
            series11.ChartArea = "ChartArea1";
            series11.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedBar100;
            series11.Color = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            series11.LabelForeColor = System.Drawing.Color.WhiteSmoke;
            series11.Name = "Series1";
            series12.ChartArea = "ChartArea1";
            series12.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedBar100;
            series12.Color = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            series12.Name = "Series2";
            this.chartCeiling.Series.Add(series11);
            this.chartCeiling.Series.Add(series12);
            this.chartCeiling.Size = new System.Drawing.Size(232, 105);
            this.chartCeiling.TabIndex = 13;
            this.chartCeiling.Text = "chart1";
            // 
            // labelCeilingValue
            // 
            this.labelCeilingValue.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelCeilingValue.Location = new System.Drawing.Point(0, 132);
            this.labelCeilingValue.Name = "labelCeilingValue";
            this.labelCeilingValue.Size = new System.Drawing.Size(232, 28);
            this.labelCeilingValue.TabIndex = 12;
            this.labelCeilingValue.Text = "0 %";
            this.labelCeilingValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelCeilingForEarning
            // 
            this.labelCeilingForEarning.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelCeilingForEarning.Location = new System.Drawing.Point(0, 0);
            this.labelCeilingForEarning.Name = "labelCeilingForEarning";
            this.labelCeilingForEarning.Size = new System.Drawing.Size(232, 27);
            this.labelCeilingForEarning.TabIndex = 8;
            this.labelCeilingForEarning.Text = "Ceiling for earning";
            this.labelCeilingForEarning.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelMis
            // 
            this.panelMis.Controls.Add(this.dataGridViewCotisation);
            this.panelMis.Controls.Add(this.labelEstimationContributions);
            this.panelMis.Location = new System.Drawing.Point(10, 340);
            this.panelMis.Name = "panelMis";
            this.panelMis.Size = new System.Drawing.Size(480, 149);
            this.panelMis.TabIndex = 5;
            // 
            // dataGridViewCotisation
            // 
            this.dataGridViewCotisation.AllowUserToAddRows = false;
            this.dataGridViewCotisation.AllowUserToDeleteRows = false;
            this.dataGridViewCotisation.AllowUserToResizeColumns = false;
            this.dataGridViewCotisation.AllowUserToResizeRows = false;
            this.dataGridViewCotisation.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.dataGridViewCotisation.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewCotisation.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Calibri", 9.75F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewCotisation.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewCotisation.ColumnHeadersHeight = 25;
            this.dataGridViewCotisation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewCotisation.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnLabel,
            this.ColumnValue});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Calibri", 9.75F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewCotisation.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewCotisation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewCotisation.EnableHeadersVisualStyles = false;
            this.dataGridViewCotisation.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.dataGridViewCotisation.Location = new System.Drawing.Point(0, 26);
            this.dataGridViewCotisation.Name = "dataGridViewCotisation";
            this.dataGridViewCotisation.RowHeadersVisible = false;
            this.dataGridViewCotisation.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewCotisation.Size = new System.Drawing.Size(480, 123);
            this.dataGridViewCotisation.TabIndex = 10;
            // 
            // ColumnLabel
            // 
            this.ColumnLabel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnLabel.HeaderText = "Period 2018";
            this.ColumnLabel.Name = "ColumnLabel";
            // 
            // ColumnValue
            // 
            this.ColumnValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColumnValue.HeaderText = "Value";
            this.ColumnValue.Name = "ColumnValue";
            this.ColumnValue.Width = 60;
            // 
            // labelEstimationContributions
            // 
            this.labelEstimationContributions.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelEstimationContributions.Location = new System.Drawing.Point(0, 0);
            this.labelEstimationContributions.Name = "labelEstimationContributions";
            this.labelEstimationContributions.Size = new System.Drawing.Size(480, 26);
            this.labelEstimationContributions.TabIndex = 9;
            this.labelEstimationContributions.Text = "Estimation of the contributions";
            this.labelEstimationContributions.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // viewAccountResume
            // 
            this.viewAccountResume.Activity = null;
            this.viewAccountResume.BackColor = System.Drawing.Color.Black;
            this.viewAccountResume.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewAccountResume.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.viewAccountResume.IsActive = false;
            this.viewAccountResume.Location = new System.Drawing.Point(13, 12);
            this.viewAccountResume.Name = "viewAccountResume";
            this.viewAccountResume.Size = new System.Drawing.Size(476, 32);
            this.viewAccountResume.TabIndex = 6;
            // 
            // buttonClose
            // 
            this.buttonClose.FlatAppearance.BorderSize = 0;
            this.buttonClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.buttonClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClose.Image = global::Droid.financial.Properties.Resources.close;
            this.buttonClose.Location = new System.Drawing.Point(478, 4);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(16, 16);
            this.buttonClose.TabIndex = 12;
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // ActivityPreviewPro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.viewAccountResume);
            this.Controls.Add(this.panelMis);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelBillsUnpaid);
            this.Controls.Add(this.panelPendingBills);
            this.Controls.Add(this.panelCA);
            this.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.ForeColor = System.Drawing.Color.Gainsboro;
            this.Name = "ActivityPreviewPro";
            this.Size = new System.Drawing.Size(500, 500);
            this.panelCA.ResumeLayout(false);
            this.panelPendingBills.ResumeLayout(false);
            this.panelBillsUnpaid.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartTurnover)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartCeiling)).EndInit();
            this.panelMis.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCotisation)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelCA;
        private System.Windows.Forms.Panel panelPendingBills;
        private System.Windows.Forms.Panel panelBillsUnpaid;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panelMis;
        private System.Windows.Forms.Label labelCA;
        private System.Windows.Forms.Label labelPendingBills;
        private System.Windows.Forms.Label labelUnpaidBills;
        private System.Windows.Forms.Label labelCollectedTurnover;
        private System.Windows.Forms.Label labelCeilingForEarning;
        private System.Windows.Forms.Label labelEstimationContributions;
        private System.Windows.Forms.Label labelTurnoverThisMonth;
        private System.Windows.Forms.Label labelCountPendingBills;
        private System.Windows.Forms.Label labelCountUnpaidBills;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTurnover;
        private System.Windows.Forms.Label labelAmountTurnover;
        private System.Windows.Forms.Label labelAmountBills;
        private System.Windows.Forms.Label labelAmountUnpaidBills;
        private System.Windows.Forms.DataGridView dataGridViewCotisation;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnValue;
        private ViewAccountResume viewAccountResume;
        private System.Windows.Forms.Label labelCeilingValue;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartCeiling;
        private System.Windows.Forms.Button buttonClose;
    }
}
