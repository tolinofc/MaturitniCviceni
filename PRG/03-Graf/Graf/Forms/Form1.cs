using Graf.Forms;
using Graf.Models;

namespace Graf
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // TODO
            GraphViewForm form = new GraphViewForm(ParseData(@"C:\Users\Tolin\Desktop\Cviceni_k_maturite\PRG\03-Graf\assignment\TSLA.csv"));
            form.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "csv files (*.csv)|*.csv";
            ofd.InitialDirectory = "";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                GraphViewForm form = new GraphViewForm(ParseData(ofd.FileName));
                form.ShowDialog();
            }
        }

        private List<GraphValue> ParseData(string path)
        {
            List<GraphValue> values = new List<GraphValue>();
            using (StreamReader reader = new StreamReader(path))
            {
                reader.ReadLine(); // first line
                while(!reader.EndOfStream)
                {
                    string[] line = reader.ReadLine().Split(',');
                    GraphValue value = new GraphValue()
                    {
                        Date = DateOnly.Parse(line[0]),
                        Open = float.Parse(line[1].Replace(".",",")),
                        Volume = long.Parse(line[6].Replace(".", ","))
                    };
                    values.Add(value);
                }
            }

            for (int i = 1; i < values.Count; i++)
            {
                values[i].isOpenNegative = values[i - 1].Open > values[i].Open;
            }

            return values;
        }
    }
}
