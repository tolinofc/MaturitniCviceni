namespace ServisniProtokolCv.Forms
{
    partial class BasicInfoForm
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
            labelProtocolNumber = new Label();
            textBoxProtocolNumber = new TextBox();
            labelMeasureDate = new Label();
            dateTimePickerMeasureDate = new DateTimePicker();
            buttonOK = new Button();
            buttonCancel = new Button();
            errorProvider1 = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // labelProtocolNumber
            // 
            labelProtocolNumber.AutoSize = true;
            labelProtocolNumber.Location = new Point(31, 27);
            labelProtocolNumber.Name = "labelProtocolNumber";
            labelProtocolNumber.Size = new Size(91, 15);
            labelProtocolNumber.TabIndex = 0;
            labelProtocolNumber.Text = "Číslo protokolu:";
            // 
            // textBoxProtocolNumber
            // 
            textBoxProtocolNumber.Location = new Point(141, 24);
            textBoxProtocolNumber.Name = "textBoxProtocolNumber";
            textBoxProtocolNumber.Size = new Size(200, 23);
            textBoxProtocolNumber.TabIndex = 0;
            textBoxProtocolNumber.Validating += textBoxProtocolNumber_Validating;
            textBoxProtocolNumber.Validated += Validated;
            // 
            // labelMeasureDate
            // 
            labelMeasureDate.AutoSize = true;
            labelMeasureDate.Location = new Point(31, 64);
            labelMeasureDate.Name = "labelMeasureDate";
            labelMeasureDate.Size = new Size(86, 15);
            labelMeasureDate.TabIndex = 2;
            labelMeasureDate.Text = "Datum měření:";
            // 
            // dateTimePickerMeasureDate
            // 
            dateTimePickerMeasureDate.Location = new Point(141, 58);
            dateTimePickerMeasureDate.Name = "dateTimePickerMeasureDate";
            dateTimePickerMeasureDate.Size = new Size(200, 23);
            dateTimePickerMeasureDate.TabIndex = 1;
            // 
            // buttonOK
            // 
            buttonOK.Location = new Point(185, 102);
            buttonOK.Name = "buttonOK";
            buttonOK.Size = new Size(75, 23);
            buttonOK.TabIndex = 2;
            buttonOK.Text = "OK";
            buttonOK.UseVisualStyleBackColor = true;
            buttonOK.Click += buttonOK_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(266, 102);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(75, 23);
            buttonCancel.TabIndex = 3;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // BasicInfoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoValidate = AutoValidate.EnableAllowFocusChange;
            ClientSize = new Size(353, 141);
            Controls.Add(buttonCancel);
            Controls.Add(buttonOK);
            Controls.Add(dateTimePickerMeasureDate);
            Controls.Add(labelMeasureDate);
            Controls.Add(textBoxProtocolNumber);
            Controls.Add(labelProtocolNumber);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "BasicInfoForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Základní informace";
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelProtocolNumber;
        private TextBox textBoxProtocolNumber;
        private Label labelMeasureDate;
        private DateTimePicker dateTimePickerMeasureDate;
        private Button buttonOK;
        private Button buttonCancel;
        private ErrorProvider errorProvider1;
    }
}