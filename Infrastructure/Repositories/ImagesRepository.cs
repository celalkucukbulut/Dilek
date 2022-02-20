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
    public class ImagesRepository : DapperRepositoryBase<Images> , IImagesRepository
    {
        public ImagesRepository(DapperHelper dapperHelper) : base(dapperHelper)
        {
        }

        public IEnumerable<Images> getAllProducts()
        {
            string sql = $@"Select * from Images i Where i.DBCode = 4 or i.DBCode = 5 or i.DBCode = 6";
            sql += " Order by i.CreatedDate";
            return _dapperHelper.Connection.Query<Images>(sql);
        }

        public IEnumerable<Images> GetByDBCodes(int dbCode)
        {
            string sql = $@"Select * from Images i Where i.DBCode = @DBCode ";
            sql += " Order by i.CreatedDate";
            return _dapperHelper.Connection.Query<Images>(sql, new { DBCode = dbCode });
        }
    }
}
