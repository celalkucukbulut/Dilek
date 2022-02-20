using Core.Repositories.Dapper;
using Domain.Domains;
using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class DBCodesRepository : DapperRepositoryBase<DBCodes>, IDBCodesRepository
    {
        public DBCodesRepository(DapperHelper dapperHelper) : base(dapperHelper)
        {
        }
        public IEnumerable<DBCodes> getProducts(int code)
        {
            return null;
        }
    }
}
