using System;
using System.Collections.Generic;
using TA_.NET_.week2.Toys;

namespace TA_.NET_.week2
{
    class PlayingRoom
    {
        const uint TOYS_NUMBER = 124;   //Number of toys in the room
        private List<Toy> toys;         //List contains toys in playing room

        //mehtod handle order
        public List<Toy> HandleOrder(uint cash)
        {
            List<Toy> order = new List<Toy>();
            uint leftMoney = cash;

            //paying for every toy and adding 
            //them to the toys list for the kid
            foreach(Toy toy in toys)
            {
                if(toy.Available && leftMoney>= toy.Price)
                {
                    toy.Available = false;
                    leftMoney -= toy.Price;
                    order.Add(toy);
                }
            }
            return order;
        }

        //Every day in the morinng room opens...
        public void Open()
        { 
            toys = new List<Toy>();
            RandomFillToysList(TOYS_NUMBER);
        }

        //Randomly creating toys
        public void RandomFillToysList(uint numeberOfToys)
        {

        }

        ////Searching doll with nessesary parameters(color and tall)
        ////Method returns true, if it's founded, else 
        //public bool OrderToy(Doll doll)
        //{
        //    foreach (Toy toy in toys)
        //    {
        //        if (doll.GetType().Equals(GetToyType(toy)))
        //        {
        //            Doll foundedDoll = (Doll)toy;
        //            if (CheckOrderedToyForPresence(foundedDoll, toy))
        //                return true;
        //        }
        //    }
        //    return false;
        //}

        ////Overloaded method OrderToy for car
        //public bool OrderToy(Car car)
        //{
        //    foreach (Toy toy in toys)
        //    {
        //        if (car.GetType().Equals(GetToyType(toy)))
        //        {
        //            Car foundedCar = (Car)toy;
        //            if (CheckOrderedToyForPresence(foundedCar, toy))
        //                return true;
        //        }
        //    }
        //    return false;
        //}

        ////Overloaded method OrderToy for ball
        //public bool OrderToy(Ball ball)
        //{
        //    foreach (Toy toy in toys)
        //    {
        //        if (ball.GetType().Equals(GetToyType(toy)))
        //        {
        //            Ball foundedBall = (Ball)toy;
        //            if (CheckOrderedToyForPresence(foundedBall, toy))

        //                return true;
        //        }
        //    }
        //    return false;
        //}

        //Checks if room contains toy with specified params
        public bool CheckOrderedToyForPresence(Toy toyForCheck, Toy sourceToy)
        {
            if (toyForCheck.Color == sourceToy.Color
                && toyForCheck.Tall == sourceToy.Tall)
                return true;
            else return false;
        }
    }
}
