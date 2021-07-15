using Business.Abstarct;
using Business.Concrete;
using DataAccess.EntityFramework;
using Entity.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        IAuthService authService = new AuthManager(new AdminManager(new EfAdminDal()), new WriterManager(new EfWriterDal()));
        RoleManager roleManager = new RoleManager(new EfRoleDal());
        StatusManager statusManager = new StatusManager(new EfStatusDal());

        [HttpGet]
        public ActionResult WriterRegister()
        {
            return View();
        }
        [HttpPost]
        public ActionResult WriterRegister(WriterLoginDto writerLoginDto)
        {
            authService.WriterRegister(
                writerLoginDto.WriterName,
                writerLoginDto.WriterSurName,
                writerLoginDto.WriterTitle,
                writerLoginDto.WriterAbout,
                writerLoginDto.WriterImage,
                writerLoginDto.WriterUserName,
                writerLoginDto.WriterMail,
                writerLoginDto.WriterPassword,
                writerLoginDto.WriterStatus = true
                );
            return RedirectToAction("MyContent", "WriterPanelContent");
        }
    }
}