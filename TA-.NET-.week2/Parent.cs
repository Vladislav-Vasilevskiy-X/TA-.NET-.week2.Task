using System.Collections.Generic;

namespace TA_.NET_.week2
{
    class Parent
    {
        private Kid son;    //kid
        private uint cash;  //current money
        
        public Parent()
        {
            son = new Kid();
        }

        //Order toys
        public void MakeOrder(uint cash, PlayingRoom room)
        {
            son.Toys = room.HandleOrder(cash);
        }

        //Accessors
        public uint Cash
        {
            get { return cash; }
            set { cash = value; }
        }

        public Kid Son
        {
            get { return son; }
            set { son = value; }
        }
    }
}