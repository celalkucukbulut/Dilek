using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Domains;
using Infrastructure.Interfaces;

namespace Services.DBCodesServices
{
    public class DBCodesServices : IDBCodesServices
    {
        private readonly IDBCodesRepository _dbCodesRepository;

        public DBCodesServices(IDBCodesRepository dbCodesRepository)
        {
            _dbCodesRepository = dbCodesRepository;
        }

        public IEnumerable<DBCodes> getAllCodes()
        {
            var codes = _dbCodesRepository.GetList();
            return codes;
        }

        public DBCodes getCode(int id)
        {
            var code = _dbCodesRepository.Get(id);
            return code;
        }

        public IEnumerable<DBCodes> getProducts(int code)
        {
            return null;
        }
    }
}
