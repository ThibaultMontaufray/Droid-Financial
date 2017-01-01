namespace Droid_financial
{
    partial class MvtDelete
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelMember = new System.Windows.Forms.Panel();
            this.labelNameValue = new System.Windows.Forms.Label();
            this.labelGopValue = new System.Windows.Forms.Label();
            this.comboBoxListMovements = new System.Windows.Forms.ComboBox();
            this.labelProjectList = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.labelName = new System.Windows.Forms.Label();
            this.labelFirstName = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.panelMember.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.Size = new System.Drawing.Size(128, 17);
            this.labelTitle.Text = "Movement : remove";
            // 
            // panelMember
            // 
            this.panelMember.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            this.panelMember.Controls.Add(this.labelNameValue);
            this.panelMember.Controls.Add(this.labelGopValue);
            this.panelMember.Controls.Add(this.comboBoxListMovements);
            this.panelMember.Controls.Add(this.labelProjectList);
            this.panelMember.Controls.Add(this.buttonCancel);
            this.panelMember.Controls.Add(this.buttonDelete);
            this.panelMember.Controls.Add(this.labelName);
            this.panelMember.Controls.Add(this.labelFirstName);
            this.panelMember.Location = new System.Drawing.Point(35, 84);
            this.panelMember.Name = "panelMember";
            this.panelMember.Size = new System.Drawing.Size(360, 141);
            this.panelMember.TabIndex = 1;
            // 
            // labelNameValue
            // 
            this.labelNameValue.AutoSize = true;
            this.labelNameValue.BackColor = System.Drawing.Color.Transparent;
            this.labelNameValue.ForeColor = System.Drawing.Color.White;
            this.labelNameValue.Location = new System.Drawing.Point(79, 65);
            this.labelNameValue.Name = "labelNameValue";
            this.labelNameValue.Size = new System.Drawing.Size(49, 13);
            this.labelNameValue.TabIndex = 13;
            this.labelNameValue.Text = "_______";
            this.labelNameValue.Click += new System.EventHandler(this.labelNameValue_Click);
            // 
            // labelGopValue
            // 
            this.labelGopValue.AutoSize = true;
            this.labelGopValue.BackColor = System.Drawing.Color.Transparent;
            this.labelGopValue.ForeColor = System.Drawing.Color.White;
            this.labelGopValue.Location = new System.Drawing.Point(79, 39);
            this.labelGopValue.Name = "labelGopValue";
            this.labelGopValue.Size = new System.Drawing.Size(49, 13);
            this.labelGopValue.TabIndex = 12;
            this.labelGopValue.Text = "_______";
            // 
            // comboBoxListMovements
            // 
            this.comboBoxListMovements.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxListMovements.FormattingEnabled = true;
            this.comboBoxListMovements.Location = new System.Drawing.Point(82, 7);
            this.comboBoxListMovements.Name = "comboBoxListMovements";
            this.comboBoxListMovements.Size = new System.Drawing.Size(244, 21);
            this.comboBoxListMovements.TabIndex = 11;
            this.comboBoxListMovements.SelectedIndexChanged += new System.EventHandler(this.comboBoxListMovements_SelectedIndexChanged);
            // 
            // labelProjectList
            // 
            this.labelProjectList.AutoSize = true;
            this.labelProjectList.BackColor = System.Drawing.Color.Transparent;
            this.labelProjectList.ForeColor = System.Drawing.Color.White;
            this.labelProjectList.Location = new System.Drawing.Point(16, 10);
            this.labelProjectList.Name = "labelProjectList";
            this.labelProjectList.Size = new System.Drawing.Size(64, 13);
            this.labelProjectList.TabIndex = 9;
            this.labelProjectList.Text = "Project list : ";
            this.labelProjectList.Click += new System.EventHandler(this.labelProjectList_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(264, 115);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(83, 22);
            this.buttonCancel.TabIndex = 7;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonDelete.Location = new System.Drawing.Point(175, 115);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(83, 22);
            this.buttonDelete.TabIndex = 2;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonApply_Click);
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.BackColor = System.Drawing.Color.Transparent;
            this.labelName.ForeColor = System.Drawing.Color.White;
            this.labelName.Location = new System.Drawing.Point(16, 65);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(35, 13);
            this.labelName.TabIndex = 3;
            this.labelName.Text = "Name";
            this.labelName.Click += new System.EventHandler(this.labelName_Click);
            // 
            // labelFirstName
            // 
            this.labelFirstName.AutoSize = true;
            this.labelFirstName.BackColor = System.Drawing.Color.Transparent;
            this.labelFirstName.ForeColor = System.Drawing.Color.White;
            this.labelFirstName.Location = new System.Drawing.Point(16, 39);
            this.labelFirstName.Name = "labelFirstName";
            this.labelFirstName.Size = new System.Drawing.Size(36, 13);
            this.labelFirstName.TabIndex = 2;
            this.labelFirstName.Text = "Family";
            this.labelFirstName.Click += new System.EventHandler(this.labelFirstName_Click);
            // 
            // MvtDelete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(441, 258);
            this.Controls.Add(this.panelMember);
            this.Name = "MvtDelete";
            this.Text = "UserCard";
            this.Controls.SetChildIndex(this.panelMember, 0);
            this.panelMember.ResumeLayout(false);
            this.panelMember.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMember;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelFirstName;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ComboBox comboBoxListMovements;
        private System.Windows.Forms.Label labelProjectList;
        private System.Windows.Forms.Label labelNameValue;
        private System.Windows.Forms.Label labelGopValue;
    }
}