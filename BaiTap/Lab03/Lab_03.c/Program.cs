using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_03.c
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedList mySL = new System.Collections.Generic.SortedList();
            mySL.Add("Third", "!");
            mySL.Add("Second", "World");
            mySL.Add("First", "Hello");

            Console.WriteLine("mySL");
            Console.WriteLine(value: $"Count: {mySL.Count}");
            Console.WriteLine("Keys:");
        }
    }
}
