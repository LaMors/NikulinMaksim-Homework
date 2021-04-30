using System.Collections.Generic;
using System.Linq;
using DI.App.Abstractions;
using DI.App.Abstractions.BLL;

namespace DI.App.Services
{
    public class InMemoryDatabaseService : IDatabaseService<IDbEntity>
    {
        private readonly Dictionary<int, IDbEntity> inMemoryDatabase = new Dictionary<int, IDbEntity>();

        public IEnumerable<IDbEntity> Read() 
            
        {
            return this.inMemoryDatabase.Values
                .Where(v => v is IDbEntity)
                .Cast<IDbEntity>()
                .AsEnumerable();
        }

        public void Write(params IDbEntity[] data)
        {
            foreach (var entity in data)
            {
                this.inMemoryDatabase.TryAdd(entity.Id, entity);
            }
        }
    }
}