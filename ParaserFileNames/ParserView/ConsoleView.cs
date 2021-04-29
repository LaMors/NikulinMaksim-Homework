using ParaserEntities.Abstract;
using ParserView.Abstract;
using System;
using System.Collections.Generic;

namespace ParserView
{
    public class ConsoleView : IView<List<string>>
    {
        public void Show(List<string> content)
        {
            foreach (var str in content)
            {
                Console.WriteLine(str);
            }
        }
    }
}
