using Domain.Domains;
using Services.ContentsServices;
using Services.DBCodesServices;
using Services.ImagesServices;
using Services.MessagesServices;
using System.Web.Mvc;

namespace Dilek.Controllers
{
    public class IletisimController : Controller
    {
        public readonly IMessagesServices _messagesServices;
        public readonly IContentsServices _contentService;
        public IletisimController()
        {
        }
        public IletisimController(
            IMessagesServices messagesServices,
            IContentsServices contentService)
        {
            _messagesServices = messagesServices;
            _contentService = contentService;
        }
        public ActionResult Index()
        {
            var result = _contentService.getAllContactContents();
            return View(result);
        }
        [HttpPost]
        public ActionResult SendUs(Messages message)
        {
            var result = _messagesServices.InsertMessage(message);
            if (result)
            {
                return RedirectToAction("MesajinizAlindi", "Iletisim");
            }
            return RedirectToAction("Index", "Iletisim"); ;
        }
        public ActionResult MesajinizAlindi()
        {
            return View();
        }
    }
}