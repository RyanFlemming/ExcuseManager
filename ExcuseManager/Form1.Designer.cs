namespace ExcuseManager
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.excuseLabel = new System.Windows.Forms.Label();
            this.resultsLabel = new System.Windows.Forms.Label();
            this.lastUsedLabel = new System.Windows.Forms.Label();
            this.dateLabel = new System.Windows.Forms.Label();
            this.fileDate = new System.Windows.Forms.Label();
            this.description = new System.Windows.Forms.TextBox();
            this.results = new System.Windows.Forms.TextBox();
            this.folder = new System.Windows.Forms.Button();
            this.save = new System.Windows.Forms.Button();
            this.open = new System.Windows.Forms.Button();
            this.random = new System.Windows.Forms.Button();
            this.lastUsed = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // excuseLabel
            // 
            this.excuseLabel.AutoSize = true;
            this.excuseLabel.Location = new System.Drawing.Point(12, 9);
            this.excuseLabel.Name = "excuseLabel";
            this.excuseLabel.Size = new System.Drawing.Size(42, 13);
            this.excuseLabel.TabIndex = 0;
            this.excuseLabel.Text = "Excuse";
            // 
            // resultsLabel
            // 
            this.resultsLabel.AutoSize = true;
            this.resultsLabel.Location = new System.Drawing.Point(12, 34);
            this.resultsLabel.Name = "resultsLabel";
            this.resultsLabel.Size = new System.Drawing.Size(42, 13);
            this.resultsLabel.TabIndex = 1;
            this.resultsLabel.Text = "Results";
            // 
            // lastUsedLabel
            // 
            this.lastUsedLabel.AutoSize = true;
            this.lastUsedLabel.Location = new System.Drawing.Point(12, 61);
            this.lastUsedLabel.Name = "lastUsedLabel";
            this.lastUsedLabel.Size = new System.Drawing.Size(55, 13);
            this.lastUsedLabel.TabIndex = 2;
            this.lastUsedLabel.Text = "Last Used";
            // 
            // dateLabel
            // 
            this.dateLabel.AutoSize = true;
            this.dateLabel.Location = new System.Drawing.Point(12, 86);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(49, 13);
            this.dateLabel.TabIndex = 3;
            this.dateLabel.Text = "File Date";
            // 
            // fileDate
            // 
            this.fileDate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.fileDate.Location = new System.Drawing.Point(70, 78);
            this.fileDate.Name = "fileDate";
            this.fileDate.Size = new System.Drawing.Size(277, 21);
            this.fileDate.TabIndex = 4;
            // 
            // description
            // 
            this.description.Location = new System.Drawing.Point(70, 6);
            this.description.Name = "description";
            this.description.Size = new System.Drawing.Size(277, 20);
            this.description.TabIndex = 5;
            this.description.TextChanged += new System.EventHandler(this.description_TextChanged);
            // 
            // results
            // 
            this.results.Location = new System.Drawing.Point(70, 31);
            this.results.Name = "results";
            this.results.Size = new System.Drawing.Size(277, 20);
            this.results.TabIndex = 6;
            this.results.TextChanged += new System.EventHandler(this.results_TextChanged);
            // 
            // folder
            // 
            this.folder.Location = new System.Drawing.Point(15, 106);
            this.folder.Name = "folder";
            this.folder.Size = new System.Drawing.Size(77, 23);
            this.folder.TabIndex = 8;
            this.folder.Text = "Folder";
            this.folder.UseVisualStyleBackColor = true;
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(98, 106);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(77, 23);
            this.save.TabIndex = 9;
            this.save.Text = "Save";
            this.save.UseVisualStyleBackColor = true;
            // 
            // open
            // 
            this.open.Location = new System.Drawing.Point(181, 106);
            this.open.Name = "open";
            this.open.Size = new System.Drawing.Size(85, 23);
            this.open.TabIndex = 10;
            this.open.Text = "Open";
            this.open.UseVisualStyleBackColor = true;
            // 
            // random
            // 
            this.random.Location = new System.Drawing.Point(272, 106);
            this.random.Name = "random";
            this.random.Size = new System.Drawing.Size(75, 23);
            this.random.TabIndex = 11;
            this.random.Text = "Random";
            this.random.UseVisualStyleBackColor = true;
            // 
            // lastUsed
            // 
            this.lastUsed.Location = new System.Drawing.Point(73, 54);
            this.lastUsed.Name = "lastUsed";
            this.lastUsed.Size = new System.Drawing.Size(200, 20);
            this.lastUsed.TabIndex = 12;
            this.lastUsed.ValueChanged += new System.EventHandler(this.lastUsed_ValueChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 141);
            this.Controls.Add(this.lastUsed);
            this.Controls.Add(this.random);
            this.Controls.Add(this.open);
            this.Controls.Add(this.save);
            this.Controls.Add(this.folder);
            this.Controls.Add(this.results);
            this.Controls.Add(this.description);
            this.Controls.Add(this.fileDate);
            this.Controls.Add(this.dateLabel);
            this.Controls.Add(this.lastUsedLabel);
            this.Controls.Add(this.resultsLabel);
            this.Controls.Add(this.excuseLabel);
            this.Name = "Form1";
            this.Text = "Excuse Manager";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label excuseLabel;
        private System.Windows.Forms.Label resultsLabel;
        private System.Windows.Forms.Label lastUsedLabel;
        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.Label fileDate;
        private System.Windows.Forms.TextBox description;
        private System.Windows.Forms.TextBox results;
        private System.Windows.Forms.Button folder;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.Button open;
        private System.Windows.Forms.Button random;
        private System.Windows.Forms.DateTimePicker lastUsed;
    }
}

