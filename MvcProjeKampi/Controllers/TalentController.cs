using Business.Concrete;
using DataAccess.EntityFramework;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using FluentValidation.Results;
using Business.ValidationRules;

namespace MvcProjeKampi.Controllers
{
    [Authorize]
    public class TalentController : Controller
    {
        TalentManager talentManager = new TalentManager(new EfTalentDal());
        SkillAreaManager skillAreaManager = new SkillAreaManager(new EfSkillAreaDal());
        TalentValidator talentValidator = new TalentValidator();

        public ActionResult Index(int? page)
        {
            var values = talentManager.GetList().ToPagedList(page ?? 1, 6);
            return View(values);
        }
        public ActionResult TalentCard(int? page)
        {
            var talentvalues = talentManager.GetList().ToPagedList(page ?? 1, 8);
            return View(talentvalues);
        }

        [HttpGet]
        public ActionResult AddTalent()
        {
            List<SelectListItem> _valueSkill = (from x in skillAreaManager.GetList()
                                                select new SelectListItem
                                                {
                                                    Text = x.Area,
                                                    Value = x.SkillAreaId.ToString()
                                                }).ToList();
            ViewBag.valueSkill = _valueSkill;
            return View();
        }
        [HttpPost ,ValidateInput(false)]
        public ActionResult AddTalent(Talent talent)
        {
            ValidationResult results = talentValidator.Validate(talent);
            if (results.IsValid)
            {
                talentManager.TalentAdd(talent);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        [HttpGet]
        public ActionResult UpdateTalent(int id)
        {
            List<SelectListItem> _valueSkill = (from x in skillAreaManager.GetList()
                                                select new SelectListItem
                                                {
                                                    Text = x.Area,
                                                    Value = x.SkillAreaId.ToString()
                                                }).ToList();
            ViewBag.valueSkill = _valueSkill;
            var talentValues = talentManager.GetByID(id);
            return View(talentValues);
        }
        [HttpPost]
        public ActionResult UpdateTalent(Talent talent)
        {
            talentManager.TalentUpdate(talent);
            return RedirectToAction("TalentCard");
        }
        public ActionResult DeleteTalent(int Id)
        {
            var talentValues = talentManager.GetByID(Id);
            talentManager.TalentDelete(talentValues);
            return RedirectToAction("TalentCard");
        }


    }
}