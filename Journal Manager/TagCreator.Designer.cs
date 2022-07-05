
namespace Journal_Manager
{
    partial class TagCreator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TagCreator));
            this.label1 = new System.Windows.Forms.Label();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.colorBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pickButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tag Name";
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(15, 25);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(244, 20);
            this.nameBox.TabIndex = 1;
            // 
            // colorBox
            // 
            this.colorBox.Enabled = false;
            this.colorBox.Location = new System.Drawing.Point(15, 64);
            this.colorBox.Name = "colorBox";
            this.colorBox.Size = new System.Drawing.Size(200, 20);
            this.colorBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tag Color";
            // 
            // pickButton
            // 
            this.pickButton.Location = new System.Drawing.Point(221, 62);
            this.pickButton.Name = "pickButton";
            this.pickButton.Size = new System.Drawing.Size(38, 23);
            this.pickButton.TabIndex = 4;
            this.pickButton.Text = "Pick";
            this.pickButton.UseVisualStyleBackColor = true;
            this.pickButton.Click += new System.EventHandler(this.pickButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(15, 90);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 5;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // TagCreator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(273, 124);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.pickButton);
            this.Controls.Add(this.colorBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nameBox);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TagCreator";
            this.Text = "Tag Creator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.TextBox colorBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button pickButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.ColorDialog colorDialog;
    }
}