using LovelyWaffles.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LovelyWaffles.Web.Controllers
{
    public class HomeController : Controller
    {

        private IRepository _repository;

        public HomeController(IRepository repository)
        {
            _repository = repository;
        }
        public ActionResult Index()
        {
            return View(_repository.PhotoCarousels.ToList());
        }

        public ActionResult Gallery()
        {
            return View(_repository.PhotoGalleries.ToList());
        }
	}
}