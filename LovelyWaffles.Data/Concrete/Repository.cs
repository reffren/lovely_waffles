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
        public IQueryable<PhotoCarousel> PhotoCarousels
        {
            get { return context.PhotoCarousels; }
        }

        public void SavePhotoCarousel(PhotoCarousel photoCarousel)
        {
            if (photoCarousel.PhotoCarouselID == 0)
            {
                context.PhotoCarousels.Add(photoCarousel);
            }
            else
            {
                context.Entry(photoCarousel).State = EntityState.Modified;
            }
            context.SaveChanges();
        }

        public void DeletePhotoCarousel(PhotoCarousel photoCarousel)
        {
            context.Entry(photoCarousel).State = EntityState.Deleted;
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