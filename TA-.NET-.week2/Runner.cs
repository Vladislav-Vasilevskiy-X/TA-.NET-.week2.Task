using System;
using TA_.NET_.week2;
using TA_.NET_.week2.Toys;

class Runner
{
    static void Main(string[] args)
    {
        PlayingRoom room = new PlayingRoom();
        room.Open();

        Parent parent = new Parent();
        Kid kid = new Kid();
        parent.Son = kid;
        kid.Father = parent;

        room.PrintToysInfo();
        parent.Cash = 1000;
        parent.MakeOrder(room);
        kid.PrintToysList();

        Console.WriteLine("Room after order: ");
        room.PrintToysInfo();
    }
}

