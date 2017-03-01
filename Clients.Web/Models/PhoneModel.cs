using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Clients.Web.Models
{
    public class PhoneModel
    {
        public int Id { get; set; }

        public int ClientId { get; set; }

        public string PhoneNumber { get; set; }

        public int PhoneTypeId { get; set; }

    }
}