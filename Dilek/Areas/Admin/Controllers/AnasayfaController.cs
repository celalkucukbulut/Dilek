using Domain.Domains;
using Services.ContentsServices;
using Services.ImagesServices;
using Services.Results;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dilek.Areas.Admin.Controllers
{
    public class AnasayfaController : BaseController
    {
        private readonly IImagesServices _imagesServices;
        private readonly IContentsServices _contentsServices;
        public AnasayfaController(IImagesServices imagesServices
            , IContentsServices contentsService)
        {
            _imagesServices = imagesServices;
            _contentsServices = contentsService;
        }
        public ActionResult Index()
        {
            var result = new HomepageResult();
            result.Images = _imagesServices.getImagesByDBCodes(8);
            result.Contents = _contentsServices.getAllContentsByDBCode(1);
            return View(result);
        }
        [HttpPost]
        public ActionResult UploadFiles(HttpPostedFileBase files, string text)
        {
            if (files != null && files.ContentLength > 0)
            {
                var fileName = Path.GetFileName(files.FileName);
                var path = Path.Combine(Server.MapPath("~/Images"), fileName);
                files.SaveAs(path);
                _imagesServices.InsertSliderImage(fileName,text);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult UpdateText(int ID, string title, string text,DateTime CreatedDate, int DBCode)
        {
            Contents content = new Contents() {
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
            var result = _contentsServices.AddText(title, text,1);
            if (result)
                return RedirectToAction("Index");
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult DeleteSlider(int ID)
        {
            var result = _imagesServices.DeleteImage(ID);
            if (result)
                return RedirectToAction("Index");
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult UpdateSliderText(int ID, string text,DateTime CreatedDate, int DBCode,string Code,string FilePath)
        {
            var result = _imagesServices.UpdateImage(ID, text, CreatedDate, DBCode, Code, FilePath);
            if (result)
                return RedirectToAction("Index");
            return RedirectToAction("Index");
        }

    }
}