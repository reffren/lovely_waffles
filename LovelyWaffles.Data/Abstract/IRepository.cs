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
        IQueryable<PhotoCarousel> PhotoCarousels { get; }
        void SavePhotoCarousel(PhotoCarousel photoCarousel);
        void DeletePhotoCarousel(PhotoCarousel photoCarousel);
    }
}
