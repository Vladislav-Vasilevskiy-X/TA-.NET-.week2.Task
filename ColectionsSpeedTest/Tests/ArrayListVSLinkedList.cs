using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System;

namespace ColectionsSpeedTest
{
    class ArrayListVSLinkedList
    { 
        class AdditionTest
        {
            private ArrayList arrayList = new ArrayList();  //arraylist
            private LinkedList<int> linkedList = new LinkedList<int>(); //linhkedlist

            private long elapsedTimeLinkedList;     //elapsed time for adding 1 to arraylist TIMES times
            private long elapsedTimeArrayList;      //elapsed time for adding 1 to linkedlist TIMES times

            const uint TIMES = 10000000;        //addition times

            private Stopwatch stopwatch = new Stopwatch();  //stopwatch
            
            //Run test from the constructor
            public AdditionTest()
            {
                Run();
                PrintTestResults();
            }

            private void Run()
            {
                //starting the stopwatch
                stopwatch.Start();

                //adding data to array list
                AddDataToArrayList(TIMES);

                //stop-reset-start the stopwatch
                stopwatch.Stop();

                elapsedTimeArrayList = stopwatch.ElapsedMilliseconds;

                stopwatch.Reset();
                stopwatch.Start();

                //adding data to linked list
                AddDataTolinkedList(TIMES);
                stopwatch.Stop();

                elapsedTimeLinkedList = stopwatch.ElapsedMilliseconds;
            }

            //Adding 1 to arraylist TIMES times
            private void AddDataToArrayList(uint times)
            {
                while(times > 0)
                {
                    arrayList.Add(1);
                    times--;
                }
            }

            //Adding 1 to linkedlist TIMES times
            private void AddDataTolinkedList(uint times)
            {
                while (times > 0)
                {
                    linkedList.AddLast(1);
                    //linkedList.AddFirst(1);
                    times--;
                }
            }

            //Prints test results on the console
            private void PrintTestResults()
            {
                Console.WriteLine("Elapsed time for adding 1 to ArrayList " +
                    TIMES + " times: " + elapsedTimeArrayList + " milliseconds.");
                Console.WriteLine("Elapsed time for adding 1 to LinkedList " +
                    TIMES + " times: " + elapsedTimeLinkedList + " milliseconds.");

                if (elapsedTimeArrayList == elapsedTimeLinkedList)
                {
                    Console.WriteLine("It's draw!");
                    return;
                }
                if (elapsedTimeArrayList > elapsedTimeLinkedList)
                    Console.WriteLine("LinkedList won!");
                else
                    Console.WriteLine("ArrayList won!");
            }

        }

        class SearchingTest
        {
            private ArrayList arrayList = new ArrayList();  //arraylist
            private LinkedList<int> linkedList = new LinkedList<int>(); //linhkedlist

            private long elapsedTimeLinkedList;     //elapsed time for adding 1 to arraylist TIMES times
            private long elapsedTimeArrayList;      //elapsed time for adding 1 to linkedlist TIMES times

            const uint SEARCHING_TIMES = 100;        //searching times
            const uint ADDING_TIMES = 10000000;

            private Stopwatch stopwatch = new Stopwatch();  //stopwatch

            //Run test from the constructor
            public SearchingTest()
            {
                Run();
                PrintTestResults();
            }

            private void Run()
            { 
                Prepare();

                //starting the stopwatch
                stopwatch.Start();

                //adding data to array list
                FindInArrayList(SEARCHING_TIMES);

                //stop-reset-start the stopwatch
                stopwatch.Stop();

                elapsedTimeArrayList = stopwatch.ElapsedMilliseconds;

                stopwatch.Reset();
                stopwatch.Start();

                //adding data to linked list
                FindInLinkedList(SEARCHING_TIMES);
                stopwatch.Stop();

                elapsedTimeLinkedList = stopwatch.ElapsedMilliseconds;
            }

            //Prepearing lists: 
            //creating TIMES-1 elements with value 1
            //and int TIMES/2 position element with value 2
            private void Prepare()
            {
                AddDataToArrayList(ADDING_TIMES);
                arrayList.Insert((int)ADDING_TIMES / 2, 2);

                AddDataTolinkedList(ADDING_TIMES / 2);
                linkedList.AddLast(2);
                AddDataTolinkedList(ADDING_TIMES / 2-1);
            }

            //Adding 1 to arraylist TIMES times
            private void AddDataToArrayList(uint times)
            {
                while (times > 0)
                {
                    arrayList.Add(1);
                    times--;
                }
            }

