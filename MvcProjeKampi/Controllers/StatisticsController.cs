using DataAccess.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class StatisticsController : Controller
    {
        //Şart !=Toplam Kategori Sayısı
        //Şart 2=Yazılım Kategorisindeki Baslık Sayısı
        //Şart 3=Yazar Adında "a" Harfi Geçen Yazar Sayısı
        //Şart 4=En Fazla Başlıga Sahip Kategori Adı
        //Şart 5=Kategoriler Tablosundaki Aktif Kategori Sayısı

        Context _context = new Context();
        public ActionResult Index()
        {
            var totalCategory = _context.Categories.Count(); //=> 1.Şartımız
            ViewBag.totalNumberOfCategories = totalCategory;

            var softwareCategory = _context.Headings.Count(x => x.CategoryId == 9);// 2.Şartımız
            ViewBag.softwareCategoryTitleNumber = softwareCategory;

            var writerNameSortByA = _context.Writers.Count(x => x.WriterName.Contains("a")); //3.Şartımız
            ViewBag.writerNameSortByA = writerNameSortByA;

            var mostTitles = _context.Headings.Max(x => x.Category.CategoryName); //4.Şartımız
            ViewBag.categoryNameWithTheMostTitles = mostTitles;

            var categoryStatusTrue = _context.Categories.Count(x => x.CategoryStatus == true); // 5.Şartımız
            ViewBag.activeCategories = categoryStatusTrue;

            string session = (string)Session["AdminMail"];
            ViewBag.a = session;
            return View();
        }
    }
}