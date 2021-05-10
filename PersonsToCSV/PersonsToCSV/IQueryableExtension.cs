using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace PersonsToCSV
{
    public static class IQueryableExtension
    {
        /// <summary>
        /// Writes the contents of the collection to a file
        /// </summary>
        /// <param name="collection">Collection to write</param>
        /// <param name="pathToFile">The path to the file where the collection should be written</param>
        public static void WriteToFile(this IQueryable collection, string pathToFile)
        {
            using (var streamWriter = new StreamWriter(pathToFile))
            {
                foreach (var entity in collection)
                {
                    var editedProperties = entity.ToString().Trim(new char[] { '{', '}' });

                    streamWriter.WriteLine(editedProperties);
                    streamWriter.Flush();
                }
            }
        }

        public static void OutputToConsole(this IQueryable collection)
        {
            Console.WriteLine();

            var resultingList = collection.ToStringList();

            foreach (var str in resultingList)
            {
                Console.WriteLine(str);
            }
        }

        /// <summary>
        /// Converts collection records to a list of strings
        /// </summary>
        /// <param name="collection">Collection to convert</param>
        /// <returns></returns>
        static public List<string> ToStringList(this IQueryable collection)
        {
            var result = new List<string>();

            foreach (var entity in collection)
            {
                string editedProperties = default;

                Type type = entity.GetType();

                var props = type.GetProperties();

                foreach (var prop in props)
                {
                    // Trying to get the value of service properties will throw an TargetParameterCountException
                    try
                    {
                        var value = prop.GetValue(entity);

                        if (value.IsDefault())
                        {
                            editedProperties += $"Empty;\t";
                            continue;
                        }

                        editedProperties += $"{value};\t";
                    }
                    catch (TargetParameterCountException)
                    {

                    }
                }
                result.Add(editedProperties);
            }
            return result;
        }
    }
}
