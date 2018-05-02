using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooInheritance
{
    class Monkey : Animal
    {
        public override void Eat()
        {
            this.Energy += 10;
        }
    }
}
