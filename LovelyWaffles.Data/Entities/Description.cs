using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LovelyWaffles.Data.Entities
{
    public class Description
    {
        [Key]
        public int DescriptionID { get; set; }
        public string HeadDescription1 { get; set; }
        public string Description1 { get; set; }
        public string HeadDescription2 { get; set; }
        public string Description2 { get; set; }
        public string HeadDescription3 { get; set; }
        public string Description3 { get; set; }
        public string HeadDescription4 { get; set; }
        public string Description4 { get; set; }
    }
}