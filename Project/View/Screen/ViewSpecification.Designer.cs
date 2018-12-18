namespace Droid.financial
{
    partial class ViewSpecification
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.labelEntityFrom = new System.Windows.Forms.Label();
            this.comboBoxEntityFrom = new System.Windows.Forms.ComboBox();
            this.comboBoxEntityTo = new System.Windows.Forms.ComboBox();
            this.labelEntityTo = new System.Windows.Forms.Label();
            this.buttonEntityAdd = new System.Windows.Forms.Button();
            this.dataGridViewCotisation = new System.Windows.Forms.DataGridView();
            this.ColumnLabel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labelSpecDate = new System.Windows.Forms.Label();
            this.dateTimePickerSpecDate = new System.Windows.Forms.DateTimePicker();
            this.labelOfferDelay = new System.Windows.Forms.Label();
            this.textBoxOfferDays = new System.Windows.Forms.TextBox();
            this.textBoxSpecId = new System.Windows.Forms.TextBox();
            this.labelSpecId = new System.Windows.Forms.Label();
            this.comboBoxPayment = new System.Windows.Forms.ComboBox();
            this.labelPaymentSupport = new System.Windows.Forms.Label();
            this.buttonAddProduct = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCotisation)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.ForeColor = System.Drawing.Color.Black;
            this.buttonCancel.Location = new System.Drawing.Point(428, 320);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSave.ForeColor = System.Drawing.Color.Black;
            this.buttonSave.Location = new System.Drawing.Point(509, 320);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 2;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // labelEntityFrom
            // 
            this.labelEntityFrom.AutoSize = true;
            this.labelEntityFrom.Location = new System.Drawing.Point(3, 6);
            this.labelEntityFrom.Name = "labelEntityFrom";
            this.labelEntityFrom.Size = new System.Drawing.Size(34, 14);
            this.labelEntityFrom.TabIndex = 4;
            this.labelEntityFrom.Text = "From";
            // 
            // comboBoxEntityFrom
            // 
            this.comboBoxEntityFrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEntityFrom.FormattingEnabled = true;
            this.comboBoxEntityFrom.Location = new System.Drawing.Point(62, 3);
            this.comboBoxEntityFrom.Name = "comboBoxEntityFrom";
            this.comboBoxEntityFrom.Size = new System.Drawing.Size(190, 22);
            this.comboBoxEntityFrom.TabIndex = 5;
            // 
            // comboBoxEntityTo
            // 
            this.comboBoxEntityTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEntityTo.FormattingEnabled = true;
            this.comboBoxEntityTo.Location = new System.Drawing.Point(316, 3);
            this.comboBoxEntityTo.Name = "comboBoxEntityTo";
            this.comboBoxEntityTo.Size = new System.Drawing.Size(190, 22);
            this.comboBoxEntityTo.TabIndex = 7;
            // 
            // labelEntityTo
            // 
            this.labelEntityTo.AutoSize = true;
            this.labelEntityTo.Location = new System.Drawing.Point(271, 6);
            this.labelEntityTo.Name = "labelEntityTo";
            this.labelEntityTo.Size = new System.Drawing.Size(19, 14);
            this.labelEntityTo.TabIndex = 6;
            this.labelEntityTo.Text = "To";
            // 
            // buttonEntityAdd
            // 
            this.buttonEntityAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonEntityAdd.ForeColor = System.Drawing.Color.Black;
            this.buttonEntityAdd.Location = new System.Drawing.Point(509, 3);
            this.buttonEntityAdd.Name = "buttonEntityAdd";
            this.buttonEntityAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonEntityAdd.TabIndex = 8;
            this.buttonEntityAdd.Text = "Add entity";
            this.buttonEntityAdd.UseVisualStyleBackColor = true;
            this.buttonEntityAdd.Click += new System.EventHandler(this.buttonEntityAdd_Click);
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
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewCotisation.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridViewCotisation.ColumnHeadersHeight = 25;
            this.dataGridViewCotisation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewCotisation.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnLabel,
            this.ColumnValue});
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewCotisation.DefaultCellStyle = dataGridViewCellStyle10;
            this.dataGridViewCotisation.EnableHeadersVisualStyles = false;
            this.dataGridViewCotisation.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.dataGridViewCotisation.Location = new System.Drawing.Point(6, 87);
            this.dataGridViewCotisation.Name = "dataGridViewCotisation";
            this.dataGridViewCotisation.RowHeadersVisible = false;
            this.dataGridViewCotisation.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewCotisation.Size = new System.Drawing.Size(578, 227);
            this.dataGridViewCotisation.TabIndex = 11;
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
            this.ColumnValue.Width = 61;
            // 
            // labelSpecDate
            // 
            this.labelSpecDate.AutoSize = true;
            this.labelSpecDate.Location = new System.Drawing.Point(3, 34);
            this.labelSpecDate.Name = "labelSpecDate";
            this.labelSpecDate.Size = new System.Drawing.Size(103, 14);
            this.labelSpecDate.TabIndex = 12;
            this.labelSpecDate.Text = "Specification date";
            // 
            // dateTimePickerSpecDate
            // 
            this.dateTimePickerSpecDate.Location = new System.Drawing.Point(135, 31);
            this.dateTimePickerSpecDate.Name = "dateTimePickerSpecDate";
            this.dateTimePickerSpecDate.Size = new System.Drawing.Size(200, 22);
            this.dateTimePickerSpecDate.TabIndex = 13;
            // 
            // labelOfferDelay
            // 
            this.labelOfferDelay.AutoSize = true;
            this.labelOfferDelay.Location = new System.Drawing.Point(346, 34);
            this.labelOfferDelay.Name = "labelOfferDelay";
            this.labelOfferDelay.Size = new System.Drawing.Size(127, 14);
            this.labelOfferDelay.TabIndex = 14;
            this.labelOfferDelay.Text = "Offer valid until (days)";
            // 
            // textBoxOfferDays
            // 
            this.textBoxOfferDays.Location = new System.Drawing.Point(484, 31);
            this.textBoxOfferDays.Name = "textBoxOfferDays";
            this.textBoxOfferDays.Size = new System.Drawing.Size(100, 22);
            this.textBoxOfferDays.TabIndex = 15;
            this.textBoxOfferDays.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxOfferDays_KeyPress);
            // 
            // textBoxSpecId
            // 
            this.textBoxSpecId.Location = new System.Drawing.Point(135, 59);
            this.textBoxSpecId.Name = "textBoxSpecId";
            this.textBoxSpecId.Size = new System.Drawing.Size(117, 22);
            this.textBoxSpecId.TabIndex = 17;
            // 
            // labelSpecId
            // 
            this.labelSpecId.AutoSize = true;
            this.labelSpecId.Location = new System.Drawing.Point(3, 62);
            this.labelSpecId.Name = "labelSpecId";
            this.labelSpecId.Size = new System.Drawing.Size(63, 14);
            this.labelSpecId.TabIndex = 16;
            this.labelSpecId.Text = "Identifiant";
            // 
            // comboBoxPayment
            // 
            this.comboBoxPayment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPayment.FormattingEnabled = true;
            this.comboBoxPayment.Location = new System.Drawing.Point(394, 59);
            this.comboBoxPayment.Name = "comboBoxPayment";
            this.comboBoxPayment.Size = new System.Drawing.Size(190, 22);
            this.comboBoxPayment.TabIndex = 19;
            // 
            // labelPaymentSupport
            // 
            this.labelPaymentSupport.AutoSize = true;
            this.labelPaymentSupport.Location = new System.Drawing.Point(271, 62);
            this.labelPaymentSupport.Name = "labelPaymentSupport";
            this.labelPaymentSupport.Size = new System.Drawing.Size(98, 14);
            this.labelPaymentSupport.TabIndex = 18;
            this.labelPaymentSupport.Text = "Payment support";
            // 
            // buttonAddProduct
            // 
            this.buttonAddProduct.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonAddProduct.ForeColor = System.Drawing.Color.Black;
            this.buttonAddProduct.Location = new System.Drawing.Point(6, 320);
            this.buttonAddProduct.Name = "buttonAddProduct";
            this.buttonAddProduct.Size = new System.Drawing.Size(125, 23);
            this.buttonAddProduct.TabIndex = 20;
            this.buttonAddProduct.Text = "Add product";
            this.buttonAddProduct.UseVisualStyleBackColor = true;
            this.buttonAddProduct.Click += new System.EventHandler(this.buttonAddProduct_Click);
            // 
            // ViewSpecification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.buttonAddProduct);
            this.Controls.Add(this.comboBoxPayment);
            this.Controls.Add(this.labelPaymentSupport);
            this.Controls.Add(this.textBoxSpecId);
            this.Controls.Add(this.labelSpecId);
            this.Controls.Add(this.textBoxOfferDays);
            this.Controls.Add(this.labelOfferDelay);
            this.Controls.Add(this.dateTimePickerSpecDate);
            this.Controls.Add(this.labelSpecDate);
            this.Controls.Add(this.dataGridViewCotisation);
            this.Controls.Add(this.buttonEntityAdd);
            this.Controls.Add(this.comboBoxEntityTo);
            this.Controls.Add(this.labelEntityTo);
            this.Controls.Add(this.comboBoxEntityFrom);
            this.Controls.Add(this.labelEntityFrom);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Gainsboro;
            this.Name = "ViewSpecification";
            this.Size = new System.Drawing.Size(587, 346);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCotisation)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Label labelEntityFrom;
        private System.Windows.Forms.ComboBox comboBoxEntityFrom;
        private System.Windows.Forms.ComboBox comboBoxEntityTo;
        private System.Windows.Forms.Label labelEntityTo;
        private System.Windows.Forms.Button buttonEntityAdd;
        private System.Windows.Forms.DataGridView dataGridViewCotisation;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnValue;
        private System.Windows.Forms.Label labelSpecDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerSpecDate;
        private System.Windows.Forms.Label labelOfferDelay;
        private System.Windows.Forms.TextBox textBoxOfferDays;
        private System.Windows.Forms.TextBox textBoxSpecId;
        private System.Windows.Forms.Label labelSpecId;
        private System.Windows.Forms.ComboBox comboBoxPayment;
        private System.Windows.Forms.Label labelPaymentSupport;
        private System.Windows.Forms.Button buttonAddProduct;
    }
}
