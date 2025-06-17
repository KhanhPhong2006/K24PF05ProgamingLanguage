using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab03.c
{
    internal class QueueExample
    {
        private static List<Student> studentsList = new List<Student>(); // Fixed the type of studentsList  

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

            List<string> fruits = new List<string>();
            fruits.Add("Apple");
            fruits.Add("Banana");
            fruits.Add("Cherry");
            fruits.Insert(1, "Blueberry");
            Console.WriteLine("Contains 'Banana': " + fruits.Contains("Banana"));
            fruits.Remove("Banana");
            fruits.RemoveAt(0);

            foreach (var fruit in fruits)
            {
                Console.WriteLine(fruit);
                Dictionary<string, int> ages = new Dictionary<string, int>();
                ages.Add("Alice", 30);
                ages.Add("Bob", 25);

                if (ages.ContainsKey("Alice"))
                    Console.WriteLine("Alice 's age: " + ages["Alice"] + "year old.");
                ages["Alice"] = 26; // Update Bob's age
                ages.Remove("Bob"); // Remove Bob from the dictionary

                foreach (var kvp in ages)
                    Console.WriteLine($"Name: {kvp.Key}, Age: {kvp.Value}");
            }
            Console.ReadLine();
        }

        public class Student
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }

        public static void DisplayStudents()
        {
            Console.WriteLine("==== List<Student> ====");
            List<Student> students = new List<Student>
                      {
                          new Student { Name = "Alice", Age = 20 },
                          new Student { Name = "Bob", Age = 22 },
                          new Student { Name = "Charlie", Age = 21 }
                      };

            studentsList.Add(new Student { Name = "David", Age = 23 });
            students.Insert(1, new Student { Name = "Eve", Age = 24 });
            students.RemoveAt(2);
        }
        public static void QueueExamp()
        {
            Queue<string> Tasks = new Queue<string>();
            Tasks.Enqueue("Download file ");
            Tasks.Enqueue("Scan file");
            Console.WriteLine("Next task:" + Tasks.Peek());
            Console.WriteLine("Processing task: " + Tasks.Dequeue());

            foreach (var task in Tasks)
            {
                Console.WriteLine("Task: " + task);
            }
        }
    }
}
