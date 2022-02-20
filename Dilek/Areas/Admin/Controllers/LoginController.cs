using Services.AdminsServices;
using Services.ForgotPasswordServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Security;

namespace Dilek.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        private readonly IAdminsServices _adminServices;
        private readonly IForgotPasswordServices _forgotPasswordServices;
        public LoginController(IAdminsServices adminServices, IForgotPasswordServices forgotPasswordServices)
        {
            _adminServices = adminServices;
            _forgotPasswordServices = forgotPasswordServices;
        }
        public ActionResult Index()
        {
            if (HttpContext.Request.IsAuthenticated)
            {
                return RedirectToAction("Index", "Anasayfa", new { Area = "Admin" });
            }
            return View();
        }
        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            Domain.Domains.Admin admin = null;
            var checkUser = _adminServices.CheckLogin(username,password,ref admin);
            if (!checkUser)
                return RedirectToAction("Index", "Login", new { Area = "Admin" });

            var serializeModel = new UserPrincipalSerializeModel
            {
                ID = admin.ID,
                Name = admin.Name,
                Surname = admin.Surname,
                Username = admin.Username,
                MailAddress = admin.MailAddress
            };
            string userData = new JavaScriptSerializer().Serialize(serializeModel);
            FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(1, serializeModel.MailAddress, DateTime.Now, DateTime.Now.AddMinutes(1), false, userData);
            string encTicket = FormsAuthentication.Encrypt(authTicket);
            HttpCookie faCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
            Response.Cookies.Add(faCookie);
            return RedirectToAction("Index","Anasayfa",new { Area = "Admin" });
        }
        //[HttpPost]
        //public ActionResult Forgot(string mailAddress)
        //{
        //    var checkAdmin = _adminServices.CheckUserExist(mailAddress);
        //    if (!checkAdmin)
        //        return View("Index");

        //    var isSentMail = _adminServices.SendMail(mailAddress);
        //    return RedirectToAction("Index", "Login", new { Area = "Admin" });
        //}
        public ActionResult SifreYenile(string hash)
        {
            int ID=0;
            var dbHash = _forgotPasswordServices.GetLastHashCode(hash,ref ID);
            if (dbHash)
            {
                _forgotPasswordServices.updateIsUsed(hash);
                return View(ID);
            }
            return RedirectToAction("Index", "Login", new { Area = "Admin" });
        }
        [HttpPost]
        public ActionResult UpdatePassword(string password,int ID)
        {
            var result = _forgotPasswordServices.UpdatePassword(password,ID);
            if (result)
            {
                return RedirectToAction("Index", "Login", new { Area = "Admin" });
            }
            return View();
        }
    }
}