using System;
using System.Collections.Generic;


namespace Class_7
{

    public class DataStorage<T> where T : new()
    {
        private List<T> storage = new List<T>();

        public void Add(T item)
        {
            storage.Add(item);
        }

        public bool Remove(T item)
        {
            return storage.Remove(item);
        }

        public T Retrieve(int index)
        {
            return storage[index];
        }

        public void DisplayAll()
        {
            foreach (T item in storage)
            {
                Console.WriteLine(item);
            }
        }
    }
}
