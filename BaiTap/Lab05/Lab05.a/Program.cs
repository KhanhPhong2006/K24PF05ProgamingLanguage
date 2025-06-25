using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab05.a
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int counter = 0;
            Action increment = () => counter++;
            increment();
            increment();

            Console.WriteLine(counter);
            int a = 5, b = 10;
            Console.WriteLine($"Before Swap: a = {a}, b = {b}");
            Swap(ref a, ref b);
            Console.WriteLine($"After Swap: a = {a}, b = {b}");
        }


        public static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
    }
}
