using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLifePortfolio
{
    public class ApplyEventArgs : EventArgs
    {
        public delegate void ApplyEventHandler(object sender, ApplyEventArgs e);

        int myInteger;
        string myString;
        public int MyInteger
        {
            get { return myInteger; }
            set { myInteger = value; }
        }
        public string MyString
        {
            get { return myString; }
            set { myString = value; }
        }
        public ApplyEventArgs(int myInteger, string myString)
        {
            this.myInteger = myInteger;
            this.myString = myString;


        }
    }
}
