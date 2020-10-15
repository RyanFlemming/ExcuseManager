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
        Excuse excuse;
        bool formChanged = false;
        public Form1()
        {
            InitializeComponent();
            excuse = new Excuse();
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
    }
}
