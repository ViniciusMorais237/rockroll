using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Domain.Interfaces.Repositories
{
    public interface IUoW
    {
        Task Begin();
        Task Commit();
        Task Rollback();
        Task Dispose();
    }
}