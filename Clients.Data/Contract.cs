//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Clients.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Contract
    {
        public int id { get; set; }
        public int ClientId { get; set; }
        public string ContractNumber { get; set; }
        public System.DateTime Date { get; set; }
        public decimal Sum { get; set; }
    
        public virtual Client Client { get; set; }
    }
}
