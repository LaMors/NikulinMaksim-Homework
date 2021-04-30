using System.Collections.Generic;

namespace DI.App.Abstractions
{
    public interface IDatabaseService<T> where T : IDbEntity
    {
        IEnumerable<T> Read();

        void Write(params T[] data);
    }
}