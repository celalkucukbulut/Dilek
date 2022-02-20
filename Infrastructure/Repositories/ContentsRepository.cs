using Core.Repositories.Dapper;
using Dapper;
using Domain.Domains;
using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ContentsRepository : DapperRepositoryBase<Contents>, IContentsRepository
    {
        public ContentsRepository(DapperHelper dapperHelper) : base(dapperHelper)
        {
        }

        public IEnumerable<Contents> getAllContactContents()
        {
            string sql = $@"Select * from Contents c Where c.DBCode = 7 or c.DBCode = 11 or c.DBCode = 12 ";
            sql += " Order by c.Id asc";
            return _dapperHelper.Connection.Query<Contents>(sql);
        }

        public IEnumerable<Contents> getAllContentsByDBCode(int dbCode)
        {
            string sql = $@"Select * from Contents c Where c.DBCode = @DBCode ";
            sql += " Order by c.Id asc";
            return _dapperHelper.Connection.Query<Contents>(sql, new { DBCode = dbCode });
        }

        public IEnumerable<Contents> getAllProductContents()
        {
            string sql = $@"Select * from Contents c Where c.DBCode = 4 or c.DBCode = 5 or c.DBCode = 6 or c.DBCode = 10  ";
            sql += " Order by c.Id asc";
            return _dapperHelper.Connection.Query<Contents>(sql);
        }
    }
}