using Project.BLL.DesignPatterns.GenericRepository.ConcRep;
using Project.COMMON.Tools;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.WEBUI.Controllers
{
    public class ContactController : Controller
    {
        IssueRepository _iRep;
        MessageRepository _mRep;

        public ContactController()
        {
            _iRep = new IssueRepository();
            _mRep = new MessageRepository();
        }
        // GET: Contact
        public ActionResult AddTechnicalIssue()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddTechnicalIssue(Issue issue)
        {
            _iRep.Add(issue);

            string destekMail = "Destek talebinizi aldık. Sorununuzla ilgili en kısa zamanda tarafınıza dönüş yapılacaktır. İyi günler dileriz.";

            MailService.Send(issue.Email, body: destekMail, subject: "Teknoroma Destek Ekibi");

            return RedirectToAction("Contact", "Home");
        }

        public ActionResult AddMessage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddMessage(Message message)
        {
            message.MessageType = ENTITIES.Enums.MessageType.Advice;
            _mRep.Add(message);

            string destekMail = "Mesajınızı aldık. En kısa zamanda talebinizle iligili tarafınıza dönüş yapılacaktır. İyi günler dileriz.";

            MailService.Send(message.Email, body: destekMail, subject: "Teknoroma Destek Ekibi");

            return RedirectToAction("Contact", "Home");
        }
    }
}