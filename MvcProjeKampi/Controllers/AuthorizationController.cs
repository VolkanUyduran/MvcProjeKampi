using Business.Abstarct;
using Business.Concrete;
using DataAccess.EntityFramework;
using Entity.Concrete;
using Entity.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace MvcProjeKampi.Controllers
{
    public class AuthorizationController : Controller
    {
        AdminManager adminManager = new AdminManager(new EfAdminDal());
        IAuthService authService = new AuthManager(new AdminManager(new EfAdminDal()));
        RoleManager roleManager = new RoleManager(new EfRoleDal());
        StatusManager statusManager = new StatusManager(new EfStatusDal());
        public ActionResult Index(int? page)
        {
            var adminvalues = adminManager.GetAdmins().ToPagedList(page ?? 1, 8);
            return View(adminvalues);
        }
        [HttpGet]
        public ActionResult AddAdmin()
        {
            List<SelectListItem> adminRoleValue = (from x in roleManager.GetRoles()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.Description,
                                                       Value = x.RoleId.ToString()
                                                   }).ToList();

            List<SelectListItem> adminStatusValue = (from x in statusManager.GetList()
                                                     select new SelectListItem
                                                     {
                                                         Text = x.StatusName,
                                                         Value = x.StatusId.ToString()
                                                     }).ToList();
            ViewBag.valueAdminStatus = adminStatusValue;
            ViewBag.valueAdminRole = adminRoleValue;
            return View();
        }
        [HttpPost]
        public ActionResult AddAdmin(LoginDto loginDto)
        {
            authService.AdminRegister(loginDto.AdminUserName, loginDto.AdminMail, loginDto.AdminPassword,
                loginDto.AdminRoleId, loginDto.AdminStatusId);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateRole(int id)
        {
            List<SelectListItem> adminRoleValue = (from x in roleManager.GetRoles()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.Description,
                                                       Value = x.RoleId.ToString()
                                                   }).ToList();
          
            List<SelectListItem> adminstatusvalue = (from x in statusManager.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.StatusName,
                                                       Value = x.StatusId.ToString()
                                                   }).ToList();
            ViewBag.adminstatusvalue = adminstatusvalue;
            ViewBag.valueAdminRole = adminRoleValue;
            var adminValue = adminManager.GetById(id);
            return View(adminValue);
        }
        [HttpPost]
        public ActionResult UpdateRole(Admin admin)
        {
            adminManager.Update(admin);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteAdmin(int id)
        {
            var adminValue = adminManager.GetById(id);

            adminManager.Delete(adminValue);
            return RedirectToAction("Index");
        }
        public ActionResult ChangeAdminStatus(int id)
        {
            var adminValue = adminManager.GetById(id);

            if (adminValue.StatusId == 2)
            {
                adminValue.StatusId = 1; 
            }
            else
            {
                adminValue.StatusId = 2; 
            }

            adminManager.Update(adminValue);
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult UpdateProfile(int id)
        {
            List<SelectListItem> adminStatusValue = (from x in statusManager.GetList()
                                                     select new SelectListItem
                                                     {
                                                         Text = x.StatusName,
                                                         Value = x.StatusId.ToString()
                                                     }).ToList();



            List<SelectListItem> adminRoleValue = (from x in roleManager.GetRoles()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.Description,
                                                       Value = x.RoleId.ToString()
                                                   }).ToList();
            ViewBag.valueAdminStatus = adminStatusValue;
            ViewBag.valueAdminRole = adminRoleValue;
            var adminValue = adminManager.GetById(id);
            return View(adminValue);
        }
        [HttpPost]
        public ActionResult UpdateProfile(Admin admin)
        {
            adminManager.Update(admin);

            return RedirectToAction("Index");
        }
    }
}