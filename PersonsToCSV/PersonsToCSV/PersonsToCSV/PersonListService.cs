using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Dynamic.Core.Exceptions;

namespace PersonsToCSV
{
    public class PersonListService
    {

        /// <summary>
        /// Gets the collection of the selected properties.
        /// Returns the original collection on failure.
        /// </summary>
        /// <param name="persons">List of persons whose properties are required</param>
        /// <param name="request">Requested properties</param>
        /// <param name="isSuccessfully">Flag indicating whether properties were retrieved successfully</param>
        /// <returns></returns>
        public IQueryable GetSelectionProperties(List<Person> persons, string request, out bool isSuccessfully)
        {
            var resultingCollection = persons.AsQueryable();
            try
            {
                isSuccessfully = true;

                return resultingCollection.Select($"new({request})");
            }

            catch (ParseException)
            {
                isSuccessfully =  false;
            }

            return resultingCollection;
        }
    }
}
