using Business.Concrete;
using Business.ValidationRules;
using DataAccess.EntityFramework;
using Entity.Concrete;
using FluentValidation.Results;
using System;
using System.Linq;
using System.Web.Mvc;
using PagedList;

namespace MvcProjeKampi.Controllers
{
    public class MessageController : Controller
    {
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        MessageValidator messageValidator = new MessageValidator();

        [Authorize]
        public ActionResult Inbox(int? page)
        {
            string session = (string)Session["AdminMail"];
            var MessageList = messageManager.GetListInbox(session).ToPagedList(page ?? 1, 5);
            return View(MessageList);
        }
        public ActionResult Sendbox()
        {
            string session = (string)Session["AdminMail"];
            var messagelist = messageManager.GetListSendbox(session);
            return View(messagelist);
        }
        public ActionResult GetInboxMessageDetails(int id)
        {
            var values = messageManager.GetById(id);
            return View(values);
        }
        public ActionResult GetSendboxMessageDetails(int id)
        {
            var values = messageManager.GetById(id);
            return View(values);
        }
        public ActionResult GetUnReadMessageDetails(int id)
        {
            var values = messageManager.GetById(id);
            return View(values);
        }
        public ActionResult GetReadMessageDetails(int id)
        {
            var values = messageManager.GetById(id);
            return View(values);
        }
        [HttpGet]
        public ActionResult NewMessage()
        {

            return View();
        }
        [HttpPost]
        public ActionResult NewMessage(Message message, string button)
        {
            string session = (string)Session["AdminMail"];

            ValidationResult validationResult = messageValidator.Validate(message);
            if (button == "add")
            {
                if (validationResult.IsValid)
                {
                    message.SenderMail = session;
                    message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                    messageManager.MessageAdd(message);
                    return RedirectToAction("Sendbox");
                }
                else
                {
                    foreach (var item in validationResult.Errors)
                    {
                        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    }
                }
            }

            else if (button == "draft")
            {
                if (validationResult.IsValid)
                {

                    message.SenderMail = "admin@gmail.com";
                    message.IsDraft = true;
                    message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                    messageManager.MessageAdd(message);
                    return RedirectToAction("Draft");
                }
                else
                {
                    foreach (var item in validationResult.Errors)
                    {
                        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    }
                }
            }
            else if (button == "cancel")
            {
                return RedirectToAction("NewMessage");
            }

            return View();
        }
        public ActionResult AddDraft(Message message)
        {
            ValidationResult validationResult = messageValidator.Validate(message);
            if (validationResult.IsValid)
            {
                message.IsDraft = true;
                message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                messageManager.MessageAdd(message);
                return RedirectToAction("Draft");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return RedirectToAction("Draft");
        }
        public ActionResult DeleteMessage(int id)
        {
            var result = messageManager.GetById(id);
            if (result.Trash == true)
            {
                result.Trash = false;
            }
            else
            {
                result.Trash = true;
            }
            messageManager.MessageDelete(result);
            return RedirectToAction("Inbox");
        }
        public ActionResult Draft()
        {
            var result = messageManager.IsDraft();
            return View(result);
        }
        public ActionResult GetDraftDetails(int id)
        {
            var result = messageManager.GetById(id);
            return View(result);
        }
        public ActionResult IsRead(int id)
        {
            var result = messageManager.GetById(id);
            if (result.IsRead == false)
            {
                result.IsRead = true;
            }
            else
            {
                result.IsRead = false;
            }
            messageManager.MessageUpdate(result);
            return RedirectToAction("Inbox");
        }
        public ActionResult MessageRead(string p)
        {
            var result = messageManager.GetListInbox(p).Where(m => m.IsRead == true).ToList();
            return View(result);
        }
        public ActionResult MessageUnRead()
        {
            var result = messageManager.GetAllRead();
            return View(result);
        }
    }
}