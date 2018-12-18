namespace Droid.financial.View
{
    partial class ViewSpecifications
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
            this.dataGridViewSpec = new System.Windows.Forms.DataGridView();
            this.buttonClose = new System.Windows.Forms.Button();
            this.ColumnIcon = new System.Windows.Forms.DataGridViewImageColumn();
            this.ColumnId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFrom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMaxDay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnEdit = new System.Windows.Forms.DataGridViewImageColumn();
            this.ColumnDel = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSpec)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewSpec
            // 
            this.dataGridViewSpec.AllowUserToAddRows = false;
            this.dataGridViewSpec.AllowUserToDeleteRows = false;
            this.dataGridViewSpec.AllowUserToResizeColumns = false;
            this.dataGridViewSpec.AllowUserToResizeRows = false;
            this.dataGridViewSpec.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewSpec.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSpec.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnIcon,
            this.ColumnId,
            this.ColumnFrom,
            this.ColumnTo,
            this.ColumnMaxDay,
            this.ColumnEdit,
            this.ColumnDel});
            this.dataGridViewSpec.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewSpec.Name = "dataGridViewSpec";
            this.dataGridViewSpec.RowHeadersVisible = false;
            this.dataGridViewSpec.Size = new System.Drawing.Size(757, 316);
            this.dataGridViewSpec.TabIndex = 0;
            this.dataGridViewSpec.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewSpec_CellDoubleClick);
            // 
            // buttonClose
            // 
            this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClose.Location = new System.Drawing.Point(685, 325);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 1;
            this.buttonClose.Text = "exit";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // ColumnIcon
            // 
            this.ColumnIcon.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColumnIcon.HeaderText = "";
            this.ColumnIcon.Name = "ColumnIcon";
            this.ColumnIcon.Width = 5;
            // 
            // ColumnId
            // 
            this.ColumnId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColumnId.HeaderText = "Id";
            this.ColumnId.Name = "ColumnId";
            this.ColumnId.Width = 41;
            // 
            // ColumnFrom
            // 
            this.ColumnFrom.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnFrom.HeaderText = "From";
            this.ColumnFrom.Name = "ColumnFrom";
            // 
            // ColumnTo
            // 
            this.ColumnTo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnTo.HeaderText = "To";
            this.ColumnTo.Name = "ColumnTo";
            // 
            // ColumnMaxDay
            // 
            this.ColumnMaxDay.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColumnMaxDay.HeaderText = "Max";
            this.ColumnMaxDay.Name = "ColumnMaxDay";
            this.ColumnMaxDay.Width = 52;
            // 
            // ColumnEdit
            // 
            this.ColumnEdit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColumnEdit.HeaderText = "";
            this.ColumnEdit.Name = "ColumnEdit";
            this.ColumnEdit.Width = 5;
            // 
            // ColumnDel
            // 
            this.ColumnDel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColumnDel.HeaderText = "";
            this.ColumnDel.Name = "ColumnDel";
            this.ColumnDel.Width = 5;
            // 
            // ViewSpecifications
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.dataGridViewSpec);
            this.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ViewSpecifications";
            this.Size = new System.Drawing.Size(763, 351);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSpec)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewSpec;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.DataGridViewImageColumn ColumnIcon;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFrom;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMaxDay;
        private System.Windows.Forms.DataGridViewImageColumn ColumnEdit;
        private System.Windows.Forms.DataGridViewImageColumn ColumnDel;
    }
}
