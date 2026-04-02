using ServisniProtokolCv.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServisniProtokolCv.Forms
{
    public partial class CustomerForm : Form
    {
        public Customer customer { get; private set; }
        public CustomerForm(Customer customer)
        {
            InitializeComponent();
            this.customer = customer;

            this.textBoxName.Text = customer.Name;
            this.textBoxAddress.Text = customer.Address;
            this.textBoxPostalCode.Text = customer.PostalCode;
            this.textBoxIC.Text = customer.ICO;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                this.customer.Name = textBoxName.Text;
                this.customer.Address = textBoxAddress.Text;
                this.customer.PostalCode = textBoxPostalCode.Text;
                this.customer.ICO = textBoxIC.Text;
                this.DialogResult = DialogResult.OK;
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
                this.errorProvider1.SetError(textBox, "Pole je povinné");
            }
        }

        public void Validated(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            this.errorProvider1.SetError(textBox, null);
        }

        private void textBoxPostalCode_Validating(object sender, CancelEventArgs e)
        {
            if (!Regex.IsMatch(textBoxPostalCode.Text, @"^[0-9]{3}\s[0-9]{2}$"))
            {
                e.Cancel = true;
                this.errorProvider1.SetError(textBoxPostalCode, "Zadejte PSČ ve tvaru: 123 45");
            }
        }

        private void textBoxIC_Validating(object sender, CancelEventArgs e)
        {
            if (!Regex.IsMatch(textBoxIC.Text, @"^[0-9]{6}$"))
            {
                e.Cancel = true;
                this.errorProvider1.SetError(textBoxIC, "Zadejte IČO ve tvaru: 123456");
            }
        }
    }
}
