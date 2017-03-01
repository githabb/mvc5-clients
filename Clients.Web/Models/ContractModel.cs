using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Clients.Web.Models
{
    public class ContractModel
    {
        public int Id { get; set; }

        public int ClientId { get; set; }

        public string ContractNumber { get; set; }

        public DateTime Date { get; set; }

        public decimal Sum { get; set; }
    }
}