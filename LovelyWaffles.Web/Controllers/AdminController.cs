using LovelyWaffles.Data.Abstract;
using LovelyWaffles.Data.Entities;
using LovelyWaffles.Web.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace LovelyWaffles.Web.Controllers
{
    public class AdminController : Controller
    {
        private IRepository _repository;

        public AdminController(IRepository repository)
        {
            _repository = repository;
        }

        [Authorize]
        public ActionResult Index()
        {
            return View(_repository.IndexPages.FirstOrDefault(f => f.IndexPageID != 0));
        }

        public ActionResult EditPhotoGallery()
        {
            return View(_repository.PhotoGalleries.OrderByDescending(o=>o.PhotoID).ToList());
        }

        [HttpPost]
        public ActionResult EditImages(PhotoGallery galley, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                if (image != null && image.ContentLength > 0)
                {
                    var imgName = Path.GetFileName(image.FileName);
                    var path = Path.Combine(Server.MapPath("~/Content/GalleryPhoto/"), System.IO.Path.GetFileName(image.FileName));
                    image.SaveAs(path);
                    galley.Photo = "~/Content/GalleryPhoto/" + imgName;
                    _repository.SavePhoto(galley);
                }
                else if (galley.PhotoID != 0)
                {
                    galley = _repository.PhotoGalleries.FirstOrDefault(f => f.PhotoID == galley.PhotoID);

                    string fullPath = Request.MapPath(galley.Photo); //delete from server
                    if (System.IO.File.Exists(fullPath))
                    {
                        System.IO.File.Delete(fullPath);
                    }
                    _repository.DeletePhoto(galley);
                }
            }
            return RedirectToAction("EditPhotoGallery", "Admin");
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            LoginViewModel model = new LoginViewModel();

            return View(model);
        }

        // POST: /Account/Login
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (this.ModelState.IsValid && FormsAuthentication.Authenticate(model.UserName, model.Password))
            {
                FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
                if (this.Url.IsLocalUrl(returnUrl))
                {
                    return Redirect(returnUrl);
                }
                else
                {
                    return RedirectToAction("Index", "admin");
                }
            }

            // If we got this far, something failed, redisplay form
            this.ModelState.AddModelError("", "Неверное имя пользователя или пароль.");
            return View(model);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }
	}
}