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
    public partial class BasicInfoForm : Form
    {
        public Protocol protocol { get; private set; }
        public BasicInfoForm(Protocol protocol)
        {
            InitializeComponent();
            this.protocol = protocol;

            this.textBoxProtocolNumber.Text = protocol.ProtocolNumber;
            this.dateTimePickerMeasureDate.Value = protocol.MeasureDate;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                this.protocol.ProtocolNumber = textBoxProtocolNumber.Text;
                this.protocol.MeasureDate = dateTimePickerMeasureDate.Value;
                this.DialogResult = DialogResult.OK;
            }

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void textBoxProtocolNumber_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.textBoxProtocolNumber.Text))
            {
                e.Cancel = true;
                this.errorProvider1.SetError(this.textBoxProtocolNumber, "Pole je povinné");
            }
        }

        public void Validated(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            this.errorProvider1.SetError(textBox, null);
        }
    }
}
