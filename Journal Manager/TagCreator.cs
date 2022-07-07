using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Journal_Manager
{
    public partial class TagCreator : Form
    {
        static readonly string DATA_FILE = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\JournalManager\\data.txt";
        string saveDirectory = File.ReadLines(DATA_FILE).ElementAtOrDefault(0); // first line

        string name;
        string color;
        public TagCreator()
        {
            InitializeComponent();
        }

        private void pickButton_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                colorBox.BackColor = colorDialog.Color;
                color = colorDialog.Color.R + "/" + colorDialog.Color.G + "/" + colorDialog.Color.B;
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            name = nameBox.Text;

            if (name == "" || color == null)
            {
                MessageBox.Show("One or more fields are empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } else
            {
                string[] tags;
                string tagsDir = saveDirectory + "\\tags";
                if (!Directory.Exists(tagsDir)) Directory.CreateDirectory(tagsDir);

                string saveAs = tagsDir + "\\" + name + ".tag";
                if (File.Exists(saveAs))
                {
                    MessageBox.Show("A tag with that name already exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                } else
                {
                    File.WriteAllText(saveAs, name);
                    File.AppendAllText(saveAs, "<COLOR>" + color + "</COLOR>");
                    MessageBox.Show("Saved tag as " + saveAs, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Dispose();
                }
            }
        }
    }
}
