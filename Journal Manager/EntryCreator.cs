using System;
using System.IO;
using System.Windows.Forms;

namespace Journal_Manager
{
    public partial class EntryCreator : Form
    {
        string saveDirectory = "C:\\Users\\sbrug\\Documents\\journaltest"; // change this later
        public EntryCreator()
        {
            InitializeComponent();
        }
        private void SaveFile(string saveAs)
        {
            try
            {
                File.WriteAllText(saveAs, richTextBox1.Text);
                File.AppendAllText(saveAs, "[TITLE]" + textBox1.Text + "[/TITLE]");
                MessageBox.Show("Saved as " + saveAs, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while saving: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public string SubstringFromTo(string str, int from, int to)
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
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFile(Path.Combine(saveDirectory, DateTime.Now.ToString("yyyyMMdd-HHmmss") + ".entry"));
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "Journal Entry|*.entry"; // what to display on the file dialog
            saveFile.Title = "Save Entry";
            DialogResult result = saveFile.ShowDialog();

            if (result == DialogResult.OK)
            {
                SaveFile(saveFile.FileName);
            }
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog loadFile = new OpenFileDialog();
            loadFile.Filter = "Journal Entry| *.entry"; // what to display on the file dialog
            loadFile.Title = "Load Entry";
            DialogResult result = loadFile.ShowDialog();

            if (result == DialogResult.OK)
            {
                try
                {
                    string rawText = File.ReadAllText(loadFile.FileName);
                    string contents = SubstringFromTo(rawText, 0, rawText.IndexOf("[TITLE]"));
                    string title = SubstringFromTo(rawText, rawText.IndexOf("[TITLE]") + 7, rawText.IndexOf("[/TITLE]"));

                    richTextBox1.Text = contents;
                    textBox1.Text = title.Equals("None") ? "" : title;

                    MessageBox.Show("File loaded!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                } catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while loading: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
        }
    }
}
