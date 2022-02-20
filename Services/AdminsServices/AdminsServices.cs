using Domain.Domains;
using Infrastructure.Interfaces;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace Services.AdminsServices
{
    public class AdminsServices : IAdminsServices
    {
        private readonly IAdminsRepository _adminRepository;
        private readonly IForgotPasswordRepository _forgotPasswordRepository;
        public AdminsServices(IAdminsRepository adminRepository,
            IForgotPasswordRepository forgotPasswordRepository)
        {
            _adminRepository = adminRepository;
            _forgotPasswordRepository = forgotPasswordRepository;
        }
        public bool CheckLogin(string username, string password,ref Admin admin)
        {
            var result = _adminRepository.Login(username, password);
            if (result == null)
                return false;
            admin = result;
            return true;
        }

        public bool CheckUserExist(string mailAddress)
        {
            var result = _adminRepository.checkUserExist(mailAddress);
            return result;
        }

        public bool SendMail(string mailAddress)
        {
            var admin = _adminRepository.getAdminByEmail(mailAddress);
            try
            {
                Guid GUID1 = Guid.NewGuid();
                Guid GUID2 = Guid.NewGuid();
                Guid GUID3 = Guid.NewGuid();
                string hash = GUID1.ToString() + GUID2.ToString() + GUID3.ToString();
                var forgot = new ForgotPassword()
                {
                    CreatedDate = DateTime.Now,
                    AdminId = admin.ID,
                    Hash = hash,
                    IsUsed = false
                };
                _forgotPasswordRepository.Add(forgot);
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress("mailaddress"); // todo mail address
                mail.To.Add(mailAddress);
                mail.Subject = "Şifre Yenileme";
                mail.Body = @"Merhaba "+admin.Name + " " + admin.Surname + @",

Şifrenizi aşağıdaki linke tıklayarak yeniden oluşturabilirsiniz.

http://localhost:3417/Admin/Login/SifreYenile?hash=" + hash+@"

İyi Günler.";

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("mailaddress", "password"); // todo mailadress password
                SmtpServer.EnableSsl = true;
                SmtpServer.Timeout = 20000;

                SmtpServer.Send(mail);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
