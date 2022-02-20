using Domain.Domains;
using Services.ContentsServices;
using Services.DBCodesServices;
using Services.ImagesServices;
using Services.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dilek.Controllers
{
    public class AnasayfaController : Controller
    {

        public readonly IImagesServices _imagesServices;
        public readonly IDBCodesServices _dbCodesServices;
        public readonly IContentsServices _contentsServices;
        public AnasayfaController()
        {
        }
        public AnasayfaController(IImagesServices imagesServices,
            IContentsServices contentsServices,
            IDBCodesServices dbCodesServices)
        {
            _imagesServices = imagesServices;
            _contentsServices = contentsServices;
            _dbCodesServices = dbCodesServices;
        }
        public ActionResult Index()
        {
            var result = new HomepageResult();
            result.Images = _imagesServices.getImagesByDBCodes(8);
            result.Contents = _contentsServices.getAllContentsByDBCode(1);
            return View(result);
        }
    }
}