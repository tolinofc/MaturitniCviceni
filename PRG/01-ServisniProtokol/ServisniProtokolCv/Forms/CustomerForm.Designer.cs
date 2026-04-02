namespace ServisniProtokolCv.Forms
{
    partial class CustomerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            label1 = new Label();
            textBoxName = new TextBox();
            label2 = new Label();
            textBoxAddress = new TextBox();
            label3 = new Label();
            textBoxPostalCode = new TextBox();
            label4 = new Label();
            textBoxIC = new TextBox();
            buttonOK = new Button();
            buttonCancel = new Button();
            errorProvider1 = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 18);
            label1.Name = "label1";
            label1.Size = new Size(42, 15);
            label1.TabIndex = 0;
            label1.Text = "Název:";
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(72, 15);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(285, 23);
            textBoxName.TabIndex = 0;
            textBoxName.Validating += textBox_Validating;
            textBoxName.Validated += Validated;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 47);
            label2.Name = "label2";
            label2.Size = new Size(46, 15);
            label2.TabIndex = 0;
            label2.Text = "Adresa:";
            // 
            // textBoxAddress
            // 
            textBoxAddress.Location = new Point(72, 44);
            textBoxAddress.Name = "textBoxAddress";
            textBoxAddress.Size = new Size(285, 23);
            textBoxAddress.TabIndex = 1;
            textBoxAddress.Validating += textBox_Validating;
            textBoxAddress.Validated += Validated;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 76);
            label3.Name = "label3";
            label3.Size = new Size(31, 15);
            label3.TabIndex = 0;
            label3.Text = "PSČ:";
            // 
            // textBoxPostalCode
            // 
            textBoxPostalCode.Location = new Point(72, 73);
            textBoxPostalCode.Name = "textBoxPostalCode";
            textBoxPostalCode.Size = new Size(285, 23);
            textBoxPostalCode.TabIndex = 2;
            textBoxPostalCode.Validating += textBoxPostalCode_Validating;
            textBoxPostalCode.Validated += Validated;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 105);
            label4.Name = "label4";
            label4.Size = new Size(21, 15);
            label4.TabIndex = 0;
            label4.Text = "IČ:";
            // 
            // textBoxIC
            // 
            textBoxIC.Location = new Point(72, 102);
            textBoxIC.Name = "textBoxIC";
            textBoxIC.Size = new Size(285, 23);
            textBoxIC.TabIndex = 3;
            textBoxIC.Validating += textBoxIC_Validating;
            textBoxIC.Validated += Validated;
            // 
            // buttonOK
            // 
            buttonOK.Location = new Point(192, 142);
            buttonOK.Name = "buttonOK";
            buttonOK.Size = new Size(75, 23);
            buttonOK.TabIndex = 4;
            buttonOK.Text = "OK";
            buttonOK.UseVisualStyleBackColor = true;
            buttonOK.Click += buttonOK_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(273, 142);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(75, 23);
            buttonCancel.TabIndex = 5;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            errorProvider1.ContainerControl = this;
            // 
            // CustomerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoValidate = AutoValidate.EnableAllowFocusChange;
            ClientSize = new Size(369, 179);
            Controls.Add(buttonCancel);
            Controls.Add(buttonOK);
            Controls.Add(textBoxIC);
            Controls.Add(label4);
            Controls.Add(textBoxPostalCode);
            Controls.Add(label3);
            Controls.Add(textBoxAddress);
            Controls.Add(label2);
            Controls.Add(textBoxName);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "CustomerForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Zákazník";
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBoxName;
        private Label label2;
        private TextBox textBoxAddress;
        private Label label3;
        private TextBox textBoxPostalCode;
        private Label label4;
        private TextBox textBoxIC;
        private Button buttonOK;
        private Button buttonCancel;
        private ErrorProvider errorProvider1;
    }
}