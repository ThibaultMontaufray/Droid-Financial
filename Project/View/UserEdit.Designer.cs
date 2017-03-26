//namespace Droid_financial
//{
//    partial class UserEdit
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
//            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserEdit));
//            this.panelMember = new System.Windows.Forms.Panel();
//            this.comboBoxListUsers = new System.Windows.Forms.ComboBox();
//            this.checkBoxNew = new System.Windows.Forms.CheckBox();
//            this.labelProjectList = new System.Windows.Forms.Label();
//            this.buttonColor = new System.Windows.Forms.Button();
//            this.buttonCancel = new System.Windows.Forms.Button();
//            this.buttonApply = new System.Windows.Forms.Button();
//            this.buttonImgDown = new System.Windows.Forms.Button();
//            this.buttonImgUp = new System.Windows.Forms.Button();
//            this.textBoxName = new System.Windows.Forms.TextBox();
//            this.textBoxFirstname = new System.Windows.Forms.TextBox();
//            this.labelNom = new System.Windows.Forms.Label();
//            this.labelPrenom = new System.Windows.Forms.Label();
//            this.pictureBoxUser = new System.Windows.Forms.PictureBox();
//            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
//            this.dateTimePickerStart = new System.Windows.Forms.DateTimePicker();
//            this.dateTimePickerEnd = new System.Windows.Forms.DateTimePicker();
//            this.labelStartParticipation = new System.Windows.Forms.Label();
//            this.labelEndParticipation = new System.Windows.Forms.Label();
//            this.panelMember.SuspendLayout();
//            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxUser)).BeginInit();
//            this.SuspendLayout();
//            // 
//            // labelTitle
//            // 
//            this.labelTitle.Size = new System.Drawing.Size(68, 17);
//            this.labelTitle.Text = "User : Edit";
//            // 
//            // panelMember
//            // 
//            this.panelMember.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
//            this.panelMember.Controls.Add(this.labelEndParticipation);
//            this.panelMember.Controls.Add(this.labelStartParticipation);
//            this.panelMember.Controls.Add(this.dateTimePickerEnd);
//            this.panelMember.Controls.Add(this.dateTimePickerStart);
//            this.panelMember.Controls.Add(this.comboBoxListUsers);
//            this.panelMember.Controls.Add(this.checkBoxNew);
//            this.panelMember.Controls.Add(this.labelProjectList);
//            this.panelMember.Controls.Add(this.buttonColor);
//            this.panelMember.Controls.Add(this.buttonCancel);
//            this.panelMember.Controls.Add(this.buttonApply);
//            this.panelMember.Controls.Add(this.buttonImgDown);
//            this.panelMember.Controls.Add(this.buttonImgUp);
//            this.panelMember.Controls.Add(this.textBoxName);
//            this.panelMember.Controls.Add(this.textBoxFirstname);
//            this.panelMember.Controls.Add(this.labelNom);
//            this.panelMember.Controls.Add(this.labelPrenom);
//            this.panelMember.Controls.Add(this.pictureBoxUser);
//            this.panelMember.Location = new System.Drawing.Point(40, 82);
//            this.panelMember.Name = "panelMember";
//            this.panelMember.Size = new System.Drawing.Size(352, 217);
//            this.panelMember.TabIndex = 1;
//            // 
//            // comboBoxListUsers
//            // 
//            this.comboBoxListUsers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
//            this.comboBoxListUsers.FormattingEnabled = true;
//            this.comboBoxListUsers.Location = new System.Drawing.Point(89, 29);
//            this.comboBoxListUsers.Name = "comboBoxListUsers";
//            this.comboBoxListUsers.Size = new System.Drawing.Size(256, 21);
//            this.comboBoxListUsers.TabIndex = 11;
//            this.comboBoxListUsers.SelectedIndexChanged += new System.EventHandler(this.comboBoxListUsers_SelectedIndexChanged);
//            // 
//            // checkBoxNew
//            // 
//            this.checkBoxNew.AutoSize = true;
//            this.checkBoxNew.ForeColor = System.Drawing.Color.White;
//            this.checkBoxNew.Location = new System.Drawing.Point(22, 6);
//            this.checkBoxNew.Name = "checkBoxNew";
//            this.checkBoxNew.Size = new System.Drawing.Size(71, 17);
//            this.checkBoxNew.TabIndex = 10;
//            this.checkBoxNew.Text = "New user";
//            this.checkBoxNew.UseVisualStyleBackColor = true;
//            this.checkBoxNew.CheckedChanged += new System.EventHandler(this.checkBoxNew_CheckedChanged);
//            // 
//            // labelProjectList
//            // 
//            this.labelProjectList.AutoSize = true;
//            this.labelProjectList.BackColor = System.Drawing.Color.Transparent;
//            this.labelProjectList.ForeColor = System.Drawing.Color.White;
//            this.labelProjectList.Location = new System.Drawing.Point(19, 32);
//            this.labelProjectList.Name = "labelProjectList";
//            this.labelProjectList.Size = new System.Drawing.Size(64, 13);
//            this.labelProjectList.TabIndex = 9;
//            this.labelProjectList.Text = "Project list : ";
//            // 
//            // buttonColor
//            // 
//            this.buttonColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
//            this.buttonColor.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
//            this.buttonColor.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGray;
//            this.buttonColor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
//            this.buttonColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
//            this.buttonColor.ForeColor = System.Drawing.Color.White;
//            this.buttonColor.Location = new System.Drawing.Point(89, 160);
//            this.buttonColor.Name = "buttonColor";
//            this.buttonColor.Size = new System.Drawing.Size(256, 22);
//            this.buttonColor.TabIndex = 8;
//            this.buttonColor.Text = "user color";
//            this.buttonColor.UseVisualStyleBackColor = false;
//            this.buttonColor.Click += new System.EventHandler(this.buttonColor_Click);
//            // 
//            // buttonCancel
//            // 
//            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
//            this.buttonCancel.Location = new System.Drawing.Point(262, 188);
//            this.buttonCancel.Name = "buttonCancel";
//            this.buttonCancel.Size = new System.Drawing.Size(83, 22);
//            this.buttonCancel.TabIndex = 7;
//            this.buttonCancel.Text = "Cancel";
//            this.buttonCancel.UseVisualStyleBackColor = true;
//            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
//            // 
//            // buttonApply
//            // 
//            this.buttonApply.Location = new System.Drawing.Point(173, 188);
//            this.buttonApply.Name = "buttonApply";
//            this.buttonApply.Size = new System.Drawing.Size(83, 22);
//            this.buttonApply.TabIndex = 2;
//            this.buttonApply.Text = "Apply";
//            this.buttonApply.UseVisualStyleBackColor = true;
//            this.buttonApply.Click += new System.EventHandler(this.buttonApply_Click);
//            // 
//            // buttonImgDown
//            // 
//            this.buttonImgDown.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonImgDown.BackgroundImage")));
//            this.buttonImgDown.FlatAppearance.BorderSize = 0;
//            this.buttonImgDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
//            this.buttonImgDown.Location = new System.Drawing.Point(17, 191);
//            this.buttonImgDown.Name = "buttonImgDown";
//            this.buttonImgDown.Size = new System.Drawing.Size(16, 16);
//            this.buttonImgDown.TabIndex = 6;
//            this.buttonImgDown.UseVisualStyleBackColor = true;
//            this.buttonImgDown.Click += new System.EventHandler(this.buttonImgDown_Click);
//            // 
//            // buttonImgUp
//            // 
//            this.buttonImgUp.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonImgUp.BackgroundImage")));
//            this.buttonImgUp.FlatAppearance.BorderSize = 0;
//            this.buttonImgUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
//            this.buttonImgUp.Location = new System.Drawing.Point(17, 165);
//            this.buttonImgUp.Name = "buttonImgUp";
//            this.buttonImgUp.Size = new System.Drawing.Size(16, 16);
//            this.buttonImgUp.TabIndex = 5;
//            this.buttonImgUp.UseVisualStyleBackColor = true;
//            this.buttonImgUp.Click += new System.EventHandler(this.buttonImgUp_Click);
//            // 
//            // textBoxName
//            // 
//            this.textBoxName.Location = new System.Drawing.Point(89, 82);
//            this.textBoxName.Name = "textBoxName";
//            this.textBoxName.Size = new System.Drawing.Size(256, 20);
//            this.textBoxName.TabIndex = 4;
//            // 
//            // textBoxFirstname
//            // 
//            this.textBoxFirstname.Location = new System.Drawing.Point(89, 56);
//            this.textBoxFirstname.Name = "textBoxFirstname";
//            this.textBoxFirstname.Size = new System.Drawing.Size(256, 20);
//            this.textBoxFirstname.TabIndex = 2;
//            // 
//            // labelNom
//            // 
//            this.labelNom.AutoSize = true;
//            this.labelNom.BackColor = System.Drawing.Color.Transparent;
//            this.labelNom.ForeColor = System.Drawing.Color.White;
//            this.labelNom.Location = new System.Drawing.Point(19, 84);
//            this.labelNom.Name = "labelNom";
//            this.labelNom.Size = new System.Drawing.Size(35, 13);
//            this.labelNom.TabIndex = 3;
//            this.labelNom.Text = "Name";
//            // 
//            // labelPrenom
//            // 
//            this.labelPrenom.AutoSize = true;
//            this.labelPrenom.BackColor = System.Drawing.Color.Transparent;
//            this.labelPrenom.ForeColor = System.Drawing.Color.White;
//            this.labelPrenom.Location = new System.Drawing.Point(19, 58);
//            this.labelPrenom.Name = "labelPrenom";
//            this.labelPrenom.Size = new System.Drawing.Size(52, 13);
//            this.labelPrenom.TabIndex = 2;
//            this.labelPrenom.Text = "Firstname";
//            // 
//            // pictureBoxUser
//            // 
//            this.pictureBoxUser.Location = new System.Drawing.Point(39, 171);
//            this.pictureBoxUser.Name = "pictureBoxUser";
//            this.pictureBoxUser.Size = new System.Drawing.Size(32, 32);
//            this.pictureBoxUser.TabIndex = 0;
//            this.pictureBoxUser.TabStop = false;
//            // 
//            // dateTimePickerStart
//            // 
//            this.dateTimePickerStart.Location = new System.Drawing.Point(145, 108);
//            this.dateTimePickerStart.Name = "dateTimePickerStart";
//            this.dateTimePickerStart.Size = new System.Drawing.Size(200, 20);
//            this.dateTimePickerStart.TabIndex = 12;
//            // 
//            // dateTimePickerEnd
//            // 
//            this.dateTimePickerEnd.Location = new System.Drawing.Point(145, 134);
//            this.dateTimePickerEnd.Name = "dateTimePickerEnd";
//            this.dateTimePickerEnd.Size = new System.Drawing.Size(200, 20);
//            this.dateTimePickerEnd.TabIndex = 13;
//            // 
//            // labelStartParticipation
//            // 
//            this.labelStartParticipation.AutoSize = true;
//            this.labelStartParticipation.BackColor = System.Drawing.Color.Transparent;
//            this.labelStartParticipation.ForeColor = System.Drawing.Color.White;
//            this.labelStartParticipation.Location = new System.Drawing.Point(19, 114);
//            this.labelStartParticipation.Name = "labelStartParticipation";
//            this.labelStartParticipation.Size = new System.Drawing.Size(119, 13);
//            this.labelStartParticipation.TabIndex = 14;
//            this.labelStartParticipation.Text = "Start participation date :";
//            // 
//            // labelEndParticipation
//            // 
//            this.labelEndParticipation.AutoSize = true;
//            this.labelEndParticipation.BackColor = System.Drawing.Color.Transparent;
//            this.labelEndParticipation.ForeColor = System.Drawing.Color.White;
//            this.labelEndParticipation.Location = new System.Drawing.Point(19, 140);
//            this.labelEndParticipation.Name = "labelEndParticipation";
//            this.labelEndParticipation.Size = new System.Drawing.Size(116, 13);
//            this.labelEndParticipation.TabIndex = 15;
//            this.labelEndParticipation.Text = "End participation date :";
//            // 
//            // UserEdit
//            // 
//            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
//            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
//            this.ClientSize = new System.Drawing.Size(438, 328);
//            this.Controls.Add(this.panelMember);
//            this.Name = "UserEdit";
//            this.Text = "UserCard";
//            this.Controls.SetChildIndex(this.panelMember, 0);
//            this.panelMember.ResumeLayout(false);
//            this.panelMember.PerformLayout();
//            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxUser)).EndInit();
//            this.ResumeLayout(false);

//        }

//        #endregion

//        private System.Windows.Forms.Panel panelMember;
//        private System.Windows.Forms.Label labelNom;
//        private System.Windows.Forms.Label labelPrenom;
//        private System.Windows.Forms.PictureBox pictureBoxUser;
//        private System.Windows.Forms.TextBox textBoxName;
//        private System.Windows.Forms.TextBox textBoxFirstname;
//        private System.Windows.Forms.Button buttonImgDown;
//        private System.Windows.Forms.Button buttonImgUp;
//        private System.Windows.Forms.Button buttonApply;
//        private System.Windows.Forms.Button buttonCancel;
//        private System.Windows.Forms.Button buttonColor;
//        private System.Windows.Forms.ColorDialog colorDialog1;
//        private System.Windows.Forms.ComboBox comboBoxListUsers;
//        private System.Windows.Forms.CheckBox checkBoxNew;
//        private System.Windows.Forms.Label labelProjectList;
//        private System.Windows.Forms.Label labelEndParticipation;
//        private System.Windows.Forms.Label labelStartParticipation;
//        private System.Windows.Forms.DateTimePicker dateTimePickerEnd;
//        private System.Windows.Forms.DateTimePicker dateTimePickerStart;
//    }
//}