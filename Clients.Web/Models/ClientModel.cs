using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Clients.Web.Models
{
    public class ClientModel
    {
        public int Id { get; set; }

        [Display(Name = "Фамилия")]
        public string Surname { get; set; }

        [Display(Name = "Имя")]
        public string FirstName { get; set; }

        [Display(Name = "Отчество")]
        public string Patronymic { get; set; }

        [Display(Name = "Дата рождения")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DateOfBirth { get; set; }

        public IList<ActivityModel> Activities { get; set; }

        public ClientModel()
        {
            Activities = new List<ActivityModel>();
        }
    }
}