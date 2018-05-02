using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZooInheritance
{
    public partial class Form1 : Form
    {
        // The declaration of Zoo should be scoped to the entire Form
        List<Animal> Zoo = null;

        public Form1()
        {
            InitializeComponent();

            // Variable Zoo is instantiated in the constructor of the Form
            Zoo = new List<Animal>();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Instantiate a new Monkey object

            Monkey m = new Monkey();

            m.Name = "Klaas";

            AddAnimalToZoo(m);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // var is implicite typing
            var l = new Lion();

            l.Name = "Bob";

            AddAnimalToZoo(l);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Elephant el = new Elephant();
            el.Name = "Dombo";
            AddAnimalToZoo(el);
        }

        private void AddAnimalToZoo(Animal a)
        {
            Zoo.Add(a);

            dataGridView1.DataSource = null;
            listBox1.DataSource = null;
            dataGridView1.DataSource = Zoo;
            listBox1.DataSource = Zoo;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            foreach(Animal a in Zoo)
            {
                if (a is Lion)
                    a.Eat();
            }

            dataGridView1.DataSource = null;
            listBox1.DataSource = null;
            dataGridView1.DataSource = Zoo;
            listBox1.DataSource = Zoo;
        }
    }
}
