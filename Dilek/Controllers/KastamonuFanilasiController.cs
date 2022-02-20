using Services.ContentsServices;
using Services.DBCodesServices;
using Services.ImagesServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dilek.Controllers
{
    public class KastamonuFanilasiController : Controller
    {
        public readonly IImagesServices _imagesServices;
        public readonly IDBCodesServices _dbCodesServices;
        public readonly IContentsServices _contentsServices;
        public KastamonuFanilasiController()
        {
        }
        public KastamonuFanilasiController(IImagesServices imagesServices,
            IContentsServices contentsServices,
            IDBCodesServices dbCodesServices)
        {
            _imagesServices = imagesServices;
            _contentsServices = contentsServices;
            _dbCodesServices = dbCodesServices;
        }
        public ActionResult Index()
        {
            var result = _contentsServices.getAllContentsByDBCode(3);
            return View(result);
        }
    }
}