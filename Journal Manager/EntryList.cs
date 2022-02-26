using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Journal_Manager
{
    public partial class EntryList : Form
    {
        static readonly string DATA_FILE = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\JournalManager\\data.txt";
        string saveDirectory = File.ReadLines(DATA_FILE).ElementAtOrDefault(0); // first line
        List<string> entryNames = new List<string>();
        string[] entries;
        public EntryList()
        {
            InitializeComponent();
            viewButton.Enabled = listView1.SelectedIndices.Count != 0;
            editButton.Enabled = listView1.SelectedIndices.Count != 0;
            RefreshFiles();
        }
        private void RefreshFiles()
        {
            listView1.Items.Clear();
            entryNames.Clear();
            entries = Directory.GetFiles(saveDirectory);
            foreach (string entry in entries)
            {
                if (!Path.GetExtension(entry).Equals(".entry")) return;
                string rawText = File.ReadAllText(entry);
                string title = SubstringFromTo(rawText, rawText.IndexOf("<TITLE>") + 7, rawText.IndexOf("</TITLE>"));
                string color = SubstringFromTo(rawText, rawText.IndexOf("<COLOR>") + 7, rawText.IndexOf("</COLOR>"));
                string red = SubstringFromTo(color, 0, indexOfNth(color, "/", 0));
                string green = SubstringFromTo(color, indexOfNth(color, "/", 0) + 1, indexOfNth(color, "/", 1));
                string blue = SubstringFromTo(color, indexOfNth(color, "/", 1) + 1, color.Length);

                listView1.Items.Insert(0, title.Equals("None") ? File.GetCreationTime(entry).ToString() : title); // set display to title, otherwise file creation time
                listView1.Items[0].BackColor = Color.FromArgb(Int32.Parse(red), Int32.Parse(green), Int32.Parse(blue));
                listView1.Items[0].ToolTipText = "Created on " + File.GetCreationTime(entry).ToString();
                entryNames.Insert(0, entry);
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
        private void viewButton_Click(object sender, EventArgs e) // this goes for both the view button click and a double click on the list
        {
            try
            {
                new EntryCreator(true, entryNames[listView1.SelectedIndices[0]], entries).Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sorry, an error occured while loading: " + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            try
            {
                new EntryCreator(false, entryNames[listView1.SelectedIndices[0]]).Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sorry, an error occured while loading: " + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            RefreshFiles();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            viewButton.Enabled = listView1.SelectedIndices.Count != 0;
            editButton.Enabled = listView1.SelectedIndices.Count != 0;
        }
    }
}
