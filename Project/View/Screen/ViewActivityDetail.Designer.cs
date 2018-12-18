namespace Droid.financial
{
    partial class ViewActivityDetail
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
            this.labelName = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxPath = new System.Windows.Forms.TextBox();
            this.labelBrowsePath = new System.Windows.Forms.Label();
            this.buttonBrowsePath = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.labelCurrency = new System.Windows.Forms.Label();
            this.labelType = new System.Windows.Forms.Label();
            this.comboBoxCurrency = new System.Windows.Forms.ComboBox();
            this.comboBoxFamily = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(13, 6);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(38, 15);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "Name";
            // 
            // textBoxName
            // 
            this.textBoxName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxName.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBoxName.Location = new System.Drawing.Point(97, 0);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(607, 23);
            this.textBoxName.TabIndex = 1;
            // 
            // textBoxPath
            // 
            this.textBoxPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPath.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBoxPath.Location = new System.Drawing.Point(97, 29);
            this.textBoxPath.Name = "textBoxPath";
            this.textBoxPath.Size = new System.Drawing.Size(526, 23);
            this.textBoxPath.TabIndex = 3;
            // 
            // labelBrowsePath
            // 
            this.labelBrowsePath.AutoSize = true;
            this.labelBrowsePath.Location = new System.Drawing.Point(13, 33);
            this.labelBrowsePath.Name = "labelBrowsePath";
            this.labelBrowsePath.Size = new System.Drawing.Size(32, 15);
            this.labelBrowsePath.TabIndex = 2;
            this.labelBrowsePath.Text = "Path";
            // 
            // buttonBrowsePath
            // 
            this.buttonBrowsePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBrowsePath.ForeColor = System.Drawing.Color.Black;
            this.buttonBrowsePath.Location = new System.Drawing.Point(629, 29);
            this.buttonBrowsePath.Name = "buttonBrowsePath";
            this.buttonBrowsePath.Size = new System.Drawing.Size(75, 23);
            this.buttonBrowsePath.TabIndex = 4;
            this.buttonBrowsePath.Text = "Browse";
            this.buttonBrowsePath.UseVisualStyleBackColor = true;
            this.buttonBrowsePath.Click += new System.EventHandler(this.buttonBrowsePath_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSave.ForeColor = System.Drawing.Color.Black;
            this.buttonSave.Location = new System.Drawing.Point(629, 91);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 5;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.ForeColor = System.Drawing.Color.Black;
            this.buttonCancel.Location = new System.Drawing.Point(548, 91);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 6;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // labelCurrency
            // 
            this.labelCurrency.AutoSize = true;
            this.labelCurrency.Location = new System.Drawing.Point(13, 90);
            this.labelCurrency.Name = "labelCurrency";
            this.labelCurrency.Size = new System.Drawing.Size(56, 15);
            this.labelCurrency.TabIndex = 7;
            this.labelCurrency.Text = "Currency";
            // 
            // labelType
            // 
            this.labelType.AutoSize = true;
            this.labelType.Location = new System.Drawing.Point(13, 61);
            this.labelType.Name = "labelType";
            this.labelType.Size = new System.Drawing.Size(31, 15);
            this.labelType.TabIndex = 8;
            this.labelType.Text = "Type";
            // 
            // comboBoxCurrency
            // 
            this.comboBoxCurrency.BackColor = System.Drawing.Color.WhiteSmoke;
            this.comboBoxCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCurrency.FormattingEnabled = true;
            this.comboBoxCurrency.Items.AddRange(new object[] {
            "EUR",
            "CAD",
            "NZD",
            "USD"});
            this.comboBoxCurrency.Location = new System.Drawing.Point(97, 87);
            this.comboBoxCurrency.Name = "comboBoxCurrency";
            this.comboBoxCurrency.Size = new System.Drawing.Size(102, 23);
            this.comboBoxCurrency.TabIndex = 9;
            // 
            // comboBoxFamily
            // 
            this.comboBoxFamily.BackColor = System.Drawing.Color.WhiteSmoke;
            this.comboBoxFamily.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFamily.FormattingEnabled = true;
            this.comboBoxFamily.Location = new System.Drawing.Point(97, 58);
            this.comboBoxFamily.Name = "comboBoxFamily";
            this.comboBoxFamily.Size = new System.Drawing.Size(168, 23);
            this.comboBoxFamily.TabIndex = 10;
            // 
            // ViewActivityDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.comboBoxFamily);
            this.Controls.Add(this.comboBoxCurrency);
            this.Controls.Add(this.labelType);
            this.Controls.Add(this.labelCurrency);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonBrowsePath);
            this.Controls.Add(this.textBoxPath);
            this.Controls.Add(this.labelBrowsePath);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.labelName);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Gainsboro;
            this.Name = "ViewActivityDetail";
            this.Size = new System.Drawing.Size(707, 117);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxPath;
        private System.Windows.Forms.Label labelBrowsePath;
        private System.Windows.Forms.Button buttonBrowsePath;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelCurrency;
        private System.Windows.Forms.Label labelType;
        private System.Windows.Forms.ComboBox comboBoxCurrency;
        private System.Windows.Forms.ComboBox comboBoxFamily;
    }
}
