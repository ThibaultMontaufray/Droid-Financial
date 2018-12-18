namespace Droid.financial
{
    partial class ActivityPreviewPerso
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
            this.viewExpences1 = new Droid.financial.ViewExpences();
            this.viewAccountResume1 = new Droid.financial.ViewAccountResume();
            this.viewMovements1 = new Droid.financial.ViewMovements();
            this.panelFiltering = new System.Windows.Forms.Panel();
            this.labelFiltering = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.panelFiltering.SuspendLayout();
            this.SuspendLayout();
            // 
            // viewExpences1
            // 
            this.viewExpences1.Activity = null;
            this.viewExpences1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.viewExpences1.BackColor = System.Drawing.Color.Black;
            this.viewExpences1.IsActive = false;
            this.viewExpences1.Location = new System.Drawing.Point(220, 60);
            this.viewExpences1.Name = "viewExpences1";
            this.viewExpences1.Size = new System.Drawing.Size(266, 302);
            this.viewExpences1.TabIndex = 9;
            // 
            // viewAccountResume1
            // 
            this.viewAccountResume1.Activity = null;
            this.viewAccountResume1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.viewAccountResume1.BackColor = System.Drawing.Color.Black;
            this.viewAccountResume1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewAccountResume1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.viewAccountResume1.IsActive = false;
            this.viewAccountResume1.Location = new System.Drawing.Point(12, 12);
            this.viewAccountResume1.Name = "viewAccountResume1";
            this.viewAccountResume1.Size = new System.Drawing.Size(474, 37);
            this.viewAccountResume1.TabIndex = 8;
            // 
            // viewMovements1
            // 
            this.viewMovements1.Activity = null;
            this.viewMovements1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.viewMovements1.IsActive = false;
            this.viewMovements1.Location = new System.Drawing.Point(12, 379);
            this.viewMovements1.Name = "viewMovements1";
            this.viewMovements1.Size = new System.Drawing.Size(474, 107);
            this.viewMovements1.TabIndex = 6;
            // 
            // panelFiltering
            // 
            this.panelFiltering.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panelFiltering.BackColor = System.Drawing.Color.Black;
            this.panelFiltering.Controls.Add(this.labelFiltering);
            this.panelFiltering.Location = new System.Drawing.Point(12, 60);
            this.panelFiltering.Name = "panelFiltering";
            this.panelFiltering.Size = new System.Drawing.Size(195, 302);
            this.panelFiltering.TabIndex = 10;
            // 
            // labelFiltering
            // 
            this.labelFiltering.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelFiltering.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFiltering.ForeColor = System.Drawing.Color.Gainsboro;
            this.labelFiltering.Location = new System.Drawing.Point(0, 0);
            this.labelFiltering.Name = "labelFiltering";
            this.labelFiltering.Size = new System.Drawing.Size(195, 27);
            this.labelFiltering.TabIndex = 0;
            this.labelFiltering.Text = "Filtering";
            this.labelFiltering.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.buttonClose.TabIndex = 11;
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // ActivityPreviewPerso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.panelFiltering);
            this.Controls.Add(this.viewExpences1);
            this.Controls.Add(this.viewAccountResume1);
            this.Controls.Add(this.viewMovements1);
            this.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.ForeColor = System.Drawing.Color.Gainsboro;
            this.Name = "ActivityPreviewPerso";
            this.Size = new System.Drawing.Size(500, 500);
            this.panelFiltering.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ViewMovements viewMovements1;
        private ViewAccountResume viewAccountResume1;
        private ViewExpences viewExpences1;
        private System.Windows.Forms.Panel panelFiltering;
        private System.Windows.Forms.Label labelFiltering;
        private System.Windows.Forms.Button buttonClose;
    }
}
