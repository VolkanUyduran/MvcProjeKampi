using Business.Concrete;
using DataAccess.EntityFramework;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace MvcProjeKampi.Controllers
{
    public class SkillAreaController : Controller
    {
        SkillAreaManager skillAreaManager = new SkillAreaManager(new EfSkillAreaDal());
        public ActionResult Index(int? page)
        {
            var skillvalues = skillAreaManager.GetList().ToPagedList(page ?? 1, 4);
            return View(skillvalues);
        }
        [HttpGet]
        public ActionResult AddSkillArea()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddSkillArea(SkillArea skill)
        {
            skillAreaManager.SkillAreaAdd(skill);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateSkillArea(int id)
        {
            var value = skillAreaManager.GetByIdSkillArea(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateSkillArea(SkillArea skill)
        {
            skillAreaManager.SkillAreaUpdate(skill);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteSkillArea(int Id)
        {
            var talentValues = skillAreaManager.GetByIdSkillArea(Id);
            skillAreaManager.SkillAreaDelete(talentValues);
            return RedirectToAction("Index");
        }


    }
}