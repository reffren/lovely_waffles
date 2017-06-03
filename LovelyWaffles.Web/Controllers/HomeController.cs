using LovelyWaffles.Data.Abstract;
using LovelyWaffles.Data.Entities;
using LovelyWaffles.Web.Models;
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
        private IndexModel indexModel;
        const int picturesPerPage = 9;

        public HomeController(IRepository repository)
        {
            _repository = repository;
        }
        public ActionResult Index()
        {
            indexModel = new IndexModel()
            {
                Description = _repository.Descriptions.FirstOrDefault(f => f.DescriptionID != 0),
                Images = _repository.Images.ToList()
            };
            return View(indexModel);
        }

        public ActionResult Gallery(int? id)
        {
            var page = id ?? 0;

            if (Request.IsAjaxRequest())
            {
                return PartialView("_Pictures", GetPaginatedPictures(page));
            }

            return View("Gallery", _repository.PhotoGalleries.Where(x => x.Photo != null).OrderByDescending(o => o.PhotoID).Take(picturesPerPage));
        }

        private List<PhotoGallery> GetPaginatedPictures(int page = 1)
        {
            var skipPictures = page * picturesPerPage;

            var listOfProducts = _repository.PhotoGalleries.Where(x => x.Photo != null).OrderByDescending(o => o.PhotoID);

            return listOfProducts.Skip(skipPictures).Take(picturesPerPage).ToList();
        }
	}
}