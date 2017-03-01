using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Clients.Data;
using Clients.Web.Models;

namespace Clients.Web.Controllers
{
    public class ClientController : Controller
    {
        public ActionResult Index()
        {
            IList<ClientModel> clients;
            using (Entities db = new Entities())
            {
                clients = (from b in db.Clients
                           select new ClientModel()
                           {
                               Id = b.Id,
                               Surname = b.Surname,
                               FirstName = b.FirstName,
                               Patronymic = b.Patronymic,
                               DateOfBirth = b.DateOfBirth
                           }).ToList();
            }

            return View(clients);
        }

        public ActionResult Display(int? id)
        {
            if(id == null)
                return HttpNotFound();

            using (Entities db = new Entities())
            {
                Client c = db.Clients.FirstOrDefault(com => com.Id == id);

                if (c != null)
                {
                    var client = new ClientModel()
                    {
                        Id = c.Id,
                        Surname = c.Surname,
                        FirstName = c.FirstName,
                        Patronymic = c.Patronymic,
                        DateOfBirth = c.DateOfBirth,
                        Activities = c.Activities.Select(a => new ActivityModel()
                        {
                            ClientId = a.ClientId,
                            CommentDate = a.CommentDate,
                            CommentText = a.CommenText
                        }).OrderByDescending(b => b.CommentDate).Take(5).ToList()
                    };

                    return View(client);
                }

                return HttpNotFound();
            }
        }
    }
}