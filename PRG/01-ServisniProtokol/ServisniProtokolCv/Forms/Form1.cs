using ServisniProtokolCv.Forms;
using ServisniProtokolCv.Models;
using ServisniProtokolCv.Services;
using System.ComponentModel;

namespace ServisniProtokolCv
{
    public partial class ProtocolForm : Form
    {
        Protocol protocol = new Protocol();
        BindingList<Measure> measures;
        public ProtocolForm()
        {
            InitializeComponent();
            this.measures = protocol.MeasureList;
            this.dataGridViewMeasure.DataSource = protocol.MeasureList;
        }

        private void editBasicInfoBtn_Click(object sender, EventArgs e)
        {
            BasicInfoForm form = new BasicInfoForm(protocol);
            if (form.ShowDialog() == DialogResult.OK)
            {
                this.protocol = form.protocol;

                this.protocolNumberValue.Text = protocol.ProtocolNumber;
                this.measureDateValue.Text = protocol.MeasureDate.ToShortDateString();
            }
        }

        private void editCustomerBtn_Click(object sender, EventArgs e)
        {
            CustomerForm form = new CustomerForm(protocol.Customer);
            if (form.ShowDialog() == DialogResult.OK)
            {
                this.protocol.Customer = form.customer;

                this.labelCustomerNameValue.Text = protocol.Customer.Name;
                this.labelAddressValue.Text = protocol.Customer.Address;
                this.labelPostalCodeValue.Text = protocol.Customer.PostalCode;
                this.labelIcValue.Text = protocol.Customer.ICO;
            }
        }

        private void buttonDeviceEdit_Click(object sender, EventArgs e)
        {
            DeviceForm form = new DeviceForm(protocol.Device);
            if (form.ShowDialog() == DialogResult.OK)
            {
                this.protocol.Device = form.device;

                this.labelManufacturer.Text = protocol.Device.Manufacturer;
                this.labelModel.Text = protocol.Device.Model;
                this.labelSerialNumber.Text = protocol.Device.SerialNumber;
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            MeasureForm form = new MeasureForm(new Measure());
            if (form.ShowDialog() == DialogResult.OK)
            {
                this.measures.Add(form.measure);
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (this.dataGridViewMeasure.CurrentRow != null)
            {
                Measure selectedMeasure = this.measures[this.dataGridViewMeasure.CurrentRow.Index];

                MeasureForm form = new MeasureForm(selectedMeasure);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    this.measures[this.dataGridViewMeasure.CurrentRow.Index] = form.measure;
                }
            }
            else
            {
                MessageBox.Show("Pro úpravu nejprve vyberte øádek");
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (this.dataGridViewMeasure.CurrentRow != null)
            {
                this.measures.Remove(this.measures[this.dataGridViewMeasure.CurrentRow.Index]);
            }
            else
            {
                MessageBox.Show("Pro smazání nejprve vyberte øádek");
            }

        }

        private void buttonExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Soubor HTML (*.html)|*.html|All files (*.*)|*.*";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                {
                    HTMLService html = new HTMLService(protocol);
                    writer.WriteLine(html.ExportHTML());
                }

                MessageBox.Show("Protokol exportován");
            }
        }

        private void buttonView_Click(object sender, EventArgs e)
        {
            PrintPreviewForm form = new PrintPreviewForm(protocol);

            form.ShowDialog();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Textový soubor (*.txt)|*.txt|All files (*.*)|*.*";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                JSONService service = new JSONService();

                service.Save(protocol, saveFileDialog.FileName);

                MessageBox.Show("Protokol uložen");
            }
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Textový soubor (*.txt)|*.txt|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    JSONService service = new JSONService();

                    this.protocol = service.Load(openFileDialog.FileName);

                    this.protocolNumberValue.Text = protocol.ProtocolNumber;
                    this.measureDateValue.Text = protocol.MeasureDate.ToShortDateString();
                    this.labelCustomerNameValue.Text = protocol.Customer.Name;
                    this.labelAddressValue.Text = protocol.Customer.Address;
                    this.labelPostalCodeValue.Text = protocol.Customer.PostalCode;
                    this.labelIcValue.Text = protocol.Customer.ICO;
                    this.labelManufacturer.Text = protocol.Device.Manufacturer;
                    this.labelModel.Text = protocol.Device.Model;
                    this.labelSerialNumber.Text = protocol.Device.SerialNumber;
                    this.measures = protocol.MeasureList;
                    this.dataGridViewMeasure.DataSource = null;
                    this.dataGridViewMeasure.DataSource = protocol.MeasureList;

                    MessageBox.Show("Protokol naèten");
                }
                catch (Exception)
                {
                    MessageBox.Show("Chyba");
                }

            }
        }
    }
}
