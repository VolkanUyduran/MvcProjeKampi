using Business.Concrete;
using Business.ValidationRules;
using DataAccess.Concrete;
using DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class ContactController : Controller
    {
        
        ContactManager contactManager = new ContactManager(new EfContactDal());
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        ContactValidator cv = new ContactValidator();
        
        public ActionResult Index()
        {
            var contactvalues = contactManager.GetList();
            return View(contactvalues);
        }
        public ActionResult GetContactDetails(int id)
        {
            var contactvalues = contactManager.GetById(id);
            return View(contactvalues);
        }
        public PartialViewResult Menu(string p)
        {
            var receiverMail = messageManager.GetListInbox(p).Count();
            ViewBag.receiverMail = receiverMail;

            var senderMail = messageManager.GetListSendbox(p).Count();
            ViewBag.senderMail = senderMail;

            var draftMail = messageManager.GetListSendbox(p).Where(x => x.IsDraft == true).Count();
            ViewBag.draftMail = draftMail;

            var contact = contactManager.GetList().Count();
            ViewBag.contact = contact;

            var unreadMail = messageManager.GetAllRead().Count();
            ViewBag.unreadMail = unreadMail;

            var readMail = messageManager.GetListInbox(p).Where(x => x.IsRead == true).Count();
            ViewBag.readMail = readMail;

            return PartialView();
        }
        public ActionResult IsRead(int id)
        {
            var contactvalue = contactManager.GetById(id);
            if (contactvalue.IsRead)
            {
                contactvalue.IsRead = false;
            }
            else
            {
                contactvalue.IsRead = true;
            }
            contactManager.Update(contactvalue);
            return RedirectToAction("Index");
        }
        public ActionResult IsImportant(int id)
        {
            var contactvalue = contactManager.GetById(id);
            if (contactvalue.IsImportant)
            {
                contactvalue.IsImportant = false;
            }
            else
            {
                contactvalue.IsImportant = true;
            }
            contactManager.Update(contactvalue);
            return RedirectToAction("Index");
        }
    }
}