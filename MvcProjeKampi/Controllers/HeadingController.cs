using Business.Concrete;
using DataAccess.EntityFramework;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class HeadingController : Controller
    {
        // GET: Heading
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        WriterManager wm = new WriterManager(new EfWriterDal());

        public ActionResult Index()
        {
            var headingvalues = hm.GetList();
            return View(headingvalues);
        }
        [HttpGet]
        public ActionResult AddHeading()
        {
            List<SelectListItem> valuecategory = (from x in cm.GetList()
                                                  select new SelectListItem 
                                                  {
                                                    Text=x.CategoryName,
                                                    Value=x.CategoryId.ToString()
                                                  }
                                                ).ToList();

            List<SelectListItem> valuewriter = (from y in wm.GetList()
                                                select new SelectListItem
                                                {
                                                    Text=y.WriterName + " " +y.WriterSurname,
                                                    Value=y.WriterId.ToString()
                                                }).ToList();

            ViewBag.vlw = valuewriter;
            ViewBag.vlc = valuecategory;
            return View();
        }
        [HttpPost]
        public ActionResult AddHeading(Heading p)
        {
            p.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            hm.Add(p);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditHeading(int id)
        {
            List<SelectListItem> valuecategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryId.ToString()
                                                  }
                                               ).ToList();
            ViewBag.vlc = valuecategory;
            var headingvalue = hm.GetById(id);
            return View(headingvalue);
        }
        [HttpPost]
        public ActionResult EditHeading(Heading p)
        {
            hm.Update(p);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteHeading(int id)
        {
            var headingid = hm.GetById(id);
            headingid.HeadingStatus = false;
            hm.Delete(headingid);
            return RedirectToAction("Index");
            
        }
        public ActionResult Active(int id)
        {
            var heading = hm.GetById(id);
            hm.Active(heading);
            return RedirectToAction("Index");
        }
    }
}