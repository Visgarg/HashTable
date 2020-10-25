using System;
using System.Collections.Generic;

namespace HashTable
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Hash Table");
            //Declaring MyMapNode object with data type and size of array in parametrized constructor
            MyMapNode<string, int> hash = new MyMapNode<string, int>(5);
            //Adding values in hashtable.
            //hash.Add("0", "To");
            //hash.Add("1", "be");
            //hash.Add("2", "or");
            //hash.Add("3", "not");
            //hash.Add("4", "To");
            //hash.Add("5", "be");
            //getting the specific value from hashtable.
            //string hash5 = hash.Get("5");
            //Console.WriteLine("5th index value:" + hash5);

            //creating a string of long sentence
            string words = "Paranoids are not paranoid because they are paranoid but because they keep putting themselves deliberately into paranoid avoidable situations";
            //adding values into array
            string[] arr = words.Split(" ");
            //creating a linkedlist to check for duplicates value
            //if duplicate value is coming inside a array, as previous element(when it was not in list) would already contain total count of same elements
            //it will be skipped
            LinkedList<string> checkForDuplication = new LinkedList<string>();
            //iterating loop over the array of sentence words
            foreach(string element in arr)
            {
                //count iterator for counting no of times word is coming
                int count = 0;
                //another foreach loop to check if other same element is present
                //if present counter is incremented
                foreach(string match in arr)
                {
                    if(element==match)
                    {
                        count++;
                        //if same element is coming in 2nd time, it will be presnent in linkedlist, so loopwill break and no further counting will be done
                        if(checkForDuplication.Contains(element))
                        {
                            break;
                        }
                    }
                    
                }
                //if element is already there in list, outer loop will be continued and loop will shift to next value
                //basically only values appearing for 1st time, will be added in linkedlist and added in hash table, so that frequency can be displayed.
                if(checkForDuplication.Contains(element))
                {
                    continue;
                }
                //added element in linkedlist
                checkForDuplication.AddLast(element);
                //added element and it's frequency in hashtable.
                hash.Add(element, count);
            }
            //getting the specific value from hashtable.
            int frequency = hash.Get("Paranoids");
            Console.WriteLine("frequency for Paranoids:\t"+frequency);

            //Displaying all the elements from the linkedlist
            Console.WriteLine("****************");
            Console.WriteLine("Displaying all the key value pairs in hash table");
            hash.Display();

        }
    }
}
