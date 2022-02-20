using Core.Repositories;
using Domain.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IForgotPasswordRepository : IRepository<ForgotPassword>
    {
        bool GetLastHashCode(string hash, ref int ID);
        void UpdateIsUsed(string hash);
        bool UpdatePassword(string password,int ID);
    }
}
