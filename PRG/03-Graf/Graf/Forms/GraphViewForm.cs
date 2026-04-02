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

        //private DateOnly maxXAxis;
        //private DateOnly minXAxis;
        //private double maxYAxis;
        //private double minYAxis;

        bool isDragging = false;
        private int startMouseX;
        private int startScollValue;
        private float dateWidth;

        private int visibleDaysCount = 50;
        public GraphViewForm(List<GraphValue> values)
        {
            InitializeComponent();
            this.data = values;

            hScrollBar1.Minimum = 0;
            hScrollBar1.Maximum = values.Count - visibleDaysCount;

            //CalculateAxis();
        }

        //private void CalculateAxis()
        //{
        //    maxYAxis = data.Max(v => v.Open);
        //    minYAxis = data.Min(v => v.Open);

        //    maxXAxis = data.Max(v => v.Date);
        //    minXAxis = data.Min(v => v.Date);
        //}

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            int start = hScrollBar1.Value;
            List<GraphValue> visibleData = data.Skip(start).Take(visibleDaysCount).ToList();

            double maxOpen = visibleData.Max(v => v.Open);
            double minOpen = visibleData.Min(v => v.Open);
            long maxVolume = visibleData.Max(v => v.Volume);
            dateWidth = pictureBox1.Width / visibleDaysCount;

            Font labelFont = new Font("Arial", 10);

            #region Axis


            #region YAxis

            float marginBottom = 40;
            float marginTop = 20;
            float marginRight = 60;

            float graphWidth = pictureBox1.Width - marginRight;
            float graphHeight = pictureBox1.Height - marginBottom - marginTop;

            int stepsY = 5;

            for (int i = 0; i < stepsY; i++)
            {
                float height = (float)i / (stepsY - 1);
                float y = height * graphHeight + marginTop;

                double value = maxOpen - (height * (maxOpen - minOpen));

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
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                startMouseX = e.X;
                startScollValue = hScrollBar1.Value;
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
                int newValue = hScrollBar1.Value + deltaX;

                if (newValue < hScrollBar1.Minimum)
                {
                    newValue = hScrollBar1.Minimum;
                }

                if (newValue > hScrollBar1.Maximum)
                {
                    newValue = hScrollBar1.Maximum;
                }

                hScrollBar1.Value = newValue;
                startMouseX = e.X;

                pictureBox1.Invalidate();
            }
        }
    }
}
