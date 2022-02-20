using Domain.Domains;
using Services.ContentsServices;
using Services.MessagesServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dilek.Areas.Admin.Controllers
{
    public class IletisimController : BaseController
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
            result.Messages = _messagesServices.ShowMessages();
            return View(result);
        }
        [HttpPost]
        public ActionResult UpdateText(int ID, string title, string text, DateTime CreatedDate, int DBCode)
        {
            Contents content = new Contents()
            {
                CreatedDate = CreatedDate,
                DBCode = DBCode,
                ID = ID,
                Text = text,
                Title = title
            };
            var result = _contentService.UpdateContent(content);
            if (result)
                return RedirectToAction("Index");
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult DeleteText(int ID)
        {
            var result = _contentService.DeleteContent(ID);
            if (result)
                return RedirectToAction("Index");
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult AddText(string title, string text)
        {
            var result = _contentService.AddText(title, text, 11);
            if (result)
                return RedirectToAction("Index");
            return RedirectToAction("Index");
        }
    }
}