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
    public partial class MeasureForm : Form
    {
        public Measure measure { get; private set; }
        public MeasureForm(Measure measure)
        {
            InitializeComponent();
            this.measure = measure;

            this.textBoxParameter.Text = measure.Parameter;
            this.textBoxMeasuredValue.Text = this.measure.MeasuredValue.ToString();
            this.textBoxUnit.Text = this.measure.Unit;
            this.checkBoxIsOptimal.Checked = this.measure.IsOptimal;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                this.measure.Parameter = this.textBoxParameter.Text;
                this.measure.MeasuredValue = Double.Parse(this.textBoxMeasuredValue.Text);
                this.measure.Unit = this.textBoxUnit.Text;
                this.measure.IsOptimal = this.checkBoxIsOptimal.Checked;

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
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                e.Cancel = true;
                this.errorProvider1.SetError(textBox, "Pole je povinne");
            }
        }

        private void Validated(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            this.errorProvider1.SetError(textBox, null);
        }

        private void textBoxMeasuredValue_Validating(object sender, CancelEventArgs e)
        {
            if (!Double.TryParse(this.textBoxMeasuredValue.Text, out double value))
            {
                e.Cancel = true;
                this.errorProvider1.SetError(this.textBoxMeasuredValue, "Pole musí být číslo");
            }
        }
    }
}
