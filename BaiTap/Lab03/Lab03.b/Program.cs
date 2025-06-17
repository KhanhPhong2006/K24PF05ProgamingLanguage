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
        private readonly Hashtable ht01; // Fix for IDE0044: Make field readonly
        private readonly bool hasKey;    // Fix for IDE0044: Make field readonly

        public Class1()
        {
            ht01 = new Hashtable();
            ht01.Add("a", 1);
            ht01.Add("b", 2);
            ht01.Add("c", 3);
            ht01.Add("d", 4);
            ht01.Add("e", 5);
            ht01.Add(1, "c");

            hasKey = ht01.ContainsKey("a");
            if (hasKey)
                ht01.Remove("c");

            hasKey = ht01.ContainsKey("c");
            if (hasKey)
                ht01.Remove("f");

            bool containsValue = ht01.ContainsValue(3); // Fix for SPELL: Rename 'hasvalue' to 'containsValue'
            containsValue = ht01.ContainsValue(6);

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

            var ht02 = (Hashtable)ht01.Clone();
        }

      
    }
}