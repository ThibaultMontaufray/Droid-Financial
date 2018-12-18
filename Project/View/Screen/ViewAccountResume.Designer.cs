namespace Droid.financial
{
    partial class ViewAccountResume
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewAccountResume));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.imageListBullet = new System.Windows.Forms.ImageList(this.components);
            this.labelSolde = new System.Windows.Forms.Label();
            this.labelSoldeText = new System.Windows.Forms.Label();
            this.labelAccountName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(37, 37);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // imageListBullet
            // 
            this.imageListBullet.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListBullet.ImageStream")));
            this.imageListBullet.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListBullet.Images.SetKeyName(0, "black");
            this.imageListBullet.Images.SetKeyName(1, "purple");
            this.imageListBullet.Images.SetKeyName(2, "red");
            this.imageListBullet.Images.SetKeyName(3, "orange");
            this.imageListBullet.Images.SetKeyName(4, "yellow");
            this.imageListBullet.Images.SetKeyName(5, "green");
            this.imageListBullet.Images.SetKeyName(6, "white");
            // 
            // labelSolde
            // 
            this.labelSolde.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelSolde.Location = new System.Drawing.Point(857, 8);
            this.labelSolde.Name = "labelSolde";
            this.labelSolde.Size = new System.Drawing.Size(100, 15);
            this.labelSolde.TabIndex = 2;
            this.labelSolde.Text = " 0";
            this.labelSolde.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelSoldeText
            // 
            this.labelSoldeText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelSoldeText.Location = new System.Drawing.Point(773, 8);
            this.labelSoldeText.Name = "labelSoldeText";
            this.labelSoldeText.Size = new System.Drawing.Size(78, 15);
            this.labelSoldeText.TabIndex = 3;
            this.labelSoldeText.Text = " Solde : ";
            this.labelSoldeText.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelAccountName
            // 
            this.labelAccountName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelAccountName.Location = new System.Drawing.Point(43, 8);
            this.labelAccountName.Name = "labelAccountName";
            this.labelAccountName.Size = new System.Drawing.Size(718, 15);
            this.labelAccountName.TabIndex = 4;
            this.labelAccountName.Text = "Account name";
            this.labelAccountName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ViewAccountResume
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.labelAccountName);
            this.Controls.Add(this.labelSoldeText);
            this.Controls.Add(this.labelSolde);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Name = "ViewAccountResume";
            this.Size = new System.Drawing.Size(960, 32);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ImageList imageListBullet;
        private System.Windows.Forms.Label labelSolde;
        private System.Windows.Forms.Label labelSoldeText;
        private System.Windows.Forms.Label labelAccountName;
    }
}
