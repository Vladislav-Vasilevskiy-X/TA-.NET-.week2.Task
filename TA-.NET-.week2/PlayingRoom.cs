using System;
using System.Collections.Generic;
using TA_.NET_.week2.Toys;
using TA_.NET_.week2.Exceptions;

namespace TA_.NET_.week2
{
    class PlayingRoom
    {
        enum ToyType { Car, Ball, Doll }    //toy types
        enum Color { Blue, Red, Green, Orange, Yellow }     //toy color

        const int MAX_TALL = 120;           //max toy tall
        const int MIN_TALL = 20;            //min toy tall
        const int MAX_PRICE = 100;          //max toy price
        const int MIN_PRICE = 1;            //min toy 
        const uint TOYS_NUMBER = 5;         //Number of toys in the room
        const int MAX_TOYS_NUMBER = 50;     //number of maximum possible toys number
        const string fileName = "data.txt"; //file for writing/reading toys

        private List<Toy> toysList;         //List contains toys in playing room
        static Random random = new Random();

        //mehtod handle order
        public List<Toy> HandleOrder(uint cash)
        {
            List<Toy> order = new List<Toy>();
            uint leftMoney = cash;

            //paying for every toy and adding 
            //them to the toys list for the kid
            foreach (Toy toy in toysList)
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
            toysList = new List<Toy>();
            RandomFillToysList(TOYS_NUMBER);
        }

        //Addition of a toy
        public void AddToy(Toy toy)
        {
            if (toysList.Count + 1 < MAX_TOYS_NUMBER) toysList.Add(toy);
            else throw new MaxToysNumberException("The room is full! No toys can be added.");
        }

        //Searching of toy with required color, price, tall
        public Toy FindToy(string color, uint price, uint tall)
        {
            foreach(Toy toy in toysList)
            {
                if(toy.Color == color
                    && toy.Price == price
                    && toy.Tall == tall)
                {
                    return DefineToyType(toy);
                }
            }
            throw new ToyNotFoundException("Toy with required parameters is not founded.");
        }

        //Deleting toy
        public void DeleteToy(Toy toy)
        {
            Toy foundedToy = FindToy(toy.Color, toy.Price, toy.Tall);

            if (foundedToy.Available == false) toysList.Remove(foundedToy);
            else throw new DeletingUsableToyException("Can't delete toy which is in use now.");
        }

        //Randomly creating toys
        public void RandomFillToysList(uint numeberOfToys)
        {
            for (int i = 0; i < TOYS_NUMBER; i++)
            {
                string toyType = PlayingRoom.RandomEnumValue<ToyType>().ToString();
                if (toyType.Equals("Ball"))
                {
                    toysList.Add(new Car(RandomColor(),
                        RandomPrice(MIN_PRICE, MAX_PRICE),
                        RandomTall(MIN_TALL, MAX_PRICE)));
                }
                if (toyType.Equals("Doll"))
                {
                    toysList.Add(new Doll(RandomColor(),
                        RandomPrice(MIN_PRICE, MAX_PRICE),
                        RandomTall(MIN_TALL, MAX_PRICE)));
                }
                if (toyType.Equals("Car"))
                {
                    toysList.Add(new Car(RandomColor(),
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

        //Print all info about toys on the screen
        public void PrintToysInfo()
        {
            foreach (Toy toy in toysList)
            {
                DefineToyType(toy).PrintDescription();
            }
        }
    }
}
