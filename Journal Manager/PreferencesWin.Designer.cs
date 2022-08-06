
namespace Journal_Manager
{
    partial class PreferencesWin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PreferencesWin));
            this.label1 = new System.Windows.Forms.Label();
            this.journalDirInput = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.journalDirButton = new System.Windows.Forms.Button();
            this.fontNameButton = new System.Windows.Forms.Button();
            this.fontNameInput = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Journal Directory";
            // 
            // journalDirInput
            // 
            this.journalDirInput.Location = new System.Drawing.Point(105, 10);
            this.journalDirInput.Name = "journalDirInput";
            this.journalDirInput.Size = new System.Drawing.Size(335, 20);
            this.journalDirInput.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(16, 36);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(505, 20);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = "This is the directory that the program will read from when you view past journal " +
    "entries.\r\n";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Font";
            // 
            // journalDirButton
            // 
            this.journalDirButton.Location = new System.Drawing.Point(446, 8);
            this.journalDirButton.Name = "journalDirButton";
            this.journalDirButton.Size = new System.Drawing.Size(75, 23);
            this.journalDirButton.TabIndex = 9;
            this.journalDirButton.Text = "Select";
            this.journalDirButton.UseVisualStyleBackColor = true;
            this.journalDirButton.Click += new System.EventHandler(this.journalDirButton_Click);
            // 
            // fontNameButton
            // 
            this.fontNameButton.Location = new System.Drawing.Point(446, 63);
            this.fontNameButton.Name = "fontNameButton";
            this.fontNameButton.Size = new System.Drawing.Size(75, 23);
            this.fontNameButton.TabIndex = 11;
            this.fontNameButton.Text = "Select";
            this.fontNameButton.UseVisualStyleBackColor = true;
            this.fontNameButton.Click += new System.EventHandler(this.fontNameButton_Click);
            // 
            // fontNameInput
            // 
            this.fontNameInput.Location = new System.Drawing.Point(105, 65);
            this.fontNameInput.Name = "fontNameInput";
            this.fontNameInput.Size = new System.Drawing.Size(335, 20);
            this.fontNameInput.TabIndex = 10;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(16, 117);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(504, 23);
            this.saveButton.TabIndex = 12;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // textBox2
            // 
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(16, 91);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(505, 20);
            this.textBox2.TabIndex = 13;
            this.textBox2.Text = "Set the font and font size of entry contents.";
            // 
            // PreferencesWin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 146);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.fontNameButton);
            this.Controls.Add(this.fontNameInput);
            this.Controls.Add(this.journalDirButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.journalDirInput);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "PreferencesWin";
            this.Text = "Preferences";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox journalDirInput;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button journalDirButton;
        private System.Windows.Forms.Button fontNameButton;
        private System.Windows.Forms.TextBox fontNameInput;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.TextBox textBox2;
    }
}