using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ColectionsSpeedTest.Tests
{
    class HashTableVSDictionary
    {
        static Random random = new Random();

        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789"; //chars for Key generator
        static int MAX_VALUE = 1 << 20;     //max value for Hastable/Dictoinary element
        static int MIN_VALUE = 1 << 2;      //min value for Hastable/Dictoinary element
        static int KEY_LENGTH = 11;          //key's length for Hastable/Dictoinary element

        class AdditionTest
        {
            private Hashtable hashtable = new Hashtable();  //hashtable
            private Dictionary<string, int> dictionary = new Dictionary<string, int>();  //dictionary

            private long elapsedTimeHashtable;     //elapsed time for addition 1 to hashtable TIMES times
            private long elapsedTimeDictionary;      //elapsed time for addition 1 to dictionary TIMES times

            const uint TIMES = 1000000;            //addition times

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

                //addition data to hashtable
                AddDataToHashtable(TIMES);

                //stop-reset-start the stopwatch
                stopwatch.Stop();

                elapsedTimeDictionary = stopwatch.ElapsedMilliseconds;

                stopwatch.Reset();
                stopwatch.Start();

                //addition data to dictionary
                AddDataToDictionary(TIMES);
                stopwatch.Stop();

                elapsedTimeHashtable = stopwatch.ElapsedMilliseconds;
            }

            //addition random element to hashtable TIMES times
            private void AddDataToHashtable(uint times)
            {
                while (times > 0)
                {
                    hashtable.Add(RandomKeyGenerator(KEY_LENGTH), RandomValueGenerator());
                    times--;
                }
            }

            //addition random element to dictionary TIMES times
            private void AddDataToDictionary(uint times)
            {
                while (times > 0)
                {
                    dictionary.Add(RandomKeyGenerator(KEY_LENGTH), RandomValueGenerator());
                    times--;
                }
            }

            //Prints test results on the console
            private void PrintTestResults()
            {
                Console.WriteLine("Elapsed time for addition random element to hashtable " +
                    TIMES + " times: " + elapsedTimeDictionary + " milliseconds.");
                Console.WriteLine("Elapsed time for addition random element to dictionary " +
                    TIMES + " times: " + elapsedTimeHashtable + " milliseconds.");

                if (elapsedTimeDictionary == elapsedTimeHashtable)
                {
                    Console.WriteLine("It's draw!");
                    return;
                }
                if (elapsedTimeDictionary > elapsedTimeHashtable)
                    Console.WriteLine("Dictionary won!");
                else
                    Console.WriteLine("Hashtable won!");
            }

        }

        class SearchingTest
        {
            private Hashtable hashtable = new Hashtable();  //hashtable
            private Dictionary<string, int> dictionary = new Dictionary<string, int>();  //dictionary

            private long elapsedTimeHashtable;     //elapsed time for addition 1 to hashtable TIMES times
            private long elapsedTimeDictionary;      //elapsed time for addition 1 to dictionary TIMES times

            const uint SEARCHING_TIMES = 1000;       //searching times
            const uint ADDITION_TIMES = 100000;   //addition times    

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

                //addition data to hashtable
                SearchInHashTable(SEARCHING_TIMES);

                //stop-reset-start the stopwatch
                stopwatch.Stop();

                elapsedTimeDictionary = stopwatch.ElapsedMilliseconds;

                stopwatch.Reset();
                stopwatch.Start();

                //addition data to dictionary
                SearchInDictionary(SEARCHING_TIMES);
                stopwatch.Stop();

                elapsedTimeHashtable = stopwatch.ElapsedMilliseconds;
            }

            //Preparing hashtable and dictionary for searching test
            private void Prepare()
            {
                AddDataToHashtable(ADDITION_TIMES / 2);
                hashtable.Add("MySpecificKey", 123421);
                AddDataToHashtable(ADDITION_TIMES / 2 - 1);

                AddDataToDictionary(ADDITION_TIMES / 2);
                dictionary.Add("MySpecificKey", 123421);
                AddDataToDictionary(ADDITION_TIMES / 2 - 1);
            }

            //addition random element to hashtable TIMES times
            private void AddDataToHashtable(uint times)
            {
                while (times > 0)
                {
                    hashtable.Add(RandomKeyGenerator(KEY_LENGTH), RandomValueGenerator());
                    times--;
                }
            }

            //addition random element to dictionary TIMES times
            private void AddDataToDictionary(uint times)
            {
                while (times > 0)
                {
                    dictionary.Add(RandomKeyGenerator(KEY_LENGTH), RandomValueGenerator());
                    times--;
                }
            }

            //Searching "MySpecificKey" in hashtable SEARCHING_TIMES times
            private void SearchInHashTable(uint times)
            {
                while(times > 0)
                {
                    hashtable.Contains("MySpecificKey");
                    times--;
                }
            }

            //Searching "MySpecificKey" in dictionary SEARCHING_TIMES times
            private void SearchInDictionary(uint times)
            {
                while (times > 0)
                {
                    dictionary.ContainsKey("MySpecificKey");
                    times--;
                }
            }

            //Prints test results on the console
            private void PrintTestResults()
            {
                Console.WriteLine("Elapsed time for searching element at hashtable " +
                    SEARCHING_TIMES + " times: " + elapsedTimeDictionary + " milliseconds.");
                Console.WriteLine("Elapsed time for searching element at dictionary " +
                    SEARCHING_TIMES + " times: " + elapsedTimeHashtable + " milliseconds.");

                if (elapsedTimeDictionary == elapsedTimeHashtable)
                {
                    Console.WriteLine("It's draw!");
                    return;
                }
                if (elapsedTimeDictionary > elapsedTimeHashtable)
                    Console.WriteLine("Dictionary won!");
                else
                    Console.WriteLine("Hashtable won!");
            }
        }

        class DeletingTest
        {
            private Hashtable hashtable = new Hashtable();  //hashtable
            private Dictionary<string, int> dictionary = new Dictionary<string, int>();  //dictionary

            private Queue queueOfHastableKeys = new Queue();    //queue contains all randomly generated keys for hashtable
            private Queue queueOfDictionaryKeys = new Queue();  //queue contains all randomly generated keys for dictionary

            private long elapsedTimeHashtable;     //elapsed time for addition 1 to hashtable TIMES times
            private long elapsedTimeDictionary;      //elapsed time for addition 1 to dictionary TIMES times

            const uint DELETING_TIMES = 1000;       //deleting times
            const uint ADDITION_TIMES = 100000;   //addition times    

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

                //addition data to hashtable
                DeleteInHashTable(DELETING_TIMES);

                //stop-reset-start the stopwatch
                stopwatch.Stop();

                elapsedTimeDictionary = stopwatch.ElapsedMilliseconds;

                stopwatch.Reset();
                stopwatch.Start();

                //addition data to dictionary
                DeleteInDictionary(DELETING_TIMES);
                stopwatch.Stop();

                elapsedTimeHashtable = stopwatch.ElapsedMilliseconds;
            }

            //Preparing hashtable and dictionary for deleting test
            private void Prepare()
            {
                uint times = ADDITION_TIMES;
                while (times > 0)
                {
                    //preparing hashtable and it's key's queue
                    string key = RandomKeyGenerator(KEY_LENGTH);
                    hashtable.Add( key, RandomValueGenerator());
                    queueOfHastableKeys.Enqueue(key);

                    //preparing dictionary and it's key's queue
                    key = RandomKeyGenerator(KEY_LENGTH);
                    dictionary.Add( key, RandomValueGenerator());
                    queueOfDictionaryKeys.Enqueue(key);

                    times--;
                }
            }

            //Deleting element in hashtable DELETING_TIMES times
            private void DeleteInHashTable(uint times)
            {
                while (times > 0)
                {
                    hashtable.Remove((string)queueOfHastableKeys.Dequeue());
                    times--;
                }
            }

            //Deleting element in dictionary DELETING_TIMES times
            private void DeleteInDictionary(uint times)
            {
                while (times > 0)
                {
                    dictionary.Remove((string)queueOfDictionaryKeys.Dequeue());
                    times--;
                }
            }

            //Prints test results on the console
            private void PrintTestResults()
            {
                Console.WriteLine("Elapsed time for deleting element from hashtable " +
                    DELETING_TIMES + " times: " + elapsedTimeDictionary + " milliseconds.");
                Console.WriteLine("Elapsed time for deleting element from dictionary " +
                    DELETING_TIMES + " times: " + elapsedTimeHashtable + " milliseconds.");

                if (elapsedTimeDictionary == elapsedTimeHashtable)
                {
                    Console.WriteLine("It's draw!");
                    return;
                }
                if (elapsedTimeDictionary > elapsedTimeHashtable)
                    Console.WriteLine("Dictionary won!");
                else
                    Console.WriteLine("Hashtable won!");
            }
        }

        public HashTableVSDictionary()
        {
            RunTests();
        }

        public static string RandomKeyGenerator(int length)
        {
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static int RandomValueGenerator()
        {
            return random.Next(MIN_VALUE, MAX_VALUE);
        }


        private void RunTests()
        {
            new AdditionTest();
            new SearchingTest();
            new DeletingTest();
        }
    }
}
