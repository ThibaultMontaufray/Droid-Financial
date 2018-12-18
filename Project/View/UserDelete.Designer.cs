//namespace Droid.financial
//{
//    partial class UserDelete
//    {
//        /// <summary>
//        /// Required designer variable.
//        /// </summary>
//        private System.ComponentModel.IContainer components = null;

//        /// <summary>
//        /// Clean up any resources being used.
//        /// </summary>
//        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
//        protected override void Dispose(bool disposing)
//        {
//            if (disposing && (components != null))
//            {
//                components.Dispose();
//            }
//            base.Dispose(disposing);
//        }

//        #region Windows Form Designer generated code

//        /// <summary>
//        /// Required method for Designer support - do not modify
//        /// the contents of this method with the code editor.
//        /// </summary>
//        private void InitializeComponent()
//        {
//            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
//            this.pictureBoxUser = new System.Windows.Forms.PictureBox();
//            this.labelFirstName = new System.Windows.Forms.Label();
//            this.labelName = new System.Windows.Forms.Label();
//            this.buttonDelete = new System.Windows.Forms.Button();
//            this.buttonCancel = new System.Windows.Forms.Button();
//            this.labelProjectList = new System.Windows.Forms.Label();
//            this.comboBoxListUsers = new System.Windows.Forms.ComboBox();
//            this.labelFirstnameValue = new System.Windows.Forms.Label();
//            this.labelNameValue = new System.Windows.Forms.Label();
//            this.panelMember = new System.Windows.Forms.Panel();
//            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxUser)).BeginInit();
//            this.panelMember.SuspendLayout();
//            this.SuspendLayout();
//            // 
//            // labelTitle
//            // 
//            this.labelTitle.Size = new System.Drawing.Size(90, 17);
//            this.labelTitle.Text = "User : remove";
//            // 
//            // pictureBoxUser
//            // 
//            this.pictureBoxUser.Location = new System.Drawing.Point(6, 36);
//            this.pictureBoxUser.Name = "pictureBoxUser";
//            this.pictureBoxUser.Size = new System.Drawing.Size(32, 32);
//            this.pictureBoxUser.TabIndex = 0;
//            this.pictureBoxUser.TabStop = false;
//            // 
//            // labelFirstName
//            // 
//            this.labelFirstName.AutoSize = true;
//            this.labelFirstName.BackColor = System.Drawing.Color.Transparent;
//            this.labelFirstName.ForeColor = System.Drawing.Color.White;
//            this.labelFirstName.Location = new System.Drawing.Point(48, 32);
//            this.labelFirstName.Name = "labelFirstName";
//            this.labelFirstName.Size = new System.Drawing.Size(52, 13);
//            this.labelFirstName.TabIndex = 2;
//            this.labelFirstName.Text = "Firstname";
//            // 
//            // labelName
//            // 
//            this.labelName.AutoSize = true;
//            this.labelName.BackColor = System.Drawing.Color.Transparent;
//            this.labelName.ForeColor = System.Drawing.Color.White;
//            this.labelName.Location = new System.Drawing.Point(48, 58);
//            this.labelName.Name = "labelName";
//            this.labelName.Size = new System.Drawing.Size(35, 13);
//            this.labelName.TabIndex = 3;
//            this.labelName.Text = "Name";
//            // 
//            // buttonDelete
//            // 
//            this.buttonDelete.Location = new System.Drawing.Point(184, 116);
//            this.buttonDelete.Name = "buttonDelete";
//            this.buttonDelete.Size = new System.Drawing.Size(83, 22);
//            this.buttonDelete.TabIndex = 2;
//            this.buttonDelete.Text = "Delete";
//            this.buttonDelete.UseVisualStyleBackColor = true;
//            this.buttonDelete.Click += new System.EventHandler(this.buttonApply_Click);
//            // 
//            // buttonCancel
//            // 
//            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
//            this.buttonCancel.Location = new System.Drawing.Point(273, 116);
//            this.buttonCancel.Name = "buttonCancel";
//            this.buttonCancel.Size = new System.Drawing.Size(83, 22);
//            this.buttonCancel.TabIndex = 7;
//            this.buttonCancel.Text = "Cancel";
//            this.buttonCancel.UseVisualStyleBackColor = true;
//            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
//            // 
//            // labelProjectList
//            // 
//            this.labelProjectList.AutoSize = true;
//            this.labelProjectList.BackColor = System.Drawing.Color.Transparent;
//            this.labelProjectList.ForeColor = System.Drawing.Color.White;
//            this.labelProjectList.Location = new System.Drawing.Point(3, 6);
//            this.labelProjectList.Name = "labelProjectList";
//            this.labelProjectList.Size = new System.Drawing.Size(64, 13);
//            this.labelProjectList.TabIndex = 9;
//            this.labelProjectList.Text = "Project list : ";
//            // 
//            // comboBoxListUsers
//            // 
//            this.comboBoxListUsers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
//            this.comboBoxListUsers.FormattingEnabled = true;
//            this.comboBoxListUsers.Location = new System.Drawing.Point(73, 3);
//            this.comboBoxListUsers.Name = "comboBoxListUsers";
//            this.comboBoxListUsers.Size = new System.Drawing.Size(280, 21);
//            this.comboBoxListUsers.TabIndex = 11;
//            this.comboBoxListUsers.SelectedIndexChanged += new System.EventHandler(this.comboBoxListUsers_SelectedIndexChanged);
//            // 
//            // labelFirstnameValue
//            // 
//            this.labelFirstnameValue.AutoSize = true;
//            this.labelFirstnameValue.BackColor = System.Drawing.Color.Transparent;
//            this.labelFirstnameValue.ForeColor = System.Drawing.Color.White;
//            this.labelFirstnameValue.Location = new System.Drawing.Point(115, 32);
//            this.labelFirstnameValue.Name = "labelFirstnameValue";
//            this.labelFirstnameValue.Size = new System.Drawing.Size(49, 13);
//            this.labelFirstnameValue.TabIndex = 12;
//            this.labelFirstnameValue.Text = "_______";
//            // 
//            // labelNameValue
//            // 
//            this.labelNameValue.AutoSize = true;
//            this.labelNameValue.BackColor = System.Drawing.Color.Transparent;
//            this.labelNameValue.ForeColor = System.Drawing.Color.White;
//            this.labelNameValue.Location = new System.Drawing.Point(115, 58);
//            this.labelNameValue.Name = "labelNameValue";
//            this.labelNameValue.Size = new System.Drawing.Size(49, 13);
//            this.labelNameValue.TabIndex = 13;
//            this.labelNameValue.Text = "_______";
//            // 
//            // panelMember
//            // 
//            this.panelMember.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
//            this.panelMember.Controls.Add(this.labelNameValue);
//            this.panelMember.Controls.Add(this.labelFirstnameValue);
//            this.panelMember.Controls.Add(this.comboBoxListUsers);
//            this.panelMember.Controls.Add(this.labelProjectList);
//            this.panelMember.Controls.Add(this.buttonCancel);
//            this.panelMember.Controls.Add(this.buttonDelete);
//            this.panelMember.Controls.Add(this.labelName);
//            this.panelMember.Controls.Add(this.labelFirstName);
//            this.panelMember.Controls.Add(this.pictureBoxUser);
//            this.panelMember.Location = new System.Drawing.Point(38, 81);
//            this.panelMember.Name = "panelMember";
//            this.panelMember.Size = new System.Drawing.Size(356, 141);
//            this.panelMember.TabIndex = 1;
//            // 
//            // UserDelete
//            // 
//            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
//            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
//            this.ClientSize = new System.Drawing.Size(440, 259);
//            this.Controls.Add(this.panelMember);
//            this.Name = "UserDelete";
//            this.Text = "UserCard";
//            this.Controls.SetChildIndex(this.panelMember, 0);
//            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxUser)).EndInit();
//            this.panelMember.ResumeLayout(false);
//            this.panelMember.PerformLayout();
//            this.ResumeLayout(false);

//        }

//        #endregion

//        private System.Windows.Forms.ColorDialog colorDialog1;
//        private System.Windows.Forms.PictureBox pictureBoxUser;
//        private System.Windows.Forms.Label labelFirstName;
//        private System.Windows.Forms.Label labelName;
//        private System.Windows.Forms.Button buttonDelete;
//        private System.Windows.Forms.Button buttonCancel;
//        private System.Windows.Forms.Label labelProjectList;
//        private System.Windows.Forms.ComboBox comboBoxListUsers;
//        private System.Windows.Forms.Label labelFirstnameValue;
//        private System.Windows.Forms.Label labelNameValue;
//        private System.Windows.Forms.Panel panelMember;
//    }
//}