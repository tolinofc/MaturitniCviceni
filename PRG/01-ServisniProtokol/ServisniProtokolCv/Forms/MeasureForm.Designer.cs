namespace ServisniProtokolCv.Forms
{
    partial class MeasureForm
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
            textBoxUnit = new TextBox();
            labelSerialNumber = new Label();
            textBoxMeasuredValue = new TextBox();
            labelModel = new Label();
            textBoxParameter = new TextBox();
            labelManufacturer = new Label();
            label1 = new Label();
            checkBoxIsOptimal = new CheckBox();
            errorProvider1 = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(273, 141);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(75, 23);
            buttonCancel.TabIndex = 5;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // buttonOK
            // 
            buttonOK.Location = new Point(192, 141);
            buttonOK.Name = "buttonOK";
            buttonOK.Size = new Size(75, 23);
            buttonOK.TabIndex = 4;
            buttonOK.Text = "OK";
            buttonOK.UseVisualStyleBackColor = true;
            buttonOK.Click += buttonOK_Click;
            // 
            // textBoxUnit
            // 
            textBoxUnit.Location = new Point(132, 72);
            textBoxUnit.Name = "textBoxUnit";
            textBoxUnit.Size = new Size(225, 23);
            textBoxUnit.TabIndex = 2;
            textBoxUnit.Validating += textBox_Validating;
            textBoxUnit.Validated += Validated;
            // 
            // labelSerialNumber
            // 
            labelSerialNumber.AutoSize = true;
            labelSerialNumber.Location = new Point(12, 75);
            labelSerialNumber.Name = "labelSerialNumber";
            labelSerialNumber.Size = new Size(57, 15);
            labelSerialNumber.TabIndex = 16;
            labelSerialNumber.Text = "Jednotka:";
            // 
            // textBoxMeasuredValue
            // 
            textBoxMeasuredValue.Location = new Point(132, 43);
            textBoxMeasuredValue.Name = "textBoxMeasuredValue";
            textBoxMeasuredValue.Size = new Size(225, 23);
            textBoxMeasuredValue.TabIndex = 1;
            textBoxMeasuredValue.Validating += textBoxMeasuredValue_Validating;
            textBoxMeasuredValue.Validated += Validated;
            // 
            // labelModel
            // 
            labelModel.AutoSize = true;
            labelModel.Location = new Point(12, 46);
            labelModel.Name = "labelModel";
            labelModel.Size = new Size(113, 15);
            labelModel.TabIndex = 17;
            labelModel.Text = "Naměřená hodnota:";
            // 
            // textBoxParameter
            // 
            textBoxParameter.Location = new Point(132, 14);
            textBoxParameter.Name = "textBoxParameter";
            textBoxParameter.Size = new Size(225, 23);
            textBoxParameter.TabIndex = 0;
            textBoxParameter.Validating += textBox_Validating;
            textBoxParameter.Validated += Validated;
            // 
            // labelManufacturer
            // 
            labelManufacturer.AutoSize = true;
            labelManufacturer.Location = new Point(12, 17);
            labelManufacturer.Name = "labelManufacturer";
            labelManufacturer.Size = new Size(58, 15);
            labelManufacturer.TabIndex = 18;
            labelManufacturer.Text = "Parametr:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 102);
            label1.Name = "label1";
            label1.Size = new Size(59, 15);
            label1.TabIndex = 16;
            label1.Text = "Vyhovuje:";
            // 
            // checkBoxIsOptimal
            // 
            checkBoxIsOptimal.AutoSize = true;
            checkBoxIsOptimal.Location = new Point(132, 103);
            checkBoxIsOptimal.Name = "checkBoxIsOptimal";
            checkBoxIsOptimal.Size = new Size(15, 14);
            checkBoxIsOptimal.TabIndex = 3;
            checkBoxIsOptimal.UseVisualStyleBackColor = true;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // MeasureForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoValidate = AutoValidate.EnableAllowFocusChange;
            ClientSize = new Size(369, 179);
            Controls.Add(checkBoxIsOptimal);
            Controls.Add(buttonCancel);
            Controls.Add(buttonOK);
            Controls.Add(textBoxUnit);
            Controls.Add(label1);
            Controls.Add(labelSerialNumber);
            Controls.Add(textBoxMeasuredValue);
            Controls.Add(labelModel);
            Controls.Add(textBoxParameter);
            Controls.Add(labelManufacturer);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "MeasureForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Měření";
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonCancel;
        private Button buttonOK;
        private TextBox textBoxUnit;
        private Label labelSerialNumber;
        private TextBox textBoxMeasuredValue;
        private Label labelModel;
        private TextBox textBoxParameter;
        private Label labelManufacturer;
        private Label label1;
        private CheckBox checkBoxIsOptimal;
        private ErrorProvider errorProvider1;
    }
}