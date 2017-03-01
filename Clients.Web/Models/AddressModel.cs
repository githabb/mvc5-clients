using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Clients.Web.Models
{
    public class AddressModel
    {

        public int Id { get; set; }

        public int ClientId { get; set; }

        public string AddressText { get; set; }

        public int AddressTypeId { get; set; }
    }
}