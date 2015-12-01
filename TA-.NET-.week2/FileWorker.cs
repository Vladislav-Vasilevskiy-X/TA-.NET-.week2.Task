using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace TA_.NET_.week2
{
    class FileWorker
    {
        //Binary formatter for objects serializtion
        private static BinaryFormatter formatter = new BinaryFormatter();

        //Returns deserialized toy from file
        public static Toy GetToyFromFile(string fileName)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Open))
            {
                //Deserializing toy
                return (Toy)formatter.Deserialize(fs);
            }
        }

        //Serializing and writing toy to the file
        public static void WriteToyToFile(Toy toy, string fileName)
        { 
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                //Serializing toy
                formatter.Serialize(fs, toy);
            }
        }
    }
}
