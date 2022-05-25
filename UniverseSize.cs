using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameOfLifePortfolio
{
    public partial class UniverseSize : Form
    {
        public UniverseSize()
        {
            InitializeComponent();
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.UniverseHeight = (int) HeightVal.Value;
            Properties.Settings.Default.UniverseWidth = (int)WidthVal.Value;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
