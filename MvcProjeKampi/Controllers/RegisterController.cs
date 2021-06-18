﻿using Business.Abstarct;
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
    public class RegisterController : Controller
    {

        IAuthService authService = new AuthManager(new AdminManager(new EfAdminDal()), new WriterManager(new EfWriterDal()));
        // GET: Register
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(LoginDto loginDto)
        {
            authService.Register(loginDto.AdminUserName, loginDto.AdminPassword);
            return RedirectToAction("Index", "AdminCategory");
        }

        [HttpGet]
        public ActionResult WriterRegister()
        {
            return View();
        }
        [HttpPost]
        public ActionResult WriterRegister(WriterLoginDto writerLoginDto)
        {
            authService.WriterRegister(writerLoginDto.WriterEmail, writerLoginDto.WriterPassword);
            return RedirectToAction("MyContent", "WriterPanelContent");
        }
    }
}