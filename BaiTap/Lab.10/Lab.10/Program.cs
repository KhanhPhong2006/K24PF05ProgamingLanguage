using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab._10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };
            List<int> squaredNumbers = numbers.Select(n => n * n).ToList();
            Console.WriteLine("Squared Numbers:");
            foreach (var number in squaredNumbers)
            {
                Console.WriteLine(number);
            }

            List<Customer> MyCustomerList = new List<Customer>
                     {
                         new Customer { customerID = "C001", customerName = "John Doe", City = "New York" },
                         new Customer { customerID = "C002", customerName = "Jane Smith", City = "Los Angeles" },
                         new Customer { customerID = "C003", customerName = "Sam Brown", City = "Chicago" }
                     };

            var query = from c in MyCustomerList
                        where c.City == "New York"
                        select new { c.customerID, c.customerName };

            foreach (var c in query)
            {
                Console.WriteLine($"Customer ID: {c.customerID}, Name: {c.customerName}");
            }

            List<int> list1 = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };
            var sortedNumbers = list1.OrderBy(n => n);
            foreach (var number in sortedNumbers)
            {
                Console.WriteLine(number);
            }
            var PFullname = from p in MyCustomerList
                            where p.City == "New York"
                            select new { FullName = p.customerName + " from " + p.City };
            List<int> list2 = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };
            var groupedNumbers = list2.GroupBy(n => n % 2 == 0 ? "Even" : "Odd");
            foreach (var group in groupedNumbers)
            {
                Console.WriteLine($"{group.Key}");
                foreach (var number in group)
                {
                    Console.WriteLine(number);
                }
            }

            List<Person> people = GenerateListofPeople();
            var companies = GenerateCompanies();
            var peolesWhithCompaies = people.Join(companies,
                      person => person.CompanyID,
                      company => company.CompanyID,
                      (person, company) => new
                      {
                          person.Name,
                          person.Age,
                          company.CompanyName
                      });
        }

        public class Customer
        {
            public string customerID { get; set; }
            public string customerName { get; set; }
            public string City { get; set; }
        }

        // Fix for CS0246: Define the 'Person' class  
        public class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public int CompanyID { get; set; }
        }

        // Fix for CS0103: Define the 'GenerateListofPeople' method  
        public static List<Person> GenerateListofPeople()
        {
            return new List<Person>
               {
                   new Person { Name = "Alice", Age = 30, CompanyID = 1 },
                   new Person { Name = "Bob", Age = 25, CompanyID = 2 },
                   new Person { Name = "Charlie", Age = 35, CompanyID = 1 }
               };
        }

        // Define the 'GenerateCompanies' method  
        public static List<Company> GenerateCompanies()
        {
            return new List<Company>
               {
                   new Company { CompanyID = 1, CompanyName = "TechCorp" },
                   new Company { CompanyID = 2, CompanyName = "Innovate Inc." }
               };
        }

        public class Company
        {
            public int CompanyID { get; set; }
            public string CompanyName { get; set; }
        }
        
    }
}
 
