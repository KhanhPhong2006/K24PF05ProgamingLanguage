using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        List<int> numbers = new List<int>
        {
            12, -5, 0, 7, -14, 25, -1, 3, 8, -9,
            17, -22, 4, -3, 10, -6, 31, -17, 2, -8,
            19, -12, 0, 23, -30, 11, -7, 5, -15, 9,
            26, -18, 6, -4, 13, -2, 16, -20, 1, -10,
            28, -11, 14, -13, 15, -19, 18, -16, 21, -21
        };

        
        List<int> squares = numbers
            .Where(n => n > 10)
            .Select(n => n * n)
            .ToList();

        Console.WriteLine("Bình phương các số lớn hơn 10:");
        foreach (int sq in squares)
        {
            Console.Write(sq + " ");
        }
    }
}
