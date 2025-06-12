using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab03.c
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack myStack = new Stack();
            myStack.Push(1);
            myStack.Push(2);
            myStack.Push(3);
            myStack.Push(4);
            var a = myStack.Pop();
            var b = myStack.Peek();
            
            myStack.Clear();
           bool has2 = myStack.Contains(2);
           bool hasz = myStack.Contains("z");

            Queue myQueue01 = new Queue();
            myQueue01.Enqueue(1);
            myQueue01.Enqueue(2);
            myQueue01.Enqueue(3);
            myQueue01.Enqueue(4);
            myQueue01.Enqueue(5); 
            myQueue01.Enqueue("Bob");
            myQueue01.Enqueue("Alice");
            myQueue01.Enqueue("Charlie");
            var item01 = myQueue01.Dequeue();
            Console.WriteLine($"Dequeued item: {item01}");
            Console.ReadLine();
        }
    }
}
