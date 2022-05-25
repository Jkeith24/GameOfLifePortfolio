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

namespace GameOfLifePortfolio
{
    public partial class RandomSeed : Form
    {
        public RandomSeed()
        {
            InitializeComponent();
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.RandomSeed = (int)Seed1.Value;

            
            

            //this.Close();
        }



        private void Form2_Load(object sender, EventArgs e)
        {
          

        }



    }
}
