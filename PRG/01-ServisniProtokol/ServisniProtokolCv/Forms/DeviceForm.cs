using ServisniProtokolCv.Models;
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
    public partial class DeviceForm : Form
    {
        public Device device { get; private set; }
        public DeviceForm(Device device)
        {
            InitializeComponent();
            this.device = device;

            this.textBoxManufacturer.Text = device.Manufacturer;
            this.textBoxModel.Text = device.Model;
            this.textBoxSerialNumber.Text = device.SerialNumber;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                this.device.Manufacturer = this.textBoxManufacturer.Text;
                this.device.Model = this.textBoxModel.Text;
                this.device.SerialNumber = this.textBoxSerialNumber.Text;

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void textBox_Validating(object sender, CancelEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if (String.IsNullOrWhiteSpace(textBox.Text))
            {
                e.Cancel = true;
                this.errorProvider1.SetError(textBox, "Pole je povinné.");
            }
        }

        public void Validated(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            this.errorProvider1.SetError(textBox, null);
        }
    }
}
