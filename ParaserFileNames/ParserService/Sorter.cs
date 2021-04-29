using ParaserEntities;
using ParaserEntities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserService
{
    public class Sorter
    {
        /// <summary>
        /// </summary>
        /// <param name="content"></param>
        /// <returns>Content sorted by categories</returns>
        public List<string> Sort(string content)
        {
            //Below are Indian tricks. Please don't hit me
            var stringParser = new StringParser();

            var partedContent = new List<string>();

            var substrings = content.Split('\n');

            var images = new List<Image>();

            var movies = new List<Movie>();

            var texts = new List<Text>();



            foreach (var substring in substrings)
            {
                var temp = stringParser.Parse(substring);

                if (temp is Image image)
                    images.Add(image);

                else if (temp is Movie movie)
                    movies.Add(movie);

                else if (temp is Text text)
                    texts.Add(text);

                else throw new Exception("It is impossible to determine the object");

            }

            partedContent.Add("Text files:");
            texts.Sort();
            foreach (var text in texts)
            {
                foreach (var information in text.GetInformation())
                {
                    partedContent.Add(" " + information);
                }
            }

            partedContent.Add("Movies:");
            movies.Sort();
            foreach (var movie in movies)
            {
                foreach (var information in movie.GetInformation())
                {
                    partedContent.Add(" " + information);
                }
            }

            partedContent.Add("Images:");
            images.Sort();
            foreach (var image in images)
            {
                foreach (var information in image.GetInformation())
                {
                    partedContent.Add(" "+information);
                }
            }

            return partedContent;
        }
    }
}
