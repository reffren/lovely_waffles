using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LovelyWaffles.Data.Entities
{
    public class PhotoCarousel
    {
        [Key]
        public int PhotoCarouselID { get; set; }
        public string Photo { get; set; }
        public string PhotoName { get; set; }
    }
}