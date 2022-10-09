using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Input;

namespace Journal_Manager
{
    public partial class EntryCreator : Form
    {
        // load in userdata: where to save, font information
        static readonly string DATA_FILE = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\JournalManager\\data.txt";
        string saveDirectory = File.ReadLines(DATA_FILE).ElementAtOrDefault(0); // first line
        int fontSize = Int32.Parse(File.ReadLines(DATA_FILE).ElementAtOrDefault(1));
        string fontName = File.ReadLines(DATA_FILE).ElementAtOrDefault(2);

        string color = "255/255/255";
        string currentlyLoaded;

        string savedText;
        string savedTitle;
        // List<string> savedTags;

        string[] entries;
        List<string> entriesList;
        bool readOnly = false;

        string[] tags; // name of tags
        List<string> tagFiles = new List<string>(); // files of tags (to retrieve color/other props)

        /// <summary>
        /// Constructor for EntryCreator
        /// </summary>
        /// <param name="readOnly">If true, the contents of this entry cannot be edited and the user can switch between entries</param>
        /// <param name="toLoad">Which entry to load contents/info from; if blank, will load an empty entry</param>
        /// <param name="otherFiles">Other entries to navigate to when using the Previous and Next buttons</param>
        public EntryCreator(bool readOnly, string toLoad = "", string[] otherFiles = null)
        {
            InitializeComponent();

            string tagsDirectory = saveDirectory + "\\tags";
            tags = Directory.GetFiles(tagsDirectory);
            foreach (string tag in tags)
            {
                if (!Path.GetExtension(tag).Equals(".tag")) return;
                string rawText = File.ReadAllText(tag);
                string name = SubstringFromTo(rawText, 0, rawText.IndexOf("<COLOR>"));

                tagsList.Items.Add(name);
                tagFiles.Add(Path.GetFullPath(tag));
            }

            contentBox.Font = new Font(fontName, fontSize);

            this.readOnly = readOnly;
            currentlyLoaded = toLoad;

            if (readOnly)
            {
                menuStrip1.Visible = false;
                contentBox.ReadOnly = true;
                titleBox.ReadOnly = true;
                colorChoice.Enabled = false;
                tagsList.Visible = false;
                addTag.Visible = false;
                label2.Visible = false;

                titleLabel.Text = "Journal Title";
                contentLabel.Text = "Content";

                entries = otherFiles;
                entriesList = entries.OfType<string>().ToList();

                if (entriesList.IndexOf(toLoad) == 0)
                {
                    previousEntry.Enabled = false;
                }
                if (entriesList.IndexOf(toLoad) == entriesList.Count - 1)
                {
                    nextEntry.Enabled = false;
                }
            }
            else
            {
                previousEntry.Visible = false;
                nextEntry.Visible = false;
            }

            if (!toLoad.Equals(""))
            {
                LoadFile(toLoad);
            } else
            {
                savedText = ""; // set saved to empty; we're making a new file
                savedTitle = "";
                Text = "Create Entry";
            }
        }

