using System;
using System.Drawing;
using System.Windows.Forms;
//using Touchless.Vision.Camera;

namespace Droid.financial
{
    public partial class CamGUI : Form
    {
        #region Attribute
        //private CameraFrameSource _frameSource;
        private static Bitmap _latestFrame;
        private bool _cameraStopped = false;
        private string _picturePath;
        #endregion

        #region Properties
        public string PicturePath
        {
            get { return _picturePath; }
        }
        #endregion

        #region Constructor
        public CamGUI()
        {
            InitializeComponent();  
        }
        #endregion

        #region Methods public
        //public void OnImageCaptured(Touchless.Vision.Contracts.IFrameSource frameSource, Touchless.Vision.Contracts.Frame frame, double fps)
        //{
        //    _latestFrame = frame.Image;
        //    pictureBoxDisplay.Invalidate();
        //}
        #endregion

        #region Methods private
        private void startCapturing()
        {
            try
            {
                //Camera c = (Camera)comboBoxCameras.SelectedItem;
                //setFrameSource(new CameraFrameSource(c));
                //_frameSource.Camera.CaptureWidth = this.pictureBoxDisplay.Width;
                //_frameSource.Camera.CaptureHeight = this.pictureBoxDisplay.Height;
                //_frameSource.Camera.Fps = 20;
                //_frameSource.NewFrame += OnImageCaptured;

                //pictureBoxDisplay.Paint += new PaintEventHandler(drawLatestImage);
                //_frameSource.StartFrameCapture();
            }
            catch (Exception ex)
            {
                comboBoxCameras.Text = "Select A Camera";
                MessageBox.Show(ex.Message);
            }
        }
        private void drawLatestImage(object sender, PaintEventArgs e)
        {
            if (_latestFrame != null)
            {
                // Draw the latest image from the active camera
                e.Graphics.DrawImage(_latestFrame, 0, 0, _latestFrame.Width, _latestFrame.Height);
            }
        }
        //private void setFrameSource(CameraFrameSource cameraFrameSource)
        //{
        //    if (_frameSource == cameraFrameSource)
        //        return;

        //    _frameSource = cameraFrameSource;
        //}
        //private void thrashOldCamera()
        //{
        //    // Trash the old camera
        //    if (_frameSource != null)
        //    {
        //        _frameSource.NewFrame -= OnImageCaptured;
        //        _frameSource.Camera.Dispose();
        //        setFrameSource(null);
        //        pictureBoxDisplay.Paint -= new PaintEventHandler(drawLatestImage);
        //    }
        //}
        private void ProcessCamera()
        {
            if (_cameraStopped)
            {
                _cameraStopped = !_cameraStopped;
                StopCam();
            }
            else
            {
                _cameraStopped = !_cameraStopped;
                StartCam();
            }
        }
        private void StartCam()
        {
            //buttonStopStart.Text = "Stop camera";
            //// Early return if we've selected the current camera
            //if (_frameSource != null && _frameSource.Camera == comboBoxCameras.SelectedItem) return;
            //thrashOldCamera();
            //startCapturing();
        }
        private void StopCam()
        {
            //buttonStopStart.Text = "Launch camera";
            //thrashOldCamera();
        }
        private void CameraChanged()
        {
            if (_cameraStopped)
            {
                StopCam();
                StartCam();
            }
        }
        private void SavePicture()
        {
            //if (_frameSource == null) return;
            Bitmap current = (Bitmap)_latestFrame.Clone();
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "*.bmp|*.bmp";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    current.Save(sfd.FileName);
                    _picturePath = sfd.FileName;
                }
            }
            current.Dispose();

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }
        #endregion

        #region Event
        private void btnSave_Click(object sender, EventArgs e)
        {
            SavePicture();
        }
        private void btnConfig_Click(object sender, EventArgs e)
        {
            //// snap camera
            //if (_frameSource != null)
            //    _frameSource.Camera.ShowPropertiesDialog();
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                // Refresh the list of available cameras
                comboBoxCameras.Items.Clear();
                //foreach (Camera cam in CameraService.AvailableCameras)
                //    comboBoxCameras.Items.Add(cam);

                if (comboBoxCameras.Items.Count > 0)
                    comboBoxCameras.SelectedIndex = 0;
            }
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //thrashOldCamera();
        }
        private void buttonStopStart_Click(object sender, EventArgs e)
        {
            ProcessCamera();
        }
        private void comboBoxCameras_SelectedIndexChanged(object sender, EventArgs e)
        {
            CameraChanged();
        }
        #endregion
    }
}
