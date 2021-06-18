using Business.Concrete;
using DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class GalleryController : Controller
    {
        ImageFileManager ImageFileManager = new ImageFileManager(new EfImageDal());
        public ActionResult Index()
        {
            var files=ImageFileManager.GetList();
            return View(files);
        }
    }
}