using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        List<int> numbers = new List<int> { -3, 0, 5, 10, 13, 7, 1, 25, 12, -1 };
        List<int> result = numbers.Where(n => n >= 1 && n <= 12).ToList();
        Console.WriteLine("Các số dương từ 1 đến 12:");
        foreach (int num in result)
        {
            Console.Write(num + " ");
        }
    }
}