            //Adding 1 to linkedlist TIMES times
            private void AddDataTolinkedList(uint times)
            {
                while (times > 0)
                {
                    linkedList.AddLast(1);
                    //linkedList.AddFirst(1);
                    times--;
                }
            }

            //Looking for 2 in arraylist TIMES times
            private void FindInArrayList(uint times)
            {
                while (times > 0)
                {
                    arrayList.Contains(2);
                    times--;
                }
            }

            //Looking for 2 in linkedlist TIMES times
            private void FindInLinkedList(uint times)
            {
                while (times > 0)
                {
                    linkedList.Contains(2);
                    times--;
                }
            }

            //Prints test results on the console
            private void PrintTestResults()
            {
                Console.WriteLine("Elapsed time for searching 2 in ArrayList " +
                    SEARCHING_TIMES + " times: " + elapsedTimeArrayList + " milliseconds.");
                Console.WriteLine("Elapsed time for searching 2 in LinkedList " +
                    SEARCHING_TIMES + " times: " + elapsedTimeLinkedList + " milliseconds.");

                if (elapsedTimeArrayList == elapsedTimeLinkedList)
                {
                    Console.WriteLine("It's draw!");
                    return;
                }
                if (elapsedTimeArrayList > elapsedTimeLinkedList)
                    Console.WriteLine("LinkedList won!");
                else
                    Console.WriteLine("ArrayList won!");
            }
        }

        class DeletingTest
        {
            private ArrayList arrayList = new ArrayList();  //arraylist
            private LinkedList<int> linkedList = new LinkedList<int>(); //linhkedlist

            private long elapsedTimeLinkedList;     //elapsed time for adding 1 to arraylist TIMES times
            private long elapsedTimeArrayList;      //elapsed time for adding 1 to linkedlist TIMES times

            const uint DELETING_TIMES = 100;        //searching times
            const uint ADDING_TIMES = 10000000;

            private Stopwatch stopwatch = new Stopwatch();  //stopwatch

            //Run test from the constructor
            public DeletingTest()
            {
                Run();
                PrintTestResults();
            }

            private void Run()
            {
                Prepare();

                //starting the stopwatch
                stopwatch.Start();

                //adding data to array list
                DeleteFromArrayList(DELETING_TIMES);

                //stop-reset-start the stopwatch
                stopwatch.Stop();

                elapsedTimeArrayList = stopwatch.ElapsedMilliseconds;

                stopwatch.Reset();
                stopwatch.Start();

                //adding data to linked list
                DeleteFromLinkedList(DELETING_TIMES);
                stopwatch.Stop();

                elapsedTimeLinkedList = stopwatch.ElapsedMilliseconds;
            }

            //Prepearing lists: 
            //creating TIMES-1 elements with value 1
            //and int TIMES/2 position element with value 2
            private void Prepare()
            {
                uint times = ADDING_TIMES;
                while (times > 0)
                {
                    arrayList.Add(1);
                    linkedList.AddLast(1);
                    times--;
                }

            }

            //Deleting elements from the middle of the arrylist DELETING_TIMES times
            private void DeleteFromArrayList(uint times)
            {
                while (times > 0)
                {
                    arrayList.RemoveAt(0);
                    times--;
                }
            }

            //Deleting elements from the middle of the linkedlist DELETING_TIMES times
            private void DeleteFromLinkedList(uint times)
            {
                while (times > 0)
                {
                    linkedList.RemoveFirst();
                    times--;
                }
            }

            //Prints test results on the console
            private void PrintTestResults()
            {
                Console.WriteLine("Elapsed time for deleting elements in ArrayList " +
                    DELETING_TIMES + " times: " + elapsedTimeArrayList + " milliseconds.");
                Console.WriteLine("Elapsed time for deleting elements in LinkedList " +
                    DELETING_TIMES + " times: " + elapsedTimeLinkedList + " milliseconds.");

                if (elapsedTimeArrayList == elapsedTimeLinkedList)
                {
                    Console.WriteLine("It's draw!");
                    return;
                }
                if (elapsedTimeArrayList > elapsedTimeLinkedList)
                    Console.WriteLine("LinkedList won!");
                else
                    Console.WriteLine("ArrayList won!");
            }
        }

        public ArrayListVSLinkedList()
        {
            RunTests();
        }

        private void RunTests()
        {
            new AdditionTest();
            new SearchingTest();
            new DeletingTest();
        }
    }
}
