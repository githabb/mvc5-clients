using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Clients.Web.Models
{
    public class PhoneModel
    {
        public int Id { get; set; }

        [Required]
        public int ClientId { get; set; }

        [Required]
        [Display(Name = "Номер телефона")]
        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name = "Тип телефона")]
        public int PhoneTypeId { get; set; }

    }
}