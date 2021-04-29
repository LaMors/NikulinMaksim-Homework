
using ParaserEntities.Abstract;

namespace ParserService.Abstract
{
    public interface ISpecificParser<out T> where T: BaseFile
    {
        T Parse(string text);
    }
}
