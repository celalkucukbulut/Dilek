using Domain.Domains;
using Domain.Enums;
using Services.ContentsServices;
using Services.DBCodesServices;
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
    public class UrunlerimizController : BaseController
    {
        public readonly IImagesServices _imagesServices;
        public readonly IDBCodesServices _dbCodesServices;
        public readonly IContentsServices _contentsServices;
        public UrunlerimizController()
        {
        }
        public UrunlerimizController(IImagesServices imagesServices,
            IContentsServices contentsServices,
            IDBCodesServices dbCodesServices)
        {
            _imagesServices = imagesServices;
            _contentsServices = contentsServices;
            _dbCodesServices = dbCodesServices;
        }
        public ActionResult Index()
        {
            var result = new ProductResult();
            result.Images = _imagesServices.getAllProducts();
            result.Contents = _contentsServices.getAllProductContents();
            result.Gender = Gender.Female;
            return View(result);
        }
        [HttpPost]
        public ActionResult UploadFiles(HttpPostedFileBase files, string text,Gender gender)
        {
            if (files != null && files.ContentLength > 0)
            {
                var fileName = Path.GetFileName(files.FileName);
                var path = Path.Combine(Server.MapPath("~/Images"), fileName);
                files.SaveAs(path);
                _imagesServices.InsertImage(fileName, text,(int)gender);
            }
            return RedirectToAction("Index");
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
        public ActionResult AddText(string title, string text,int? gender)
        {
            if (!(gender.HasValue))
                gender = 10;

            var result = _contentsServices.AddText(title, text, gender.Value);
            if (result)
                return RedirectToAction("Index");
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult DeleteImage(int ID)
        {
            var result = _imagesServices.DeleteImage(ID);
            if (result)
                return RedirectToAction("Index");
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult UpdateImageText(int ID, string text, DateTime CreatedDate, int DBCode, string Code, string FilePath)
        {
            var result = _imagesServices.UpdateImage(ID, text, CreatedDate, DBCode, Code, FilePath);
            if (result)
                return RedirectToAction("Index");
            return RedirectToAction("Index");
        }
    }
}