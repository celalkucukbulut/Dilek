using Core.Repositories;
using Domain.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IDBCodesRepository : IRepository<DBCodes>
    {
        IEnumerable<DBCodes> getProducts(int code);
    }
}
