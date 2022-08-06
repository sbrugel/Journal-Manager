
namespace Journal_Manager
{
    partial class Search
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Search));
            this.label1 = new System.Windows.Forms.Label();
            this.queryTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.searchButton = new System.Windows.Forms.Button();
            this.resultsTable = new System.Windows.Forms.DataGridView();
            this.Entry = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FileLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.radioKeyword = new System.Windows.Forms.RadioButton();
            this.radioTag = new System.Windows.Forms.RadioButton();
            this.radioNoTag = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.resultsTable)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Search for:";
            // 
            // queryTextBox
            // 
            this.queryTextBox.Location = new System.Drawing.Point(78, 81);
            this.queryTextBox.Name = "queryTextBox";
            this.queryTextBox.Size = new System.Drawing.Size(424, 20);
            this.queryTextBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(158, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "label2";
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(77, 107);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(75, 23);
            this.searchButton.TabIndex = 3;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // resultsTable
            // 
            this.resultsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.resultsTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Entry,
            this.FileLocation});
            this.resultsTable.Location = new System.Drawing.Point(12, 153);
            this.resultsTable.Name = "resultsTable";
            this.resultsTable.Size = new System.Drawing.Size(486, 442);
            this.resultsTable.TabIndex = 4;
            this.resultsTable.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.OnRowClick);
            // 
            // Entry
            // 
            this.Entry.HeaderText = "Entry";
            this.Entry.Name = "Entry";
            this.Entry.ReadOnly = true;
            // 
            // FileLocation
            // 
            this.FileLocation.HeaderText = "File Location";
            this.FileLocation.Name = "FileLocation";
            this.FileLocation.ReadOnly = true;
            // 
            // radioKeyword
            // 
            this.radioKeyword.AutoSize = true;
            this.radioKeyword.Location = new System.Drawing.Point(77, 12);
            this.radioKeyword.Name = "radioKeyword";
            this.radioKeyword.Size = new System.Drawing.Size(66, 17);
            this.radioKeyword.TabIndex = 5;
            this.radioKeyword.TabStop = true;
            this.radioKeyword.Text = "Keyword";
            this.radioKeyword.UseVisualStyleBackColor = true;
            // 
            // radioTag
            // 
            this.radioTag.AutoSize = true;
            this.radioTag.Location = new System.Drawing.Point(77, 35);
            this.radioTag.Name = "radioTag";
            this.radioTag.Size = new System.Drawing.Size(44, 17);
            this.radioTag.TabIndex = 6;
            this.radioTag.TabStop = true;
            this.radioTag.Text = "Tag";
            this.radioTag.UseVisualStyleBackColor = true;
            // 
            // radioNoTag
            // 
            this.radioNoTag.AutoSize = true;
            this.radioNoTag.Location = new System.Drawing.Point(77, 58);
            this.radioNoTag.Name = "radioNoTag";
            this.radioNoTag.Size = new System.Drawing.Size(83, 17);
            this.radioNoTag.TabIndex = 7;
            this.radioNoTag.TabStop = true;
            this.radioNoTag.Text = "Lack of Tag";
            this.radioNoTag.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(78, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Queries are case insensitive.";
            // 
            // Search
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 607);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.radioNoTag);
            this.Controls.Add(this.radioTag);
            this.Controls.Add(this.radioKeyword);
            this.Controls.Add(this.resultsTable);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.queryTextBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Search";
            this.Text = "Search";
            ((System.ComponentModel.ISupportInitialize)(this.resultsTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox queryTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.DataGridView resultsTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn Entry;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileLocation;
        private System.Windows.Forms.RadioButton radioKeyword;
        private System.Windows.Forms.RadioButton radioTag;
        private System.Windows.Forms.RadioButton radioNoTag;
        private System.Windows.Forms.Label label3;
    }
}