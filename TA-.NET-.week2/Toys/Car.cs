using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TA_.NET_.week2.Toys
{
    [Serializable]
    class Car : Toy
    {
        private string name = "Lamba-421D"; //Toy's name

        public Car(string color, uint price, uint tall)
            : base(color, price, tall)
        { }

        //Overrided method prints doll's description
        public override void PrintDescription()
        {
            Console.WriteLine("Car: " + name);
            Console.WriteLine("-price:" + Price);
            Console.WriteLine("-tall:" + Tall);
            Console.WriteLine("-color:" + Color);
            Console.WriteLine("-available:" + Available);
        }
    }
}
