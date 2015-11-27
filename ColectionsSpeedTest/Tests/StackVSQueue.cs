using System;
using System.Collections.Generic;
using System.Collections;
using System.Diagnostics;

namespace ColectionsSpeedTest
{
    class StackVSQueue
    {
        class AdditionTest
        {
            private Stack stack = new Stack();  //stack
            private Queue queue = new Queue();  //queue

            private long elapsedTimeStack;     //elapsed time for addition 1 to stack TIMES times
            private long elapsedTimeQueue;      //elapsed time for addition 1 to queue TIMES times

            const uint TIMES = 10000000;            //addition times

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

                //addition data to stack
                AddDataToStack(TIMES);

                //stop-reset-start the stopwatch
                stopwatch.Stop();

                elapsedTimeQueue = stopwatch.ElapsedMilliseconds;

                stopwatch.Reset();
                stopwatch.Start();

                //addition data to queue
                AddDataToQueue(TIMES);
                stopwatch.Stop();

                elapsedTimeStack = stopwatch.ElapsedMilliseconds;
            }

            //addition 1 to stack TIMES times
            private void AddDataToStack(uint times)
            {
                while (times > 0)
                {
                    stack.Push(1);
                    times--;
                }
            }

            //addition 1 to queue TIMES times
            private void AddDataToQueue(uint times)
            {
                while (times > 0)
                {
                    queue.Enqueue(1);
                    times--;
                }
            }

            //Prints test results on the console
            private void PrintTestResults()
            {
                Console.WriteLine("Elapsed time for addition 1 to Stack " +
                    TIMES + " times: " + elapsedTimeQueue + " milliseconds.");
                Console.WriteLine("Elapsed time for addition 1 to Queue " +
                    TIMES + " times: " + elapsedTimeStack + " milliseconds.");

                if (elapsedTimeQueue == elapsedTimeStack)
                {
                    Console.WriteLine("It's draw!");
                    return;
                }
                if (elapsedTimeQueue > elapsedTimeStack)
                    Console.WriteLine("Queue won!");
                else
                    Console.WriteLine("Stack won!");
            }

        }

        class SearchingTest
        {
            private Stack stack = new Stack();  //stack
            private Queue queue = new Queue();  //queue

            private long elapsedTimeStack;     //elapsed time for addition 1 to stack TIMES times
            private long elapsedTimeQueue;      //elapsed time for addition 1 to queue TIMES times

            const uint SEARCHING_TIMES = 100;        //searching times
            const uint ADDITION_TIMES = 10000000;

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

                //addition data to stack
                FindInStack(SEARCHING_TIMES);

                //stop-reset-start the stopwatch
                stopwatch.Stop();

                elapsedTimeStack = stopwatch.ElapsedMilliseconds;

                stopwatch.Reset();
                stopwatch.Start();

                //addition data to queue
                FindInQueue(SEARCHING_TIMES);
                stopwatch.Stop();

                elapsedTimeQueue = stopwatch.ElapsedMilliseconds;
            }

            //Prepearing lists: 
            //creating TIMES-1 elements with value 1
            //and int TIMES/2 position element with value 2
            private void Prepare()
            {
                AddDataToStack(ADDITION_TIMES / 2);
                stack.Push(2);
                AddDataToStack(ADDITION_TIMES / 2 - 1);

                AddDataToQueue(ADDITION_TIMES / 2);
                queue.Enqueue(2);
                AddDataToQueue(ADDITION_TIMES / 2 - 1);
            }

            //addition 1 to stack TIMES times
            private void AddDataToStack(uint times)
            {
                while (times > 0)
                {
                    stack.Push(1);
                    times--;
                }
            }

            //addition 1 to queue TIMES times
            private void AddDataToQueue(uint times)
            {
                while (times > 0)
                {
                    queue.Enqueue(1);
                    times--;
                }
            }

            //Looking for 2 in stck TIMES times
            private void FindInStack(uint times)
            {
                while (times > 0)
                {
                    FindDataInStack(2);
                    times--;
                }
            }

            //Returns true if found value in stack
            private bool FindDataInStack(int value)
            {
                foreach (int i in stack)
                {
                    if (i == value)
                    {
                        return true;
                    }
                }
                return false;
            }

            //Looking for 2 in queue TIMES times
            private void FindInQueue(uint times)
            {
                while (times > 0)
                {
                    queue.Contains(2);
                    times--;
                }
            }

            //Prints test results on the console
            private void PrintTestResults()
            {
                Console.WriteLine("Elapsed time for searching 2 in Stack " +
                    SEARCHING_TIMES + " times: " + elapsedTimeStack + " milliseconds.");
                Console.WriteLine("Elapsed time for searching 2 in Queue " +
                    SEARCHING_TIMES + " times: " + elapsedTimeQueue + " milliseconds.");

                if (elapsedTimeStack == elapsedTimeQueue)
                {
                    Console.WriteLine("It's draw!");
                    return;
                }
                if (elapsedTimeStack > elapsedTimeQueue)
                    Console.WriteLine("Queue won!");
                else
                    Console.WriteLine("Stack won!");
            }
        }

        class DeletingTest
        {
            private Stack stack = new Stack();  //stack
            private Queue queue = new Queue();  //queue

            private long elapsedTimeStack;     //elapsed time for addition 1 to stack TIMES times
            private long elapsedTimeQueue;      //elapsed time for addition 1 to queue TIMES times

            const uint DELETING_TIMES = 100;        //deleting times
            const uint additionS_TIMES = 10000000;

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

                //deleting data from stack
                DeleteInStack(DELETING_TIMES);

                //stop-reset-start the stopwatch
                stopwatch.Stop();

                elapsedTimeStack = stopwatch.ElapsedMilliseconds;

                stopwatch.Reset();
                stopwatch.Start();

                //deleting data from queue
                DeleteInQueue(DELETING_TIMES);
                stopwatch.Stop();

                elapsedTimeQueue = stopwatch.ElapsedMilliseconds;
            }

            //Prepearing lists
            private void Prepare()
            {
                uint times = additionS_TIMES;
                while (times > 0)
                {
                    stack.Push(1);
                    queue.Enqueue(1);
                    times--;
                }
            }

            //Pop element from stack TIMES times
            private void DeleteInStack(uint times)
            {
                while (times > 0)
                {
                    stack.Pop();
                    times--;
                }
            }

            //Dequeue element from queue TIMES times
            private void DeleteInQueue(uint times)
            {
                while (times > 0)
                {
                    queue.Dequeue();
                    times--;
                }
            }

            //Prints test results on the console
            private void PrintTestResults()
            {
                Console.WriteLine("Elapsed time for pop element from Stack " +
                    DELETING_TIMES + " times: " + elapsedTimeStack + " milliseconds.");
                Console.WriteLine("Elapsed time for dequeue elemets from Queue " +
                    DELETING_TIMES + " times: " + elapsedTimeQueue + " milliseconds.");

                if (elapsedTimeStack == elapsedTimeQueue)
                {
                    Console.WriteLine("It's draw!");
                    return;
                }
                if (elapsedTimeStack > elapsedTimeQueue)
                    Console.WriteLine("Queue won!");
                else
                    Console.WriteLine("Stack won!");
            }
        }

        public StackVSQueue()
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
