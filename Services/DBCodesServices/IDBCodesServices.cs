using Core.Services.Interfaces;
using Domain.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DBCodesServices
{
    public interface IDBCodesServices  : IService
    {
        IEnumerable<DBCodes> getAllCodes();
        DBCodes getCode(int id);
        IEnumerable<DBCodes> getProducts(int code);

    }
}
