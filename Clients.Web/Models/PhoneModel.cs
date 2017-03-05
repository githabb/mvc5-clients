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

        public int ClientId { get; set; }

        [Display(Name = "Номер телефона")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Тип телефона")]
        public int PhoneTypeId { get; set; }

    }
}