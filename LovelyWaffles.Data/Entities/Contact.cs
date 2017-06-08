using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LovelyWaffles.Data.Entities
{
    public class Contact
    {
        [Key]
        public int ContactID { get; set; }

        [Required(ErrorMessage = "Не заполнено поле 'Адрес'")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Не заполнено поле 'Телефон'")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Не заполнено поле 'Email'")]
        public string Email { get; set; }
    }
}