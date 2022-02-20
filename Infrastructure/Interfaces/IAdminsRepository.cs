using Core.Repositories;
using Domain.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IAdminsRepository : IRepository<Admin>
    {
        Admin Login(string username, string password);
        bool checkUserExist(string mailAddress);
        Admin getAdminByEmail(string mailAddress);
    }
}
