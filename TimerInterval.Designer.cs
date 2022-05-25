
namespace GameOfLifePortfolio
{
    partial class TimerInterval
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
            this.Tinterval = new System.Windows.Forms.Button();
            this.Interval = new System.Windows.Forms.NumericUpDown();
            this.TimerLabel = new System.Windows.Forms.Label();
            this.CancelButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Interval)).BeginInit();
            this.SuspendLayout();
            // 
            // Tinterval
            // 
            this.Tinterval.Location = new System.Drawing.Point(90, 163);
            this.Tinterval.Name = "Tinterval";
            this.Tinterval.Size = new System.Drawing.Size(75, 23);
            this.Tinterval.TabIndex = 0;
            this.Tinterval.Text = "OK";
            this.Tinterval.UseVisualStyleBackColor = true;
            this.Tinterval.Click += new System.EventHandler(this.button1_Click);
            // 
            // Interval
            // 
            this.Interval.Location = new System.Drawing.Point(73, 105);
            this.Interval.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.Interval.Name = "Interval";
            this.Interval.Size = new System.Drawing.Size(120, 20);
            this.Interval.TabIndex = 1;
            // 
            // TimerLabel
            // 
            this.TimerLabel.AutoSize = true;
            this.TimerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimerLabel.Location = new System.Drawing.Point(45, 73);
            this.TimerLabel.Name = "TimerLabel";
            this.TimerLabel.Size = new System.Drawing.Size(191, 20);
            this.TimerLabel.TabIndex = 2;
            this.TimerLabel.Text = "Timer interval milliseconds";
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(90, 202);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 3;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // TimerInterval
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(261, 258);
            this.ControlBox = false;
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.TimerLabel);
            this.Controls.Add(this.Interval);
            this.Controls.Add(this.Tinterval);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TimerInterval";
            this.Text = "TimerInterval";
            ((System.ComponentModel.ISupportInitialize)(this.Interval)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Tinterval;
        private System.Windows.Forms.NumericUpDown Interval;
        private System.Windows.Forms.Label TimerLabel;
        private System.Windows.Forms.Button CancelButton;
    }
}