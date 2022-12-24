namespace Engmu
{
    partial class More
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
            this.histogramButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // histogramButton
            // 
            this.histogramButton.Location = new System.Drawing.Point(12, 22);
            this.histogramButton.Name = "histogramButton";
            this.histogramButton.Size = new System.Drawing.Size(102, 30);
            this.histogramButton.TabIndex = 0;
            this.histogramButton.Text = "Show Histogram";
            this.histogramButton.UseVisualStyleBackColor = true;
            this.histogramButton.Click += new System.EventHandler(this.histogramButton_Click);
            // 
            // More
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 450);
            this.Controls.Add(this.histogramButton);
            this.Name = "More";
            this.Text = "More";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button histogramButton;
    }
}