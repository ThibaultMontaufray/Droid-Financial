namespace Droid_financial
{
    partial class ViewMovements
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
            this._dataGridViewMovement = new System.Windows.Forms.DataGridView();
            this.ColumnExpsId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnExpsName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnExpsStartParticipation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnExpsEndParticipation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnExpsAmountOrg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnExpsDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnExpsEdit = new System.Windows.Forms.DataGridViewImageColumn();
            this.ColumnExpsDel = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this._dataGridViewMovement)).BeginInit();
            // 
            // dataGridViewMovmeents
            // 
            this._dataGridViewMovement.AllowUserToAddRows = false;
            this._dataGridViewMovement.AllowUserToDeleteRows = false;
            this._dataGridViewMovement.AllowUserToResizeColumns = false;
            this._dataGridViewMovement.AllowUserToResizeRows = false;
            this._dataGridViewMovement.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dataGridViewMovement.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnExpsId,
            this.ColumnExpsName,
            this.ColumnExpsStartParticipation,
            this.ColumnExpsEndParticipation,
            this.ColumnExpsAmountOrg,
            this.ColumnExpsDescription,
            this.ColumnExpsEdit,
            this.ColumnExpsDel});
            this._dataGridViewMovement.Dock = System.Windows.Forms.DockStyle.Fill;
            this._dataGridViewMovement.Location = new System.Drawing.Point(0, 0);
            this._dataGridViewMovement.Name = "dataGridViewMovmeents";
            this._dataGridViewMovement.RowHeadersVisible = false;
            this._dataGridViewMovement.Size = new System.Drawing.Size(859, 385);
            this._dataGridViewMovement.TabIndex = 0;
            // 
            // ColumnExpsId
            // 
            this.ColumnExpsId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColumnExpsId.HeaderText = "Id";
            this.ColumnExpsId.Name = "ColumnExpsId";
            this.ColumnExpsId.Width = 41;
            // 
            // ColumnExpsName
            // 
            this.ColumnExpsName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColumnExpsName.HeaderText = "Name";
            this.ColumnExpsName.Name = "ColumnExpsName";
            this.ColumnExpsName.Width = 60;
            // 
            // ColumnExpsStartParticipation
            // 
            this.ColumnExpsStartParticipation.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColumnExpsStartParticipation.HeaderText = "Start";
            this.ColumnExpsStartParticipation.Name = "ColumnExpsStartParticipation";
            this.ColumnExpsStartParticipation.Width = 54;
            // 
            // ColumnExpsEndParticipation
            // 
            this.ColumnExpsEndParticipation.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColumnExpsEndParticipation.HeaderText = "End";
            this.ColumnExpsEndParticipation.Name = "ColumnExpsEndParticipation";
            this.ColumnExpsEndParticipation.Width = 51;
            // 
            // ColumnExpsAmountOrg
            // 
            this.ColumnExpsAmountOrg.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColumnExpsAmountOrg.HeaderText = "Amount";
            this.ColumnExpsAmountOrg.Name = "ColumnExpsAmountOrg";
            this.ColumnExpsAmountOrg.Width = 68;
            // 
            // ColumnExpsDescription
            // 
            this.ColumnExpsDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnExpsDescription.HeaderText = "Description";
            this.ColumnExpsDescription.Name = "ColumnExpsDescription";
            // 
            // ColumnExpsEdit
            // 
            this.ColumnExpsEdit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColumnExpsEdit.HeaderText = "";
            this.ColumnExpsEdit.Name = "ColumnExpsEdit";
            this.ColumnExpsEdit.Width = 5;
            // 
            // ColumnExpsDel
            // 
            this.ColumnExpsDel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColumnExpsDel.HeaderText = "";
            this.ColumnExpsDel.Name = "ColumnExpsDel";
            this.ColumnExpsDel.Width = 5;
            // 
            // ViewMovements
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._dataGridViewMovement);
            this.Name = "ViewMovements";
            this.Size = new System.Drawing.Size(859, 385);
            ((System.ComponentModel.ISupportInitialize)(this._dataGridViewMovement)).EndInit();
        }

        #endregion

        private System.Windows.Forms.DataGridView _dataGridViewMovement;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnExpsId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnExpsName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnExpsStartParticipation;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnExpsEndParticipation;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnExpsAmountOrg;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnExpsDescription;
        private System.Windows.Forms.DataGridViewImageColumn ColumnExpsEdit;
        private System.Windows.Forms.DataGridViewImageColumn ColumnExpsDel;
    }
}
