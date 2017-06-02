using LovelyWaffles.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LovelyWaffles.Data.Abstract
{
    public interface IRepository
    {
        IQueryable<IndexPage> IndexPages { get; }
        void SavePhotoCarousel(IndexPage indexPage);
        void DeletePhotoCarousel(IndexPage indexPage);

        IQueryable<Image> Images { get; }
        void SavePhotoCarousel(Image image);
        void DeletePhotoCarousel(Image image);

        IQueryable<PhotoGallery> PhotoGalleries { get; }
        void SavePhoto(PhotoGallery photo);
        void DeletePhoto(PhotoGallery photo);
    }
}
