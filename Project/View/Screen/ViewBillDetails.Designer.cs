namespace Droid.financial
{
    partial class ViewBillDetails
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
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.comboBoxOwner = new System.Windows.Forms.ComboBox();
            this.labelOwner = new System.Windows.Forms.Label();
            this.textBoxBank = new System.Windows.Forms.TextBox();
            this.labelBank = new System.Windows.Forms.Label();
            this.buttonColor = new System.Windows.Forms.Button();
            this.labelColor = new System.Windows.Forms.Label();
            this.buttonProductAdd = new System.Windows.Forms.Button();
            this.buttonProductNew = new System.Windows.Forms.Button();
            this.labelProduct = new System.Windows.Forms.Label();
            this.comboBoxProducts = new System.Windows.Forms.ComboBox();
            this._dataGridViewProducts = new System.Windows.Forms.DataGridView();
            this.ColumnId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSubTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDel = new System.Windows.Forms.DataGridViewImageColumn();
            this.labelDateLimit = new System.Windows.Forms.Label();
            this.dateTimePickerLimit = new System.Windows.Forms.DateTimePicker();
            this.labelDateCreation = new System.Windows.Forms.Label();
            this.dateTimePickerCreation = new System.Windows.Forms.DateTimePicker();
            this.comboBoxClients = new System.Windows.Forms.ComboBox();
            this.labelClient = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.labelPayDate = new System.Windows.Forms.Label();
            this.dateTimePickerPayDate = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this._dataGridViewProducts)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxOwner
            // 
            this.comboBoxOwner.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxOwner.FormattingEnabled = true;
            this.comboBoxOwner.Location = new System.Drawing.Point(119, 37);
            this.comboBoxOwner.Name = "comboBoxOwner";
            this.comboBoxOwner.Size = new System.Drawing.Size(200, 22);
            this.comboBoxOwner.TabIndex = 22;
            // 
            // labelOwner
            // 
            this.labelOwner.AutoSize = true;
            this.labelOwner.Location = new System.Drawing.Point(5, 40);
            this.labelOwner.Name = "labelOwner";
            this.labelOwner.Size = new System.Drawing.Size(63, 14);
            this.labelOwner.TabIndex = 21;
            this.labelOwner.Text = "Bill owner";
            // 
            // textBoxBank
            // 
            this.textBoxBank.Location = new System.Drawing.Point(119, 65);
            this.textBoxBank.Name = "textBoxBank";
            this.textBoxBank.Size = new System.Drawing.Size(201, 22);
            this.textBoxBank.TabIndex = 20;
            // 
            // labelBank
            // 
            this.labelBank.AutoSize = true;
            this.labelBank.Location = new System.Drawing.Point(5, 68);
            this.labelBank.Name = "labelBank";
            this.labelBank.Size = new System.Drawing.Size(76, 14);
            this.labelBank.TabIndex = 19;
            this.labelBank.Text = "Bank detail :";
            // 
            // buttonColor
            // 
            this.buttonColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonColor.Location = new System.Drawing.Point(119, 282);
            this.buttonColor.Name = "buttonColor";
            this.buttonColor.Size = new System.Drawing.Size(101, 20);
            this.buttonColor.TabIndex = 18;
            this.buttonColor.UseVisualStyleBackColor = true;
            this.buttonColor.Click += new System.EventHandler(this.buttonColor_Click);
            // 
            // labelColor
            // 
            this.labelColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelColor.AutoSize = true;
            this.labelColor.Location = new System.Drawing.Point(4, 285);
            this.labelColor.Name = "labelColor";
            this.labelColor.Size = new System.Drawing.Size(35, 14);
            this.labelColor.TabIndex = 17;
            this.labelColor.Text = "Color";
            // 
            // buttonProductAdd
            // 
            this.buttonProductAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonProductAdd.ForeColor = System.Drawing.Color.Black;
            this.buttonProductAdd.Location = new System.Drawing.Point(494, 91);
            this.buttonProductAdd.Name = "buttonProductAdd";
            this.buttonProductAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonProductAdd.TabIndex = 16;
            this.buttonProductAdd.Text = "Add";
            this.buttonProductAdd.UseVisualStyleBackColor = true;
            this.buttonProductAdd.Click += new System.EventHandler(this.buttonProductAdd_Click);
            // 
            // buttonProductNew
            // 
            this.buttonProductNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonProductNew.ForeColor = System.Drawing.Color.Black;
            this.buttonProductNew.Location = new System.Drawing.Point(575, 91);
            this.buttonProductNew.Name = "buttonProductNew";
            this.buttonProductNew.Size = new System.Drawing.Size(75, 23);
            this.buttonProductNew.TabIndex = 15;
            this.buttonProductNew.Text = "New";
            this.buttonProductNew.UseVisualStyleBackColor = true;
            this.buttonProductNew.Click += new System.EventHandler(this.buttonProductNew_Click);
            // 
            // labelProduct
            // 
            this.labelProduct.AutoSize = true;
            this.labelProduct.Location = new System.Drawing.Point(4, 95);
            this.labelProduct.Name = "labelProduct";
            this.labelProduct.Size = new System.Drawing.Size(62, 14);
            this.labelProduct.TabIndex = 14;
            this.labelProduct.Text = "Products : ";
            // 
            // comboBoxProducts
            // 
            this.comboBoxProducts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxProducts.FormattingEnabled = true;
            this.comboBoxProducts.Location = new System.Drawing.Point(119, 92);
            this.comboBoxProducts.Name = "comboBoxProducts";
            this.comboBoxProducts.Size = new System.Drawing.Size(369, 22);
            this.comboBoxProducts.TabIndex = 13;
            // 
            // _dataGridViewProducts
            // 
            this._dataGridViewProducts.AllowUserToAddRows = false;
            this._dataGridViewProducts.AllowUserToDeleteRows = false;
            this._dataGridViewProducts.AllowUserToResizeColumns = false;
            this._dataGridViewProducts.AllowUserToResizeRows = false;
            this._dataGridViewProducts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._dataGridViewProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dataGridViewProducts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnId,
            this.ColumnDescription,
            this.ColumnQuantity,
            this.ColumnAmount,
            this.ColumnSubTotal,
            this.ColumnDel});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this._dataGridViewProducts.DefaultCellStyle = dataGridViewCellStyle1;
            this._dataGridViewProducts.Location = new System.Drawing.Point(7, 120);
            this._dataGridViewProducts.Name = "_dataGridViewProducts";
            this._dataGridViewProducts.RowHeadersVisible = false;
            this._dataGridViewProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._dataGridViewProducts.Size = new System.Drawing.Size(643, 155);
            this._dataGridViewProducts.TabIndex = 12;
            this._dataGridViewProducts.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this._dataGridViewProducts_CellClick);
            this._dataGridViewProducts.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this._dataGridViewProducts_CellValueChanged);
            // 
            // ColumnId
            // 
            this.ColumnId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColumnId.HeaderText = "Id";
            this.ColumnId.Name = "ColumnId";
            this.ColumnId.Width = 43;
            // 
            // ColumnDescription
            // 
            this.ColumnDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnDescription.HeaderText = "Description";
            this.ColumnDescription.Name = "ColumnDescription";
            // 
            // ColumnQuantity
            // 
            this.ColumnQuantity.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColumnQuantity.HeaderText = "Quantity";
            this.ColumnQuantity.Name = "ColumnQuantity";
            this.ColumnQuantity.Width = 77;
            // 
            // ColumnAmount
            // 
            this.ColumnAmount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColumnAmount.HeaderText = "Amount";
            this.ColumnAmount.Name = "ColumnAmount";
            this.ColumnAmount.Width = 74;
            // 
            // ColumnSubTotal
            // 
            this.ColumnSubTotal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColumnSubTotal.HeaderText = "Sub-total";
            this.ColumnSubTotal.Name = "ColumnSubTotal";
            this.ColumnSubTotal.Width = 82;
            // 
            // ColumnDel
            // 
            this.ColumnDel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColumnDel.HeaderText = "";
            this.ColumnDel.Name = "ColumnDel";
            this.ColumnDel.Width = 5;
            // 
            // labelDateLimit
            // 
            this.labelDateLimit.AutoSize = true;
            this.labelDateLimit.Location = new System.Drawing.Point(335, 43);
            this.labelDateLimit.Name = "labelDateLimit";
            this.labelDateLimit.Size = new System.Drawing.Size(71, 14);
            this.labelDateLimit.TabIndex = 9;
            this.labelDateLimit.Text = "Date limit : ";
            // 
            // dateTimePickerLimit
            // 
            this.dateTimePickerLimit.Location = new System.Drawing.Point(450, 37);
            this.dateTimePickerLimit.Name = "dateTimePickerLimit";
            this.dateTimePickerLimit.Size = new System.Drawing.Size(200, 22);
            this.dateTimePickerLimit.TabIndex = 8;
            // 
            // labelDateCreation
            // 
            this.labelDateCreation.AutoSize = true;
            this.labelDateCreation.Location = new System.Drawing.Point(335, 15);
            this.labelDateCreation.Name = "labelDateCreation";
            this.labelDateCreation.Size = new System.Drawing.Size(86, 14);
            this.labelDateCreation.TabIndex = 7;
            this.labelDateCreation.Text = "Date creation :";
            // 
            // dateTimePickerCreation
            // 
            this.dateTimePickerCreation.Location = new System.Drawing.Point(450, 9);
            this.dateTimePickerCreation.Name = "dateTimePickerCreation";
            this.dateTimePickerCreation.Size = new System.Drawing.Size(200, 22);
            this.dateTimePickerCreation.TabIndex = 6;
            // 
            // comboBoxClients
            // 
            this.comboBoxClients.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxClients.FormattingEnabled = true;
            this.comboBoxClients.Location = new System.Drawing.Point(119, 9);
            this.comboBoxClients.Name = "comboBoxClients";
            this.comboBoxClients.Size = new System.Drawing.Size(200, 22);
            this.comboBoxClients.TabIndex = 3;
            // 
            // labelClient
            // 
            this.labelClient.AutoSize = true;
            this.labelClient.Location = new System.Drawing.Point(5, 12);
            this.labelClient.Name = "labelClient";
            this.labelClient.Size = new System.Drawing.Size(39, 14);
            this.labelClient.TabIndex = 2;
            this.labelClient.Text = "Client";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.ForeColor = System.Drawing.Color.Black;
            this.buttonCancel.Location = new System.Drawing.Point(494, 281);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSave.ForeColor = System.Drawing.Color.Black;
            this.buttonSave.Location = new System.Drawing.Point(575, 281);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 0;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // labelPayDate
            // 
            this.labelPayDate.AutoSize = true;
            this.labelPayDate.Location = new System.Drawing.Point(335, 71);
            this.labelPayDate.Name = "labelPayDate";
            this.labelPayDate.Size = new System.Drawing.Size(91, 14);
            this.labelPayDate.TabIndex = 24;
            this.labelPayDate.Text = "Date Pay date : ";
            // 
            // dateTimePickerPayDate
            // 
            this.dateTimePickerPayDate.Location = new System.Drawing.Point(450, 65);
            this.dateTimePickerPayDate.Name = "dateTimePickerPayDate";
            this.dateTimePickerPayDate.Size = new System.Drawing.Size(200, 22);
            this.dateTimePickerPayDate.TabIndex = 23;
            // 
            // ViewBillDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.labelPayDate);
            this.Controls.Add(this.dateTimePickerPayDate);
            this.Controls.Add(this.comboBoxOwner);
            this.Controls.Add(this.labelOwner);
            this.Controls.Add(this.textBoxBank);
            this.Controls.Add(this.labelBank);
            this.Controls.Add(this.buttonColor);
            this.Controls.Add(this.labelColor);
            this.Controls.Add(this.buttonProductAdd);
            this.Controls.Add(this.buttonProductNew);
            this.Controls.Add(this.labelProduct);
            this.Controls.Add(this.comboBoxProducts);
            this.Controls.Add(this._dataGridViewProducts);
            this.Controls.Add(this.labelDateLimit);
            this.Controls.Add(this.dateTimePickerLimit);
            this.Controls.Add(this.labelDateCreation);
            this.Controls.Add(this.dateTimePickerCreation);
            this.Controls.Add(this.comboBoxClients);
            this.Controls.Add(this.labelClient);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Gainsboro;
            this.Name = "ViewBillDetails";
            this.Size = new System.Drawing.Size(657, 308);
            ((System.ComponentModel.ISupportInitialize)(this._dataGridViewProducts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelClient;
        private System.Windows.Forms.ComboBox comboBoxClients;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.DateTimePicker dateTimePickerCreation;
        private System.Windows.Forms.Label labelDateCreation;
        private System.Windows.Forms.Label labelDateLimit;
        private System.Windows.Forms.DateTimePicker dateTimePickerLimit;
        private System.Windows.Forms.DataGridView _dataGridViewProducts;
        private System.Windows.Forms.ComboBox comboBoxProducts;
        private System.Windows.Forms.Label labelProduct;
        private System.Windows.Forms.Button buttonProductAdd;
        private System.Windows.Forms.Button buttonProductNew;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSubTotal;
        private System.Windows.Forms.DataGridViewImageColumn ColumnDel;
        private System.Windows.Forms.TextBox textBoxBank;
        private System.Windows.Forms.Label labelBank;
        private System.Windows.Forms.Button buttonColor;
        private System.Windows.Forms.Label labelColor;
        private System.Windows.Forms.ComboBox comboBoxOwner;
        private System.Windows.Forms.Label labelOwner;
        private System.Windows.Forms.Label labelPayDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerPayDate;
    }
}
