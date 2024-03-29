﻿using System;
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
                button2.Enabled = true; // unlock button if a directory is chosen
                textBox2.Text = folder.SelectedPath;
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
                    sw.WriteLine("8");
                    sw.WriteLine("Microsoft Sans Serif");
                }
            }
            SetVisibleCore(false);
            new MainMenu().Show();
        }
    }
}