        /// <summary>
        /// Save the file, with a specified name, to the default save directory
        /// </summary>
        /// <param name="saveAs">Name of the file</param>
        private void SaveFile(string saveAs)
        {
            try
            {
                File.WriteAllText(saveAs, contentBox.Text);
                File.AppendAllText(saveAs, "<TITLE>" + titleBox.Text + "</TITLE>");
                File.AppendAllText(saveAs, "<COLOR>" + color + "</COLOR>");
                List<string> tagNames = new List<string>();
                foreach (ListViewItem tag in currentTags.Items)
                {
                    tagNames.Add(tag.Text);
                }
                File.AppendAllText(saveAs, "<TAGS>" + String.Join(",", tagNames) + "</TAGS>");
                MessageBox.Show("Saved as " + saveAs, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while saving: " + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Load in contents/data of a specified file in the default save directory
        /// </summary>
        /// <param name="toLoad">Name of the file</param>
        private void LoadFile(String toLoad)
        {
            try
            {
                Text = readOnly ? "View Entry - " + toLoad : "Edit Entry - " + toLoad;

                currentTags.Items.Clear();

                string rawText = File.ReadAllText(toLoad);
                string contents = SubstringFromTo(rawText, 0, rawText.IndexOf("<TITLE>"));
                string title = SubstringFromTo(rawText, rawText.IndexOf("<TITLE>") + 7, rawText.IndexOf("</TITLE>"));
                color = SubstringFromTo(rawText, rawText.IndexOf("<COLOR>") + 7, rawText.IndexOf("</COLOR>"));
                string tags = SubstringFromTo(rawText, rawText.IndexOf("<TAGS>") + 6, rawText.IndexOf("</TAGS>")); // if no tags, will show None

                savedText = contents;
                savedTitle = title;
                contentBox.Text = contents;
                titleBox.Text = title.Equals("None") ? "" : title;
                GetColor();

                if (!tags.Equals("None"))
                {
                    int addIteration = 0;
                    string[] tagsList = tags.Split(',');
                    foreach (string tag in tagsList)
                    {
                        // search through saved tags and find the right one (for color)
                        string tagsDirectory = File.ReadLines(DATA_FILE).ElementAtOrDefault(0) + "\\tags"; // first line

                        string[] entryTags = Directory.GetFiles(tagsDirectory);

                        foreach (string savedTag in entryTags)
                        {
                            string tagRaw = File.ReadAllText(savedTag);
                            string tagName = SubstringFromTo(tagRaw, 0, tagRaw.IndexOf("<COLOR>"));
                            if (!Path.GetExtension(savedTag).Equals(".tag") || !tagName.Equals(tag)) continue;
                            string tagColor = SubstringFromTo(tagRaw, tagRaw.IndexOf("<COLOR>") + 7, tagRaw.IndexOf("</COLOR>"));
                            string red = SubstringFromTo(tagColor, 0, indexOfNth(tagColor, "/", 0));
                            string green = SubstringFromTo(tagColor, indexOfNth(tagColor, "/", 0) + 1, indexOfNth(tagColor, "/", 1));
                            string blue = SubstringFromTo(tagColor, indexOfNth(tagColor, "/", 1) + 1, tagColor.Length);

                            currentTags.Items.Add(tagName);
                            currentTags.Items[addIteration].BackColor = Color.FromArgb(Int32.Parse(red), Int32.Parse(green), Int32.Parse(blue));
                            addIteration++;

                            break;
                        }
                    }
                }

                if (readOnly) // format text only if not editing, otherwise show the tags
                {
                    contents = contents.Replace("[b]", "\\b ");
                    contents = contents.Replace("[/b]", "\\b0 ");
                    contents = contents.Replace("[i]", "\\i ");
                    contents = contents.Replace("[/i]", "\\i0 ");
                    contents = contents.Replace("[u]", "\\ulw ");
                    contents = contents.Replace("[/u]", "\\ulw0 ");
                    contents = contents.Replace("[h1]", "\\fs" + (fontSize * 4) + " ");
                    contents = contents.Replace("[/h1]", "\\fs" + (fontSize * 2));
                    contents = contents.Replace("[h2]", "\\fs" + (fontSize * 3) + " ");
                    contents = contents.Replace("[/h2]", "\\fs" + (fontSize * 2));
                    contents = contents.Replace("[h3]", "\\fs" + (int)(fontSize * 2.5) + " ");
                    contents = contents.Replace("[/h3]", "\\fs" + (fontSize * 2));
                    string[] lines = contents.Split(
                        new string[] { "\r\n", "\r", "\n", "\n\r" },
                        StringSplitOptions.None
                    );

                    string textToRtf = "";
                    contentBox.Rtf = @"{\rtf1\ansi ";
                    foreach (string line in lines)
                    {
                        if (line.Equals(""))
                        {
                            textToRtf += @" \par ";
                        }
                        else textToRtf += line + @" \par ";
                    }
                    contentBox.Rtf = @"{\rtf1\ansi " + textToRtf + "}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading: " + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Set the display color of the entry. If <CUSTOM> is selected, a color picker will display where the user can pick a color.
        /// </summary>
        /// <param name="col">Name of color - can be one of None, Red, Orange, Yellow, Green, Blue, Purple, <CUSTOM></param>
        private void SetColor(string col)
        {
            if (col.Equals("None"))
            {
                color = "255/255/255";
                contentBox.BackColor = Color.FromArgb(255, 255, 255);
            }
            else if (col.Equals("Red"))
            {
                color = "255/130/130";
                contentBox.BackColor = Color.FromArgb(255, 130, 130);
            }
            else if (col.Equals("Orange"))
            {
                color = "255/184/130";
                contentBox.BackColor = Color.FromArgb(255, 184, 130);
            }
            else if (col.Equals("Yellow"))
            {
                color = "255/240/130";
                contentBox.BackColor = Color.FromArgb(255, 240, 130);
            }
            else if (col.Equals("Green"))
            {
                color = "130/255/132";
                contentBox.BackColor = Color.FromArgb(130, 255, 132);
            }
            else if (col.Equals("Blue"))
            {
                color = "130/172/255";
                contentBox.BackColor = Color.FromArgb(130, 172, 255);
            }
            else if (col.Equals("Purple"))
            {
                color = "180/130/255";
                contentBox.BackColor = Color.FromArgb(180, 130, 255);
            }
            else if (col.Equals("<CUSTOM>"))
            {
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    contentBox.BackColor = colorDialog.Color;
                    color = colorDialog.Color.R + "/" + colorDialog.Color.G + "/" + colorDialog.Color.B;
                }
            }
        }

        /// <summary>
        /// Set the dropdown to the correct color when loading in an etry.
        /// </summary>
        private void GetColor()
        {
            string red = SubstringFromTo(color, 0, indexOfNth(color, "/", 0));
            string green = SubstringFromTo(color, indexOfNth(color, "/", 0)+1, indexOfNth(color, "/", 1));
            string blue = SubstringFromTo(color, indexOfNth(color, "/", 1)+1, color.Length);
            contentBox.BackColor = Color.FromArgb(Int32.Parse(red), Int32.Parse(green), Int32.Parse(blue));

            string colorStr = red + "/" + green + "/" + blue;

            if (colorStr.Equals("255/255/255"))
            {
                colorChoice.SelectedItem = "None";
            }
            else if (colorStr.Equals("255/130/130"))
            {
                colorChoice.SelectedItem = "Red";
            }
            else if (colorStr.Equals("255/184/130"))
            {
                colorChoice.SelectedItem = "Orange";
            }
            else if (colorStr.Equals("255/240/130"))
            {
                colorChoice.SelectedItem = "Yellow";
            }
            else if (colorStr.Equals("130/255/132"))
            {
                colorChoice.SelectedItem = "Green";
            }
            else if (colorStr.Equals("130/172/255"))
            {
                colorChoice.SelectedItem = "Blue";
            }
            else if (colorStr.Equals("180/130/255"))
            {
                colorChoice.SelectedItem = "Purple";
            }

        }

        /// <summary>
        /// Finds substring between indices (if that's how the plural is spelt!)
        /// </summary>
        /// <param name="str">The string to search.</param>
        /// <param name="from">The starting index of the string to search</param>
        /// <param name="to">The ending index of the string, stop searching here</param>
        /// <returns>The substring of str from the start to end index specified by the code</returns>
        private string SubstringFromTo(string str, int from, int to)
        {
            try
            {
                if (str.Substring(from, to - from).Equals(""))
                {
                    return "None";
                }
                return str.Substring(from, to - from);
            }
            catch (Exception ex)
            {
                return "None";
            }
        }

        /// <summary>
        /// Finds the nth index of a substring in a string.
        /// </summary>
        /// <param name="str">The string to search.</param>
        /// <param name="value">The substring to look for.</param>
        /// <param name="nth">What occurence of the substring to find.</param>
        /// <returns>An integer corresponding to the position of the nth index of value in str</returns>
        public static int indexOfNth(string str, string value, int nth = 0)
        {
            if (nth < 0)
                throw new ArgumentException("Can't find a negative index of substring in string. Must start with 0");

            int offset = str.IndexOf(value);
            for (int i = 0; i < nth; i++)
            {
                if (offset == -1) return -1;
                offset = str.IndexOf(value, offset + 1);
            }

            return offset;
        }

        /// <summary>
        /// Save the file with an auto-generated name based on system time. Shortcut Ctrl + S
        /// </summary>
        private void QuickSave()
        {
            if (currentlyLoaded == "")
                currentlyLoaded = Path.Combine(saveDirectory, DateTime.Now.ToString("yyyy-MM-dd_HHmmss") + ".entry");
            savedText = contentBox.Text;
            savedTitle = titleBox.Text;
            SaveFile(currentlyLoaded);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuickSave();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.InitialDirectory = saveDirectory;
            saveFile.Filter = "Journal Entry|*.entry";
            saveFile.Title = "Save Entry";
            DialogResult result = saveFile.ShowDialog();

            if (result == DialogResult.OK)
            {
                SaveFile(saveFile.FileName);
            }
        }

        private void colorChoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetColor(colorChoice.SelectedItem.ToString());
        }

        /// <summary>
        /// Switch over to the previous entry in the entries list supplied in constructor, if the entry is opened as read only
        /// </summary>
        private void previousEntry_Click(object sender, EventArgs e)
        {
            LoadFile(entries[entriesList.IndexOf(currentlyLoaded) - 1]);
            currentlyLoaded = entries[entriesList.IndexOf(currentlyLoaded) - 1];
            previousEntry.Enabled = (entriesList.IndexOf(currentlyLoaded) != 0);
            nextEntry.Enabled = (entriesList.IndexOf(currentlyLoaded) != entriesList.Count - 1);
        }

        /// <summary>
        /// Switch over to the next entry in the entries list supplied in constructor, if the entry is opened as read only
        /// </summary>
        private void nextEntry_Click(object sender, EventArgs e)
        {
            LoadFile(entries[entriesList.IndexOf(currentlyLoaded) + 1]);
            currentlyLoaded = entries[entriesList.IndexOf(currentlyLoaded) + 1];
            previousEntry.Enabled = (entriesList.IndexOf(currentlyLoaded) != 0);
            nextEntry.Enabled = (entriesList.IndexOf(currentlyLoaded) != entriesList.Count - 1);
        }

        private void preferencesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new PreferencesWin().Show();
        }

        /// <summary>
        /// Keyboard shortcut handler for bold, italics, underline, and save
        /// </summary>
        private void OnKeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (readOnly) return;
            if (Keyboard.IsKeyDown(Key.S) && (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl)))
            {
                QuickSave();
            }
            if (Keyboard.IsKeyDown(Key.B) && (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl)))
            {
                contentBox.SelectedText = "[b]" + contentBox.SelectedText + "[/b]";
            }
            if (Keyboard.IsKeyDown(Key.I) && (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl)))
            {
                contentBox.SelectedText = "[i]" + contentBox.SelectedText + "[/i]";
            }
            if (Keyboard.IsKeyDown(Key.U) && (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl)))
            {
                contentBox.SelectedText = "[u]" + contentBox.SelectedText + "[/u]";
            }
        }

        /// <summary>
        /// If closing an entry with unsaved changes, a dialog will pop up asking whether changes want to be saved
        /// </summary>
        /// <returns>[char]: 'y' to save data and close, 'n' to discard and close, 'c' to not close</returns>
        private char AcceptDiscardChanges()
        {
            // i'll find a way to check for different tags later
            if (!savedText.Equals(contentBox.Text) || !savedTitle.Equals(titleBox.Text))
            {
                DialogResult dr = MessageBox.Show("You have made changes to your entry since your last save. Unsaved edits will be lost.\n\nSave changes?", "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (dr == DialogResult.Cancel) return 'c';
                else if (dr == DialogResult.No) return 'n';
                else if (dr == DialogResult.Yes) return 'y';
            }
            return 'n'; // no changes made
        }

        /// <summary>
        /// Handle closing operation
        /// </summary>
        private void OnClose(object sender, FormClosingEventArgs e)
        {
            if (readOnly) return;

            char discardChangesDialog = AcceptDiscardChanges();

            if (discardChangesDialog == 'y') QuickSave();
            else if (discardChangesDialog == 'c') e.Cancel = true;
        }

        /// <summary>
        /// Enable/disable add tag button depending on if the selected tag is already an included tag
        /// </summary>
        private void ToggleButton()
        {
            addTag.Enabled = true;
            if (tagsList.SelectedItem == null) return;
            foreach (ListViewItem tag in currentTags.Items)
            {
                if (tag.Text.Equals(tagsList.SelectedItem.ToString()))
                {
                    addTag.Enabled = false;
                    break;
                }
            }
        }

        /// <summary>
        /// Add a tag to the entry
        /// </summary>
        private void addTag_Click(object sender, EventArgs e)
        {
            if (tagsList.SelectedIndex == -1) return;
            string rawText = File.ReadAllText(tagFiles[tagsList.SelectedIndex]);
            string name = SubstringFromTo(rawText, 0, rawText.IndexOf("<COLOR>"));
            string color = SubstringFromTo(rawText, rawText.IndexOf("<COLOR>") + 7, rawText.IndexOf("</COLOR>"));
            string red = SubstringFromTo(color, 0, indexOfNth(color, "/", 0));
            string green = SubstringFromTo(color, indexOfNth(color, "/", 0) + 1, indexOfNth(color, "/", 1));
            string blue = SubstringFromTo(color, indexOfNth(color, "/", 1) + 1, color.Length);

            currentTags.Items.Insert(0, name);
            currentTags.Items[0].BackColor = Color.FromArgb(Int32.Parse(red), Int32.Parse(green), Int32.Parse(blue));
            ToggleButton();
        }

        private void tagsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ToggleButton();
        }

        private void tagDoubleClick(object sender, EventArgs e)
        {
            if (readOnly) return;
            currentTags.Items.Remove(currentTags.SelectedItems[0]);
            ToggleButton();
        }

        /// <summary>
        /// Handle tab key; adds in spaces to entry
        /// </summary>
        /// <returns>[bool]: false so the program doesn't switch components</returns>
        protected override bool ProcessTabKey(bool forward)
        {
            if (!contentBox.Focused) return false;
            contentBox.SelectedText = contentBox.SelectedText + "   ";
            return false;
        }

        /// <summary>
        /// If content is changed, add a * to the title to denote unsaved changes; remove it if entries restored to last-saved state
        /// </summary>
        private void OnContentChange(object sender, EventArgs e)
        {
            if (!savedText.Equals(contentBox.Text))
            {
                if (Text.Substring(Text.Length - 1) != "*")
                {
                    Text += "*";
                }
            } else
            {
                if (Text.Substring(Text.Length - 1) == "*")
                {
                    Text = Text.Substring(0, Text.Length - 1);
                }
            }
        }
    }
}
