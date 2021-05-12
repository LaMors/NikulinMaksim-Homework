using System;
using System.Collections.Generic;
using System.Linq;

namespace CollectionsAndLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            var customers = new List<Customer>
            {
                new Customer(1, "Tawana Shope", new DateTime(2017, 7, 15), 15.8),
                new Customer(2, "Danny Wemple", new DateTime(2016, 2, 3), 88.54),
                new Customer(3, "Margert Journey", new DateTime(2017, 11, 19), 0.5),
                new Customer(4, "Tyler Gonzalez", new DateTime(2017, 5, 14), 184.65),
                new Customer(5, "Melissa Demaio", new DateTime(2016, 9, 24), 241.33),
                new Customer(6, "Cornelius Clemens", new DateTime(2016, 4, 2), 99.4),
                new Customer(7, "Silvia Stefano", new DateTime(2017, 7, 15), 40),
                new Customer(8, "Margrett Yocum", new DateTime(2017, 12, 7), 62.2),
                new Customer(9, "Clifford Schauer", new DateTime(2017, 6, 29), 89.47),
                new Customer(10, "Norris Ringdahl", new DateTime(2017, 1, 30), 13.22),
                new Customer(11, "Delora Brownfield", new DateTime(2011, 10, 11), 0),
                new Customer(12, "Sparkle Vanzile", new DateTime(2017, 7, 15), 12.76),
                new Customer(13, "Lucina Engh", new DateTime(2017, 3, 8), 19.7),
                new Customer(14, "Myrna Suther", new DateTime(2017, 8, 31), 13.9),
                new Customer(15, "Fidel Querry", new DateTime(2016, 5, 17), 77.88),
                new Customer(16, "Adelle Elfrink", new DateTime(2017, 11, 6), 183.16),
                new Customer(17, "Valentine Liverman", new DateTime(2017, 1, 18), 13.6),
                new Customer(18, "Ivory Castile", new DateTime(2016, 4, 21), 36.8),
                new Customer(19, "Florencio Messenger", new DateTime(2017, 10, 2), 36.8),
                new Customer(20, "Anna Ledesma", new DateTime(2017, 12, 29), 0.8)
            };

            FirstRegistered(customers);

            AverageScore(customers);

            GetByData(customers);

            GetById(customers);

            GetByName(customers);

            SortByMonthAndName(customers);

            SortByFild(customers);

            customers.NamesToConsol();

        }

        public static void FirstRegistered(IEnumerable<Customer> customers)
        {
            var customer = customers.FirstRegistered();
            Console.WriteLine($"{customer.Name}was the first to register. Registration date {customer.RegistrationDate}\n");
        }

        public static void AverageScore(IEnumerable<Customer> customers)
        {
            Console.WriteLine($"Average score of all customers: {customers.AverageScore()}\n");
        }

        public static void GetByData(IEnumerable<Customer> customers)
        {
            Console.WriteLine("Enter the first date\n");
            var firstDate = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("\nEnter the second date\n");
            var secondDate = Convert.ToDateTime(Console.ReadLine());

            var sortCustomers = customers.GetByData(firstDate, secondDate);

            if (sortCustomers.Count() != 0)
            {
                Console.WriteLine("\nSelected сustomers:\n");
                foreach (var customer in sortCustomers)
                {
                    Console.WriteLine($"{customer.Name}\t {customer.RegistrationDate}\n");
                }
            }

            else
            {
                Console.WriteLine("No results\n");
            }

        }

        public static void GetById(IEnumerable<Customer> customers)
        {
            Console.WriteLine("\nWrite id\n");

            var id = Convert.ToInt64(Console.ReadLine());

            var customer = customers.GetById(id);

            if (customer != null)
            {
                Console.WriteLine($"\n{customer.Name}\t {customer.Id}");
            }

            else
            {
                Console.WriteLine("\nNo results\n");
            }
        }

        public static void GetByName(IEnumerable<Customer> customers)
        {
            Console.WriteLine("Write what the name should contain\n");

            var sortCustomer = customers.GetByName(Console.ReadLine());

            if (sortCustomer.Count() != 0)
            {
                foreach (var customer in customers)
                {
                    Console.WriteLine($"\n{customer.Name}");
                }

            }

            else
            {
                Console.WriteLine("\nNo results\n");
            }
        }

        public static void SortByMonthAndName(IEnumerable<Customer> customers)
        {
            Console.WriteLine("Users sorted by month and name:\n");


            foreach (var customer in customers.SortByMonthAndName())
            {
                Console.WriteLine($"\n{customer.RegistrationDate.Month}\t{customer.Name}");
            }

        }

        public static void SortByFild(IEnumerable<Customer> customers)
        {
            Console.WriteLine("What field do we sort by?\n");

            var fildName = Console.ReadLine();

            Console.WriteLine("\nAscending or descending?\n");

            var direction = Console.ReadLine();

            foreach (var customer in customers.SortByFild(fildName, direction))
            {
                Console.WriteLine($"\n{customer.RegistrationDate.Month}\t{customer.Name}");
            }

        }
    }
}
