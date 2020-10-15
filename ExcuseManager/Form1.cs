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

namespace ExcuseManager
{
    public partial class Form1 : Form
    {
        private Excuse excuse = new Excuse();
        bool formChanged = false;
        private string selectedFolder = "";
        public Form1()
        {
            InitializeComponent();
            // Set LastUsed to default val (today's date)
            excuse.LastUsed = lastUsed.Value;
        }

        // Handle text changed events

        private void UpdateForm(bool changed)
        {
            if (!changed)
            {
                this.description.Text = excuse.Description;
                this.results.Text = excuse.Results;
                this.lastUsed.Value = excuse.LastUsed;
                if (!String.IsNullOrEmpty(excuse.ExcusePath))
                {
                    fileDate.Text = File.GetLastWriteTime(excuse.ExcusePath).ToString();
                    this.Text = "Excuse Manager";
                } 
            }
            else
            {
                this.Text = "Excuse Manager*";
                formChanged = changed;
            }
        }

        private void description_TextChanged(object sender, EventArgs e)
        {
            excuse.Description = description.Text;
            UpdateForm(true);
        }

        private void results_TextChanged(object sender, EventArgs e)
        {
            excuse.Results = results.Text;
            UpdateForm(true);
        }

        private void lastUsed_ValueChanged(object sender, EventArgs e)
        {
            excuse.LastUsed = lastUsed.Value;
            UpdateForm(true);
        }

        // Set folder path for saving
        private void folder_Click(object sender, EventArgs e)
        {
            openFolder.SelectedPath = selectedFolder;
            if (openFolder.ShowDialog() == DialogResult.OK)
            {
                selectedFolder = openFolder.SelectedPath;
                save.Enabled = true;
                open.Enabled = true;
                random.Enabled = true;
                folder.Enabled = false;
            }
        }

        // Attempt to save file if input fields have been filled
        private void save_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(description.Text) || String.IsNullOrEmpty(results.Text))
            {
                MessageBox.Show("Please fill both Excuse and Results", "Unable to save", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            saveFile.InitialDirectory = selectedFolder;
            saveFile.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFile.FileName = description.Text + ".txt";
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                excuse.Save(saveFile.FileName);
                UpdateForm(false);
                MessageBox.Show("Excuse saved");
            }
        }
    }
}
