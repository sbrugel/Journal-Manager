using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Journal_Manager
{
    public partial class TagList : Form
    {
        static readonly string DATA_FILE = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\JournalManager\\data.txt";
        string saveDirectory = File.ReadLines(DATA_FILE).ElementAtOrDefault(0) + "\\tags"; // first line
        List<string> tagNames = new List<string>();
        string[] tags;

        public TagList()
        {
            InitializeComponent();
            RefreshTags();
        }

        private void RefreshTags()
        {
            listView1.Items.Clear();
            tagNames.Clear();
            tags = Directory.GetFiles(saveDirectory);
            foreach (string tag in tags)
            {
                if (!Path.GetExtension(tag).Equals(".tag")) return;
                string rawText = File.ReadAllText(tag);
                string name = SubstringFromTo(rawText, 0, rawText.IndexOf("<COLOR>"));
                string color = SubstringFromTo(rawText, rawText.IndexOf("<COLOR>") + 7, rawText.IndexOf("</COLOR>"));
                string red = SubstringFromTo(color, 0, indexOfNth(color, "/", 0));
                string green = SubstringFromTo(color, indexOfNth(color, "/", 0) + 1, indexOfNth(color, "/", 1));
                string blue = SubstringFromTo(color, indexOfNth(color, "/", 1) + 1, color.Length);

                listView1.Items.Insert(0, name);
                listView1.Items[0].BackColor = Color.FromArgb(Int32.Parse(red), Int32.Parse(green), Int32.Parse(blue));
                listView1.Items[0].ToolTipText = Path.GetFullPath(tag);
                tagNames.Insert(0, tag);
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

        private void newTagButton_Click(object sender, EventArgs e)
        {
            new TagCreator().Show();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure you want to delete " + tagNames[listView1.SelectedIndices[0]] + "? This cannot be undone.", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                File.Delete(tagNames[listView1.SelectedIndices[0]]);
                RefreshTags();
            }
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            RefreshTags();
        }
    }
}
