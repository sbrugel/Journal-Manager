using System;
using System.Windows.Forms;

namespace Journal_Manager
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
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
