using System.Collections.Generic;
using System;

namespace TA_.NET_.week2
{
    class Kid
    {
        private Parent father;      //parent
        private List<Toy> toys;     //toys
        
        public Kid()
        {
            toys = new List<Toy>();
        }

        public void PrintToysList()
        {
            Console.WriteLine("Kids toys list:");
            foreach(Toy toy in toys)
            {
                PlayingRoom.DefineToyType(toy).PrintDescription();
            }
        }

        //Accessors
        public Parent Father
        {
            get { return father; }
            set { father = value; }
        }

        public List<Toy> Toys
        {
            get { return toys; }
            set { toys = value; }
        }
    }
}