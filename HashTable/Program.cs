using System;

namespace HashTable
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Hash Table");
            //Declaring MyMapNode object with data type and size of array in parametrized constructor
            MyMapNode<string, string> hash = new MyMapNode<string, string>(5);
            //Adding values in hashtable.
            hash.Add("0", "To");
            hash.Add("1", "be");
            hash.Add("2", "or");
            hash.Add("3", "not");
            hash.Add("4", "To");
            hash.Add("5", "be");
            //getting the specific value from hashtable.
            string hash5 = hash.Get("5");
            Console.WriteLine("5th index value:" + hash5);
            //Displaying all the elements from the linkedlist
            Console.WriteLine("****************");
            Console.WriteLine("Displaying all the key value pairs in hash table");
            hash.Display();

        }
    }
}
