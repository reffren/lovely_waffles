using LovelyWaffles.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LovelyWaffles.Web.Controllers
{
    public class ContactController : Controller
    {
        private IRepository _repository;

        public ContactController(IRepository repository)
        {
            _repository = repository;
        }
        public PartialViewResult Contacts()
        {
            return PartialView(_repository.Contacts.FirstOrDefault(f => f.ContactID != 0));
        }
	}
}