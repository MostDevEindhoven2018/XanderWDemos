using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooInheritance
{
    class Animal
    {
        public Animal()
        {
            // Constructor! For initializing an object of this class Animal
            Energy = 10;
        }


        // Property
        public int Energy { get; set; }

        public string Name { get; set; }

        public virtual void Eat()
        {
            // 25 for each Animal
            // ToDo: specify a number per Animal
            this.Energy += 25;
        }

        // Override: write your own version of an existing method 
        // ToString was defined in class object (not by me!)
        public override string ToString()
        {
            return Name;
        }
    }
}
