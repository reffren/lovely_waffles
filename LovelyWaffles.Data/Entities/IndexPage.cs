using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LovelyWaffles.Data.Entities
{
    public class IndexPage
    {
        [Key]
        public int IndexPageID { get; set; }
        public string HeadDescription1 { get; set; }
        public string Description1 { get; set; }
        public string HeadDescription2 { get; set; }
        public string Description2 { get; set; }
        public string Picture { get; set; }
        public string HeadDescription3 { get; set; }
        public string Description3 { get; set; }
        public string HeadDescription4 { get; set; }
        public string Description4 { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public virtual ICollection<Image> Images { get; set; }
    }
}