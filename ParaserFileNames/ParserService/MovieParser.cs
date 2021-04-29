using ParaserEntities;
using ParserService.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserService
{
    public class MovieParser : ISpecificParser<Movie>
    {
        public Movie Parse(string text)
    {

            var substings = text.Split(new char[] { '(', ')', ';' }, StringSplitOptions.RemoveEmptyEntries);

            var name = substings[0];

            var tempString = substings[0].Split('.');

            var extension = tempString[tempString.Length-1];

            return new Movie()
        {
            Name = name,
            Extension = extension,
            Size = substings[1],
            Resolution = substings[2],
            Length = substings[3]
        };
    }
}
}
