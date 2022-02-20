using Core.Services.Interfaces;
using Domain.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.AdminsServices
{
    public interface IAdminsServices : IService
    {
        bool CheckLogin(string username,string password, ref Admin admin);
        bool CheckUserExist(string mailAddress);
        bool SendMail(string mailAddress);
    }
}
