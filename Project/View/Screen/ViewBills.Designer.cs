namespace Droid.financial.View.Screen
{
    partial class ViewBills
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this._dataGridViewBills = new System.Windows.Forms.DataGridView();
            this.ColumnId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCreateDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDueDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPaid = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDel = new System.Windows.Forms.DataGridViewImageColumn();
            this.ColumnInspect = new System.Windows.Forms.DataGridViewImageColumn();
            this.ColumnPrint = new System.Windows.Forms.DataGridViewImageColumn();
            this.buttonAdd = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this._dataGridViewBills)).BeginInit();
            this.SuspendLayout();
            // 
            // _dataGridViewBills
            // 
            this._dataGridViewBills.AllowUserToAddRows = false;
            this._dataGridViewBills.AllowUserToDeleteRows = false;
            this._dataGridViewBills.AllowUserToResizeColumns = false;
            this._dataGridViewBills.AllowUserToResizeRows = false;
            this._dataGridViewBills.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dataGridViewBills.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnId,
            this.ColumnName,
            this.ColumnCreateDate,
            this.ColumnDueDate,
            this.ColumnPaid,
            this.ColumnAmount,
            this.ColumnDel,
            this.ColumnInspect,
            this.ColumnPrint});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this._dataGridViewBills.DefaultCellStyle = dataGridViewCellStyle1;
            this._dataGridViewBills.Location = new System.Drawing.Point(3, 32);
            this._dataGridViewBills.Name = "_dataGridViewBills";
            this._dataGridViewBills.RowHeadersVisible = false;
            this._dataGridViewBills.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._dataGridViewBills.Size = new System.Drawing.Size(643, 257);
            this._dataGridViewBills.TabIndex = 15;
            this._dataGridViewBills.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this._dataGridViewBills_CellContentClick);
            // 
            // ColumnId
            // 
            this.ColumnId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColumnId.HeaderText = "Id";
            this.ColumnId.Name = "ColumnId";
            this.ColumnId.Width = 41;
            // 
            // ColumnName
            // 
            this.ColumnName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnName.HeaderText = "Name";
            this.ColumnName.Name = "ColumnName";
            // 
            // ColumnCreateDate
            // 
            this.ColumnCreateDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColumnCreateDate.HeaderText = "Create date";
            this.ColumnCreateDate.Name = "ColumnCreateDate";
            this.ColumnCreateDate.Width = 87;
            // 
            // ColumnDueDate
            // 
            this.ColumnDueDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColumnDueDate.HeaderText = "Due date";
            this.ColumnDueDate.Name = "ColumnDueDate";
            this.ColumnDueDate.Width = 76;
            // 
            // ColumnPaid
            // 
            this.ColumnPaid.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColumnPaid.HeaderText = "Paid";
            this.ColumnPaid.Name = "ColumnPaid";
            this.ColumnPaid.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnPaid.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnPaid.Width = 53;
            // 
            // ColumnAmount
            // 
            this.ColumnAmount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColumnAmount.HeaderText = "Amount";
            this.ColumnAmount.Name = "ColumnAmount";
            this.ColumnAmount.Width = 68;
            // 
            // ColumnDel
            // 
            this.ColumnDel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColumnDel.HeaderText = "";
            this.ColumnDel.Name = "ColumnDel";
            this.ColumnDel.Width = 5;
            // 
            // ColumnInspect
            // 
            this.ColumnInspect.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColumnInspect.HeaderText = "";
            this.ColumnInspect.Name = "ColumnInspect";
            this.ColumnInspect.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnInspect.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnInspect.Width = 19;
            // 
            // ColumnPrint
            // 
            this.ColumnPrint.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColumnPrint.HeaderText = "";
            this.ColumnPrint.Name = "ColumnPrint";
            this.ColumnPrint.Width = 5;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAdd.ForeColor = System.Drawing.Color.Black;
            this.buttonAdd.Location = new System.Drawing.Point(572, 3);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 14;
            this.buttonAdd.Text = "Create new";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // ViewBills
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this._dataGridViewBills);
            this.Controls.Add(this.buttonAdd);
            this.Name = "ViewBills";
            this.Size = new System.Drawing.Size(651, 292);
            ((System.ComponentModel.ISupportInitialize)(this._dataGridViewBills)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView _dataGridViewBills;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCreateDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDueDate;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnPaid;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAmount;
        private System.Windows.Forms.DataGridViewImageColumn ColumnDel;
        private System.Windows.Forms.DataGridViewImageColumn ColumnInspect;
        private System.Windows.Forms.DataGridViewImageColumn ColumnPrint;
    }
}
