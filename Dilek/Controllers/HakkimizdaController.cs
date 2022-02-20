using Services.ContentsServices;
using Services.ImagesServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dilek.Controllers
{
    public class HakkimizdaController : Controller
    {
        public readonly IImagesServices _imagesServices;
        public readonly IContentsServices _contentsServices;
        public HakkimizdaController()
        {
        }
        public HakkimizdaController(IImagesServices imagesServices,
            IContentsServices contentsServices)
        {
            _imagesServices = imagesServices;
            _contentsServices = contentsServices;
        }
        public ActionResult Index()
        {
            var result = _contentsServices.getAllContentsByDBCode(2);
            return View(result);
        }
    }
}