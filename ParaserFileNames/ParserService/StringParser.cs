using ParaserEntities.Abstract;
using ParserService.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserService
{
    public class StringParser
    {
        private ISpecificParser<BaseFile> parser; 


        public BaseFile Parse(string text)
        {
            var substrings = text.Split(':');

            SelectSpecificParser(substrings);

            return parser.Parse(string.Join(null, RemoveContentTitle(substrings))); ;

        }

        private void SelectSpecificParser(string[] substrings)
        {
            substrings[0]= substrings[0].Replace(" ", "");

            if (substrings[0] == "Text")
                parser = new TextParser();

            else if (substrings[0] == "Movie")
                parser = new MovieParser();

            else if (substrings[0] == "Image")
                parser = new ImageParser();

            else throw new Exception("There is no suitable parser");
        }

        private static IEnumerable<string> RemoveContentTitle(string[] substrings)
        {
            return substrings.Except(new string[] { substrings[0] });
        }
    }
}
