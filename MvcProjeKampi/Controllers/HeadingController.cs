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
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        WriterManager writerManager = new WriterManager(new EfWriterDal());

        public ActionResult Index()
        {
            var headingvalues = headingManager.GetList();
            return View(headingvalues);
        }
        public ActionResult HeadingReport()
        {
            var headingValues = headingManager.GetList();
            return View(headingValues);
        }
        [HttpGet]
        public ActionResult AddHeading()
        {
            List<SelectListItem> valuecategory = (from x in categoryManager.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryId.ToString()
                                                  }
                                                ).ToList();

            List<SelectListItem> valuewriter = (from y in writerManager.GetList()
                                                select new SelectListItem
                                                {
                                                    Text = y.WriterName + " " + y.WriterSurname,
                                                    Value = y.WriterId.ToString()
                                                }).ToList();

            ViewBag.vlw = valuewriter;
            ViewBag.vlc = valuecategory;
            return View();
        }
        [HttpPost]
        public ActionResult AddHeading(Heading p)
        {
            p.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            headingManager.Add(p);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditHeading(int id)
        {
            List<SelectListItem> valuecategory = (from x in categoryManager.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryId.ToString()
                                                  }
                                               ).ToList();
            ViewBag.vlc = valuecategory;
            var headingvalue = headingManager.GetById(id);
            return View(headingvalue);
        }
        [HttpPost]
        public ActionResult EditHeading(Heading p)
        {
            headingManager.Update(p);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteHeading(int id)
        {
            var headingValue = headingManager.GetById(id);

            if (headingValue.StatusId == 2)
            {
                headingValue.StatusId = 1;
            }
            else
            {
                headingValue.StatusId = 2;
            }
            headingManager.Delete(headingValue);
            return RedirectToAction("Index");

        }
        public ActionResult Active(int id)
        {
            var heading = headingManager.GetById(id);
            headingManager.Active(heading);
            return RedirectToAction("Index");
        }
        

    }
}