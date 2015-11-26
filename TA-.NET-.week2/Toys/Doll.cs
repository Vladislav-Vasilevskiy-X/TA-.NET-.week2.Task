using System;

namespace TA_.NET_.week2.Toys
{
    class Doll : Toy
    {
        private string name = "Elizabeth-1";    //doll's name

        public Doll(string name, string color, uint price, uint tall)
            : base(color, price, tall)
        {
            this.name = name;
        }

        //Overrided method prints doll's description
        public override void PrintDescription()
        {
            Console.WriteLine("Doll: " + name);
            Console.WriteLine("-price:" + Price);
            Console.WriteLine("-tall:" + Tall);
            Console.WriteLine("-color:" + Color);
        }
    }
}
