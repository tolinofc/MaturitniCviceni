using Graf.Forms;
using Graf.Models;
using Graf.Services;

namespace Graf
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "csv files (*.csv)|*.csv";
            ofd.InitialDirectory = "";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                GraphViewForm form = new GraphViewForm(ParseDataService.ParseData(ofd.FileName));
                form.ShowDialog();
            }
        }
    }
}
