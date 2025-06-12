using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Nhap so luong phan tu n > 0: ");
        int n = int.Parse(Console.ReadLine());

        List<int> numbers = new List<int>();
        Random random = new Random();


        for (int i = 0; i < n; i++)
        {
            int value = random.Next(100); 
            numbers.Add(value);
        }


        Console.WriteLine("Danh sach truoc khi sap xep:");
        foreach (int num in numbers)
        {
            Console.Write(num + " ");
        }


        numbers.Sort();


        Console.WriteLine("\nDanh sach sau khi sap xep:");
        foreach (int num in numbers)
        {
            Console.Write(num + " ");
        }
    }
}
