using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Journal_Manager
{
    public partial class Search : Form
    {
        static readonly string DATA_FILE = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\JournalManager\\data.txt";
        string saveDirectory = File.ReadLines(DATA_FILE).ElementAtOrDefault(0); // first line
        string[] entries;

        string[] tags;
        public Search()
        {
            InitializeComponent();
            radioKeyword.Checked = true;
            label2.Text = "";

            queryTextBox.Enabled = true;
            availableTags.Enabled = false;

            string tagsDirectory = saveDirectory + "\\tags";
            tags = Directory.GetFiles(tagsDirectory);
            foreach (string tag in tags)
            {
                if (!Path.GetExtension(tag).Equals(".tag")) return;
                string rawText = File.ReadAllText(tag);
                string name = SubstringFromTo(rawText, 0, rawText.IndexOf("<COLOR>"));

                availableTags.Items.Add(name);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            entries = Directory.GetFiles(saveDirectory);
            int filesWithHits = 0;
            resultsTable.Rows.Clear();
            searchButton.Enabled = false;

            Thread t = new Thread(delegate ()
            {
                foreach (string entry in entries)
                {
                    if (!Path.GetExtension(entry).Equals(".entry")) return;
                    string rawText = File.ReadAllText(entry);
                    string contents = SubstringFromTo(rawText, 0, rawText.IndexOf("<TITLE>"));
                    string tags = SubstringFromTo(rawText, rawText.IndexOf("<TAGS>") + 6, rawText.IndexOf("</TAGS>"));
                    string title = SubstringFromTo(rawText, rawText.IndexOf("<TITLE>") + 7, rawText.IndexOf("</TITLE>"));
                    string color = SubstringFromTo(rawText, rawText.IndexOf("<COLOR>") + 7, rawText.IndexOf("</COLOR>"));
                    string red = SubstringFromTo(color, 0, indexOfNth(color, "/", 0));
                    string green = SubstringFromTo(color, indexOfNth(color, "/", 0) + 1, indexOfNth(color, "/", 1));
                    string blue = SubstringFromTo(color, indexOfNth(color, "/", 1) + 1, color.Length);

                    string[] tagsList = tags.Split(',');
                    for (int i = 0; i < tagsList.Length; i++)
                    {
                        tagsList[i] = tagsList[i].ToLower();
                    }

                    bool matchingEntry = false;
                    if (radioKeyword.Checked)
                    {
                        matchingEntry = contents.IndexOf(queryTextBox.Text, StringComparison.CurrentCultureIgnoreCase) != -1;
                    }
                    else if (radioTag.Checked)
                    {
                        availableTags.Invoke(new MethodInvoker(delegate { matchingEntry = tagsList.Contains(availableTags.SelectedItem.ToString().ToLower()); }));
                    }
                    else if (radioNoTag.Checked)
                    {
                        availableTags.Invoke(new MethodInvoker(delegate { matchingEntry = !tagsList.Contains(availableTags.SelectedItem.ToString().ToLower()); }));
                    }

                    if (matchingEntry)
                    {
                        filesWithHits++;
                        resultsTable.Invoke(new MethodInvoker(delegate { resultsTable.Rows.Add(new object[] { title, entry }); }));
                        resultsTable.Invoke(new MethodInvoker(delegate { resultsTable.Rows[filesWithHits - 1].DefaultCellStyle.BackColor = Color.FromArgb(Int32.Parse(red), Int32.Parse(green), Int32.Parse(blue)); }));
                    }
                    label2.Invoke(new MethodInvoker(delegate { label2.Text = "Found query in " + filesWithHits + " entr" + (filesWithHits == 1 ? "y" : "ies"); }));
                }
                searchButton.Invoke(new MethodInvoker(delegate { searchButton.Enabled = true; }));
            });
            t.Start();
        }

        /// <summary>
        /// Finds substring between indices (if that's how the plural is spelt!)
        /// </summary>
        /// <param name="str">The string to search.</param>
        /// <param name="from">The starting index of the string to search</param>
        /// <param name="to">The ending index of the string, stop searching here</param>
        /// <returns>The substring of str from the start to end index specified by the code</returns>
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

        private void OnRowClick(object sender, DataGridViewCellEventArgs e)
        {
            new EntryCreator(true, resultsTable.Rows[e.RowIndex].Cells[1].Value.ToString(), entries).Show();
        }

        private void radioKeyword_CheckedChanged(object sender, EventArgs e)
        {
            queryTextBox.Enabled = true;
            availableTags.Enabled = false;
        }

        private void radioTag_CheckedChanged(object sender, EventArgs e)
        {
            queryTextBox.Enabled = false;
            availableTags.Enabled = true;
        }

        private void radioNoTag_CheckedChanged(object sender, EventArgs e)
        {
            queryTextBox.Enabled = false;
            availableTags.Enabled = true;
        }
    }
}
