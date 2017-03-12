using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Clients.Data;
using Clients.Web.Models;

namespace Clients.Web.Controllers
{
    [Authorize]
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
            if (id == null)
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
                        Contracts = c.Contracts.Select(a => new ContractModel()
                        {
                            ClientId = a.ClientId,
                            Date = a.Date,
                            ContractNumber = a.ContractNumber
                        }).OrderByDescending(b => b.Date).ToList(),
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

        [HttpGet]
        public ActionResult AddPhone(int? clientId)
        {
            if (clientId == null)
                return HttpNotFound();

            LoadDropDowns();

            ViewBag.ClientId = clientId;
            return PartialView();
            
        }

        [HttpPost]
        public ActionResult AddPhone(PhoneModel phone)
        {
            if (!ModelState.IsValid)
                return AddPhone(phone.ClientId);

            Phone dbPhone = new Phone()
            {
                ClientId = phone.ClientId,
                PhoneNumber = phone.PhoneNumber,
                PhoneTypeId = phone.PhoneTypeId
            };
            using (Entities db = new Entities())
            {
                db.Phones.Add(dbPhone);
                db.SaveChanges();
            }
            return RedirectToAction("Display", new { id = phone.ClientId });
        }


        private IList<NameItem> GetTypeList()
        {
            IList<PhoneType> phoneTypes;
            using (Entities db = new Entities())
            {
                phoneTypes = db.PhoneTypes.OrderBy(e => e.ShortName).ToList();
            }

            IList<NameItem> list = new List<NameItem>();
            list.Insert(0, new NameItem() { Id = null, Name = string.Empty });
            foreach (var m in phoneTypes)
            {
                list.Add(new NameItem() { Id = m.Id, Name = m.ShortName });
            }
            return list;
        }

        private void LoadDropDowns()
        {
           
            var type = GetTypeList();

            
            ViewBag.TypeList = new SelectList(type, "Id", "Name");
        }
    }
}