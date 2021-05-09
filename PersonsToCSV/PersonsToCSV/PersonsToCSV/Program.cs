using System;
using System.Linq;

namespace PersonsToCSV
{
    class Program
    {
        static void Main(string[] args)
        {

            var persons = PersonList.GetListPerson();

            bool requestCompleted;

            var personListService = new PersonListService();

            Console.WriteLine("Еnter your request:");

            var userRequest = Console.ReadLine();

            var resultingCollection = personListService.GetSelectionProperties(persons, userRequest, out requestCompleted);

            if (requestCompleted)
            {
                resultingCollection.OutputToConsole();

                resultingCollection.ToStringList().AsQueryable().WriteToFile("SelectedPersonProperties.csv");
            }

            else
            {
                Console.WriteLine("You entered an invalid request");
            }

            Console.ReadLine();
        }
    }
}
