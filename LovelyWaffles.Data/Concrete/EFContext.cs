using LovelyWaffles.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LovelyWaffles.Data.Concrete
{
    public class EFContext : DbContext
    {
        public DbSet<IndexPage> IndexPages { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<PhotoGallery> PhotoGalleries { get; set; }
    }
}