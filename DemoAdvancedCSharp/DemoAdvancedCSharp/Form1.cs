using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoAdvancedCSharp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Use Reflection by getting the information of type Student
            Type t = typeof(Student);

            foreach (var prop in t.GetProperties())
            {
                comboBox1.Items.Add(prop.Name);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var st = new Student();

            st.Firstname = "Xander";
            st.Lastname = "Wemmers";
            st.DateOfBirth = new DateTime(1974, 2, 7);
            st.City = "Utrecht";
            st.Salary = 1000;

            // Use reflection to get all information of the object st
            Type t = st.GetType();

            string s = "";

            foreach (var prop in t.GetProperties())
            {
                s += prop.Name + " = " + prop.GetValue(st) + "\n";
            }

            foreach (var method in t.GetMethods())
            {
                s += method.Name + "\n";
            }

            MessageBox.Show(s);
        }



        void SayHello()
        {
            // This function is going to be an action
            MessageBox.Show("Hello");
        }

        void SayName(string name)
        {
            MessageBox.Show(name);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // The same method, but now as a Lambda expression
            // And the type of the Lambda expression is Action
            Action a1 = () => MessageBox.Show("Hello");

            Action a2 = () => MessageBox.Show("World");

            // Execute these two actions in a synchronous way:
            //a1();
            //a2();

            // Execute two actions in parallel:
            Parallel.Invoke(a1, a2);

            // Execute several actions using lambda expressions:
            Parallel.Invoke(
                () => MessageBox.Show("Mathijs"),
                () => MessageBox.Show("George"),
                () => MessageBox.Show("Roy")
            );
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // An action having one input parameter (supply the type <string>)
            Action<int> a1 = (n) => MessageBox.Show(n.ToString());

            // An action having two input parameters:
            Action<string, string> a2 = (firstname, lastname) => MessageBox.Show(firstname + " " + lastname);

            //a1("Mathijs");
            //a2("Xander", "Wemmers");

            var names = new string[] { "George", "Mathijs", "Roy", "Erica" };
            var numbers = new int[] { 1,2,3,4 };

            // Execute in parallel for each name in the array the action a1
            //Parallel.ForEach(names, a1);

            //Parallel.ForEach(numbers, a1);

            Parallel.For(1, 100, a1);

            // An action can also be multiple lines of code
            // Do not forget the curly braces { and }
            Action a3 = () =>
            {
                MessageBox.Show("Hello");
                MessageBox.Show("World");
                MessageBox.Show("Xander");
                MessageBox.Show("Roy");
                MessageBox.Show("George");
            };

        }

        private void button4_Click(object sender, EventArgs e)
        {
            // An example of a Func
            Func<int, int, int> AddNumbers = (x, y) => x + y;

            //Func<int, int> Square = (x) => x * x;

            var sw =  Stopwatch.StartNew();

            var numbers = new[] { 5, 3, 1, 2, 4, 3 };

            // Do this query in parallel by adding AsParallel
            // And tell it to create 2 threads by calling WithDegreeOfParallelism
            var query = from n in numbers.AsParallel().WithDegreeOfParallelism(6)
                        where Square(n) > 10
                        select n;

            var list = query.ToList();

            sw.Stop();

            MessageBox.Show(sw.ElapsedMilliseconds.ToString());
        }

        // The same function but now in the other syntax:
        int Square(int num)
        {
            Thread.Sleep(num * 1000);
            return num * num;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Action a1 = () => 
            {
                Thread.Sleep(5000);
                MessageBox.Show("Done!");
            };


            // Synchronously:
            //a1();

            // Asynchronously:

            // Create a new task based on action a1:
            Task t = new Task(a1);

            // Start the action in the background:
            t.Start();

            // My UI does not freeze!
        }

        private async void button6_Click(object sender, EventArgs e)
        {
            var task = new Task<int>(() =>
            {
                Thread.Sleep(5000);
                return 25;
            });

            task.Start();

            // Get the result:
            // but: waiting for the result is again a blocking call!
            // so my UI freezes
            //MessageBox.Show(task.Result.ToString());

            // Wait for the task in a non blocking way:
            int num = await task;
            MessageBox.Show(num.ToString());

        }

        private async void button7_Click(object sender, EventArgs e)
        {

            var c = new Calculator();
            int answer = await c.AddAsync(3, 3);
            MessageBox.Show(answer.ToString());
        }

        private void button8_Click(object sender, EventArgs e)
        {
            // Dictionary is in fact a list

            var dict = new Dictionary<string, int>();

            dict.Add("Eindhoven", 300000);
            dict.Add("Utrecht", 350000);

            var dict2 = new Dictionary<int, Student>();
            dict2.Add(2, new Student { Firstname = "Xander" });
            dict2.Add(3, new Student { Firstname = "George" });


            var quantities = new Dictionary<string, int>();
            quantities.Add("Cola", 3);

            quantities["Fanta"] = 4;

            foreach (var item in quantities.Keys)
            {
            }

        }
    }
}
