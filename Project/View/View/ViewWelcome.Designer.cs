namespace Droid_financial
{
    partial class ViewWelcome
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewWelcome));
            this.panelFinance1 = new Droid_financial.PanelFinance();
            this.viewExpences1 = new Droid_financial.ViewExpences();
            this._viewMovementExpensers = new Droid_financial.ViewMovements();
            this.panelGraph1 = new Droid_financial.PanelGraph();
            this.viewMovement1 = new Droid_financial.ViewMovements();
            this.panelFinance1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelFinance1
            // 
            this.panelFinance1.AutoScroll = true;
            this.panelFinance1.Controls.Add(this.viewExpences1);
            this.panelFinance1.Controls.Add(this._viewMovementExpensers);
            this.panelFinance1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFinance1.Location = new System.Drawing.Point(0, 0);
            this.panelFinance1.Name = "panelFinance1";
            this.panelFinance1.Size = new System.Drawing.Size(972, 274);
            this.panelFinance1.TabIndex = 0;
            // 
            // viewExpences1
            // 
            this.viewExpences1.BackColor = System.Drawing.Color.Black;
            this.viewExpences1.InterfaceFinancial = null;
            this.viewExpences1.Location = new System.Drawing.Point(15, 14);
            this.viewExpences1.Name = "viewExpences1";
            this.viewExpences1.Size = new System.Drawing.Size(293, 248);
            this.viewExpences1.TabIndex = 1;
            // 
            // _viewMovementExpensers
            // 
            this._viewMovementExpensers.InterfaceFinancial = null;
            this._viewMovementExpensers.Location = new System.Drawing.Point(314, 14);
            this._viewMovementExpensers.Name = "_viewMovementExpensers";
            this._viewMovementExpensers.Size = new System.Drawing.Size(655, 248);
            this._viewMovementExpensers.TabIndex = 0;
            // 
            // panelGraph1
            // 
            this.panelGraph1.BackColor = System.Drawing.Color.Transparent;
            this.panelGraph1.GraphMode = Droid_financial.PanelGraph.GRAPHMODE.PIE;
            this.panelGraph1.Location = new System.Drawing.Point(0, 0);
            this.panelGraph1.Name = "panelGraph1";
            this.panelGraph1.Size = new System.Drawing.Size(200, 100);
            this.panelGraph1.TabIndex = 0;
            // 
            // viewMovement1
            // 
            this.viewMovement1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.viewMovement1.InterfaceFinancial = null;
            this.viewMovement1.Location = new System.Drawing.Point(0, 273);
            this.viewMovement1.Name = "viewMovement1";
            this.viewMovement1.Size = new System.Drawing.Size(972, 257);
            this.viewMovement1.TabIndex = 0;
            // 
            // ViewWelcome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.panelFinance1);
            this.Name = "ViewWelcome";
            this.Size = new System.Drawing.Size(972, 274);
            this.panelFinance1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private PanelFinance panelFinance1;
        private ViewMovements _viewMovementExpensers;
        private PanelGraph panelGraph1;
        private ViewExpences viewExpences1;
        private ViewMovements viewMovement1;
    }
}
