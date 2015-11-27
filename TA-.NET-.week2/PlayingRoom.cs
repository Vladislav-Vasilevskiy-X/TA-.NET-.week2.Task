using System;
using System.Collections.Generic;
using TA_.NET_.week2.Toys;

namespace TA_.NET_.week2
{
    class PlayingRoom
    {
        enum ToyType { Car, Ball, Doll }    //toy types
        enum Color { Blue, Red, Green, Orange, Yellow }     //toy color

        static Random random = new Random();

        const int MAX_TALL = 120;       //max toy tall
        const int MIN_TALL = 20;        //min toy tall
        const int MAX_PRICE = 100;      //max toy price
        const int MIN_PRICE = 1;        //min toy price

        const uint TOYS_NUMBER = 5;   //Number of toys in the room
        private List<Toy> toys;         //List contains toys in playing room

        //mehtod handle order
        public List<Toy> HandleOrder(uint cash)
        {
            List<Toy> order = new List<Toy>();
            uint leftMoney = cash;

            //paying for every toy and adding 
            //them to the toys list for the kid
            foreach (Toy toy in toys)
            {
                if (toy.Available && leftMoney >= toy.Price)
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
            for (int i = 0; i < TOYS_NUMBER; i++)
            {
                string toyType = PlayingRoom.RandomEnumValue<ToyType>().ToString();
                if (toyType.Equals("Ball"))
                {
                    toys.Add(new Car(RandomColor(),
                        RandomPrice(MIN_PRICE, MAX_PRICE),
                        RandomTall(MIN_TALL, MAX_PRICE)));
                }
                if (toyType.Equals("Doll"))
                {
                    toys.Add(new Doll(RandomColor(),
                        RandomPrice(MIN_PRICE, MAX_PRICE),
                        RandomTall(MIN_TALL, MAX_PRICE)));
                }
                if (toyType.Equals("Car"))
                {
                    toys.Add(new Car(RandomColor(),
                        RandomPrice(MIN_PRICE, MAX_PRICE),
                        RandomTall(MIN_TALL, MAX_PRICE)));
                }
            }
        }

        //Random color from colors enum
        static string RandomColor()
        {
            return RandomEnumValue<Color>().ToString();
        }

        //Random price of the toy, from min to max
        static uint RandomPrice(int fromValue, int toValue)
        {
            return (uint)(random).Next(fromValue, toValue);
        }

        //Random tall of the toy, from min to max
        static uint RandomTall(int fromValue, int toValue)
        {
            return (uint)(random).Next(fromValue, toValue);
        }

        //Get random value from enum
        static T RandomEnumValue<T>()
        {
            var v = Enum.GetValues(typeof(T));
            return (T)v.GetValue(random.Next(v.Length));
        }

        //Checks if room contains toy with specified params
        public bool CheckOrderedToyForPresence(Toy toyForCheck, Toy sourceToy)
        {
            if (toyForCheck.Color == sourceToy.Color
                && toyForCheck.Tall == sourceToy.Tall)
                return true;
            else return false;
        }

        //dynamic method returns object of defined toy (ball, car, doll)
        //or null if type is undefined
        public static dynamic DefineToyType(Toy toy)
        {
            string type = toy.GetType().ToString();
            if(type.Equals("TA_.NET_.week2.Toys.Ball"))
            {
                return (Ball)toy;
            }
            if (type.Equals("TA_.NET_.week2.Toys.Car"))
            {
                return (Car)toy;
            }
            if (type.Equals("TA_.NET_.week2.Toys.Doll"))
            {
                return (Doll)toy;
            }
            return null;
        }


        public void PrintToysInfo()
        {
            foreach (Toy toy in toys)
            {
                DefineToyType(toy).PrintDescription();
            }
        }
    }
}
