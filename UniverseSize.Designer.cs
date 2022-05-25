
namespace GameOfLifePortfolio
{
    partial class UniverseSize
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
            this.OKButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.HeightVal = new System.Windows.Forms.NumericUpDown();
            this.WidthVal = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.HeightVal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WidthVal)).BeginInit();
            this.SuspendLayout();
            // 
            // OKButton
            // 
            this.OKButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OKButton.Location = new System.Drawing.Point(57, 215);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(75, 23);
            this.OKButton.TabIndex = 0;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(222, 215);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 1;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // HeightVal
            // 
            this.HeightVal.Location = new System.Drawing.Point(113, 60);
            this.HeightVal.Name = "HeightVal";
            this.HeightVal.Size = new System.Drawing.Size(120, 20);
            this.HeightVal.TabIndex = 2;
            // 
            // WidthVal
            // 
            this.WidthVal.Location = new System.Drawing.Point(113, 123);
            this.WidthVal.Name = "WidthVal";
            this.WidthVal.Size = new System.Drawing.Size(120, 20);
            this.WidthVal.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(141, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Height";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(141, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Width";
            // 
            // UniverseSize
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 291);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.WidthVal);
            this.Controls.Add(this.HeightVal);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.OKButton);
            this.Name = "UniverseSize";
            this.Text = "Universe Size";
            ((System.ComponentModel.ISupportInitialize)(this.HeightVal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WidthVal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.NumericUpDown HeightVal;
        private System.Windows.Forms.NumericUpDown WidthVal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}