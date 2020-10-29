using System;
using System.IO;
using System.Windows.Forms;

namespace ExcuseManager
{
    public partial class Form1 : Form
    {

        private IExcuse excuse;
        // To do: Replace with call to Factory
        Random randomFile = new Random();
        bool formChanged = false;
        private string selectedFolder = "";
        private const string filter = "Excuse files (*.excuse)|*.excuse";
        public Form1()
        {
            InitializeComponent();
            excuse = Factory.CreateExcuse();
            // Set LastUsed to default val (today's date)
            excuse.LastUsed = lastUsed.Value;
        }

        // Handle text changed events
        private void UpdateForm(bool changed)
        {
            // To do: Remove * from recently opened files
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
            openFolderDialog.SelectedPath = selectedFolder;
            if (openFolderDialog.ShowDialog() == DialogResult.OK)
            {
                selectedFolder = openFolderDialog.SelectedPath;
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
            saveFileDialog.InitialDirectory = selectedFolder;
            saveFileDialog.Filter = filter;
            saveFileDialog.FileName = description.Text + ".excuse";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                excuse.Save(saveFileDialog.FileName);
                UpdateForm(false);
                MessageBox.Show("Excuse saved");
            }
        }

        // If values haven't changed, display open file dialog and set properties if a file is chosen
        // Otherwise, call CheckChanged
        private void open_Click(object sender, EventArgs e)
        {
            if (CheckChanged())
            {
                openFileDialog.InitialDirectory = selectedFolder;
                openFileDialog.Filter = filter;
                openFileDialog.FileName = description.Text + ".excuse";
                DialogResult result = openFileDialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    excuse = Factory.CreateExcuse(openFileDialog.FileName);
                    UpdateForm(false);
                }
            }
        }

        // Ask user if they want to save changes, or go back to parent window
        private bool CheckChanged()
        {
            if (formChanged)
            {
                DialogResult result = MessageBox.Show("The current excuse has not been saved. Continue?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.No)
                {
                    return false;
                }
            }
            return true;
        }

        // Opens random file from selected folder field and populate fields
        // Heavy lifting is done in the constructor
        private void random_Click(object sender, EventArgs e)
        {
            if (CheckChanged())
            {
                excuse = Factory.CreateExcuse(randomFile, selectedFolder);
                UpdateForm(false);
            }
        }
    }
}
