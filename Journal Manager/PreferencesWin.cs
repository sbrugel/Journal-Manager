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
                bool changed = false;
                using (StreamWriter sw = File.CreateText(path))
                {
                    if (!journalDirInput.Text.Equals(""))
                    {
                        sw.WriteLine(journalDirInput.Text);
                        changed = true;
                    }
                    if (!fontNameInput.Text.Equals(""))
                    {
                        sw.WriteLine(fsize);
                        sw.WriteLine(fname);
                        changed = true;
                    }
                    if (!changed)
                    {
                        MessageBox.Show("No changes were made to your settings.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    } else
                    {
                        MessageBox.Show("Settings saved!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Hide();
                        Close();
                    }
                }
            } catch (Exception ex)
            {
                MessageBox.Show("An error occured while saving your settings: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
