using Tools4Libraries;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Droid_financial
{
    public class UserPanel : Panel
    {
        #region Attribute
        private System.Windows.Forms.Panel previewPanel;
        private System.Windows.Forms.PictureBox pictureBoxUser;
        private System.Windows.Forms.TextBox textBoxTitle;
        private System.Windows.Forms.Label labelNom;
        private System.Windows.Forms.Label labelPrenom;
        private System.Windows.Forms.Label labelSolde;
        private System.Windows.Forms.PictureBox pictureBoxSolde;
        private System.Windows.Forms.DataGridView dataGridViewMovement;
        private System.Windows.Forms.Button buttonExpand;
        
        private GUI _gui;
        private User _user;
        #endregion

        #region Properties
        #endregion

        #region Constructor
        public UserPanel(User user, GUI gui)
        {
            _user = user;
            _gui = gui;
            Initialization();
        }
        #endregion

        #region Methods public
        public void UpdateUser()
        {
            textBoxTitle.Text = _user.Name + " " + _user.Firstname;
            textBoxTitle.BackColor = _user.Color;
            labelNom.Text = _user.Name;
            labelPrenom.Text = _user.Firstname;
            pictureBoxUser.Image = _gui.imageListAvatars32.Images[_user.AvatarIndex < _gui.imageListAvatars32.Images.Count - 1 ? _user.AvatarIndex : 0];

            if (_user.Solde > 0) pictureBoxSolde.Image = Tools4Libraries.Resources.ResourceIconSet16Default.tick;
            else if (_user.Solde < 0) pictureBoxSolde.Image = Tools4Libraries.Resources.ResourceIconSet16Default.exclamation;
            else pictureBoxSolde.Image = Tools4Libraries.Resources.ResourceIconSet16Default.error;
            
            labelSolde.Text = _user.Solde.ToString();
        }
        #endregion

        #region Methods private
        private void Initialization()
        {
            Declare();
            Parameter();
            if (_user != null) UpdateUser();
        }
        private void Declare()
        {
            this.previewPanel = new Panel();
            this.buttonExpand = new System.Windows.Forms.Button();
            this.dataGridViewMovement = new System.Windows.Forms.DataGridView();
            this.pictureBoxSolde = new System.Windows.Forms.PictureBox();
            this.labelSolde = new System.Windows.Forms.Label();
            this.labelNom = new System.Windows.Forms.Label();
            this.labelPrenom = new System.Windows.Forms.Label();
            this.textBoxTitle = new System.Windows.Forms.TextBox();
            this.pictureBoxUser = new System.Windows.Forms.PictureBox();
        }
        private void Parameter()
        {
            // 
            // panelMember
            // 
            //this.StartPosition = FormStartPosition.Manual;
            //this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            //this.Opacity = 0.8;
            //this.ShowInTaskbar = false;
            
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.previewPanel);
            this.Location = new System.Drawing.Point(28, 22);
            this.Name = "panelMember";
            this.Size = new System.Drawing.Size(189, 108);
            this.TabIndex = 0;
            //
            // preview panel
            //
            this.previewPanel.BackColor = Color.Transparent;
            this.previewPanel.Dock = DockStyle.Fill;
            this.previewPanel.Controls.Add(this.buttonExpand);
            this.previewPanel.Controls.Add(this.dataGridViewMovement);
            this.previewPanel.Controls.Add(this.pictureBoxSolde);
            this.previewPanel.Controls.Add(this.labelSolde);
            this.previewPanel.Controls.Add(this.labelNom);
            this.previewPanel.Controls.Add(this.labelPrenom);
            this.previewPanel.Controls.Add(this.textBoxTitle);
            this.previewPanel.Controls.Add(this.pictureBoxUser);
            // 
            // buttonExpand
            // 
            this.buttonExpand.FlatAppearance.BorderSize = 0;
            this.buttonExpand.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExpand.Location = new System.Drawing.Point(164, 83);
            this.buttonExpand.Name = "buttonExpand";
            this.buttonExpand.Size = new System.Drawing.Size(16, 16);
            this.buttonExpand.TabIndex = 7;
            this.buttonExpand.UseVisualStyleBackColor = true;
            this.buttonExpand.BackgroundImage = _gui.imageListUserPanel.Images[_gui.imageListUserPanel.Images.IndexOfKey("expand")];
            this.buttonExpand.BackgroundImageLayout = ImageLayout.None;
            this.buttonExpand.Click += buttonExpand_Click;
            // 
            // dataGridView1
            // 
            this.dataGridViewMovement.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewMovement.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMovement.Location = new System.Drawing.Point(0, 106);
            this.dataGridViewMovement.Name = "dataGridView1";
            this.dataGridViewMovement.Size = new System.Drawing.Size(189, 177);
            this.dataGridViewMovement.TabIndex = 6;
            // 
            // pictureBoxSolde
            // 
            this.pictureBoxSolde.Location = new System.Drawing.Point(16, 84);
            this.pictureBoxSolde.Name = "pictureBoxSolde";
            this.pictureBoxSolde.Size = new System.Drawing.Size(16, 16);
            this.pictureBoxSolde.TabIndex = 5;
            this.pictureBoxSolde.TabStop = false;
            // 
            // labelSolde
            // 
            this.labelSolde.AutoSize = true;
            this.labelSolde.BackColor = System.Drawing.Color.Transparent;
            this.labelSolde.ForeColor = System.Drawing.Color.White;
            this.labelSolde.Location = new System.Drawing.Point(38, 85);
            this.labelSolde.Name = "labelSolde";
            this.labelSolde.Size = new System.Drawing.Size(88, 13);
            this.labelSolde.TabIndex = 4;
            this.labelSolde.Text = "Solde : + 17,25 €";
            // 
            // labelNom
            // 
            this.labelNom.AutoSize = true;
            this.labelNom.BackColor = System.Drawing.Color.Transparent;
            this.labelNom.ForeColor = System.Drawing.Color.White;
            this.labelNom.Location = new System.Drawing.Point(71, 59);
            this.labelNom.Name = "labelNom";
            this.labelNom.Size = new System.Drawing.Size(29, 13);
            this.labelNom.TabIndex = 3;
            this.labelNom.Text = "Nom";
            // 
            // labelPrenom
            // 
            this.labelPrenom.AutoSize = true;
            this.labelPrenom.BackColor = System.Drawing.Color.Transparent;
            this.labelPrenom.ForeColor = System.Drawing.Color.White;
            this.labelPrenom.Location = new System.Drawing.Point(71, 40);
            this.labelPrenom.Name = "labelPrenom";
            this.labelPrenom.Size = new System.Drawing.Size(43, 13);
            this.labelPrenom.TabIndex = 2;
            this.labelPrenom.Text = "Prenom";
            // 
            // textBox1
            // 
            this.textBoxTitle.BackColor = System.Drawing.Color.Maroon;
            this.textBoxTitle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBoxTitle.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTitle.ForeColor = System.Drawing.Color.White;
            this.textBoxTitle.Location = new System.Drawing.Point(0, 0);
            this.textBoxTitle.Margin = new System.Windows.Forms.Padding(5);
            this.textBoxTitle.Name = "textBox1";
            this.textBoxTitle.ReadOnly = true;
            this.textBoxTitle.Size = new System.Drawing.Size(189, 20);
            this.textBoxTitle.TabIndex = 1;
            this.textBoxTitle.Text = "   Prenom nom";
            // 
            // pictureBoxUser
            // 
            this.pictureBoxUser.Location = new System.Drawing.Point(16, 40);
            this.pictureBoxUser.Name = "pictureBoxUser";
            this.pictureBoxUser.Size = new System.Drawing.Size(32, 32);
            this.pictureBoxUser.TabIndex = 0;
            this.pictureBoxUser.TabStop = false;
            //
            // This panel
            //
            this.BackgroundImage = _gui.imageListUserPanel.Images[_gui.imageListUserPanel.Images.IndexOfKey("pixelGrayAlpha")];
            this.BackgroundImageLayout = ImageLayout.None;
        }
        #endregion

        #region Event
        private void buttonExpand_Click(object sender, EventArgs e)
        {
            if (this.Size == new System.Drawing.Size(189, 108))
            {
                this.Size = new System.Drawing.Size(189, 240);
                this.buttonExpand.BackgroundImage = _gui.imageListUserPanel.Images[_gui.imageListUserPanel.Images.IndexOfKey("reduce")];
            }
            else
            {
                this.Size = new System.Drawing.Size(189, 108);
                this.buttonExpand.BackgroundImage = _gui.imageListUserPanel.Images[_gui.imageListUserPanel.Images.IndexOfKey("expand")];
            }
        }
        #endregion
    }
}
