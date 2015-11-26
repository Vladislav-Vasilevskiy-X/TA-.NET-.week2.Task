using System.Collections.Generic;

namespace TA_.NET_.week2
{
    class Kid
    {
        private Parent father;
        private List<Toy> toys;
        
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
