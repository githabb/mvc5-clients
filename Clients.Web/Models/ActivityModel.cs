using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Clients.Web.Models
{
    public class ActivityModel
    {
        public int Id { get; set; }

        public int ClientId { get; set; }

        [Display(Name = "Комментарий")]
        public string CommentText { get; set; }

        [Display(Name = "Дата")]
        public DateTime CommentDate { get; set; }
    }
}