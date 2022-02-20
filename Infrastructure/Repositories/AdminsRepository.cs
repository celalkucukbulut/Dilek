using Core.Extensions;
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
    public class AdminsRepository :DapperRepositoryBase<Admin>, IAdminsRepository
    {
        public AdminsRepository(DapperHelper dapperHelper) : base(dapperHelper)
        {
        }

        public bool checkUserExist(string mailAddress)
        {
            string sql = $@"Select * from Admins a Where a.MailAddress = @mailAddress ";
            var result = _dapperHelper.Connection.Query<Admin>(sql, new { mailAddress = mailAddress });
            if (result.Count() == 1)
            {
                return true;
            }
            return false;
        }

        public Admin getAdminByEmail(string mailAddress)
        {
            string sql = $@"Select * from Admins a Where a.MailAddress = @mailAddress ";
            var result = _dapperHelper.Connection.Query<Admin>(sql, new { mailAddress = mailAddress });
            return result.FirstOrDefault();
        }

        public Admin Login(string username, string password)
        {
            password = password.ToSha256();
            string sql = $@"Select * from Admins a Where a.Username = @Username and a.Password = @Password ";
            var result = _dapperHelper.Connection.Query<Admin>(sql, new { Username = username, Password = password });
            return result.FirstOrDefault();
        }
    }
}
