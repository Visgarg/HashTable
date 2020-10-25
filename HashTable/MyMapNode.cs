using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace HashTable
{
    public class MyMapNode<K,V>
    {
        private readonly int size;
        //declaring an array named items whose datatype is linkedlist
        //linkedlist have it's data type defined as keyValue
        //keyValue is a struct defined at the end of this class
        //each element of array stores different linkedlist.
        private readonly LinkedList<keyValue<K, V>>[] items;

        /// <summary>
        /// Defining a constructor
        /// </summary>
        /// <param name="size">size of array is passed in it</param>
        public MyMapNode(int size)
        {
            this.size = size;
            //array of linkedlist size is defined
            this.items = new LinkedList<keyValue<K, V>>[size];
        }
        /// <summary>
        /// Position of array is returned where linkedlist is there
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        protected int GetArrayPosition(K key)
        {
            //For adding hash table using linkedlist
            //we have defined a array of linkedlist
            //when we pass a key and value to hashtable
            //hashcode is generated which tells about where the particular key and value will be stored
            //basically get hash code tells me in which linkedlist (out of all in arrays) key value pair will be stored
            //position of linkedlist is generated from below method
            int position = key.GetHashCode() % size;
            return Math.Abs(position);
        }
        /// <summary>
        /// Accessing linkedlist using position in array extracted from getarrayposition method
        /// </summary>
        /// <param name="position">position in array where linked list is present</param>
        /// <returns></returns>
        protected LinkedList<keyValue<K,V>> GetLinkedList(int position)
        {
            //linkedlist contains a data type of keyvalue.
            //position helps to findout the linkedlist in which key value pair will be inserted
            //position is passed into array of items and stored in variable linkedlist with data type as defined below.
            LinkedList<keyValue<K, V>> linkedList = items[position];
            //if linked list is not yet defined on that position, than a new linked  list is created
            //whenever a new position is generated first time, than linked list is made
            //after making linked list, if same position is generated again using hash code than same linked list is returned.
            if(linkedList==null)
            {
                linkedList = new LinkedList<keyValue<K, V>>();
                //adding a linkedlist in the given array position
                items[position] = linkedList;
            }
            //returning linked list.
            return linkedList;
        }
        /// <summary>
        /// This method is used to retreive value from the hashtable, when key is passed.
        /// </summary>
        /// <param name="key">key is the identification element for the hashtable.</param>
        /// <returns></returns>
        public V Get(K key)
        {
            //getting the position of the linkedlist in array, by getarrayposition method
            //gethashcode, inbuilt method is used to find out the position and returned here
            int position = GetArrayPosition(key);
            //linkedlist is accessed after getting the position from the array
            //getlinkedlist method is called with position of linkedlist in array
            LinkedList<keyValue<K, V>> linkedList = GetLinkedList(position);
            //linkedlist contains all the key value pairs for which same hashcode was generated 
            //each key value pair in linkedlist is of data type keyValue (struct) defined at end of class.
            //foreach loop is used to access the key and values from linkedlist
            foreach(keyValue<K,V> item in linkedList)
            {
                //if key element matches with the key in linkedlist, value is retuned
                //otherwise loop is iterated.
                if(item.Key.Equals(key))
                {
                    return item.Value;
                }
            }
            return default(V);
        }
        /// <summary>
        /// Add method is called to add key and values in the array
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Add(K key, V value)
        {
            //key is passed to getarrayposition and unique position is obtained, which tells about the array in which element will be stored
            int position = GetArrayPosition(key);
            //linkedlist is called by passing the position in array to getlinkedlist method.
            LinkedList<keyValue<K, V>> linkedList = GetLinkedList(position);
            //for adding value in linkedlist. Struct object is defined, like a class and key and value obtained as a parameter
            //to this method are passed as parameter to object
            //keyValue struct is instatiated and stores the key and value, which is passed as one object to linkedlist.
            keyValue<K, V> item = new keyValue<K, V>() { Key = key, Value = value };
            //keyvalue is added in the linkedlist.
            linkedList.AddLast(item);
        }
        /// <summary>
        /// Removing Key Value pair from linkedList
        /// </summary>
        /// <param name="key"></param>
        public void Remove(K key)
        {
            //getting the  position of linkedlist in which key value pair is stored and is to be removed
            int position = GetArrayPosition(key);
            //calling the dictionary from which element is to be removed.
            LinkedList<keyValue<K, V>> linkedList = GetLinkedList(position);
            bool itemFound = false;
            //if key of item matches from iteration done in particular linked list, key value pairs are assigned to foundItem variable.
            keyValue<K, V> foundItem = default(keyValue<K, V>);
            //iterating loop in linkedlist to find out the key
            foreach(keyValue<K,V> item in linkedList)
            {
                if(item.Key.Equals(key))
                {
                    itemFound = true;
                    foundItem = item;
                }
            }
            //if item is found, it is removed
            if(itemFound)
            {
                linkedList.Remove(foundItem);
            }
        }
        /// <summary>
        /// Displaying all the elments of hash table, by iterating over complete array
        /// </summary>
        public void Display()
        {
            //linkedlist is iterated in array
            foreach (var linkedList in items)
            {
                //linkedlist may be null, if hashcode never generated the positon of array 
                if (linkedList != null)
                    //if linkedlist is not null, linkedlist is iterated
                    foreach (keyValue<K,V> keyvalue in linkedList)
                    {
                        //
                        //string res = element.ToString();
                          Console.WriteLine(keyvalue.Key + " " + keyvalue.Value);
                    }
            }
        }
    }
    /// <summary>
    /// Defining a struct to store key and value
    /// struct is similar to class and used to hold values
    /// </summary>
    /// <typeparam name="k"></typeparam>
    /// <typeparam name="v"></typeparam>
    public struct keyValue<k, v>
    {

        public k Key { get; set; }
        public v Value { get; set; }

    }
}
