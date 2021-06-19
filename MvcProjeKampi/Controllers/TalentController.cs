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
    [Authorize]
    public class TalentController : Controller
    {
        TalentManager talentManager = new TalentManager(new EfTalentDal());
        public ActionResult Index()
        {
            var values = talentManager.GetList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddTalent()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddTalent(Talent talent)
        {
            talent.Name = "Volkan Uyduran";
            talent.About = "Kod Yazmayı Seviyorum";
            talentManager.TalentAdd(talent);
            return RedirectToAction("Index");
        }
    }
}