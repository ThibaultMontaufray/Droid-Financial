namespace Droid.financial
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
            this._panelScrollable = new Tools4Libraries.PanelScrollableCustom();
            this.SuspendLayout();
            // 
            // _panelScrollable
            // 
            this._panelScrollable.AutoScroll = true;
            this._panelScrollable.AutoScrollHorizontalMaximum = 100;
            this._panelScrollable.AutoScrollHorizontalMinimum = 0;
            this._panelScrollable.AutoScrollHPos = 0;
            this._panelScrollable.AutoScrollVerticalMaximum = 100;
            this._panelScrollable.AutoScrollVerticalMinimum = 0;
            this._panelScrollable.AutoScrollVPos = 0;
            this._panelScrollable.BackgroundImage = global::Droid.financial.Properties.Resources.ShieldTileBg;
            this._panelScrollable.Dock = System.Windows.Forms.DockStyle.Fill;
            this._panelScrollable.EnableAutoScrollHorizontal = true;
            this._panelScrollable.EnableAutoScrollVertical = true;
            this._panelScrollable.Location = new System.Drawing.Point(0, 0);
            this._panelScrollable.Name = "_panelScrollable";
            this._panelScrollable.Size = new System.Drawing.Size(500, 300);
            this._panelScrollable.TabIndex = 0;
            this._panelScrollable.VisibleAutoScrollHorizontal = false;
            this._panelScrollable.VisibleAutoScrollVertical = false;
            // 
            // ViewWelcome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this._panelScrollable);
            this.Name = "ViewWelcome";
            this.Size = new System.Drawing.Size(500, 300);
            this.ResumeLayout(false);

        }

        #endregion

        private Tools4Libraries.PanelScrollableCustom _panelScrollable;
    }
}
