using System;

namespace TA_.NET_.week2
{
    [Serializable]
    abstract class Toy
    {
        private uint price;     //Toy's price
        private string color;   //Toy's color
        private uint tall;      //Tall of the toy
        private bool available; //Flag for monitoring toy's usability

        //Construcor for every toy
        public Toy(string color, uint price, uint tall)
        {
            Color = color;
            Price = price;
            Tall = tall;
            Available = true;
        }

        public abstract void PrintDescription();

        //Accessors
        public string Color
        {
            get { return color; }
            set { color = value; }
        }

        public uint Price
        {
            get { return price; }
            set { price = value; }
        }

        public uint Tall
        {
            get { return tall; }
            set { tall = value; }
        }

        public bool Available
        {
            get { return available; }
            set { available = value; }
        }
    }
}
