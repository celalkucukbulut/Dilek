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
    public class ForgotPasswordRepository : DapperRepositoryBase<ForgotPassword>, IForgotPasswordRepository
    {
        public ForgotPasswordRepository(DapperHelper dapperHelper) : base(dapperHelper)
        {
        }

        public bool GetLastHashCode(string hash,ref int ID)
        {
            string sql = $@"Select * from ForgotPassword fp Where fp.Hash = @Hash and fp.IsUsed=0 order by ID desc";
            var result = _dapperHelper.Connection.Query<ForgotPassword>(sql, new { Hash = hash }).FirstOrDefault();
            if (result!=null)
            {
                ID = result.AdminId;
                return true;
            }
            return false;
        }

        public void UpdateIsUsed(string hash)
        {
            string sql = $@"UPDATE ForgotPassword SET IsUsed = 1 Where Hash = @Hash and IsUsed=0";
            var result = _dapperHelper.Connection.Query(sql, new { Hash = hash });
        }

        public bool UpdatePassword(string password, int ID)
        {
            try
            {
                password = password.ToSha256();
                string sql = $@"UPDATE Admins SET Password = @Password Where ID = @ID ";
                var result = _dapperHelper.Connection.Query(sql, new { ID = ID, Password = password });
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }
    }
}
