using System;
using System.Data;
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
        public Search()
        {
            InitializeComponent();
            radioKeyword.Checked = true;
            label2.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            entries = Directory.GetFiles(saveDirectory);
            int filesWithHits = 0;
            resultsTable.Rows.Clear();
            searchButton.Enabled = false;
            if (radioKeyword.Checked)
            {
                foreach (string entry in entries)
                {
                    if (!Path.GetExtension(entry).Equals(".entry")) return;
                    string rawText = File.ReadAllText(entry);
                    string contents = SubstringFromTo(rawText, 0, rawText.IndexOf("<TITLE>"));
                    string title = SubstringFromTo(rawText, rawText.IndexOf("<TITLE>") + 7, rawText.IndexOf("</TITLE>"));

                    if (contents.IndexOf(queryTextBox.Text, StringComparison.CurrentCultureIgnoreCase) != -1)
                    {
                        filesWithHits++;
                        resultsTable.Rows.Add(new object[] { title, entry });
                    }
                    label2.Text = "Found query in " + filesWithHits + " entr" + (filesWithHits == 1 ? "y" : "ies");
                }
            } else if (radioTag.Checked)
            {
                Thread t = new Thread(delegate()
                {
                    foreach (string entry in entries)
                    {
                        if (!Path.GetExtension(entry).Equals(".entry")) return;
                        string rawText = File.ReadAllText(entry);
                        string title = SubstringFromTo(rawText, rawText.IndexOf("<TITLE>") + 7, rawText.IndexOf("</TITLE>"));
                        string tags = SubstringFromTo(rawText, rawText.IndexOf("<TAGS>") + 6, rawText.IndexOf("</TAGS>"));
                        string[] tagsList = tags.Split(',');
                        for (int i = 0; i < tagsList.Length; i++)
                        {
                            tagsList[i] = tagsList[i].ToLower();
                        }

                        if (tagsList.Contains(queryTextBox.Text.ToLower()))
                        {
                            filesWithHits++;
                            resultsTable.Invoke(new MethodInvoker(delegate { resultsTable.Rows.Add(new object[] { title, entry });  }));
                        }
                    }
                    label2.Invoke(new MethodInvoker(delegate { label2.Text = "Found query in " + filesWithHits + " entr" + (filesWithHits == 1 ? "y" : "ies"); }));
                    searchButton.Invoke(new MethodInvoker(delegate { searchButton.Enabled = true; }));
                });
                t.Start();
            } else if (radioNoTag.Checked)
            {
                Thread t = new Thread(delegate ()
                {
                    foreach (string entry in entries)
                    {
                        if (!Path.GetExtension(entry).Equals(".entry")) return;
                        string rawText = File.ReadAllText(entry);
                        string title = SubstringFromTo(rawText, rawText.IndexOf("<TITLE>") + 7, rawText.IndexOf("</TITLE>"));
                        string tags = SubstringFromTo(rawText, rawText.IndexOf("<TAGS>") + 6, rawText.IndexOf("</TAGS>"));
                        string[] tagsList = tags.Split(',');
                        for (int i = 0; i < tagsList.Length; i++)
                        {
                            tagsList[i] = tagsList[i].ToLower();
                        }

                        if (!tagsList.Contains(queryTextBox.Text.ToLower()))
                        {
                            filesWithHits++;
                            resultsTable.Invoke(new MethodInvoker(delegate { resultsTable.Rows.Add(new object[] { title, entry }); }));
                        }
                    }
                    label2.Invoke(new MethodInvoker(delegate { label2.Text = "Found query in " + filesWithHits + " entr" + (filesWithHits == 1 ? "y" : "ies"); }));
                    searchButton.Invoke(new MethodInvoker(delegate { searchButton.Enabled = true; }));
                });
                t.Start();
            }
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
    }
}
