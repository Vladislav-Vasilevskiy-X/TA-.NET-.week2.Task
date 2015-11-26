using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TA_.NET_.week2.Toys
{
    class Ball : Toy
    {
        private string name = "Yamata-1";

        public Ball(string name, string color, uint price, uint tall)
            : base(color, price, tall)
        {
            this.name = name;
        }

        //Overrided method prints doll's description
        public override void PrintDescription()
        {
            Console.WriteLine("Ball: " + name);
            Console.WriteLine("-price:" + Price);
            Console.WriteLine("-tall:" + Tall);
            Console.WriteLine("-color:" + Color);
        }
    }
}
