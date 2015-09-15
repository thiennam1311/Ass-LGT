namespace S_DES
{
    partial class Form1
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
            this.txtBoxKey = new System.Windows.Forms.TextBox();
            this.lblKey = new System.Windows.Forms.Label();
            this.btnRandomkey = new System.Windows.Forms.Button();
            this.btnEncrypt = new System.Windows.Forms.Button();
            this.btnDecrypt = new System.Windows.Forms.Button();
            this.lblInput = new System.Windows.Forms.Label();
            this.txtBoxInput = new System.Windows.Forms.TextBox();
            this.txtBoxOutput = new System.Windows.Forms.TextBox();
            this.lblOutput = new System.Windows.Forms.Label();
            this.btnInput = new System.Windows.Forms.Button();
            this.btnOutput = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.openFileInput = new System.Windows.Forms.OpenFileDialog();
            this.openFileOutput = new System.Windows.Forms.OpenFileDialog();
            this.lblAbout = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtBoxKey
            // 
            this.txtBoxKey.Location = new System.Drawing.Point(15, 29);
            this.txtBoxKey.Name = "txtBoxKey";
            this.txtBoxKey.Size = new System.Drawing.Size(229, 20);
            this.txtBoxKey.TabIndex = 0;
            // 
            // lblKey
            // 
            this.lblKey.AutoSize = true;
            this.lblKey.Location = new System.Drawing.Point(12, 11);
            this.lblKey.Name = "lblKey";
            this.lblKey.Size = new System.Drawing.Size(25, 13);
            this.lblKey.TabIndex = 1;
            this.lblKey.Text = "Key";
            // 
            // btnRandomkey
            // 
            this.btnRandomkey.Location = new System.Drawing.Point(265, 27);
            this.btnRandomkey.Name = "btnRandomkey";
            this.btnRandomkey.Size = new System.Drawing.Size(75, 23);
            this.btnRandomkey.TabIndex = 2;
            this.btnRandomkey.Text = "Random key";
            this.btnRandomkey.UseVisualStyleBackColor = true;
            this.btnRandomkey.Click += new System.EventHandler(this.btnRandomkey_Click);
            // 
            // btnEncrypt
            // 
            this.btnEncrypt.Location = new System.Drawing.Point(12, 164);
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.Size = new System.Drawing.Size(88, 23);
            this.btnEncrypt.TabIndex = 3;
            this.btnEncrypt.Text = "Encryption";
            this.btnEncrypt.UseVisualStyleBackColor = true;
            this.btnEncrypt.Click += new System.EventHandler(this.btnEncrypt_Click);
            // 
            // btnDecrypt
            // 
            this.btnDecrypt.Location = new System.Drawing.Point(128, 164);
            this.btnDecrypt.Name = "btnDecrypt";
            this.btnDecrypt.Size = new System.Drawing.Size(92, 23);
            this.btnDecrypt.TabIndex = 4;
            this.btnDecrypt.Text = "Decryption";
            this.btnDecrypt.UseVisualStyleBackColor = true;
            this.btnDecrypt.Click += new System.EventHandler(this.btnDecrypt_Click);
            // 
            // lblInput
            // 
            this.lblInput.AutoSize = true;
            this.lblInput.Location = new System.Drawing.Point(12, 55);
            this.lblInput.Name = "lblInput";
            this.lblInput.Size = new System.Drawing.Size(47, 13);
            this.lblInput.TabIndex = 5;
            this.lblInput.Text = "Input file";
            // 
            // txtBoxInput
            // 
            this.txtBoxInput.Location = new System.Drawing.Point(15, 74);
            this.txtBoxInput.Name = "txtBoxInput";
            this.txtBoxInput.Size = new System.Drawing.Size(229, 20);
            this.txtBoxInput.TabIndex = 6;
            // 
            // txtBoxOutput
            // 
            this.txtBoxOutput.Location = new System.Drawing.Point(15, 119);
            this.txtBoxOutput.Name = "txtBoxOutput";
            this.txtBoxOutput.Size = new System.Drawing.Size(229, 20);
            this.txtBoxOutput.TabIndex = 7;
            // 
            // lblOutput
            // 
            this.lblOutput.AutoSize = true;
            this.lblOutput.Location = new System.Drawing.Point(15, 98);
            this.lblOutput.Name = "lblOutput";
            this.lblOutput.Size = new System.Drawing.Size(55, 13);
            this.lblOutput.TabIndex = 8;
            this.lblOutput.Text = "Output file";
            // 
            // btnInput
            // 
            this.btnInput.Location = new System.Drawing.Point(265, 72);
            this.btnInput.Name = "btnInput";
            this.btnInput.Size = new System.Drawing.Size(75, 23);
            this.btnInput.TabIndex = 9;
            this.btnInput.Text = "Browser...";
            this.btnInput.UseVisualStyleBackColor = true;
            this.btnInput.Click += new System.EventHandler(this.btnInput_Click);
            // 
            // btnOutput
            // 
            this.btnOutput.Location = new System.Drawing.Point(265, 117);
            this.btnOutput.Name = "btnOutput";
            this.btnOutput.Size = new System.Drawing.Size(75, 23);
            this.btnOutput.TabIndex = 10;
            this.btnOutput.Text = "Browser...";
            this.btnOutput.UseVisualStyleBackColor = true;
            this.btnOutput.Click += new System.EventHandler(this.btnOutput_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(265, 162);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 11;
            this.btnClose.Text = "Exit";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // openFileInput
            // 
            this.openFileInput.FileName = "openFileInput";
            // 
            // openFileOutput
            // 
            this.openFileOutput.FileName = "openFileOutput";
            // 
            // lblAbout
            // 
            this.lblAbout.AutoSize = true;
            this.lblAbout.Location = new System.Drawing.Point(88, 215);
            this.lblAbout.Name = "lblAbout";
            this.lblAbout.Size = new System.Drawing.Size(156, 13);
            this.lblAbout.TabIndex = 12;
            this.lblAbout.Text = "Nguyễn Thiên Nam - 51202275";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 237);
            this.Controls.Add(this.lblAbout);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnOutput);
            this.Controls.Add(this.btnInput);
            this.Controls.Add(this.lblOutput);
            this.Controls.Add(this.txtBoxOutput);
            this.Controls.Add(this.txtBoxInput);
            this.Controls.Add(this.lblInput);
            this.Controls.Add(this.btnDecrypt);
            this.Controls.Add(this.btnEncrypt);
            this.Controls.Add(this.btnRandomkey);
            this.Controls.Add(this.lblKey);
            this.Controls.Add(this.txtBoxKey);
            this.Name = "Form1";
            this.Text = "S-DES";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.TextBox txtBoxKey;
        private System.Windows.Forms.Label lblKey;
        private System.Windows.Forms.Button btnRandomkey;
        private System.Windows.Forms.Button btnEncrypt;
        private System.Windows.Forms.Button btnDecrypt;
        private System.Windows.Forms.Label lblInput;
        private System.Windows.Forms.TextBox txtBoxInput;
        private System.Windows.Forms.TextBox txtBoxOutput;
        private System.Windows.Forms.Label lblOutput;
        private System.Windows.Forms.Button btnInput;
        private System.Windows.Forms.Button btnOutput;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.OpenFileDialog openFileInput;
        private System.Windows.Forms.OpenFileDialog openFileOutput;
        private System.Windows.Forms.Label lblAbout;
    }
}

