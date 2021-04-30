using System.Collections.Generic;

namespace DI.App.Abstractions
{
    public interface IDatabaseService<out T, in N> 
        where T : IDbEntity 
        where N : IDbEntity
    {
        IEnumerable<T> Read();

        void Write(params N[] data) ;
    }
}