using ParaserEntities;
using ParserService.Abstract;
using System;
using System.Linq;

namespace ParserService
{
    public class TextParser : ISpecificParser<Text>
    {
        public Text Parse(string text)
        {

            var substings = text.Split(new char[] { '(', ')', ';' }, StringSplitOptions.RemoveEmptyEntries);

            var name = substings[0];

            var tempString = substings[0].Split('.');

            var extension = tempString[tempString.Length-1];


            return new Text()
            {
                Name = name,
                Extension = extension,
                Size = substings[1],
                Content = substings[2]
            };
        }
    }
}
