using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tools4Libraries;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using System.IO;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace Droid.financial
{
    public partial class ViewBillPreview : UserControlCustom
    {
        #region Attributes
        public event UserControlCustomEventHandler OnCancel;
        public event UserControlCustomEventHandler OnSave;

        private Bill _bill;
        #endregion

        #region Properties
        public Bill Bill
        {
            get { return _bill; }
            set
            {
                _bill = value;
                RefreshData();
            }
        }
        #endregion

        #region Constructor
        public ViewBillPreview()
        {
            InitializeComponent();
        }
        #endregion

        #region Methods public
        public override void ChangeLanguage()
        {
            base.ChangeLanguage();
        }
        public override void RefreshData()
        {
            if (_bill != null)
            {
                int total = 0;
                panelColor.BackColor = _bill.Color;
                labelFactureNum.Text = _bill.Id.ToString().PadLeft(6, '0'); ;
                labelBank.Text = _bill.BankDetail;

                labelOwnerName.Text = _bill.Owner.ToString();
                labelOwnerAddress.Text = _bill.Owner.Address;
                labelOwnerCity.Text = _bill.Owner.City;
                labelOwnerId.Text = "Siret: " + _bill.Owner.Siret;
                
                labelClientName.Text = _bill.Client.ToString();
                labelClientAddress.Text = _bill.Client.Address;
                labelClientCity.Text = _bill.Client.City;
                labelClientId.Text = "Siret: " + _bill.Client.Siret;

                dataGridViewDetail.Rows.Clear();
                dataGridViewDetail.Rows.Add();
                dataGridViewDetail.Rows[0].Cells[ColumnBillDate.Index].Value = _bill.CreateDate.ToShortDateString();
                dataGridViewDetail.Rows[0].Cells[ColumnBillLimit.Index].Value = _bill.LimitDate.ToShortDateString();
                dataGridViewDetail.Rows[0].Cells[ColumnRuleCondition.Index].Value = "A payer dans une délais de 45 jours";

                dataGridViewProduct.Rows.Clear();
                dataGridViewProduct.Columns[ColumnDescription.Index].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                foreach (var item in _bill.Products)
                {
                    dataGridViewProduct.Rows.Add();
                    dataGridViewProduct.Rows[dataGridViewProduct.Rows.Count - 1].Tag = item;
                    dataGridViewProduct.Rows[dataGridViewProduct.Rows.Count - 1].Cells[ColumnId.Index].Value = "#" + item.Id;
                    dataGridViewProduct.Rows[dataGridViewProduct.Rows.Count - 1].Cells[ColumnDescription.Index].Value = item.Name + Environment.NewLine + item.Description;
                    dataGridViewProduct.Rows[dataGridViewProduct.Rows.Count - 1].Cells[ColumnPrice.Index].Value = item.Cost + " €";
                    dataGridViewProduct.Rows[dataGridViewProduct.Rows.Count - 1].Cells[ColumnQuantity.Index].Value = item.Quantity + " Jours";
                    dataGridViewProduct.Rows[dataGridViewProduct.Rows.Count - 1].Cells[ColumnSubTotal.Index].Value = item.Cost * item.Quantity + " €";
                    dataGridViewProduct.Rows[dataGridViewProduct.Rows.Count - 1].Height += 30;
                    total += item.Cost * item.Quantity;
                }
                labelSubTotal.Text = total + " €";
                labelTotal.Text = total + " €";
            }
        }
        #endregion

        #region Methods private
        private void Print()
        {
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.FileName = "Facture-" + _bill.Id;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Bitmap panelImage = new Bitmap(panelSheet.Width, panelSheet.Height);
                panelImage.SetResolution(900, 1261);

                Graphics g = Graphics.FromImage((System.Drawing.Image)panelImage);
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;

                panelSheet.DrawToBitmap(panelImage, panelSheet.ClientRectangle);

                g.DrawImage(panelImage, 0, 0, panelSheet.Width, panelSheet.Height);
                g.Dispose();
                panelImage.SetResolution(900, 1261);
                panelImage.Save(sfd.FileName + ".png", ImageFormat.Png);

                Droid.Image.Interface_image.ACTION_140_convert(sfd.FileName + ".png");
                try
                {
                    if (File.Exists(sfd.FileName + ".png")) { File.Delete(sfd.FileName + ".png"); }
                }
                catch (Exception exp)
                {
                    Console.WriteLine(exp.Message);
                }
            }
        }
        #endregion

        #region Event
        private void buttonPrint_Click(object sender, EventArgs e)
        {
            Print();
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            OnCancel?.Invoke(null);
        }
        #endregion
    }
}
