using ServisniProtokolCv.Models;
using ServisniProtokolCv.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServisniProtokolCv.Forms
{
    public partial class PrintPreviewForm : Form
    {
        private PrintPreviewService service;
        public PrintPreviewForm(Protocol protocol)
        {
            InitializeComponent();
            this.service = new PrintPreviewService(protocol);
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            this.service.Draw(e.Graphics, pictureBox1.Width,pictureBox1.Height);
        }

        private void pictureBox1_Resize(object sender, EventArgs e)
        {
            this.pictureBox1.Invalidate();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
