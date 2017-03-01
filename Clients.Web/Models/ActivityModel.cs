using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Clients.Web.Models
{
    public class ActivityModel
    {
        public int Id { get; set; }

        public int ClientId { get; set; }

        public string CommentText { get; set; }

        public DateTime CommentDate { get; set; }
    }
}