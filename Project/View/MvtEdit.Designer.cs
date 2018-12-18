using Tools4Libraries;
namespace Droid.financial
{
    partial class ExpsEdit
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

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExpsEdit));
            this.labelExpense = new System.Windows.Forms.Label();
            this.textBoxMovementName = new System.Windows.Forms.TextBox();
            this.labelAmount = new System.Windows.Forms.Label();
            this.textBoxAmount = new System.Windows.Forms.TextBox();
            this.labelUser = new System.Windows.Forms.Label();
            this.labelDevise = new System.Windows.Forms.Label();
            this.comboBoxCurrency = new System.Windows.Forms.ComboBox();
            this.labelBill = new System.Windows.Forms.Label();
            this.textBoxBillPath = new System.Windows.Forms.TextBox();
            this.buttonBrowseBill = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonAbonmnent = new System.Windows.Forms.RadioButton();
            this.radioButtonLogement = new System.Windows.Forms.RadioButton();
            this.radioButtonClothe = new System.Windows.Forms.RadioButton();
            this.radioButtonLoan = new System.Windows.Forms.RadioButton();
            this.radioButtonOther = new System.Windows.Forms.RadioButton();
            this.labelGOP = new System.Windows.Forms.Label();
            this.radioButtonComodities = new System.Windows.Forms.RadioButton();
            this.radioButtonActivities = new System.Windows.Forms.RadioButton();
            this.radioButtonFood = new System.Windows.Forms.RadioButton();
            this.radioButtonTransport = new System.Windows.Forms.RadioButton();
            this.buttonValidateMovement = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.comboBoxMovement = new System.Windows.Forms.ComboBox();
            this.labelDescription = new System.Windows.Forms.Label();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.checkBoxNewMovement = new System.Windows.Forms.CheckBox();
            this.dateTimePickerStartDate = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerEndDate = new System.Windows.Forms.DateTimePicker();
            this.labelStartDate = new System.Windows.Forms.Label();
            this.labelEndDate = new System.Windows.Forms.Label();
            this.buttonTakePicture = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.checkBoxAllRegardingParticipants = new System.Windows.Forms.CheckBox();
            this.checkBoxIsPartial = new System.Windows.Forms.CheckBox();
            this.comboBoxWho = new CheckedComboBox();
            this.comboBoxParticipantList = new CheckedComboBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.Size = new System.Drawing.Size(125, 17);
            this.labelTitle.Text = "Movement : edition";
            // 
            // labelExpense
            // 
            this.labelExpense.AutoSize = true;
            this.labelExpense.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            this.labelExpense.Location = new System.Drawing.Point(53, 102);
            this.labelExpense.Name = "labelExpense";
            this.labelExpense.Size = new System.Drawing.Size(57, 13);
            this.labelExpense.TabIndex = 0;
            this.labelExpense.Text = "Movement";
            // 
            // textBoxMovementName
            // 
            this.textBoxMovementName.Location = new System.Drawing.Point(136, 100);
            this.textBoxMovementName.Name = "textBoxMovementName";
            this.textBoxMovementName.Size = new System.Drawing.Size(276, 20);
            this.textBoxMovementName.TabIndex = 1;
            // 
            // labelAmount
            // 
            this.labelAmount.AutoSize = true;
            this.labelAmount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            this.labelAmount.Location = new System.Drawing.Point(53, 180);
            this.labelAmount.Name = "labelAmount";
            this.labelAmount.Size = new System.Drawing.Size(43, 13);
            this.labelAmount.TabIndex = 2;
            this.labelAmount.Text = "Amount";
            // 
            // textBoxAmount
            // 
            this.textBoxAmount.Location = new System.Drawing.Point(136, 177);
            this.textBoxAmount.Name = "textBoxAmount";
            this.textBoxAmount.Size = new System.Drawing.Size(111, 20);
            this.textBoxAmount.TabIndex = 3;
            this.textBoxAmount.TextChanged += new System.EventHandler(this.textBoxAmount_TextChanged);
            // 
            // labelUser
            // 
            this.labelUser.AutoSize = true;
            this.labelUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            this.labelUser.Location = new System.Drawing.Point(53, 128);
            this.labelUser.Name = "labelUser";
            this.labelUser.Size = new System.Drawing.Size(74, 13);
            this.labelUser.TabIndex = 4;
            this.labelUser.Text = "Who depense";
            // 
            // labelDevise
            // 
            this.labelDevise.AutoSize = true;
            this.labelDevise.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            this.labelDevise.Location = new System.Drawing.Point(253, 179);
            this.labelDevise.Name = "labelDevise";
            this.labelDevise.Size = new System.Drawing.Size(49, 13);
            this.labelDevise.TabIndex = 6;
            this.labelDevise.Text = "Currency";
            // 
            // comboBoxCurrency
            // 
            this.comboBoxCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCurrency.ForeColor = System.Drawing.Color.Black;
            this.comboBoxCurrency.FormattingEnabled = true;
            this.comboBoxCurrency.Location = new System.Drawing.Point(308, 176);
            this.comboBoxCurrency.Name = "comboBoxCurrency";
            this.comboBoxCurrency.Size = new System.Drawing.Size(104, 21);
            this.comboBoxCurrency.Sorted = true;
            this.comboBoxCurrency.TabIndex = 7;
            // 
            // labelBill
            // 
            this.labelBill.AutoSize = true;
            this.labelBill.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            this.labelBill.Location = new System.Drawing.Point(53, 206);
            this.labelBill.Name = "labelBill";
            this.labelBill.Size = new System.Drawing.Size(51, 13);
            this.labelBill.TabIndex = 8;
            this.labelBill.Text = "Import bill";
            // 
            // textBoxBillPath
            // 
            this.textBoxBillPath.Location = new System.Drawing.Point(136, 203);
            this.textBoxBillPath.Name = "textBoxBillPath";
            this.textBoxBillPath.Size = new System.Drawing.Size(186, 20);
            this.textBoxBillPath.TabIndex = 9;
            // 
            // buttonBrowseBill
            // 
            this.buttonBrowseBill.BackColor = System.Drawing.Color.WhiteSmoke;
            this.buttonBrowseBill.ForeColor = System.Drawing.Color.Black;
            this.buttonBrowseBill.Location = new System.Drawing.Point(328, 201);
            this.buttonBrowseBill.Name = "buttonBrowseBill";
            this.buttonBrowseBill.Size = new System.Drawing.Size(84, 23);
            this.buttonBrowseBill.TabIndex = 10;
            this.buttonBrowseBill.Text = "browse";
            this.buttonBrowseBill.UseVisualStyleBackColor = false;
            this.buttonBrowseBill.Click += new System.EventHandler(this.buttonBrowseBill_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            this.groupBox1.Controls.Add(this.radioButtonAbonmnent);
            this.groupBox1.Controls.Add(this.radioButtonLogement);
            this.groupBox1.Controls.Add(this.radioButtonClothe);
            this.groupBox1.Controls.Add(this.radioButtonLoan);
            this.groupBox1.Controls.Add(this.radioButtonOther);
            this.groupBox1.Controls.Add(this.labelGOP);
            this.groupBox1.Controls.Add(this.radioButtonComodities);
            this.groupBox1.Controls.Add(this.radioButtonActivities);
            this.groupBox1.Controls.Add(this.radioButtonFood);
            this.groupBox1.Controls.Add(this.radioButtonTransport);
            this.groupBox1.Location = new System.Drawing.Point(58, 349);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(352, 112);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            // 
            // radioButtonAbonmnent
            // 
            this.radioButtonAbonmnent.AutoSize = true;
            this.radioButtonAbonmnent.Location = new System.Drawing.Point(119, 42);
            this.radioButtonAbonmnent.Name = "radioButtonAbonmnent";
            this.radioButtonAbonmnent.Size = new System.Drawing.Size(85, 17);
            this.radioButtonAbonmnent.TabIndex = 10;
            this.radioButtonAbonmnent.TabStop = true;
            this.radioButtonAbonmnent.Text = "Abonnement";
            this.radioButtonAbonmnent.UseVisualStyleBackColor = true;
            // 
            // radioButtonLogement
            // 
            this.radioButtonLogement.AutoSize = true;
            this.radioButtonLogement.Location = new System.Drawing.Point(250, 88);
            this.radioButtonLogement.Name = "radioButtonLogement";
            this.radioButtonLogement.Size = new System.Drawing.Size(72, 17);
            this.radioButtonLogement.TabIndex = 9;
            this.radioButtonLogement.TabStop = true;
            this.radioButtonLogement.Text = "Logement";
            this.radioButtonLogement.UseVisualStyleBackColor = true;
            // 
            // radioButtonClothe
            // 
            this.radioButtonClothe.AutoSize = true;
            this.radioButtonClothe.Location = new System.Drawing.Point(119, 88);
            this.radioButtonClothe.Name = "radioButtonClothe";
            this.radioButtonClothe.Size = new System.Drawing.Size(60, 17);
            this.radioButtonClothe.TabIndex = 8;
            this.radioButtonClothe.TabStop = true;
            this.radioButtonClothe.Text = "Clothes";
            this.radioButtonClothe.UseVisualStyleBackColor = true;
            // 
            // radioButtonLoan
            // 
            this.radioButtonLoan.AutoSize = true;
            this.radioButtonLoan.Location = new System.Drawing.Point(119, 65);
            this.radioButtonLoan.Name = "radioButtonLoan";
            this.radioButtonLoan.Size = new System.Drawing.Size(49, 17);
            this.radioButtonLoan.TabIndex = 7;
            this.radioButtonLoan.TabStop = true;
            this.radioButtonLoan.Text = "Loan";
            this.radioButtonLoan.UseVisualStyleBackColor = true;
            // 
            // radioButtonOther
            // 
            this.radioButtonOther.AutoSize = true;
            this.radioButtonOther.Location = new System.Drawing.Point(250, 65);
            this.radioButtonOther.Name = "radioButtonOther";
            this.radioButtonOther.Size = new System.Drawing.Size(51, 17);
            this.radioButtonOther.TabIndex = 6;
            this.radioButtonOther.TabStop = true;
            this.radioButtonOther.Text = "Other";
            this.radioButtonOther.UseVisualStyleBackColor = true;
            // 
            // labelGOP
            // 
            this.labelGOP.AutoSize = true;
            this.labelGOP.Location = new System.Drawing.Point(14, 16);
            this.labelGOP.Name = "labelGOP";
            this.labelGOP.Size = new System.Drawing.Size(117, 13);
            this.labelGOP.TabIndex = 5;
            this.labelGOP.Text = "Group Operation (GOP)";
            // 
            // radioButtonComodities
            // 
            this.radioButtonComodities.AutoSize = true;
            this.radioButtonComodities.Location = new System.Drawing.Point(250, 42);
            this.radioButtonComodities.Name = "radioButtonComodities";
            this.radioButtonComodities.Size = new System.Drawing.Size(76, 17);
            this.radioButtonComodities.TabIndex = 3;
            this.radioButtonComodities.TabStop = true;
            this.radioButtonComodities.Text = "Comodities";
            this.radioButtonComodities.UseVisualStyleBackColor = true;
            // 
            // radioButtonActivities
            // 
            this.radioButtonActivities.AutoSize = true;
            this.radioButtonActivities.Location = new System.Drawing.Point(6, 65);
            this.radioButtonActivities.Name = "radioButtonActivities";
            this.radioButtonActivities.Size = new System.Drawing.Size(67, 17);
            this.radioButtonActivities.TabIndex = 2;
            this.radioButtonActivities.TabStop = true;
            this.radioButtonActivities.Text = "Activities";
            this.radioButtonActivities.UseVisualStyleBackColor = true;
            // 
            // radioButtonFood
            // 
            this.radioButtonFood.AutoSize = true;
            this.radioButtonFood.Location = new System.Drawing.Point(6, 88);
            this.radioButtonFood.Name = "radioButtonFood";
            this.radioButtonFood.Size = new System.Drawing.Size(49, 17);
            this.radioButtonFood.TabIndex = 1;
            this.radioButtonFood.TabStop = true;
            this.radioButtonFood.Text = "Food";
            this.radioButtonFood.UseVisualStyleBackColor = true;
            // 
            // radioButtonTransport
            // 
            this.radioButtonTransport.AutoSize = true;
            this.radioButtonTransport.Location = new System.Drawing.Point(6, 42);
            this.radioButtonTransport.Name = "radioButtonTransport";
            this.radioButtonTransport.Size = new System.Drawing.Size(70, 17);
            this.radioButtonTransport.TabIndex = 0;
            this.radioButtonTransport.TabStop = true;
            this.radioButtonTransport.Text = "Transport";
            this.radioButtonTransport.UseVisualStyleBackColor = true;
            // 
            // buttonValidateMovement
            // 
            this.buttonValidateMovement.BackColor = System.Drawing.Color.DimGray;
            this.buttonValidateMovement.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonValidateMovement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonValidateMovement.ForeColor = System.Drawing.Color.Gainsboro;
            this.buttonValidateMovement.Location = new System.Drawing.Point(225, 468);
            this.buttonValidateMovement.Name = "buttonValidateMovement";
            this.buttonValidateMovement.Size = new System.Drawing.Size(91, 23);
            this.buttonValidateMovement.TabIndex = 15;
            this.buttonValidateMovement.Text = "Create";
            this.buttonValidateMovement.UseVisualStyleBackColor = false;
            this.buttonValidateMovement.Click += new System.EventHandler(this.buttonValidateMovement_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.BackColor = System.Drawing.Color.DimGray;
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancel.ForeColor = System.Drawing.Color.Gainsboro;
            this.buttonCancel.Location = new System.Drawing.Point(322, 468);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(88, 23);
            this.buttonCancel.TabIndex = 16;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = false;
            // 
            // comboBoxMovement
            // 
            this.comboBoxMovement.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMovement.Enabled = false;
            this.comboBoxMovement.ForeColor = System.Drawing.Color.Black;
            this.comboBoxMovement.FormattingEnabled = true;
            this.comboBoxMovement.Location = new System.Drawing.Point(177, 74);
            this.comboBoxMovement.Name = "comboBoxMovement";
            this.comboBoxMovement.Size = new System.Drawing.Size(235, 21);
            this.comboBoxMovement.Sorted = true;
            this.comboBoxMovement.TabIndex = 17;
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            this.labelDescription.Location = new System.Drawing.Point(53, 232);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(60, 13);
            this.labelDescription.TabIndex = 18;
            this.labelDescription.Text = "Description";
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Location = new System.Drawing.Point(136, 229);
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(276, 40);
            this.textBoxDescription.TabIndex = 19;
            // 
            // checkBoxNewMovement
            // 
            this.checkBoxNewMovement.AutoSize = true;
            this.checkBoxNewMovement.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            this.checkBoxNewMovement.Checked = true;
            this.checkBoxNewMovement.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxNewMovement.Location = new System.Drawing.Point(55, 76);
            this.checkBoxNewMovement.Name = "checkBoxNewMovement";
            this.checkBoxNewMovement.Size = new System.Drawing.Size(100, 17);
            this.checkBoxNewMovement.TabIndex = 20;
            this.checkBoxNewMovement.Text = "New movement";
            this.checkBoxNewMovement.UseVisualStyleBackColor = false;
            this.checkBoxNewMovement.CheckedChanged += new System.EventHandler(this.checkBoxNewMovement_CheckedChanged);
            // 
            // dateTimePickerStartDate
            // 
            this.dateTimePickerStartDate.Enabled = false;
            this.dateTimePickerStartDate.Location = new System.Drawing.Point(136, 302);
            this.dateTimePickerStartDate.Name = "dateTimePickerStartDate";
            this.dateTimePickerStartDate.Size = new System.Drawing.Size(276, 20);
            this.dateTimePickerStartDate.TabIndex = 23;
            // 
            // dateTimePickerEndDate
            // 
            this.dateTimePickerEndDate.Enabled = false;
            this.dateTimePickerEndDate.Location = new System.Drawing.Point(136, 327);
            this.dateTimePickerEndDate.Name = "dateTimePickerEndDate";
            this.dateTimePickerEndDate.Size = new System.Drawing.Size(276, 20);
            this.dateTimePickerEndDate.TabIndex = 24;
            // 
            // labelStartDate
            // 
            this.labelStartDate.AutoSize = true;
            this.labelStartDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            this.labelStartDate.Enabled = false;
            this.labelStartDate.Location = new System.Drawing.Point(55, 304);
            this.labelStartDate.Name = "labelStartDate";
            this.labelStartDate.Size = new System.Drawing.Size(59, 13);
            this.labelStartDate.TabIndex = 25;
            this.labelStartDate.Text = "Start date :";
            // 
            // labelEndDate
            // 
            this.labelEndDate.AutoSize = true;
            this.labelEndDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            this.labelEndDate.Enabled = false;
            this.labelEndDate.Location = new System.Drawing.Point(56, 329);
            this.labelEndDate.Name = "labelEndDate";
            this.labelEndDate.Size = new System.Drawing.Size(56, 13);
            this.labelEndDate.TabIndex = 26;
            this.labelEndDate.Text = "End date :";
            // 
            // buttonTakePicture
            // 
            this.buttonTakePicture.BackColor = System.Drawing.Color.DimGray;
            this.buttonTakePicture.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonTakePicture.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTakePicture.ForeColor = System.Drawing.Color.Gainsboro;
            this.buttonTakePicture.Location = new System.Drawing.Point(416, 468);
            this.buttonTakePicture.Name = "buttonTakePicture";
            this.buttonTakePicture.Size = new System.Drawing.Size(346, 23);
            this.buttonTakePicture.TabIndex = 29;
            this.buttonTakePicture.Text = "Take picture with camera";
            this.buttonTakePicture.UseVisualStyleBackColor = false;
            this.buttonTakePicture.Click += new System.EventHandler(this.buttonCamera_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.Color.Gainsboro;
            this.pictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox.Image")));
            this.pictureBox.Location = new System.Drawing.Point(416, 74);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(351, 388);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 31;
            this.pictureBox.TabStop = false;
            this.pictureBox.DoubleClick += new System.EventHandler(this.pictureBox_DoubleClick);
            // 
            // checkBoxAllRegardingParticipants
            // 
            this.checkBoxAllRegardingParticipants.AutoSize = true;
            this.checkBoxAllRegardingParticipants.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            this.checkBoxAllRegardingParticipants.Checked = true;
            this.checkBoxAllRegardingParticipants.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxAllRegardingParticipants.Location = new System.Drawing.Point(55, 152);
            this.checkBoxAllRegardingParticipants.Name = "checkBoxAllRegardingParticipants";
            this.checkBoxAllRegardingParticipants.Size = new System.Drawing.Size(111, 17);
            this.checkBoxAllRegardingParticipants.TabIndex = 33;
            this.checkBoxAllRegardingParticipants.Text = "For all participants";
            this.checkBoxAllRegardingParticipants.UseVisualStyleBackColor = false;
            this.checkBoxAllRegardingParticipants.CheckedChanged += new System.EventHandler(this.checkBoxAllRegardingParticipants_CheckedChanged);
            // 
            // checkBoxIsPartial
            // 
            this.checkBoxIsPartial.AutoSize = true;
            this.checkBoxIsPartial.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            this.checkBoxIsPartial.Location = new System.Drawing.Point(53, 278);
            this.checkBoxIsPartial.Name = "checkBoxIsPartial";
            this.checkBoxIsPartial.Size = new System.Drawing.Size(321, 17);
            this.checkBoxIsPartial.TabIndex = 34;
            this.checkBoxIsPartial.Text = "Is partial movement ( calculate rate per user date participation )";
            this.checkBoxIsPartial.UseVisualStyleBackColor = false;
            this.checkBoxIsPartial.CheckedChanged += new System.EventHandler(this.checkBoxIsPartial_CheckedChanged);
            // 
            // comboBoxWho
            // 
            this.comboBoxWho.CheckOnClick = true;
            this.comboBoxWho.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.comboBoxWho.DropDownHeight = 1;
            this.comboBoxWho.FormattingEnabled = true;
            this.comboBoxWho.IntegralHeight = false;
            this.comboBoxWho.Location = new System.Drawing.Point(136, 125);
            this.comboBoxWho.Name = "comboBoxWho";
            this.comboBoxWho.Size = new System.Drawing.Size(276, 21);
            this.comboBoxWho.TabIndex = 37;
            this.comboBoxWho.ValueSeparator = ", ";
            // 
            // comboBoxParticipantList
            // 
            this.comboBoxParticipantList.CheckOnClick = true;
            this.comboBoxParticipantList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.comboBoxParticipantList.DropDownHeight = 1;
            this.comboBoxParticipantList.Enabled = false;
            this.comboBoxParticipantList.FormattingEnabled = true;
            this.comboBoxParticipantList.IntegralHeight = false;
            this.comboBoxParticipantList.Location = new System.Drawing.Point(172, 151);
            this.comboBoxParticipantList.Name = "comboBoxParticipantList";
            this.comboBoxParticipantList.Size = new System.Drawing.Size(240, 21);
            this.comboBoxParticipantList.TabIndex = 38;
            this.comboBoxParticipantList.ValueSeparator = ", ";
            // 
            // ExpsEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Blue;
            this.ClientSize = new System.Drawing.Size(813, 549);
            this.Controls.Add(this.comboBoxParticipantList);
            this.Controls.Add(this.comboBoxWho);
            this.Controls.Add(this.checkBoxIsPartial);
            this.Controls.Add(this.checkBoxAllRegardingParticipants);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.buttonTakePicture);
            this.Controls.Add(this.labelEndDate);
            this.Controls.Add(this.labelStartDate);
            this.Controls.Add(this.dateTimePickerEndDate);
            this.Controls.Add(this.dateTimePickerStartDate);
            this.Controls.Add(this.checkBoxNewMovement);
            this.Controls.Add(this.textBoxDescription);
            this.Controls.Add(this.labelDescription);
            this.Controls.Add(this.comboBoxMovement);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonValidateMovement);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonBrowseBill);
            this.Controls.Add(this.textBoxBillPath);
            this.Controls.Add(this.labelBill);
            this.Controls.Add(this.comboBoxCurrency);
            this.Controls.Add(this.labelDevise);
            this.Controls.Add(this.labelUser);
            this.Controls.Add(this.textBoxAmount);
            this.Controls.Add(this.labelAmount);
            this.Controls.Add(this.textBoxMovementName);
            this.Controls.Add(this.labelExpense);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "ExpsEdit";
            this.Text = "Expense";
            this.Controls.SetChildIndex(this.labelExpense, 0);
            this.Controls.SetChildIndex(this.textBoxMovementName, 0);
            this.Controls.SetChildIndex(this.labelAmount, 0);
            this.Controls.SetChildIndex(this.textBoxAmount, 0);
            this.Controls.SetChildIndex(this.labelUser, 0);
            this.Controls.SetChildIndex(this.labelDevise, 0);
            this.Controls.SetChildIndex(this.comboBoxCurrency, 0);
            this.Controls.SetChildIndex(this.labelBill, 0);
            this.Controls.SetChildIndex(this.textBoxBillPath, 0);
            this.Controls.SetChildIndex(this.buttonBrowseBill, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.buttonValidateMovement, 0);
            this.Controls.SetChildIndex(this.buttonCancel, 0);
            this.Controls.SetChildIndex(this.comboBoxMovement, 0);
            this.Controls.SetChildIndex(this.labelDescription, 0);
            this.Controls.SetChildIndex(this.textBoxDescription, 0);
            this.Controls.SetChildIndex(this.checkBoxNewMovement, 0);
            this.Controls.SetChildIndex(this.dateTimePickerStartDate, 0);
            this.Controls.SetChildIndex(this.dateTimePickerEndDate, 0);
            this.Controls.SetChildIndex(this.labelStartDate, 0);
            this.Controls.SetChildIndex(this.labelEndDate, 0);
            this.Controls.SetChildIndex(this.buttonTakePicture, 0);
            this.Controls.SetChildIndex(this.pictureBox, 0);
            this.Controls.SetChildIndex(this.checkBoxAllRegardingParticipants, 0);
            this.Controls.SetChildIndex(this.checkBoxIsPartial, 0);
            this.Controls.SetChildIndex(this.comboBoxWho, 0);
            this.Controls.SetChildIndex(this.comboBoxParticipantList, 0);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        
        private System.Windows.Forms.Label labelExpense;
        private System.Windows.Forms.TextBox textBoxMovementName;
        private System.Windows.Forms.Label labelAmount;
        private System.Windows.Forms.TextBox textBoxAmount;
        private System.Windows.Forms.Label labelUser;
        private System.Windows.Forms.Label labelDevise;
        private System.Windows.Forms.ComboBox comboBoxCurrency;
        private System.Windows.Forms.Label labelBill;
        private System.Windows.Forms.TextBox textBoxBillPath;
        private System.Windows.Forms.Button buttonBrowseBill;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonFood;
        private System.Windows.Forms.RadioButton radioButtonTransport;
        private System.Windows.Forms.RadioButton radioButtonActivities;
        private System.Windows.Forms.RadioButton radioButtonComodities;
        private System.Windows.Forms.Button buttonValidateMovement;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.ComboBox comboBoxMovement;
        private System.Windows.Forms.Label labelGOP;
        private System.Windows.Forms.RadioButton radioButtonOther;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.CheckBox checkBoxNewMovement;
        private System.Windows.Forms.RadioButton radioButtonAbonmnent;
        private System.Windows.Forms.RadioButton radioButtonLogement;
        private System.Windows.Forms.RadioButton radioButtonClothe;
        private System.Windows.Forms.RadioButton radioButtonLoan;
        private System.Windows.Forms.DateTimePicker dateTimePickerStartDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerEndDate;
        private System.Windows.Forms.Label labelStartDate;
        private System.Windows.Forms.Label labelEndDate;
        private System.Windows.Forms.Button buttonTakePicture;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.CheckBox checkBoxAllRegardingParticipants;
        private System.Windows.Forms.CheckBox checkBoxIsPartial;
        private CheckedComboBox comboBoxWho;
        private CheckedComboBox comboBoxParticipantList;
    }
}