using ParaserEntities;
using ParserService;
using ParserView;
using System;

namespace ParaserFileNames
{
    class Program
    {
        static void Main(string[] args)
        {
            var sorter = new Sorter();

            var view = new ConsoleView();

            var sortedContent = sorter.Sort(@"Text: file.txt(6B); Some string content
                                             Image: img.bmp(19MB); 1920х1080
                                             Text:data.txt(12B); Another string
                                             Text:data1.txt(7B); Yet another string
                                             Movie:logan.2017.mkv(19GB); 1920х1080; 2h12m");

            view.Show(sortedContent);
            
        }
    }
}
