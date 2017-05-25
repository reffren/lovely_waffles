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
    }
}