using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Journal_Manager
{
    public partial class EntryCreator : Form
    {
        static readonly string DATA_FILE = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\JournalManager\\data.txt";
        string saveDirectory = File.ReadLines(DATA_FILE).ElementAtOrDefault(0); // first line
        int fontSize = Int32.Parse(File.ReadLines(DATA_FILE).ElementAtOrDefault(1));
        string fontName = File.ReadLines(DATA_FILE).ElementAtOrDefault(2);

        string color = "255/255/255";
        string currentlyLoaded;
        string[] entries;
        List<string> entriesList;
        bool readOnly = false;
        public EntryCreator(bool readOnly, string toLoad = "", string[] otherFiles = null)
        {
            InitializeComponent();

            string font = File.ReadLines(DATA_FILE).ElementAtOrDefault(2);
            if (!font.Equals("X"))
            {
                contentBox.Font = new Font(fontName, fontSize);
            } else
            {
                contentBox.Font = new Font("Microsoft Sans Serif", fontSize);
            }
            this.readOnly = readOnly;

            if (readOnly)
            {
                menuStrip1.Visible = false;
                contentBox.ReadOnly = true;
                titleBox.ReadOnly = true;
                colorChoice.Enabled = false;

                titleLabel.Text = "Journal Title";
                contentLabel.Text = "Content";

                Text = "View Entry";
                currentlyLoaded = toLoad;
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
            }
        }
        private void SaveFile(string saveAs)
        {
            try
            {
                File.WriteAllText(saveAs, contentBox.Text);
                File.AppendAllText(saveAs, "<TITLE>" + titleBox.Text + "</TITLE>");
                File.AppendAllText(saveAs, "<COLOR>" + color + "</COLOR>");
                MessageBox.Show("Saved as " + saveAs, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while saving: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadFile(String toLoad)
        {
            try
            {
                string rawText = File.ReadAllText(toLoad);
                string contents = SubstringFromTo(rawText, 0, rawText.IndexOf("<TITLE>"));
                string title = SubstringFromTo(rawText, rawText.IndexOf("<TITLE>") + 7, rawText.IndexOf("</TITLE>"));
                color = SubstringFromTo(rawText, rawText.IndexOf("<COLOR>") + 7, rawText.IndexOf("</COLOR>"));

                contentBox.Text = contents;
                titleBox.Text = title.Equals("None") ? "" : title;
                GetColor();

                if (readOnly) // format text only if not editing
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
                        new string[] { "\r\n", "\r", "\n" },
                        StringSplitOptions.None
                    );

                    string textToRtf = "";
                    contentBox.Rtf = @"{\rtf1\ansi ";
                    foreach (string line in lines)
                    {
                        if (line.Equals(""))
                        {
                            textToRtf += @" \par\par ";
                        }
                        else textToRtf += line;
                        // contentBox.Rtf = contentBox.Rtf + contents;
                    }
                    contentBox.Rtf = @"{\rtf1\ansi " + textToRtf + "}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading: " + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
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
        }
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
        public static int indexOfNth(string str, string value, int nth = 0)
        {
            if (nth < 0)
                throw new ArgumentException("Can not find a negative index of substring in string. Must start with 0");

            int offset = str.IndexOf(value);
            for (int i = 0; i < nth; i++)
            {
                if (offset == -1) return -1;
                offset = str.IndexOf(value, offset + 1);
            }

            return offset;
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
                LoadFile(loadFile.FileName);
            }
        }

        private void colorChoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetColor(colorChoice.SelectedItem.ToString());
        }

        private void previousEntry_Click(object sender, EventArgs e)
        {
            LoadFile(entries[entriesList.IndexOf(currentlyLoaded) - 1]);
            currentlyLoaded = entries[entriesList.IndexOf(currentlyLoaded) - 1];
            previousEntry.Enabled = (entriesList.IndexOf(currentlyLoaded) != 0);
            nextEntry.Enabled = (entriesList.IndexOf(currentlyLoaded) != entriesList.Count - 1);
        }

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
    }
}
