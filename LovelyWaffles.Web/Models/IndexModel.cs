using LovelyWaffles.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LovelyWaffles.Web.Models
{
    public class IndexModel
    {
        public Description Description { get; set; }
        public IEnumerable<Image> Images { get; set; }
    }
}