using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Journal_Manager
{
    public partial class MainMenu : Form
    {
        static readonly string DATA_FILE = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\JournalManager\\data.txt";
        string saveDirectory = File.ReadLines(DATA_FILE).ElementAtOrDefault(0) + "\\tags"; // first line

        public MainMenu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(saveDirectory))
            {
                Directory.CreateDirectory(saveDirectory);
            }
            new EntryCreator(false).Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new EntryList().Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new PreferencesWin().Show();
        }
    }
}
