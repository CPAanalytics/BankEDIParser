namespace EODPARSER_WF
{
    partial class EodForm
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
            this.Parse = new System.Windows.Forms.Button();
            this.GetFile = new System.Windows.Forms.Button();
            this.FilenameBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Parse
            // 
            this.Parse.Location = new System.Drawing.Point(620, 372);
            this.Parse.Name = "Parse";
            this.Parse.Size = new System.Drawing.Size(143, 51);
            this.Parse.TabIndex = 0;
            this.Parse.Text = "Parse";
            this.Parse.UseVisualStyleBackColor = true;
            this.Parse.Click += new System.EventHandler(this.Parse_Click);
            // 
            // GetFile
            // 
            this.GetFile.Location = new System.Drawing.Point(72, 43);
            this.GetFile.Name = "GetFile";
            this.GetFile.Size = new System.Drawing.Size(143, 25);
            this.GetFile.TabIndex = 1;
            this.GetFile.Text = "Open EOD File";
            this.GetFile.UseVisualStyleBackColor = true;
            this.GetFile.Click += new System.EventHandler(this.GetFile_Click);
            // 
            // FilenameBox
            // 
            this.FilenameBox.Location = new System.Drawing.Point(274, 41);
            this.FilenameBox.Name = "FilenameBox";
            this.FilenameBox.Size = new System.Drawing.Size(346, 20);
            this.FilenameBox.TabIndex = 2;
            // 
            // EODForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.FilenameBox);
            this.Controls.Add(this.GetFile);
            this.Controls.Add(this.Parse);
            this.Name = "EODForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.TextBox FilenameBox;
        private System.Windows.Forms.Button Parse;
        private System.Windows.Forms.Button GetFile;

        #endregion
    }
}