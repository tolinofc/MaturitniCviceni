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

            float dateWidth = pictureBox1.Width / visibleDaysCount;

            for (int i = 0; i < visibleData.Count; i++)
            {

            }

            Font labelFont = new Font("Arial", 10);

            #region YAxis
            int YAxisDefaultHeight = 20;
            double YAxisRange = maxOpen - minOpen;

            g.DrawString(maxOpen.ToString(), labelFont, Brushes.Black, Width - 70, 20);
            YAxisDefaultHeight += 80;
            for (int i = 1; i <= 4; i++)
            {
                string YAxisNumber = (minOpen + ((i / 4) * YAxisRange)).ToString();
                g.DrawString(maxOpen.ToString(), labelFont, Brushes.Black, Width - 70, YAxisDefaultHeight);
                YAxisDefaultHeight += 80;
            }
            g.DrawString(minOpen.ToString(), labelFont, Brushes.Black, Width - 70, 360);

            #endregion
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            this.pictureBox1.Invalidate();
        }
    }
}
