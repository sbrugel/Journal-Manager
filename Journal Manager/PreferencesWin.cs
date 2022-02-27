using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Journal_Manager
{
    public partial class PreferencesWin : Form
    {
        static readonly string DATA_FILE = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\JournalManager\\data.txt";
        int fsize;
        string fname;
        public PreferencesWin()
        {
            InitializeComponent();
            journalDirInput.Text = File.ReadLines(DATA_FILE).ElementAtOrDefault(0);
            fontNameInput.Text = File.ReadLines(DATA_FILE).ElementAtOrDefault(2) + ", Size " + File.ReadLines(DATA_FILE).ElementAtOrDefault(1);
            fname = File.ReadLines(DATA_FILE).ElementAtOrDefault(2);
            fsize = Int32.Parse(File.ReadLines(DATA_FILE).ElementAtOrDefault(1));
        }

        private void journalDirButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();
            DialogResult result = folder.ShowDialog();
            if (result == DialogResult.OK)
            {
                string entriesDir = folder.SelectedPath;
                journalDirInput.Text = entriesDir;
            }
        }

        private void fontNameButton_Click(object sender, EventArgs e)
        {
            FontDialog loadFont = new FontDialog();
            loadFont.ShowEffects = false;
            DialogResult result = loadFont.ShowDialog();

            fname = loadFont.Font.Name;
            fsize = (int)loadFont.Font.Size;

            fontNameInput.Text = fname + ", Size " + fsize;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                string dir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\JournalManager";
                string path = dir + "\\data.txt";
                File.Delete(path);
                using (StreamWriter sw = File.CreateText(path))
                {
                    if (!journalDirInput.Text.Equals("") && !fontNameInput.Text.Equals(""))
                    {
                        sw.WriteLine(journalDirInput.Text);
                        sw.WriteLine(fsize);
                        sw.WriteLine(fname);

                        MessageBox.Show("Settings saved!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Hide();
                        Close();
                    } else
                    {
                        MessageBox.Show("One of your fields is empty, please fill it out before saving.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            } catch (Exception ex)
            {
                MessageBox.Show("An error occured while saving your settings: " + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
