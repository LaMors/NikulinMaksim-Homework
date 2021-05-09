using DI.App.Abstractions;
using DI.App.Abstractions.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI.App.Models
{
    public static class UserMapper
    {
        public static User ToUser(this IDbEntity entity)
        {
            return new User { Id = entity.Id };
        }
    }
}
