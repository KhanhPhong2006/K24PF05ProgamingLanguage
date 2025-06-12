using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ArrayList list01 = new ArrayList();  
            list01.Add(1);
            list01.Add(2);
            list01.Add(3);
            list01.Add(4);
            list01.Add(5);

            for (int i = 0; i < list01.Count; i++)
            {
                Console.WriteLine($"Item {i}: {list01[i]}"); 
            }
            list01.RemoveAt(3);
            list01.Insert(4, 10);
            list01.Insert(2, 8);
            Console.WriteLine($"Count: {list01.Count}");
            arraylist list02 = new ArrayList();
            list02.Add("A1");
            list02.Add("B1");
            list02.Add("C1");
            list02.Add("D1");
            list01.InsertRange(4, list02);
            list02.Remove("C1");
            list01.Remove("C2");
            list02,Clenar();


            Console.WriteLine($"list01 Count: {list01.Count}");
            Console.ReadLine();
        }
    }
}
