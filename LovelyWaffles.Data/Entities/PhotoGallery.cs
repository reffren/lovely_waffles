using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LovelyWaffles.Data.Entities
{
    public class PhotoGallery
    {
        [Key]
        public int PhotoID { get; set; }
        public string Photo { get; set; }
        public string Title { get; set; }
    }
}