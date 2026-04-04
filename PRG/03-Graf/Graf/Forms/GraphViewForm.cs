using Graf.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graf.Forms
{
    public partial class GraphViewForm : Form
    {
        private List<GraphValue> data = new List<GraphValue>();

        bool isDragging = false;
        private int startMouseX;
        private float dateWidth;

        private int visibleDaysCount = 250;
        public GraphViewForm(List<GraphValue> data)
        {
            InitializeComponent();
            this.data = data;

            hScrollBarPan.Minimum = 0;
            hScrollBarPan.Maximum = data.Count - visibleDaysCount;

            hScrollBarPan.Value = data.Count - visibleDaysCount;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            int start = hScrollBarPan.Value;
            List<GraphValue> visibleData = data.Skip(start).Take(visibleDaysCount).ToList();

            float maxOpen = visibleData.Max(v => v.Open);
            float minOpen = visibleData.Min(v => v.Open);
            long maxVolume = visibleData.Max(v => v.Volume);
            dateWidth = pictureBox1.Width / visibleDaysCount;

            float marginBottom = 40;
            float marginTop = 20;
            float marginRight = 60;

            float graphWidth = pictureBox1.Width - marginRight;
            float graphHeight = pictureBox1.Height - marginBottom - marginTop;

            #region Axis

            Font labelFont = new Font("Arial", 10);

            #region YAxis

            int stepsY = 5;

            for (int i = 0; i < stepsY; i++)
            {
                float height = (float)i / (stepsY - 1);
                float y = height * graphHeight + marginTop;

                float value = maxOpen - (height * (maxOpen - minOpen));

                g.DrawLine(Pens.LightGray, 0, y, graphWidth, y);

                g.DrawString(value.ToString(), labelFont, Brushes.Black, graphWidth + 5, y - 6);
            }

            #endregion

            #region XAxis

            int stepsX = visibleDaysCount / 5;

            for (int i = 0; i < visibleData.Count; i++)
            {
                if (i % stepsX == 0)
                {
                    float x = i * dateWidth;

                    string dateText = visibleData[i].Date.ToString();
                    g.DrawString(dateText, labelFont, Brushes.Black, x, graphHeight + 30);
                }
            }

            #endregion

            #endregion

            #region BarChart

            float maxBarHeight = 100f;

            for (int i = 0; i < visibleData.Count; i++)
            {
                float volumePercent = (float)visibleData[i].Volume / maxVolume;
                float barHeight = (float)volumePercent * maxBarHeight;

                float x = i * dateWidth;
                float y = marginTop + graphHeight - barHeight;

                RectangleF bar = new RectangleF(x, y, dateWidth, barHeight);

                if (visibleData[i].isOpenNegative)
                {
                    g.FillRectangle(Brushes.Red, bar);
                }
                else
                {
                    g.FillRectangle(Brushes.Green, bar);
                }
            }

            #endregion

            #region LineGraph

            PointF[] linePoints = new PointF[visibleData.Count];

            float rangeOpen = maxOpen - minOpen;

            for (int i = 0; i < visibleData.Count; i++)
            {
                float openPercent = (float)((visibleData[i].Open - minOpen) / rangeOpen);

                float x = (i * dateWidth) + (dateWidth / 2f);
                float y = (marginTop + graphHeight) - (openPercent * graphHeight);

                linePoints[i] = new PointF(x, y);
            }

            g.DrawLines(Pens.Blue, linePoints);

            #endregion
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                startMouseX = e.X;
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                int deltaX = startMouseX - e.X;
                int newValue = hScrollBarPan.Value + deltaX;

                if (newValue < hScrollBarPan.Minimum)
                {
                    newValue = hScrollBarPan.Minimum;
                }

                if (newValue > hScrollBarPan.Maximum)
                {
                    newValue = hScrollBarPan.Maximum;
                }

                hScrollBarPan.Value = newValue;
                startMouseX = e.X;

                this.pictureBox1.Invalidate();
            }
        }

        private void pictureBox1_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta < 0)
            {
                visibleDaysCount += 10;
            }
            else
            {
                visibleDaysCount -= 10;
            }

            if (visibleDaysCount < 10)
            {
                visibleDaysCount = 10;
            }

            if (visibleDaysCount > 250)
            {
                visibleDaysCount = 250;
            }

            hScrollBarPan.Maximum = data.Count - visibleDaysCount;
            this.pictureBox1.Invalidate();
        }
    }
}
