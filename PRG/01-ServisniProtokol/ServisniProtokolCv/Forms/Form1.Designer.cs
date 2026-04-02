namespace ServisniProtokolCv
{
    partial class ProtocolForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            basicInfo = new GroupBox();
            buttonBasicInfoEdit = new Button();
            measureDateValue = new Label();
            protocolNumberValue = new Label();
            measureDateLabel = new Label();
            protocolNumberLabel = new Label();
            groupBoxCustomer = new GroupBox();
            buttonCustomerEdit = new Button();
            labelIcValue = new Label();
            labelICO = new Label();
            labelPostalCodeValue = new Label();
            labelPostalCode = new Label();
            labelAddressValue = new Label();
            labelAddress = new Label();
            labelCustomerNameValue = new Label();
            labelCustomerName = new Label();
            groupBoxDevice = new GroupBox();
            buttonDeviceEdit = new Button();
            labelSerialNumber = new Label();
            labelModel = new Label();
            labelManufacturer = new Label();
            label5 = new Label();
            label3 = new Label();
            label2 = new Label();
            groupBoxMeasure = new GroupBox();
            buttonDelete = new Button();
            buttonEdit = new Button();
            buttonAdd = new Button();
            dataGridViewMeasure = new DataGridView();
            buttonView = new Button();
            buttonExport = new Button();
            buttonLoad = new Button();
            buttonSave = new Button();
            basicInfo.SuspendLayout();
            groupBoxCustomer.SuspendLayout();
            groupBoxDevice.SuspendLayout();
            groupBoxMeasure.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewMeasure).BeginInit();
            SuspendLayout();
            // 
            // basicInfo
            // 
            basicInfo.Controls.Add(buttonBasicInfoEdit);
            basicInfo.Controls.Add(measureDateValue);
            basicInfo.Controls.Add(protocolNumberValue);
            basicInfo.Controls.Add(measureDateLabel);
            basicInfo.Controls.Add(protocolNumberLabel);
            basicInfo.Location = new Point(12, 12);
            basicInfo.Name = "basicInfo";
            basicInfo.Size = new Size(642, 94);
            basicInfo.TabIndex = 0;
            basicInfo.TabStop = false;
            basicInfo.Text = "Základní informace";
            // 
            // buttonBasicInfoEdit
            // 
            buttonBasicInfoEdit.Location = new Point(553, 22);
            buttonBasicInfoEdit.Name = "buttonBasicInfoEdit";
            buttonBasicInfoEdit.Size = new Size(83, 66);
            buttonBasicInfoEdit.TabIndex = 4;
            buttonBasicInfoEdit.Text = "Upravit";
            buttonBasicInfoEdit.UseVisualStyleBackColor = true;
            buttonBasicInfoEdit.Click += editBasicInfoBtn_Click;
            // 
            // measureDateValue
            // 
            measureDateValue.AutoSize = true;
            measureDateValue.Location = new Point(114, 59);
            measureDateValue.Name = "measureDateValue";
            measureDateValue.Size = new Size(12, 15);
            measureDateValue.TabIndex = 3;
            measureDateValue.Text = "?";
            // 
            // protocolNumberValue
            // 
            protocolNumberValue.AutoSize = true;
            protocolNumberValue.Location = new Point(114, 30);
            protocolNumberValue.Name = "protocolNumberValue";
            protocolNumberValue.Size = new Size(12, 15);
            protocolNumberValue.TabIndex = 2;
            protocolNumberValue.Text = "?";
            // 
            // measureDateLabel
            // 
            measureDateLabel.AutoSize = true;
            measureDateLabel.Location = new Point(17, 59);
            measureDateLabel.Name = "measureDateLabel";
            measureDateLabel.Size = new Size(86, 15);
            measureDateLabel.TabIndex = 1;
            measureDateLabel.Text = "Datum měření:";
            // 
            // protocolNumberLabel
            // 
            protocolNumberLabel.AutoSize = true;
            protocolNumberLabel.Location = new Point(17, 30);
            protocolNumberLabel.Name = "protocolNumberLabel";
            protocolNumberLabel.Size = new Size(91, 15);
            protocolNumberLabel.TabIndex = 0;
            protocolNumberLabel.Text = "Číslo protokolu:";
            // 
            // groupBoxCustomer
            // 
            groupBoxCustomer.Controls.Add(buttonCustomerEdit);
            groupBoxCustomer.Controls.Add(labelIcValue);
            groupBoxCustomer.Controls.Add(labelICO);
            groupBoxCustomer.Controls.Add(labelPostalCodeValue);
            groupBoxCustomer.Controls.Add(labelPostalCode);
            groupBoxCustomer.Controls.Add(labelAddressValue);
            groupBoxCustomer.Controls.Add(labelAddress);
            groupBoxCustomer.Controls.Add(labelCustomerNameValue);
            groupBoxCustomer.Controls.Add(labelCustomerName);
            groupBoxCustomer.Location = new Point(12, 122);
            groupBoxCustomer.Name = "groupBoxCustomer";
            groupBoxCustomer.Size = new Size(295, 161);
            groupBoxCustomer.TabIndex = 1;
            groupBoxCustomer.TabStop = false;
            groupBoxCustomer.Text = "Zákazník";
            // 
            // buttonCustomerEdit
            // 
            buttonCustomerEdit.Location = new Point(214, 132);
            buttonCustomerEdit.Name = "buttonCustomerEdit";
            buttonCustomerEdit.Size = new Size(75, 23);
            buttonCustomerEdit.TabIndex = 1;
            buttonCustomerEdit.Text = "Upravit";
            buttonCustomerEdit.UseVisualStyleBackColor = true;
            buttonCustomerEdit.Click += editCustomerBtn_Click;
            // 
            // labelIcValue
            // 
            labelIcValue.AutoSize = true;
            labelIcValue.Location = new Point(70, 110);
            labelIcValue.Name = "labelIcValue";
            labelIcValue.Size = new Size(12, 15);
            labelIcValue.TabIndex = 0;
            labelIcValue.Text = "?";
            // 
            // labelICO
            // 
            labelICO.AutoSize = true;
            labelICO.Location = new Point(17, 110);
            labelICO.Name = "labelICO";
            labelICO.Size = new Size(21, 15);
            labelICO.TabIndex = 0;
            labelICO.Text = "IČ:";
            // 
            // labelPostalCodeValue
            // 
            labelPostalCodeValue.AutoSize = true;
            labelPostalCodeValue.Location = new Point(70, 82);
            labelPostalCodeValue.Name = "labelPostalCodeValue";
            labelPostalCodeValue.Size = new Size(12, 15);
            labelPostalCodeValue.TabIndex = 0;
            labelPostalCodeValue.Text = "?";
            // 
            // labelPostalCode
            // 
            labelPostalCode.AutoSize = true;
            labelPostalCode.Location = new Point(17, 82);
            labelPostalCode.Name = "labelPostalCode";
            labelPostalCode.Size = new Size(31, 15);
            labelPostalCode.TabIndex = 0;
            labelPostalCode.Text = "PSČ:";
            // 
            // labelAddressValue
            // 
            labelAddressValue.AutoSize = true;
            labelAddressValue.Location = new Point(70, 56);
            labelAddressValue.Name = "labelAddressValue";
            labelAddressValue.Size = new Size(12, 15);
            labelAddressValue.TabIndex = 0;
            labelAddressValue.Text = "?";
            // 
            // labelAddress
            // 
            labelAddress.AutoSize = true;
            labelAddress.Location = new Point(17, 56);
            labelAddress.Name = "labelAddress";
            labelAddress.Size = new Size(46, 15);
            labelAddress.TabIndex = 0;
            labelAddress.Text = "Adresa:";
            // 
            // labelCustomerNameValue
            // 
            labelCustomerNameValue.AutoSize = true;
            labelCustomerNameValue.Location = new Point(70, 29);
            labelCustomerNameValue.Name = "labelCustomerNameValue";
            labelCustomerNameValue.Size = new Size(12, 15);
            labelCustomerNameValue.TabIndex = 0;
            labelCustomerNameValue.Text = "?";
            // 
            // labelCustomerName
            // 
            labelCustomerName.AutoSize = true;
            labelCustomerName.Location = new Point(17, 29);
            labelCustomerName.Name = "labelCustomerName";
            labelCustomerName.Size = new Size(42, 15);
            labelCustomerName.TabIndex = 0;
            labelCustomerName.Text = "Název:";
            // 
            // groupBoxDevice
            // 
            groupBoxDevice.Controls.Add(buttonDeviceEdit);
            groupBoxDevice.Controls.Add(labelSerialNumber);
            groupBoxDevice.Controls.Add(labelModel);
            groupBoxDevice.Controls.Add(labelManufacturer);
            groupBoxDevice.Controls.Add(label5);
            groupBoxDevice.Controls.Add(label3);
            groupBoxDevice.Controls.Add(label2);
            groupBoxDevice.Location = new Point(359, 122);
            groupBoxDevice.Name = "groupBoxDevice";
            groupBoxDevice.Size = new Size(295, 161);
            groupBoxDevice.TabIndex = 1;
            groupBoxDevice.TabStop = false;
            groupBoxDevice.Text = "Zařízení";
            // 
            // buttonDeviceEdit
            // 
            buttonDeviceEdit.Location = new Point(214, 132);
            buttonDeviceEdit.Name = "buttonDeviceEdit";
            buttonDeviceEdit.Size = new Size(75, 23);
            buttonDeviceEdit.TabIndex = 1;
            buttonDeviceEdit.Text = "Upravit";
            buttonDeviceEdit.UseVisualStyleBackColor = true;
            buttonDeviceEdit.Click += buttonDeviceEdit_Click;
            // 
            // labelSerialNumber
            // 
            labelSerialNumber.AutoSize = true;
            labelSerialNumber.Location = new Point(110, 82);
            labelSerialNumber.Name = "labelSerialNumber";
            labelSerialNumber.Size = new Size(12, 15);
            labelSerialNumber.TabIndex = 1;
            labelSerialNumber.Text = "?";
            // 
            // labelModel
            // 
            labelModel.AutoSize = true;
            labelModel.Location = new Point(110, 56);
            labelModel.Name = "labelModel";
            labelModel.Size = new Size(12, 15);
            labelModel.TabIndex = 1;
            labelModel.Text = "?";
            // 
            // labelManufacturer
            // 
            labelManufacturer.AutoSize = true;
            labelManufacturer.Location = new Point(110, 29);
            labelManufacturer.Name = "labelManufacturer";
            labelManufacturer.Size = new Size(12, 15);
            labelManufacturer.TabIndex = 1;
            labelManufacturer.Text = "?";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(27, 82);
            label5.Name = "label5";
            label5.Size = new Size(75, 15);
            label5.TabIndex = 2;
            label5.Text = "Sériové číslo:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(27, 56);
            label3.Name = "label3";
            label3.Size = new Size(44, 15);
            label3.TabIndex = 2;
            label3.Text = "Model:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(27, 29);
            label2.Name = "label2";
            label2.Size = new Size(50, 15);
            label2.TabIndex = 2;
            label2.Text = "Výrobce";
            // 
            // groupBoxMeasure
            // 
            groupBoxMeasure.Controls.Add(buttonDelete);
            groupBoxMeasure.Controls.Add(buttonEdit);
            groupBoxMeasure.Controls.Add(buttonAdd);
            groupBoxMeasure.Controls.Add(dataGridViewMeasure);
            groupBoxMeasure.Location = new Point(12, 299);
            groupBoxMeasure.Name = "groupBoxMeasure";
            groupBoxMeasure.Size = new Size(642, 338);
            groupBoxMeasure.TabIndex = 2;
            groupBoxMeasure.TabStop = false;
            groupBoxMeasure.Text = "Měření";
            // 
            // buttonDelete
            // 
            buttonDelete.Location = new Point(553, 307);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(75, 23);
            buttonDelete.TabIndex = 1;
            buttonDelete.Text = "Smazat";
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // buttonEdit
            // 
            buttonEdit.Location = new Point(476, 307);
            buttonEdit.Name = "buttonEdit";
            buttonEdit.Size = new Size(75, 23);
            buttonEdit.TabIndex = 1;
            buttonEdit.Text = "Upravit";
            buttonEdit.UseVisualStyleBackColor = true;
            buttonEdit.Click += buttonEdit_Click;
            // 
            // buttonAdd
            // 
            buttonAdd.Location = new Point(395, 307);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(75, 23);
            buttonAdd.TabIndex = 1;
            buttonAdd.Text = "Přidat";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += buttonAdd_Click;
            // 
            // dataGridViewMeasure
            // 
            dataGridViewMeasure.AllowUserToAddRows = false;
            dataGridViewMeasure.AllowUserToDeleteRows = false;
            dataGridViewMeasure.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewMeasure.Location = new Point(6, 22);
            dataGridViewMeasure.Name = "dataGridViewMeasure";
            dataGridViewMeasure.ReadOnly = true;
            dataGridViewMeasure.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewMeasure.Size = new Size(630, 279);
            dataGridViewMeasure.TabIndex = 0;
            // 
            // buttonView
            // 
            buttonView.Location = new Point(573, 648);
            buttonView.Name = "buttonView";
            buttonView.Size = new Size(75, 23);
            buttonView.TabIndex = 3;
            buttonView.Text = "Náhled";
            buttonView.UseVisualStyleBackColor = true;
            buttonView.Click += buttonView_Click;
            // 
            // buttonExport
            // 
            buttonExport.Location = new Point(492, 648);
            buttonExport.Name = "buttonExport";
            buttonExport.Size = new Size(75, 23);
            buttonExport.TabIndex = 3;
            buttonExport.Text = "Export";
            buttonExport.UseVisualStyleBackColor = true;
            buttonExport.Click += buttonExport_Click;
            // 
            // buttonLoad
            // 
            buttonLoad.Location = new Point(93, 648);
            buttonLoad.Name = "buttonLoad";
            buttonLoad.Size = new Size(75, 23);
            buttonLoad.TabIndex = 3;
            buttonLoad.Text = "Načíst";
            buttonLoad.UseVisualStyleBackColor = true;
            buttonLoad.Click += buttonLoad_Click;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(12, 648);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(75, 23);
            buttonSave.TabIndex = 3;
            buttonSave.Text = "Uložit";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // ProtocolForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(666, 683);
            Controls.Add(buttonSave);
            Controls.Add(buttonExport);
            Controls.Add(buttonLoad);
            Controls.Add(buttonView);
            Controls.Add(groupBoxMeasure);
            Controls.Add(groupBoxDevice);
            Controls.Add(groupBoxCustomer);
            Controls.Add(basicInfo);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "ProtocolForm";
            Text = "Servisní protokol";
            basicInfo.ResumeLayout(false);
            basicInfo.PerformLayout();
            groupBoxCustomer.ResumeLayout(false);
            groupBoxCustomer.PerformLayout();
            groupBoxDevice.ResumeLayout(false);
            groupBoxDevice.PerformLayout();
            groupBoxMeasure.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewMeasure).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox basicInfo;
        private Button buttonBasicInfoEdit;
        private Label measureDateValue;
        private Label protocolNumberValue;
        private Label measureDateLabel;
        private Label protocolNumberLabel;
        private GroupBox groupBoxCustomer;
        private Button buttonCustomerEdit;
        private Label labelIcValue;
        private Label labelICO;
        private Label labelPostalCodeValue;
        private Label labelPostalCode;
        private Label labelAddressValue;
        private Label labelAddress;
        private Label labelCustomerNameValue;
        private Label labelCustomerName;
        private GroupBox groupBoxDevice;
        private Label labelSerialNumber;
        private Label labelModel;
        private Label labelManufacturer;
        private Label label5;
        private Label label3;
        private Label label2;
        private Button buttonDeviceEdit;
        private GroupBox groupBoxMeasure;
        private Button buttonDelete;
        private Button buttonEdit;
        private Button buttonAdd;
        private DataGridView dataGridViewMeasure;
        private Button buttonView;
        private Button buttonExport;
        private Button buttonLoad;
        private Button buttonSave;
    }
}
