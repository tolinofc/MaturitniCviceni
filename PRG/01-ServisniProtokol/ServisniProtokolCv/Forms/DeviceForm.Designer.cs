namespace ServisniProtokolCv.Forms
{
    partial class DeviceForm
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
            buttonCancel = new Button();
            buttonOK = new Button();
            textBoxSerialNumber = new TextBox();
            labelSerialNumber = new Label();
            textBoxModel = new TextBox();
            labelModel = new Label();
            textBoxManufacturer = new TextBox();
            labelManufacturer = new Label();
            errorProvider1 = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(273, 141);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(75, 23);
            buttonCancel.TabIndex = 4;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // buttonOK
            // 
            buttonOK.Location = new Point(192, 141);
            buttonOK.Name = "buttonOK";
            buttonOK.Size = new Size(75, 23);
            buttonOK.TabIndex = 3;
            buttonOK.Text = "OK";
            buttonOK.UseVisualStyleBackColor = true;
            buttonOK.Click += buttonOK_Click;
            // 
            // textBoxSerialNumber
            // 
            textBoxSerialNumber.Location = new Point(93, 72);
            textBoxSerialNumber.Name = "textBoxSerialNumber";
            textBoxSerialNumber.Size = new Size(264, 23);
            textBoxSerialNumber.TabIndex = 2;
            textBoxSerialNumber.Validating += textBox_Validating;
            textBoxSerialNumber.Validated += Validated;
            // 
            // labelSerialNumber
            // 
            labelSerialNumber.AutoSize = true;
            labelSerialNumber.Location = new Point(12, 75);
            labelSerialNumber.Name = "labelSerialNumber";
            labelSerialNumber.Size = new Size(75, 15);
            labelSerialNumber.TabIndex = 7;
            labelSerialNumber.Text = "Sériové číslo:";
            // 
            // textBoxModel
            // 
            textBoxModel.Location = new Point(93, 43);
            textBoxModel.Name = "textBoxModel";
            textBoxModel.Size = new Size(264, 23);
            textBoxModel.TabIndex = 1;
            textBoxModel.Validating += textBox_Validating;
            textBoxModel.Validated += Validated;
            // 
            // labelModel
            // 
            labelModel.AutoSize = true;
            labelModel.Location = new Point(12, 46);
            labelModel.Name = "labelModel";
            labelModel.Size = new Size(44, 15);
            labelModel.TabIndex = 8;
            labelModel.Text = "Model:";
            // 
            // textBoxManufacturer
            // 
            textBoxManufacturer.Location = new Point(93, 14);
            textBoxManufacturer.Name = "textBoxManufacturer";
            textBoxManufacturer.Size = new Size(264, 23);
            textBoxManufacturer.TabIndex = 0;
            textBoxManufacturer.Validating += textBox_Validating;
            textBoxManufacturer.Validated += Validated;
            // 
            // labelManufacturer
            // 
            labelManufacturer.AutoSize = true;
            labelManufacturer.Location = new Point(12, 17);
            labelManufacturer.Name = "labelManufacturer";
            labelManufacturer.Size = new Size(53, 15);
            labelManufacturer.TabIndex = 10;
            labelManufacturer.Text = "Výrobce:";
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // DeviceForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoValidate = AutoValidate.EnableAllowFocusChange;
            ClientSize = new Size(369, 179);
            Controls.Add(buttonCancel);
            Controls.Add(buttonOK);
            Controls.Add(textBoxSerialNumber);
            Controls.Add(labelSerialNumber);
            Controls.Add(textBoxModel);
            Controls.Add(labelModel);
            Controls.Add(textBoxManufacturer);
            Controls.Add(labelManufacturer);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "DeviceForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Zařízení";
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonCancel;
        private Button buttonOK;
        private TextBox textBoxSerialNumber;
        private Label labelSerialNumber;
        private TextBox textBoxModel;
        private Label labelModel;
        private TextBox textBoxManufacturer;
        private Label labelManufacturer;
        private ErrorProvider errorProvider1;
    }
}