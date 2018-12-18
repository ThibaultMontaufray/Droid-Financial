namespace Droid.financial
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this._dataGridViewMovement = new System.Windows.Forms.DataGridView();
            this.ColumnExpsId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnExpsName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnExpsStartParticipation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnExpsEndParticipation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnExpsAmountOrg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnGOP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnExpsDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnExpsEdit = new System.Windows.Forms.DataGridViewImageColumn();
            this.ColumnExpsDel = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this._dataGridViewMovement)).BeginInit();
            this.SuspendLayout();
            // 
            // _dataGridViewMovement
            // 
            this._dataGridViewMovement.AllowUserToAddRows = false;
            this._dataGridViewMovement.AllowUserToDeleteRows = false;
            this._dataGridViewMovement.AllowUserToResizeColumns = false;
            this._dataGridViewMovement.AllowUserToResizeRows = false;
            this._dataGridViewMovement.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this._dataGridViewMovement.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._dataGridViewMovement.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this._dataGridViewMovement.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this._dataGridViewMovement.ColumnHeadersHeight = 25;
            this._dataGridViewMovement.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this._dataGridViewMovement.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnExpsId,
            this.ColumnExpsName,
            this.ColumnExpsStartParticipation,
            this.ColumnExpsEndParticipation,
            this.ColumnExpsAmountOrg,
            this.ColumnGOP,
            this.ColumnExpsDescription,
            this.ColumnExpsEdit,
            this.ColumnExpsDel});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 9.75F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this._dataGridViewMovement.DefaultCellStyle = dataGridViewCellStyle2;
            this._dataGridViewMovement.Dock = System.Windows.Forms.DockStyle.Fill;
            this._dataGridViewMovement.EnableHeadersVisualStyles = false;
            this._dataGridViewMovement.Location = new System.Drawing.Point(0, 0);
            this._dataGridViewMovement.Name = "_dataGridViewMovement";
            this._dataGridViewMovement.RowHeadersVisible = false;
            this._dataGridViewMovement.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._dataGridViewMovement.Size = new System.Drawing.Size(859, 385);
            this._dataGridViewMovement.TabIndex = 1;
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
            this.ColumnExpsName.Width = 62;
            // 
            // ColumnExpsStartParticipation
            // 
            this.ColumnExpsStartParticipation.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColumnExpsStartParticipation.HeaderText = "Start";
            this.ColumnExpsStartParticipation.Name = "ColumnExpsStartParticipation";
            this.ColumnExpsStartParticipation.Width = 55;
            // 
            // ColumnExpsEndParticipation
            // 
            this.ColumnExpsEndParticipation.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColumnExpsEndParticipation.HeaderText = "End";
            this.ColumnExpsEndParticipation.Name = "ColumnExpsEndParticipation";
            this.ColumnExpsEndParticipation.Width = 50;
            // 
            // ColumnExpsAmountOrg
            // 
            this.ColumnExpsAmountOrg.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColumnExpsAmountOrg.HeaderText = "Amount";
            this.ColumnExpsAmountOrg.Name = "ColumnExpsAmountOrg";
            this.ColumnExpsAmountOrg.Width = 72;
            // 
            // ColumnGOP
            // 
            this.ColumnGOP.HeaderText = "GOP";
            this.ColumnGOP.Name = "ColumnGOP";
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView _dataGridViewMovement;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnExpsId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnExpsName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnExpsStartParticipation;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnExpsEndParticipation;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnExpsAmountOrg;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnGOP;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnExpsDescription;
        private System.Windows.Forms.DataGridViewImageColumn ColumnExpsEdit;
        private System.Windows.Forms.DataGridViewImageColumn ColumnExpsDel;
    }
}
