using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SolidDemo
{
    public partial class Form1 : Form
    {
        public Form1(ICalculate calc)
        {
            InitializeComponent();
            c = calc;
        }


        // The Form1 class is dependent not on a class but on the Interface!
        // Loose coupling:
        ICalculate c = null;

        private void button1_Click(object sender, EventArgs e)
        {
            // Do some fancy stuff..

            // Tight coupling
            int answer = c.Add(2, 3);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Even more fancy stuff
        }

        void GetSomeData()
        {
            // Entity Framework blah blah blah 
        }


    }
}
