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
    public partial class EntryList : Form
    {
        static readonly string DATA_FILE = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\JournalManager\\data.txt";
        string saveDirectory = File.ReadLines(DATA_FILE).ElementAtOrDefault(0); // first line
        List<string> entryNames = new List<string>();
        public EntryList()
        {
            InitializeComponent();
            string[] entries = Directory.GetFiles(saveDirectory);
            foreach (string entry in entries)
            {
                string rawText = File.ReadAllText(entry);
                string title = SubstringFromTo(rawText, rawText.IndexOf("[TITLE]") + 7, rawText.IndexOf("[/TITLE]"));

                listView1.Items.Add(title.Equals("None") ? File.GetCreationTime(entry).ToString() : title); // set display to title, otherwise file creation time
                entryNames.Add(entry);
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                new EntryCreator(true, entryNames[listView1.SelectedIndices[0]]).Show();
            } catch (Exception ex)
            {
                MessageBox.Show("You didn't select an entry!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                new EntryCreator(false, entryNames[listView1.SelectedIndices[0]]).Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("You didn't select an entry!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
