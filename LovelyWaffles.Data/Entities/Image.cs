using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LovelyWaffles.Data.Entities
{
    public class Image
    {
        [Key]
        public int ImageID { get; set; }
        public string ImgCarouselTop { get; set; }
        public string Pictures { get; set; }
        public string Picture { get; set; }
        public string ImgCarouselDown { get; set; }
    }
}