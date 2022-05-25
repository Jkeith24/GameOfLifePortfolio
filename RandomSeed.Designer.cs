
namespace GameOfLifePortfolio
{
    partial class RandomSeed
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.Seed1 = new System.Windows.Forms.NumericUpDown();
            this.Seed = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Seed1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(62, 199);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 31);
            this.button1.TabIndex = 0;
            this.button1.Text = "OK\r\n";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(218, 199);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 31);
            this.button2.TabIndex = 1;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // Seed1
            // 
            this.Seed1.Location = new System.Drawing.Point(114, 75);
            this.Seed1.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.Seed1.Name = "Seed1";
            this.Seed1.Size = new System.Drawing.Size(88, 20);
            this.Seed1.TabIndex = 2;
            // 
            // Seed
            // 
            this.Seed.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Seed.Location = new System.Drawing.Point(96, 39);
            this.Seed.Name = "Seed";
            this.Seed.Size = new System.Drawing.Size(123, 23);
            this.Seed.TabIndex = 3;
            this.Seed.Text = "Seed";
            this.Seed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form2
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button2;
            this.ClientSize = new System.Drawing.Size(334, 246);
            this.Controls.Add(this.Seed);
            this.Controls.Add(this.Seed1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Seed1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.NumericUpDown Seed1;
        private System.Windows.Forms.Label Seed;
    }
}