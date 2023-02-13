using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTableAndBinaryTree
{
    public class MyNodeClass<K,V>
    {
        public struct KeyValue<k, v>
        {
            public k Key { get; set; }
            public v Value { get; set; }
        }
        //Variable
        readonly int size;
        readonly LinkedList<KeyValue<K, V>>[] items; //array

        public MyNodeClass(int size)
        {
            this.size =size;
            this.items = new LinkedList<KeyValue<K, V>>[size];  //initiliztion array
        }
        public int GetArrayPosition(K key)
        {
            int hash = key.GetHashCode();
            int position = hash%size;//Reminder
            return Math.Abs(position);
        }
        public LinkedList<KeyValue<K, V>> GetArrayPositionAndLinkedList(K key)
        {
            int position = GetArrayPosition(key); //index number of array
            LinkedList<KeyValue<K, V>> linkedList = GetLinkedList(position);
            return linkedList;
        }
        protected LinkedList<KeyValue<K, V>> GetLinkedList(int position)
        {
            LinkedList<KeyValue<K, V>> linkedlist = items[position];
            if (linkedlist ==null)
            {
                linkedlist = new LinkedList<KeyValue<K, V>>();
                items[position] = linkedlist;
            }
            return linkedlist;
        }
        public V Get(K key)
        {
            var GetlinkedList = GetArrayPositionAndLinkedList(key);
            foreach (KeyValue<K, V> data in GetlinkedList)
            {
                if (data.Key.Equals(key))
                    return data.Value;
            }
            return default(V);
        }
        /// <summary>
        /// Add Data on Hash Table
        /// </summary>
        /// <param name="Key"></param>
        /// <param name="value"></param>
        public void Add(K key, V value)
        {
            var AddlinkedList = GetArrayPositionAndLinkedList(key);
             KeyValue<K, V> item = new KeyValue<K, V>() { Key = key, Value = value };//Struct Object with value
            if (AddlinkedList.Count != 0)
            {
                foreach (KeyValue<K, V> item1 in AddlinkedList)
                {
                    if (item1.Key.Equals(key))
                    {
                        Remove(key);
                        break;
                    }
                }
            }
            AddlinkedList.AddLast(item); 
           // Console.WriteLine(item.Key + " " + item.Value);
        }/// <summary>
        /// Remove data
        /// </summary>
        /// <param name="key"></param>
        public void Remove(K key)
        {
            var linkedList = GetArrayPositionAndLinkedList(key);
            bool itemFound = false;
            KeyValue<K, V> fonditem = default(KeyValue<K, V>);
            foreach (KeyValue<K, V> item in linkedList)
            {
                if (item.Key.Equals(key))
                {
                    itemFound = true;
                    fonditem = item;
                }
            }
            if (itemFound)
            {
                linkedList.Remove(fonditem);
               // Console.WriteLine("Remove that data"+fonditem.Key);
            }
        }
        public bool Exists(K key)
        {
            var linkedList = GetArrayPositionAndLinkedList(key);
            foreach (KeyValue<K, V> item in linkedList)
            {
                if (item.Key.Equals(key))
                {
                    return true;
                }
            }
            return false;
        }
        public void Display()
        {
            foreach (var linkedList in items)
            {
                if (linkedList != null)
                {
                    foreach (var element in linkedList)
                    {
                        string res = element.ToString();
                        if (res != null)
                            Console.WriteLine(element.Key + " " + element.Value);
                    }
                }
            }
        }
    }
}
