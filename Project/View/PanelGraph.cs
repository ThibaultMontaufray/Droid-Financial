using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.Serialization;
using System.Windows.Forms;

namespace Droid_financial
{
    // TOTRAIN : add the correct start color 

    public class PanelGraph : Panel
    {
        #region Enum
        public enum GRAPHMODE
        {
            NONE = 0,
            BAR = 1,
            PIE = 2
        }
        #endregion

        #region Structure
        public struct VAL
        {
            public float Val;
            public string Name;
        };
        #endregion

        #region Attribute
        private GRAPHMODE _graphMode;
        private List<VAL> _lstValues;
        private int _colR;
        private int _colG;
        private int _colB;
        private float _sum;
        #endregion

        #region Properties
        public List<VAL> ListValues
        {
            get { return _lstValues; }
            set { _lstValues = value; }
        }
        public GRAPHMODE GraphMode
        {
            get { return _graphMode; }
            set 
            {
                _graphMode = value;
                Invalidate();
            }
        }
        #endregion

        #region Constructor
        public PanelGraph()
        {
            this.BackColor = Color.Transparent;
            this.Paint += PanelGraph_Paint;
            _lstValues = new List<VAL>();
            _graphMode = GRAPHMODE.PIE;
            LoadTest();
        }
        #endregion

        #region Methods public
        public void SetValues(List<string> lstStr, List<float> lstVal, float sum)
        {
            _sum = sum;
            if (lstStr.Count == lstVal.Count)
            {
                VAL v;
                _lstValues.Clear();
                for (int i = 0; i < lstStr.Count; i++)
			    {
                    v = new VAL() { Name = lstStr[i], Val = lstVal[i] / sum };
                    _lstValues.Add(v);
			    }
                Invalidate();
            }
        }
        #endregion

        #region Methods private
        private void LoadTest()
        {
            _lstValues.Add(new VAL() { Val = 6, Name = "val1" });
            _lstValues.Add(new VAL() { Val = 4, Name = "val2" });
            _lstValues.Add(new VAL() { Val = 8, Name = "val3" });
            _lstValues.Add(new VAL() { Val = 12, Name = "val4" });
        }
        private Color GetNextColorToWhite()
        {
            Color retCol = Color.FromArgb(255, _colR, _colG, _colB);
            if (_colR < 255)
            {
                _colR = _colR + 64 > 160 ? 255 : _colR + 64;
            }
            else if (_colG < 255)
            {
                _colG = _colG + 64 > 160 ? 255 : _colG + 64;
            }
            else
            {
                _colB = _colB + 64 > 160 ? 255 : _colB + 64;
            }
            return retCol;
        }
        private Color GetNextColorToBlack()
        {
            Color retCol = Color.FromArgb(255, _colR, _colG, _colB);
            if (_colB > 0)
            {
                _colB = _colB - 96 > 0 ? _colB - 96 : 0;
            }
            else if (_colG > 0)
            {
                _colG = _colG - 96 > 0 ? _colG - 96 : 0;
            }
            else
            {
                _colR = _colR - 32 > 0 ? _colR - 32 : 0;
            }
            return retCol;
        }
        #endregion

        #region Event
        private void PanelGraph_Paint(object sender, PaintEventArgs e)
        {
            _colR = 63;
            _colG = 0;
            _colB = 0;
            Color col;
            Rectangle rc;
            Point pStart = this.AutoScrollPosition;
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            int xStr;
            int yStr;
            string graphText;
            switch (_graphMode)
            {
                case GRAPHMODE.BAR:
                    xStr = 20;
                    yStr = 20;
                    int X = pStart.X + 250, Y = pStart.Y + 5;
                    foreach (VAL v in _lstValues)
                    {
                        col = GetNextColorToWhite();
                        int H = (int)(v.Val * 400);
                        rc = new Rectangle(xStr + 140, yStr, H, 10);
                        e.Graphics.FillRectangle(new SolidBrush(col), rc);
                        graphText = v.Name;
                        //s = v.Name + " (" + String.Format("{0:0.0%}", v.Val) + ")";
                        e.Graphics.DrawString(graphText, new Font("Calibri", 9, FontStyle.Bold), new SolidBrush(col), xStr, yStr);
                        graphText = String.Format("{0:0.0%}", v.Val);
                        e.Graphics.DrawString(graphText, new Font("Calibri", 9, FontStyle.Bold), new SolidBrush(col), xStr + 160 + H, yStr);
                        X += 35;
                        yStr += 22;
                    }
                    break;
                case GRAPHMODE.PIE:
                    xStr = 280;
                    yStr = 20;
                    int AngleStart = 0, Angle;
                    rc = new Rectangle(pStart.X + 40, pStart.Y + 40, 200, 200);
                    foreach (VAL v in _lstValues)
                    {
                        col = GetNextColorToWhite();
                        Angle = (int)(360 * v.Val * 1.1);
                        e.Graphics.FillPie(new SolidBrush(col), rc, AngleStart, Angle);
                        //int xStr = pStart.X + 40 + 210 / 2 + (int)(180 * Math.Cos(2 * 3.14 * (AngleStart + Angle / 2) / 360));
                        //int yStr = pStart.Y + 40 + 210 / 2 + (int)(180 * Math.Sin(2 * 3.14 * (AngleStart + Angle / 2) / 360));
                        yStr += 30;
                        graphText = String.Format("{0:0.0%}", v.Val) + " (" + v.Name + ")";
                        e.Graphics.DrawString(graphText, new Font("Calibri", 9, FontStyle.Bold), new SolidBrush(col), xStr, yStr);
                        AngleStart += Angle;
                    }
                    break;
            }
        }
        #endregion
    }
}
