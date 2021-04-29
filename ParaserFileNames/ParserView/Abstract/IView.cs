using ParaserEntities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserView.Abstract
{
    public interface IView<T>
    {
        void Show(T content);
    }
}
