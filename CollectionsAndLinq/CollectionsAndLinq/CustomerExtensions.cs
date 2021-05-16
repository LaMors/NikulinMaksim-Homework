using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;

namespace CollectionsAndLinq
{
    public static class CustomerExtensions
    {
        public static Customer FirstRegistered(this IEnumerable<Customer> customers)
        {
            return customers.OrderBy(customer => customer.RegistrationDate).First();
        }

        public static double AverageScore(this IEnumerable<Customer> customers)
        {
            var sumBalance = customers.Sum(sum => sum.Balance);

            return sumBalance / customers.Count();
        }

        public static IEnumerable<Customer> GetByData(this IEnumerable<Customer> customers, DateTime firstDate, DateTime secondDate)
        {
            if (firstDate > secondDate)
            {
                return customers.Where(customer => customer.RegistrationDate <= firstDate && customer.RegistrationDate >= secondDate)
                                        .OrderBy(customer => customer.RegistrationDate);
            }
            return customers.Where(customer => customer.RegistrationDate >= firstDate && customer.RegistrationDate <= secondDate)
                                        .OrderBy(customer => customer.RegistrationDate);
        }

        public static Customer GetById(this IEnumerable<Customer> customers, long Id)
        {
            return customers.Where(customer => customer.Id == Id).FirstOrDefault();
        }

        public static IEnumerable<Customer> GetByName(this IEnumerable<Customer> customers, string name)
        {
            return customers.Where(customer => customer.Name.ToLower().Contains(name.ToLower()));
        }

        public static IEnumerable<Customer> SortByMonthAndName(this IEnumerable<Customer> customers)
        {
            return customers.OrderBy(customer => customer.RegistrationDate.Month)
                            .ThenBy(customer => customer.Name);
        }

        public static IQueryable<Customer> SortByFild(this IEnumerable<Customer> customers, string fildName, string direction)
        {
            var sortCustomers = customers.AsQueryable();

            try
            {
                sortCustomers = sortCustomers.OrderBy($"customer => customer.{fildName}");
            }

            catch (Exception)
            {
                return sortCustomers;
            }

            if (direction.ToLower() == "ascending")
            {
                return sortCustomers;
            }

            else if (direction.ToLower() == "descending")
            {
                return sortCustomers.Reverse();
            }

            else return sortCustomers;
        }

        public static void NamesToConsol(this IEnumerable<Customer> customers)
        {
            string stringNames = string.Join(", ", customers.Select(customer => customer.Name));
            Console.WriteLine(stringNames);
        }
    }
}
