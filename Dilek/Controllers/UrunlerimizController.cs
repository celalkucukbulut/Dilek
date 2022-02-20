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
    public class UrunlerimizController : Controller
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
            return View(result);
        }
    }
}