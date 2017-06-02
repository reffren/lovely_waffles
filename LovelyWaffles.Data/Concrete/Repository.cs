using LovelyWaffles.Data.Abstract;
using LovelyWaffles.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LovelyWaffles.Data.Concrete
{
    public class Repository : IRepository
    {
        private EFContext context = new EFContext();

        public IQueryable<IndexPage> IndexPages
        {
            get { return context.IndexPages; }
        }

        public void SavePhotoCarousel(IndexPage indexPage)
        {
            if (indexPage.IndexPageID == 0)
            {
                context.IndexPages.Add(indexPage);
            }
            else
            {
                context.Entry(indexPage).State = EntityState.Modified;
            }
            context.SaveChanges();
        }

        public void DeletePhotoCarousel(IndexPage indexPage)
        {
            context.Entry(indexPage).State = EntityState.Deleted;
            context.SaveChanges();
        }

        public IQueryable<Image> Images
        {
            get { return context.Images; }
        }

        public void SavePhotoCarousel(Image image)
        {
            if (image.ImageID == 0)
            {
                context.Images.Add(image);
            }
            else
            {
                context.Entry(image).State = EntityState.Modified;
            }
            context.SaveChanges();
        }

        public void DeletePhotoCarousel(Image image)
        {
            context.Entry(image).State = EntityState.Deleted;
            context.SaveChanges();
        }

        public IQueryable<PhotoGallery> PhotoGalleries
        {
            get { return context.PhotoGalleries; }
        }

        public void SavePhoto(PhotoGallery photo)
        {
            if (photo.PhotoID == 0)
            {
                context.PhotoGalleries.Add(photo);
            }
            else
            {
                context.Entry(photo).State = EntityState.Modified; // Indicating that the record is changed
            }
            context.SaveChanges();
        }

        public void DeletePhoto(PhotoGallery photo)
        {
            context.Entry(photo).State = EntityState.Deleted;
            context.SaveChanges();
        }
    }
}