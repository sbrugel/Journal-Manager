
namespace Journal_Manager
{
    partial class EntryCreator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EntryCreator));
            this.contentLabel = new System.Windows.Forms.Label();
            this.contentBox = new System.Windows.Forms.RichTextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.preferencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.titleLabel = new System.Windows.Forms.Label();
            this.titleBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.colorChoice = new System.Windows.Forms.ComboBox();
            this.previousEntry = new System.Windows.Forms.Button();
            this.nextEntry = new System.Windows.Forms.Button();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.addTag = new System.Windows.Forms.Button();
            this.tagsList = new System.Windows.Forms.ComboBox();
            this.currentTags = new System.Windows.Forms.ListView();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contentLabel
            // 
            this.contentLabel.AutoSize = true;
            this.contentLabel.Location = new System.Drawing.Point(10, 58);
            this.contentLabel.Name = "contentLabel";
            this.contentLabel.Size = new System.Drawing.Size(109, 13);
            this.contentLabel.TabIndex = 0;
            this.contentLabel.Text = "Write contents here...";
            // 
            // contentBox
            // 
            this.contentBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.contentBox.Location = new System.Drawing.Point(12, 74);
            this.contentBox.Name = "contentBox";
            this.contentBox.Size = new System.Drawing.Size(772, 220);
            this.contentBox.TabIndex = 1;
            this.contentBox.Text = "";
            this.contentBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnKeyDown);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.preferencesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.ShowItemToolTips = true;
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.ToolTipText = "Instantly save the file - it will be named based on the current system time";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.saveAsToolStripMenuItem.Text = "Save As";
            this.saveAsToolStripMenuItem.ToolTipText = "Save the file as a custom name or overwrite an existing file";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // preferencesToolStripMenuItem
            // 
            this.preferencesToolStripMenuItem.Name = "preferencesToolStripMenuItem";
            this.preferencesToolStripMenuItem.Size = new System.Drawing.Size(80, 20);
            this.preferencesToolStripMenuItem.Text = "Preferences";
            this.preferencesToolStripMenuItem.ToolTipText = "Change settings";
            this.preferencesToolStripMenuItem.Click += new System.EventHandler(this.preferencesToolStripMenuItem_Click);
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Location = new System.Drawing.Point(9, 34);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(110, 13);
            this.titleLabel.TabIndex = 3;
            this.titleLabel.Text = "Journal Title (optional)";
            // 
            // titleBox
            // 
            this.titleBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.titleBox.Location = new System.Drawing.Point(128, 31);
            this.titleBox.MaxLength = 35;
            this.titleBox.Name = "titleBox";
            this.titleBox.Size = new System.Drawing.Size(656, 20);
            this.titleBox.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 303);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Set color:";
            // 
            // colorChoice
            // 
            this.colorChoice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.colorChoice.FormattingEnabled = true;
            this.colorChoice.Items.AddRange(new object[] {
            "None",
            "Red",
            "Orange",
            "Yellow",
            "Green",
            "Blue",
            "Purple",
            "<CUSTOM>"});
            this.colorChoice.Location = new System.Drawing.Point(71, 300);
            this.colorChoice.Name = "colorChoice";
            this.colorChoice.Size = new System.Drawing.Size(121, 21);
            this.colorChoice.TabIndex = 6;
            this.colorChoice.SelectedIndexChanged += new System.EventHandler(this.colorChoice_SelectedIndexChanged);
            // 
            // previousEntry
            // 
            this.previousEntry.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.previousEntry.Location = new System.Drawing.Point(12, 327);
            this.previousEntry.Name = "previousEntry";
            this.previousEntry.Size = new System.Drawing.Size(107, 23);
            this.previousEntry.TabIndex = 7;
            this.previousEntry.Text = "Previous Entry";
            this.previousEntry.UseVisualStyleBackColor = true;
            this.previousEntry.Click += new System.EventHandler(this.previousEntry_Click);
            // 
            // nextEntry
            // 
            this.nextEntry.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.nextEntry.Location = new System.Drawing.Point(677, 327);
            this.nextEntry.Name = "nextEntry";
            this.nextEntry.Size = new System.Drawing.Size(107, 23);
            this.nextEntry.TabIndex = 8;
            this.nextEntry.Text = "Next Entry";
            this.nextEntry.UseVisualStyleBackColor = true;
            this.nextEntry.Click += new System.EventHandler(this.nextEntry_Click);
            // 
            // addTag
            // 
            this.addTag.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addTag.Location = new System.Drawing.Point(376, 298);
            this.addTag.Name = "addTag";
            this.addTag.Size = new System.Drawing.Size(75, 23);
            this.addTag.TabIndex = 9;
            this.addTag.Text = "Add Tag";
            this.addTag.UseVisualStyleBackColor = true;
            this.addTag.Click += new System.EventHandler(this.addTag_Click);
            // 
            // tagsList
            // 
            this.tagsList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tagsList.FormattingEnabled = true;
            this.tagsList.Location = new System.Drawing.Point(249, 300);
            this.tagsList.Name = "tagsList";
            this.tagsList.Size = new System.Drawing.Size(121, 21);
            this.tagsList.TabIndex = 10;
            this.tagsList.SelectedIndexChanged += new System.EventHandler(this.tagsList_SelectedIndexChanged);
            // 
            // currentTags
            // 
            this.currentTags.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.currentTags.HideSelection = false;
            this.currentTags.Location = new System.Drawing.Point(457, 298);
            this.currentTags.Name = "currentTags";
            this.currentTags.Size = new System.Drawing.Size(327, 23);
            this.currentTags.TabIndex = 11;
            this.currentTags.UseCompatibleStateImageBehavior = false;
            this.currentTags.DoubleClick += new System.EventHandler(this.tagDoubleClick);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(457, 327);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(151, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Double click a tag to remove it";
            // 
            // EntryCreator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 358);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.currentTags);
            this.Controls.Add(this.tagsList);
            this.Controls.Add(this.addTag);
            this.Controls.Add(this.nextEntry);
            this.Controls.Add(this.previousEntry);
            this.Controls.Add(this.colorChoice);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.titleBox);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.contentBox);
            this.Controls.Add(this.contentLabel);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "EntryCreator";
            this.Text = "Entry Creator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnClose);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label contentLabel;
        private System.Windows.Forms.RichTextBox contentBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem preferencesToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.TextBox titleBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox colorChoice;
        private System.Windows.Forms.Button previousEntry;
        private System.Windows.Forms.Button nextEntry;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.Button addTag;
        private System.Windows.Forms.ComboBox tagsList;
        private System.Windows.Forms.ListView currentTags;
        private System.Windows.Forms.Label label2;
    }
}

