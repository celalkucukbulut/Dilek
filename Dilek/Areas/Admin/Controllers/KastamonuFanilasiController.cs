using Domain.Domains;
using Services.ContentsServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dilek.Areas.Admin.Controllers
{
    public class KastamonuFanilasiController : BaseController
    {
        public readonly IContentsServices _contentsServices;
        public KastamonuFanilasiController()
        {
        }
        public KastamonuFanilasiController(
            IContentsServices contentsServices)
        {
            _contentsServices = contentsServices;
        }
        public ActionResult Index()
        {
            var result = _contentsServices.getAllContentsByDBCode(3);
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
            var result = _contentsServices.UpdateContent(content);
            if (result)
                return RedirectToAction("Index");
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult DeleteText(int ID)
        {
            var result = _contentsServices.DeleteContent(ID);
            if (result)
                return RedirectToAction("Index");
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult AddText(string title, string text)
        {
            var result = _contentsServices.AddText(title, text, 3);
            if (result)
                return RedirectToAction("Index");
            return RedirectToAction("Index");
        }
    }
}