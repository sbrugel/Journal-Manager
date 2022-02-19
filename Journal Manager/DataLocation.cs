using System;
using System.IO;
using System.Windows.Forms;

namespace Journal_Manager
{
    public partial class DataLocation : Form
    {
        public DataLocation()
        {
            InitializeComponent();
            button2.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            DialogResult result = folder.ShowDialog();
            if (result == DialogResult.OK)
            {
                button2.Enabled = true; //unlock button if a directory is chosen
                string entriesDir = folder.SelectedPath;
                textBox2.Text = entriesDir;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string dir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\JournalManager";
            Directory.CreateDirectory(dir);
            string path = dir + "\\data.txt";
            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(textBox2.Text);
                }
            }
            Dispose(); // change later to main menu
        }
    }
}
