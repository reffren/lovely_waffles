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
        IQueryable<Description> Descriptions { get; }
        void SaveDescription(Description description);

        IQueryable<Contact> Contacts { get; }
        void SaveContacts(Contact contact);

        IQueryable<Image> Images { get; }
        void SaveImage(Image image);
        void DeletePhotoCarousel(Image image);

        IQueryable<PhotoGallery> PhotoGalleries { get; }
        void SavePhotoGallery(PhotoGallery photo);
        void DeletePhotoGallery(PhotoGallery photo);
    }
}
