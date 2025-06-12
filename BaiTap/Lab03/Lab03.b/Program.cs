using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab03
{
    internal class Class1
    {
        private Hashtable ht01;
        private bool haskey;
        private bool hasvalue;

        public Class1()
        {
            ht01 = new Hashtable();
            ht01.Add("a", 1);
            ht01.Add("b", 2);
            ht01.Add("c", 3);
            ht01.Add("d", 4);
            ht01.Add("e", 5);
            ht01.Add(1, "c");

            haskey = ht01.ContainsKey("a");
            if (haskey)
                ht01.Remove("c");

            haskey = ht01.ContainsKey("c");
            if (haskey)
                ht01.Remove("f");

            hasvalue = ht01.ContainsValue(3);
            hasvalue = ht01.ContainsValue(6);

            foreach (DictionaryEntry item in ht01)
            {
                Console.WriteLine($"Key: {item.Key}, Value: {item.Value}");
                Console.WriteLine();
            }

            Console.WriteLine("=============== KEYS ===============");
            foreach (var key in ht01.Keys)
            {
                Console.WriteLine($"Key: {key}");
            }

            Console.WriteLine("=============== VALUES ===============");
            foreach (var value in ht01.Values)
            {
                Console.WriteLine(value);
            }

            Hashtable ht02 = (Hashtable)ht01.Clone();
        }
    }
}