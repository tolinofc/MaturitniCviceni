namespace Graf
{
    partial class Form1
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
            button_Open = new Button();
            SuspendLayout();
            // 
            // button_Open
            // 
            button_Open.Location = new Point(12, 12);
            button_Open.Name = "button_Open";
            button_Open.Size = new Size(155, 63);
            button_Open.TabIndex = 0;
            button_Open.Text = "Otevřít";
            button_Open.UseVisualStyleBackColor = true;
            button_Open.Click += button1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(179, 87);
            Controls.Add(button_Open);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Form1";
            Text = "Výběr souboru";
            ResumeLayout(false);
        }

        #endregion

        private Button button_Open;
    }
}
