using LovelyWaffles.Data.Abstract;
using LovelyWaffles.Data.Entities;
using LovelyWaffles.Web.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        private IndexModel indexModel;
        private Image imageModel;

        public AdminController(IRepository repository)
        {
            _repository = repository;
        }

        [Authorize]
        public ActionResult Index()
        {
            indexModel = new IndexModel()
            {
                Images = _repository.Images.ToList()
            };
            return View(indexModel);
        }

        [HttpPost]
        public ActionResult EditCarouselTop([DefaultValue(0)]int id, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                imageModel = new Image();
                //delete an image
                if (id != 0)
                {
                    imageModel = _repository.Images.FirstOrDefault(f => f.ImageID == id);
                    string fullPath = Request.MapPath(imageModel.ImgCarouselTop); //delete from server
                    DeleteImage(fullPath);
                    imageModel.ImgCarouselTop = null;
                    _repository.SaveImage(imageModel);
                }
                //upload an image
                int count = _repository.Images.Where(w => w.ImgCarouselTop != null).Select(s => s.ImgCarouselTop).Count(); // we must have maximum 6 records in "ImgCarousel" column
                if (image != null && image.ContentLength > 0 && count < 7)
                {
                    string imgName = SaveImage(image, "~/Content/CarouselTopImages/");
                    var imageData = _repository.Images.FirstOrDefault(f => f.ImgCarouselTop == null); //update record where "ImgCarouselTop" column = NULL
                    if (imageData != null)
                        imageModel = imageData;
                    imageModel.ImgCarouselTop = "~/Content/CarouselTopImages/" + imgName; //if the record doesn't have NULL, we are create new record (but not more than 6 records)
                    if (imgName != null)
                        _repository.SaveImage(imageModel);
                }
                else
                {
                    return RedirectToAction("Index", "Admin");
                }
            }
            return RedirectToAction("Index", "Admin");
        }

        public ActionResult Edit3Pic([DefaultValue(0)]int id, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                imageModel = new Image();
                //delete an image
                if (id != 0)
                {
                    imageModel = _repository.Images.FirstOrDefault(f => f.ImageID == id);
                    string fullPath = Request.MapPath(imageModel.Pictures); //delete from server
                    DeleteImage(fullPath);
                    imageModel.Pictures = null;
                    _repository.SaveImage(imageModel);
                }

                //upload an image
                int count = _repository.Images.Where(w => w.Pictures != null).Select(s => s.Pictures).Count(); // we must have maximum 6 records in "ImgCarousel" column
                if (image != null && image.ContentLength > 0 && count < 3)
                {
                    string imgName = SaveImage(image, "~/Content/3pic/");
                    var imageData = _repository.Images.FirstOrDefault(f => f.Pictures == null); //update record where "ImgCarouselTop" column = NULL
                    if (imageData != null)
                        imageModel = imageData;
                    imageModel.Pictures = "~/Content/3pic/" + imgName; //if the record doesn't have NULL, we are create new record (but not more than 6 records)
                    if (imgName != null)
                        _repository.SaveImage(imageModel);
                }
                else
                {
                    return RedirectToAction("Index", "Admin");
                }
            }
            return RedirectToAction("Index", "Admin");
        }

        [HttpPost]
        public ActionResult Edit1Pic(HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                imageModel = new Image();
                //delete an image
                imageModel = _repository.Images.FirstOrDefault(f=>f.Picture != null);
                string fullPath = Request.MapPath(imageModel.Picture);
                DeleteImage(fullPath);
                //upload an image

                    string imgName = SaveImage(image, "~/Content/1pic/");
                    imageModel.Picture = "~/Content/1pic/" + imgName;
                    if (imgName != null)
                    _repository.SaveImage(imageModel);
            }
            return RedirectToAction("Index", "Admin");
        }
        public ActionResult EditPhotoGallery()
        {
            return View(_repository.PhotoGalleries.OrderByDescending(o => o.PhotoID).ToList());
        }

        [HttpPost]
        public ActionResult EditCarouselDown([DefaultValue(0)]int id, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                imageModel = new Image();
                //delete an image
                if (id != 0)
                {
                    imageModel = _repository.Images.FirstOrDefault(f => f.ImageID == id);
                    string fullPath = Request.MapPath(imageModel.ImgCarouselDown); //delete from server
                    DeleteImage(fullPath);
                    imageModel.ImgCarouselDown = null;
                    _repository.SaveImage(imageModel);
                }

                //upload an image
                int count = _repository.Images.Where(w => w.ImgCarouselDown != null).Select(s => s.ImgCarouselDown).Count(); // we must have maximum 6 records in "ImgCarousel" column
                if (image != null && image.ContentLength > 0 && count < 7)
                {
                    string imgName = SaveImage(image, "~/Content/CarouselDownImages/");
                    var imageData = _repository.Images.FirstOrDefault(f => f.ImgCarouselDown == null); //update record where "ImgCarouselTop" column = NULL
                    if (imageData != null)
                        imageModel = imageData;
                    imageModel.ImgCarouselDown = "~/Content/CarouselDownImages/" + imgName; //if the record doesn't have NULL, we are create new record (but not more than 6 records)
                    if (imgName != null)
                        _repository.SaveImage(imageModel);
                }
                else
                {
                    return RedirectToAction("Index", "Admin");
                }
            }
            return RedirectToAction("Index", "Admin");
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

        [Authorize]
        public ActionResult EditText()
        {
            return View(_repository.Descriptions.FirstOrDefault(f => f.DescriptionID != 0));
        }

        [HttpPost]
        public ActionResult EditText(Description model)
        {
            if (ModelState.IsValid)
            {
                _repository.SaveDescription(model);
            }
            return View();
        }

        [Authorize]
        public ActionResult EditContacts()
        {
            return View(_repository.Contacts.FirstOrDefault(f => f.ContactID != 0));
        }

        [HttpPost]
        public ActionResult EditContacts(Contact contact)
        {
            if (ModelState.IsValid)
            {
                _repository.SaveContacts(contact);
            }
            return View();
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

        public string SaveImage(HttpPostedFileBase image, string nameImg)
        {
            if (image != null && image.ContentLength > 0)
            {
                var imgName = Path.GetFileName(image.FileName);
                var path = Path.Combine(Server.MapPath(nameImg), System.IO.Path.GetFileName(image.FileName));
                image.SaveAs(path);
                return imgName;
            }
            return null;
        }

        public void DeleteImage(string fullPath)
        {
                if (System.IO.File.Exists(fullPath))
                {
                    System.IO.File.Delete(fullPath);
                }
        }
    }
}