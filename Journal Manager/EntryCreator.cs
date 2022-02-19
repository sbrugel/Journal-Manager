using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Journal_Manager
{
    public partial class EntryCreator : Form
    {
        static readonly string DATA_FILE = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\JournalManager\\data.txt";
        string saveDirectory = File.ReadLines(DATA_FILE).ElementAtOrDefault(0); // first line
        public EntryCreator(bool readOnly, string toLoad = "")
        {
            InitializeComponent();
            if (readOnly)
            {
                menuStrip1.Visible = false;
                contentBox.ReadOnly = true;
                titleBox.ReadOnly = true;

                titleLabel.Text = "Journal Title";
                contentLabel.Text = "Content";
            }

            if (!toLoad.Equals(""))
            {
                try
                {
                    string rawText = File.ReadAllText(toLoad);
                    string contents = SubstringFromTo(rawText, 0, rawText.IndexOf("[TITLE]"));
                    string title = SubstringFromTo(rawText, rawText.IndexOf("[TITLE]") + 7, rawText.IndexOf("[/TITLE]"));

                    contentBox.Text = contents;
                    titleBox.Text = title.Equals("None") ? "" : title;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while loading: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void SaveFile(string saveAs)
        {
            try
            {
                File.WriteAllText(saveAs, contentBox.Text);
                File.AppendAllText(saveAs, "[TITLE]" + titleBox.Text + "[/TITLE]");
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
            SaveFile(Path.Combine(saveDirectory, DateTime.Now.ToString("yyyy-MM-dd_HHmmss") + ".entry"));
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

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog loadFile = new OpenFileDialog();
            loadFile.InitialDirectory = saveDirectory;
            loadFile.Filter = "Journal Entry| *.entry";
            loadFile.Title = "Load Entry";
            DialogResult result = loadFile.ShowDialog();

            if (result == DialogResult.OK)
            {
                try
                {
                    string rawText = File.ReadAllText(loadFile.FileName);
                    string contents = SubstringFromTo(rawText, 0, rawText.IndexOf("[TITLE]"));
                    string title = SubstringFromTo(rawText, rawText.IndexOf("[TITLE]") + 7, rawText.IndexOf("[/TITLE]"));

                    contentBox.Text = contents;
                    titleBox.Text = title.Equals("None") ? "" : title;

                    MessageBox.Show("File loaded!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                } catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while loading: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
