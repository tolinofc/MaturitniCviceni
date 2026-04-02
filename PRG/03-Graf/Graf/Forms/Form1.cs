using Graf.Forms;
using Graf.Models;

namespace Graf
{
    public partial class Form1 : Form
    {
        private List<GraphValue> values = new List<GraphValue>();
        public Form1()
        {
            InitializeComponent();

            // TODO
            ParseData(@"C:\Users\Tolin\Desktop\Cviceni_k_maturite\PRG\03-Graf\assignment\TSLA.csv");
            GraphViewForm form = new GraphViewForm(values);
            form.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "csv files (*.csv)|*.csv";
            ofd.InitialDirectory = "";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                ParseData(ofd.FileName);
                GraphViewForm form = new GraphViewForm(values);
                form.ShowDialog();
            }
        }

        private void ParseData(string path)
        {
            using (StreamReader reader = new StreamReader(path))
            {
                reader.ReadLine(); // first line
                while(!reader.EndOfStream)
                {
                    string[] line = reader.ReadLine().Split(',');
                    GraphValue value = new GraphValue()
                    {
                        Date = DateOnly.Parse(line[0]),
                        Open = Double.Parse(line[1].Replace(".",",")),
                        Volume = long.Parse(line[6].Replace(".", ","))
                    };
                    values.Add(value);
                }
            }
        }
    }
}
